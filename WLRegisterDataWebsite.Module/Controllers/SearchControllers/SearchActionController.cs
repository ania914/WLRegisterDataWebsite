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

namespace WLRegisterDataWebsite.Module.Controllers.SearchControllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SearchActionController : ViewController
    {
        private const string SearchActionName = "SearchAction";
        private SimpleAction searchAction;
        public SearchActionController()
        {
            InitializeComponent();
            TargetObjectType = typeof(SearchSubject);
            searchAction = new SimpleAction(this, SearchActionName, PredefinedCategory.View)
            {
                Caption = "Search"
            };
            searchAction.Execute += SearchAction_Execute;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            searchAction.Execute -= SearchAction_Execute;
        }

        private void SearchAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

        }
    }
}
