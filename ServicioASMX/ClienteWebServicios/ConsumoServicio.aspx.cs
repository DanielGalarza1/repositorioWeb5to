using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClienteWebServicios.ProxyListaUsuario;

namespace ClienteWebServicios
{
    public partial class ConsumoServicio : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            WebServiceUsuariosSoapClient ws = new WebServiceUsuariosSoapClient();
            GridView1.DataSource = ws.Listado();
            GridView1.DataBind();
        }
    }
}