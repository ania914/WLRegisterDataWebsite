using DevExpress.ExpressApp;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    public class EntityResponse : NonPersistentBaseObject
    {
        private EntityItem result;

        public EntityItem Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }
    }
}
