using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web.UI.HtmlControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Connect to dataset: 
        
        // Load devices from dataset

        // Display devices on home page:
        

        // Connect to Database and return list of services:
        database db = new database();
        DataTable returnedTable = new DataTable();

        returnedTable = db.returnServiceDT(); // Dictionary should be structured as "Name" and "URL"

        // Panel add controls :) 

        foreach (DataRow row in returnedTable.Rows)
        {
            string id = row["Id"].ToString();
            string name = row["Name"].ToString();
            string url = row["URL"].ToString();

            // Create the following items: 
            // Link: 
            HyperLink hl = new HyperLink();
            hl.Text = name;
            hl.NavigateUrl = url;
            // Button delete: 
            Button btnDel = new Button();
            btnDel.Text = "Delete";
            btnDel.CommandArgument = id;
            btnDel.Click += delClick;
            // Button modify: 
            Button btnMod = new Button();
            btnMod.Text = "Modify";
            btnMod.CommandArgument = id;
            btnMod.Click += modClick;

            // Create HTML formating: 
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("class", "col-md-4");
            div.InnerHtml = "<h2>"+name+"</h2> <p>Service information: </p>";


        //    Panel widgetPanel = new Panel();
          //  widgetPanel.Height = 250;
          //  widgetPanel.Width = 300;

            


            // Create a table to give me better formmatting options: 
            Table tbl = new Table();
            TableRow row1 = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            
            cell1.Controls.Add(hl);
            cell2.Controls.Add(btnDel);
            cell3.Controls.Add(btnMod);
       
            row1.Cells.Add(cell1);
            row1.Cells.Add(cell2);
            row1.Cells.Add(cell3);
            tbl.Rows.Add(row1);
            cell1.Width = 150;

           

            //  tbl.CellSpacing = 30;
            tbl.CellPadding = 3;
            
            div.Controls.Add(tbl);
            

            Panel1.Controls.Add(div);
        }
    }

    protected void delClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int id = Convert.ToInt32(button.CommandArgument);

        database db = new database();
        db.deleteService(id);
        Response.Redirect(Request.RawUrl);
    }
    protected void modClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Response.Redirect("/modService.aspx?field1="+button.CommandArgument);
    }


}