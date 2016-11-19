using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.cnx
{
    class Conexion
    {
        //atributos
        public string servidor = "";
        public string usuario = "";
        public string password = "";
        public string baseDeDatos = "";

        //nombre de la conexión a modificar
        private string nombreConexion = "IDCHECKDBEntities";

        /// <summary>
        /// obtiene los datos de la conexión para ser utilizados en el formulario
        /// </summary>
        /// <returns></returns>
        public bool getData()
        {
            bool exito = false;
            // se obtienen las conexiones
            System.Configuration.ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;

            //si existe por lo menos una conexión continuamos
            if (connections.Count != 0)
            {

                //Recorremos las conexiones existentes
                foreach (ConnectionStringSettings connection in connections)
                {
                    //asignamos el nombre
                    string name = connection.Name;
                    //obtenemos el proveedor, solo por demostración, no lo utilizaremos ni nada.
                    string provider = connection.ProviderName;
                    //obtenemos la cadena
                    string connectionString = connection.ConnectionString;

                    //comparamos el nombre al de nuestro atributo de la clase para verificar si es la cadena
                    //de conexión que modificaremos
                    if (name.Equals(nombreConexion))
                    {

                        //separamos la conexión en un arreglo tomando ; como separador
                        string[] sC = connectionString.Split(';');
                        foreach (String s in sC)
                        {

                            //separamos por el simbolo = para obtener el campo y el valor
                            string[] spliter = s.Split('=');
                            //comparamos los valores
                            switch (spliter[0].ToUpper())
                            {

                                case "DATA SOURCE":
                                    servidor = spliter[1];
                                    break;
                                case "USER ID":
                                    usuario = spliter[1];
                                    break;
                                case "PASSWORD":
                                    password = spliter[1];
                                    break;
                                case "INITIAL CATALOG":
                                    baseDeDatos = spliter[1];
                                    break;

                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("No existe la conexión");

            }

            return exito;
        }
    }
}