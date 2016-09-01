using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

//superadmin is same as admin page...except he sees all the courses list...ad select from it...
public partial class superadmin : System.Web.UI.Page
{
    string strConnString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
    string str, str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12, str13, str14;
    SqlCommand com, com1, com2, com3, com4, com5, com6, com7, com8, com9, com10, com11, com12, com13, com14;
    protected void Page_Load(object sender, EventArgs e)
    {   
        //displaying admin name based on login....
        lb11.Text = "<b><font color=Black size=3px>" + "Welcome " + "</font>" + "<b><font color=Black size=3px>" + "ADMIN" + " " + "</font>";

    }

    string strConnString1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

    SqlDataAdapter sqlda, sqlda1;

    DataTable dt, dt1;
    int RowCount;


    // button submit clicked for selecting coursewise or student details or programwise
    protected void btn_click_att_admin1(object sender, EventArgs e)
    {
        if (ddl_att_admin1.SelectedItem.Value == "1")
        {
            ddl_course1.Visible = true;
            btn_course_admin1.Visible = true;
            txtusersearch1.Visible = false;
            btn_search1.Visible = false;
            lblroll1.Visible = false;
            ddl_studentcourse1.Visible = false;
            ddldatewise1.Visible = false;
            btndatewise1.Visible = false;
            txtdatewise1.Visible = false;
            lbladminmode1.Visible = true;
            lbladminmode2.Visible = false;
            lbladminmode4.Visible = false;
            lbladminmode6.Visible = false;
            
            grdviewstudentwise1.Visible = false;


        }
        if (ddl_att_admin1.SelectedItem.Value == "2")
        {
            ddl_course1.Visible = false;
            btn_course_admin1.Visible = false;
            grd_coursewise1.Visible = false;
            txtusersearch1.Visible = false;
            btn_search1.Visible = false;
            lblroll1.Visible = false;
            ddl_studentcourse1.Visible = false;
            lbladminmode1.Visible = false;
            ddldatewise1.Visible = true;
            txtdatewise1.Visible = true;
            btndatewise1.Visible = true;
            lbladminmode2.Visible = false;
            lbladminmode4.Visible = true;
            lbladminmode6.Visible = true;
        }




        if (ddl_att_admin1.SelectedItem.Value == "3")
        {
            ddl_course1.Visible = false;
            btn_course_admin1.Visible = false;
            grd_coursewise1.Visible = false;
            txtusersearch1.Visible = true;
            btn_search1.Visible = true;
            lblroll1.Visible = true;
            ddl_studentcourse1.Visible = true;
            ddldatewise1.Visible = false;
            btndatewise1.Visible = false;
            txtdatewise1.Visible = false;
            lbladminmode1.Visible = false;
            lbladminmode2.Visible = true;
            lbladminmode4.Visible = false;
            lbladminmode6.Visible = false;
            
            grdviewstudentwise1.Visible = true;


        }
    }

