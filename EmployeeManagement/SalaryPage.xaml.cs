using EmployeeManagement.ViewModels;
using EmployeeManagement.Views;
using EmployeeManagementBO.Models;
using EmployeeManagementService;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using System.Windows.Shapes;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for SalaryPage.xaml
    /// </summary>
    public partial class SalaryPage : Window
    {
        private readonly ISalaryService _service = null;
        private readonly IEmployeeService _emservice = null;
        List<string> item = new List<string>();
        public SalaryDetailModel model;
        int modelId = 0;
        public bool InsertOrUpdate { get; set; }
        public SalaryPage()
        {
            InitializeComponent();
            _service = new SalaryService();
            _emservice = new EmployeeService();
            LoadMonth();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (model != null)
            {
                txtName.Text = model.Name;
                txtUserNo.Text = model.UserNo.ToString();
                txtSalary.Text = model.Amount.ToString();
                txtYear.Text = model.Year.ToString();
                cmbMonth.SelectedValue = model.MonthName;
                modelId = model.Id;
                gridEmployee.Visibility = Visibility.Collapsed;
            }
            else
            {
                gridEmployee.ItemsSource = _emservice.GetEmployees();
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtSalary.Text.Trim() == "" || txtYear.Text.Trim() == "" || cmbMonth.SelectedIndex == -1)
                MessageBox.Show("Please fill the necessary areas");
            else if (InsertOrUpdate)
            {
                AddSalary();
            }
            else
            {
                UpdateSalary();
            }
        }
        private void gridEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee employee = (Employee)gridEmployee.SelectedItem;
            txtUserNo.Text = employee.UserNo.ToString();
            txtName.Text = employee.Name;
            txtYear.Text = DateTime.Now.Year.ToString();
            txtSalary.Text = employee.Salary.ToString();
            modelId = employee.Id;
        }
        private void AddSalary()
        {
            bool flag = checkNumber(txtSalary.Text);
            if (!flag)
            {
                MessageBox.Show("The input is not a number.");
            }
            else
            {
                if (modelId == 0)
                    MessageBox.Show("Please select an employee from table");
                else
                {
                    var s = _service.GetSalarys().Any(x => x.Month == cmbMonth.SelectedValue.ToString()
                    && x.Year == Convert.ToInt32(txtYear.Text)
                    && x.EmployeeId == modelId);
                    if (s)
                    {
                        MessageBox.Show("Already Exist");
                    }
                    else
                    {
                        Salary salary = new Salary();
                        salary.EmployeeId = modelId;
                        salary.Amount = Convert.ToInt32(txtSalary.Text);
                        salary.Month = cmbMonth.SelectedValue.ToString();
                        salary.Year = Convert.ToInt32(txtYear.Text);
                        _service.AddSalary(salary);
                        MessageBox.Show("Salary was added");
                        this.Close();
                    }
                }
            }
        }

        private void UpdateSalary()
        {
            bool flag = checkNumber(txtSalary.Text);
            if (!flag)
            {
                MessageBox.Show("The input is not a number.");
            }
            else
            {
                var list = _service.GetSalarys().Where(x => x.Month == cmbMonth.SelectedValue.ToString()
                && x.Year == Convert.ToInt32(txtYear.Text)
                && x.EmployeeId == modelId
                ).ToList();
                if (list.Count > 0)
                {
                    MessageBox.Show("Already Exist");
                }
                else
                {
                    Salary salary = _service.GetSalarys().FirstOrDefault(x => x.Id == modelId);
                    salary.Month = cmbMonth.SelectedValue.ToString();
                    salary.Year = Convert.ToInt32(txtYear.Text);
                    _service.EditSalary(salary);
                    MessageBox.Show("Update Salary Successfully");
                    this.Close();
                }
            }
        }


        private bool checkNumber(string num2)
        {
            string pattern = @"[^0-9]";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(num2))
            {
                return false;
            }
            return true;
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
