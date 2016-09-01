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



public partial class Details : System.Web.UI.Page
{   

    //creating connection strings

    string strConnString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
    string str,str1,str2,str3,str4,str5,str6,str7,str8,str9,str10,str11,str12,str13,str14,str15,str16,str17,str18,str19,str20,str21,str22,str23,str24,str25,str26,str27;
    SqlCommand com,com1,com2,com3,com4,com5,com6,com7,com8,com9,com10,com11,com12,com13,com14,com15,com16,com17,com18,com19,com20,com21,com22,com23,com24,com25,com26,com27;
    protected void Page_Load(object sender, EventArgs e)
    {

            //this is used to display name of the user who logged in by displaying the firstname and lastname stored in the session of index.aspx.cs.....
            lb1.Text = "<b><font color=Black size=3px>" + "Welcome " + "</font>" + "<b><font color=Black size=3px>" + Session["FirstName"] + " "+ Session["Lastname"] + "</font>";
            

            //displaying attendance of course1
           
           //displaying registered courses by comparing rollno stored in regcourses table and username stored in session and ordering by courseid in ascending order
            SqlConnection con12 = new SqlConnection(strConnString);
            str12 = "select courseid,coursename,insrtuctor,credits from regcourses where Rollno='" + Session["Username"] + "' order by courseid";
            com12 = new SqlCommand(str12, con12);
            SqlDataAdapter da12 = new SqlDataAdapter(com12);
            DataSet ds12 = new DataSet();
            da12.Fill(ds12);
            //displaying the fields like courseid,coursename etc. fetched from the select query above......
            lbl_cid5.Text = ds12.Tables[0].Rows[0]["courseid"].ToString();
            lbl_cname5.Text = ds12.Tables[0].Rows[0]["coursename"].ToString();
            lbl_iname5.Text = ds12.Tables[0].Rows[0]["insrtuctor"].ToString();
            lbl_credits5.Text = ds12.Tables[0].Rows[0]["credits"].ToString();
            lbl_cid6.Text = ds12.Tables[0].Rows[1]["Courseid"].ToString();
            lbl_cname6.Text = ds12.Tables[0].Rows[1]["coursename"].ToString();
            lbl_iname6.Text = ds12.Tables[0].Rows[1]["insrtuctor"].ToString();
            lbl_credits6.Text = ds12.Tables[0].Rows[1]["Credits"].ToString();
            lbl_cid7.Text = ds12.Tables[0].Rows[2]["courseid"].ToString();
            lbl_cname7.Text = ds12.Tables[0].Rows[2]["Coursename"].ToString();
            lbl_iname7.Text = ds12.Tables[0].Rows[2]["insrtuctor"].ToString();
            lbl_credits7.Text = ds12.Tables[0].Rows[2]["credits"].ToString();
            lbl_cid8.Text = ds12.Tables[0].Rows[3]["Courseid"].ToString();
            lbl_cname8.Text = ds12.Tables[0].Rows[3]["coursename"].ToString();
            lbl_iname8.Text = ds12.Tables[0].Rows[3]["insrtuctor"].ToString();
            lbl_credits8.Text = ds12.Tables[0].Rows[3]["credits"].ToString();
            lbl_cid9.Text = ds12.Tables[0].Rows[4]["courseid"].ToString();
            lbl_cname9.Text = ds12.Tables[0].Rows[4]["CourseName"].ToString();
            lbl_iname9.Text = ds12.Tables[0].Rows[4]["insrtuctor"].ToString();
            lbl_credits9.Text = ds12.Tables[0].Rows[4]["Credits"].ToString();
            lbl_cid10.Text = ds12.Tables[0].Rows[5]["courseid"].ToString();
            lbl_cname10.Text = ds12.Tables[0].Rows[5]["CourseName"].ToString();
            lbl_iname10.Text = ds12.Tables[0].Rows[5]["insrtuctor"].ToString();
            lbl_credits10.Text = ds12.Tables[0].Rows[5]["Credits"].ToString();



        
            
            


        

    }


