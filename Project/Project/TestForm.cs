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
            InitializeComponent();

        }

        public TestForm(IDBServices dBServices)
        {
            InitializeComponent();
        }

        public void notify(Event e)
        {
            string from = e.from;
            if (from != null && from.Equals("TestPlugin2"))
            {
                Student student = e.obj as Student;
                int age = int.Parse(student.SAge);
                this.fiveYearsLaterTextBox.Text = (age).ToString();
                this.fiveYearsLaterTextBox.Refresh();
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
