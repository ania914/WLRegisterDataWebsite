using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Validation;
using WLRegisterDataWebsite.Module.BusinessObjects.Models.Parameters;

namespace WLRegisterDataWebsite.Module.Controllers
{
    public class ParameterBaseValidationController : ObjectViewController<DetailView, ParameterBase>
    {
        private DialogController dialogController;
        protected override void OnActivated()
        {
            base.OnActivated();
            dialogController = Frame.GetController<DialogController>();
            if (dialogController != null)
            {
                dialogController.Accepting += DialogController_Accepting;
            }
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            if (dialogController != null)
            {
                dialogController.Accepting -= DialogController_Accepting;
            }
        }

        private void DialogController_Accepting(object sender, DialogControllerAcceptingEventArgs e)
        {
            var objectSpace = View.ObjectSpace;
            var parameter = e.AcceptActionArgs.CurrentObject as ParameterBase;
            var validate = Validator.RuleSet.ValidateAll(objectSpace, new object[] { parameter, parameter.Number }, ContextIdentifier.Save);
            if (!validate)
            {
                e.Cancel = true;
            }
        }
    }
}
