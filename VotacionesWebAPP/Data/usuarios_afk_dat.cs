using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class usuarios_afk_dat
    {
        // Create an instance of the Persistence class to handle database connections.
        Persistence objPer = new Persistence();

        // Method to show records from the Usuarios_afk table.
        public DataSet showUsuariosAfk()
        {
            // Create a MySQL data adapter.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            // Create a DataSet to store the results of the query.
            DataSet objData = new DataSet();
            // Create a MySQL command to select records using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            // Set the connection of the command using the openConnection() method from Persistence.
            objSelectCmd.Connection = objPer.openConnection();
            // Specify the name of the stored procedure to execute.
            objSelectCmd.CommandText = "spSelectUsuariosAfk"; // Adjust this to your stored procedure name.
            // Indicate that this is a stored procedure.
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            // Set the select command of the data adapter.
            objAdapter.SelectCommand = objSelectCmd;
            // Fill the DataSet with the results of the query.
            objAdapter.Fill(objData);
            // Close the connection after obtaining the data.
            objPer.closeConnection();
            // Return the DataSet containing the records.
            return objData;
        }

        // Method to save a new record in the Usuarios_afk table.
        public bool saveUsuarioAfk(string correo, string contrasena)
        {
            // Initialize a variable to indicate if the operation was successful.
            bool executed = false;
            int row;

            // Create a MySQL command to insert a new record using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertUsuariosAfk"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the record.
            objSelectCmd.Parameters.Add("p_correo", MySqlDbType.VarString).Value = correo;
            objSelectCmd.Parameters.Add("p_contrasena", MySqlDbType.VarString).Value = contrasena;

            try
            {
                // Execute the command and get the number of affected rows.
                row = objSelectCmd.ExecuteNonQuery();
                // If one row is inserted successfully, set executed to true.
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                // Log the error if an exception occurs during command execution.
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            // Return the value of executed to indicate if the operation was successful.
            return executed;
        }

        // Method to update a record in the Usuarios_afk table.
        public bool updateUsuarioAfk(int id, string correo, string contrasena)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to update a record using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateUsuariosAfk"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the record.
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objSelectCmd.Parameters.Add("p_correo", MySqlDbType.VarString).Value = correo;
            objSelectCmd.Parameters.Add("p_contrasena", MySqlDbType.VarString).Value = contrasena;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Method to delete a record from the Usuarios_afk table.
        public bool deleteUsuarioAfk(int id)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to delete a record using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDeleteUsuariosAfk"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}