    //button submit event when coursewise was selected and course was selected
    protected void btn_course_admin_selected1(object sender, EventArgs e)
    {
        if (ddl_course1.SelectedItem.Text == "ITWS II")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con2 = new SqlConnection(strConnString);
            str2 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13 group by username,firstname,lastname,checktime";
            com2 = new SqlCommand(str2, con2);
            SqlDataAdapter da2 = new SqlDataAdapter(com2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            grd_coursewise1.DataSource = ds2;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Fundamentals of Communication")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con3 = new SqlConnection(strConnString);
            str3 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17 group by username,firstname,lastname,checktime";
            com3 = new SqlCommand(str3, con3);
            SqlDataAdapter da3 = new SqlDataAdapter(com3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            grd_coursewise1.DataSource = ds3;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Maths II")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9 group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            grd_coursewise1.DataSource = ds4;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Maths III")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con5 = new SqlConnection(strConnString);
            str5 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15 group by username,firstname,lastname,checktime";
            com5 = new SqlCommand(str5, con5);
            SqlDataAdapter da5 = new SqlDataAdapter(com5);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            grd_coursewise1.DataSource = ds5;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Data Structures")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con6 = new SqlConnection(strConnString);
            str6 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10 group by username,firstname,lastname,checktime";
            com6 = new SqlCommand(str6, con6);
            SqlDataAdapter da6 = new SqlDataAdapter(com6);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            grd_coursewise1.DataSource = ds6;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Basic Electronic Circuits")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con7 = new SqlConnection(strConnString);
            str7 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11 group by username,firstname,lastname,checktime";
            com7 = new SqlCommand(str7, con7);
            SqlDataAdapter da7 = new SqlDataAdapter(com7);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
            grd_coursewise1.DataSource = ds7;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Computer Organization")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con8 = new SqlConnection(strConnString);
            str8 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12 group by username,firstname,lastname,checktime";
            com8 = new SqlCommand(str8, con8);
            SqlDataAdapter da8 = new SqlDataAdapter(com8);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            grd_coursewise1.DataSource = ds8;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Computer Architecture")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con8 = new SqlConnection(strConnString);
            str8 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16 group by username,firstname,lastname,checktime";
            com8 = new SqlCommand(str8, con8);
            SqlDataAdapter da8 = new SqlDataAdapter(com8);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            grd_coursewise1.DataSource = ds8;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Humanities[Communication 2]")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con10 = new SqlConnection(strConnString);
            str10 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14 group by username,firstname,lastname,checktime";
            com10 = new SqlCommand(str10, con10);
            SqlDataAdapter da10 = new SqlDataAdapter(com10);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            grd_coursewise1.DataSource = ds10;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Humanities[Communication 2 + Thinking Skills]")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con11 = new SqlConnection(strConnString);
            str11 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20 group by username,firstname,lastname,checktime";
            com11 = new SqlCommand(str11, con11);
            SqlDataAdapter da11 = new SqlDataAdapter(com11);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11);
            grd_coursewise1.DataSource = ds11;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Computer and Communication Networks")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con12 = new SqlConnection(strConnString);
            str12 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18 group by username,firstname,lastname,checktime";
            com12 = new SqlCommand(str12, con12);
            SqlDataAdapter da12 = new SqlDataAdapter(com12);
            DataSet ds12 = new DataSet();
            da12.Fill(ds12);
            grd_coursewise1.DataSource = ds12;
            grd_coursewise1.DataBind();

        }
        if (ddl_course1.SelectedItem.Text == "Economic Fundamentals")
        {
            grd_coursewise1.Visible = true;
            SqlConnection con13 = new SqlConnection(strConnString);
            str13 = "SELECT userlogin.username, userlogin.firstname, userlogin.lastname, convert(date,checktime) as dat, convert(time,checktime) as tim,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou FROM CHECKINOUT INNER JOIN userlogin ON CHECKINOUT.USERID = userlogin.userid where DATEPART(HOUR,CHECKTIME)>=18 and DATEPART(HOUR,CHECKTIME)<19 group by username,firstname,lastname,checktime";
            com13 = new SqlCommand(str13, con13);
            SqlDataAdapter da13 = new SqlDataAdapter(com13);
            DataSet ds13 = new DataSet();
            da13.Fill(ds13);
            grd_coursewise1.DataSource = ds13;
            grd_coursewise1.DataBind();

        }
    }
    protected void btn_search_selected1(object sender, EventArgs e)
    {
        if (ddl_studentcourse1.SelectedItem.Text == "ITWS II")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {
                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13 and username='" + Session["username"] + "'  group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);


                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;

                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();

                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));

                   
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Fundamentals of Communication")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {
                    Session["username"] = rollno;



                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);


                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;

                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();
                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Maths II")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {
                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);

                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;

                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Maths III")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {

                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);

                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;

                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Data Structures")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {
                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;

                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds4.Tables[0].Rows[0]["cou"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Basic Electronic Circuits")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {

                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);

                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;

                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Computer Organization")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["username"].ToString();

                if (rollno == txtusersearch1.Text)
                {

                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12 and username='" + Session["username"] + "'  group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);


                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;

                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Computer Architecture")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {

                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);


                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";


                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;

                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds4.Tables[0].Rows[0]["cou"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Humanities[Communication 2]")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {
                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);

                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;

                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }
        }
        if (ddl_studentcourse1.SelectedItem.Text == "Humanities[Communication 2 + Thinking Skills]")
        {


            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {
                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);

                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;


                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Computer and Communication Networks")
        {
            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["username"].ToString();

                if (rollno == txtusersearch1.Text)
                {

                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);




                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;


                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddl_studentcourse1.SelectedItem.Text == "Economic Fundamentals")
        {

            string rollno = txtusersearch1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=18 and DATEPART(HOUR,CHECKTIME)<19 group by username,firstname,lastname,checktime";

            com2 = new SqlCommand(str2);

            sqlda = new SqlDataAdapter(com2.CommandText, con);

            dt = new DataTable();

            sqlda.Fill(dt);

            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch1.Text)
                {


                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=18 and DATEPART(HOUR,CHECKTIME)<19 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=18 and DATEPART(HOUR,CHECKTIME)<19 and username='" + Session["username"] + "' group by username,firstname,lastname,checktime) as sum1";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);

                    SqlConnection con3 = new SqlConnection(strConnString);
                    str3 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
                    com3 = new SqlCommand(str3, con3);
                    SqlDataAdapter da3 = new SqlDataAdapter(com3);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);

                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise1.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";
                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);


                    grdviewstudentwise1.Visible = true;
                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds4;
                    grdviewstudentwise1.DataBind();



                }

            }

        }
    }


    protected void btndatewise1_click(object sender, EventArgs e)
    {
        if (ddldatewise1.SelectedItem.Text == "ITWS II")
        {
             String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Fundamentals of Communication")
        {

            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Maths II")
        {
            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();


                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Maths III")
        {
            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();


                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Data Structures")
        {
            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10 group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10 group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Basic Electronic Circuits")
        {
            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();


                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Computer Organization")
        {
            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();


                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Computer Architecture")
        {
            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();


                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Humanities[Communication 2]")
        {
            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();


                }

            }
        }
        if (ddldatewise1.SelectedItem.Text == "Humanities[Communication 2 + Thinking Skills]")
        {


            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Computer and Communication Networks")
        {
            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();

                }

            }

        }
        if (ddldatewise1.SelectedItem.Text == "Economic Fundamentals")
        {

            String date1 = txtdatewise1.Text.Trim();
            SqlConnection con = new SqlConnection(strConnString1);
            con.Open();
            str2 = "Select username,firstname,lastname, convert(varchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=18 and DATEPART(HOUR,CHECKTIME)<19 group by username,firstname,lastname,checktime ";
            com2 = new SqlCommand(str2);
            sqlda = new SqlDataAdapter(com2.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                date1 = dt.Rows[i]["doa"].ToString();

                if (date1 == txtdatewise1.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=18 and DATEPART(HOUR,CHECKTIME)<19  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=18 and DATEPART(HOUR,CHECKTIME)<19  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grdviewstudentwise1.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grdviewstudentwise1.Columns[1].FooterText = "60";
                    grdviewstudentwise1.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise1.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise1.Visible = true;



                    grdviewstudentwise1.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise1.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grdviewstudentwise1.DataSource = ds6;
                    grdviewstudentwise1.DataBind();



                }

            }

        }
    }










    protected void btn_adminlogout_click1(object sender, EventArgs e)
    {
        Session.Abandon();

        Session.Contents.RemoveAll();

        System.Web.Security.FormsAuthentication.SignOut();

        Response.Redirect("index.aspx");



    }

}