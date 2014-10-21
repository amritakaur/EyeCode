using EYEService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Provider_ParentGuardianInfo : System.Web.UI.Page
{
    /// <summary>
    /// This method returns the family information for the patient selected on the previous page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPatient.Text = Request.QueryString["FirstName"] + " " + Request.QueryString["LastName"];
        EYEServiceClient serviceClient = new EYEServiceClient();

        // Gets the family information for the patient.
        var family = serviceClient.getFamilyForPatient(Convert.ToInt32(Request.QueryString["Id"]));

        DataTable dt = new DataTable();
        dt.Columns.Add("FirstName", typeof(string));
        dt.Columns.Add("MiddleName", typeof(string));
        dt.Columns.Add("LastName", typeof(string));
        dt.Columns.Add("Phone", typeof(string));
        DataRow dr = null;

        foreach (User user in family)
        {
            dr = dt.NewRow();
            dr["FirstName"] = user.FirstName;
            dr["MiddleName"] = user.MiddleName;
            dr["LastName"] = user.LastName;
            dr["Phone"] = user.Phone;
            dt.Rows.Add(dr);
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}