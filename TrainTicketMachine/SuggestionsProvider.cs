using System;

namespace TrainTicketMachine
{
    public class SuggestionsProvider
    {
        public Suggestions Get(string searchedText, ISearchableTree searchableTree)
        {
            return new Suggestions();
        }
    }
}
