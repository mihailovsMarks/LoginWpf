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
using EncDec;
using System.IO;

namespace EncryptionWpfV1
{
    /// <summary>
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
            tb_regsucc.Visibility = Visibility.Hidden;
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            if (txt_passReg.Password == null || txt_userReg.Text == null)
            {
                MessageBox.Show("Username or Password is too short");
            }else
            {
                string dir = txt_userReg.Text;
                Directory.CreateDirectory("Data\\" + dir);

                var sw = new StreamWriter("Data\\" + dir + "\\Data.ls");

                //Encrypting user data.
                string UserEnc = AesCrypt.Encrypt(txt_userReg.Text);
                string PassEnc = AesCrypt.Encrypt(txt_passReg.Password);

                sw.WriteLine(UserEnc);
                sw.WriteLine(PassEnc);
                sw.Close();

                tb_regsucc.Visibility = Visibility.Visible;
                
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }
    }
}
