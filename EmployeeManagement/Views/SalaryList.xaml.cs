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
    /// Interaction logic for SalaryList.xaml
    /// </summary>
    public partial class SalaryList : UserControl
    {
        private readonly ISalaryService _service = null;
        List<string> item = new List<string>();
        public SalaryList()
        {
            InitializeComponent();
            _service = new SalaryService();
            LoadMonth();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSalary();
        }
       

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SalaryPage page = new SalaryPage();
            page.InsertOrUpdate = true;
            page.ShowDialog();
            LoadSalary();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SalaryDetailModel model = (SalaryDetailModel)gridSalary.SelectedItem;
            if(model != null)
            {
                SalaryPage page = new SalaryPage();
                page.model = model;
                page.ShowDialog();
                LoadSalary();
            }
            else
            {
                MessageBox.Show("Please select the salary to update");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Salary> list1 = new List<Salary>();
            if (txtUserNo.Text.Trim() != "")
                list1 = _service.SearchSalarys(x => x.Employee.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            else if (txtName.Text.Trim() != "")
                list1 = _service.SearchSalarys(x => x.Employee.Name.Contains(txtName.Text)).ToList();
            else if (cmbMonth.SelectedIndex != -1)
                list1 = _service.SearchSalarys(x => x.Month.Contains(cmbMonth.SelectedValue.ToString())).ToList();
            else if (txtYear.Text.Trim() != "")
            {
                list1 = _service.SearchSalarys(x => x.Year == Convert.ToInt32(txtYear.Text)).ToList();
            }
            else if (txtSalary.Text.Trim() != "")
            {
                if (rbMore.IsChecked == true)
                    list1 = _service.SearchSalarys(x => x.Amount > Convert.ToInt32(txtSalary.Text)).ToList();
                else if (rbLess.IsChecked == true)
                    list1 = _service.SearchSalarys(x => x.Amount < Convert.ToInt32(txtSalary.Text)).ToList();
                else
                    list1 = _service.SearchSalarys(x => x.Amount == Convert.ToInt32(txtSalary.Text)).ToList();
            }
            LoadSalary(list1);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            SalaryDetailModel model = (SalaryDetailModel)gridSalary.SelectedItem;
            if (model != null && model.Id != 0)
            {
                if (MessageBox.Show("Are you sure to delete", "Question", MessageBoxButton.YesNo
                    , MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _service.DeleteSalary(model.Id);
                    MessageBox.Show("Salary was deleted");
                }
            }
            else
            {
                MessageBox.Show("Please select Salary");
            }
            LoadSalary();
        }
        private void LoadSalary(List<Salary> salary = null)
        {
            if (salary == null)
            {
                salary = _service.GetSalarys();
            }
            var list = salary.Select(x => new SalaryDetailModel()
            {
                UserNo = x.Employee.UserNo,
                Name = x.Employee.Name,
                Amount = x.Amount,
                EmployeeId = x.EmployeeId,
                Id = x.Id,
                MonthName = x.Month,
                Year = x.Year,
            }).OrderBy(x => x.UserNo).OrderByDescending(x => x.MonthName).ToList();

            if (ApplicationUser.Role == 3)
            {
                list = list.Where(x => x.EmployeeId == ApplicationUser.EmployeeId).ToList();
                txtUserNo.IsEnabled = false;
                txtName.IsEnabled = false;
                btnAdd.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
            }

            if (ApplicationUser.Role == 2)
            {
                btnUpdate.Visibility = Visibility.Collapsed;
            }

            gridSalary.ItemsSource = list;
        }
        private void LoadMonth()
        {
            item.Add("January");
            item.Add("February");
            item.Add("March");
            item.Add("April");
            item.Add("May");
            item.Add("June");
            item.Add("July");
            item.Add("August");
            item.Add("September");
            item.Add("October");
            item.Add("November");
            item.Add("December");
            cmbMonth.ItemsSource = item;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUserNo.Text = "";
            txtName.Text = "";
            txtSalary.Text = "";
            txtYear.Text = "";
            cmbMonth.SelectedIndex = -1;
            rbMore.IsChecked = false;
            rbLess.IsChecked = false;
            rbEquals.IsChecked = false;
            LoadSalary();   
        }
    }
}
