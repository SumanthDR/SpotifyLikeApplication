using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

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

        //private void saveUserRatings(String prc)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    try
        //    {
        //        foreach (DataGridViewRow dr in dataGridView1.Rows)
        //        {
        //            SqlCommand cmd = new SqlCommand(prc, con)
        //            {
        //                CommandType = CommandType.StoredProcedure
        //            };
        //            cmd.Parameters.AddWithValue("@Course_Id", Frm_CourseView.crs_id);
        //            cmd.Parameters.AddWithValue("@Course_Id", Frm_CourseView.crs_id);
        //            if (dr.IsNewRow) continue;
        //            {
        //                cmd.Parameters.AddWithValue("@card_id", dr.Cells["Card_Id"].Value ?? DBNull.Value);                        
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();             
        //            }
        //        }
        //        dataGridView1.DataSource = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Something went wrong, Please try again !! \n\n" + ex);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        private void removeDuplicateRows()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = i + 1; j < dataGridView1.Rows.Count; j++)
                {
                    string first_str = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string second_str = dataGridView1.Rows[j].Cells[5].Value.ToString();

                    if (first_str == second_str)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                        j--;
                    }
                    else
                        list.Add(dataGridView1.Rows[i].Cells[5].Value.ToString());
                }
            }
        }

        private void FrmUserHome_Load(object sender, EventArgs e)
        {   
            loadGridView();
            removeDuplicateRows();
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

                    // Clear binding
                    dataGridView1.DataSource = null;

                    //Set AutoGenerateColumns False
                    dataGridView1.AutoGenerateColumns = false;

                    //Set Columns Count
                    dataGridView1.ColumnCount = 5;

                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.Name = "songImage";
                    imageColumn.DataPropertyName = "songImage";
                    imageColumn.HeaderText = "Art Work";
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    dataGridView1.Columns.Insert(1, imageColumn);
                    dataGridView1.RowTemplate.Height = 100;
                    dataGridView1.Columns[1].Width = 100;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

