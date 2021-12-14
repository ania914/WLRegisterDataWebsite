using System;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;

namespace WLRegisterDataWebsite.Module.Services.ApiSearch
{
    public class SearchNipStrategy : SearchStrategyBase
    {
        public SearchNipStrategy(string baseUrl, IEnumerable<ParameterBase> parameters, DateTime date) : base(baseUrl, parameters, date)
        {
        }

        protected override string Option => "nip";
    }
}
