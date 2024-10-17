using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class candidatos_eliminados_dat
    {
        // Create an instance of the Persistence class to handle database connections.
        Persistence objPer = new Persistence();

        // Method to show deleted candidates from the database.
        public DataSet showCandidatosEliminados()
        {
            // Create a MySQL data adapter.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            // Create a DataSet to store the results of the query.
            DataSet objData = new DataSet();
            // Create a MySQL command to select deleted candidates using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            // Set the connection of the command using the openConnection() method from Persistence.
            objSelectCmd.Connection = objPer.openConnection();
            // Specify the name of the stored procedure to execute.
            objSelectCmd.CommandText = "spSelectCandidatosEliminados";
            // Indicate that this is a stored procedure.
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            // Set the select command of the data adapter.
            objAdapter.SelectCommand = objSelectCmd;
            // Fill the DataSet with the results of the query.
            objAdapter.Fill(objData);
            // Close the connection after obtaining the data.
            objPer.closeConnection();
            // Return the DataSet containing the deleted candidates.
            return objData;
        }

        // Method to save a deleted candidate.
        public bool saveCandidatoEliminado(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to insert a new deleted candidate using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertCandidatoEliminado"; // Name of the stored procedure
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the deleted candidate.
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = apellido;
            objSelectCmd.Parameters.Add("p_partido", MySqlDbType.VarString).Value = partido;
            objSelectCmd.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = fechaNacimiento;
            objSelectCmd.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = propuesta;

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

        // Method to update a deleted candidate.
        public bool updateCandidatoEliminado(int id, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to update a deleted candidate using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateCandidatoEliminado"; // Name of the stored procedure
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the deleted candidate.
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = id;
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = apellido;
            objSelectCmd.Parameters.Add("p_partido", MySqlDbType.VarString).Value = partido;
            objSelectCmd.Parameters.Add("p_fecha_nacimiento", MySqlDbType.VarString).Value = fechaNacimiento;
            objSelectCmd.Parameters.Add("p_propuesta", MySqlDbType.Text).Value = propuesta;

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

        // Method to delete a candidate from the deleted candidates table (if needed).
        public bool deleteCandidatoEliminado(int id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDeleteCandidatoEliminado"; // Name of the stored procedure
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
