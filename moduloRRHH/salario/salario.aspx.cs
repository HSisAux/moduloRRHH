using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace moduloRRHH.salario
{
    public partial class salario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ((Label)Master.FindControl("lblPaginaTitulo")).Text = "Salarios";
        }

        protected void ddRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}