using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StunningDisco
{
    public partial class FrmUser : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;

        public FrmUser()
        {
            InitializeComponent();
        }

        private void loadGridView()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_RetrieveUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    adt.Fill(dt);

                    // Clear binding
                    dataGridView1.DataSource = null;

                    //Set AutoGenerateColumns False
                    dataGridView1.AutoGenerateColumns = false;

                    //Set Columns Count
                    dataGridView1.ColumnCount = 4;

                    dataGridView1.Columns[1].Name = "userName";
                    dataGridView1.Columns[1].HeaderText = "User Name";
                    dataGridView1.Columns[1].DataPropertyName = "userName";
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].Name = "userEmail";
                    dataGridView1.Columns[2].HeaderText = "User Email";
                    dataGridView1.Columns[2].DataPropertyName = "userEmail";
                    dataGridView1.Columns[2].Width = 150;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].Name = "userId";                    
                    dataGridView1.Columns[3].DataPropertyName = "userId";
                    dataGridView1.Columns[3].Visible = false;
                    
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong please try again !! \n\n" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            loadGridView();
        }
    }
}
