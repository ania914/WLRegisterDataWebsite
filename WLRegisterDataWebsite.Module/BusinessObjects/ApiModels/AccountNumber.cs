using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    public class AccountNumber : BaseObject
    {
        private string number;

        public AccountNumber(Session session) : base(session)
        {
        }

        public string Number
        {
            get => number;
            set => SetPropertyValue(nameof(Number), ref number, value);
        }

        [Association("Entity-AccountNumbers")]
        public XPCollection<ApiEntity> AccountNumberEntities
        {
            get => GetCollection<ApiEntity>(nameof(AccountNumberEntities));
        }
    }
}
