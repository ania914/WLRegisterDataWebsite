using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Services;

namespace WLRegisterDataWebsite.Module.Controllers.SearchControllers
{
    public partial class SearchActionController : ViewController
    {
        private const string SearchActionName = "SearchAction";
        private const string ChangeBaseUrl = "ChangeBaseUrl";
        private SimpleAction changeBaseUrl;
        private SimpleAction searchAction;
        private SelectSearchOptionController selectSearchOptionController;
        private SearchOption? selectedOption;
        private ISubjectService subjectService;

        public SearchActionController()
        {
            InitializeComponent();

            TargetObjectType = typeof(SearchSubject);

            changeBaseUrl = new SimpleAction(this, ChangeBaseUrl, PredefinedCategory.View)
            {
                Caption = ""
            };
            searchAction = new SimpleAction(this, SearchActionName, PredefinedCategory.View)
            {
                Caption = "Search"
            };
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            if(subjectService == null)
            {
                subjectService = new SubjectService(new CustomHttpClient(), new DatabaseService(Application.ConnectionString));
            }
            selectSearchOptionController = Frame.GetController<SelectSearchOptionController>();
            if(selectSearchOptionController != null)
            {
                selectSearchOptionController.OnSelectionChanged += OnSelectionChanged;
            }
            changeBaseUrl.Execute += ChangeBaseUrl_Execute;
            searchAction.Execute += SearchAction_Execute;
            UpdateChangeActionCaption();
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            searchAction.Execute -= SearchAction_Execute;
            if (selectSearchOptionController != null)
            {
                selectSearchOptionController.OnSelectionChanged += OnSelectionChanged;
            }
            changeBaseUrl.Execute -= ChangeBaseUrl_Execute;
            searchAction.Execute -= SearchAction_Execute;
        }

        private async void SearchAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (!selectedOption.HasValue)
                return;

            var searchSubject = View.CurrentObject as SearchSubject;
            var response = await subjectService.Search(searchSubject, selectedOption.Value);
            var entitySpace = Application.CreateNestedObjectSpace(View.ObjectSpace);
            await subjectService.SaveResults(entitySpace, response);
            var objectSpace = View.ObjectSpace.CreateNestedObjectSpace();
            var detailView = Application.CreateDetailView(objectSpace, response, true);
            Frame.SetView(detailView);
        }

        private void ChangeBaseUrl_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            subjectService.ChangeBaseUrl();
            UpdateChangeActionCaption();
        }

        private void OnSelectionChanged(object sender, SearchOption searchOption)
        {
            selectedOption = searchOption;
        }

        private void UpdateChangeActionCaption()
        {
            changeBaseUrl.Caption = subjectService.UseTestUrl ? "Use production" : "Use Test";
        }
    }
}
