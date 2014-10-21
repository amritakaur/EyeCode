<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="TreatmentRecords.aspx.cs" Inherits="Provider_TreatmentRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Showing treatment record for <asp:label runat="server" ID="lblPatient"></asp:label> </h1>
    <div>
        <asp:GridView ID="GridView1" runat="server" CssClass="EU_DataTable" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="DateConducted" DataField="DateConducted" SortExpression="DateConducted"></asp:BoundField>
                <asp:BoundField HeaderText="SensitivityToLight" DataField="SensitivityToLight" SortExpression="SensitivityToLight"></asp:BoundField>
                <asp:BoundField HeaderText="DislikeTo3DMovies" DataField="DislikeTo3DMovies" SortExpression="DislikeTo3DMovies"></asp:BoundField>
                <asp:BoundField HeaderText="UsesGlasses" DataField="UsesGlasses" SortExpression="UsesGlasses"></asp:BoundField>
                <asp:BoundField HeaderText="EyeFatigue" DataField="EyeFatigue" SortExpression="EyeFatigue"></asp:BoundField>
                <asp:BoundField HeaderText="ReadingForgetfulness" DataField="ReadingForgetfulness" SortExpression="ReadingForgetfulness"></asp:BoundField>
                <asp:BoundField HeaderText="ReadSlowly" DataField="ReadSlowly" SortExpression="ReadSlowly"></asp:BoundField><asp:BoundField HeaderText="ReadSlowly" DataField="ReadSlowly" SortExpression="ReadSlowly"></asp:BoundField>
                <asp:BoundField HeaderText="BlurredVision" DataField="BlurredVision" SortExpression="BlurredVision"></asp:BoundField>
                <asp:BoundField HeaderText="DoubleVision" DataField="DoubleVision" SortExpression="DoubleVision"></asp:BoundField>
                <asp:BoundField HeaderText="JumpingLines" DataField="JumpingLines" SortExpression="JumpingLines"></asp:BoundField>
                <asp:BoundField HeaderText="HurtingEyes" DataField="HurtingEyes" SortExpression="HurtingEyes"></asp:BoundField>
                <asp:BoundField HeaderText="SoreEyes" DataField="SoreEyes" SortExpression="SoreEyes"></asp:BoundField>
                <asp:BoundField HeaderText="Focus" DataField="Focus" SortExpression="Focus"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

