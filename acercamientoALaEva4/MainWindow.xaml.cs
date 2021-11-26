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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace acercamientoALaEva4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Usuario usuarioLogueado;
        private Data data;

        private string[] LISTA_TIPO_REQUERIMIENTO = new string[3] { "Base de Datos", "Sistemas", "Servidores" };
        private string[] LISTA_DE_PRIORIDAD = new string[3] { "Alta", "Media", "Baja" };
        
        public MainWindow(Usuario u, Data d)
        {
            InitializeComponent();
            usuarioLogueado = u;
            data = d;
            this.Title = u.Nombre + " " + u.Apellido;
            comboBoxTipoRequerimiento.ItemsSource = LISTA_TIPO_REQUERIMIENTO;
            comboBoxAsignado.ItemsSource = d.GetUsuarios();
            comboBoxPrioridad.ItemsSource = LISTA_DE_PRIORIDAD;
        }

        internal Usuario UsuarioLogueado { get => usuarioLogueado; set => usuarioLogueado = value; }

        private void buttonGuardar_Click(object sender, RoutedEventArgs e)
        {
            string tipoRequerimiento = comboBoxTipoRequerimiento.Text;
            Usuario responsable = (Usuario)comboBoxAsignado.SelectedItem;
            string descripcion = textBoxDescripcion.Text;
            string prioridad = (string)comboBoxPrioridad.SelectedItem;

            int respuesta = data.RegistrarRequerimiento(new Requerimiento(descripcion, responsable.Id, tipoRequerimiento, prioridad));

            if(respuesta > 0)
            {
                MessageBox.Show(
                    "Se han modificado " + respuesta + " filas!",
                    "Registrar Requerimiento",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                limpiarFormulario();
            }else if(respuesta == 0)
            {
                MessageBox.Show(
                    "No se ha podido registrar!",
                    "Registrar Requerimiento",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void limpiarFormulario()
        {
            textBoxDescripcion.Text = "";
            comboBoxTipoRequerimiento.SelectedIndex = -1;
            comboBoxAsignado.SelectedIndex = -1;
            comboBoxPrioridad.SelectedIndex = -1;
        }

        private void buttonLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiarFormulario();
        }
    }
}
