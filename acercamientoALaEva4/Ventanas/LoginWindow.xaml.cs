using acercamientoALaEva4.Model;
using codigoBD.modelBD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace acercamientoALaEva4.Ventanas
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Data d;
        public LoginWindow()
        {
            InitializeComponent();
            d = new Data("LAPTOP-PC8SL5H1", "acercamientoALaEva4", "sa", "123456");
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuario = textBoxUser.Text;
            string pass = passwordBoxPass.Password;

            Usuario esteUsuario = d.Autentificacion(usuario, pass);

            if (esteUsuario == null)
            {
                MessageBox.Show("El usuario o la contraseña no coincide.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MainWindow main = new MainWindow(esteUsuario, d);
                this.Close();
                main.Show();
            }
        }
    }
}
