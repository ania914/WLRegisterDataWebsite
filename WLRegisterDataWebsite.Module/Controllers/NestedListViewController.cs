using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using System.Linq;

namespace WLRegisterDataWebsite.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class NestedListViewController : ViewController
    {
        private ListViewProcessCurrentObjectController processCurrentObjectController;
        private object oldValue;

        public NestedListViewController()
        {
            InitializeComponent();
            TargetViewNesting = Nesting.Nested;
        }
        protected override void OnActivated()
        {
            base.OnActivated();

            processCurrentObjectController = Frame.GetController<ListViewProcessCurrentObjectController>();
            if (processCurrentObjectController != null)
            {
                processCurrentObjectController.ProcessCurrentObjectAction.Executing += ProcessCurrentObjectAction_Executing;
            }
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();

            if (processCurrentObjectController != null)
            {
                processCurrentObjectController.ProcessCurrentObjectAction.Executing -= ProcessCurrentObjectAction_Executing;
            }
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
            ((ListView)View).CollectionSource.Remove(oldValue);
            ((ListView)View).CollectionSource.Add(e.CurrentObject);
        }
    }
}
