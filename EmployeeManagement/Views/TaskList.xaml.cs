using EmployeeManagement.ViewModels;
using EmployeeManagementBO.Models;
using EmployeeManagementService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    /// Interaction logic for TaskList.xaml
    /// </summary>
    public partial class TaskList : UserControl
    {
        private readonly ITaskService _service = null;
        public TaskList()
        {
            InitializeComponent();
            _service = new TaskService();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TaskPage page = new TaskPage();
            page.InsertOrUpdate = true;
            page.ShowDialog();
            LoadTask();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTask();
        }

        private void LoadTask(List<Task> listTask = null)
        {
            if(listTask == null)
            {
                listTask = _service.GetTasks();
            }
            var list = listTask.Select(x => new TaskDetailModel()
            {
                Id = x.Id,
                EmployeeId = (int)x.EmployeeId,
                Name = x.Employee.Name,
                TaskContent = x.Content,
                TaskDeliveryDate = (DateTime)x.DeliveryDate,
                TaskStartDate = (DateTime)x.StartDate,
                TaskTitle = x.Title,
                UserNo = x.Employee.UserNo,
            }).ToList();

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

            gridTask.ItemsSource = list;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUserNo.Clear();
            txtName.Clear();
            dpDelivery.SelectedDate = DateTime.Today;
            dpStart.SelectedDate = DateTime.Today;
            LoadTask();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            TaskDetailModel model = (TaskDetailModel) gridTask.SelectedItem;
            if(model != null)
            {
                TaskPage page = new TaskPage();
                page.model = model;
                page.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select the task to update");
            }
            LoadTask();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Task> list1 = new List<Task>();
            if (txtUserNo.Text.Trim() != "")
                list1 = _service.SearchTasks(x => x.Employee.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            else if (txtName.Text.Trim() != "")
                list1 = _service.SearchTasks(x => x.Employee.Name.Contains(txtName.Text)).ToList();
            else if (dpStart.SelectedDate.HasValue)
                list1 = _service.SearchTasks(x => x.StartDate >= dpStart.SelectedDate).ToList();
            else if (dpDelivery.SelectedDate.HasValue)
            {
                list1 = _service.SearchTasks(x => x.DeliveryDate >= dpDelivery.SelectedDate).ToList();
            }
            LoadTask(list1);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            TaskDetailModel model = (TaskDetailModel)gridTask.SelectedItem;
            if (model != null && model.Id != 0)
            {
                if (MessageBox.Show("Are you sure to delete", "Question", MessageBoxButton.YesNo
                    , MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _service.DeleteTask(model.Id);
                    MessageBox.Show("Task was deleted");
                }
            }
            else
            {
                MessageBox.Show("Please select Task");
            }
            LoadTask();
        }
    }
}
