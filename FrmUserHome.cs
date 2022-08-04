using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StunningDisco
{   
    public partial class FrmUserHome : Form
    {
        string message = string.Empty;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;

        public FrmUserHome()
        {
            InitializeComponent();
        }

        private void FrmUserHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbStunningDiscoDataSetDGV.sp_RetrieveSongs' table. You can move, or remove it, as needed.

            loadGridView();
        }

        private void loadGridView()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("sp_RetrieveSongs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    adt.Fill(dt);

                    ///     CREATES BUTTON IN DATAGRID VIEW  /////////////////

                    // Clear binding
                    dataGridView1.DataSource = null;

                    //Set AutoGenerateColumns False
                    dataGridView1.AutoGenerateColumns = false;

                    //Set Columns Count
                    dataGridView1.ColumnCount = 6;


                    //Add Columns
                    dataGridView1.Columns[1].HeaderText = "Art Work";
                    dataGridView1.Columns[1].Name = "songImage";
                    dataGridView1.Columns[1].DataPropertyName = "songImage";
                    dataGridView1.Columns[1].Width = 120;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[2].Name = "songName";
                    dataGridView1.Columns[2].HeaderText = "Song Name";
                    dataGridView1.Columns[2].DataPropertyName = "songName";
                    dataGridView1.Columns[2].Width = 150;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Columns[3].Name = "songDOR";
                    dataGridView1.Columns[3].HeaderText = "Date of Release";
                    dataGridView1.Columns[3].DataPropertyName = "songDOR";
                    dataGridView1.Columns[3].Width = 130;
                    dataGridView1.Columns[3].ReadOnly = true;

                    dataGridView1.Columns[4].Name = "ARTISTNAME";
                    dataGridView1.Columns[4].HeaderText = "Artists";
                    dataGridView1.Columns[4].DataPropertyName = "ARTISTNAME";
                    dataGridView1.Columns[4].Width = 180;
                    dataGridView1.Columns[4].ReadOnly = true;

                    dataGridView1.Columns[5].Name = "songId";
                    dataGridView1.Columns[5].DataPropertyName = "songId";
                    dataGridView1.Columns[5].Visible = false;


                    ///     CREATES BUTTON IN DATAGRID VIEW  /////////////////
                    ///                    

                    DataGridViewComboBoxColumn comboBox = new DataGridViewComboBoxColumn();
                    dataGridView1.Columns.Add(comboBox);
                    comboBox.HeaderText = "Rating";
                    comboBox.Items.Add("1");
                    comboBox.Items.Add("2");
                    comboBox.Items.Add("3");
                    comboBox.Items.Add("4");
                    comboBox.Items.Add("5");
                    comboBox.Name = "cmbbx_rate";
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
    }
}
