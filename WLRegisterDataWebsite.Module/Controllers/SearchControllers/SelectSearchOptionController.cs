using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WLRegisterDataWebsite.Module.BusinessObjects;
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Extensions;

namespace WLRegisterDataWebsite.Module.Controllers.SearchControllers
{
    public partial class SelectSearchOptionController : ViewController
    {
        private const string SearchOptionSelectionAction = "SearchOptionSelectionAction";

        private SingleChoiceAction searchOptionSelectionAction;
        private IList<PropertyEditor> propertyEditors;

        public SelectSearchOptionController()
        {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(SearchSubject);
           

            searchOptionSelectionAction = new SingleChoiceAction(this, SearchOptionSelectionAction, PredefinedCategory.Edit)
            {
                Caption = "Search by",
                ItemType = SingleChoiceActionItemType.ItemIsOperation,
                SelectionDependencyType = SelectionDependencyType.Independent
            };
            searchOptionSelectionAction.FillWithEnumValues(typeof(SearchOption));
           
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            var objectSpace = View.ObjectSpace;
            View.CurrentObject = objectSpace.CreateObject<SearchSubject>();

            propertyEditors = ((DetailView)View).GetItems<PropertyEditor>();
            searchOptionSelectionAction.Execute += SearchOptionSelectionAction_Execute;
            HideAllPropertyEditors();
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            searchOptionSelectionAction.Execute -= SearchOptionSelectionAction_Execute;
        }

        private void SearchOptionSelectionAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            HideAllPropertyEditors();
            ChangePropertyEditorVisibility(e.SelectedChoiceActionItem.Data.ToString(), true);
        }

        private void HideAllPropertyEditors()
        {
            foreach(var editor in propertyEditors)
            {
                if (editor is not ListPropertyEditor) 
                    continue;

                ChangePropertyEditorVisibility(editor.Id, false);
            }
        }

        private void ChangePropertyEditorVisibility(string id, bool isVisible)
        {
            var editor = propertyEditors.FirstOrDefault(x => x.Id == id);
            
            if (editor == null)
                return;

            ((IAppearanceVisibility)editor).Visibility = isVisible ? ViewItemVisibility.Show : ViewItemVisibility.Hide;
        }
    }
}
