using DevExpress.ExpressApp;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels.Responses
{
    public class EntityListResponse: NonPersistentBaseObject
    {
        private EntityList result;

        public EntityList Result
        {
            get => result;
            set => SetPropertyValue(ref result, value);
        }
    }
}
