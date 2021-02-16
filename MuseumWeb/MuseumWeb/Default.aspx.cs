using MuseumWeb.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuseumWeb
{
    public partial class Default : System.Web.UI.Page
    {
        private static HttpPostedFile lastImg;
        private static byte[] lastImgBytes;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GoGame_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MuseumGame/Index.html");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string adminName = "";
            using (var context = new MuseumContext())
            {
                var admins = context.Admins.ToList();

                var enteredAdmin = admins.Where(x => x.Login == login.Text && x.Password == password.Text).FirstOrDefault();
                if (enteredAdmin!=null)
                {
                    adminName=enteredAdmin.Name;
                }
            }
            if(adminName!="")
            {
                Label3.Text = $"Добро пожаловать, {adminName}!";
                login.Enabled = false;
                password.Enabled = false;
                fileUpload.Visible = true;
                AddImages.Visible = true;
                namePic.Visible = true;
                descriptionPic.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;

                showImage.Visible = true;
                Label1.Text = "";
                lastImg = null;
                lastImgBytes = null;

            }
            else
            {
                Label1.Text = "Неверный логин или пароль!";
            }
        }
        private string BytesToImg(byte[] bytes)
        {
            ;
            return Convert.ToBase64String(bytes);

        }

        protected void AddImages_Click(object sender, EventArgs e)
        {

            showImage_Click(new object(), new EventArgs());
            if (lastImgBytes == null || lastImgBytes.Length == 0)
            {
                return;
            }



            using (MuseumContext context = new MuseumContext())
            {
                var imgs = context.Images;
                var img = new Model.Image();
                img.FrameNumber = -1;

                img.Name = namePic.Text == ""? "Нет названия":namePic.Text;
                img.Description= descriptionPic.Text == ""? "Описание отсутствует":descriptionPic.Text;
                img.Picture = lastImgBytes;
                imgs.Add(img);
                context.SaveChanges();
            }
            lastImgBytes = default;
            lastImg = null;
        }

        protected void showImage_Click(object sender, EventArgs e)
        {
            string fileName = fileUpload.PostedFile.FileName;
            var imgString = BytesToImg(fileUpload.FileBytes);


            if (fileName == "" && lastImgBytes != null)
            {
                fileName = lastImg.FileName;
                imgString = BytesToImg(lastImgBytes);

            }
            else
            {
                lastImg = fileUpload.PostedFile;
                lastImgBytes = fileUpload.FileBytes;

            }
            if ( fileName.EndsWith(".jpg") || fileName.EndsWith(".png") || fileName.EndsWith(".jpeg"))
            {
                Label2.Text = "";
                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                img.Attributes.Add("src", $"data:image;base64,{imgString}");
                Controls.Add(img);

            }
            else
            {
                Label2.Text = "Ошибочное расширение файла (необходимо: jpeg, jpg, png)";
            }
        }
    }
}