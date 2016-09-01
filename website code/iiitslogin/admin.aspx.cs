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

public partial class admin : System.Web.UI.Page
{

    string strConnString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
    string str, str1, str2, str3,str4,str5,str6,str7,str8,str9,str10,str11,str12,str13,str14;
    SqlCommand com, com1, com2, com3,com4,com5,com6,com7,com8,com9,com10,com11,com12,com13,com14;
    protected void Page_Load(object sender, EventArgs e)
    {
        //displaying name of faculty based on his login id.....
        lb1.Text = "<b><font color=Black size=3px>" + "Welcome " + "</font>" + "<b><font color=Black size=3px>" + Session["name"] + " " + "</font>";
        
    }

    string strConnString1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

    SqlDataAdapter sqlda,sqlda1;
    
    DataTable dt,dt1;
    int RowCount;


    // button submit clicked for selecting student details or datewisewise
    protected void btn_click_att_admin(object sender, EventArgs e)
    {
        //if selected value is datewise
        if (ddl_att_admin.SelectedItem.Value == "1")
        {
            ddl_date.Visible = true;
            btndate_admin.Visible = true;
            txtusersearch.Visible = false;
            btn_search.Visible = false;
            lblstudentmode.Visible = false;
            lblstudentmode1.Visible = false;
            ddl_studentcourse.Visible = false;
            txtdatesearch.Visible = true;
            lbldatemode.Visible = true;
            lbldatemode1.Visible = true;

            grdviewstudentwise.Visible = false;

            //this displays the courses taught by the faculty who logged in..in the drop down list....
            SqlConnection con1 = new SqlConnection(strConnString1);
            str1 = "select coursename from facultycourses where facultyname='" + Session["name"] + "'";
            com1 = new SqlCommand(str1, con1);
            SqlDataAdapter da1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            ddl_date.DataTextField = ds1.Tables[0].Columns["coursename"].ToString();
            ddl_date.DataSource = ds1.Tables[0];
            ddl_date.DataBind();
           

        }

        //if item selected is student search...
        if (ddl_att_admin.SelectedItem.Value == "3")
        {
            ddl_date.Visible = false;
            btndate_admin.Visible = false;
            grd_datewise.Visible = false;
            txtusersearch.Visible = true;
            btn_search.Visible = true;
            lblstudentmode.Visible = true;
            lblstudentmode1.Visible = true;
            ddl_studentcourse.Visible = true;
            lbldatemode.Visible = false;
            lbldatemode1.Visible = false;
            txtdatesearch.Visible = false;
                       
            grdviewstudentwise.Visible = true;
            
            //displays courses taught by faculty in the dropdown list.....
            SqlConnection con2 = new SqlConnection(strConnString1);
            str2 = "select coursename from facultycourses where facultyname='" + Session["name"] + "'";
            com2 = new SqlCommand(str2, con2);
            SqlDataAdapter da2 = new SqlDataAdapter(com2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            ddl_studentcourse.DataTextField = ds2.Tables[0].Columns["coursename"].ToString();
            ddl_studentcourse.DataSource = ds2.Tables[0];
            ddl_studentcourse.DataBind();


        }
    }

   //click event of button when course is selected from dropdown list...
   //click event for datewise attendance details....
    protected void btndate_admin_selected(object sender, EventArgs e)
    {
        //date search in table and displaying data based on date...
        if (ddl_date.SelectedItem.Text == "ITWS II")
        {
            
            String date1 = txtdatesearch.Text.Trim();
            
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
            
                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;


                    //this select query displays information based on date searched...
                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    //this select query gives the total present people in class..based on valid attendance count....
                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "' ";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();
                    
                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Fundamentals of Communication")
        {
           String date1 = txtdatesearch.Text.Trim();
           
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
           
                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17  group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    

                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);
                    

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();

                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Maths II")
        {
            String date1 = txtdatesearch.Text.Trim();
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
           
                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9  group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();

                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Maths III")
        {
            String date1 = txtdatesearch.Text.Trim();
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
           
                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;

                    
                    
                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();

                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Data Structures")
        {
            String date1 = txtdatesearch.Text.Trim();
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
           
                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();

                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Basic Electronic Circuits")
        {
            String date1 = txtdatesearch.Text.Trim();
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
           
                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();
                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Computer Organization")
        {
            String date1 = txtdatesearch.Text.Trim();
            
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

                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();
                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Computer Architecture")
        {
            String date1 = txtdatesearch.Text.Trim();
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

                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();

                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Humanities[Communication 2]")
        {
            String date1 = txtdatesearch.Text.Trim();
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

                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();

                }

            }
        }
        if (ddl_date.SelectedItem.Text == "Humanities[Communication 2 + Thinking Skills]")
        {


            String date1 = txtdatesearch.Text.Trim();
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

                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();

                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Computer and Communication Networks")
        {
            String date1 = txtdatesearch.Text.Trim();
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

                if (date1 == txtdatesearch.Text)
                {
                    Session["doa"] = date1;



                    SqlConnection con6 = new SqlConnection(strConnString);
                    str6 = "Select * from (Select username,firstname,lastname, convert(nvarchar(10), checktime,20) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18  group by username,firstname,lastname,checktime) checkintime where doa= '" + Session["doa"] + "'";
                    com6 = new SqlCommand(str6, con6);
                    SqlDataAdapter da6 = new SqlDataAdapter(com6);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6);


                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18  group by username,firstname,lastname,checktime) as sum1 where doa= '" + Session["doa"] + "'";
                    com5 = new SqlCommand(str5, con5);
                    SqlDataAdapter da5 = new SqlDataAdapter(com5);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5);



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();
                }

            }

        }
        if (ddl_date.SelectedItem.Text == "Economic Fundamentals")
        {

            String date1 = txtdatesearch.Text.Trim();
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

                if (date1 == txtdatesearch.Text)
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



                    grd_datewise.Columns[0].FooterText = "TOTAL STRENGTH:";
                    grd_datewise.Columns[1].FooterText = "60";
                    grd_datewise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grd_datewise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grd_datewise.Visible = true;



                    grd_datewise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grd_datewise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / (60) * 100).ToString("N2"));
                    grd_datewise.DataSource = ds6;
                    grd_datewise.DataBind();




                }

            }

        }
    }

    //click event of button when student search is selected from dropdown list....
    protected void btn_search_selected(object sender, EventArgs e)
    {
        if (ddl_studentcourse.SelectedItem.Text == "ITWS II")
        {
            string rollno = txtusersearch.Text.Trim();
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

                if (rollno == txtusersearch.Text)
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;

                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }

        }
        if (ddl_studentcourse.SelectedItem.Text == "Fundamentals of Communication")
        {
            string rollno = txtusersearch.Text.Trim();
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

                if (rollno == txtusersearch.Text)
                {
                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17 and username='" + Session["username"] + "'  group by username,firstname,lastname,checktime) as sum1";
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;

                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }


                }

            
        if (ddl_studentcourse.SelectedItem.Text == "Maths II")
        {
            string rollno = txtusersearch.Text.Trim();
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

                if (rollno == txtusersearch.Text)
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;

                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }

        }
        if (ddl_studentcourse.SelectedItem.Text == "Maths III")
        {
            string rollno = txtusersearch.Text.Trim();
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

                if (rollno == txtusersearch.Text)
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;

                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }

        }
        if (ddl_studentcourse.SelectedItem.Text == "Data Structures")
        {
            string rollno = txtusersearch.Text.Trim();
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

                if (rollno == txtusersearch.Text)
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;

                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }

        }
        if (ddl_studentcourse.SelectedItem.Text == "Basic Electronic Circuits")
        {
            string rollno = txtusersearch.Text.Trim();
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

                if (rollno == txtusersearch.Text)
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;

                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }

        }
        if (ddl_studentcourse.SelectedItem.Text == "Computer Organization")
        {
            string rollno = txtusersearch.Text.Trim();
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
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch.Text)
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;

                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }

        }
        if (ddl_studentcourse.SelectedItem.Text == "Computer Architecture")
        {
            string rollno = txtusersearch.Text.Trim();
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

                if (rollno == txtusersearch.Text)
                {
                    Session["username"] = rollno;

                    SqlConnection con4 = new SqlConnection(strConnString);
                    str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
                    com4 = new SqlCommand(str4, con4);
                    SqlDataAdapter da4 = new SqlDataAdapter(com4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);

                    SqlConnection con5 = new SqlConnection(strConnString);
                    str5 = "Select sum(cou) as sum1 from (Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16 and username='" + Session["username"] + "'  group by username,firstname,lastname,checktime) as sum1";
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;

                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }


        }
        if (ddl_studentcourse.SelectedItem.Text == "Humanities[Communication 2]")
        {
            string rollno = txtusersearch.Text.Trim();
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

                if (rollno == txtusersearch.Text)
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;

                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }
        }
        if (ddl_studentcourse.SelectedItem.Text == "Humanities[Communication 2 + Thinking Skills]")
        {
            

            string rollno = txtusersearch.Text.Trim();
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

                if (rollno == txtusersearch.Text)
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;


                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }

        }
        if (ddl_studentcourse.SelectedItem.Text == "Computer and Communication Networks")
        {
            string rollno = txtusersearch.Text.Trim();
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
                rollno = dt.Rows[i]["UserName"].ToString();

                if (rollno == txtusersearch.Text)
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

                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";

                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";

                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    grdviewstudentwise.Visible = true;


                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                }

            }

        }
        if (ddl_studentcourse.SelectedItem.Text == "Economic Fundamentals")
        {
            
            string rollno = txtusersearch.Text.Trim();
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
                         
                if (rollno == txtusersearch.Text)
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
                    
                    grdviewstudentwise.Columns[0].FooterText = "TOTAL DAYS:";
                    grdviewstudentwise.Columns[1].FooterText = ds3.Tables[0].Rows[0]["totaldays"].ToString();
                    grdviewstudentwise.Columns[2].FooterText = "TOTAL PRESENT:";
                    
                    grdviewstudentwise.Columns[4].FooterText = "PERCENTAGE:";
                    com2 = new SqlCommand(str2, con);
                    SqlDataAdapter da2 = new SqlDataAdapter(com2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    
                   
                    grdviewstudentwise.Visible = true;
                    grdviewstudentwise.Columns[3].FooterText = ds5.Tables[0].Rows[0]["sum1"].ToString();
                    grdviewstudentwise.Columns[5].FooterText = ((Convert.ToDouble(ds5.Tables[0].Rows[0]["sum1"]) / Convert.ToDouble(ds3.Tables[0].Rows[0]["totaldays"]) * 100).ToString("N2"));
                    grdviewstudentwise.DataSource = ds4;
                    grdviewstudentwise.DataBind();

                   
                   
                    
                }
                
            }

        }
    }
    












    protected void btn_adminlogout_click(object sender, EventArgs e)
    {
        Session.Abandon();

        Session.Contents.RemoveAll();

        System.Web.Security.FormsAuthentication.SignOut();

        Response.Redirect("index.aspx");



    }
  
}