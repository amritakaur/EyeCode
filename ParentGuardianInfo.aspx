<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="ParentGuardianInfo.aspx.cs" Inherits="Provider_ParentGuardianInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Showing family of  <asp:label runat="server" ID="lblPatient"></asp:label> </h1>
    <div>
        <asp:GridView ID="GridView1" runat="server" CssClass="EU_DataTable" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Last Name" DataField="LastName"
                    SortExpression="LastName"></asp:BoundField>
                <asp:BoundField HeaderText="Middle Name" DataField="MiddleName"
                    SortExpression="MiddleName"></asp:BoundField>
                <asp:BoundField HeaderText="First Name" DataField="FirstName"
                    SortExpression="FirstName"></asp:BoundField>
                <asp:BoundField HeaderText="Phone" DataField="Phone"
                    SortExpression="Phone"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

