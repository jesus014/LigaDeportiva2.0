using LigaDeportiva.BIZ;
using LigaDeportiva.COMMON.DatosOxi;
using LigaDeportiva.COMMON.Entidades;
using LigaDeportiva.COMMON.Interfaces;
using LigaDeportiva.COMMON.ListaInterfaces;
using LigaDeportiva.COMMON.Modelo;
using LigaDeportiva.DAL;
using Microsoft.Reporting.WinForms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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

namespace LigaDeportiva.GUI
{
    /// <summary>
    /// Lógica de interacción para Administrador2.xaml
    /// </summary>
    public partial class Administrador2 : Window
    {

        Generador generador;
        Random ran = new Random();
        enum accion

        {
            nuevo,
            editar
        }

        accion operacion;
        IManejadorAdministrador manejadorAdministrador;
        IManejadorDeporte manejadorDeporte;
        IManejadorEquipo manejadorEquipo;
        IManejadorTorneo manejadorTorneo;
        List<Administrador> Administrador;

        List<VistaDeporte> vista = new List<VistaDeporte>();
        List<Aleatorios> lista = new List<Aleatorios>();
        List<Aleatorios> lista2 = new List<Aleatorios>();
        List<Torneos> torne = new List<Torneos>();
        List<VistaDeporte> nueva = new List<VistaDeporte>();
        List<TorneoLista> listatorneo;
        string equipo1;
        string equipo2;






        public Administrador2()
        {
            InitializeComponent();


            manejadorAdministrador = new ManejadorAdministrador(new RepositorioGenerico<Administrador>());
            manejadorDeporte = new ManejadorDeporte(new RepositorioGenerico<Deporte>());
            manejadorEquipo = new ManejadorEquipo(new RepositorioGenerico<EquiposTorneo>());
            manejadorTorneo = new ManejadorTorneo(new RepositorioGenerico<Torneos>());
            Administrador = new List<Administrador>();
            listatorneo = new List<TorneoLista>();
            CargarTablas();

            HabilitarBotones(false);
            LimpiarEditarTablasDeporte(false);
            LimpiarEditarTablasEquipo(false);
            LimpiarEditarTorneo(false);



            btnCalcularEstadisticos.Click += btnCalcularEstadisticos_Click;
            generador= new Generador();
        }


        private void LimpiarTorneo(bool a)
        {
            cmbTipoDeporteTorneo.ItemsSource = "";
            clFechaTorneo.Text = "";
            cmbTipoDeporteTorneo.IsEnabled = a;
            clFechaTorneo.IsEnabled = a;
            btnOrdenarTorneo.IsEnabled = a;
            btnCancelarTorneo.IsEnabled = a;
            btnEliminarTorneo.IsEnabled = !a;
            btnNuevoTorneo.IsEnabled = !a;
            btnOrdenarTorneo.IsEnabled = a;
            btnBuscadorTorneo.IsEnabled = a;
            EliminacionDeTorneoCompleto.IsEnabled = a;
            btnCancelarTorneo.IsEnabled = a;
            btnEliminarTorneo.IsEnabled = !a;
            btnNuevoTorneo.IsEnabled = !a;
        }


        private void LimpiarEditarTorneo(bool a)
        {
            cmbTipoDeporteTorneo.ItemsSource = "";
            clFechaTorneo.Text = "";

            cmbTipoDeporteTorneo.IsEnabled = a;
            clFechaTorneo.IsEnabled = a;
            CargarTablas();

            btnOrdenarTorneo.IsEnabled = a;
            btnBuscadorTorneo.IsEnabled = a;
            EliminacionDeTorneoCompleto.IsEnabled = a;
            //btnAgregarTorneo.IsEnabled = a;
            btnCancelarTorneo.IsEnabled = a;
            //btnEditarTorneo.IsEnabled = !a;
            btnEliminarTorneo.IsEnabled = !a;
            btnNuevoTorneo.IsEnabled = !a;
        }

        private void LimpiarEditarTablasEquipo(bool v)
        {
          
            txtNombreUsuario.Clear();
          
            txtContrasenaUsuario.Clear();
            // txtDeporteUsuario.ItemsSource="";
            txtNombreDeUsuario.Clear();
        }

