using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.XtraPrinting.Native;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    [DomainComponent]
    [DefaultClassOptions]
    public class EntityItem : NonPersistentBaseObject
    {
        private EntityModel subject;
        private string requestDateTime;
        private string requestId;

        [ExpandObjectMembers(ExpandObjectMembers.Always)]
        public EntityModel Subject
        {
            get => subject;
            set => SetPropertyValue(ref subject, value);
        }

        public string RequestDateTime
        {
            get => requestDateTime;
            set => SetPropertyValue(ref requestDateTime, value);
        }

        public string RequestId
        {
            get => requestId;
            set => SetPropertyValue(ref requestId, value);
        }
    }
}
