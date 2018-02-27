using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data;

/// <summary>
/// Summary description for serviceMonitor
/// </summary>
public class serviceMonitor
{
    Dictionary<string, int> serviceList = new Dictionary<string, int>();


    public serviceMonitor()
    {
        



    }


    public void getServices() // Should be running periodically. 
    {
        // Connect to Database and return list of services:
        database db = new database();
        DataTable returnedTable = new DataTable();

        foreach (DataRow row in returnedTable.Rows)
        {
            string id = row["Id"].ToString();
            string name = row["Name"].ToString();
           // string url = row["URL"].ToString(); // Might not be relevant at this point. 

            try
            {
                serviceList.Add(name, Convert.ToInt32(id));
                // Since we havent error'ed it should be safe to start a thread to monitor this device. 

            }
            catch (ArgumentException)
            {
                // Should just skip it on failure, I am assuming only "Duplicates" will error.  -- hehe wait till my assumption is wrong.. 
            }




        }




        }







}