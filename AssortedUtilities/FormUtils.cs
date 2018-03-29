using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssortedUtilities
{
    // Uma form que já tem um método para retornar a versão do Aplicativo.
    public class AppVersionForm : Form
    {
        protected string GetAppVersion()
        {
            // Get App Version
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version v = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                return String.Format("{0}.{1}.{2}.{3}", v.Major, v.Minor, v.Build, v.Revision);
            }
            else
            {
                return "DEVELOPMENT BUILD";
            }

            // Isso pode ser útil no futuro.
            // Version version = Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}
