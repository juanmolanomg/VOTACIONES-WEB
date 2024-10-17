<<<<<<<< HEAD:votos_dat.cs
﻿using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class votos_dat
    {
        // Create an instance of the Persistence class to manage the database connection.
        Persistence objPer = new Persistence();

        // Method to show votes from the database.
        public DataSet showVotes()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();

            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectVotes"; // Stored procedure for selecting votes
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();

            return objData;
        }

        // Method to save a new vote
        public bool saveVote(string _nombre, string _apellido, string _cedula, string _opcion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertVote"; // Stored procedure for inserting a vote
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Adding parameters for the vote
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = _cedula;
            objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = _opcion;

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

        // Method to update a vote
        public bool updateVote(int _id, string _nombre, string _apellido, string _cedula, string _opcion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateVote"; // Stored procedure for updating a vote
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Adding parameters for the vote
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = _cedula;
            objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = _opcion;

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
========
﻿using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class tbl_votos
    {
        // Create an instance of the Persistence class to manage the database connection.
        Persistence objPer = new Persistence();

        // Method to show votes from the database.
        public DataSet showVotes()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();

            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectVotes"; // Stored procedure for selecting votes
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();

            return objData;
        }

        // Method to save a new vote
        public bool saveVote(string _nombre, string _apellido, string _cedula, string _opcion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertVote"; // Stored procedure for inserting a vote
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Adding parameters for the vote
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = _cedula;
            objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = _opcion;

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

        // Method to update a vote
        public bool updateVote(int _id, string _nombre, string _apellido, string _cedula, string _opcion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateVote"; // Stored procedure for updating a vote
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Adding parameters for the vote
            objSelectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("p_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("p_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("p_cedula", MySqlDbType.VarString).Value = _cedula;
            objSelectCmd.Parameters.Add("p_opcion", MySqlDbType.VarString).Value = _opcion;

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
>>>>>>>> e244a01c20dc7b723a5831a5af7aa6f689681acc:tbl_votos.cs
