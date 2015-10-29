using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
// <System.Web.Script.Services.ScriptService()> _
[System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
[System.Web.Services.WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]
public class getCustomerDetail : System.Web.Services.WebService
{

    [WebMethod()]
    public DataTable DetailCustomer(string strCusID)
    {
        SqlConnection objConn = new SqlConnection();
        SqlCommand objCmd = new SqlCommand();
        SqlDataAdapter dtAdapter = new SqlDataAdapter();

        DataSet ds = new DataSet();
        DataTable dt = null;
        string strConnString = null;
        StringBuilder strSQL = new StringBuilder();

        strConnString = "Server=.\localhost;UID=moo;PASSWORD=1234;database=mydatabase;Max Pool Size=400;Connect Timeout=600;";

        strSQL.Append(" SELECT * FROM customer ");
        strSQL.Append(" WHERE [CustomerID] = '" + strCusID + "' ");

        objConn.ConnectionString = strConnString;
        var _with1 = objCmd;
        _with1.Connection = objConn;
        _with1.CommandText = strSQL.ToString();
        _with1.CommandType = CommandType.Text;
        dtAdapter.SelectCommand = objCmd;

        dtAdapter.Fill(ds);
        dt = ds.Tables[0];

        dtAdapter = null;
        objConn.Close();
        objConn = null;

        return dt;

    }

}