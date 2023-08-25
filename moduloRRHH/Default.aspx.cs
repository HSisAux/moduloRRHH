using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace moduloRRHH
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("lblPaginaTitulo")).Text = "inicio";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + fileName));
        }
    }
}