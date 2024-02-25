using EmployeeManagement.ViewModels;
using EmployeeManagementBO.Models;
using EmployeeManagementRepo;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private readonly IEmployeeService service = null;
        public LoginPage()
        {
            InitializeComponent();
            service = new EmployeeService();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if((txtUserNo.Text.Trim() == "") || (pwdPassword.Password.ToString().Trim() == ""))
            {
                MessageBox.Show("Please fill in the UserNo or Password");
            }
            else
            {
                Employee employee = service.CheckLogin(Convert.ToInt32(txtUserNo.Text), pwdPassword.Password.ToString());
                if(employee != null)
                {
                    this.Visibility = Visibility.Collapsed;
                    MainWindow main = new MainWindow();
                    ApplicationUser.Role = employee.RoleId;
                    ApplicationUser.EmployeeId = employee.Id;
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please check the UserNo and Password again");
                }
            }
        }
    }
}
