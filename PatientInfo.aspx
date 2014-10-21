<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="PatientInfo.aspx.cs" Inherits="Provider_PatientInfo" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>List of your patients</h1>
    <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" CssClass="EU_DataTable" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Last Name" DataField="LastName"
                    SortExpression="LastName"></asp:BoundField>
                <asp:BoundField HeaderText="Middle Name" DataField="MiddleName"
                    SortExpression="MiddleName"></asp:BoundField>
                <asp:BoundField HeaderText="First Name" DataField="FirstName"
                    SortExpression="FirstName"></asp:BoundField>
                <asp:BoundField HeaderText="Gender" DataField="Gender"
                    SortExpression="Gender"></asp:BoundField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Provider/ParentGuardianInfo.aspx?Id={0}&FirstName={1}&LastName={2}",
                    HttpUtility.UrlEncode(Eval("PatientId").ToString()), HttpUtility.UrlEncode(Eval("FirstName").ToString()), HttpUtility.UrlEncode(Eval("LastName").ToString())) %>'
                            Text='Show Family Details' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Provider/TreatmentRecords.aspx?Id={0}&FirstName={1}&LastName={2}",
                    HttpUtility.UrlEncode(Eval("PatientId").ToString()), HttpUtility.UrlEncode(Eval("FirstName").ToString()), HttpUtility.UrlEncode(Eval("LastName").ToString())) %>'
                            Text='Show Treatment Record' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

