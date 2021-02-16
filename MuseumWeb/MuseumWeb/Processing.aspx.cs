using MuseumWeb.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuseumWeb
{
    public partial class Processing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var args = Request.QueryString;
            string command;
            if (args.AllKeys.Contains("command"))
            {

                command = args["command"].ToString();
            }
            else
            {
                command = "get_images";
            }
            string response = "";
            switch (command)
            {
                case "get_images": response = GetImages(); break;
                case "get_adm_data": response = GetAdmData(); break;
                case "change_img": response = SetPicData(args["id"], args["number"]); break;
                case "delete_img": response = DeleteImg(args["id"]); break;
            }
            Response.AddHeader("Access-Control-Allow-Credentials","true");
            Response.AddHeader("Access-Control-Allow-Headers","Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time");
            Response.AddHeader("Access-Control-Allow-Methods","GET, POST, OPTIONS");
            Response.AddHeader("Access-Control-Allow-Origin","*");
            Response.Write(response);

        }
        private string DeleteImg(string picId)
        {
            try
            {
                var id = Int32.Parse(picId);

                using (var context = new MuseumContext())
                {
                    var imgToDelete = context.Images.Where(x => x.Id == id).FirstOrDefault();
                    context.Images.Remove(imgToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "success";
        }
        private string SetPicData(string picId, string picNumber)
        {
            try
            {

                var id = Int32.Parse(picId);
                var newNumber = Int32.Parse(picNumber);
                using (var context = new MuseumContext())
                {
                    var pic = context.Images.Where(img => img.Id == id).FirstOrDefault();

                    pic.FrameNumber = newNumber;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "success";
        }
        private string GetAdmData()
        {
            string json;
            using (var context = new MuseumContext())
            {
                json = JsonConvert.SerializeObject(context.Admins.ToList());
            }
            return json;
        }

        private static string GetImages()
        {
            string json;
            using (MuseumContext context = new MuseumContext())
            {
                var images = context.Images.ToList();
                json = JsonConvert.SerializeObject(images);
                var obj = JsonConvert.DeserializeObject<List<Model.Image>>(json);

            }
            return json;
        }

    }
}