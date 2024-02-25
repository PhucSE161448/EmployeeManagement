using EmployeeManagement.ViewModels;
using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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

namespace EmployeeManagement.Views
{
    /// <summary>
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : UserControl
    {
        private readonly IEmployeeService _service = null;
        private readonly IDepartmentService service = null;
        public EmployeeList()
        {
            InitializeComponent();
            _service = new EmployeeService();
            service = new DepartmentService();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbDepartment.ItemsSource = service.GetDepartments();
            cmbDepartment.DisplayMemberPath = "Name";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;

            if(ApplicationUser.Role == 2)
            {
                btnUpdate.Visibility = Visibility.Collapsed;
            }
            LoadEmployee();
        }
        private void LoadEmployee(List<Employee> employee = null)
        {
            if (employee == null)
            {
                employee = _service.GetEmployees();
            }
            gridEmployee.ItemsSource = employee.Select(x => new EmployeeDetailModel
            {
                Id = x.Id,
                UserNo = x.UserNo,
                Name = x.Name,
                Address = x.Address,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.Name,
                Salary = x.Salary,
                Password = x.Password,
                Role_Id = x.RoleId,
            }).OrderBy(x => x.UserNo)
            .ToList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage page = new EmployeePage();
            page.InsertOrUpdate = true;
            page.ShowDialog();
            LoadEmployee();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDetailModel employee = (EmployeeDetailModel)gridEmployee.SelectedItem;
            if(employee != null)
            {
                EmployeePage page = new EmployeePage();
                page.model = employee;
                page.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an employee to update");
            }
            LoadEmployee();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> list1 = new List<Employee>();
            if (txtUserNo.Text.Trim() != "")
                list1 = _service.SearchEmployee(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            else if (txtName.Text.Trim() != "")
                list1 = _service.SearchEmployee(x => x.Name.Contains(txtName.Text)).ToList();
            else if (cmbDepartment.SelectedIndex != -1)
                list1 = _service.SearchEmployee(x => x.DepartmentId == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            else if (txtAddress.Text.Trim() != "")
            {
                list1 = _service.SearchEmployee(x => x.Address.Contains(txtAddress.Text)).ToList();
            }
            else if (txtSalary.Text.Trim() != "")
            {
                list1 = _service.SearchEmployee(x => x.Salary == Convert.ToInt32(txtSalary.Text)).ToList();
            }
            LoadEmployee(list1);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtUserNo.Clear();
            txtSalary.Clear();
            txtAddress.Clear();
            cmbDepartment.SelectedIndex = -1;
            LoadEmployee();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDetailModel model = (EmployeeDetailModel)gridEmployee.SelectedItem;
            if (model != null && model.Id != 0)
            {
                if (MessageBox.Show("Are you sure to delete", "Question", MessageBoxButton.YesNo
                    , MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _service.DeleteEmployee(model.Id);
                    MessageBox.Show("Employee was deleted");
                }
            }
            else
            {
                MessageBox.Show("Please select Employee");
            }
            LoadEmployee();
        }
    }
}
