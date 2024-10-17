<<<<<<<< HEAD:usuarios_dat.cs
﻿using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class usuarios_dat
    {
        // Create an instance of the Persistence class to handle database connections.
        Persistence objPer = new Persistence();

        // Method to show users from the database.
        public DataSet showUsuarios()
        {
            // Create a MySQL data adapter.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            // Create a DataSet to store the results of the query.
            DataSet objData = new DataSet();
            // Create a MySQL command to select users using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            // Set the connection of the command using the openConnection() method from Persistence.
            objSelectCmd.Connection = objPer.openConnection();
            // Specify the name of the stored procedure to execute.
            objSelectCmd.CommandText = "spSelectUsuarios"; // Adjust this to your stored procedure name.
            // Indicate that this is a stored procedure.
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            // Set the select command of the data adapter.
            objAdapter.SelectCommand = objSelectCmd;
            // Fill the DataSet with the results of the query.
            objAdapter.Fill(objData);
            // Close the connection after obtaining the data.
            objPer.closeConnection();
            // Return the DataSet containing the users.
            return objData;
        }

        // Method to save a new user.
        public bool saveUsuario(string correo, string contrasena)
        {
            // Initialize a variable to indicate if the operation was successful.
            bool executed = false;
            int row;

            // Create a MySQL command to insert a new user using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertUsuario"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the user.
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

        // Method to update a user.
        public bool updateUsuario(int id, string correo, string contrasena)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to update a user using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateUsuario"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the user.
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

        // Method to delete a user.
        public bool deleteUsuario(int id)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to delete a user using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDeleteUsuario"; // Adjust this to your stored procedure name.
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
========
﻿using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class tblUsuarios
    {
        // Create an instance of the Persistence class to handle database connections.
        Persistence objPer = new Persistence();

        // Method to show users from the database.
        public DataSet showUsuarios()
        {
            // Create a MySQL data adapter.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            // Create a DataSet to store the results of the query.
            DataSet objData = new DataSet();
            // Create a MySQL command to select users using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            // Set the connection of the command using the openConnection() method from Persistence.
            objSelectCmd.Connection = objPer.openConnection();
            // Specify the name of the stored procedure to execute.
            objSelectCmd.CommandText = "spSelectUsuarios"; // Adjust this to your stored procedure name.
            // Indicate that this is a stored procedure.
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            // Set the select command of the data adapter.
            objAdapter.SelectCommand = objSelectCmd;
            // Fill the DataSet with the results of the query.
            objAdapter.Fill(objData);
            // Close the connection after obtaining the data.
            objPer.closeConnection();
            // Return the DataSet containing the users.
            return objData;
        }

        // Method to save a new user.
        public bool saveUsuario(string correo, string contrasena)
        {
            // Initialize a variable to indicate if the operation was successful.
            bool executed = false;
            int row;

            // Create a MySQL command to insert a new user using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertUsuario"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the user.
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

        // Method to update a user.
        public bool updateUsuario(int id, string correo, string contrasena)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to update a user using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateUsuario"; // Adjust this to your stored procedure name.
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Add parameters to the command to pass the values of the user.
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

        // Method to delete a user.
        public bool deleteUsuario(int id)
        {
            bool executed = false;
            int row;

            // Create a MySQL command to delete a user using a stored procedure.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spDeleteUsuario"; // Adjust this to your stored procedure name.
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
>>>>>>>> e244a01c20dc7b723a5831a5af7aa6f689681acc:tblUsuarios.cs
