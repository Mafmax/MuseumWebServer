<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MuseumWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="GoGame" runat="server" Text="Перейти в музей" OnClick="GoGame_Click" />
            <br />

            <asp:Label ID="lbllog" runat="server">Имя пользователя:</asp:Label>
            <asp:TextBox ID="login" runat="server"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblpas" runat="server">Пароль:</asp:Label><asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Войти" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server" ForeColor="#CC3300"></asp:Label>
            <asp:Label ID="Label3" runat="server" ForeColor="Black"></asp:Label>
            <br />



                    <asp:FileUpload ID="fileUpload" runat="server" Visible="False" />

                    <asp:Button ID="showImage" runat="server" OnClick="showImage_Click" Text="Показать изображение" Visible="False" />
                    <asp:Label ID="Label2" runat="server" ForeColor="#CC3300"></asp:Label>
                    <br />

                    <asp:Button ID="AddImages" runat="server" Text="Добавить изображение" Visible="False" OnClick="AddImages_Click" />


            <br />
            <asp:Label ID="Label4" runat="server" Text="Название:" Visible="False"></asp:Label>
            <asp:TextBox ID="namePic" runat="server" Visible="False" Width="161px">Три богатыря</asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Описание:" Visible="False"></asp:Label>
            <asp:TextBox ID="descriptionPic" runat="server" Width="645px" Visible="False">Это богатыри и их три</asp:TextBox>


        </div>
    </form>
</body>
</html>
