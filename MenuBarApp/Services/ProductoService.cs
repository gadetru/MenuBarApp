using MenuBarApp.Data;
using MenuBarApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBarApp.Services
{
    public class ProductoService
    {
        private Database db = new Database();


        //*********lista de productos****************
        public List<Producto> ObtenerProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM Producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Producto
                    {
                        IdProducto = reader.GetInt32("id_producto"),
                        Nombre = reader.GetString("nombre"),
                        Precio = reader.GetDecimal("precio")
                    });
                }
            }

            return lista;
        }

        //****************** INSERTAR PRODUCTOS *********************
        public void InsertarProducto(Producto producto)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO Producto (nombre, precio, categoria) VALUES (@nombre, @precio, @categoria)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@categoria", producto.Categoria.ToString().ToLower()); // para que entienda el enum

                cmd.ExecuteNonQuery();
            }
        }
    }
}
