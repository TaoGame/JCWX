<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oauth2Demo.aspx.cs" Inherits="WebDemo.Oauth2Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>网页授权获取用户基本信息</h1>
        <h2>第一步：选择类型</h2>
        <p>SnsApi_Base：无需弹窗认证，只需不弹出授权页面，直接跳转，只能获取用户openid</p>
        <p>Snsapi_userinfo：弹出授权页面，可通过openid拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息</p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">请选择</asp:ListItem>
                <asp:ListItem Value="snsapi_base">SnsApi_Base</asp:ListItem>
                <asp:ListItem Value="snsapi_userinfo">SnsApi_UserInfo</asp:ListItem>
            </asp:DropDownList><asp:Button ID="Button1" runat="server" Text="生成二维码" OnClick="Button1_Click" /></p>
        <p>请用微信扫一扫功能，扫描以下二维码：</p>
        <p>
            <asp:Image ID="Image1" Visible="false" Width="200" Height="200"  runat="server" /></p>
        <p>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
    </div>
    </form>
</body>
</html>
