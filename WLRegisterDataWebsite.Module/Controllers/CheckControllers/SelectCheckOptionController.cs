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
using WLRegisterDataWebsite.Module.Enums;
using WLRegisterDataWebsite.Module.Extensions;

namespace WLRegisterDataWebsite.Module.Controllers.CheckControllers
{
    public partial class SelectCheckOptionController : ViewController
    {
        private const string CheckOptionSelectionAction = "CheckOptionSelectionAction";

        private SingleChoiceAction checkOptionSelectionAction;
        private IList<PropertyEditor> propertyEditors;

        public SelectCheckOptionController()
        {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(CheckSubject);


            checkOptionSelectionAction = new SingleChoiceAction(this, CheckOptionSelectionAction, PredefinedCategory.Edit)
            {
                Caption = "Check by",
                ItemType = SingleChoiceActionItemType.ItemIsOperation,
                SelectionDependencyType = SelectionDependencyType.Independent
            };
            checkOptionSelectionAction.FillWithEnumValues(typeof(CheckOption));
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            var objectSpace = View.ObjectSpace;
            View.CurrentObject = objectSpace.CreateObject<CheckSubject>();

            propertyEditors = ((DetailView)View).GetItems<PropertyEditor>();
            checkOptionSelectionAction.Execute += SearchOptionSelectionAction_Execute;
            HideAllPropertyEditors();
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            checkOptionSelectionAction.Execute -= SearchOptionSelectionAction_Execute;
        }

        private void SearchOptionSelectionAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            HideAllPropertyEditors();
            ChangePropertyEditorVisibility(e.SelectedChoiceActionItem.Data.ToString(), true);
        }

        private void HideAllPropertyEditors()
        {
            foreach (var editor in propertyEditors)
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
