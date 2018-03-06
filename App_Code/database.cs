﻿using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Collections.Specialized;
using System.Data;


/// <summary>
/// Summary description for database
/// </summary>
/// 
public class database
{
    public SQLiteConnection myConnection;

    public database()
    {
        // Create the database: 
        // If a user ever has a corrupt database they can simply rebuild it by deleting the database file. 
        myConnection = new SQLiteConnection("Data Source=database.sqlite3");

        if (!File.Exists("./database.sqlite3"))
        {
            SQLiteConnection.CreateFile("database.sqlite3");
            System.Diagnostics.Debug.WriteLine("Alert: Database file did not exist, Created.");
            // Create tables and stuff here: 
            using (var connection = new SQLiteConnection("data source=database.sqlite3.db"))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open(); // Create the following tables: 
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS[UserDefinedServices](
                       [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                       [Name] NVARCHAR(2048)  NULL,
                       [URL] NVCHAR(2048) NULL,
                       [apiKey] NVCHAR(2048) NULL)";
                    command.ExecuteNonQuery();
                }
                connection.Close(); // All opperations should be completed for the initilization of the database.
            }
            createServiceStatusTable(); // Creation code for our service Status table. 
            createStatusCodeTable(); // Contains the status codes for the project
        }
    }

    // Add data to userDefinedServices

    public string addUserDefinedServices(string name, string url, string apiKey)
    {
        string x = "";

        using (var connection = new SQLiteConnection("data source=database.sqlite3.db"))
        {
            using (var command = new SQLiteCommand(connection))
            {
                connection.Open(); // Create the following tables: 
                command.CommandText = @"INSERT INTO [UserDefinedServices] (Name,URL,apiKey) VALUES ('" + name + "','" + url + "','" + apiKey + "')";
                command.ExecuteNonQuery();
            }
            connection.Close(); // All opperations should be completed for the initilization of the database.
        }

        return (x);
    }

    // Return data for service list:
    public DataTable returnServiceDT()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Id", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("URL", typeof(string));

        using (var connection = new SQLiteConnection("data source=database.sqlite3.db"))
        {
            using (var command = new SQLiteCommand(connection))
            {
                connection.Open(); // Create the following tables: 
                command.CommandText = @"Select * FROM [UserDefinedServices]";
                command.ExecuteNonQuery();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        table.Rows.Add(reader["id"], reader["Name"].ToString(), reader["URL"].ToString());
                    }
                    return (table);
                }
            }
        }
    }

    public string[] returnServiceInfo(int id, string type = "default") 
    {
        switch (type)
        {   
            case "address":
                {
                    string[] rtnArray = new string[1];
                    using (var connection = new SQLiteConnection("data source=database.sqlite3.db"))
                    {
                        using (var command = new SQLiteCommand(connection))
                        {
                            connection.Open(); // Create the following tables: 
                            command.CommandText = @"Select * FROM [UserDefinedServices] where id =" + id;
                            command.ExecuteNonQuery();

                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    rtnArray[0] = reader["URL"].ToString();
                                }
                                return (rtnArray);
                               
                            }
                        }
                    }
                }
            default: // Return all options in array if type is not defined.  "Default" should also go here. 
                {
                    string[] rtnArray = new string[3];
                    using (var connection = new SQLiteConnection("data source=database.sqlite3.db"))
                    {
                        using (var command = new SQLiteCommand(connection))
                        {
                            connection.Open(); // Create the following tables: 
                            command.CommandText = @"Select * FROM [UserDefinedServices] where id =" + id;
                            command.ExecuteNonQuery();

                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    rtnArray[0] = reader["Name"].ToString();
                                    rtnArray[1] = reader["URL"].ToString(); //pingWebHost(int id) relies on this array position to work. 
                                    rtnArray[2] = reader["apiKey"].ToString();
                                }
                                return (rtnArray);
                            }
                        }
                    }
                }

        }

    }


    public void deleteService(int id)
    {
        // delete from UserDefinedServices where id = 1
        using (var connection = new SQLiteConnection("data source=database.sqlite3.db"))
        using (var command = new SQLiteCommand(connection))
        {
            connection.Open(); // Create the following tables: 
            command.CommandText = @"delete from UserDefinedServices where id = "+id;
            command.ExecuteNonQuery();
        }
    }


    public void createServiceStatusTable()
    {
        using (var connection = new SQLiteConnection("data source=database.sqlite3.db"))
        {
            using (var command = new SQLiteCommand(connection))
            {
                connection.Open(); // Create the following tables: 
                command.CommandText = @"CREATE TABLE IF NOT EXISTS[serviceStatus](
                       [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                       [serviceFK] INTEGER NOT NULL,
                       [statusFK] INTEGER NOT NULL,
                       [eventTime] DATE  NULL)";
                command.ExecuteNonQuery();
            }
            connection.Close(); // All opperations should be completed for the initilization of the database.
        }
    }

    public void createStatusCodeTable()
    {
        using (var connection = new SQLiteConnection("data source=database.sqlite3.db"))
        {
            using (var command = new SQLiteCommand(connection))
            {
                connection.Open(); // Create the following tables: 
                command.CommandText = @"CREATE TABLE IF NOT EXISTS[StatusReason](
                       [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                       [Name] NVARCHAR(2048)  NULL,
                       [Description] NVARCHAR(2048)  NULL)";
                command.ExecuteNonQuery();


                // Create a dictionary for all the status codes. 
                Dictionary<string, string> statusCodes = new Dictionary<string, string>();
                statusCodes.Add("pingSuccess", "System replied succesfully to ping request");
                statusCodes.Add("pingFail", "System failed to reply to ping request");


                foreach(KeyValuePair<string, string> entry in statusCodes)
                {
                    // Populate table with data: 
                    command.CommandText = @"INSERT INTO [StatusReason] (Name, Description) VALUES('"+entry.Key+ "','" + entry.Value + "')";
                    command.ExecuteNonQuery();
                }


            



            }
            connection.Close(); // All opperations should be completed for the initilization of the database.
        }
    }





}
