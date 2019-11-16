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
    /// Lógica de interacción para EliminarDatos.xaml
    /// </summary>
    public partial class EliminarDatos : Window
    {

        public EliminarDatos()
        {
            InitializeComponent();
        }
       

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(App.databasePath))
            {
                string sentenciaSQL = "delete from contactos where Nombre='" + txtNombre + "'";
                conexion.Execute(sentenciaSQL);
            }
            Close();
        }
    }
}
