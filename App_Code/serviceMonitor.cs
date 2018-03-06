using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using System.Net;

/// <summary>
/// Summary description for serviceMonitor
/// </summary>
public class serviceMonitor
{
    Dictionary<string, int> serviceList = new Dictionary<string, int>();
    DataTable returnedTable = new DataTable(); // Global to class. 

    public serviceMonitor()
    {
        getServices(); // Get a list of all of the services that are running. 
        
    }



    public void watchService(int id)
    {
        // Get service information from database. 
        
        

    }



    public void getServices() // Should be running periodically. 
    {
        // Connect to Database and return list of services:
        database db = new database();
        returnedTable = db.returnServiceDT();


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


    public bool pingWebHost(int id)
    {
        //addService.aspx.cs class should have "vetted" the data is "Valid -- This method is intentionally only responsible for checking known-good data.

        database db = new database();



        // Obtain Address of site based on id: 
        string address = db.returnServiceInfo(id, "address")[0];


        try
        {
            WebRequest request = WebRequest.Create(address);
            WebResponse response = request.GetResponse();
            if (response == null)
            {
                return false;
            }
            else
            {
                // Clause is true: -- Gather information to push to database. 
                string date = DateTime.Now.ToString();


                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
}