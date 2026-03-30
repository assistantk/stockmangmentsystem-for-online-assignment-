using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace stockmangmentsystem
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            loadData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            var codes = new List<string>();

            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if (r.Cells[0]?.Value != null)
                    codes.Add(r.Cells[0].Value.ToString());
            }

            if (codes.Count == 0 && dataGridView1.CurrentRow != null)
            {
                var cell = dataGridView1.CurrentRow.Cells[0];
                if (cell != null && cell.Value != null)
                    codes.Add(cell.Value.ToString());
            }

            if (codes.Count == 0)
            {
                var manual = textBox1.Text?.Trim();
                if (!string.IsNullOrWhiteSpace(manual)) codes.Add(manual);
            }

            if (codes.Count == 0)
            {
                MessageBox.Show("Please select a product row to delete or enter a product code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete {codes.Count} product(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            
            DeleteCodesRecursive(codes, 0);
        }

    
        private void DeleteCodesRecursive(List<string> codes, int idx)
        {
            if (idx >= codes.Count)
            {
                
                loadData();
                return;
            }

            string code = codes[idx];
            if (string.IsNullOrWhiteSpace(code))
            {
                
                DeleteCodesRecursive(codes, idx + 1);
                return;
            }

            string cs = "Data Source=MAYANK\\SQLEXPRESS01;Initial Catalog=STOCKMANAGEMENT;" +
                        "Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Products] WHERE ProductCode = @code", conn))
                    {
                        cmd.Parameters.AddWithValue("@code", code);
                        int affected = cmd.ExecuteNonQuery();
                        
                        if (affected > 0)
                        {
                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }

            
            DeleteCodesRecursive(codes, idx + 1);
        }

        private void Products_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=MAYANK\\SQLEXPRESS01;Initial Catalog=STOCKMANAGEMENT;" +
                        "Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    bool status = (comboBox1.SelectedIndex == 0);

                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO [dbo].[Products] ([ProductCode],[ProductName],[ProductStatus]) VALUES (@code,@name,@status)",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@code", textBox1.Text);
                        cmd.Parameters.AddWithValue("@name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@status", status);

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Record insert successfully...!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Record Not inserted.!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
            loadData();
        }

        public void loadData()
        {
            string cs = "Data Source=MAYANK\\SQLEXPRESS01;Initial Catalog=STOCKMANAGEMENT;" +
                        "Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * FROM [STOCKMANAGEMENT].[dbo].[Products]", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();

                foreach (DataRow item in dt.Rows )
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();

                    if ((bool)item["ProductStatus"])
                    {
                        dataGridView1.Rows[n].Cells[2].Value = "Active";
                    }

                    else
                    {
                        dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                    }

                    dataGridView1.Rows[n].Cells[2].Value = item["ProductStatus"].ToString();
                } 
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[1].Cells[1].Value.ToString();

            if (dataGridView1.SelectedRows[0].Cells[1].Value.ToString() == "Active")
            {

                comboBox1.SelectedIndex = 0;

            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }
    }
}
