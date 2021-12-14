using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.SystemModule;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLRegisterDataWebsite.Module.Blazor.Controllers
{
    public class BlazorDiagnosticInfoController : DiagnosticInfoController
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            IConfiguration configuration = (IConfiguration)((BlazorApplication)Application).ServiceProvider.GetService(typeof(IConfiguration));
            DiagnosticInfo.Active.SetItemValue(EnableDiagnosticActionsActiveKey, configuration.GetValue<bool>("EnableDiagnosticActions"));
        }
    }
}