    //button click event where the dropdown list item is selected and accordingly things are displayed
    protected void btn_click_att1(object sender, EventArgs e)
    {
       
        //if the item selected in dropdown list is subject wise attendence
        if (ddl_att.SelectedItem.Value == "1")
        {
            ddl_month.Visible = false;
            btn_s.Visible = false;
            monthselect.Visible = false;
            lblmode.Visible = true;
            SqlConnection con13 = new SqlConnection(strConnString);


            //select query to fetch the coursename and credits etc. from regcourses table based on username stored in session and rollno stored in table
            str13 = "select coursename,insrtuctor,credits from regcourses where Rollno='" + Session["Username"] + "'";
            com13 = new SqlCommand(str13, con13);
            SqlDataAdapter da13 = new SqlDataAdapter(com13);
            DataSet ds13 = new DataSet();
            da13.Fill(ds13);
            lbl_course1.Text = ds13.Tables[0].Rows[0]["coursename"].ToString();
            lbl_course2.Text = ds13.Tables[0].Rows[1]["coursename"].ToString();
            lbl_course3.Text = ds13.Tables[0].Rows[2]["coursename"].ToString();
            lbl_course4.Text = ds13.Tables[0].Rows[3]["coursename"].ToString();
            lbl_course5.Text = ds13.Tables[0].Rows[4]["coursename"].ToString();
            lbl_course6.Text = ds13.Tables[0].Rows[5]["coursename"].ToString();

            //displaying the titles of the table in various labels
            lblcourse.Text = "COURSE NAME: ";
            lbltotal.Text = "TOTAL ATTENDANCE: ";
            lblpresent.Text = "PRESENT: ";
            lblabs.Text = "ABSENT: ";
            lblper.Text = "PERCENTAGE: ";





            //displaying total workin days by using function created in sql
            SqlConnection con2 = new SqlConnection(strConnString);
            str2 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays";
            com2 = new SqlCommand(str2, con2);
            SqlDataAdapter da2 = new SqlDataAdapter(com2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            lbl_course1_total.Text = ds2.Tables[0].Rows[0]["totaldays"].ToString();



            //counting total present days by comparing hour and minute part of time
            //here 2 classes are displayed 1) running from 8-9(UG-1(M2)) and another from 14-15(UG-2(M3))
            SqlConnection con3 = new SqlConnection(strConnString);
            str3 = "select count(*) as m2 from CHECKINOUT where ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com3 = new SqlCommand(str3, con3);
            SqlDataAdapter da3 = new SqlDataAdapter(com3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            lbl_course1_present.Text = ds3.Tables[0].Rows[0]["m2"].ToString();



            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            // "N2" in bracket of tostring gives result upto 2 decimal places
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2
            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays1";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            lbl_course2_total.Text = ds4.Tables[0].Rows[0]["totaldays1"].ToString();



            //for classes running from 9-10(UG-1(DATA STRUCTURES)) and 17-18(UG-2(COMPUTER AND COMMUNICATION NETWORKS))
            SqlConnection con5 = new SqlConnection(strConnString);
            str5 = "select count(*) as ds from CHECKINOUT where ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com5 = new SqlCommand(str5, con5);
            SqlDataAdapter da5 = new SqlDataAdapter(com5);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);
            lbl_course2_present.Text = ds5.Tables[0].Rows[0]["ds"].ToString();



            
            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");





            //attendance details of course 3
            SqlConnection con6 = new SqlConnection(strConnString);
            str6 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays2";
            com6 = new SqlCommand(str6, con6);
            SqlDataAdapter da6 = new SqlDataAdapter(com6);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);
            lbl_course3_total.Text = ds6.Tables[0].Rows[0]["totaldays2"].ToString();



            //for classes running from 10-11(UG-1(Basic Electronic Circuits)) and 16-17(UG-2(Fundamentals of Communication))
            SqlConnection con7 = new SqlConnection(strConnString);
            str7 = "select count(*) as oop from CHECKINOUT where ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com7 = new SqlCommand(str7, con7);
            SqlDataAdapter da7 = new SqlDataAdapter(com7);
            DataSet ds7 = new DataSet();
            da7.Fill(ds7);
            lbl_course3_present.Text = ds7.Tables[0].Rows[0]["oop"].ToString();


            
            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");



            //attendance details for course 4
            SqlConnection con8 = new SqlConnection(strConnString);
            str8 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays3";
            com8 = new SqlCommand(str8, con8);
            SqlDataAdapter da8 = new SqlDataAdapter(com8);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            lbl_course4_total.Text = ds8.Tables[0].Rows[0]["totaldays3"].ToString();



            //for classes running from 12-1(UG-1(ITWS 2)) and 18-19(UG-2(economic fundamentals))
            SqlConnection con9 = new SqlConnection(strConnString);
            str9 = "select count(*) as daa from CHECKINOUT where ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com9 = new SqlCommand(str9, con9);
            SqlDataAdapter da9 = new SqlDataAdapter(com9);
            DataSet ds9 = new DataSet();
            da9.Fill(ds9);
            lbl_course4_present.Text = ds9.Tables[0].Rows[0]["daa"].ToString();


            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");






            //attendance details for course 5
            SqlConnection con10 = new SqlConnection(strConnString);
            str10 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays4";
            com10 = new SqlCommand(str10, con10);
            SqlDataAdapter da10 = new SqlDataAdapter(com10);
            DataSet ds10 = new DataSet();
            da10.Fill(ds10);
            lbl_course5_total.Text = ds10.Tables[0].Rows[0]["totaldays4"].ToString();



            //for classes running from 11-12(UG-1(Computer organization)) and 15-16(UG-2(Computer Architecture))
            SqlConnection con11 = new SqlConnection(strConnString);
            str11 = "select count(*) as psy from CHECKINOUT where ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com11 = new SqlCommand(str11, con11);
            SqlDataAdapter da11 = new SqlDataAdapter(com11);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11);
            lbl_course5_present.Text = ds11.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");



            //attendance details fro HSS courses
            SqlConnection con26 = new SqlConnection(strConnString);
            str26 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',GETDATE()) as totaldays3";
            com26 = new SqlCommand(str26, con26);
            SqlDataAdapter da26 = new SqlDataAdapter(com26);
            DataSet ds26 = new DataSet();
            da26.Fill(ds26);
            lbl_course6_total.Text = ds26.Tables[0].Rows[0]["totaldays3"].ToString();




            SqlConnection con27 = new SqlConnection(strConnString);
            str27 = "select count(*) as hss from CHECKINOUT where ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com27 = new SqlCommand(str27, con27);
            SqlDataAdapter da27 = new SqlDataAdapter(com27);
            DataSet ds27 = new DataSet();
            da27.Fill(ds27);
            lbl_course6_present.Text = ds27.Tables[0].Rows[0]["hss"].ToString();




            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");





        }

