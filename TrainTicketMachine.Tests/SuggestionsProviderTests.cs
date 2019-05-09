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
                PerformSearch("DART");
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

        [Scenario]
        public void SuggestingStationsForCaseWithSpace()
        {
            "Given a list of stations".x(() =>
            {
                _stations = new List<string>
                {
                    "LIVERPOOL",
                    "LIVERPOOL LIME STREET",
                    "PADDINGTON"
                };
            });

            "When user inputs text".x(() =>
            {
                PerformSearch("LIVERPOOL");
            });

            "Then suggestions should contain proper stations".x(() =>
            {
                var expectedStations = new[]
                {
                    "LIVERPOOL",
                    "LIVERPOOL LIME STREET"
                };

                _suggestions.MatchedItems.Should().BeEquivalentTo(expectedStations);
            });

            "And suggestions should contain next characters".x(() =>
            {
                var expectedCharacters = new[]
                {
                    ' '
                };

                _suggestions.NextCharacters.Should().BeEquivalentTo(expectedCharacters);
            });
        }

        [Scenario]
        public void SuggestingStationsForCaseWithoutMatchingItems()
        {
            "Given a list of stations".x(() =>
            {
                _stations = new List<string>
                {
                    "EUSTON",
                    "LONDON BRIDGE",
                    "VICTORIA"
                };
            });

            "When user inputs text".x(() =>
            {
                PerformSearch("KINGS CROSS");
            });

            "Then suggestions should not contain any station".x(() =>
            {
                _suggestions.MatchedItems.Should().BeEmpty();
            });

            "And suggestions should not contain any character".x(() =>
            {
                _suggestions.NextCharacters.Should().BeEmpty();
            });
        }

        private void PerformSearch(string searchedText)
        {
            var searchableTree = _searchableTreeBuilder.Build(_stations);
            _suggestions = _suggestionsProvider.Get(searchedText, searchableTree);
        }
    }
}
