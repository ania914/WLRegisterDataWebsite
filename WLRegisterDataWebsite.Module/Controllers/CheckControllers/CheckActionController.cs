using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Services;

namespace WLRegisterDataWebsite.Module.Controllers.CheckControllers
{
    public partial class CheckActionController : ViewController
    {
        private const string CheckActionName = "CheckAction";
        private const string ChangeBaseUrlAction = "ChangeBaseUrlAction";
        private SimpleAction changeBaseUrl;
        private SimpleAction checkAction;
        private SelectCheckOptionController selectCheckOptionController;
        private CheckOption? checkOption;
        private ISubjectService subjectService;

        public CheckActionController()
        {
            InitializeComponent();
            TargetObjectType = typeof(CheckSubject);

            changeBaseUrl = new SimpleAction(this, ChangeBaseUrlAction, PredefinedCategory.View)
            {
                Caption = ""
            };
            checkAction = new SimpleAction(this, CheckActionName, PredefinedCategory.View)
            {
                Caption = "Check"
            };
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            if (subjectService == null)
            {
                subjectService = new SubjectService(new CustomHttpClient(), new DatabaseService(Application.ConnectionString));
            }
            selectCheckOptionController = Frame.GetController<SelectCheckOptionController>();
            if (selectCheckOptionController != null)
            {
                selectCheckOptionController.OnSelectionChanged += OnSelectionChanged;
            }
            changeBaseUrl.Execute += ChangeBaseUrl_Execute;
            checkAction.Execute += CheckAction_Execute;
            UpdateChangeActionCaption();
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }

        protected override void OnDeactivated()
        {
            if (selectCheckOptionController != null)
            {
                selectCheckOptionController.OnSelectionChanged += OnSelectionChanged;
            }
            changeBaseUrl.Execute -= ChangeBaseUrl_Execute;
            checkAction.Execute -= CheckAction_Execute;

            base.OnDeactivated();
        }

        private async void CheckAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (!checkOption.HasValue)
                return;

            var checkSubject = View.CurrentObject as CheckSubject;
            var response = await subjectService.Check(checkSubject, checkOption.Value);
            var objectSpace = View.ObjectSpace.CreateNestedObjectSpace();
            var detailView = Application.CreateDetailView(objectSpace, response, true);
            Frame.SetView(detailView);
        }

        private void ChangeBaseUrl_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            subjectService.ChangeBaseUrl();
            UpdateChangeActionCaption();
        }

        private void OnSelectionChanged(object sender, CheckOption searchOption)
        {
            checkOption = searchOption;
        }

        private void UpdateChangeActionCaption()
        {
            changeBaseUrl.Caption = subjectService.UseTestUrl ? "Use production" : "Use Test";
        }
    }
}
