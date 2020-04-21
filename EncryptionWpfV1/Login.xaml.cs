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
using System.IO;
using EncDec;

namespace EncryptionWpfV1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            tb_Logfail.Visibility = Visibility.Hidden;
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Reg());
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (txt_pass.Password == null || txt_user.Text == null)
            {
                MessageBox.Show("Please enter username or password");
            }
            else
            {
                string usr = txt_user.Text;

                if(!Directory.Exists("Data\\" + usr))
                {
                    tb_Logfail.Visibility = Visibility.Visible;
                }
                else 
                {
                    var sr = new StreamReader("Data\\" + usr + "\\Data.ls");

                    string ecUser = sr.ReadLine();
                    string ecPass = sr.ReadLine();
                    sr.Close();

                    string dcUser = AesCrypt.Decrypt(ecUser);
                    string dcPass = AesCrypt.Decrypt(ecPass);

                    if(dcUser == txt_user.Text && dcPass == txt_pass.Password)
                    {
                        MessageBox.Show("Welcome " + txt_user.Text);
                    }
    
                }

            }
        }
    }
}
