using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["field1"]); // These values are passed in one page load. 
        database db = new database();
        string[] arr = new string[3];
        arr = db.returnServiceInfo(id);
        tbName.Text = arr[0];
        tbURL.Text = arr[1];
        tbApiKey.Text = arr[2];
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}