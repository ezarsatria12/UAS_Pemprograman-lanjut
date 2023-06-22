using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;

namespace UAS_Pemprogramanlanjut_2203040104
{
    public partial class WebForm1 : System.Web.UI.Page
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
                if (Session["UserFullName"] != null)
                {
                    btn_add.Visible = true;
                    GridView1.Columns[GridView1.Columns.Count - 1].Visible = true;
                }
                else
                {
                    btn_add.Visible = false;
                    GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
                }
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/page/add_edit/Edit.aspx?id=" + id);
        }
        protected void Btn_add(object sender, EventArgs e)
        {
            Response.Redirect("~/page/add_edit/Add.aspx");
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Mendapatkan ID dari item yang akan dihapus
            int id = Convert.ToInt32(e.Keys["ID"]);

            string query = "SELECT ITEM_IMAGE FROM ITEMS WHERE ID = :ID";

            using (OracleConnection connection = new OracleConnection(Tns))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":ID", OracleDbType.Int32).Value = id;

                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string filePath = Server.MapPath("~/ImageUpload/") + reader["ITEM_IMAGE"].ToString();

                        // Hapus file gambar dari folder
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }

                    reader.Close();
                }
            }

            // Contoh: Lakukan query DELETE ke database
            query = "DELETE FROM ITEMS WHERE ID = :ID";

            using (OracleConnection connection = new OracleConnection(Tns))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":ID", OracleDbType.Int32).Value = id;

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        BindListViewData();
                    }
                    else
                    {
                        // Gagal menghapus data, tampilkan pesan error atau lakukan tindakan lainnya
                    }
                }
            }
        }
        private void BindListViewData()
        {
            // Lakukan query SELECT untuk mendapatkan data yang akan ditampilkan di ListView
            string query = "SELECT * FROM ITEMS";

            using (OracleConnection connection = new OracleConnection(Tns))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    connection.Open();
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                }
            }
        }
    }
}