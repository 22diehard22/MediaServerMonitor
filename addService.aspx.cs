using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack) // First load data ONLY 
        {
            // List of Supported services: 
            List<string> supportedServices = new List<String>();
            supportedServices.Add("Plex");
            supportedServices.Add("Sonarr");
            supportedServices.Add("Radarr");
            supportedServices.Add("Sabnzbd");

            foreach (var service in supportedServices)
            {
                dropServiceType.Items.Add(service);
            }
        }
        else // Any data that can be loaded each refresh. 
        {
            // First load should handle for now. 
        }
    }

    protected void btnTestConnection_Click(object sender, EventArgs e)
    {
        // Take url and test for network connectivity. 
       bool success = testConnection(tbUrl.Text.ToString());

        if (success == true)
        { btnTestConnection.Text = "SUCCESS"; }
        else{btnTestConnection.Text = "FAILED"; }
    }
    private bool testConnection(string address)
    {
        // Check if user forgot http:// if so try and correct it. 
        if (address.Contains("http://") || address.Contains("https://"))
        {
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
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        else
        {
            try
            {
                tbUrl.Text = @"http://" + address;
                WebRequest request = WebRequest.Create(@"http://" + address);
                WebResponse response = request.GetResponse();
                if (response == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    protected void btnTestAPI_Click(object sender, EventArgs e)
    {

        // Create connection to database:
        database databaseObject = new database();




        // Determine what drop down value is selected: 
        string ServiceType = dropServiceType.Text.ToString();
  
        if (ServiceType == "Sonarr")
        {
            // Pull a system status and return to label for now. -- Eventually do something with the data to prove its working. 
            sonarr Sonar = new sonarr();
            string rtnValue = Sonar.status(tbUrl.Text.ToString(), tbApiKey.Text.ToString());
            testJson.Text = rtnValue;
            // So far the following possibilities have returned:
            // 401 - unauthorized -- correct API key? 
            // Dead host -- Couldn't work with the client. 
            // Got back a JSON output of the system status.  -- Parse this for success? 
            downloadQueue.Text = Sonar.queue(tbUrl.Text.ToString(), tbApiKey.Text.ToString());

        }
        }





    //  btnTestAPI.Text = ServiceType;


    protected void btnAddService_Click(object sender, EventArgs e)
    {
        database db = new database();
        // Get data: 
        string ServiceType = dropServiceType.Text.ToString();

        if (ServiceType == "Sonarr")
        {
            // Pull a system status and return to label for now. -- Eventually do something with the data to prove its working. 
            sonarr Sonar = new sonarr();
            string rtnValue = Sonar.status(tbUrl.Text.ToString(), tbApiKey.Text.ToString());
            testJson.Text = rtnValue;
            downloadQueue.Text = Sonar.queue(tbUrl.Text.ToString(), tbApiKey.Text.ToString());
            db.addUserDefinedServices(ServiceType, tbUrl.Text.ToString(), tbApiKey.Text.ToString());
        }
        if (ServiceType == "Plex")
        {
            db.addUserDefinedServices(ServiceType, tbUrl.Text.ToString(), tbApiKey.Text.ToString());
        }
        if (ServiceType == "Radarr")
        {
            db.addUserDefinedServices(ServiceType, tbUrl.Text.ToString(), tbApiKey.Text.ToString());
        }
        if (ServiceType == "Sabnzbd")
        {
            db.addUserDefinedServices(ServiceType, tbUrl.Text.ToString(), tbApiKey.Text.ToString());
        }
        // TODO: Switch this to a switch statement. 






    }
}
