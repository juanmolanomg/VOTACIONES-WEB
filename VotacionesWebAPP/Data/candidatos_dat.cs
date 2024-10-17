using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class candidatos_dat
    {
        Persistence objPer = new Persistence();

        // Method to show all candidates
        public DataSet showCandidatos()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectCandidatos"; // Stored procedure to get all candidates
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Method to save a new candidate
        public bool saveCandidato(string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertCandidato"; // Stored procedure for inserting a candidate
            objSelectCmd.CommandType = CommandType.StoredProcedure;
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

        // Method to update a candidate
        public bool updateCandidato(int idCandidato, string nombre, string apellido, string partido, string fechaNacimiento, string propuesta)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateCandidato"; // Stored procedure for updating a candidate
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = idCandidato;
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

        // Method to delete a candidate
        public bool deleteCandidato(int idCandidato)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDeleteCandidato"; // Stored procedure for deleting a candidate
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = idCandidato;

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