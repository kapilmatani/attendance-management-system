<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <head>
<title>IIIT</title>
<meta charset="utf-8">
<link rel="stylesheet" href="css/reset.css" type="text/css" media="all">
<link rel="stylesheet" href="css/style.css" type="text/css" media="all">
<script type="text/javascript" src="js/jquery-1.4.2.min.js" ></script>
<script type="text/javascript" src="js/cufon-yui.js"></script>
<script type="text/javascript" src="js/cufon-replace.js"></script>
<script type="text/javascript" src="js/Myriad_Pro_300.font.js"></script>
<script type="text/javascript" src="js/Myriad_Pro_400.font.js"></script>
<script type="text/javascript" src="js/script.js"></script>

<script type="text/javascript" language="javascript">
    function Validate() {
        var UName = document.getElementById('txtUserName1');
        var Password = document.getElementById('txtPWD1');
        if ((UName.value == '') || (Password.value == '')) {
            alert('UserName or Password should not be blank');
            return false;
        }
        else {
            return true;
        }
    }
    </script>

<!--[if lt IE 7]>
<link rel="stylesheet" href="css/ie6.css" type="text/css" media="screen">
<script type="text/javascript" src="js/ie_png.js"></script>
<script type="text/javascript">ie_png.fix('.png, footer, header nav ul li a, .nav-bg, .list li img');</script>
<![endif]-->
<!--[if lt IE 9]><script type="text/javascript" src="js/html5.js"></script><![endif]-->

    <link rel="stylesheet" href="css/reset1.css">

    <link rel='stylesheet prefetch' href='http://daneden.github.io/animate.css/animate.min.css'>
<link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Roboto:400,100,400italic,700italic,700'>
<link rel='stylesheet prefetch' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css'>
<link rel="stylesheet" href="css/style1.css">
</head>
<body id="page1">
<!-- START PAGE SOURCE -->
<div class="wrap">
  <header style="width:1100px; height:120px;">
      <h1><a href="index.aspx">IIIT MIS</a></h1>
      <h4 style="height:30px;font-size:28px;font-weight:bold;margin-top:20px;margin-left:240px;font-family:Verdana; color:black;">Indian Institute Of Information Technology</h4>
      <br>
      <h4 style="font-family:Verdana;font-size:22px;margin-left:18px;margin-top:-4px; color:Black;">Sri City, Chittoor District, Andhra Pradesh</h4>
      <!--<nav>
        <ul>
          <li class="current"><a href="index.html" class="m1">Home Page</a></li>
          <li><a href="about-us.html" class="m2">About Us</a></li>
          <li><a href="articles.html" class="m3">Our Articles</a></li>
          <li><a href="contact-us.html" class="m4">Contact Us</a></li>
          <li class="last"><a href="sitemap.html" class="m5">Sitemap</a></li>
        </ul>
      </nav>-->
      <!--<form action="#" id="search-form">
        <fieldset>
          <div class="rowElem">
            <input type="text">
            <a href="#">Search</a></div>
        </fieldset>
      </form>-->
      
  </header>
  <div class="container">
    <aside >
<!--<div class='form aniamted bounceIn'>
  <div class='switch'>
    <i class='fa fa-pencil fa-times'></i>
    <div class='tooltip'>Admin</div>
  </div>
  <div class='login'>
    <h2>USER LOGIN</h2>
    <form>
      <input placeholder='Username' type='text' id="txtUserName" runat="server"/>
      <input placeholder='Password' type='password' id="txtPWD" runat="server"/>

      <button onclick="btnSubmit_Click">Login</button>
    </form>
  </div>
  <div class='register'>
    <h2>ADMIN ACCESS</h2>
    
    <form>
      <input placeholder='Username' type='text' name="user">
      <input placeholder='Password' type='password' name="pass">
      <button type="submit" >Login</button>

    </form>
  </div>
  <footer>
    <a href='http://andytran.me'>Forgot Password?</a>
  </footer>
</div>-->





<div>
    
<div>

<div>
    
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000000">STUDENT'S LOGIN </asp:Label>
</div>
<table style="margin-right:30px;margin-top:20px;">



<tr>   

    <td style="margin-bottom:15px">
        <asp:Label ID="lbl_prog" runat="server" Font-Bold="True" ForeColor="#000000">Program: </asp:Label>

    </td>
    

    <td>
    
        <asp:DropDownList ID="ddl_prog" runat="server"  AutoPostBack="true" 
            onselectedindexchanged="ddl_prog_SelectedIndexChanged" style="margin-bottom:3px">
               
               <asp:ListItem Value="0">--Select--</asp:ListItem>
            <asp:ListItem Value="1">UG-1 (CSE)</asp:ListItem>
             <asp:ListItem Value="2">UG-1 (ECE)</asp:ListItem>
               <asp:ListItem Value="3">UG-2 (CSE)</asp:ListItem>
                    <asp:ListItem Value="4">UG-2 (ECE)</asp:ListItem>
        
        
        
        </asp:DropDownList>
    
    </td>



