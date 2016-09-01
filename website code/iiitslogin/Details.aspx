<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<!DOCTYPE html>
<html lang="en">
    <head>
		<meta charset="UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
        <title>Animated Content Tabs with CSS3</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"> 
        <meta name="description" content="Animated Content Tabs with CSS3" />
        <meta name="keywords" content="tabs, css3, transition, checked, pseudo-class, label, css-only, sibling combinator" />
        <meta name="author" content="Codrops" />
        <link rel="shortcut icon" href="../favicon.ico"> 
        <link rel="stylesheet" type="text/css" href="css1/demo.css" />
        <link rel="stylesheet" type="text/css" href="css1/style3.css" />
		<script type="text/javascript" src="js/modernizr.custom.04022.js"></script>
		<link href='http://fonts.googleapis.com/css?family=Open+Sans+Condensed:700,300,300italic' rel='stylesheet' type='text/css'>
		<!--[if lt IE 9]>
			<style>
				.content{
					height: auto;
					margin: 0;
				}
				.content div {
					position: relative;
				}
			    .style1
                {
                    height: 156px;
                }
			    .style2
                {
                    height: 2px;
                }
			</style>
		<![endif]-->
            <link rel="stylesheet" type="text/css" media="all" href="css/jsDatePick_ltr.min.css" />
    <link rel="stylesheet" type="text/css" media="all" href="/jsDatePick_ltr.css" />
    <script type="text/javascript" src="js/jquery.1.4.2.js"></script>
<script type="text/javascript" src="js/jsDatePick.jquery.min.1.3.js"></script>
<script type="text/javascript">
    window.onload = function () {
        new JsDatePick({
            useMode: 2,
            target: "inputField",
            dateFormat: "%d-%M-%Y"
            /*selectedDate:{				
            day:5,					
            month:9,
            year:2006
            },
            yearsRange:[1978,2020],
            limitToToday:false,
            cellColorScheme:"beige",
            dateFormat:"%m-%d-%Y",
            imgPath:"img/",
            weekStartDay:1*/
        });
    };
</script>


<script language="javascript" type="text/javascript">
history.forward();

 

</script>





    </head>
    <body>
   
        <form id="form1" runat="server">
   
        <div class="container">
			<!-- Codrops top bar -->
            
			<section class="tabs">
	      <input id="tab-1" type="radio" name="radio-set" class="tab-selector-1" checked="checked" />
		        <label for="tab-1" class="tab-label-1">ATTENDANCE</label>
		
	            <input id="tab-2" type="radio" name="radio-set" class="tab-selector-2" />
		        <label for="tab-2" class="tab-label-2">COURSES</label>
		
            
            
			    <div class="clear-shadow"></div>
			
		        <div class="content">
			        <div class="content-1">
                    
             
                         


                        <asp:Label ID="lb1" runat="server" Text="Label"></asp:Label>
   
     
     
  

                            <asp:Button ID="Button4" 
                            style="opacity:10; margin-top:11px; margin-left:934px; width:100px; height:21px" 
                            runat="server" Text="LOGOUT" onclick="Button4_Click"  ></asp:Button>
                  <table style="background-color:#E9E8EE; width: 956px;margin-top:50px;"
             cellspacing="25px" cellpadding="10px">
             <tr style="background-color:#AEBac4;color:white;font-size:20px;margin-top:-8px;padding-bottom:14px;padding-top:6px;">
             <td colspan="6" align="center">ATTENDANCE DETAILS</td>
             </tr>
            
                
               <tr style="font-weight:bold;font-size:13px;color:#000000;">
                 <td>
                    <asp:Label ID="lblmode" runat="server" Text="SELECT YOUR MODE :" Visible="true"></asp:Label>
                
                </td>
                <td >
                    <asp:DropDownList ID="ddl_att" style="margin-left:-166px" runat="server"   >
                            <asp:ListItem value="">Select</asp:ListItem>
                            <asp:ListItem value="1">Subject Wise Attendance Details</asp:ListItem>
                            <asp:ListItem value="2">Month Wise Attendance Details</asp:ListItem> 
                    </asp:DropDownList>

                    </td>


                    <td style="margin-left:336px;margin-top:115px; opacity:10;" class="style2 margin-top">
                                    
                    <asp:Button ID="btn_att" style="opacity:10; margin-top:138px; margin-left:513px; width:100px; height:21px" runat="server" Text="Submit" OnClick="btn_click_att1" ></asp:Button>
                    
                    
                </td>
                </tr>
                <tr>
                <td>
                    <asp:Label ID="monthselect" runat="server" Text="SELECT YOUR MONTH :" Visible="false"></asp:Label>
                
                </td>
<td>             

             <asp:DropDownList ID="ddl_month" style="margin-left:-166px" runat="server"  Visible="false"  >
                            <asp:ListItem value="">Select</asp:ListItem>
                            <asp:ListItem value="1">January</asp:ListItem>
                            <asp:ListItem value="2">February</asp:ListItem>
                            <asp:ListItem value="3">March</asp:ListItem>
                            <asp:ListItem value="4">April</asp:ListItem>
                            <asp:ListItem value="5">May</asp:ListItem>
                            <asp:ListItem value="6">June</asp:ListItem>
                            <asp:ListItem value="7">July</asp:ListItem>
                            <asp:ListItem value="8">August</asp:ListItem>
                            <asp:ListItem value="9">September</asp:ListItem>
                            <asp:ListItem value="10">October</asp:ListItem>
                            <asp:ListItem value="11">November</asp:ListItem>
                            <asp:ListItem value="12">December</asp:ListItem>  
                    </asp:DropDownList>