        //if dropdown list selected item is month-wise attendance
        if (ddl_att.SelectedItem.Value == "2")
        {

            ddl_month.Visible = true;
            btn_s.Visible= true;
            monthselect.Visible = true;
            

        }
        

    }



    //click event of button when a month is selected from drop down lsit

    protected void btn_click_att(object sender, EventArgs e)
    {
        //displaying various coursename and attendance details in labels

        SqlConnection con13 = new SqlConnection(strConnString);
        str13 = "select coursename,insrtuctor,credits from regcourses where Rollno='" + Session["Username"] + "'";
        com13 = new SqlCommand(str13, con13);
        SqlDataAdapter da13 = new SqlDataAdapter(com13);
        DataSet ds13 = new DataSet();
        da13.Fill(ds13);
        lbl_course1.Text = ds13.Tables[0].Rows[0]["coursename"].ToString();
        lbl_course2.Text = ds13.Tables[0].Rows[1]["coursename"].ToString();
        lbl_course3.Text = ds13.Tables[0].Rows[2]["coursename"].ToString();
        lbl_course4.Text = ds13.Tables[0].Rows[3]["coursename"].ToString();
        lbl_course5.Text = ds13.Tables[0].Rows[4]["coursename"].ToString();
        lbl_course6.Text = ds13.Tables[0].Rows[5]["coursename"].ToString();


        lblcourse.Text = "COURSE NAME: ";
        lbltotal.Text = "TOTAL ATTENDANCE: ";
        lblpresent.Text = "PRESENT: ";
        lblabs.Text = "ABSENT: ";
        lblper.Text = "PERCENTAGE: ";
        
        //details are displayed just as displayed for subject wise...just another field month is included

        //if selected month is january....
        if (ddl_month.SelectedItem.Value == "1")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con15 = new SqlConnection(strConnString);
            str15 = "select [dbo].[CalculateNumberOFWorkDays]('2015-01-01','2015-01-31') as totaldays15";
            com15 = new SqlCommand(str15, con15);
            SqlDataAdapter da15 = new SqlDataAdapter(com15);
            DataSet ds15 = new DataSet();
            da15.Fill(ds15);
            lbl_course1_total.Text = ds15.Tables[0].Rows[0]["totaldays15"].ToString();
            lbl_course2_total.Text = ds15.Tables[0].Rows[0]["totaldays15"].ToString();
            lbl_course3_total.Text = ds15.Tables[0].Rows[0]["totaldays15"].ToString();
            lbl_course4_total.Text = ds15.Tables[0].Rows[0]["totaldays15"].ToString();
            lbl_course5_total.Text = ds15.Tables[0].Rows[0]["totaldays15"].ToString();
            lbl_course6_total.Text = ds15.Tables[0].Rows[0]["totaldays15"].ToString();

           
            SqlConnection con16 = new SqlConnection(strConnString);
            str16 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=01 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com16 = new SqlCommand(str16, con16);
            SqlDataAdapter da16 = new SqlDataAdapter(com16);
            DataSet ds16 = new DataSet();
            da16.Fill(ds16);
            lbl_course1_present.Text = ds16.Tables[0].Rows[0]["coa"].ToString();


          

            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2
            
            
            SqlConnection con17 = new SqlConnection(strConnString);
            str17 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=01 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com17 = new SqlCommand(str17, con17);
            SqlDataAdapter da17 = new SqlDataAdapter(com17);
            DataSet ds17 = new DataSet();
            da17.Fill(ds17);
            lbl_course2_present.Text = ds17.Tables[0].Rows[0]["dbms"].ToString();



            
            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");






         
            SqlConnection con18 = new SqlConnection(strConnString);
            str18 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=01 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com18 = new SqlCommand(str18, con18);
            SqlDataAdapter da18 = new SqlDataAdapter(com18);
            DataSet ds18 = new DataSet();
            da18.Fill(ds18);
            lbl_course3_present.Text = ds18.Tables[0].Rows[0]["oop"].ToString();


            
            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");




            
            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=01 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            
            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");





            


            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=01 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");


            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=01 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");









        }

        //if month is february
        if (ddl_month.SelectedItem.Value == "2")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-02-01','2015-02-28') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

            
            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=02 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();


            

            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            
            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=02 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            
            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=02 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            
            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=02 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            
            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=02 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");



            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=02 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");






        }


        //if month is march.....
        if (ddl_month.SelectedItem.Value == "3")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-03-01','2015-03-31') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

            
            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=03 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();


            

            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            
            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=03 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            
            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=03 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            
            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=03 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            
            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=03 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");




            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=03 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");





        }


        //if month is april....
        if (ddl_month.SelectedItem.Value == "4")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-04-01','2015-04-30') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

            
            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=04 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();


            

            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            
            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=04 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            
            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=04 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            
            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=04 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            
            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=04 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");


            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=04 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");







        }

        //if month is may....
        if (ddl_month.SelectedItem.Value == "5")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-05-01','2015-05-31') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

           
            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=05 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();


           

            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

           
            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=05 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



           
            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=05 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


           
            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=05 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



           
            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=05 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



           
            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");


            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=05 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



           
            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");







        }

        //if month is june
        if (ddl_month.SelectedItem.Value == "6")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-06-13',getdate()) as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

            
            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=06 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();


            

            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            
            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=06 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            
            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=06 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            
            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=06 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            
            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=06 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");


            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=06 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            
            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");







        }

        //if month is july....
        if (ddl_month.SelectedItem.Value == "7")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-07-01','2015-07-31') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=07 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();



            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=07 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=07 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=07 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=07 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");



            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=07 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");






        }

        //if month is august....
        if (ddl_month.SelectedItem.Value == "8")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-08-01','2015-08-31') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

            
            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=08 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();


            
            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=08 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=08 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=08 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=08 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");


            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=08 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");







        }

        //if month is september....
        if (ddl_month.SelectedItem.Value == "9")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-09-01','2015-09-30') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=09 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();


            
            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=09 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=10 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<19) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=09 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=09 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");



            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=09 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");






        }

        //if month is october....
        if (ddl_month.SelectedItem.Value == "10")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-10-01','2015-10-31') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=10 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();



            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=10 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=10 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=10 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=10 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");




            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=10 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");





        }

        //if month is november....
        if (ddl_month.SelectedItem.Value == "11")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-11-01','2015-11-30') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();

            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=11 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();


           
            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=11 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=11 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=11 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=11 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");


            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=11 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");







        }

        //if month is december.....
        if (ddl_month.SelectedItem.Value == "12")
        {





            //displaying attendance of course1


            //displaying total workin days by using function created in sql
            SqlConnection con21 = new SqlConnection(strConnString);
            str21 = "select [dbo].[CalculateNumberOFWorkDays]('2015-12-01','2015-12-31') as totaldays21";
            com21 = new SqlCommand(str21, con21);
            SqlDataAdapter da21 = new SqlDataAdapter(com21);
            DataSet ds21 = new DataSet();
            da21.Fill(ds21);
            lbl_course1_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course2_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course3_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course4_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course5_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();
            lbl_course6_total.Text = ds21.Tables[0].Rows[0]["totaldays21"].ToString();


            SqlConnection con22 = new SqlConnection(strConnString);
            str22 = "select count(*) as coa from CHECKINOUT where DATEPART(mm,checktime)=12 and ((DATEPART(HOUR, checktime)>=8 and DATEPART(HOUR,checktime)<9) or (DATEPART(HOUR,checktime)>=14 and DATEPART(HOUR,checktime)<15)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com22 = new SqlCommand(str22, con22);
            SqlDataAdapter da22 = new SqlDataAdapter(com22);
            DataSet ds22 = new DataSet();
            da22.Fill(ds22);
            lbl_course1_present.Text = ds22.Tables[0].Rows[0]["coa"].ToString();



            //counting total absent by subtracting total days by total present days
            lbl_course1_abs.Text = (Convert.ToDouble(lbl_course1_total.Text) - Convert.ToDouble(lbl_course1_present.Text)).ToString();

            //counting total percentage
            lbl_course1_per.Text = ((Convert.ToDouble(lbl_course1_present.Text) / Convert.ToDouble(lbl_course1_total.Text)) * 100).ToString("N2");





            //attendance details for course2

            SqlConnection con23 = new SqlConnection(strConnString);
            str23 = "select count(*) as dbms from CHECKINOUT where DATEPART(mm,checktime)=12 and ((DATEPART(HOUR, checktime)>=9 and DATEPART(HOUR,checktime)<10) or (DATEPART(HOUR, checktime)>=17 and DATEPART(HOUR, checktime)<18)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<59 and USERID= '" + Session["userid"] + "'";
            com23 = new SqlCommand(str23, con23);
            SqlDataAdapter da23 = new SqlDataAdapter(com23);
            DataSet ds23 = new DataSet();
            da23.Fill(ds23);
            lbl_course2_present.Text = ds23.Tables[0].Rows[0]["dbms"].ToString();



            lbl_course2_abs.Text = (Convert.ToDouble(lbl_course2_total.Text) - Convert.ToDouble(lbl_course2_present.Text)).ToString();


            lbl_course2_per.Text = ((Convert.ToDouble(lbl_course2_present.Text) / Convert.ToDouble(lbl_course2_total.Text)) * 100).ToString("N2");







            SqlConnection con24 = new SqlConnection(strConnString);
            str24 = "select count(*) as oop from CHECKINOUT where DATEPART(mm,checktime)=12 and ((DATEPART(HOUR, checktime)>=10 and DATEPART(HOUR,checktime)<11) or (DATEPART(HOUR, checktime)>=16 and DATEPART(HOUR,checktime)<17)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com24 = new SqlCommand(str24, con24);
            SqlDataAdapter da24 = new SqlDataAdapter(com24);
            DataSet ds24 = new DataSet();
            da24.Fill(ds24);
            lbl_course3_present.Text = ds24.Tables[0].Rows[0]["oop"].ToString();


            lbl_course3_abs.Text = (Convert.ToDouble(lbl_course3_total.Text) - Convert.ToDouble(lbl_course3_present.Text)).ToString();


            lbl_course3_per.Text = ((Convert.ToDouble(lbl_course3_present.Text) / Convert.ToDouble(lbl_course3_total.Text)) * 100).ToString("N2");





            SqlConnection con19 = new SqlConnection(strConnString);
            str19 = "select count(*) as daa from CHECKINOUT where DATEPART(mm,checktime)=12 and ((DATEPART(HOUR, checktime)>=12 and DATEPART(HOUR,checktime)<13) or (DATEPART(HOUR, checktime)>=18 and DATEPART(HOUR,checktime)<19)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com19 = new SqlCommand(str19, con19);
            SqlDataAdapter da19 = new SqlDataAdapter(com19);
            DataSet ds19 = new DataSet();
            da19.Fill(ds19);
            lbl_course4_present.Text = ds19.Tables[0].Rows[0]["daa"].ToString();



            lbl_course4_abs.Text = (Convert.ToDouble(lbl_course4_total.Text) - Convert.ToDouble(lbl_course4_present.Text)).ToString();


            lbl_course4_per.Text = ((Convert.ToDouble(lbl_course4_present.Text) / Convert.ToDouble(lbl_course4_total.Text)) * 100).ToString("N2");








            SqlConnection con20 = new SqlConnection(strConnString);
            str20 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=12 and ((DATEPART(HOUR, checktime)>=11 and DATEPART(HOUR,checktime)<12) or (DATEPART(HOUR, checktime)>=15 and DATEPART(HOUR,checktime)<16)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com20 = new SqlCommand(str20, con20);
            SqlDataAdapter da20 = new SqlDataAdapter(com20);
            DataSet ds20 = new DataSet();
            da20.Fill(ds20);
            lbl_course5_present.Text = ds20.Tables[0].Rows[0]["psy"].ToString();



            lbl_course5_abs.Text = (Convert.ToDouble(lbl_course5_total.Text) - Convert.ToDouble(lbl_course5_present.Text)).ToString();


            lbl_course5_per.Text = ((Convert.ToDouble(lbl_course5_present.Text) / Convert.ToDouble(lbl_course5_total.Text)) * 100).ToString("N2");


            SqlConnection con25 = new SqlConnection(strConnString);
            str25 = "select count(*) as psy from CHECKINOUT where DATEPART(mm,checktime)=12 and ((DATEPART(HOUR, checktime)>=13 and DATEPART(HOUR,checktime)<14) or (DATEPART(HOUR, checktime)>=19 and DATEPART(HOUR,checktime)<20)) and DATEPART(MINUTE, checktime)>=00 and DATEPART(MINUTE, checktime)<10 and USERID= '" + Session["userid"] + "'";
            com25 = new SqlCommand(str25, con25);
            SqlDataAdapter da25 = new SqlDataAdapter(com25);
            DataSet ds25 = new DataSet();
            da25.Fill(ds25);
            lbl_course6_present.Text = ds25.Tables[0].Rows[0]["psy"].ToString();



            lbl_course6_abs.Text = (Convert.ToDouble(lbl_course6_total.Text) - Convert.ToDouble(lbl_course6_present.Text)).ToString();


            lbl_course6_per.Text = ((Convert.ToDouble(lbl_course6_present.Text) / Convert.ToDouble(lbl_course6_total.Text)) * 100).ToString("N2");







        }






    }




    //click event of logout button....
    protected void Button1_Click(object sender, EventArgs e)
    {

        Session.Abandon();

        Session.Contents.RemoveAll();

        System.Web.Security.FormsAuthentication.SignOut();

        Response.Redirect("index.aspx");


   }
    
    //click event of another logout button
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Abandon();

        Session.Contents.RemoveAll();

        System.Web.Security.FormsAuthentication.SignOut();

        Response.Redirect("index.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();

        Session.Contents.RemoveAll();

        System.Web.Security.FormsAuthentication.SignOut();

        Response.Redirect("index.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Session.Abandon();

        Session.Contents.RemoveAll();

        System.Web.Security.FormsAuthentication.SignOut();

        Response.Redirect("index.aspx");
    }



    //click event when percentage of any subject is clicked....
    //it displays how the percentage is calculated.. i.e. time at which attendance is marked and whether it is valid or invalid...
    //it is invalid if the time of marking attendance exceeds 10 minutes from the start of class
    //the data is displayed in a grid
    protected void lblcourse1_details(object sender, EventArgs e)
    {
        if (lbl_course1.Text == "Maths II")
        {
            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=8 and DATEPART(HOUR,CHECKTIME)<9 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            
           
            
            grd_att.Visible = true;

            
         
            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }
        if (lbl_course1.Text == "Maths III")
        {
            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=14 and DATEPART(HOUR,CHECKTIME)<15 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }


    }

    protected void lblcourse2_details(object sender, EventArgs e)
    {

        if (lbl_course2.Text == "Data Structures")
        {
            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=9 and DATEPART(HOUR,CHECKTIME)<10 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            
            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }
        if (lbl_course5.Text == "Computer and Communication Networks")
        {

            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=17 and DATEPART(HOUR,CHECKTIME)<18 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }


    }
    protected void lblcourse3_details(object sender, EventArgs e)
    {

        if (lbl_course3.Text == "Basic Electronic Circuits")
        {
            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=10 and DATEPART(HOUR,CHECKTIME)<11 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }
        if (lbl_course3.Text == "Fundamentals of Communication")
        {

            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=16 and DATEPART(HOUR,CHECKTIME)<17 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            
            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }


    }
    protected void lblcourse4_details(object sender, EventArgs e)
    {

        if (lbl_course4.Text == "ITWS II")
        {
            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=12 and DATEPART(HOUR,CHECKTIME)<13 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }
        if (lbl_course4.Text == "Economic Fundamentals")
        {

            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=18 and DATEPART(HOUR,CHECKTIME)<19 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }


    }

    protected void lblcourse5_details(object sender, EventArgs e)
    {
        
        if (lbl_course5.Text == "Computer Organization")
        {
            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=11 and DATEPART(HOUR,CHECKTIME)<12 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }
        if (lbl_course5.Text == "Computer Architecture")
        {

            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=15 and DATEPART(HOUR,CHECKTIME)<16 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }


    }
    protected void lblcourse6_details(object sender, EventArgs e)
    {

        if (lbl_course6.Text == "HUMANITIES[Communication 2]")
        {
            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=13 and DATEPART(HOUR,CHECKTIME)<14 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



            grd_att.DataSource = ds4;
            grd_att.DataBind();
        }
        if (lbl_course6.Text == "HUMANITIES[Communication 2 + Thinking Skills]")
        {

            SqlConnection con4 = new SqlConnection(strConnString);
            str4 = "Select username,firstname,lastname, convert(DATE,checktime) as doa,convert(time,checktime) as it,case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' else 'INVALID' end as min,count(case when DATEPART(MINUTE,checktime)>00 and DATEPART(MINUTE,checktime)<10 then 'VALID' end) as cou from checkinout inner join userlogin on checkinout.USERID=userlogin.userid where DATEPART(HOUR,CHECKTIME)>=19 and DATEPART(HOUR,CHECKTIME)<20 and username= '" + Session["username"] + "' group by username,firstname,lastname,checktime";
            com4 = new SqlCommand(str4, con4);
            SqlDataAdapter da4 = new SqlDataAdapter(com4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);




            grd_att.Visible = true;



             grd_att.DataSource = ds4;
            grd_att.DataBind();
        }


    }
}