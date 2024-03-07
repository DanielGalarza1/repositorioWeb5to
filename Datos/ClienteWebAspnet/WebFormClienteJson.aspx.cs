using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Data;

namespace ClienteWebAspnet
{
    public partial class WebFormClienteJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string objJson = (new WebClient())
                .DownloadString("http://localhost:53096/wcfProductos.svc/getProductos");
            GridView1.DataSource = JsonConvert.DeserializeObject<System.Data.DataTable>(objJson);
            GridView1.DataBind();
        }
    }
}