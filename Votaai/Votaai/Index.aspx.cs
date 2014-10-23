using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Votaai
{
    public partial class Index : System.Web.UI.Page
    {

        protected void Page_Unload(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(),"labelcont", "IncrementLabel()");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //teste para commit
        }
    }
}