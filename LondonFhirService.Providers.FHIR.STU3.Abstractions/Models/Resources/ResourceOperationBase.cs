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
    /// Base class for resource operations.
    ///
    /// <para>
    /// Capabilities reported by this class include:
    /// <list type="bullet">
    ///   <item>
    ///     <description>
    ///       Standard RESTful methods defined by <see cref="IResourceOperation{TResource}"/> that are explicitly
    ///       overridden in the derived class.
    ///     </description>
    ///   </item>
    ///   <item>
    ///     <description>
    ///       Non-standard, resource-specific methods declared in the derived class and decorated with
    ///       <see cref="FhirOperationAttribute"/>.
    ///     </description>
    ///   </item>
    /// </list>
    /// </para>
    ///
    /// <para>
    /// Derived classes should override only the operations they actually support. All other operations default to
    /// <see cref="NotImplementedException"/>.
    /// </para>
    /// </summary>
    /// <typeparam name="TResource">FHIR resource type (e.g., <see cref="Patient"/>).</typeparam>
    public abstract class ResourceOperationBase<TResource> : IResourceOperation<TResource>
        where TResource : Resource
    {
        private ResourceCapabilities resourceCapabilities;

        /// <summary>
        /// Gets the computed capabilities for this resource. Capabilities are determined via reflection and cached
        /// after the first computation.
        /// </summary>
        public ResourceCapabilities Capabilities => resourceCapabilities ??= ComputeCapabilities();

        /// <summary>
        /// Gets the canonical resource name. By default, this strips the suffix "Resource" from the derived class name.
        /// </summary>
        /// <returns>The resource name (e.g., "Patient").</returns>
        protected virtual string GetResourceName()
        {
            var n = GetType().Name;
            return n.EndsWith("Resource", StringComparison.Ordinal) ? n[..^"Resource".Length] : n;
        }

        /// <summary>
        /// Reads the current state of a resource by logical id.
        /// </summary>
        /// <param name="id">Logical id of the resource.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>The requested resource.</returns>
        public virtual ValueTask<TResource> Read(
            string id,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Reads a specific version of a resource by id and version id.
        /// </summary>
        /// <param name="id">Logical id of the resource.</param>
        /// <param name="versionId">Version id of the resource.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>The requested version of the resource.</returns>
        public virtual ValueTask<TResource> VRead(
            string id,
            string versionId,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Returns the change history for a single resource instance.
        /// </summary>
        /// <param name="id">Logical id of the resource.</param>
        /// <param name="since">Restrict results to changes since this timestamp.</param>
        /// <param name="count">Optional page size limit.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>A bundle containing the change history for the resource.</returns>
        public virtual ValueTask<Bundle> HistoryInstance(
            string id,
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Searches for resources of this type using FHIR search parameters.
        /// </summary>
        /// <param name="params">FHIR search parameters.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>A bundle of matching resources (searchset).</returns>
        public virtual ValueTask<Bundle> Search(
            SearchParams @params,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Returns the change history for all resources of this type.
        /// </summary>
        /// <param name="since">Restrict results to changes since this timestamp.</param>
        /// <param name="count">Optional page size limit.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>A bundle containing change history for this resource type.</returns>
        public virtual ValueTask<Bundle> HistoryType(
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Returns the change history for all resources in the system.
        /// </summary>
        /// <param name="since">Restrict results to changes since this timestamp.</param>
        /// <param name="count">Optional page size limit.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>A bundle containing system-wide change history.</returns>
        public virtual ValueTask<Bundle> HistorySystem(
            DateTimeOffset? since = null,
            int? count = null,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Creates a new resource instance.
        /// </summary>
        /// <param name="resource">The resource to create.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>The newly created resource.</returns>
        public virtual ValueTask<TResource> Create(
            TResource resource,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Updates an existing resource instance.
        /// </summary>
        /// <param name="resource">The resource with updated data.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>The updated resource.</returns>
        public virtual ValueTask<TResource> Update(
            TResource resource,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Applies a partial update (patch) to an existing resource instance.
        /// </summary>
        /// <param name="id">Logical id of the resource to patch.</param>
        /// <param name="patchParameters">FHIR patch parameters.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>The updated resource after patch.</returns>
        public virtual ValueTask<TResource> Patch(
            string id,
            Parameters patchParameters,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Deletes a resource instance by logical id.
        /// </summary>
        /// <param name="id">Logical id of the resource to delete.</param>
        /// <param name="cancellationToken">
        /// Optional token to observe while awaiting the operation. Defaults to <see cref="CancellationToken.None"/>.
        /// </param>
        /// <returns>An <see cref="OperationOutcome"/> indicating the result.</returns>
        public virtual ValueTask<OperationOutcome> Delete(
            string id,
            CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        /// <summary>
        /// Computes the capabilities for the derived resource class by scanning:
        /// <list type="bullet">
        ///   <item>
        ///     <description>Which standard RESTful methods were overridden.</description>
        ///   </item>
        ///   <item>
        ///     <description>
        ///       Which derived methods are decorated with <see cref="FhirOperationAttribute"/>.
        ///     </description>
        ///   </item>
        /// </list>
        /// </summary>
        /// <returns>A <see cref="ResourceCapabilities"/> describing supported operations.</returns>
        private ResourceCapabilities ComputeCapabilities()
        {
            var derived = GetType();

            // 1) Standard REST overrides
            var baseVirtuals = typeof(ResourceOperationBase<TResource>)
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(method => method.IsVirtual && method.DeclaringType == typeof(ResourceOperationBase<TResource>))
                .ToArray();

            var overriddenRest = new List<string>();

            foreach (var baseMethod in baseVirtuals)
            {
                var parms = baseMethod.GetParameters().Select(parameter => parameter.ParameterType).ToArray();

                var candidate = derived.GetMethod(
                    baseMethod.Name,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                    binder: null,
                    types: parms,
                    modifiers: null);

                if (candidate != null &&
                    candidate.IsVirtual &&
                    candidate.GetBaseDefinition() == baseMethod &&
                    candidate.DeclaringType != baseMethod.DeclaringType)
                {
                    overriddenRest.Add(baseMethod.Name);
                }
            }

            // 2) Non-standard ops marked with [FhirOperation]
            var annotated = derived
                .GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.DeclaredOnly)
                .Where(m => m.GetCustomAttribute<FhirOperationAttribute>(inherit: true) != null)
                .Select(m => m.Name)
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
