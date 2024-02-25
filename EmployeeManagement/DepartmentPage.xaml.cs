using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Window
    {
        private readonly IDepartmentService _service = null;
        public Department department ;
        int modelId = 0;
        public bool InsertOrUpdate { get; set; }
        public DepartmentPage()
        {
            InitializeComponent();
            _service = new DepartmentService();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(txtDepartmentName.Text.Trim() != "")
            {
                if (InsertOrUpdate)
                {
                    AddDepartment();
                }
                else
                {
                    UpdateDepartment();
                }
            }
            else
            {
                MessageBox.Show("Please fill the Department Name area");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!InsertOrUpdate)
            {
                modelId = department.Id;
            }
            if (department != null)
            {
                txtDepartmentName.Text = department.Name;
            }
        }

        private void UpdateDepartment()
        {
            var check = _service.GetDepartments().Where(x => x.Name == txtDepartmentName.Text).ToList();
            if(check.Count > 0)
            {
                MessageBox.Show("Name of Department already exist");
            }
            else
            {
                Department department = _service.GetDepartments().FirstOrDefault(x => x.Id == modelId);
                department.Name = txtDepartmentName.Text;
                _service.EditDepartment(department);
                MessageBox.Show("Update Department Successfully");
                this.Close();
            }
        }
        private void AddDepartment()
        {
            Department de = new Department();
            de.Name = txtDepartmentName.Text;
            _service.AddDepartment(de);
            MessageBox.Show("Department Was Addded");
            this.Close();
        }
    }
}
