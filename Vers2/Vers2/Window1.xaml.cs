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
using Vers2.Clases;
using SQLite;

namespace Vers2
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Contactos> contactos;

        public Window1()
        {
            InitializeComponent();
            contactos = new List<Contactos>();
            LeerBaseDatos();
        }
        void LeerBaseDatos()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contactos>();
                contactos = (conn.Table<Contactos>().ToList()).OrderBy(c => c.Nombre).ToList();
            }
            if (contactos != null)
            {
                lvContactos.ItemsSource = contactos;
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            Vers2.MainWindow form = new Vers2.MainWindow();
            form.ShowDialog();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Vers2.EliminarDatos form = new Vers2.EliminarDatos();
            form.ShowDialog();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            Vers2.Window2 form = new Vers2.Window2();
            form.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
