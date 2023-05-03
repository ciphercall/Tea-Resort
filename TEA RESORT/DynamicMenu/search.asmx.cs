using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using DynamicMenu.WebSitePanel.Interface;

namespace AlchemyAccounting
{
    /// <summary>
    /// Summary description for search
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]

    [Serializable()]

    public class search : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public string checkSession(string Session)
        {
            string sess = HttpContext.Current.Session["" + Session + ""].ToString();
            return sess;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListCompany(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();

            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand("SELECT COMPNM AS txt FROM ASL_COMPANY WHERE COMPNM LIKE @SearchText +'%' AND COMPID!='100' ORDER BY COMPNM", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListCostPoolName(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();

            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand("SELECT CATNM AS txt FROM GL_COSTPMST WHERE CATNM LIKE @SearchText +'%'", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }

        [WebMethod]

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListModuleName(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();

            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand("SELECT MODULENM AS txt FROM ASL_MENUMST WHERE MODULENM LIKE @SearchText +'%' ORDER BY MODULENM", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListMenuName(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string moduleId = "";
            if (HttpContext.Current.Session["ModuleId"] != null)
                moduleId = HttpContext.Current.Session["ModuleId"].ToString();
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand("SELECT MENUNM AS txt FROM ASL_MENU WHERE MODULEID='" + moduleId + "' AND MENUNM LIKE  @SearchText +'%' ORDER BY MENUNM", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListMenuNameByType(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string moduleId = "";
            string menuType = "";
            if (HttpContext.Current.Session["ModuleId"] != null && HttpContext.Current.Session["MenuType"] != null)
            {
                moduleId = HttpContext.Current.Session["ModuleId"].ToString();
                menuType = HttpContext.Current.Session["MenuType"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand("SELECT MENUNM AS txt FROM ASL_MENU WHERE MODULEID='" + moduleId + "' AND  MENUTP='" + menuType + "' AND MENUNM LIKE  @SearchText +'%' ORDER BY MENUNM", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompletionListOpeningBalanceEntryAccountNM(string term)
        {
            List<string> s = new List<string>();
            List<TowValue> lst = new List<TowValue>();
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand(@"SELECT ACCOUNTNM AS txt, ACCOUNTCD AS txtid FROM GL_ACCHART WHERE STATUSCD='P' and ACCOUNTNM LIKE  @SearchText +'%'", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", term);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    string result = obj_result["txt"].ToString().TrimEnd();
                    string id = obj_result["txtid"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return (List<TowValue>)q;
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListUserNameForMenuRole(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string usrid = "";
            string menuType = "";
            if (HttpContext.Current.Session["COMPANYID"] != null)
            {
                usrid = HttpContext.Current.Session["COMPANYID"].ToString();
                //menuType = HttpContext.Current.Session["MenuType"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand(@"SELECT DISTINCT ASL_USERCO.USERNM AS txt FROM ASL_USERCO INNER JOIN
ASL_ROLE ON ASL_USERCO.COMPID = ASL_ROLE.COMPID AND ASL_USERCO.USERID = ASL_ROLE.USERID 
WHERE ASL_USERCO.COMPID='" + usrid + "' AND ASL_USERCO.USERID!='" + usrid + "01' AND ASL_USERCO.USERNM LIKE @SearchText +'%' ORDER BY txt", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListCostPoolSingleVEdit(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            //if (uTp == "COMPADMIN")
            query = "GetCompletionListCostPool LIKE  @SearchText +'%'";
            //else
            //    query = "SELECT (GL_COSTP.COSTPNM + '|' + GL_COSTPMST.CATNM) AS txt FROM GL_COSTP INNER JOIN GL_COSTPMST ON GL_COSTP.CATID = GL_COSTPMST.CATID WHERE (GL_COSTP.COSTPNM + ' - ' + GL_COSTPMST.CATNM) LIKE  @SearchText +'%' AND GL_COSTP.CATID ='" + brCD + "'";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListMrecD(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            // if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%'";
            //else
            //    query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListMrecC(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            // if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            //else
            // query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListMpayD(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            //if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE  substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            // else
            //   query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE  substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListMpayC(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            //if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE  substring(ACCOUNTCD,1,7)  in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            //  else
            //    query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE  substring(ACCOUNTCD,1,7)  in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'  AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListJourD(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            // if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            // else
            //   query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListJourC(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            // if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%'";
            // else
            // query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListConD(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            // if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103')  and STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%'";
            // else
            // query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103')  and STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListConC(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            //if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%'";
            // else
            //   query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') and STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListDebit(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            string Transtype = HttpContext.Current.Session["Transtype"].ToString();
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            if (Transtype == "MREC")
            {
                // if (uTp == "COMPADMIN")
                //  {
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103')  AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
                //  }
                // else
                //  {
                //    query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103')  AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
                // }
            }

            else if (Transtype == "MPAY")
            {
                //if (uTp == "COMPADMIN")
                //{
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
                //}
                //else
                //{
                //    query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
                //}
            }
            else if (Transtype == "JOUR")
            {
                //if (uTp == "COMPADMIN")
                //{
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
                //}
                //else
                //{
                //    query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
                //}
            }
            else if (Transtype == "CONT")
            {
                //if (uTp == "COMPADMIN")
                //{
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
                //}
                //else
                //{
                //    query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
                //}
            }
            else
            {
                Transtype = "";
            }
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListCredit(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            string Transtype = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null && HttpContext.Current.Session["Transtype"] != "")
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
                Transtype = HttpContext.Current.Session["Transtype"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            if (Transtype == "MREC")
            {
                //if (uTp == "COMPADMIN")
                //{
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
                //}
                //else
                //{
                //    query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
                //}
            }

            else if (Transtype == "MPAY")
            {
                //if (uTp == "COMPADMIN")
                //{
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE  substring(ACCOUNTCD,1,7)  in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
                //    }
                //    else
                //    {
                //        query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE  substring(ACCOUNTCD,1,7)  in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
                //    }
            }
            else if (Transtype == "JOUR")
            {
                //if (uTp == "COMPADMIN")
                //{
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
                //}
                //else
                //{
                //    query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
                //}
            }
            else if (Transtype == "CONT")
            {
                //if (uTp == "COMPADMIN")
                //{
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
                //}
                //else
                //{
                //    query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
                //}
            }
            else
            {
                Transtype = "";
            }
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListCreditSingleVoucherEdit(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            string Transtype = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null && HttpContext.Current.Session["Transtype"] != "")
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
                Transtype = HttpContext.Current.Session["Transtype"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            if (Transtype == "MREC")
            {
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }

            else if (Transtype == "MPAY")
            {
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE  substring(ACCOUNTCD,1,7)  in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE   @SearchText +'%'";
            }
            else if (Transtype == "JOUR")
            {
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }
            else if (Transtype == "CONT")
            {
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }
            else
            {
                Transtype = "";
            }
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListDebitSingleVoucherEdit(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            string Transtype = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null && HttpContext.Current.Session["Transtype"] != "")
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
                Transtype = HttpContext.Current.Session["Transtype"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            if (Transtype == "MREC")
            {
                query = "SELECT ACCOUNTNM AS txt  FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103')  AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }

            else if (Transtype == "MPAY")
            {
                query = "SELECT ACCOUNTNM AS txt  FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE   @SearchText +'%'";
            }
            else if (Transtype == "JOUR")
            {
                query = "SELECT ACCOUNTNM AS txt  FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }
            else if (Transtype == "CONT")
            {
                query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%'";
            }
            else
            {
                Transtype = "";
            }
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompletionListCreditSingleVoucherNew(string txt, string transtype)
        {
            var query = "";
            List<TowValue> lst = new List<TowValue>();
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            if (transtype == "MREC")
            {
                query = "SELECT ACCOUNTNM, ACCOUNTCD FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }
            else if (transtype == "MPAY")
            {
                query = "SELECT ACCOUNTNM, ACCOUNTCD FROM GL_ACCHART WHERE  substring(ACCOUNTCD,1,7)  in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE   @SearchText +'%'";
            }
            else if (transtype == "JOUR")
            {
                query = "SELECT ACCOUNTNM, ACCOUNTCD FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }
            else if (transtype == "CONT")
            {
                query = "SELECT ACCOUNTNM, ACCOUNTCD FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }
            using (SqlCommand objSqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                objSqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader objResult = objSqlcommand.ExecuteReader();
                while (objResult.Read())
                {
                    string result = objResult["ACCOUNTNM"].ToString().TrimEnd();
                    string id = objResult["ACCOUNTCD"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return (List<TowValue>)q;
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompletionListtDebitSingleVoucherNew(string txt, string transtype)
        {
            var query = "";
            List<TowValue> lst = new List<TowValue>();
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            if (transtype == "MREC")
            {
                query = "SELECT ACCOUNTNM, ACCOUNTCD  FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103')  AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }
            else if (transtype == "MPAY")
            {
                query = "SELECT ACCOUNTNM, ACCOUNTCD  FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE   @SearchText +'%'";
            }
            else if (transtype == "JOUR")
            {
                query = "SELECT ACCOUNTNM, ACCOUNTCD  FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE  @SearchText +'%'";
            }
            else if (transtype == "CONT")
            {
                query = "SELECT ACCOUNTNM, ACCOUNTCD FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102','2020103') AND STATUSCD = 'P' and ACCOUNTNM LIKE @SearchText +'%'";
            }
            using (SqlCommand objSqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                objSqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader objResult = objSqlcommand.ExecuteReader();
                while (objResult.Read())
                {
                    string result = objResult["ACCOUNTNM"].ToString().TrimEnd();
                    string id = objResult["ACCOUNTCD"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return (List<TowValue>)q;
            }
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListLavelCode(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string lavelCd = "";
            if (HttpContext.Current.Session["LAVELCD"] != null)
                lavelCd = HttpContext.Current.Session["LAVELCD"].ToString();
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand("SELECT ACCOUNTNM+'| (L-'+convert(nvarchar,LEVELCD,103)+')'  AS txt FROM GL_ACCHART WHERE ACCOUNTCD like '" + lavelCd + "' and LEVELCD between 1 and 4 and ACCOUNTNM like  @SearchText +'%'", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListBankBook(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            //  if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) =('1020102') and STATUSCD='P' and ACCOUNTNM LIKE  @SearchText +'%'";
            // else
            //   query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) =('1020102') and STATUSCD='P' and ACCOUNTNM LIKE  @SearchText +'%'  AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListCashBook(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            // if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM As txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) =('1020101') and STATUSCD='P' and ACCOUNTNM LIKE  @SearchText +'%'";
            //  else
            //  query = "SELECT ACCOUNTNM As txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) =('1020101') and STATUSCD='P' and ACCOUNTNM LIKE   @SearchText +'%'  AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListLedgerBook(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            //   if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102') and STATUSCD='P' and ACCOUNTNM LIKE  @SearchText +'%'";
            //   else
            //   query = "SELECT ACCOUNTNM  AS txt FROM GL_ACCHART  AS txt WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102') and STATUSCD='P' and ACCOUNTNM LIKE @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListLedgerBookDepoDelear(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            //   if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM AS txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020201','1020202') and STATUSCD='P' and ACCOUNTNM LIKE  @SearchText +'%'";
            //   else
            //   query = "SELECT ACCOUNTNM  AS txt FROM GL_ACCHART  AS txt WHERE substring(ACCOUNTCD,1,7) not in ('1020101','1020102') and STATUSCD='P' and ACCOUNTNM LIKE @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompletionListLedgerBookGeneral(string term)
        {
            List<string> s = new List<string>();
            List<TowValue> lst = new List<TowValue>();
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand(@"SELECT ACCOUNTNM AS txt, ACCOUNTCD AS txtid FROM GL_ACCHART WHERE STATUSCD='P' and ACCOUNTNM LIKE  @SearchText +'%'", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", term);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    string result = obj_result["txt"].ToString().TrimEnd();
                    string id = obj_result["txtid"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return (List<TowValue>)q;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompletionListMoneyreceipts(string term)
        {
            List<string> s = new List<string>();
            List<TowValue> lst = new List<TowValue>();
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand obj_Sqlcommand = new SqlCommand(@"SELECT ACCOUNTNM AS txt, ACCOUNTCD AS txtid FROM GL_ACCHART WHERE LEVELCD='4' AND SUBSTRING(ACCOUNTCD,1,5) = '10202' AND ACCOUNTNM LIKE  @SearchText +'%'", conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", term);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    string result = obj_result["txt"].ToString().TrimEnd();
                    string id = obj_result["txtid"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return (List<TowValue>)q;
            }
        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompletionListNotesAccount(string txt, string lableCode)
        {
            List<TowValue> lst = new List<TowValue>();
            var query = "";
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            if (lableCode == "1")
            {
                query = "SELECT (ACCOUNTNM+' (L - '+convert(nvarchar(10),LEVELCD,103)+')') as txt, ACCOUNTCD  FROM GL_ACCHART WHERE ACCOUNTCD like '1%' and LEVELCD between 1 and 4 and ACCOUNTNM like @SearchText +'%'";
            }

            else if (lableCode == "2")
            {
                query = "SELECT (ACCOUNTNM+' (L - '+convert(nvarchar(10),LEVELCD,103)+')') as txt, ACCOUNTCD  FROM GL_ACCHART WHERE ACCOUNTCD like '2%' and LEVELCD between 1 and 4  and ACCOUNTNM like @SearchText +'%'";
            }
            else if (lableCode == "3")
            {
                query = "SELECT (ACCOUNTNM+' (L - '+convert(nvarchar(10),LEVELCD,103)+')') as txt, ACCOUNTCD  FROM GL_ACCHART WHERE ACCOUNTCD like '3%'  and LEVELCD between 1 and 4  and ACCOUNTNM like @SearchText +'%'";
            }
            else if (lableCode == "4")
            {
                query = "SELECT (ACCOUNTNM+' (L - '+convert(nvarchar(10),LEVELCD,103)+')') as txt, ACCOUNTCD  FROM GL_ACCHART WHERE ACCOUNTCD like '4%'  and LEVELCD between 1 and 4  and ACCOUNTNM like @SearchText +'%'";
            }
            else
            {
                lableCode = "";
            }
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    string result = obj_result["txt"].ToString().TrimEnd();
                    string id = obj_result["ACCOUNTCD"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return (List<TowValue>)q;
            }
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompletionListCostPool(string txt)
        {
            List<TowValue> lst = new List<TowValue>();
            string query = "";
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            query = "SELECT COSTPNM,COSTPID FROM GL_COSTP WHERE COSTPNM LIKE @SearchText +'%'";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    string result = obj_result["COSTPNM"].ToString().TrimEnd();
                    string id = obj_result["COSTPID"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return (List<TowValue>)q;
            }
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> GetCompletionListReceiptStatementSelected(string txt)
        {
            // your code to query the database goes here
            List<string> result = new List<string>();
            string uTp = "";
            string brCD = "";
            string query = "";
            if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
            {
                uTp = HttpContext.Current.Session["USERTYPE"].ToString();
                brCD = HttpContext.Current.Session["BrCD"].ToString();
            }
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            SqlCommand cmd = new SqlCommand();
            //  if (uTp == "COMPADMIN")
            query = "SELECT ACCOUNTNM As txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102') and STATUSCD='P' and ACCOUNTNM LIKE   @SearchText +'%'";
            // else
            //    query = "SELECT ACCOUNTNM As txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102') and STATUSCD='P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
            using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
                while (obj_result.Read())
                {
                    result.Add(obj_result["txt"].ToString().TrimEnd());
                }
            }
            return result;
        }







        //Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End
        //Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End
        //Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End
        //Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End//Accounts End


        /*--------------------------------------------------------------------------------------------------------------*/


        //WebSite Start  //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start 
        //WebSite Start  //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start 
        //WebSite Start  //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start 
        //WebSite Start  //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start 
        //WebSite Start  //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start //WebSite Start 


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<NewsFedd> ShowNewsFeed()
        {
            List<NewsFedd> lst = new List<NewsFedd>();
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            using (SqlCommand objSqlcommand = new SqlCommand(@"SELECT TOP 20   NEWSID, CONVERT(NVARCHAR, NEWSDT,103) NEWSDT, 
            NHEAD, NTITLE, DESCRIPTION, IMGPATH FROM RES_NEWS ORDER BY NEWSID DESC", conn))
            {
                conn.Open();
                SqlDataReader objResult = objSqlcommand.ExecuteReader();
                while (objResult.Read())
                {
                    string newsid = objResult["NEWSID"].ToString().TrimEnd();
                    string date = objResult["NEWSDT"].ToString().TrimEnd();
                    string head = objResult["NHEAD"].ToString().TrimEnd();
                    string title = objResult["NTITLE"].ToString().TrimEnd();
                    string description = objResult["DESCRIPTION"].ToString().TrimEnd();
                    string img = objResult["IMGPATH"].ToString().TrimEnd();
                    lst.Add(new NewsFedd { NewsId = newsid, Date = date, HeadName = head, Title = title, Descrition = description, FileName = img });
                }
                var q = lst.ToList();
                return q;
            }
        }


        //WebSite End  //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End 
        //WebSite End  //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End 
        //WebSite End  //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End 
        //WebSite End  //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End 
        //WebSite End  //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End //WebSite End 



        //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  
        //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  
        //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  
        //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  
        //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  //WebSite Input Start  


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompletionListRoomNM(string txt)
        {
            var lst = new List<TowValue>();
            string uTp = "";
            string brCD = "";
            string query;
           
            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            query = "SELECT ROOMNM as txt, ROOMID as txtid FROM RM_ROOM WHERE  ROOMNM LIKE @SearchText +'%'";

            using (var objSqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                objSqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader objResult = objSqlcommand.ExecuteReader();
                while (objResult.Read())
                {
                    string result = objResult["txt"].ToString().TrimEnd();
                    string id = objResult["txtid"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return q;
            }
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompletionListAlbamNM(string txt)
        {
            var lst = new List<TowValue>();
            string uTp = "";
            string brCD = "";
            string query;

            SqlConnection conn = new SqlConnection(DbFunctions.Connection);
            query = "SELECT DISTINCT ALBAMNM as txt, ALBAMID as txtid FROM RM_GALLERYIMG WHERE  ALBAMNM LIKE @SearchText +'%' ORDER BY ALBAMNM";

            using (var objSqlcommand = new SqlCommand(query, conn))
            {
                conn.Open();
                objSqlcommand.Parameters.AddWithValue("@SearchText", txt);
                SqlDataReader objResult = objSqlcommand.ExecuteReader();
                while (objResult.Read())
                {
                    string result = objResult["txt"].ToString().TrimEnd();
                    string id = objResult["txtid"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return q;
            }
        }








        //WebSite Input End   //WebSite Input End  //WebSite Input End  //WebSite Input End  //WebSite Input End  
        //WebSite Input End   //WebSite Input End  //WebSite Input End  //WebSite Input End  //WebSite Input End  
        //WebSite Input End   //WebSite Input End  //WebSite Input End  //WebSite Input End  //WebSite Input End  
        //WebSite Input End   //WebSite Input End  //WebSite Input End  //WebSite Input End  //WebSite Input End  
        //WebSite Input End   //WebSite Input End  //WebSite Input End  //WebSite Input End  //WebSite Input End  


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TowValue> GetCompaniesJson(string term)
        {
            var lst = new List<TowValue>();
            var conn = new SqlConnection(DbFunctions.Connection);
            using (var objSqlcommand = new SqlCommand(@"SELECT STORENM AS txt, STOREID as txtid FROM STK_STORE 
            WHERE STORENM LIKE  @SearchText +'%'", conn))
            {
                conn.Open();
                objSqlcommand.Parameters.AddWithValue("@SearchText", term);
                SqlDataReader objResult = objSqlcommand.ExecuteReader();
                while (objResult.Read())
                {
                    string result = objResult["txt"].ToString().TrimEnd();
                    string id = objResult["txtid"].ToString().TrimEnd();
                    lst.Add(new TowValue { value = id, label = result });
                }
                var q = lst.ToList();
                return q;
            }
        }



        //Website Website Website Website Website Website Website Website Website Website Website 
        //Website Website Website Website Website Website Website Website Website Website Website 
        //Website Website Website Website Website Website Website Website Website Website Website 
        //Website Website Website Website Website Website Website Website Website Website Website 


        //[WebMethod(EnableSession = true)]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public List<string> GetHeadImage()
        //{
        //    // your code to query the database goes here
        //    List<string> result = new List<string>();
        //    string imgUrl = "";
        //    string RoomId = "";
        //    string ImageID = "";
        //    if (HttpContext.Current.Session["USERTYPE"] != null && HttpContext.Current.Session["BrCD"] != null)
        //    {
        //        uTp = HttpContext.Current.Session["USERTYPE"].ToString();
        //        brCD = HttpContext.Current.Session["BrCD"].ToString();
        //    }
        //    SqlConnection conn = new SqlConnection(DbFunctions.Connection);
        //    SqlCommand cmd = new SqlCommand();
        //    //  if (uTp == "COMPADMIN")
        //    query = "SELECT ACCOUNTNM As txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102') and STATUSCD='P' and ACCOUNTNM LIKE   @SearchText +'%'";
        //    // else
        //    //    query = "SELECT ACCOUNTNM As txt FROM GL_ACCHART WHERE substring(ACCOUNTCD,1,7) in ('1020101','1020102') and STATUSCD='P' and ACCOUNTNM LIKE  @SearchText +'%' AND (BRANCHCD ='" + brCD + "' OR BRANCHCD IS NULL OR BRANCHCD ='')";
        //    using (SqlCommand obj_Sqlcommand = new SqlCommand(query, conn))
        //    {
        //        conn.Open();
        //        obj_Sqlcommand.Parameters.AddWithValue("@SearchText", txt);
        //        SqlDataReader obj_result = obj_Sqlcommand.ExecuteReader();
        //        while (obj_result.Read())
        //        {
        //            result.Add(obj_result["txt"].ToString().TrimEnd());
        //        }
        //    }
        //    return result;
        //}


    }
    public class NewsFeed
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Head { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
    public class TowValue
    {
        string _value;
        string _label;

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string label
        {
            get { return _label; }
            set { _label = value; }
        }

    }
}
