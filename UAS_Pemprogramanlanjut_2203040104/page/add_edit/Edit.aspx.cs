using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azure;
using Oracle.ManagedDataAccess.Client;

namespace UAS_Pemprogramanlanjut_2203040104.page.add_edit
{
    public partial class Edit : System.Web.UI.Page
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
                // Mendapatkan ID dari parameter URL atau sesuai mekanisme yang digunakan
                int id = Convert.ToInt32(Request.QueryString["id"]);

                // Mengambil data dari database berdasarkan ID
                // Misalnya, lakukan query SELECT untuk mendapatkan data dari tabel
                string query = "SELECT * FROM ITEMS WHERE ID = :ID";

                using (OracleConnection connection = new OracleConnection(Tns))
                {
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":ID", OracleDbType.Int32).Value = id;

                        connection.Open();
                        OracleDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Mengisi nilai-nilai ke elemen-elemen input di halaman edit
                            TxtPlantname.Text = reader["ITEM_NAME"].ToString();
                            TxtHeight.Text = reader["ITEM_HEIGHT"].ToString();
                            TxtPrice.Text = reader["ITEM_PRICE"].ToString();
                            TxtStock.Text = reader["ITEM_STOCK"].ToString();
                            TxtAge.Text = reader["ITEM_AGE"].ToString();
                            DdPlace.SelectedValue = reader["PLACE_ID"].ToString();
                            DdCategory.SelectedValue = reader["CATEGORY_ID"].ToString();


                            // ...
                        }

                        reader.Close();
                    }

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
        protected void Btn_edit(object sender, EventArgs e)
        {
            // Mendapatkan ID dari parameter URL atau sesuai mekanisme yang digunakan
            int id = Convert.ToInt32(Request.QueryString["id"]);

            // Mendapatkan nilai-nilai yang diubah oleh pengguna dari elemen-elemen input
            string Plantname = TxtPlantname.Text;
            string Age = TxtAge.Text;
            string Category = DdCategory.SelectedValue;
            string Height = TxtHeight.Text;
            string Place = DdPlace.SelectedValue;
            string Price = TxtPrice.Text;
            string Stock = TxtStock.Text;
            // ...

            // Mendapatkan nilai file yang diunggah oleh pengguna
            HttpPostedFile postedFile = fileGambar.PostedFile;
            string fileName = string.Empty;

            // Cek apakah ada file yang diunggah
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                // Hapus file sebelumnya jika ada
                string previousFilePath = GetFilePathFromDatabase(id); // Fungsi untuk mendapatkan path file sebelumnya dari database berdasarkan ID
                if (!string.IsNullOrEmpty(previousFilePath))
                {
                    DeleteFile(previousFilePath); // Fungsi untuk menghapus file
                }

                // Simpan file yang diunggah ke server
                fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Server.MapPath("~/ImageUpload/") + fileName;
                postedFile.SaveAs(filePath);
            }

            // Melakukan query UPDATE ke database untuk mengupdate data yang sesuai
            string query = "UPDATE ITEMS SET PLACE_ID = :PlaceId, CATEGORY_ID = :CategoryId, ITEM_NAME = :ItemName, ITEM_AGE = :ItemAge, ITEM_HEIGHT = :ItemHeight, ITEM_STOCK = :ItemStock, ITEM_PRICE = :ItemPrice";
            if (!string.IsNullOrEmpty(fileName))
            {
                query += ", ITEM_IMAGE = :ItemImage";
            }
            query += " WHERE ID = :ID";

            using (OracleConnection connection = new OracleConnection(Tns))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":PlaceId", Place);
                    command.Parameters.Add(":CategoryId", Category);
                    command.Parameters.Add(":ItemName", Plantname);
                    command.Parameters.Add(":ItemAge", Age);
                    command.Parameters.Add(":ItemHeight", Height);
                    command.Parameters.Add(":ItemStock", Stock);
                    command.Parameters.Add(":ItemPrice", Price);
                    command.Parameters.Add(":ID", OracleDbType.Int32).Value = id;

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        command.Parameters.Add(":ItemImage", fileName);
                    }

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Data berhasil diupdate, lakukan tindakan lainnya (misalnya, redirect ke halaman sukses)
                        Response.Redirect("~/page/Shop.aspx");
                    }
                    else
                    {
                        // Gagal mengupdate data, tampilkan pesan error atau lakukan tindakan lainnya
                    }
                }
            }
        }
        private string GetFilePathFromDatabase(int id)
        {
            string filePath = string.Empty;

            // Melakukan query SELECT untuk mendapatkan path file dari database berdasarkan ID
            string query = "SELECT ITEM_IMAGE FROM ITEMS WHERE ID = :ID";

            using (OracleConnection connection = new OracleConnection(Tns))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":ID", OracleDbType.Int32).Value = id;

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        filePath = result.ToString();
                    }
                }
            }

            return filePath;
        }
        private void DeleteFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string fullPath = Server.MapPath("~/ImageUpload/") + filePath;

                // Hapus file jika ada
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }
    }
}