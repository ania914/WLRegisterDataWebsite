namespace WLRegisterDataWebsite.Module.Controllers.SearchControllers
{
    public class SearchParameterValidationController : ParameterBaseListViewController
    {
        protected override int MaxCount => 2;

        protected override string ParameterViewId => "SearchSubject_Nip_ListView;SearchSubject_BankAccount_ListView;SearchSubject_Regon_ListView";
    }
}
