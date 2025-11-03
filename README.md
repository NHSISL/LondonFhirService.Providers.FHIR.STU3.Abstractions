# 🔥 LondonFhirService — FHIR - STU3 Abstractions

[![Build](https://github.com/NHSISL/LondonFhirService.Providers.FHIR.STU3.Abstractions/actions/workflows/build.yml/badge.svg)](https://github.com/NHSISL/LondonFhirService.Providers.FHIR.STU3.Abstractions/actions/workflows/build.yml)
[![Nuget](https://img.shields.io/nuget/v/LondonFhirService.Providers.FHIR.STU3.Abstractions?logo=nuget\&style=default\&color=blue)](https://www.nuget.org/packages/LondonFhirService.Providers.FHIR.STU3.Abstractions)
![Nuget](https://img.shields.io/nuget/dt/LondonFhirService.Providers.FHIR.STU3.Abstractions?color=blue\&label=Downloads)
----------------------------------------------------------------------------------------------------------------------

> A small, focused abstraction layer that lets you write your own concrete FHIR provider by implementing
> a couple of simple interfaces and base classes. It also ships with a **Capabilities** discovery feature
> so your provider can describe exactly which resources and operations it supports.

---

## Why this library?

* **Pluggable providers.** Implement `FhirProviderBase` and `IFhirProvider` to bring your own FHIR backend.
* **Resource‑first design.** Each FHIR resource (e.g., `Patient`) has its own operations via
  `ResourceOperationBase<TResource>` and a matching interface.
* **Discoverable capabilities.** Providers and resources automatically declare what they support — including
  custom operations — so callers can make safe, data‑driven decisions at runtime.

---

## Core concepts

### 1) Providers

A **provider** is your concrete integration with a FHIR‑compatible system. Implement it by inheriting from
`FhirProviderBase` and implementing `IFhirProvider`.

```csharp
using Hl7.Fhir.Model;
using LondonFhirService.Providers.FHIR.STU3.Abstractions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Extensions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities;

public sealed class MyFhirProvider : FhirProviderBase, IFhirProvider
{
    public IPatientResource Patients { get; }

    public MyFhirProvider()
    {
        // Wire up your supported concrete resource operations here
        // No need to implement anything else that is not supported
        Patients = new PatientResource();
    }
}
```

### 2) Resource operations

Every FHIR resource gets its own operations class that derives from `ResourceOperationBase<TResource>` and
implements the matching interface (e.g., `IPatientResource`).

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities;

public sealed class PatientResource : ResourceOperationBase<Patient>, IPatientResource
{
    // Standard operations (Read, VRead, Search, History*, etc.)
    // are inherited. Override only the ones you actually support.

    // Example: custom operation (see next section for [FhirOperation])
    public ValueTask<Bundle> Match(Parameters parameters, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
```

> Note: The pattern is the same for any resource (AllergyIntolerance, Encounter, Observation, etc.).

---

## Custom operations (beyond `IResourceOperation<TResource>`)

Operations are **not limited** to the standard surface of `IResourceOperation<TResource>`. You can add custom
operations — like `$everything` on `Patient` — by simply adding a public method on your resource class and
marking it with the `[FhirOperation]` attribute. The Capabilities scanner will then detect and include it
as a supported operation.

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities;

public sealed class PatientResource : ResourceOperationBase<Patient>, IPatientResource
{
    /// <summary>
    /// Patient plus related resources ($everything). Returns a searchset Bundle.
    /// Optional args align with common server conventions.
    /// </summary>
    /// <param name="id">Logical id of the patient resource.</param>
    /// <param name="start">Optional start date/time for records to include.</param>
    /// <param name="end">Optional end date/time for records to include.</param>
    /// <param name="typeFilter">Optional FHIR resource type filter (_type).</param>
    /// <param name="since">Optional timestamp for changes since (_since).</param>
    /// <param name="count">Optional page size limit (_count).</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    [FhirOperation]
    public ValueTask<Bundle> Everything(
        string id,
        DateTimeOffset? start = null,
        DateTimeOffset? end = null,
        string typeFilter = null,
        DateTimeOffset? since = null,
        int? count = null,
        CancellationToken cancellationToken = default)
    {
        // Implement your callout to the underlying system here.
        return new ValueTask<Bundle>(new Bundle { Type = Bundle.BundleType.Searchset });
    }

    public ValueTask<Bundle> Match(Parameters parameters, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
```

---

## Capabilities

**Capabilities** are computed metadata that describe what your provider and resources support. They power
feature detection, documentation, and guard checks at runtime.

* **Provider capabilities** include provider name and a list of supported resources.
* **Resource capabilities** list supported operations. Methods decorated with `[FhirOperation]` are automatically
  added, alongside the standard operations you override on `ResourceOperationBase<TResource>`.

### Example: printing capabilities

```csharp
IFhirProvider provider = new MyFhirProvider();
var capabilities = provider.Capabilities;
Console.WriteLine($"Provider: {capabilities.ProviderName}");

foreach (var resource in capabilities.SupportedResources)
{
    Console.WriteLine($"  Resource: {resource.ResourceName}");

    foreach (var operation in resource.SupportedOperations)
    {
        Console.WriteLine($"    Operation: {operation}");
    }
}
```

### What gets picked up?

* Any overridden standard operation on `ResourceOperationBase<TResource>`.
* Any public method on your resource class marked with `[FhirOperation]`.

---

## FhirProviderGuards extensions

The **guards** are convenience extension methods for answering questions like:

* “Does this provider support the `Patient` resource?”
* “Does it support the `Everything` operation on `Patient`?”
* “Which of these providers support `Everything` for `Patient`?”

### Single provider

```csharp
IFhirProvider provider = new MyFhirProvider();
bool supportPatientResource = provider.SupportsResource("Patient");
bool supportEverythingOperationOnPatientResource = provider.SupportsResource("Patient", "Everything");
```

### Multiple providers

```csharp
IEnumerable<IFhirProvider> providers = new[] { new AProvider(), new BProvider() };

// Filter down to providers that support a resource + operation
IEnumerable<IFhirProvider> supportingProviders = providers.SupportsResource("Patient", "Everything");

// Just the resource (any operation)
IEnumerable<IFhirProvider> patientProviders = providers.SupportsResource("Patient");
```

These guards respect null/empty input and will return an empty sequence or `false` without throwing.

---

## Putting it together: minimal provider

```csharp
public sealed class MinimalProvider : FhirProviderBase, IFhirProvider
{
    public IPatientResource Patients { get; } = new MinimalPatientResource();
}

public sealed class MinimalPatientResource : ResourceOperationBase<Patient>, IPatientResource
{
    [FhirOperation]
    public ValueTask<Bundle> Everything(
        string id,
        DateTimeOffset? start = null,
        DateTimeOffset? end = null,
        string typeFilter = null,
        DateTimeOffset? since = null,
        int? count = null,
        CancellationToken cancellationToken = default)
        => new(new Bundle { Type = Bundle.BundleType.Searchset });

    public ValueTask<Bundle> Match(Parameters parameters, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
```

### Usage
```csharp
var provider = new MinimalProvider();

if (provider.SupportsResource("Patient", "Everything"))
{
    var bundle = await provider.Patients.Everything("12345");
}
```


---

## Testing suggestions (and production usage)

* Assert that your provider Capabilities include the resources and operations you expect.
* Use the guards to keep tests expressive:

```csharp
IFhirProvider provider = new MinimalProvider();
provider.SupportsResource("Patient").Should().BeTrue();
provider.SupportsResource("Patient", "Everything").Should().BeTrue();
```

### Production example: safely call `$everything` across many providers

If you have a collection of providers and want to call a custom operation such as `$everything`, 
first use the `FhirProviderGuards` extension to filter to only those providers that advertise support. 
This avoids runtime errors and lets you fan‑out work confidently.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

public static class PatientEverythingFanout
{
    public static async Task<IReadOnlyList<Bundle>> GetEverythingAsync(
        IEnumerable<IFhirProvider> providers,
        string patientId,
        CancellationToken cancellationToken = default)
    {
        if (providers is null)
        {
            return Array.Empty<Bundle>();
        }

        // Filter to only providers that support Patient + Everything
        IEnumerable<IFhirProvider> supportingProviders =
            providers.SupportsResource("Patient", "Everything");

        // Fan-out concurrently across providers
        List<Task<Bundle>> tasks = supportingProviders
            .Select(provider => provider.Patients.Everything(
                patientId,
                start: null,
                end: null,
                typeFilter: null,
                since: null,
                count: null,
                cancellationToken: cancellationToken).AsTask())
            .ToList();

        Bundle[] bundles = await Task.WhenAll(tasks).ConfigureAwait(false);

        return bundles;
    }
}
```
---

## FAQ

**Q: Do I have to override every method?**
No. Only override what you support; unimplemented methods can throw by default.

**Q: How do I add non‑standard operations?**
Add a public method and decorate it with `[FhirOperation]`. The Capabilities scanner will include it.

**Q: Can I detect support at runtime?**
Yes. You can inspect the provider’s `Capabilities` object (or a resource’s capabilities) to see which operations are available.
Alternatively, use the `FhirProviderGuards` extension methods such as `SupportsResource` for a simpler runtime check.

---

## Contributing

We welcome all forms of contribution — whether it’s a small bug fix, a new feature, 
or simply improving the documentation.

* **Pull Requests (PRs):** Please fork the repository and submit a PR with clear commit messages.  
  Where possible, include tests that validate your changes. We follow **TDD** — anything that can 
  be tested **must** be tested before a PR will be accepted.
* **Issues:** Suggestions, feature requests, and bug reports can be logged through the 
  [Issues](../../issues) tab. Please provide enough context and steps to reproduce 
  (if reporting a bug).
* **Discussions:** If you’re unsure about an idea, feel free to open a discussion 
  before investing time in code. Early feedback is encouraged.
* **Coding Standards:** We follow "The-Standard" architecture conventions 
  (Broker/Service/Orchestration layers, async suffixes, 120 char line limit, etc.). 
  Please align with these patterns where possible.
* **Testing:** New functionality should include **unit tests** and/or **integration tests**.  
  We use **xUnit** with **FluentAssertions**. Tests should be clear, deterministic, 
  and align with the **Given–When–Then** pattern.

> **Note:** All contributions are welcome! Even if it’s just a typo fix, 
> don’t hesitate to submit a PR.  

---

## Appendix: key types (at a glance)

* `IFhirProvider` — Provider surface (resources as properties).
* `FhirProviderBase` — base class that computes and exposes provider-level capabilities 
  by scanning its resource operations.
* `IResourceOperation<TResource>` — Standard REST‑like surface for a resource.
* `ResourceOperationBase<TResource>` — Base class with capability discovery.
* `[FhirOperation]` — Attribute to mark custom methods for capability discovery.
* `FhirProviderGuards` — Extensions to query support for resources/operations.


# Appendix: Key Types (at a Glance)

## Public API

* `IFhirProvider` — Canonical provider surface (resources exposed as properties).  
* `IResourceOperation<TResource>` — Standard REST-like surface for a resource.  
* `[FhirOperation]` — Attribute used to mark custom methods for capability discovery.  
* `FhirProviderGuards` — Extension methods to query support for resources/operations.  

## Internal Helpers

* `FhirProviderBase` — Optional base class that computes and exposes provider-level capabilities 
  by scanning its resource operations.  
* `ResourceOperationBase<TResource>` — Base class that computes and exposes resource-level 
  capabilities by scanning its methods.  

---

