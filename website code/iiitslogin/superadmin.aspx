<%@ Page Language="C#" AutoEventWireup="true" CodeFile="superadmin.aspx.cs" Inherits="superadmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
					height: 1360px;
					margin: 0;
                    top: 0px;
                    left: 0px;
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
            target: "txtdatewise11",
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
		        <label for="tab-1" class="tab-label-1">Attendance</label>
		
	            <!--<input id="tab-2" type="radio" name="radio-set" class="tab-selector-2" />
		        <label for="tab-2" class="tab-label-2">Courses Taught</label>-->
		
<!--	            <input id="tab-3" type="radio" name="radio-set" class="tab-selector-3" />
		        <label for="tab-3" class="tab-label-3">Student History</label>-->
			
<!--	            <input id="tab-4" type="radio" name="radio-set" class="tab-selector-4" />
		        <label for="tab-4" class="tab-label-4">Attendance Details</label>-->
            
            
			    <div class="clear-shadow"></div>
			
		        <div class="content">
			        <div class="content-1">
                    
             
                         


                        <asp:Label ID="lb11" style="margin-top:10px" runat="server" Text="Label"></asp:Label>
   
     
     
  

  <asp:Button ID="btn_logout_admin1" 
                            style="opacity:10; margin-top:11px; margin-left:934px; width:100px; height:21px" 
                            runat="server" Text="LOGOUT" OnClick="btn_adminlogout_click1"></asp:Button>
                  <table style="background-color:#E9E8EE; width: 956px;margin-top:50px;"
             cellspacing="25px" cellpadding="10px">
             <tr style="background-color:#AEBac4;color:white;font-size:20px;margin-top:-8px;padding-bottom:14px;padding-top:6px;">
             <td colspan="4" align="center">Attendance Details</td>
             </tr>
            
                
               <tr style="font-weight:bold;font-size:13px;color:#000000;">
               <td>
                    <asp:Label ID="lbladminmode" runat="server" Text="SELECT YOUR MODE :" Visible="true"></asp:Label>
                
                </td>
                <td style="margin-left:25px;" class="style1">
                    <asp:DropDownList ID="ddl_att_admin1" style="margin-left:77px;margin-top:7px;" runat="server"    >
                            <asp:ListItem value="">Select</asp:ListItem>
                            <asp:ListItem value="1">Course-Wise Attendance</asp:ListItem>
                            <asp:ListItem value="2">Date-Wise Attendance</asp:ListItem>
                            <asp:ListItem value="3">Student Search</asp:ListItem> 
                    </asp:DropDownList>

                    </td>


                    <td style="margin-left:336px;margin-top:115px; opacity:10;" class="style2 margin-top">
                                    
                    <asp:Button ID="btn_att_admin1" style="opacity:10; margin-top:137px; margin-left:826px; width:100px; height:21px" runat="server" Text="Submit" OnClick="btn_click_att_admin1" ></asp:Button>
                    
                    
                </td>
                </tr>
                <tr>
                <td>
                    <asp:Label ID="lbladminmode1" runat="server" Text="SELECT YOUR SUBJECT :" Visible="false"></asp:Label>
                
                </td>
                <td>             


                            <asp:Label
                            ID="lblc1" runat="server" Font-Bold="True"></asp:Label> 
                            <asp:DropDownList ID="ddl_course1" style="margin-left:77px" runat="server"  Visible="false"  >
                            <asp:ListItem value="">Select</asp:ListItem>
                            <asp:ListItem value="1">Maths II</asp:ListItem>  
                           <asp:ListItem value="2">Data Structures</asp:ListItem>
                           <asp:ListItem value="3">Basic Electronics Circuits</asp:ListItem>
                           <asp:ListItem value="4">Computer Organization</asp:ListItem>
                           <asp:ListItem value="5">ITWS II</asp:ListItem>
                           <asp:ListItem value="6">Humanities[Communication 2]</asp:ListItem>
                           <asp:ListItem value="7">Maths III</asp:ListItem>
                           <asp:ListItem value="8">Computer Architecture</asp:ListItem>
                           <asp:ListItem value="9">Fundamentals of Communication</asp:ListItem>
                           <asp:ListItem value="10">Computer and Communication Networks</asp:ListItem>
                           <asp:ListItem value="11">Economic Fundamentals</asp:ListItem>
                           <asp:ListItem value="12">Humanities[Communication 2 + Thinking Skills]</asp:ListItem>
                           
                            </asp:DropDownList>

                </td>
                <td>
                
                    <asp:Button ID="btn_course_admin1" style="opacity:10; margin-top:178px; margin-left:826px; width:100px; height:21px" runat="server" Text="Submit"  Visible="false" OnClick="btn_course_admin_selected1"></asp:Button>
                    
             
             
             </td>
             </tr>
             <tr>
             <td>
                    <asp:Label ID="lbladminmode2" runat="server" Text="SELECT YOUR SUBJECT :" Visible="true"></asp:Label>
                
                </td>
              <td style="margin-left:25px" class="style-1">             


                            <asp:Label
                            ID="Label1" runat="server" Font-Bold="True" Visible="false"></asp:Label> 
                            <asp:DropDownList ID="ddl_studentcourse1" style="margin-left:71px;margin-top:-23x" runat="server"  Visible="false"  >
                            <asp:ListItem value="">Select</asp:ListItem>
                            <asp:ListItem value="1">Maths II</asp:ListItem>  
                           <asp:ListItem value="2">Data Structures</asp:ListItem>
                           <asp:ListItem value="3">Basic Electronics Circuits</asp:ListItem>
                           <asp:ListItem value="4">Computer Organization</asp:ListItem>
                           <asp:ListItem value="5">ITWS II</asp:ListItem>
                           <asp:ListItem value="6">Humanities[Communication 2]</asp:ListItem>
                           <asp:ListItem value="7">Maths III</asp:ListItem>
                           <asp:ListItem value="8">Computer Architecture</asp:ListItem>
                           <asp:ListItem value="9">Fundamentals of Communication</asp:ListItem>
                           <asp:ListItem value="10">Computer and Communication Networks</asp:ListItem>
                           <asp:ListItem value="11">Economic Fundamentals</asp:ListItem>
                           <asp:ListItem value="12">Humanities[Communication 2 + Thinking Skills]</asp:ListItem>
                            </asp:DropDownList>

                </td>
            </tr>
            <tr>   
             <td>
                <asp:Label
              ID="lblroll1" runat="server" Font-Bold="True" Text="ENTER THE ROLL NO :" Visible="false"></asp:Label>
             </td>
        <td>
        <asp:TextBox ID="txtusersearch1" runat="server" style="opacity:10;margin-top:250px;margin-left:392px" height="20px" Visible="false"></asp:TextBox>
        </td>
         <td>
                
                    <asp:Button ID="btn_search1" style="opacity:10; margin-top:250px; margin-left:826px; width:100px; height:21px" runat="server" Text="Submit"  Visible="false" OnClick="btn_search_selected1"></asp:Button>
                    
             
             
             </td>
        </tr>

         <tr>
          <td>
                    <asp:Label ID="lbladminmode6" runat="server" Text="SELECT YOUR SUBJECT :" Visible="false"></asp:Label>
                
                </td>
              <td>             


                            
                            <asp:DropDownList ID="ddldatewise1" style="margin-left:77px;" runat="server"  Visible="false"  >
                            <asp:ListItem value="">Select</asp:ListItem>
                            <asp:ListItem value="1">Maths II</asp:ListItem>  
                           <asp:ListItem value="2">Data Structures</asp:ListItem>
                           <asp:ListItem value="3">Basic Electronics Circuits</asp:ListItem>
                           <asp:ListItem value="4">Computer Organization</asp:ListItem>
                           <asp:ListItem value="5">ITWS II</asp:ListItem>
                           <asp:ListItem value="6">Humanities[Communication 2]</asp:ListItem>
                           <asp:ListItem value="7">Maths III</asp:ListItem>
                           <asp:ListItem value="8">Computer Architecture</asp:ListItem>
                           <asp:ListItem value="9">Fundamentals of Communication</asp:ListItem>
                           <asp:ListItem value="10">Computer and Communication Networks</asp:ListItem>
                           <asp:ListItem value="11">Economic Fundamentals</asp:ListItem>
                           <asp:ListItem value="12">Humanities[Communication 2 + Thinking Skills]</asp:ListItem>
                            </asp:DropDownList>

                </td>
               
            
        
         <td>
                
                    <asp:Button ID="btndatewise1" style="opacity:10; margin-top:272px; margin-left:826px; width:100px; height:21px" runat="server" Text="Submit"  Visible="false" OnClick="btndatewise1_click"></asp:Button>
                    
             
             
             </td>
        </tr>

        <tr>
        <td>
                    <asp:Label ID="lbladminmode4" runat="server" Text="ENTER THE DATE (yyyy-mm-dd) :" Visible="false"></asp:Label>
                
                </td>
                <td>
        <asp:TextBox ID="txtdatewise1" runat="server" style="opacity:10;margin-top:266px;margin-left:440px" height="20px" Visible="false"></asp:TextBox>
        </td>
        </tr>





        </table>
       
                <!--<td style="margin-left:25px;" colspan="2" class="style1">                
                     <font size="4"><asp:Label
              ID="lblrollno" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4"><asp:Label
              ID="lblfname" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4"><asp:Label
              ID="lbllname" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4"><asp:Label
              ID="lbldate" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4"><asp:Label
              ID="lblintime" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>
                <td style="margin-left:25px;" class="style1">
                     <font size="4"><asp:Label
              ID="lblvalid" runat="server" Font-Bold="True"></asp:Label> </font>
                </td>-->
                <table align="center">
                <asp:GridView ID="grdviewstudentwise1" ShowFooter="true" runat="server" AutoGenerateColumns="false" style="opacity:10;margin-top:50px" align="center" >
                            
                            <Columns>
                <asp:BoundField DataField="username" HeaderText="ROLL NO." 
                    SortExpression="username" />
                <asp:BoundField DataField="firstname" HeaderText="FIRSTNAME" 
                    SortExpression="firstname" />
                <asp:BoundField DataField="lastname" HeaderText="LASTNAME" 
                    SortExpression="lastname" />
                <asp:BoundField DataField="doa" HeaderText="DATE" 
                    SortExpression="doa" />
                    <asp:BoundField DataField="it" HeaderText="IN-TIME" 
                    SortExpression="it" />
                     <asp:BoundField DataField="min" HeaderText="VALID/INVALID" 
                    SortExpression="min" />
                              
                   <asp:TemplateField HeaderStyle-Width="40" HeaderText="CHANGE" Visible="true">
    <ItemTemplate>
        <asp:LinkButton ID="lnk_btn1" runat="server" CommandArgument='<%#Bind("min")%>' >EDIT</asp:LinkButton>
    </ItemTemplate>
</asp:TemplateField>
                     
                     
            </Columns>

            




                        <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#b3b3b3" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <PagerStyle BackColor="#B8C9EA" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

                        
                        </asp:GridView>

      

      <asp:Label ID="lblTotal" runat="server"></asp:Label>
				
                



           
             <asp:GridView ID="grd_coursewise1" runat="server" AutoGenerateColumns="false" 
             Visible="false" style="opacity:10px;margin-top:50px" align="center" ShowFooter="true">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="ROLL NO." 
                    SortExpression="username" />
                <asp:BoundField DataField="firstname" HeaderText="FIRSTNAME" 
                    SortExpression="firstname" />
                <asp:BoundField DataField="lastname" HeaderText="LASTNAME" 
                    SortExpression="lastname" />
                <asp:BoundField DataField="dat" HeaderText="DATE" 
                    SortExpression="dat" />
                    <asp:BoundField DataField="tim" HeaderText="TIME" 
                    SortExpression="tim" />
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
			    	  
                    


                 
		        </div>
			</section>
        </div>
</form>
    </body>
</html>