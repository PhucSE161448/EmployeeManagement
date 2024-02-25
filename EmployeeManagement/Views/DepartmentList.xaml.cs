using EmployeeManagement.ViewModels;
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

namespace EmployeeManagement.Views
{
    /// <summary>
    /// Interaction logic for DepartmentList.xaml
    /// </summary>
    public partial class DepartmentList : UserControl
    {
        private readonly IDepartmentService service = null;
        public DepartmentList()
        {
            InitializeComponent();
            service = new DepartmentService();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DepartmentPage page = new DepartmentPage();
            page.InsertOrUpdate = true;
            page.ShowDialog();
            gridDepartment.ItemsSource = service.GetDepartments();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Department department = (Department)gridDepartment.SelectedItem;
            if (department != null)
            {
                DepartmentPage page = new DepartmentPage();
                page.department = department;
                page.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select the department to update");
            }
            gridDepartment.ItemsSource = service.GetDepartments();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            gridDepartment.ItemsSource = service.GetDepartments();
            if (ApplicationUser.Role == 3)
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
            }


            if (ApplicationUser.Role == 2)
            {
                btnUpdate.Visibility = Visibility.Collapsed;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Department model = (Department)gridDepartment.SelectedItem;
            if (model != null && model.Id != 0)
            {
                if (MessageBox.Show("Are you sure to delete", "Question", MessageBoxButton.YesNo
                    , MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    service.DeleteDepartment(model.Id);
                    MessageBox.Show("Department was deleted");
                }
            }
            else
            {
                MessageBox.Show("Please select department");
            }
            gridDepartment.ItemsSource = service.GetDepartments();
        }
    }
}
