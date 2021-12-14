namespace WLRegisterDataWebsite.Module.Controllers.CheckControllers
{
    public class CheckParameterValidationController : ParameterBaseListViewController
    {
        protected override int MaxCount => 1;

        protected override string ParameterViewId => "CheckSubject_Nip_ListView;CheckSubject_Regon_ListView";
    }
}
