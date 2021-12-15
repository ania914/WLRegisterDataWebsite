using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;

namespace WLRegisterDataWebsite.Module.Controllers.CheckControllers
{
    public class CheckParameterValidationController : ObjectViewController<ListView, ParameterBase>
    {
        private const int MaxCount = 1;
        private NewObjectViewController newObjectViewController;
        private DeleteObjectsViewController deleteObjectsViewController;

        public CheckParameterValidationController()
        {
            TargetViewId = "CheckSubject_Nip_ListView;CheckSubject_Regon_ListView";
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            newObjectViewController = Frame.GetController<NewObjectViewController>();
            if (newObjectViewController != null)
            {
                newObjectViewController.ObjectCreated += NewObjectViewController_ObjectCreated;
            }

            deleteObjectsViewController = Frame.GetController<DeleteObjectsViewController>();
            if (deleteObjectsViewController != null)
            {
                deleteObjectsViewController.DeleteAction.Execute += DeleteAction_Execute;
            }
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();

            if (newObjectViewController != null)
            {
                newObjectViewController.ObjectCreated -= NewObjectViewController_ObjectCreated;
            }

            if (deleteObjectsViewController != null)
            {
                deleteObjectsViewController.DeleteAction.Execute -= DeleteAction_Execute;
            }
        }

        private void NewObjectViewController_ObjectCreated(object sender, ObjectCreatedEventArgs e)
        {
            e.ObjectSpace.Committed += ObjectSpace_Committed;
        }

        private void ObjectSpace_Committed(object sender, System.EventArgs e)
        {
            if (View.CollectionSource.GetCount() + 1 == MaxCount)
            {
                newObjectViewController.NewObjectAction.Enabled.SetItemValue("DisableNewObjects", false);
            }
        }

        private void DeleteAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            newObjectViewController.NewObjectAction.Enabled.Clear();
        }
    }
}
