// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LondonFhirService.Providers.FHIR.STU3.Abstractions.Extensions;


namespace LondonFhirService.Providers.FHIR.STU3.Abstractions.Tests.Unit.Extensions
{
    public partial class FhirProviderGuardsTests
    {
        [Fact]
        public void ReturnsEmpty_WhenProvidersIsNull()
        {
            // given
            IEnumerable<IFhirProvider> providers = null;

            // when
            var result = providers.SupportsResource("Patient");

            // then
            result.Should().BeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ReturnsEmpty_WhenResourceNameIsNullOrWhiteSpace(string resourceName)
        {
            // given
            var providers = new List<IFhirProvider>
            {
                MakeProvider("A", ("Patient", new[] { "Everything" }))
            };

            // when
            var result = providers.SupportsResource(resourceName);

            // then
            result.Should().BeEmpty();
        }

        [Fact]
        public void ReturnsMatchingProviders_WhenOperationIsNull_MatchesByResourceOnly()
        {
            // given
            var a = MakeProvider("A", ("Patient", new[] { "Everything" }));
            var b = MakeProvider("B", ("Observation", new[] { "Read" }));
            var c = MakeProvider("C", ("Patient", new[] { "Read", "History" }));
            var providers = new[] { a, b, c };

            // when
            var result = providers.SupportsResource("Patient").ToList();

            // then
            result.Should().ContainInOrder(a, c).And.HaveCount(2);
        }

        [Fact]
        public void ReturnsOnlyProvidersSupportingOperation_WhenOperationIsProvided()
        {
            // given
            var a = MakeProvider("A", ("Patient", new[] { "Everything" }));
            var b = MakeProvider("B", ("Patient", new[] { "Read", "History" }));
            var c = MakeProvider("C", ("Observation", new[] { "Everything" }));
            var providers = new[] { a, b, c };

            // when
            var result = providers.SupportsResource("Patient", "Everything").ToList();

            // then
            result.Should().ContainSingle().Which.Should().BeSameAs(a);
        }

        [Fact]
        public void ReturnsEmpty_WhenNoProviderSupportsResource()
        {
            // given
            var a = MakeProvider("A", ("Observation", new[] { "Read" }));
            var b = MakeProvider("B", ("Encounter", new[] { "Read" }));
            var providers = new[] { a, b };

            // when
            var result = providers.SupportsResource("Patient").ToList();

            // then
            result.Should().BeEmpty();
        }

        [Fact]
        public void ReturnsEmpty_WhenNoProviderSupportsOperationOnResource()
        {
            // given
            var a = MakeProvider("A", ("Patient", new[] { "Read", "History" }));
            var b = MakeProvider("B", ("Patient", new[] { "Search" }));
            var providers = new[] { a, b };

            // when
            var result = providers.SupportsResource("Patient", "Everything").ToList();

            // then
            result.Should().BeEmpty();
        }

        [Fact]
        public void IgnoresProvidersWithNullCapabilities_AndNullResources()
        {
            // given
            var good = MakeProvider("Good", ("Patient", new[] { "Everything" }));
            var nullCaps = MakeProviderWithNullCapabilities();
            var nullRes = MakeProviderWithNullResources("NoRes");
            var providers = new[] { nullCaps, good, nullRes };

            // when
            var result = providers.SupportsResource("Patient", "Everything").ToList();

            // then
            result.Should().ContainSingle().Which.Should().BeSameAs(good);
        }

        [Fact]
        public void IgnoresProvidersWithNullOperationsList()
        {
            // given
            var nullOps = MakeProviderWithNullOps("NullOps", "Patient");
            var good = MakeProvider("Good", ("Patient", new[] { "Everything" }));
            var providers = new[] { nullOps, good };

            // when
            var result = providers.SupportsResource("Patient", "Everything").ToList();

            // then
            result.Should().ContainSingle().Which.Should().BeSameAs(good);
        }

        [Fact]
        public void HandlesNullElementsInsideProvidersSequence()
        {
            // given
            var good = MakeProvider("Good", ("Patient", new[] { "Everything" }));
            var providers = new IFhirProvider[] { null, good, null };

            // when
            var result = providers.SupportsResource("Patient", "Everything").ToList();

            // then
            result.Should().ContainSingle().Which.Should().BeSameAs(good);
        }

        [Fact]
        public void ComparisonIsOrdinal_CaseMismatchDoesNotMatch()
        {
            // given
            var a = MakeProvider("A", ("Patient", new[] { "Everything" }));
            var providers = new[] { a };

            // when
            var byResource = providers.SupportsResource("patient").ToList();
            var byOperation = providers.SupportsResource("Patient", "everything").ToList();

            // then
            byResource.Should().BeEmpty("resource name comparison is StringComparison.Ordinal");
            byOperation.Should().BeEmpty("operation name comparison is StringComparison.Ordinal");
        }

        [Fact]
        public void PreservesOrderOfInputSequence()
        {
            // given
            var a = MakeProvider("A", ("Patient", new[] { "Everything" }));
            var b = MakeProvider("B", ("Patient", new[] { "Everything" }));
            var c = MakeProvider("C", ("Patient", new[] { "Read" }));
            var providers = new[] { c, a, b };

            // when
            var result = providers.SupportsResource("Patient", "Everything").ToList();

            // then
            result.Select(p => p.Capabilities.ProviderName)
                  .Should().ContainInOrder("A", "B");
        }
    }
}