</tr>




<tr>

<asp:Label ID="lb1" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label><br />

<td>
<asp:Label ID="lbl_username" runat="server" Visible="false" Font-Bold="True" ForeColor="#000000">Username: </asp:Label>

</td>

<td style="margin-top:15px;">
<asp:TextBox ID="txtUserName1" runat="server" Visible="false"/>
<asp:RequiredFieldValidator ID="rfvUser" ErrorMessage="Please enter Username" ControlToValidate="txtUserName1" runat="server" />
</td>
</tr>
<tr>
<td>
<asp:Label ID="lbl_password" runat="server" Font-Bold="True" ForeColor="#000000" Visible="false">Password: </asp:Label>
</td>
<td>
<asp:TextBox ID="txtPWD1" runat="server" TextMode="Password" Visible="false"/>
<asp:RequiredFieldValidator ID="rfvPWD" runat="server" ControlToValidate="txtPWD1" ErrorMessage="Please enter Password"/>
</td>
</tr>
<tr>
<td>
</td>
<td>
<asp:Button ID="btn_login" runat="server" Text="Login" Font-Bold="True" Color="#000000"
            BackColor=""  OnClientClick="Validate()" onclick="btn_login_Click" Visible="false"
            />
</td>
</tr>
</table>
<br />
<br />
<br />

<div>
    
    <asp:Label ID="lbl" runat="server" Font-Bold="True" ForeColor="#000000">ADMIN LOGIN </asp:Label>
</div>
<table style="margin-right:30px;margin-top:20px;">



<tr>   

    <td style="margin-bottom:15px">
        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#000000">Admin: </asp:Label>

    </td>
    

    <td>
    
        <asp:DropDownList ID="ddl_admin" runat="server"  AutoPostBack="true" 
            onselectedindexchanged="ddl_admin_SelectedIndexChanged" style="margin-bottom:2px">
               
               <asp:ListItem Value="0">--Select--</asp:ListItem>
            <asp:ListItem Value="1">Faculty/Staff</asp:ListItem>
             <asp:ListItem Value="2">SuperAdmin</asp:ListItem>
               
        
        
        </asp:DropDownList>
    
    </td>



</tr>




<tr>

<asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label><br />

<td>
<asp:Label ID="lbl_admin_username" runat="server" Visible="false" Font-Bold="True" ForeColor="#000000">Username: </asp:Label>

</td>

<td style="margin-top:15px;">
<asp:TextBox ID="txtadminusername" runat="server" Visible="false"/>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please enter Username" ControlToValidate="txtadminusername" runat="server" />
</td>
</tr>
<tr>
<td>
<asp:Label ID="lbl_admin_pwd" runat="server" Font-Bold="True" ForeColor="#000000" Visible="false">Password: </asp:Label>
</td>
<td>
<asp:TextBox ID="txtadminpwd" runat="server" TextMode="Password" Visible="false"/>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtadminpwd" ErrorMessage="Please enter Password"/>
</td>
</tr>
<tr>
<td>
</td>
<td>
<asp:Button ID="btn_admin" runat="server" Text="Login" Font-Bold="True" Color="#000000"
            BackColor=""  OnClientClick="Validate()" onclick="btn_admin_Click" Visible="false"
            />
</td>
</tr>
</table>



</div>
</div>


    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

        <script src="js/index.js"></script>
      
    </form>
      
      <!--<ul class="news" style="margin-top:50px;margin-right:30px;">
        <h2 style="font-size:20px;">Fresh <span>News</span></h2>
        <li><strong>May 14, 2015</strong>
          
          Prof. V. K. Mittal gave two talks at DAIICT on 12 May and 14 May 15, on 'Nonverbal Speech Sounds: Analysis and Applications' and 'Applications of Nonverbal Speech Sounds towards developing automated systems'. </li>-->
        
          
    </aside>
    <section id="content">
      <div id="banner">
      <img src="images/raj-reddy3.jpg" width="730px" height="400px"></img>
      </div>
      
    </section>
  </div>
</div>

<script type="text/javascript">    Cufon.now(); </script>
<!-- END PAGE SOURCE -->
</body>
    </div>
    </form>
</body>
</html>
