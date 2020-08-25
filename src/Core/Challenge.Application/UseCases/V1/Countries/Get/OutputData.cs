using Challenge.Application.Boundaries;
using System.Collections.Generic;

namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public sealed class OutputData :
        IOutputData
    {
        public IEnumerable<OutputDataCountryItem> Countries { get; }

        public OutputData(IEnumerable<OutputDataCountryItem> countries)
        {
            this.Countries = countries;
        }
    }
}
