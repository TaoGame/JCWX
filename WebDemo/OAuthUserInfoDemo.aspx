<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OAuthUserInfoDemo.aspx.cs" Inherits="WebDemo.OAuthUserInfoDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        input[type=submit] {
            width:90%;
            height:1.4em;
            font-size:0.9em;
        }
        body {
            font-size:4em;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:90%;">
        <p>Code:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>
        <p><asp:Button ID="Button1" runat="server" Text="获取Token" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Text="刷新Token" OnClick="Button2_Click" /></p>
        <p>AccessToken:<asp:Label ID="Label2" runat="server" Text=""></asp:Label></p>
        <p>RefreshToken:<asp:Label ID="Label3" runat="server" Text=""></asp:Label></p>
        <p><asp:Button ID="Button3" runat="server" Text="获取用户信息" OnClick="Button3_Click" /></p>
        <p>用户昵称：<asp:Label ID="Label4" runat="server" Text=""></asp:Label></p>
        <p>用户ID：<asp:Label ID="Label5" runat="server" Text=""></asp:Label></p>
        <p>错误信息：<asp:Label ID="Label6" runat="server" Text=""></asp:Label></p>
    </div>
    </form>
</body>
</html>
