using Challenge.Application.Boundaries;
using System.Collections.Generic;

namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public sealed class OutputData :
        IOutputData
    {
        public List<OutputDataCountryItem> Countries { get; }

        public OutputData(List<OutputDataCountryItem> countries)
        {
            this.Countries = countries;
        }
    }
}
