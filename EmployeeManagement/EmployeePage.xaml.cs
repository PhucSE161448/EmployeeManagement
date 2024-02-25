using EmployeeManagement.ViewModels;
using EmployeeManagement.Views;
using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Window
    {
        private readonly IEmployeeService _service = null;
        private readonly IDepartmentService service = null;
        public EmployeeDetailModel model;
        public bool InsertOrUpdate { get; set; }
        public Dictionary<int, string> Roles;
        public EmployeePage()
        {
            InitializeComponent();
            service = new DepartmentService();
            _service = new EmployeeService();
            Roles = new Dictionary<int, string>
            {
                { 1, "Admin"},
                { 2, "Staff"},
                { 3, "Employee"}
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboDepartment();
            LoadComboRole();
            if (model != null)
            {
                cmbDepartment.SelectedValue = model.DepartmentId;
                cmbRoleId.SelectedValue = model.Role_Id;
                txtUserNo.Text = model.UserNo.ToString();
                txtName.Text = model.Name;
                txtPassword.Text = model.Password;
                txtSalary.Text = model.Salary.ToString();
                txtAdress.AppendText(model.Address);
            }
        }

        private void LoadComboDepartment()
        {
            cmbDepartment.ItemsSource = service.GetDepartments();
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.DisplayMemberPath = "Name";
           
            cmbDepartment.SelectedIndex = -1;
        }

        private void LoadComboRole()
        {
            cmbRoleId.ItemsSource = Roles;
            cmbRoleId.DisplayMemberPath = "Value";
            cmbRoleId.SelectedValuePath = "Key";
            cmbRoleId.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserNo.Text.Trim() == "" || txtPassword.Text.Trim() == ""
                || txtName.Text.Trim() == "" || txtSalary.Text.Trim() == ""
                /*|| txtAdress != null*/ || cmbDepartment.SelectedIndex == -1
                || cmbRoleId.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the areas");
            }
            else if (InsertOrUpdate)
            {
                AddEmployee();
            }
            else
            {
                UpdateEmployee();
            }
        }

        private void AddEmployee()
        {
            bool flag = checkNumber(txtUserNo.Text, txtSalary.Text);
            if (!flag)
            {
                MessageBox.Show("The input is not a number.");
            }
            else
            {
                var unique = _service.GetEmployees().Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
                if (unique.Count > 0)
                {
                    MessageBox.Show("This User No is already used ");
                }
                else
                {
                    TextRange text = new TextRange(txtAdress.Document.ContentStart, txtAdress.Document.ContentEnd);
                    Employee employee = new Employee();
                    employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                    employee.Password = txtPassword.Text;
                    employee.Name = txtName.Text;
                    employee.Address = text.Text;
                    employee.Salary = Convert.ToInt32(txtSalary.Text);
                    employee.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                    employee.RoleId = Convert.ToInt32(cmbRoleId.SelectedValue);
                    _service.AddEmployee(employee);
                    MessageBox.Show("Add Employee Successfully");
                    this.Close();
                }
            }
        }

        private void UpdateEmployee()
        {
            bool flag = checkNumber(txtUserNo.Text, txtSalary.Text);
            if (!flag)
            {
                MessageBox.Show("The input is not a number.");
            }
            else
            {
                var unique = _service.GetEmployees().Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text) 
                && x.Id != model.Id).ToList();
                if (unique.Count > 0)
                {
                    MessageBox.Show("This User No is already used ");
                }
                else
                {
                    TextRange text = new TextRange(txtAdress.Document.ContentStart, txtAdress.Document.ContentEnd);
                    Employee employee = _service.GetEmployeeById(model.Id);
                    employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                    employee.Password = txtPassword.Text;
                    employee.Name = txtName.Text;
                    employee.Address = text.Text;
                    employee.Salary = Convert.ToInt32(txtSalary.Text);
                    employee.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                    employee.RoleId = Convert.ToInt32(cmbRoleId.SelectedValue);
                    _service.EditEmployee(employee);
                    MessageBox.Show("Update Employee Successfully");
                    this.Close();
                }

            }
        }
        private bool checkNumber(string num1, string num2)
        {
            string pattern = @"[^0-9]";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(num1) || regex.IsMatch(num2))
            {
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
