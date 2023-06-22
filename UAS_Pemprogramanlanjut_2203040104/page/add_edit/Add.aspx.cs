using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;

using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Oracle.ManagedDataAccess.Client;

namespace UAS_Pemprogramanlanjut_2203040104.page.add_edit
{
    public partial class Add : System.Web.UI.Page
    {
        string Tns = "Data Source=(DESCRIPTION =" +
        "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-CMAMINP)(PORT = 1521))" +
        "(CONNECT_DATA =" +
        "(SERVER = DEDICATED)" +
        "(SERVICE_NAME = ORCL)));" +
        "User Id= ezar;Password=Rampage3004";
        private string TNS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Mengisi DropDownList dengan data kategori dari database
                DdCategory.DataSource = GetCategories();
                DdCategory.DataTextField = "CATEGORY"; // Kolom yang akan ditampilkan sebagai teks pada DropDownList
                DdCategory.DataValueField = "ID"; // Kolom yang akan dijadikan nilai pada DropDownList
                DdCategory.DataBind();

                DdPlace.DataSource = GetPlace();
                DdPlace.DataTextField = "PLACE_NAME"; // Kolom yang akan ditampilkan sebagai teks pada DropDownList
                DdPlace.DataValueField = "ID"; // Kolom yang akan dijadikan nilai pada DropDownList
                DdPlace.DataBind();
            }
        }
        private DataTable GetCategories()
        {


            string query = "SELECT ID, CATEGORY FROM CATEGORY";

            using (OracleConnection connection = new OracleConnection(Tns))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    DataTable categories = new DataTable();
                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(categories);
                    }
                    return categories;
                }
            }
        }
        private DataTable GetPlace()
        {

            string query = "SELECT ID, PLACE_NAME FROM PLACE";

            using (OracleConnection connection = new OracleConnection(Tns))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    DataTable categories = new DataTable();
                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(categories);
                    }
                    return categories;
                }
            }
        }
        protected void Btn_create(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection sqlcon = new OracleConnection(Tns))
                {
                    if (fileGambar.HasFile)
                    {
                        sqlcon.Open();
                        
                        // Mendapatkan nilai dari input pengguna
                        string Plantname = TxtPlantname.Text;
                        string Age = TxtAge.Text;
                        string Category = DdCategory.SelectedValue;
                        string Height = TxtHeight.Text;
                        string Place = DdPlace.SelectedValue;
                        string Price = TxtPrice.Text;
                        string Stock = TxtStock.Text;
                        // Mendapatkan UserID dari sesi


                        // Menyimpan informasi ke database

                        string query = "INSERT INTO ITEMS (PLACE_ID, CATEGORY_ID, ITEM_NAME, ITEM_AGE, ITEM_HEIGHT, ITEM_STOCK, ITEM_PRICE, ITEM_IMAGE) VALUES (:PlaceId, :CategoryId, :ItemName, :ItemAge, :ItemHeight, :ItemStock, :ItemPrice, :ItemImage)";

                        OracleCommand command = new OracleCommand(query, sqlcon);
                        string linkpath = "~/ImageUpload/" + System.IO.Path.GetFileName(fileGambar.FileName);
                        fileGambar.SaveAs(Server.MapPath("/ImageUpload/") + System.IO.Path.GetFileName(fileGambar.FileName));
                        // Mendapatkan nilai dari input pengguna
                        command.Parameters.Add(":PlaceId", Place);
                        command.Parameters.Add(":CategoryId", Category);
                        command.Parameters.Add(":ItemName", Plantname);
                        command.Parameters.Add(":ItemAge", Age);
                        command.Parameters.Add(":ItemHeight", Height);
                        command.Parameters.Add(":ItemStock", Stock);
                        command.Parameters.Add(":ItemPrice", Price);
                        command.Parameters.Add(":ItemImage", linkpath);
                        command.ExecuteNonQuery();
                        sqlcon.Close();
                        // Data berhasil ditambahkan, lakukan tindakan lainnya (misalnya, redirect ke halaman sukses)
                        Response.Redirect("~/page/Shop.aspx");

                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}