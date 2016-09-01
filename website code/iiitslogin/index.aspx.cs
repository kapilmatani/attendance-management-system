using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //defining connection with database in sql....
    string strConnString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
    SqlCommand com,com1;
    SqlDataAdapter sqlda,sqlda1;
    string str,str1;
    DataTable dt,dt1;
    int RowCount,RowCount1;
    protected void btn_login_Click(object sender, EventArgs e)
    {

        //for student login...based on username and password stored in table userlogin......
        string UserName = txtUserName1.Text.Trim();
        string Password = txtPWD1.Text.Trim();
        string userid;
        string firstname;
        string lastname;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        str = "Select * from userlogin";
        com = new SqlCommand(str);
        sqlda = new SqlDataAdapter(com.CommandText, con);
        dt = new DataTable();
        sqlda.Fill(dt);
        RowCount = dt.Rows.Count;
        for (int i = 0; i < RowCount; i++)
        {
            UserName = dt.Rows[i]["UserName"].ToString();
            Password = dt.Rows[i]["Passwrd"].ToString();
            userid = dt.Rows[i]["Userid"].ToString();
            firstname = dt.Rows[i]["firstname"].ToString();
            lastname = dt.Rows[i]["lastname"].ToString();
            if (UserName == txtUserName1.Text && Password == txtPWD1.Text)
            {
                Session["UserName"] = UserName;
                Session["userid"] = userid;
                Session["FirstName"] = firstname;
                Session["LastName"] = lastname;
                Response.Redirect("Details.aspx");
            }
            else
            {
                lb1.Text = "Invalid User Name or Password! Please try again!";
            }
        }
    }


    //dropdown list items showinf ug1(cse or ug1(ece) etc...when selected it will display username's initial based on the item selected
    protected void ddl_prog_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtadminusername.Visible = false;
        txtadminpwd.Visible = false;
        lbl_admin_username.Visible = false;
        lbl_admin_pwd.Visible = false;
        btn_admin.Visible = false;
        if (ddl_prog.SelectedItem.Text == "UG-1 (CSE)")
        {
            lbl_username.Visible = true;
            txtUserName1.Visible = true;
            lbl_password.Visible = true;
            txtPWD1.Visible = true;
            btn_login.Visible = true;
            txtUserName1.Text = "IS201401";

        }
        if (ddl_prog.SelectedItem.Text == "UG-1 (ECE)")
        {
            lbl_username.Visible = true;
            txtUserName1.Visible = true;
            lbl_password.Visible = true;
            txtPWD1.Visible = true;
            btn_login.Visible = true;
            txtUserName1.Text = "IS201411";
        }
        if (ddl_prog.SelectedItem.Text == "UG-2 (CSE)")
        {
            lbl_username.Visible = true;
            txtUserName1.Visible = true;
            lbl_password.Visible = true;
            txtPWD1.Visible = true;
            btn_login.Visible = true;
            txtUserName1.Text = "IS201301";
        }
        if (ddl_prog.SelectedItem.Text == "UG-2 (ECE)")
        {
            lbl_username.Visible = true;
            txtUserName1.Visible = true;
            lbl_password.Visible = true;
            txtPWD1.Visible = true;
            btn_login.Visible = true;
            txtUserName1.Text = "IS201311";

        }
    }


    //admin dropdown list items....
    protected void ddl_admin_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_admin_username.Visible = true;
        txtadminusername.Visible = true;
        lbl_admin_pwd.Visible = true;
        txtadminpwd.Visible = true;
        btn_admin.Visible = true;
        txtUserName1.Visible = false;
        txtPWD1.Visible = false;
        btn_login.Visible = false;
        lbl_username.Visible = false;
        lbl_password.Visible = false;

    }

    //click event when drop down list item is selected from admin side....
    protected void btn_admin_Click(object sender, EventArgs e)
    {
        //if item selected is faculty...
        //userlogin based on username and password stored in facultylogin table....
        if (ddl_admin.SelectedItem.Text == "Faculty/Staff")
        {
            string UserName = txtadminusername.Text.Trim();
            string Password = txtadminpwd.Text.Trim();
            string userid;
            string name;
            

            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "Select * from facultylogin";
            com = new SqlCommand(str);
            sqlda = new SqlDataAdapter(com.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                UserName = dt.Rows[i]["UserName"].ToString();
                Password = dt.Rows[i]["Paswrd"].ToString();
                userid = dt.Rows[i]["Userid"].ToString();

                name = dt.Rows[i]["name"].ToString();
                if (UserName == txtadminusername.Text && Password == txtadminpwd.Text)
                {
                    Session["UserName"] = UserName;
                    Session["userid"] = userid;
                    Session["Name"] = name;

                    Response.Redirect("admin.aspx");
                }
                else
                {
                    Label3.Text = "Invalid User Name or Password! Please try again!";
                }
            }
    
        }


        //if item selected is superadmin....
        //userlogin based on username and password stored in superadmin table....
        if (ddl_admin.SelectedItem.Text == "SuperAdmin")
        {
            string UserName = txtadminusername.Text.Trim();
            string Password = txtadminpwd.Text.Trim();
            


            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "Select * from superadmin";
            com = new SqlCommand(str);
            sqlda = new SqlDataAdapter(com.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                UserName = dt.Rows[i]["username"].ToString();
                Password = dt.Rows[i]["passwrd"].ToString();
                
                if (UserName == txtadminusername.Text && Password == txtadminpwd.Text)
                {
                    Session["UserName"] = UserName;
                    
                    Response.Redirect("superadmin.aspx");
                }
                else
                {
                    Label3.Text = "Invalid User Name or Password! Please try again!";
                }
            }

        }


    }
}
