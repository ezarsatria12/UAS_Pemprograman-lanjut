using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

namespace UAS_Pemprogramanlanjut_2203040104.page.auth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Lakukan validasi atau proses otentikasi di sini

            // Contoh validasi menggunakan database Oracle
            string TNS = "Data Source=(DESCRIPTION =" +
        "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-CMAMINP)(PORT = 1521))" +
        "(CONNECT_DATA =" +
        "(SERVER = DEDICATED)" +
        "(SERVICE_NAME = ORCL)));" +
        "User Id= ezar;Password=Rampage3004";

            using (OracleConnection connection = new OracleConnection(TNS))
            {
                string query = "SELECT COUNT(*) FROM USERS WHERE USER_NAME = :Username AND USER_PASSWORD = :Password";
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add(":Username", OracleDbType.Varchar2).Value = username;
                command.Parameters.Add(":Password", OracleDbType.Varchar2).Value = password;

                connection.Open();
                int result = Convert.ToInt32(command.ExecuteScalar());

                if (result == 1)
                {
                    connection.Close();

                    // Membuat koneksi baru ke database
                    using (OracleConnection userConnection = new OracleConnection(TNS))
                    {
                        // Query untuk mengambil data pengguna berdasarkan username
                        string userQuery = "SELECT ID, USER_NAME, USER_PASSWORD FROM USERS WHERE USER_NAME = :Username";
                        OracleCommand userCommand = new OracleCommand(userQuery, userConnection);
                        userCommand.Parameters.Add(":Username", OracleDbType.Varchar2).Value = username;

                        userConnection.Open();
                        OracleDataReader userReader = userCommand.ExecuteReader();

                        if (userReader.Read())
                        {
                            // Mengambil data pengguna dari hasil query
                            int userId = userReader.GetInt32(userReader.GetOrdinal("ID"));
                            string userFullName = userReader.GetString(userReader.GetOrdinal("USER_NAME"));
                            string userPassword = userReader.GetString(userReader.GetOrdinal("USER_PASSWORD"));
                            // Ambil data lainnya sesuai kebutuhan

                            // Simpan data pengguna ke dalam session atau cookie
                            Session["UserId"] = userId;
                            Session["UserFullName"] = userFullName;
                            Session["UserPassword"] = userPassword;
                        }

                        userReader.Close();
                        userConnection.Close();
                    }

                    // Jika login berhasil, redirect ke halaman lain atau lakukan tindakan lainnya
                    Response.Redirect("~/page/Home.aspx");
                }
                else
                {
                    // Jika login gagal, tampilkan pesan error atau lakukan tindakan lainnya
                }

            }
        }
    }
}