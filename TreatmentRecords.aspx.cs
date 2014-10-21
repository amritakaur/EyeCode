using EYEService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Provider_TreatmentRecords : System.Web.UI.Page
{
    /// <summary>
    /// This method returns the treatment record for the selected patient.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPatient.Text = Request.QueryString["FirstName"] + " " + Request.QueryString["LastName"];
        EYEServiceClient serviceClient = new EYEServiceClient();
        var records = serviceClient.getPatientTreatmentRecord(Convert.ToInt32(Request.QueryString["Id"]));

        DataTable dt = new DataTable();
        dt.Columns.Add("DateConducted", typeof(string));
        dt.Columns.Add("SensitivityToLight", typeof(string));
        dt.Columns.Add("DislikeTo3DMovies", typeof(string));
        dt.Columns.Add("UsesGlasses", typeof(string));
        dt.Columns.Add("EyeFatigue", typeof(string));
        dt.Columns.Add("ReadingForgetfulness", typeof(string));
        dt.Columns.Add("ReadSlowly", typeof(string));
        dt.Columns.Add("BlurredVision", typeof(string));
        dt.Columns.Add("DoubleVision", typeof(string));
        dt.Columns.Add("JumpingLines", typeof(string));
        dt.Columns.Add("HurtingEyes", typeof(string));
        dt.Columns.Add("SoreEyes", typeof(string));
        dt.Columns.Add("Focus", typeof(string));
        DataRow dr = null;

        foreach (ScreeningTest test in records)
        {
            dr = dt.NewRow();
            dr["DateConducted"] = test.DateConducted;
            dr["SensitivityToLight"] = test.SensitivityToLight;
            dr["DislikeTo3DMovies"] = test.DislikeTo3DMovies;
            dr["UsesGlasses"] = test.UsesGlasses;
            dr["EyeFatigue"] = test.EyeFatigue;
            dr["ReadingForgetfulness"] = test.ReadingForgetfulness;
            dr["ReadSlowly"] = test.ReadSlowly;
            dr["BlurredVision"] = test.BlurredVision;
            dr["DoubleVision"] = test.DoubleVision;
            dr["JumpingLines"] = test.JumpingLines;
            dr["HurtingEyes"] = test.HurtingEyes;
            dr["SoreEyes"] = test.SoreEyes;
            dr["Focus"] = test.Focus;
            dt.Rows.Add(dr);
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}