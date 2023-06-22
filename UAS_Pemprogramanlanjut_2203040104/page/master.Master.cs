using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UAS_Pemprogramanlanjut_2203040104
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie userCookie = Request.Cookies["UserFullName"];
                if (userCookie != null)
                {
                    string userFullName = userCookie.Value;
                    // Mengubah teks tombol login menjadi nama pengguna yang tersimpan dalam cookie
                    Btnlogin.Text = userFullName;
                }
                else
                {
                    // Tombol login tetap menjadi "Login" jika cookie tidak ada
                    Btnlogin.Text = "Login";
                }
            }
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/page/auth/Login.aspx");
        }
    }
}