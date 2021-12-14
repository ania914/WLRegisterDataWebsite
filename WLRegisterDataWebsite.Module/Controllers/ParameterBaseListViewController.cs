using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using System.Linq;
using WLRegisterDataWebsite.Module.BusinessObjects.Parameters;

namespace WLRegisterDataWebsite.Module.Controllers
{
    public abstract class ParameterBaseListViewController : ObjectViewController<ListView, ParameterBase>
    {
        private ListViewProcessCurrentObjectController processCurrentObjectController;
        private NewObjectViewController newObjectViewController;
        private DeleteObjectsViewController deleteObjectsViewController;
        private object oldValue;

        protected abstract int MaxCount { get; }
        protected abstract string ParameterViewId { get; }

        public ParameterBaseListViewController()
        {
            TargetViewId = ParameterViewId;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            newObjectViewController = Frame.GetController<NewObjectViewController>();
            if(newObjectViewController != null)
            {
                newObjectViewController.ObjectCreated += NewObjectViewController_ObjectCreated;
            }

            deleteObjectsViewController = Frame.GetController<DeleteObjectsViewController>();
            if(deleteObjectsViewController != null)
            {
                deleteObjectsViewController.DeleteAction.Execute += DeleteAction_Execute;
            }

            processCurrentObjectController = Frame.GetController<ListViewProcessCurrentObjectController>();
            if(processCurrentObjectController != null)
            {
                processCurrentObjectController.ProcessCurrentObjectAction.Executing += ProcessCurrentObjectAction_Executing;
            }
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            
            if(newObjectViewController != null)
            {
                newObjectViewController.ObjectCreated -= NewObjectViewController_ObjectCreated;
            }

            if(deleteObjectsViewController != null)
            {
                deleteObjectsViewController.DeleteAction.Execute -= DeleteAction_Execute;
            }

            if (processCurrentObjectController != null)
            {
                processCurrentObjectController.ProcessCurrentObjectAction.Executing -= ProcessCurrentObjectAction_Executing;
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

        private void ProcessCurrentObjectAction_Executing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var selectedObject = ((SimpleAction)sender).SelectionContext.SelectedObjects[0];
            oldValue = selectedObject;

            var showViewParameters = CreateDialogForObject(selectedObject);
            Application.ShowViewStrategy.ShowView(showViewParameters, new ShowViewSource(Application.MainWindow, null));

            e.Cancel = true;
        }

        private ShowViewParameters CreateDialogForObject(object processedObject)
        {
            var objectSpace = Application.CreateNestedObjectSpace(View.ObjectSpace);

            var newObject = objectSpace.CreateObject(processedObject.GetType());
            foreach (var property in processedObject.GetType().GetProperties().Where(p => p.CanWrite))
            {
                var propertyValue = property.GetValue(processedObject, null);
                property.SetValue(newObject, propertyValue, null);
            }

            var view = Application.CreateDetailView(objectSpace, newObject);
            var showViewParameters = new ShowViewParameters(view)
            {
                TargetWindow = TargetWindow.NewModalWindow,
                Context = TemplateContext.PopupWindow
            };
            var dialogController = Application.CreateController<DialogController>();
            showViewParameters.Controllers.Add(dialogController);
            dialogController.AcceptAction.Execute += AcceptAction_Execute;

            return showViewParameters;
        }

        private void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            View.CollectionSource.Remove(oldValue);
            View.CollectionSource.Add(e.CurrentObject);
        }
    }
}
