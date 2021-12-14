using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace WLRegisterDataWebsite.Module.BusinessObjects.Parameters
{
    [DomainComponent, DefaultClassOptions]
    public class ParameterBase : NonPersistentBaseObject
    {
        private string parameterValue;

        [RuleRegularExpression("Number_Criteria", DefaultContexts.Save, @"^[0-9]+$", CustomMessageTemplate = "Please enter numeric value")]
        public string Number
        {
            get => parameterValue;
            set => SetPropertyValue(ref parameterValue, value);
        }
    }
}
