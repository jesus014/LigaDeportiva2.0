using LigaDeportiva.BIZ;
using LigaDeportiva.COMMON.Entidades;
using LigaDeportiva.COMMON.Interfaces;
using LigaDeportiva.DAL;
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

namespace LigaDeportiva.GUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IManejadorAdministrador manejadorAdministrador;


        public MainWindow()
        {
            InitializeComponent();
            manejadorAdministrador = new ManejadorAdministrador(new RepositorioGenerico<Administrador>());
            Actualizar();
        }

        private void Actualizar()
        {
            cmbUsuario.ItemsSource = null;
            cmbUsuario.ItemsSource = manejadorAdministrador.Lista;
        }
        private void btnIniciarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            //Menu a = new Menu();
            //a.Show();
            //this.Close();
            /*Prueba*/
            /*MainWindow s = new MainWindow();
             a.txbTipoInicio.Text = b.Tipo;
             a.txbUsuarioInicio.Text = b.NombreDeUsuario;*/
            if (cmbUsuario.Text == "")
            {
                MessageBox.Show("No ha colocado el usuario al que corresponde\nSelecciones uno", "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(pasword.Password))
            {
                MessageBox.Show("No ha ingresado la contraseña", "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbUsuario.SelectedItem != null)
            {
                Administrador b = cmbUsuario.SelectedItem as Administrador;
                if (pasword.Password == b.Contraseña)
                {
                    Administrador2 a = new Administrador2();
                    a.Show();
                    this.Close();
                    //Prueba
                    MainWindow s = new MainWindow();

                    a.txtNombreDeUsuario.Text = b.NombreDeUsuario;


                }
                else
                {
                    MessageBox.Show("Contraseña Inconrrecta", "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun usuario", "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de cancelar la operación", "Administrador", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }









        }
    }
}
