using EmployeeManagement.ViewModels;
using EmployeeManagement.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEmployeeService _service = null;
        public MainWindow()
        {
            InitializeComponent();
            _service = new EmployeeService();
        }

        private void btnDepartment_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Department List";
            DataContext = new DepartmentViewModel();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationUser.Role == 3)
            {
                var model = LoadEmployeeById();
                EmployeePage page = new EmployeePage();
                page.model = model;
                page.ShowDialog();
            }
            else
            {
                lblWindowName.Content = "Employee List";
                DataContext = new EmployeeViewModel();
            }
        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Task List";
            DataContext = new TaskViewModel();
        }

        private void btnSalary_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Salary List";
            DataContext = new SalaryViewModel();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to log out ?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                LoginPage page = new LoginPage();
                this.Close();
                page.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private EmployeeDetailModel LoadEmployeeById()
        {
            Employee employee = _service.GetEmployeeById(ApplicationUser.EmployeeId);
            EmployeeDetailModel model = new EmployeeDetailModel();
            model.UserNo = employee.UserNo;
            model.Name = employee.Name;
            model.Address = employee.Address;
            model.Password = employee.Password;
            model.Id = employee.Id;
            model.DepartmentId = employee.DepartmentId;
            model.Salary = employee.Salary;
            model.Role_Id = employee.RoleId;
            return model;
        }
    }
}