using Challenge.Application.Boundaries;
using System.Collections.Generic;

namespace Challenge.Application.UseCases.V1.Countries.GetRoute
{
    public sealed class OutputData :
        IOutputData
    {
        public List<OutputDataRouteCountryItem> Countries { get; }

        public OutputData(List<OutputDataRouteCountryItem> countries)
        {
            this.Countries = countries;
        }
    }
}
