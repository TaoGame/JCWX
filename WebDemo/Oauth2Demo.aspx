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
        <h3>您好：</h3>
        <b>昵称：</b><em><%= WeiXinUser.Nickname %></em><br />
        <b>openid：</b><em><%= WeiXinUser.OpenId %></em><br />
        <b>Code</b><em><%= this.Code %></em>

    </div>
    </form>
</body>
</html>
