using EYEService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Provider_PatientInfo : System.Web.UI.Page
{
    /// <summary>
    /// This method returns all the patients for a selected provider.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        EYEServiceClient serviceClient = new EYEServiceClient();
        var patients = serviceClient.getPatientsForProvider(4030);
        DataTable dt = new DataTable();
        dt.Columns.Add("FirstName", typeof(string));
        dt.Columns.Add("MiddleName", typeof(string));
        dt.Columns.Add("LastName", typeof(string));
        dt.Columns.Add("Gender", typeof(string));
        dt.Columns.Add("PatientId", typeof(int));
        DataRow dr = null;

        foreach(Patient patient in patients)
        {
            dr = dt.NewRow();
            dr["FirstName"] = patient.FirstName;
            dr["MiddleName"] = patient.MiddleName;
            dr["LastName"] = patient.LastName;
            dr["Gender"] = patient.Gender;
            dr["PatientId"] = patient.PatientId;
            dt.Rows.Add(dr);
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}