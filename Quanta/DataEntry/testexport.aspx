<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testexport.aspx.cs" Inherits="Quanta.DataEntry.testexport" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="/assets/css/app.min.css">
   <link rel="stylesheet" href="/assets/bundles/jquery-selectric/selectric.css">
  <!-- For data Table -->
  <link rel="stylesheet" href="/assets/bundles/datatables/datatables.min.css">
  <link rel="stylesheet" href="/assets/bundles/datatables/DataTables-1.10.16/css/dataTables.bootstrap4.min.html">
     <script src="/assets/js/app.min.js"></script>
       <script src="/assets/bundles/datatables/datatables.min.js"></script>
  <script src="/assets/bundles/datatables/DataTables-1.10.16/js/dataTables.bootstrap4.min.js"></script>

 
  <script src="/assets/bundles/datatables/export-tables/dataTables.buttons.min.js"></script>
  <script src="/assets/bundles/datatables/export-tables/buttons.flash.min.js"></script>
  <script src="/assets/bundles/datatables/export-tables/jszip.min.js"></script>
  
  <script src="/assets/bundles/datatables/export-tables/vfs_fonts.js"></script>
  <script src="/assets/bundles/datatables/export-tables/buttons.print.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
   
    <table class="table table-striped table-hover" id='tableExport'>
                      <thead>
                        <tr>
                        
                           
                          <th scope="col">Emp. ID</th>
                         
                          <th scope="col">DOB/Age</th>
                         
                          <th scope="col">DOJ</th>
                          <th scope="col">Gender</th>
                          <th scope="col">Department</th>
                          <th scope="col">Grade</th>
                           <th scope="col">Manager Emp.ID</th>
                            <th scope="col">Latest Perf Rating</th>
                           
                              <th scope="col">TFP</th>
                         <th class="notexport"  scope="col">Remarks</th>
                        
                        </tr>
                      </thead>
                      <tbody>
                         <asp:Repeater ID="rptincorrect" runat="server"  >
             
                        <ItemTemplate>
                        <tr>
                      
                         
                          <td>
                           <asp:Label ID="lblempid" runat="server" Text=' <%#Eval("empid") %>'></asp:Label>
                         </td>
                          <td>
                     
                          <asp:Label ID="lblage" runat="server" Text=' <%#Eval("DOB/Age") %>'></asp:Label>
                    <asp:TextBox ID="txtdob" runat="server" Visible="false" ></asp:TextBox>
                    </td>
                     
                          <td>  <asp:Label ID="lbldoj" runat="server" Text=' <%# string.Format("{0:ddd MMM yyyy}", Eval("doj")) %>'></asp:Label>
                    <asp:TextBox ID="txtdoj" runat="server" Visible="false" Text='<%# string.Format("{0:ddd MMM yyyy}", Eval("doj")) %>'></asp:TextBox></td>
                          <td>
                           <asp:Label ID="lblgender" runat="server" Text=' <%#Eval("gender") %>'></asp:Label>
                        </td>
                          <td>
                           <asp:Label ID="lbldept" runat="server" Text=' <%#Eval("dept") %>'></asp:Label>
                          
                         </td>
                          <td>
                           <asp:Label ID="lblGrdae" runat="server" Text=' <%#Eval("Grdae") %>'></asp:Label>
                    <asp:TextBox ID="txtGrdae" runat="server"  Text=' <%#Eval("Grdae") %>' Visible="false"></asp:TextBox>
                          </td>
                          <td>
                           <asp:Label ID="lblManagerID" runat="server" Text=' <%#Eval("ManagerID") %>'></asp:Label>
                         </td>
                          <td>
                           <asp:Label ID="lblPerfRating" runat="server" Text=' <%#Eval("PerfRating") %>'></asp:Label>
                    <asp:TextBox ID="txtPerfRating" runat="server" Visible="false" Text='<%#Eval("PerfRating") %>'></asp:TextBox>
                          </td>
                        
                          <td>
                           <asp:Label ID="lblTFP" runat="server" Text=' <%#Eval("TFP") %>'></asp:Label>
                    <asp:TextBox ID="txtTFP" runat="server" Visible="false" Text=' <%#Eval("TFP") %>'></asp:TextBox>
                   
                          
                          
                          </td>
                          
                             <td><%#Eval("Remarks")%></td>
                        </tr>
                        </ItemTemplate>
                        <FooterTemplate>  </FooterTemplate>
                        </asp:Repeater></tbody>
                    </table>
       
 
    </div>
    <script>


        function xport() {
            var filename = window.location.search.substring(4);
            var myDataTable1 = $('#tableExport').DataTable({
                dom: 'Bfrtip',
                buttons: [
      {
          extend: 'excelHtml5',
          filename: filename,

          title: null

      }
   ]
            });

            // Use jQuery selector (in this case looking for known class name) for the hidden button, then trigger it's action event.
            myDataTable1.buttons('.buttons-excel').trigger();

        }
    </script>
    </form>
</body>
</html>
