using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.BusinessObjects.ApiModels;
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Services;

namespace WLRegisterDataWebsite.Module.Controllers.SearchControllers
{
    public partial class SearchActionController : ViewController
    {
        private const string SearchActionName = "SearchAction";
        private SimpleAction searchAction;
        private SelectSearchOptionController selectSearchOptionController;
        private SearchOption? selectedOption;
        private ISubjectService subjectService;

        public SearchActionController()
        {
            InitializeComponent();

            TargetObjectType = typeof(SearchSubject);
            searchAction = new SimpleAction(this, SearchActionName, PredefinedCategory.View)
            {
                Caption = "Search"
            };
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            selectSearchOptionController = Frame.GetController<SelectSearchOptionController>();
            if(selectSearchOptionController != null)
            {
                selectSearchOptionController.OnSelectionChanged += OnSelectionChanged;
            }
            searchAction.Execute += SearchAction_Execute;
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
        }

        private async void SearchAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (!selectedOption.HasValue)
                return;

            subjectService = new SubjectService(new CustomHttpClient(), new DatabaseService(Application.ConnectionString));
            var searchSubject = View.CurrentObject as SearchSubject;
            var response = await subjectService.Search(searchSubject, selectedOption.Value);
            var entitySpace = Application.CreateNestedObjectSpace(View.ObjectSpace);
            await subjectService.SaveResults(entitySpace, response);
            var objectSpace = View.ObjectSpace.CreateNestedObjectSpace();
            var detailView = Application.CreateDetailView(objectSpace, response, true);
            Frame.SetView(detailView);
        }

        private void OnSelectionChanged(object sender, SearchOption searchOption)
        {
            selectedOption = searchOption;
        }
    }
}
