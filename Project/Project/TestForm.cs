using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBPlugin;
using ModelPlugin;
using BundleServicesProvider;
using OSGi.NET.Core;
using OSGi.NET.Core.Root;
using TestPlugin2;
using EventHandlePlugin;
using System.Threading;

namespace Project
{
    public partial class TestForm : Form, IListener
    {
        private IDBServices dBServices;
        private IEventService eventService;
        public TestForm(IFramework framework)
        {
            string fullName1 = typeof(IDBServices).Assembly.FullName;
            string fulllName2 = typeof(BunderServicesProvider).Assembly.FullName;
            dBServices = framework.GetBundleContext().GetService<IDBServices>();
            eventService = framework.GetBundleContext().GetService<IEventService>();
            eventService.registListener(this);
            BunderServicesProvider instance = BunderServicesProvider.getInstance();
            // 获取当前线程上下文
            synchronizationContext = SynchronizationContext.Current;
            InitializeComponent();

        }

        public TestForm(IDBServices dBServices)
        {
            InitializeComponent();
        }
        // 当前线程上下文
        SynchronizationContext synchronizationContext = null;

        //其他线程更新窗体的具体操作
        private void updateFistWinForm(object o)
        {
            Student student = o as Student;
            int age = int.Parse(student.SAge);
            this.fiveYearsLaterTextBox.Text = (age).ToString();
            this.fiveYearsLaterTextBox.Refresh();
        }

        private void updateSecondWinForm(object o)
        {
            Student student = o as Student;
            int age = int.Parse(student.SAge);
            this.fiveYearsLaterTextBox2.Text = (age).ToString();
            this.fiveYearsLaterTextBox2.Refresh();
        }

        public void notify(Event e)
        {
            string from = e.from;
            if (from != null && from.Equals("TestPlugin2"))
            {
                
                Student student = e.obj as Student;
                synchronizationContext.Post(updateFistWinForm, student);
                
            }
            if (from != null && from.Equals("TestPlugin3"))
            {
                
                Student student = e.obj as Student;
                synchronizationContext.Post(updateSecondWinForm, student);

            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            //string name = this.nameTextBox.Text;
            //string age = this.ageTextBox.Text;
            //Person person = new Person();
            //person.name = name;
            //person.Age = int.Parse(age);

            string sname = this.snameTextBox.Text;
            string sno = this.snoTextBox.Text;
            string sage = this.sageTextBox.Text;
            Student student = new Student();
            student.Sno = sno;
            student.SName = sname;
            student.SAge = sage;

            //bool result = dBServices.createOperation(person);
            try
            {
                bool result = dBServices.createOperation(student);
                if (result == true)
                {
                    MessageBox.Show("创建成功", "创建结果");
                }
                else
                {
                    MessageBox.Show("创建失败", "创建结果");
                }
            }
            catch
            {
                MessageBox.Show("创建失败", "创建结果");
            }
            
        }

    }
}
