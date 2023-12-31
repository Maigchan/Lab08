﻿using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Dcustomer
    {
        public static string connectionString = "DESKTOP-RQ2JF8T\\SQLEXPRESS;Initial Catalog=FacturaDB;Integrated Security=true";

        public static List<Customer> ListarClientes()
        {
            List<Customer> clientes = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                string query = "ListarClientes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila
                                clientes.Add(new Customer
                                {
                                    CustomerID = (int)reader["Customer_id"],
                                    Name = reader["name"].ToString(),
                                    Address = reader["address"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    Active = (bool)reader["active"],
                                });

                            }
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();


            }
            return clientes;

        }

    }
}