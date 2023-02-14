using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class ManejadorProductovendido
    {
        internal static class ManejadorProductoVendido
        {
            public static string connetionString = "Data Source=DESKTOP-9INRL01\\SQLEXPRESS;Initial Catalog=sistemagestion2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            public static List<Producto> ObtenerProductos(long idUsuario)
            {
                List<Producto> productos = new List<Producto>();

                using (SqlConnection conn = new SqlConnection(connetionString))
                {
                    SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE @IdUsuario = idUsuario", conn);
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    conn.Open();

                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Producto productoTemporal = new Producto();
                            productoTemporal.Id = reader.GetInt64(0);
                            productoTemporal.Descripciones = reader.GetString(1);
                            productoTemporal.Costo = reader.GetDecimal(2);
                            productoTemporal.PrecioVenta = reader.GetDecimal(3);
                            productoTemporal.Stock = reader.GetInt32(4);
                            productoTemporal.IdUsuario = reader.GetInt64(5);

                            productos.Add(productoTemporal);


                            public static List<Producto> ObtenerProductoVendido(long idUsuario)
            {
                List<long> ListaIdProductos = new List<long>();

                using (SqlConnection conn = new SqlConnection(connetionString))
                {
                    SqlCommand comando3 = new SqlCommand("SELECT IdProducto FROM Venta INNER JOIN ProductoVendido  ON venta.id = ProductoVendido.IdVenta WHERE IdUsuario = @idUsuario", conn);

                    comando3.Parameters.AddWithValue("@idUsuario", idUsuario);

                    conn.Open();

                    SqlDataReader reader = comando3.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ListaIdProductos.Add(reader.GetInt64(0));
                        }
                    }
                }
                List<Producto> productos = new List<Producto>();
                foreach (var id in ListaIdProductos)
                {
                    Producto prodTemp = ObtenerProducto(id);
                    productos.Add(prodTemp);
                }

                return productos;

            }

        }
