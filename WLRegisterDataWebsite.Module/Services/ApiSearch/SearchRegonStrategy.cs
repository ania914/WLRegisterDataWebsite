using System;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;

namespace WLRegisterDataWebsite.Module.Services.ApiSearch
{
    public class SearchRegonStrategy : SearchStrategyBase
    {
        public SearchRegonStrategy(string baseUrl, IEnumerable<ParameterBase> parameters, DateTime date) : base(baseUrl, parameters, date)
        {
        }

        protected override string Option => "regon";
    }
}
