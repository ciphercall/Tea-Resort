using System;
using System.Data;
using System.Data.SqlClient;
using AlchemyAccounting;
using DynamicMenu.WebSitePanel.Interface;

namespace DynamicMenu.WebSitePanel.DataAccess
{
    public class WebSiteDataAccess
    {
        SqlConnection con;
        SqlCommand cmd;

        public WebSiteDataAccess()
        {
            con = new SqlConnection(DbFunctions.Connection);
            cmd = new SqlCommand("", con);
        }
        


        public string INSERT_RES_NEWS(WebSiteInterface ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO RES_NEWS(NEWSID, NEWSDT, NHEAD, NTITLE, DESCRIPTION, IMGPATH, USERPC, 
                INSUSERID, INSTIME, INSIPNO, INSLTUDE) Values 
				(@NEWSID, @NEWSDT, @NHEAD, @NTITLE, @DESCRIPTION, @IMGPATH, @USERPC, @INSUSERID, @INSTIME, @INSIPNO, @INSLTUDE)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@NEWSID", SqlDbType.NVarChar).Value = ob.NewsId;
                cmd.Parameters.Add("@NHEAD", SqlDbType.NVarChar).Value = ob.HeadName;
                cmd.Parameters.Add("@NEWSDT", SqlDbType.SmallDateTime).Value = ob.InTimeInsUpd;
                cmd.Parameters.Add("@NTITLE", SqlDbType.NVarChar).Value = ob.Title;
                cmd.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar).Value = ob.Descrition;
                cmd.Parameters.Add("@IMGPATH", SqlDbType.NVarChar).Value = ob.FileName;


                cmd.Parameters.Add("@USERPC", SqlDbType.NVarChar).Value = ob.UserPcInsUpd;
                cmd.Parameters.Add("@INSUSERID", SqlDbType.BigInt).Value = ob.UserIdInsUpd;
                cmd.Parameters.Add("@INSTIME", SqlDbType.SmallDateTime).Value = ob.InTimeInsUpd;
                cmd.Parameters.Add("@INSIPNO", SqlDbType.NVarChar).Value = ob.IpAddressInsUpd;
                cmd.Parameters.Add("@INSLTUDE", SqlDbType.NVarChar).Value = ob.LotiLenInsUpd;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }
        public string INSERT_RES_Slide(WebSiteInterface ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO RES_SLIDE(SL, IMGPATH) Values 
				(@ID, @IMGPATH)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ob.ImageId;
                cmd.Parameters.Add("@IMGPATH", SqlDbType.NVarChar).Value = ob.FileName;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }

        public string DELETE_ASL_(WebSiteInterface ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"DELETE FROM ASL_BRANCH WHERE BRANCHCD=@BRANCHCD AND COMPID=@COMPID ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@COMPID", SqlDbType.BigInt).Value = ob.CompanyId;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }


        public string UPDATE_ASL_(WebSiteInterface ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE ASL_BRANCH SET BRANCHNM=@BRANCHNM,BRANCHID=@BRANCHID,CONTACTNO=@CONTACTNO,
                    ADDRESS=@ADDRESS,
                    EMAILID=@EMAILID,STATUS=@STATUS,UPDUSERID=@UPDUSERID,UPDTIME=@UPDTIME,UPDIPNO=@UPDIPNO,
                    UPDLTUDE=@UPDLTUDE WHERE BRANCHCD=@BRANCHCD AND COMPID=@COMPID ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@COMPID", SqlDbType.BigInt).Value = ob.CompanyId;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }



        public string INSERT_RoomWiseImage(WebSiteInterface ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO RM_ROOMIMG(ROOMID,IMGID,IMGURL,SL) Values 
				(@ROOMID, @IMGID, @IMGURL,@SL)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ROOMID", SqlDbType.Int).Value = ob.RoomId;
                cmd.Parameters.Add("@IMGID", SqlDbType.Int).Value = ob.ImgID;
                cmd.Parameters.Add("@IMGURL", SqlDbType.NVarChar).Value = ob.FileName;
                cmd.Parameters.Add("@SL", SqlDbType.NVarChar).Value = ob.sl;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }


        public string INSERT_AlbamWiseImage(WebSiteInterface ob)
        {
            string s = "";
            SqlTransaction tran = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                tran = con.BeginTransaction();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO RM_GALLERYIMG(ALBAMID,ALBAMNM,IMGID,IMGURL,SL) Values 
				(@ALBAMID, @ALBAMNM, @IMGID, @IMGURL,@SL)";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ALBAMID", SqlDbType.Int).Value = ob.AlbamId;
                cmd.Parameters.Add("@IMGID", SqlDbType.Int).Value = ob.ImgID;
                cmd.Parameters.Add("@IMGURL", SqlDbType.NVarChar).Value = ob.FileName;
                cmd.Parameters.Add("@ALBAMNM", SqlDbType.NVarChar).Value = ob.AlbamNm;
                cmd.Parameters.Add("@SL", SqlDbType.NVarChar).Value = ob.sl;

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                if (con.State != ConnectionState.Closed)
                    con.Close();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                s = ex.Message;
            }
            return s;
        }



    }
}