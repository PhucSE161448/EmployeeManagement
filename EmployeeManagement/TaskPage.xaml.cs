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
using System.Windows.Shapes;
using Task = EmployeeManagementBO.Models.Task;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Window
    {
        private readonly IEmployeeService _service = null;
        private readonly ITaskService _taService = null;
        public bool InsertOrUpdate { get; set; }
        public TaskDetailModel model;
        public int Id = 0;
        public TaskPage()
        {
            InitializeComponent();
            _service = new EmployeeService();
            _taService = new TaskService();
        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (model != null)
            {
                txtUserNo.Text = model.UserNo.ToString();
                txtName.Text = model.Name;
                txtTitle.Text = model.TaskTitle;
                txtContent.Text = model.TaskContent;
                Id = model.Id;
                gridEmployee.Visibility = Visibility.Collapsed;
            }
            gridEmployee.ItemsSource = _service.GetEmployees().OrderBy(x => x.UserNo);
        }

        private void gridEmployee_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Employee employee = (Employee)gridEmployee.SelectedItem;
            txtUserNo.Text = employee.UserNo.ToString();
            txtName.Text = employee.Name;
            Id = employee.Id;
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtContent.Text.Trim() == "" && txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the necessary areas.");
            }
            else if (InsertOrUpdate)
            {
                if (Id == 0)
                {
                    MessageBox.Show("Please Select an employee from table");
                }
                else
                {
                    AddTask();
                }
            }
            else
            {
                UpdateTask();
            }
        }
        private void AddTask()
        {
            var t = _taService.GetTasks().Any(x => x.Title == txtTitle.Text
            && x.Content == txtContent.Text);
            if (t)
            {
                MessageBox.Show("Already Exist");
            }
            else
            {
                Task task = new Task();
                task.EmployeeId = Id;
                task.Content = txtContent.Text;
                task.Title = txtTitle.Text;
                task.StartDate = DateTime.Now;
                task.DeliveryDate = DateTime.Now.AddDays(7);
                _taService.AddTask(task);
                MessageBox.Show("Add Task Successfully");
                Id = 0;
                this.Close();
            }
        }

        private void UpdateTask()
        {
            var t = _taService.GetTasks().Any(x => x.Title == txtTitle.Text
           && x.Content == txtContent.Text);
            if (t)
            {
                MessageBox.Show("Already Exist");
            }
            else
            {
                Task task = _taService.GetTasks().FirstOrDefault(x => x.Id == Id);
                task.Title = txtTitle.Text;
                task.Content = txtContent.Text;
                _taService.EditTask(task);
                MessageBox.Show("Update Task Successfully");
                this.Close();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