</td>
                <td>
                
                    <asp:Button ID="btn_s" style="opacity:10; margin-top:178px; margin-left:513px; width:100px; height:21px" runat="server" Text="Submit" OnClick="btn_click_att" Visible="false" ></asp:Button>
                </td>
                </tr>


               
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                <td style="margin-left:25px;" colspan="2" class="style1">                
                     <font size="4"><asp:Label
              ID="lblcourse" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4"><asp:Label
              ID="lbltotal" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4"><asp:Label
              ID="lblpresent" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4"><asp:Label
              ID="lblabs" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4"><asp:Label
              ID="lblper" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                <td style="margin-left:25px;" colspan="2" class="style1">                
                     <!--<font size="2">Computer Organisation and Architecture: </font>-->

                     <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course1" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
              
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course1_total" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_course1_present" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course1_abs" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="lbl_course1_per" runat="server" OnClick="lblcourse1_details"></asp:LinkButton></font></b>
                    
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                <td style="margin-left:25px;" colspan="2" class="style1">                
                     <!--<font size="2">Database Management System: </font>-->
                     <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course2" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
              
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course2_total" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_course2_present" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course2_abs" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="lbl_course2_per" runat="server" OnClick="lblcourse2_details"></asp:LinkButton></font></b>
                    
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                <td style="margin-left:25px;" colspan="2" class="style1">                
                     <!--<font size="2">OOP with JAVA: </font>-->
                     <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course3" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
              
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course3_total" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_course3_present" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course3_abs" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="lbl_course3_per" runat="server" OnClick="lblcourse3_details"></asp:LinkButton><br /></font></b>
                    
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                <td style="margin-left:25px;" colspan="2" class="style1">                
                     <!--<font size="2">Design and Analysis of Algorithms: </font>-->
                     <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course4" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
              
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course4_total" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_course4_present" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course4_abs" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="lbl_course4_per" runat="server" OnClick="lblcourse4_details"></asp:LinkButton><br /></font></b>
                    
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                <td style="margin-left:25px;" colspan="2" class="style1">                
                     <!--<font size="2">Introduction to Psychology: </font>-->
                     <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course5" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
              
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course5_total" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_course5_present" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course5_abs" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    


                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="lbl_course5_per" runat="server" OnClick="lblcourse5_details"></asp:LinkButton><br /></font></b>
                    
                </td>
            </tr>
           
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                <td style="margin-left:25px;" colspan="2" class="style1">                
                     <!--<font size="2">Introduction to Psychology: </font>-->
                     <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course6" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
              
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course6_total" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_course6_present" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_course6_abs" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    


                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="lbl_course6_per" runat="server" OnClick="lblcourse6_details"></asp:LinkButton><br /></font></b>
                    
                </td>
            </tr>
        </table>
    <table align="center">
               <asp:GridView ID="grd_att" runat="server" AutoGenerateColumns="false" 
             Visible="false" style="margin-top:50px" align="center" ShowFooter="true">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="ROLL NO." 
                    SortExpression="username" />
                <asp:BoundField DataField="firstname" HeaderText="FIRSTNAME" 
                    SortExpression="firstname" />
                <asp:BoundField DataField="lastname" HeaderText="LASTNAME" 
                    SortExpression="lastname" />
                <asp:BoundField DataField="doa" HeaderText="DATE" 
                    SortExpression="doa" />
                    <asp:BoundField DataField="it" HeaderText="TIME" 
                    SortExpression="it" />
                    <asp:BoundField DataField="min" HeaderText="VALID/INVALID" 
                    SortExpression="min" />
                     
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#b3b3b3" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="#B8C9EA" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />


        </asp:GridView>
    
    
    </table>

  
     
     
      
    
                         
                        
				    </div>
			        <div class="content-2">
						


                         <asp:Button ID="Button2" 
                            style="opacity:10; margin-top:11px; margin-left:934px; width:100px; height:21px" 
                            runat="server" Text="LOGOUT" onclick="Button2_Click"  ></asp:Button>
                        <table style="background-color:#E9E8EE; width: 956px; margin-top:50px;"
             cellspacing="25px" cellpadding="10px">
             <tr style="background-color:#AEBac4;color:white;font-size:20px;margin-top:-8px;padding-bottom:14px;padding-top:6px;">
             <td colspan="4" align="center">REGISTERED COURSES</td>
             </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                <td style="margin-left:25px;" class="style1">                
                     <font size="4">COURSE ID: </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4">COURSE NAME: </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4">INSTRUCTOR NAME: </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4">CREDITS: </font>
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                    <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_cid5" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_cname5" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_iname5" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_credits5" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                    <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_cid6" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_cname6" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_iname6" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_credits6" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                    <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_cid7" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_cname7" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_iname7" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_credits7" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                    <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_cid8" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_cname8" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_iname8" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_credits8" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
            </tr>
            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                    <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_cid9" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_cname9" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_iname9" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_credits9" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
            </tr>

            <tr style="font-weight:bold;font-size:13px;color:#000000;">
                    <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_cid10" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
              ID="lbl_cname10" runat="server" Font-Bold="True"></asp:Label>
                    </font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_iname10" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
                <td style="margin-left:25px;" class="style1">
                    
                    <b><font size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label
              ID="lbl_credits10" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                    
                </td>
            </tr>


            </table>

























                           

                        
                        

                        
				    </div>
			    	  
                    


                 
		        </div>
			</section>
        </div>
</form>
    </body>
</html>