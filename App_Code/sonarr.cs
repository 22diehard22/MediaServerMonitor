using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Handle's adding in any communication between the client and Sonarr
/// Features: 
/// Status: Get a return back with the version information for Sonarr and that the API communication is possible.
/// Queue: Returns items in Sonarrs download queue. 
/// rootFolder: Each show has a directory that it stores items in, returns a JSON output of all the shows + directories + freespace left on directory.
///     -- Note: In some cases the freespace may be masked depending on how the user maps the network drive especially if they use junctions. 
///     
/// 
///API documentation: https://github.com/Sonarr/Sonarr/wiki/API
///
/// Note: Most functions have minimal error handling, they will just pass the error back and this is intentional -- I do not know how I may use the API calls in future expansions so I will handle the errors depending on the use case. 
/// </summary>
public class sonarr
{
    public string status(string address, string api)
        // Requires web address and API key. 
        // Expected return:
        // { "version": "2.0.0.5085", "buildTime": "2017-12-07T18:46:48Z", "isDebug": false, "isProduction": true, "isAdmin": true, "isUserInteractive": false, "startupPath": "C:\\ProgramData\\NzbDrone\\bin", "appData": "C:\\ProgramData\\NzbDrone", "osName": "Windows Server", "osVersion": "6.3.9600.0", "isMonoRuntime": false, "isMono": false, "isLinux": false, "isOsx": false, "isWindows": true, "branch": "master", "authentication": "none", "sqliteVersion": "3.8.7.2", "urlBase": "", "runtimeVersion": "4.5.1", "runtimeName": "dotNet" }
    {
        using (var webClient = new System.Net.WebClient())
        {
            //Attempt to connect to API -- If it fail's return failed.
            // http://192.168.1.73:8989/api/system/status?apikey=cd71f95019e6447a820fb3d8bd6fa8bb
            try
            {
                string fdn = address + @"/api/system/status?apikey=" + api;
                var json = webClient.DownloadString(fdn);
                return (json.ToString());
            }
            catch (Exception ex)
            {
                return (ex.ToString()); // Just pass the error back to the method that called it. Garbage in -- Garbage out let the controller figure it out. 
            }
        }
    }


    public string queue(string address, string api)
    {
        using (var webClient = new System.Net.WebClient())
        {
            // Demo URL: 
            // http://192.168.1.73:8989/api/queue?apikey=cd71f95019e6447a820fb3d8bd6fa8bb
            // Return's JSON array containing all of the TV shows that are being downloaded. 
            try
            {
                string fdn = address + @"/api/queue?apikey=" + api;
                var json = webClient.DownloadString(fdn);
                return (json.ToString());
            }
            catch (Exception ex)
            {
                return (ex.ToString()); // Just pass the error back to the method that called it. Garbage in -- Garbage out let the controller figure it out. 
            }
        }
    }

    public string rootFolder(string address, string api)
    {
        using (var webClient = new System.Net.WebClient())
        {
            // Demo URL: 
            // http://192.168.1.73:8989/api/rootfolder?apikey=cd71f95019e6447a820fb3d8bd6fa8bb
            // Return's JSON array containing all of the TV shows that are being downloaded. 
            try
            {
                string fdn = address + @"/api/rootfolder?apikey=" + api;
                var json = webClient.DownloadString(fdn);
                return (json.ToString());
            }
            catch (Exception ex)
            {
                return (ex.ToString()); // Just pass the error back to the method that called it. Garbage in -- Garbage out let the controller figure it out. 
            }
        }
    }
}
