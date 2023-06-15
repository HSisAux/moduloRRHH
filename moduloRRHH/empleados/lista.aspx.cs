using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace moduloRRHH
{
    public partial class lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("lblPaginaTitulo")).Text = "empleados";
        }

        protected void ddRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            (ListView1.FindControl("DataPager1") as DataPager).PageSize = Convert.ToInt32(ddRegistros.SelectedValue);
            //BindGridContacto();
        }
    }
}