<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RunCalculator.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Run Calculator</h1>
    <form id="form1" runat="server">
        <div>
            <p>Enter a recent finish time for a race you completed:</p>
            <asp:Label ID="Label1" runat="server" Text="What distance did you run?"></asp:Label>
            <asp:DropDownList ID="lstRecentRace" runat="server">
                <asp:ListItem Selected="True" ID="li5K" Text="5K" Value="5000"></asp:ListItem>
                <asp:ListItem ID="li10K" Text="10K" Value="10000"></asp:ListItem>
                <asp:ListItem ID="liHalf" Text="Half Marathon" Value="21097.5"></asp:ListItem>
                <asp:ListItem ID="liMarathon" Text="Marathon" Value="42195"></asp:ListItem>
            </asp:DropDownList>
            <p>How many miles do you run per week?</p>
            <asp:DropDownList ID="lstWeeklyMileage" runat="server">
                <asp:ListItem Selected="True" ID="li0to10" Text="0-10 miles" Value="10"></asp:ListItem>
                <asp:ListItem ID="li11to25" Text="11-25" Value="25"></asp:ListItem>
                <asp:ListItem ID="li26to50" Text="26-50" Value="50"></asp:ListItem>
                <asp:ListItem ID="liOver51" Text="51+" Value="51"></asp:ListItem>
            </asp:DropDownList>
            <p>What was your finish time?</p>
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell>
                        <asp:Label ID="lblHours" runat="server" Text="Hours"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblMin" runat="server" Text="Minutes"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblSec" runat="server" Text="Seconds"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:TextBox ID="txtHours" runat="server" MaxLength="2" Width="20" Text="00"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtMin" runat="server" MaxLength="2" Width="20" Text="00"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSec" runat="server" MaxLength="2" Width="20" Text="00"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <asp:Button ID="btnCalcTimes" runat="server" Text="Estimate race times" OnClick="btnCalcTimes_Click" />
        <div>
            <asp:Label ID="lblTemp" runat="server" Text="Race time here"></asp:Label>
            <asp:GridView ID="tblEstTime" runat="server" AutoGenerateColumns="true" BorderWidth="1" BorderColor="DarkSlateGray">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
