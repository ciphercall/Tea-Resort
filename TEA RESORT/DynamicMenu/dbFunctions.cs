using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.UI.WebControls;

// ReSharper disable once CheckNamespace
namespace AlchemyAccounting
{
    public class DbFunctions
    {
        public static String Connection = ConfigurationManager.ConnectionStrings["Alchemy_Acc"].ToString();

        public static void DropDownAdd(DropDownList ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); list.Clear();
                //List.Add("Select");
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }

        public static void DropDownAddWithSelect(DropDownList ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); list.Clear();
                list.Add("--SELECT--");
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }

        public static void DropDownAddWithAll(DropDownList ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); list.Clear();
                list.Add("ALL");
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void EditableDropDownAdd(DropDownList ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader(); list.Clear();
                list.Add("Select");
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void ListAdd(ListBox ob, String sql)
        {
            List<String> list = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                list.Clear();
                while (rd.Read())
                {
                    list.Add(rd[0].ToString());
                }
                rd.Close();
                ob.Items.Clear();
                ob.Text = "";
                foreach (string item in list)
                {
                    ob.Items.Add(item);
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void TxtAdd(String sql, TextBox txtadd)
        {
            //String mystring = "";
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtadd.Text = reader[0].ToString();
                }
                con.Close();
                reader.Close();
            }
            catch
            {
                //ignore
            }
            //return List;
        }

        public static void LblAdd(String sql, Label lblAdd)
        {
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblAdd.Text = reader[0].ToString();
                }
                con.Close();
                reader.Close();
            }
            catch
            {
                //ignore
            }
        }
        public static string ExecuteCommand(String sql)
        {
            string data = "";
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                //ignore
            }
            return data;
        }
        public static string StringData(String sql)
        {
            string data = "";
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = reader[0].ToString();
                }
                con.Close();
                reader.Close();
            }
            catch
            {
                //ignore
            }
            return data;
        }
        public static string StringDataOneParameter(String sql, String parameterValue)
        {
            string data = "";
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PARAMETER", parameterValue);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = reader[0].ToString();
                }
                con.Close();
                reader.Close();
            }
            catch
            {
                //ignore
            }
            return data;
        }

        public static void GridViewAdd(GridView ob, String sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
            }
            catch
            {
                //ignore
            }
            //return List;
        }

        public static void RepeaterAdd(Repeater ob, String sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
            }
            catch
            {
                //ignore
            }
            //return List;
        }

        public static void FormViewAdd(FormView ob, String sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(table);
                ob.DataSource = table;
                ob.DataBind();
            }
            catch
            {
                //ignore
            }
            //return List;
        }

        public static string Dayformat(DateTime dt)
        {
            string mydate = dt.ToString("dd/MM/yyyy");
            return mydate;
        }
        public static string DayformatHifen(DateTime dt)
        {
            string mydate = dt.ToString("dd-MMM-yyyy");
            return mydate;
        }
        public static string TimeFormat(DateTime tt)
        {
            string myTime = tt.ToString("HH:mm:ss");
            return myTime;
        }
        public static string Monformat(DateTime mm)
        {
            string mymonth = mm.ToString("MMM");
            return mymonth;
        }
        public static DateTime Timezone(DateTime datetime)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime printDate = TimeZoneInfo.ConvertTime(datetime, timeZoneInfo);
            return printDate;
        }

        public static string IpAddress()
        {
#pragma warning disable 618
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
#pragma warning restore 618
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            return ipAddress.ToString();
        }

        public static string UserPc()
        {
            return Dns.GetHostName();
        }

        public static bool FieldCheck(string[] field)
        {
            bool checkResult = false;
            foreach (var data in field)
            {
                if (data == "")
                {
                    checkResult = false;
                    break;
                }
                else
                    checkResult = true;
            }
            return checkResult;
        }

        public static string FbProfilePicture(string userId)
        {
            string userid = userId;
            string fbusername = StringData("SELECT FBPIMG FROM ASL_USERCO WHERE USERID='" + userid + "'");
            var fbImageLink = "http:/" + "/graph.facebook.com/" + fbusername + "/picture?type=large";

            return fbImageLink;
        }

        public static string SliptText(string text, char sumbol)
        {
            string returnText = "";
            string searchPar = text;
            int splitter = searchPar.IndexOf(sumbol);
            if (splitter != -1)
            {
                string[] lineSplit = searchPar.Split(sumbol);

                returnText = lineSplit[1];
            }
            return returnText;
        }

        public static string SliptText(string text, char sumbol, int indexNo)
        {
            string returnText = "";
            string searchPar = text;
            int splitter = searchPar.IndexOf(sumbol);
            if (splitter != -1)
            {
                string[] lineSplit = searchPar.Split(sumbol);

                returnText = lineSplit[indexNo];
            }
            return returnText;
        }
        public static void DropDownAddSelectTextWithValue(DropDownList ob, String sql)
        {
            List<String> listName = new List<string>();
            List<String> listValue = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                listName.Clear();
                listValue.Clear();
                listName.Add("--SELECT--");
                listValue.Add("--SELECT--");
                while (rd.Read())
                {
                    listName.Add(rd[0].ToString());
                    listValue.Add(rd[1].ToString());
                }
                rd.Close();
                ob.Items.Clear();

                ob.Text = "";
                for (int i = 0; i < listName.Count; i++)
                {
                    ob.Items.Add(new ListItem(listName[i].ToUpper(), listValue[i]));
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void DropDownAddTextWithValue(DropDownList ob, String sql)
        {
            List<String> listName = new List<string>();
            List<String> listValue = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                listName.Clear();
                listValue.Clear();
                //List.Add("Select");
                while (rd.Read())
                {
                    listName.Add(rd[0].ToString());
                    listValue.Add(rd[1].ToString());
                }
                rd.Close();
                ob.Items.Clear();

                ob.Text = "";
                for (int i = 0; i < listName.Count; i++)
                {
                    ob.Items.Add(new ListItem(listName[i].ToUpper(), listValue[i]));
                }
            }
            catch
            {
                //ignore
            }
        }
        public static void DropDownAddAllTextWithValue(DropDownList ob, String sql)
        {
            List<String> listName = new List<string>();
            List<String> listValue = new List<string>();
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                listName.Clear();
                listValue.Clear();
                listName.Add("ALL");
                listValue.Add("ALL");
                while (rd.Read())
                {
                    listName.Add(rd[0].ToString());
                    listValue.Add(rd[1].ToString());
                }
                rd.Close();
                ob.Items.Clear();

                ob.Text = "";
                for (int i = 0; i < listName.Count; i++)
                {
                    ob.Items.Add(new ListItem(listName[i].ToUpper(), listValue[i]));
                }
            }
            catch
            {
                //ignore
            }
        }
    }
}
