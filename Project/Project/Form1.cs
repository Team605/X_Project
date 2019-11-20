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
using Project.Tools;
using DBPlugin;
using LogPlugin;
using OSGi.NET.Service;

namespace Project
{
    public partial class Form1 : Form
    {

        private IList<IBundle> bundles;
        private List<string> bundleNames = new List<string>();
        private Dictionary<string, IBundle> bundleNameMap = new Dictionary<string, IBundle>();

        IFramework framework;
        private static IDBServices dBServices = null;

        private void initBundleMap(IList<IBundle> bundles)
        {
            foreach (IBundle bundle in bundles)
            {
                bundleNames.Add(bundle.GetSymbolicName());
                bundleNameMap.Add(bundle.GetSymbolicName(), bundle);
            }
        }

        public void initFramework()
        {
            var frameworkFactory = new FrameworkFactory();
            framework = frameworkFactory.CreateFramework();

            framework.Init();
            framework.Start();

            bundles = framework.GetBundleContext().GetBundles();

        }

        // 获取服务实例
        private void initServices(IFramework framework)
        {
            dBServices = framework.GetBundleContext().GetService<IDBServices>();
        }

        public Form1()
        {
            initFramework();
            initServices(framework);
            initBundleMap(bundles);
            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 插件列表菜单 => 每个插件 => 状态窗口  
        PluginDetailForm pluginDetailForm;

        // Test菜单 => Test窗口, 该窗口只用来测试
        TestForm testForm;

        private void pluginDetialFormInit()
        {

        }

        // 弹出bundle的状态信息窗口
        private void pushStateForm(object sender)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            ToolStripItem parentToolStrip = toolStripMenuItem.OwnerItem;
            string text = parentToolStrip.Text;

            string bundleName = Tools.Tools.toolStripMenuItemText2BundleName(text);
            IBundle bundle = Tools.Tools.getBundleByName(bundleName, bundles);
            int bundleState = bundle.GetState();
            string bundleStateString = Tools.Tools.transState(bundleState);
            pluginDetailForm = new PluginDetailForm(framework, bundleName, bundleStateString);
            pluginDetailForm.Text = text;
            pluginDetailForm.Show();
        }

        private void 状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pushStateForm(sender);
        }

        private void 状态信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pushStateForm(sender);
        }

        private void 状态信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pushStateForm(sender);
        }

        private void 状态信息ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pushStateForm(sender);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testForm = new TestForm();

            testForm.Show();
        }
    }
}
