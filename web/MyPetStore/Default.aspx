<%@ Page Title="My Pets Favorite Website" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Members_LoggedIn" %>
<%@ Register Src="~/Controls/RightColumn.ascx" TagName="rightColumn" TagPrefix="rr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headerPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="navMenuPH" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftColumnPH" Runat="Server">
    <p>The left column</p>
    <p>The left column</p>
    <p>The left column</p>
    <p>The left column</p>
    <p>The left column</p>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="PagePhotoPH" Runat="Server">
    <asp:Image ID="ppDefault" runat="server" AlternateText="My Pets Favorite Website" ImageUrl="~/Images/mypets.jpg" />
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="rightColumnPH" Runat="Server">

<rr:rightColumn ID="ctrlRightColumn" runat="server" />

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="mainContentPH" Runat="Server">
<h1>Welcome User</h1>

<asp:ListView runat="server" ID="ListView1" DataKeyNames="CategoryID" DataSourceID="SqlDataSource1" GroupItemCount="4">
    <EmptyItemTemplate>
        <td id="Td1" runat="server">
        </td>
    </EmptyItemTemplate>
    <ItemTemplate >
    
     <td id="Td1" runat="server" class="cItemTemplate">
    <!-- div for background image -->
    <div class="categoriesItemTemplateBackground" >
       
           <br />
         
            <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>'>
            </asp:Label><br />
            
            <a href="Items.aspx?CategoryName=<%# Eval("CategoryName")  %>" ><asp:Image ID="imgItem" ImageUrl='<%# Eval("CategoryPhoto") %>' Width="100" Height="100" runat="server" /></a>
        
       </div>
       
       </td>
    </ItemTemplate>
    <AlternatingItemTemplate >  
    
    
     <td id="Td2" runat="server" class="cAlternativeItemTemplate">
    <!-- div for background image -->
    <div class="categoriesAlternativeItemTemplateBackground">
    <!-- td for spacing and alignment -->
     
           <br />
         
            <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>'>
            </asp:Label><br />
            <a href="Items.aspx?CategoryName=<%# Eval("CategoryName")  %>" ><asp:Image ID="Image1" ImageUrl='<%# Eval("CategoryPhoto") %>' Width="100" Height="100" runat="server" /></a>
     
        
        </div>
        </td>
    </AlternatingItemTemplate>
    <EmptyDataTemplate>
        <table id="Table1" runat="server" style="">
            <tr>
                <td>
                    No data was returned.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <InsertItemTemplate>
        <td id="Td2" runat="server" style="">
            CategoryID:
            <asp:TextBox ID="CategoryIDTextBox" runat="server" Text='<%# Bind("CategoryID") %>'>
            </asp:TextBox><br />
            CategoryName:
            <asp:TextBox ID="CategoryNameTextBox" runat="server" Text='<%# Bind("CategoryName") %>'>
            </asp:TextBox><br />
            CategoryPhoto:
            <asp:TextBox ID="CategoryPhotoTextBox" runat="server" Text='<%# Bind("CategoryPhoto") %>'>
            </asp:TextBox><br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" /><br />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" /><br />
        </td>
    </InsertItemTemplate>
    <LayoutTemplate>
        <table id="Table2" runat="server">
            <tr id="Tr1" runat="server">
                <td id="Td3" runat="server">
                    <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                        <tr id="groupPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td id="Td4" runat="server" style="text-align:center;">
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="9">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                                ShowPreviousPageButton="False" />
                            <asp:NumericPagerField ButtonCount="5" />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False"
                                ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <EditItemTemplate>
        <td id="Td5" runat="server" style="">
            CategoryID:
            <asp:Label ID="CategoryIDLabel1" runat="server" Text='<%# Eval("CategoryID") %>'>
            </asp:Label><br />
            CategoryName:
            <asp:TextBox ID="CategoryNameTextBox" runat="server" Text='<%# Bind("CategoryName") %>'>
            </asp:TextBox><br />
            CategoryPhoto:
            <asp:TextBox ID="CategoryPhotoTextBox" runat="server" Text='<%# Bind("CategoryPhoto") %>'>
            </asp:TextBox><br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" /><br />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" /><br />
        </td>
    </EditItemTemplate>
    <GroupTemplate>
        <tr id="itemPlaceholderContainer" runat="server">
            <td id="itemPlaceholder" runat="server">
            </td>
        </tr>
    </GroupTemplate>
    <SelectedItemTemplate>
        <td id="Td6" runat="server" style="">
            CategoryID:
            <asp:Label ID="CategoryIDLabel" runat="server" Text='<%# Eval("CategoryID") %>'>
            </asp:Label><br />
            CategoryName:
            <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>'>
            </asp:Label><br />
            CategoryPhoto:
            <asp:Label ID="CategoryPhotoLabel" runat="server" Text='<%# Eval("CategoryPhoto") %>'>
            </asp:Label><br />
        </td>
    </SelectedItemTemplate>
</asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyPetStoreDB %>"
        SelectCommand="SELECT [CategoryID], [CategoryName], [CategoryPhoto] FROM [Categories]">
    </asp:SqlDataSource>
</asp:Content>


<asp:Content ID="Content8" ContentPlaceHolderID="footerPH" Runat="Server">
</asp:Content>

