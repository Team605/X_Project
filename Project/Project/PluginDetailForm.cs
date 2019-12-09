using OSGi.NET.Core;
using OSGi.NET.Core.Root;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogPlugin;
using BundleServicesProvider;
using NLog;
namespace Project
{
    public partial class PluginDetailForm : Form
    {
        private string bundleName = "插件信息";
        private string bundleState = null;
        private IBundle bundle;
        private IFramework framework;
        private ILogService logService;
        private ILogger logger;
        public PluginDetailForm()
        {
            InitializeComponent();
        }

        public PluginDetailForm(IFramework framework, string bundleName, string bundleState)
        {
            this.bundleName = bundleName;
            this.bundleState = bundleState;
            bundle = framework.GetBundleContext().GetBundle(bundleName);
            this.framework = framework;
            logService = BunderServicesProvider.LogService;
            logger = logService.GetLogger();
            InitializeComponent();
            stateDetialLabel.Text = bundleState;
            
        }


        public string BundleName { get => bundleName; set => bundleName = value; }
        public string BundleState { get => bundleState; set => bundleState = value; }

        

        private string getCheckBoxDetial()
        {
            var radioButtons = this.groupBox.Controls;
            foreach (var radioButton in radioButtons)
            {
                if (radioButton is RadioButton)
                {
                    RadioButton r = radioButton as RadioButton;
                    if (r.Checked)
                    {
                        return r.Text;
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            return null;
        }

        private void buttonForMakeSure_Click(object sender, EventArgs e)
        {
            string checkBoxText = getCheckBoxDetial();
            try
            {
                switch (checkBoxText)
                {
                    case "激活":
                        bundle.Start();
                        MessageBox.Show("插件激活");
                        break;
                    case "停止":
                        bundle.Stop();
                        MessageBox.Show("插件停止");
                        break;
                    default:
                        break;
                }
            }
            catch(Exception exception)
            {
                logger.Error(exception.ToString);
                MessageBox.Show("插件状态更改失败");
            }
            
        }
    }
}
