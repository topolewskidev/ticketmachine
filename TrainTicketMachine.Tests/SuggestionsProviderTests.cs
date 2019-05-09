using System;
using System.Collections.Generic;
using FluentAssertions;
using Xbehave;
using Xunit;

namespace TrainTicketMachine.Tests
{
    public class SuggestionsProviderTests
    {
        private readonly ISearchableTreeBuilder _searchableTreeBuilder;
        private readonly SuggestionsProvider _suggestionsProvider; 

        private IList<string> _stations = null;
        private Suggestions _suggestions = null;

        public SuggestionsProviderTests()
        {
            _searchableTreeBuilder = new SearchableTreeBuilder();
            _suggestionsProvider = new SuggestionsProvider();
        }

        [Scenario]
        public void SuggestingStationsForCaseWithoutSpaces()
        {
            "Given a list of stations".x(() =>
            {
                _stations = new List<string>
                {
                    "DARTFORD",
                    "DARTMOUTH",
                    "TOWER HILL",
                    "DERBY"
                };
            });

            "When user inputs text".x(() =>
            {
                var searchableTree = _searchableTreeBuilder.Build(_stations);
                _suggestions = _suggestionsProvider.Get("DART", searchableTree);
            });

            "Then suggestions should contain proper stations".x(() =>
            {
                var expectedStations = new[]
                {
                    "DARTFORD",
                    "DARTMOUTH"
                };

                _suggestions.MatchedItems.Should().BeEquivalentTo(expectedStations);
            });

            "And suggestions should contain next characters".x(() =>
            {
                var expectedCharacters = new[]
                {
                    'F',
                    'M'
                };

                _suggestions.NextCharacters.Should().BeEquivalentTo(expectedCharacters);
            });
        }
    }
}
