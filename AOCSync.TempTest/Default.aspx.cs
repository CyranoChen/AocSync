using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AOCSync.TempTest
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string resultInfo = string.Empty;
            //int i = 0;

            DataTable dt = DataAccesss.FQSColumn.GetAOCFQSColumns();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    #region Generate AOCFQS Columns

                    //resultInfo += string.Format("[{0}], ", dr["name"]);
                    //resultInfo += string.Format("{0}, ", dr["name"].ToString().ToUpper());
                    //resultInfo += string.Format("@{0}, ", dr["name"].ToString().ToLower());
                    //resultInfo += string.Format("string {0}, ", dr["name"].ToString().ToLower());

                    #endregion

                    #region Generate AOCFQS DataAccess Parameter

                    //resultInfo += string.Format("para[{1}] = new SqlParameter(\"@{0}\", {0});\r\n", dr["name"].ToString().ToLower(), i);
                    //i++;

                    #endregion

                    #region Generate AOCFQS DataAccess UpdateSQL

                    //resultInfo += string.Format("[{0}] = @{1}, ", dr["name"], dr["name"].ToString().ToLower());

                    #endregion

                    #region Generate AOCFQS Entity Propty

                    //resultInfo += string.Format("public string {0} {{ set; get; }}\r\n", dr["name"].ToString().ToUpper());

                    #endregion

                    #region Generate AOCFQS Entity Inital

                    //resultInfo += string.Format("{0} = dr[\"{1}\"].ToString();\r\n", dr["name"].ToString().ToUpper(), dr["name"]);

                    #endregion

                    #region Generate AOCFQS BL Transfer

                    resultInfo += string.Format("aocData.{0} = fqsData.{0};\r\n", dr["name"].ToString().ToUpper());

                    #endregion

                }
            }

            tbResultInfo.Text = resultInfo;
        }
    }
}