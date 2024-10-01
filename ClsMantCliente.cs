using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ClsMantCliente
    {

        public void SubEjecutarMetodos()
        {

            string lStrConsultaSQL = "";
            DataSet lDtsDatos = new DataSet();
            int lIntCodigoError = 0;
                    
            lStrConsultaSQL = "INSERT INTO Cliente (CodigoCliente,NombreCliente) VALUES(1,'Francisco Valenzuela')";
            SubGuardarCliente(lStrConsultaSQL,ref lIntCodigoError);
            if (lIntCodigoError == 0){
                MessageBox.Show("Cliente guardado exitosamente.");              

            }else{
                MessageBox.Show("Ocurrio un error al guardar el cliente.");
            }

            lStrConsultaSQL = "UPDATE Cliente SET NombreCliente = 'Francisco Recinos' WHERE CodigoCliente = 1";
            SubModificarCliente(lStrConsultaSQL,ref lIntCodigoError);
            if (lIntCodigoError == 0){
                MessageBox.Show("Cliente modificado exitosamente.");              

            }else{
                MessageBox.Show("Ocurrio un error al modificar el cliente.");
            }

            lStrConsultaSQL = "DELETE Cliente WHERE CodigoCliente = 1";
            SubEliminarCliente(lStrConsultaSQL,ref lIntCodigoError);
            if (lIntCodigoError == 0)
            {
                MessageBox.Show("Cliente eliminado exitosamente.");

            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el cliente.");
            }

            lStrConsultaSQL = "SELECT * FROM CLIENTE";
            lDtsDatos = SubListarClientes(lStrConsultaSQL, ref lIntCodigoError);

        }


        //Escriba el código de una clase, en sintaxis C# que permita hacer conexiones a una base de datos cualquiera, y que devuelva en uno de sus métodos un Dataset al hacer un SELECT, 
        //y en otro de sus métodos el número de filas afectadas al ejecutar un INSERT, UPDATE o DELETE. 
        //También debe poder devolver el número de filas que devolvería un SELECT si se ejecutara.

        //INSERT
        public void SubGuardarCliente(string pStrQuery, ref int pIntCodigoError)
        {

            string lStrConnectionString = "Data Source=LocalHost;Initial Catalog=Local;Integrated Security=True";
            SqlConnection lObjConnection = new SqlConnection(@lStrConnectionString);
            //string lStrQuery = "INSERT INTO Cliente (CodigoCliente,NombreCliente) VALUES(1,'Francisco Valenzuela')";
            SqlCommand command = new SqlCommand(pStrQuery, lObjConnection);
            pIntCodigoError = 0;
            try
            {
                lObjConnection.Open();
                command.ExecuteNonQuery();
                pIntCodigoError = 0;
                Console.WriteLine("Cliente Guardado Exitosamente.");                
            }
            catch (SqlException e)
            {
                pIntCodigoError = -1;
                Console.WriteLine("Ocurrio un error al guardar el cliente: " + e.ToString());
            }
            finally
            {
                lObjConnection.Close();
            }

        }

        //UPDATE
        public void SubModificarCliente(string pStrQuery, ref int pIntCodigoError)
        {

            string lStrConnectionString = "Data Source=LocalHost;Initial Catalog=Local;Integrated Security=True";
            SqlConnection lObjConnection = new SqlConnection(@lStrConnectionString);
            //string lStrQuery = "UPDATE Cliente SET NombreCliente = 'Francisco Recinos' WHERE CodigoCliente = 1";
            SqlCommand command = new SqlCommand(pStrQuery, lObjConnection);
            pIntCodigoError = 0;
            try
            {
                lObjConnection.Open();
                command.ExecuteNonQuery();
                pIntCodigoError = 0;
                Console.WriteLine("Cliente Modificado Exitosamente.");

            }
            catch (SqlException e)
            {
                pIntCodigoError = -1;
                Console.WriteLine("Ocurrio un error al modificar el cliente: " + e.ToString());
            }
            finally
            {
                lObjConnection.Close();
            }

        }

        //DELETE
        public void SubEliminarCliente(string pStrQuery, ref int pIntCodigoError)
        {

            string lStrConnectionString = "Data Source=LocalHost;Initial Catalog=Local;Integrated Security=True";
            SqlConnection lObjConnection = new SqlConnection(@lStrConnectionString);
            //string lStrQuery = "DELETE Cliente WHERE CodigoCliente = 1";
            SqlCommand command = new SqlCommand(pStrQuery, lObjConnection);
            pIntCodigoError = 0;
            try
            {
                lObjConnection.Open();
                command.ExecuteNonQuery();
                pIntCodigoError = 0;
                Console.WriteLine("Cliente Eliminado Exitosamente.");

            }
            catch (SqlException e)
            {
                pIntCodigoError = -1;
                Console.WriteLine("Ocurrio un error al eliminar el cliente: " + e.ToString());
            }
            finally
            {
                lObjConnection.Close();
            }

        }

        //LISTAR
        public DataSet SubListarClientes(string pStrQuery, ref int pIntCodigoError)
        {
            string lStrConnectionString = "Data Source=LocalHost;Initial Catalog=Local;Integrated Security=True";
            DataSet lDtsDatos = new System.Data.DataSet();
            SqlConnection lObjConnection = new SqlConnection(@lStrConnectionString);
            //string lStrQuery = "SELECT * FROM Cliente";
            SqlCommand lObjCommand = new SqlCommand(pStrQuery, lObjConnection);
            SqlDataAdapter lObjAdapter = new SqlDataAdapter();
            pIntCodigoError = 0;
            try
            {
                lObjConnection.Open();
                lObjAdapter.SelectCommand = lObjCommand;
                lObjAdapter.Fill(lDtsDatos);
                pIntCodigoError = 0;               

            }
            catch (SqlException e)
            {
                pIntCodigoError = -1;
                Console.WriteLine("Ocurrio un error al consultar el listado de clientes " + e.ToString());
            }
            finally
            {
                lObjAdapter.Dispose();
                lObjCommand.Dispose();   
                lObjConnection.Close();
            }

            return lDtsDatos;
        }
        

    }
}
