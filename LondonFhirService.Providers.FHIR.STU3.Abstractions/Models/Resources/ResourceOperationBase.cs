// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Capabilities;

namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Models.Resources
{
    /// <summary>
    /// Base implementation for STU3 resource providers. Reflective
    /// <see cref="Capabilities"/> includes overridden REST methods and custom
    /// operations marked with <see cref="FhirOperationAttribute"/>.
    /// </summary>
    public abstract class ResourceOperationBase<TResource> :
        LondonFhirService.Providers.FHIR.STU3.Abstractions.IResourceOperation<TResource>
        where TResource : Resource
    {
        private ResourceCapabilities resourceCapabilities;

        /// <summary>Capability info for this resource provider (cached).</summary>
        public ResourceCapabilities Capabilities =>
            resourceCapabilities ??= ComputeCapabilities();

        /// <summary>Gets the canonical resource name from the derived class name.</summary>
        protected virtual string GetResourceName()
        {
            var name = GetType().Name;
            return name.EndsWith("Resource", StringComparison.Ordinal)
                ? name.Substring(0, name.Length - "Resource".Length)
                : name;
        }

        public virtual ValueTask<TResource> Read(
            string id,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public virtual ValueTask<TResource> VRead(
            string id,
            string versionId,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public virtual ValueTask<Bundle> HistoryInstance(
            string id,
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public virtual ValueTask<Bundle> Search(
            SearchParams @params,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public virtual ValueTask<Bundle> HistoryType(
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public virtual ValueTask<Bundle> HistorySystem(
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public virtual ValueTask<TResource> Create(
            TResource resource,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public virtual ValueTask<TResource> Update(
            TResource resource,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public virtual ValueTask<TResource> Patch(
            string id,
            Parameters patchParameters,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        public virtual ValueTask<OperationOutcome> Delete(
            string id,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        private ResourceCapabilities ComputeCapabilities()
        {
            var derived = GetType();

            // 1) Overrides of virtual REST methods on this base
            var baseVirtuals = typeof(ResourceOperationBase<TResource>)
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(method =>
                    method.IsVirtual &&
                    method.DeclaringType == typeof(ResourceOperationBase<TResource>))
                .ToArray();

            var overriddenRest = new List<string>();

            foreach (var baseMethod in baseVirtuals)
            {
                var parameterTypes = baseMethod
                    .GetParameters()
                    .Select(p => p.ParameterType)
                    .ToArray();

                var candidate = derived.GetMethod(
                    baseMethod.Name,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                    binder: null,
                    types: parameterTypes,
                    modifiers: null);

                if (candidate != null &&
                    candidate.IsVirtual &&
                    candidate.GetBaseDefinition() == baseMethod &&
                    candidate.DeclaringType != baseMethod.DeclaringType)
                {
                    overriddenRest.Add(baseMethod.Name);
                }
            }

            // 2) Custom ops via [FhirOperation]
            var annotated = derived
                .GetMethods(BindingFlags.Instance | BindingFlags.Public |
                            BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                .Select(m => new
                {
                    Method = m,
                    Attr = m.GetCustomAttribute<FhirOperationAttribute>(inherit: true)
                })
                .Where(x => x.Attr != null)
                .Select(x => string.IsNullOrWhiteSpace(x.Attr.OperationName)
                    ? x.Method.Name
                    : x.Attr.OperationName)
                .ToList();

            var supported = overriddenRest
                .Concat(annotated)
                .Distinct(StringComparer.Ordinal)
                .OrderBy(n => n, StringComparer.Ordinal)
                .ToArray();

            return new ResourceCapabilities
            {
                ResourceName = GetResourceName(),
                SupportedOperations = supported
            };
        }
    }
}
