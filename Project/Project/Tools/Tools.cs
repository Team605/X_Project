using OSGi.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Tools
{
    public class Tools
    {


        public static string toolStripMenuItemText2BundleName(string toolStripMenuItemText)
        {

            switch (toolStripMenuItemText)
            {
                case "日志插件":
                    return "LogPlugin";

                case "缓存插件":
                    return "CachePlugin";

                case "数据库插件":
                    return "DBPlugin";

                case "消息插件":
                    return "EventHandlePlugin";

                default:
                    return null;

            }
        }

        public static string PluginName2ToolStripMenuItemText(string pluginName)
        {
            switch (pluginName)
            {
                case "CachePlugin":
                    return "缓存插件";

                case "LogPlugin":
                    return "日志插件";

                case "DBPlugin":
                    return "数据库插件";

                case "EventHandlePlugin":

                    return "消息插件";
                default:
                    return null;

            }
        }

        public static string ToolStripMenuItem2PluginName(string itemName)
        {
            switch (itemName)
            {
                case "缓存插件ToolStripMenuItem":
                    return "CachePlugin";

                case "日志插件ToolStripMenuItem":
                    return "LogPlugin";

                case "数据库插件ToolStripMenuItem":
                    return "DBPlugin";

                case "消息插件ToolStripMenuItem":
                    return "EventHandlePlugin";

                default:
                    return null;
            }

        }

        public static string transState(int state)
        {
            switch (state)
            {
                case 0x00000001:
                    return "uninstall";

                case 0x00000002:
                    return "installed";

                case 0x00000004:
                    return "resolved";

                case 0x00000008:
                    return "starting";

                case 0x00000010:
                    return "stopping";

                case 0x00000020:
                    return "active";

                default:
                    return null;
            }

        }

        

        public static string getsubToolStripItemName(string stateName)
        {
            switch (stateName)
            {
                case "uninstall":
                    return "激活ToolStripMenuItem1";

                case "installed":
                    return "安装ToolStripMenuItem1";
                case "resolved":
                    break;
                case "starting":
                    break;
                case "active":
                    return "激活ToolStripMenuItem1";
                case "stopping":
                    break;

                default:
                    return null;
            }
            return null;
        }

        public static IBundle getBundleByName(string bundleName, IList<IBundle> bundles)
        {
            foreach(IBundle bundle in bundles)
            {
                if (bundleName.Equals(bundle.GetSymbolicName()))
                {
                    return bundle;
                }
            }
            return null;
        }
    }
}
