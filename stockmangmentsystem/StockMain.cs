using System;
using System.Windows.Forms;

namespace stockmangmentsystem
{
    public partial class StockMain : Form
    {
        public StockMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void PRODUCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // If a Products child is already open, reuse it
                foreach (Form child in this.MdiChildren)
                {
                    if (child is Products)
                    {
                        child.BringToFront();
                        child.WindowState = FormWindowState.Maximized;
                        return;
                    }
                }

                // Create new Products MDI child and dock it to fill the MDI client area
                Products pro = new Products();
                pro.MdiParent = this;
                pro.TopLevel = false;
                pro.FormBorderStyle = FormBorderStyle.None;
                pro.Dock = DockStyle.Fill;
                pro.Show();
                pro.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void STOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stock Clicked");
        }

        private void REPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report Clicked");
        }

        private void EXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Kya aap exit karna chahte hain?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
                e.Cancel = true;
        }
    }
}
