using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAMP_Forms.Interface;
using System.Data.SqlClient;
using System.Data;

namespace DAMP_Forms.Data
{
    class dLogin
    {
        string strSQL = "select * from D_login_table";

        public bool GetData(ILogin objILogin)
        {
            try
            {
                DataTable dttemp = new DataTable();
                SqlDataAdapter SqlDtAdapter = new SqlDataAdapter();
                SqlConnection SqlConn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=DAMP_db;Integrated Security=True;Pooling=False");

                if (SqlConn.State == ConnectionState.Closed)
                {
                    SqlConn.Open();
                }

                strSQL = strSQL + " where user_id = '" + objILogin.user_id + "'";
                SqlDtAdapter = new SqlDataAdapter(strSQL, SqlConn);
                SqlDtAdapter.Fill(dttemp);

                if (SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }

                if (dttemp != null && dttemp.Rows.Count > 0)
                {
                    objILogin.dtTemp = dttemp;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
