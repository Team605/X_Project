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

namespace Project
{
    public partial class TestForm : Form
    {
        private IDBServices dBServices;
        public TestForm(IFramework framework)
        {
            string fullName1 = typeof(IDBServices).Assembly.FullName;
            string fulllName2 = typeof(BunderServicesProvider).Assembly.FullName;
            //dBServices = (DBServices)BunderServicesProvider.DBServices;
            dBServices = framework.GetBundleContext().GetService<IDBServices>();
            BunderServicesProvider instance = BunderServicesProvider.getInstance();
            InitializeComponent();
        }

        public TestForm(IDBServices dBServices)
        {
            InitializeComponent();
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