        private void LimpiarEditarTablasDeporte(bool a)
        {
            txtDeportesDeportes.Clear();
            txtDeportesDeportes.IsEnabled = a;

            btnAgregarDeporte.IsEnabled = a;
            btnCancelarDeporte.IsEnabled = a;
            btnEditarDeporte.IsEnabled = !a;
            btnEliminarDeporte.IsEnabled = !a;
            btnNuevoDeporte.IsEnabled = !a;
        }

        private void HabilitarBotones(bool a)
        {
    
           
            txtContrasenaUsuario.IsEnabled = a;
            
            txtNombreUsuario.IsEnabled = a;
          
            txtNombreDeUsuario.IsEnabled = a;

            btnNuevoUsuario.IsEnabled = !a;
            btnEliminarUusraios.IsEnabled = !a;
            btnAgregar.IsEnabled = a;
            btnCancelarUsuario.IsEnabled = a;
            btnEditarUsuario.IsEnabled = !a; ;
        }

        private void CargarTablas()
        {
            dtgAdmnistrador.ItemsSource = null;
            dtgAdmnistrador.ItemsSource = manejadorAdministrador.Lista;
            dtgDeporte.ItemsSource = null;
            dtgDeporte.ItemsSource = manejadorDeporte.Lista;
            dtgEquipo.ItemsSource = null;
            dtgEquipo.ItemsSource = manejadorEquipo.Lista;

            txtTipoDeporteEquipo.ItemsSource = null;
            txtTipoDeporteEquipo.ItemsSource = manejadorDeporte.Lista;

            cmbTipoDeporteTorneo.ItemsSource = null;
            cmbTipoDeporteTorneo.ItemsSource = manejadorDeporte.Lista;

            dtgPrueba.ItemsSource = null;
            dtgPrueba.ItemsSource = manejadorTorneo.Lista;

            dtgDatosDeporte2.ItemsSource = null;
            dtgDatosDeporte2.ItemsSource = vista;

            dtgDatosDeporte.ItemsSource = null;
            dtgDatosDeporte.ItemsSource = nueva;

            dtgPuntosEquipos.ItemsSource = null;
            dtgPuntosEquipos.ItemsSource = manejadorTorneo.Lista;

            cmbDeportePuntosEquipos.ItemsSource = null;
            cmbDeportePuntosEquipos.ItemsSource = manejadorDeporte.Lista;

            cmbEstadisticosEquipos.ItemsSource = null;
            cmbEstadisticosEquipos.ItemsSource = manejadorDeporte.Lista;
        }
        private void LimpiarCamposTablasUsuario()
        {
            
            txtNombreUsuario.Clear();
            txtContrasenaUsuario.Clear();
            // txtDeporteUsuario.ItemsSource="";
            txtNombreDeUsuario.Clear();
        }

 






        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposTablasUsuario();
            HabilitarBotones(true);
            operacion = accion.nuevo;
        }



        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrEmpty(txtNombreDeUsuario.Text) || string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                MessageBox.Show("No ha ingresado los datos del  Administrador", "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        
            if ( string.IsNullOrEmpty(txtNombreDeUsuario.Text)  || string.IsNullOrEmpty(txtContrasenaUsuario.Password))
            {
                MessageBox.Show("No ha ingresado todos los datos del Usuario\n*Nombre de usuario\n*Deporte\n*Tipo de usuario\n*Contraseña", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
         
            int contrasena = txtContrasenaUsuario.Password.Count();
            if (contrasena <= 8)
            {
                MessageBox.Show("La contraseña debe de ser mayor o igual a 8 caracteres para mayor seguridad", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (operacion == accion.nuevo)
            {
                Administrador a = new Administrador()
                {
                    
                    Contraseña = txtContrasenaUsuario.Password,
                    Nombre = txtNombreUsuario.Text.ToUpper(),
                    NombreDeUsuario = txtNombreDeUsuario.Text,
           
                };
                manejadorAdministrador.Agregar(a);
                CargarTablas();
                LimpiarCamposTablasUsuario();
                HabilitarBotones(false);
            }
            else
            {
                Administrador administrador = dtgAdmnistrador.SelectedItem as Administrador;

                administrador.Contraseña = txtContrasenaUsuario.Password;
                administrador.Nombre = txtNombreUsuario.Text.ToUpper();
                administrador.NombreDeUsuario = txtNombreDeUsuario.Text;
         
                if (manejadorAdministrador.Modificar(administrador))
                {
                    CargarTablas();
                    LimpiarCamposTablasUsuario();
                    HabilitarBotones(false);
                    MessageBox.Show("Usuario editado correctamente", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se puedo editar correctamente el usuario", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }



        private void btnEliminarUusraios_Click(object sender, RoutedEventArgs e)
        {
            Administrador a = dtgAdmnistrador.SelectedItem as Administrador;
            if (a != null)
            {
                if (MessageBox.Show("Realmente esta seguro de eliminar Al admnistrador: " + a.Nombre, "Eliminación Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorAdministrador.Eliminar(a.Id);
                    CargarTablas();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Usuarios", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (dtgAdmnistrador.SelectedItem != null)
            {
                Administrador a = dtgAdmnistrador.SelectedItem as Administrador;
       
                txtContrasenaUsuario.Password = a.Contraseña;
        
                txtNombreDeUsuario.Text = a.NombreDeUsuario;
                txtNombreUsuario.Text = a.Nombre;

                operacion = accion.editar;
                HabilitarBotones(true);

            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla Usuarios", "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta realmente seguro de cancelar la operación", "Admnistrador", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                HabilitarBotones(false);
                LimpiarCamposTablasUsuario();
            }
        }

        private void btnNuevoDeporte_Click(object sender, RoutedEventArgs e)
        {
            LimpiarEditarTablasDeporte(true);
            operacion = accion.nuevo;
        }

        private void btnAgregarDeporte_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeportesDeportes.Text))
            {
                MessageBox.Show("Error!!!...No ha ingresado el Deporte", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (operacion == accion.nuevo)
            {
                Deporte a = new Deporte();
                a.Tipo_Deporte = txtDeportesDeportes.Text.ToUpper();

                if (manejadorDeporte.Agregar(a))
                {
                    MessageBox.Show("Deporte ingresado correctamente", "Deportes", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarEditarTablasDeporte(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar los datos correctamente", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                Deporte a = dtgDeporte.SelectedItem as Deporte;
                a.Tipo_Deporte = txtDeportesDeportes.Text.ToUpper();
                if (manejadorDeporte.Modificar(a))
                {
                    MessageBox.Show("Deporte Actualizado correctamente", "Deportes", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarEditarTablasDeporte(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar Editar correctamente el Deporte", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void btnEditarDeporte_Click(object sender, RoutedEventArgs e)
        {
            if (dtgDeporte.SelectedItem != null)
            {
                operacion = accion.editar;
                LimpiarEditarTablasDeporte(true);
                Deporte a = dtgDeporte.SelectedItem as Deporte;
                txtDeportesDeportes.Text = a.Tipo_Deporte;
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnEliminarDeporte_Click(object sender, RoutedEventArgs e)
        {
            if (dtgDeporte.SelectedItem != null)
            {
                Deporte a = dtgDeporte.SelectedItem as Deporte;
                if (MessageBox.Show("Realmente esta seguro de eliminar a " + a.Tipo_Deporte, "Deportes", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorDeporte.Eliminar(a.Id);
                    CargarTablas();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla", "Deportes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarDeporte_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Realmente esta seguro de cancelar la operación", "Deporte", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                LimpiarEditarTablasDeporte(false);
            }
        }

        private void btnNuevoEquipo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarEditarTablasEquipo(true);
            operacion = accion.nuevo;
        }

        private void btnAgregarEquipo_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtTipoDeporteEquipo.Text) || string.IsNullOrEmpty(txtNombreEquipo.Text) || string.IsNullOrEmpty(txtDirectorEquipo.Text))
            {
                MessageBox.Show("No ha llenado la información básica del equipo", "Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (operacion == accion.nuevo)
            {

                EquiposTorneo a = new EquiposTorneo();
                a.Director = txtDirectorEquipo.Text.ToUpper();
                a.Tipo_De_Deporte = txtTipoDeporteEquipo.Text.ToUpper();
                a.Nombre = txtNombreEquipo.Text.ToUpper();

                if (manejadorEquipo.Agregar(a))
                {
                    MessageBox.Show("Equipo ingresado correctamente", "Equipo", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarEditarTablasEquipo(false);
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar correctamente el equipo", "Equipo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                EquiposTorneo a = dtgEquipo.SelectedItem as EquiposTorneo;
                a.Director = txtDirectorEquipo.Text.ToUpper();
                a.Nombre = txtNombreEquipo.Text.ToUpper();
                a.Tipo_De_Deporte = txtTipoDeporteEquipo.Text.ToUpper();
                if (manejadorEquipo.Modificar(a))
                {
                    MessageBox.Show("Equipo Editado Correctamente", "Equipo", MessageBoxButton.OK, MessageBoxImage.Information);

                    CargarTablas();
                    LimpiarEditarTablasEquipo(false);
                }

                else
                {
                    MessageBox.Show("Equipo Editado Inorrectamente", "Equipo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditarEquipo_Click(object sender, RoutedEventArgs e)
        {
            EquiposTorneo a = dtgEquipo.SelectedItem as EquiposTorneo;
            if (a != null)
            {
                LimpiarEditarTablasEquipo(true);
                txtDirectorEquipo.Text = a.Director;
                txtTipoDeporteEquipo.Text = a.Tipo_De_Deporte;
                txtNombreEquipo.Text = a.Nombre;
                operacion = accion.editar;
            }
            else
            {
                MessageBox.Show("No ha seleccionado la tabla de Equipo\nSeleccione un elemento para editarlo", "Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnEliminarEquipo_Click(object sender, RoutedEventArgs e)
        {
            if (dtgEquipo.SelectedItem != null)
            {
                EquiposTorneo a = dtgEquipo.SelectedItem as EquiposTorneo;
                if (MessageBox.Show("Realmente esta seguro de eliminar a " + a.Nombre, "Equipos", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEquipo.Eliminar(a.Id))
                    {
                        MessageBox.Show("Equipo eliminado sadisfactoriamente", "Equipos", MessageBoxButton.OK, MessageBoxImage.Information);
                        CargarTablas();
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla", "Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnCancelarEquipo_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Realmente esta seguro de cancelar la operación", "Equipo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                LimpiarEditarTablasEquipo(false);

            }
        }

        private void btnNuevoTorneo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarEditarTorneo(true);
            torne = new List<Torneos>();
            dtgDatosDeporte.ItemsSource = null;
            dtgDatosDeporte.ItemsSource = torne;
        }
        public void PrimerEquipoTorneo()
        {
            int contador = 0;
            Aleatorios a = new Aleatorios();
            foreach (var item in lista)
            {
                contador++;
                if (contador == 1)
                {
                    equipo1 = item.Datos;
                    a.Datos = item.Datos;
                    lista.Remove(item);
                    lista2.Add(a);
                    break;
                }
            }

        }
        private void SegundoEquipotorneoImpar()
        {
            if (lista.Count >= 1)
            {
                Random r = new Random();
                int val = r.Next(1, lista.Count);
                int contador = 0;

                foreach (var item2 in lista)
                {
                    contador++;

                    if (contador == val)
                    {
                        equipo2 = item2.Datos;
                        lista.Remove(item2);
                        break;
                    }
                }
            }
        }
        private void AgregarListaNumerosImpares(string palabra)
        {
            PrimerEquipoTorneo();
            SegundoEquipotorneoImpar();
            Torneos a = new Torneos()
            {
                Equipo1 = equipo1,
                Equipo2 = equipo2,
                Marcador_1 = 0,
                Marcador_2 = 0,
                Tipo_Deporte = palabra.ToUpper(),
                FechaProgramada = clFechaTorneo.Text,
            };
            torne.Add(a);
            manejadorTorneo.Agregar(a);
            dtgPrueba.ItemsSource = null;
            dtgPrueba.ItemsSource = manejadorTorneo.Lista;
            dtgDatosDeporte.ItemsSource = null;
            dtgDatosDeporte.ItemsSource = torne;
        }

        private void CargarEquipos(string palabra)
        {
            foreach (var item in manejadorEquipo.Lista)
            {
                List<VistaDeporte> nueva = new List<VistaDeporte>();
                if (item.Tipo_De_Deporte == palabra)
                {
                    VistaDeporte equipos = new VistaDeporte();
                    equipos.Nombre = item.Nombre;
                    equipos.Tipo_De_Deporte = palabra;
                    equipos.Director = item.Director;
                    nueva.Add(equipos);
                }
            }
            dtgDatosDeporte.ItemsSource = null;
            dtgDatosDeporte.ItemsSource = nueva;
        }
        private void btnOrdenarTorneo_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTipoDeporteTorneo.SelectedItem == null)
            {
                MessageBox.Show("Error...No ha seleccionado ningun deporte!!!", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string palabra = cmbTipoDeporteTorneo.Text;
            if (manejadorEquipo.ContadorDeBuscarEquipo(palabra) <= 1)
            {
                MessageBox.Show("No se puede realizar los torneos con un solo equipo\nAgregue más equipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(clFechaTorneo.Text))
            {
                MessageBox.Show("Agregue la fecha programada del torneo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in manejadorEquipo.Lista)
            {
                if (item.Tipo_De_Deporte == palabra)
                {
                    Aleatorios equipos = new Aleatorios();
                    equipos.Datos = item.Nombre;
                    lista.Add(equipos);
                }
            }
            /*Cargar datos en la segunda tabla*/
            //    CargarEquipos(palabra);

            if (lista.Count % 2 == 0)
            {
                while (((lista.Count) / 2) > 0)
                {
                    AgregarListaNumerosImpares(palabra);
                }
            }
            else
            {
                while (((lista.Count) / 2) > 0)
                {
                    AgregarListaNumerosImpares(palabra);
                }
                UltimoElemntoRestante(palabra);
            }

            /**/
            LimpiarTorneo(false);
            //  LimpiarEditarTorneo(false);
        }

        private void UltimoElemntoRestante(string palabra)
        {
            PrimerEquipoTorneo();
            if (lista.Count >= 1)
            {
                Random r = new Random();
                int val = r.Next(2, lista2.Count);
                int contador = 0;

                foreach (var item2 in lista2)
                {
                    contador++;

                    if (contador == val)
                    {
                        equipo2 = item2.Datos;
                        break;
                    }
                }
            }
            Torneos a = new Torneos()
            {
                Equipo1 = equipo1,
                Equipo2 = equipo2,
                Tipo_Deporte = palabra.ToUpper(),
                Marcador_1 = 0,
                Marcador_2 = 0,
                FechaProgramada = clFechaTorneo.Text,
            };
            torne.Add(a);
            manejadorTorneo.Agregar(a);
            dtgPrueba.ItemsSource = null;
            dtgPrueba.ItemsSource = manejadorTorneo.Lista;
            // dtgPrueba.ItemsSource = torne;
            dtgDatosDeporte.ItemsSource = null;
            dtgDatosDeporte.ItemsSource = torne;
        }


        private void btnBuscadorTorneo_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTipoDeporteTorneo.SelectedItem != null)
            {
                List<VistaDeporte> vista = new List<VistaDeporte>();
                foreach (var item in manejadorEquipo.Lista)
                {
                    if (item.Tipo_De_Deporte == cmbTipoDeporteTorneo.Text)
                    {
                        VistaDeporte s = new VistaDeporte()
                        {
                            Director = item.Director,
                            Nombre = item.Nombre,
                            Tipo_De_Deporte = cmbTipoDeporteTorneo.Text
                        };
                        vista.Add(s);
                    }
                }
                dtgDatosDeporte2.ItemsSource = null;
                dtgDatosDeporte2.ItemsSource = vista;
            }
            else
            {
                MessageBox.Show("Debe primero seleccionar un Deporte", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void btnEliminarTorneo_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPrueba.SelectedItem != null)
            {
                Torneos a = dtgPrueba.SelectedItem as Torneos;
                if (MessageBox.Show("Esta realmente seguro de eliminar los equipos: " + a.Equipo1 + " & " + a.Equipo2, "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorTorneo.Eliminar(a.Id))
                    {
                        MessageBox.Show("Equipos eliminados", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se puedo eliminar el los quipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla para eliminar\nSeleccione uno", "Torneo Eliminación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void btnCancelarTorneo_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de cancelar la operación?", "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                CargarTablas();
                LimpiarEditarTorneo(false);
            }
        }

        private void EliminacionDeTorneoCompleto_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(clFechaTorneo.Text))
            {
                MessageBox.Show("Seleccione la fecha del torneo para su eliminación", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbTipoDeporteTorneo.Text))
            {
                MessageBox.Show("Seleccione el Deporte para su eliminación", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (cmbTipoDeporteTorneo.SelectedItem != null)
            {
                if (MessageBox.Show("Realmente esta seguro de eliminar el torneo", "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    foreach (var item in manejadorTorneo.Lista)
                    {
                        if (item.FechaProgramada == clFechaTorneo.Text && item.Tipo_Deporte == cmbTipoDeporteTorneo.Text)
                        {
                            manejadorTorneo.Eliminar(item.Id);
                        }
                    }
                    MessageBox.Show("Eliminación del Torneo Correctamente", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarTablas();
                    LimpiarEditarTorneo(true);
                    LimpiarTorneo(false);
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado el Deporte para su eliminación", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PuntosEquiposBuscador_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDeportePuntosEquipos.Text)) {
                MessageBox.Show("Seleccione un Deporte", "Puntos Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(clcFechaPuntosEquipos.Text))
            {
                MessageBox.Show("Seleccione la fecha de programación del torneo", "Puntos Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            List<TipoDeporteTemp> tipo = new List<TipoDeporteTemp>();
            if (cmbDeportePuntosEquipos.SelectedItem != null)
            {
                foreach (var item in manejadorTorneo.Lista)
                {
                    if (item.Tipo_Deporte== cmbDeportePuntosEquipos.Text && item.FechaProgramada== clcFechaPuntosEquipos.Text) {
                        TipoDeporteTemp TipoDeporteTemporal = new TipoDeporteTemp() {
                            Equipo1 = item.Equipo1,
                            Equipo2 = item.Equipo2,
                            Tipo_Deporte = item.Tipo_Deporte,
                            FechaProgramada = item.FechaProgramada,
                            Id = item.Id.ToString(),
                            Marcador_1 = item.Marcador_1,
                            Marcador_2 = item.Marcador_2,                          
                        };
                        tipo.Add(TipoDeporteTemporal);
                    }
                }
                dtgPuntosEquipos.ItemsSource = null;
                dtgPuntosEquipos.ItemsSource = tipo;
            }
            else {
                MessageBox.Show("Algo salio mal :(\nIntentalo de nuevo", "Puntos Equipos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void PuntosRegresarTabla_Click(object sender, RoutedEventArgs e)
        {
            dtgPuntosEquipos.ItemsSource = null;
            dtgPuntosEquipos.ItemsSource = manejadorTorneo.Lista;
        }


        private void dtgPuntosEquipos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dtgPuntosEquipos.SelectedItem != null)
            {
                Torneos a = dtgPuntosEquipos.SelectedItem as Torneos;
                if (a != null)
                {
                    txtPuntosToneroIdentificador.Text = a.Id.ToString();
                    txtPuntosToneroEquipo1.Text = a.Equipo1;
                    txtPuntosToneroEquipo2.Text = a.Equipo2;
                    txtPuntosMarcador1.Text = a.Marcador_1.ToString();
                    txtPuntosMarcador2.Text = a.Marcador_2.ToString();
                }
                else
                {
                    TipoDeporteTemp b = dtgPuntosEquipos.SelectedItem as TipoDeporteTemp;
                    foreach (var item in manejadorTorneo.Lista)
                    {
                        if (b.Id == item.Id.ToString())
                        {
                            txtPuntosToneroIdentificador.Text = item.Id.ToString();
                            txtPuntosToneroEquipo1.Text = item.Equipo1;
                            txtPuntosToneroEquipo2.Text = item.Equipo2;
                            txtPuntosMarcador1.Text = item.Marcador_1.ToString();
                            txtPuntosMarcador2.Text = item.Marcador_2.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEditarPuntosEquipos_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPuntosToneroIdentificador.Text))
            {
                MessageBox.Show("No ha seleccionado ningun campo de la tabla para actualizar", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (manejadorTorneo.VerificarSiEsNumero(txtPuntosMarcador1.Text) == 1)
            {
                MessageBox.Show("No se aceptan letras, solo numeros en Marcador 1 ", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (manejadorTorneo.VerificarSiEsNumero(txtPuntosMarcador2.Text) == 1)
            {
                MessageBox.Show("No se aceptan letras, solo numeros en Marcador 2", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int eq1 = 0;
            int eq2 = 0;
            if (int.Parse(txtPuntosMarcador1.Text) > int.Parse(txtPuntosMarcador2.Text))
            {
                eq1 = 3;
                eq2 = 1;
            }
            if (int.Parse(txtPuntosMarcador1.Text) < int.Parse(txtPuntosMarcador2.Text))
            {
                eq1 = 1;
                eq2 = 3;
            }
            if (int.Parse(txtPuntosMarcador1.Text) == int.Parse(txtPuntosMarcador2.Text))
            {
                eq1 = 2;
                eq2 = 2;
            }

            foreach (var item in manejadorTorneo.Lista)
            {
                if (item.Id.ToString() == txtPuntosToneroIdentificador.Text)
                {
                    item.Equipo1 = txtPuntosToneroEquipo1.Text;
                    item.Equipo2 = txtPuntosToneroEquipo2.Text;
                    item.Marcador_1 = eq1;
                    item.Marcador_2 = eq2;
                    if (manejadorTorneo.Modificar(item))
                    {
                        CargarTablas();
                        LimpiarPuntosTorneo();
                        MessageBox.Show("Torneo editado correctamente", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se puedo editar correctamente el Torneo", "Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }




        private void LimpiarPuntosTorneo()
        {
            txtPuntosToneroEquipo1.Clear();
            txtPuntosToneroEquipo2.Clear();
            txtPuntosMarcador1.Clear();
            txtPuntosMarcador2.Clear();
            txtPuntosToneroIdentificador.Clear();
        }

        private void btnEliminarPuntosEquipos_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPuntosEquipos.SelectedItem != null)
            {
                Torneos a = dtgPuntosEquipos.SelectedItem as Torneos;
                if (a != null)
                {
                    if (MessageBox.Show("Esta realmente seguro de eliminar los equipos: " + a.Equipo1 + " & " + a.Equipo2, "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (manejadorTorneo.Eliminar(a.Id))
                        {
                            MessageBox.Show("Equipos eliminados", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                            CargarTablas();
                            LimpiarPuntosTorneo();
                        }
                        else
                        {
                            MessageBox.Show("No se puedo eliminar el los quipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    TipoDeporteTemp b = dtgPuntosEquipos.SelectedItem as TipoDeporteTemp;
                    foreach (var item in manejadorTorneo.Lista)
                    {
                        if (b.Id == item.Id.ToString())
                        {
                            if (MessageBox.Show("Esta realmente seguro de eliminar los equipos: " + item.Equipo1 + " & " + item.Equipo2, "Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                if (manejadorTorneo.Eliminar(item.Id))
                                {
                                    MessageBox.Show("Equipos eliminados", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Information);
                                    CargarTablas();
                                    LimpiarPuntosTorneo();
                                }
                                else
                                {
                                    MessageBox.Show("No se puedo eliminar el los quipos", "Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento de la tabla", "Puntos Torneo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnCancelarPuntosEquipos_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta realmente seguro de cancelar la operación?", "Puntos Torneo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                CargarTablas();
                LimpiarPuntosTorneo();
            }
        }


        private void GenerarEstadisticos(int valor, string Deporte, string Fecha)
        {
            int contador = 1, contador1 = 1;
            List<NombreDeporte> nombre = new List<NombreDeporte>();
            foreach (var item in manejadorEquipo.Lista)
            {
                if (item.Tipo_De_Deporte == cmbEstadisticosEquipos.Text)
                {
                    NombreDeporte a = new NombreDeporte();
                    a.Numerador = contador1++;
                    a.Nombre = item.Nombre;
                    nombre.Add(a);
                }
            }

            List<TorneoLista> listatorneo = new List<TorneoLista>();

            foreach (var item in nombre)
            {
                int valores1 = 0;
                foreach (var item2 in manejadorTorneo.Lista)
                {
                    if (item2.FechaProgramada == clcFechaEstadisticos.Text)
                    {
                        if (item.Nombre == item2.Equipo1)
                        {
                            valores1 = valores1 + item2.Marcador_1;
                        }
                        if (item.Nombre == item2.Equipo2)
                        {
                            valores1 = valores1 + item2.Marcador_2;
                        }
                    }
                }
                TorneoLista a = new TorneoLista();
                a.X = contador++;
                a.Equipo = item.Nombre;
                a.Puntaje = valores1;
                listatorneo.Add(a);
            }


            int valores = 0;
            valores = listatorneo.Count;
            generador.GeneradorDatos(listatorneo, 1, valores, 1);
            dtgTablaEstadisticos.ItemsSource = null;
            dtgTablaEstadisticos.ItemsSource = listatorneo;
            PlotModel model = new PlotModel();
            LinearAxis ejeX = new LinearAxis();
            ejeX.Minimum = 1;
            ejeX.Maximum = valores;
            ejeX.Position = AxisPosition.Bottom;

            LinearAxis ejeY = new LinearAxis();
            ejeY.Minimum = generador.Puntos.Min(p => p.Y);
            ejeY.Maximum = generador.Puntos.Max(p => p.Y);
            ejeY.Position = AxisPosition.Left;

            model.Axes.Add(ejeX);
            model.Axes.Add(ejeY);
            model.Title = "Datos generados";
            LineSeries linea = new LineSeries();
            foreach (var item in generador.Puntos)
            {
                linea.Points.Add(new DataPoint(item.X, item.Y));
            }
            linea.Title = "Valores generados";
            linea.Color = OxyColor.FromRgb(byte.Parse(ran.Next(0, 255).ToString()), byte.Parse(ran.Next(0, 255).ToString()), byte.Parse(ran.Next(0, 255).ToString()));
            model.Series.Add(linea);
            Grafica.Model = model;
        }


        private void btnCalcularEstadisticos_Click(object sender, RoutedEventArgs e)
        {
            int valor = 0;
            if (string.IsNullOrEmpty(clcFechaEstadisticos.Text) || string.IsNullOrEmpty(cmbEstadisticosEquipos.Text))
            {
                MessageBox.Show("Favor de llenar datos\n*Fecha\n*Tipo de Deporte", "Estadisticos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in manejadorTorneo.Lista)
            {
                if (item.Tipo_Deporte == cmbEstadisticosEquipos.Text && item.FechaProgramada == clcFechaEstadisticos.Text)
                {
                    valor++;
                }
            }
            if (valor <= 0)
            {
                MessageBox.Show("No se encontro ningun Torneo con esa fecha o Deporte", "Estadisticos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            GenerarEstadisticos(valor, cmbEstadisticosEquipos.Text, clcFechaEstadisticos.Text);
        }

        private void BuscarDeportes()
        {
            int valor = 0;
            if (string.IsNullOrEmpty(cmbEstadisticosEquipos.Text))
            {
                MessageBox.Show("Seleccione un deporte para observar su Historial", "Impresión", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in manejadorTorneo.Lista)
            {
                if (item.Tipo_Deporte == cmbEstadisticosEquipos.Text)
                {
                    valor++;
                }
            }
            if (valor <= 0)
            {
                MessageBox.Show("No se encontro ningun Torneo con ese Deporte", "Impresión", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            List<ReportDataSource> datos = new List<ReportDataSource>();
            ReportDataSource vales = new ReportDataSource();
            List<Modelo> datosTorneo = new List<Modelo>();
            foreach (var item in manejadorTorneo.Lista)
            {
                if (item.Tipo_Deporte == cmbEstadisticosEquipos.Text)
                {
                    datosTorneo.Add(new Modelo(item));
                }
            }
            vales.Value = datosTorneo;
            vales.Name = "DataSet1";
            datos.Add(vales);
            Reporteador ventana = new Reporteador("Torneo.GUI.Reporte.ReporteSinParametros.rdlc", datos);
            ventana.ShowDialog();
        }

        private void btnImprimirEstadisticos_Click(object sender, RoutedEventArgs e)
        {
            BuscarDeportes();
        }























    }
}
