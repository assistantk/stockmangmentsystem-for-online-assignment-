using stockmangmentsystem;

namespace stockmangmentsystem
{
    partial class StockMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pRODUCTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOCKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPORTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vIEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // ===== MENU STRIP =====
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.pRODUCTToolStripMenuItem,
                this.sTOCKToolStripMenuItem,
                this.rEPORTToolStripMenuItem,
                this.vIEWToolStripMenuItem,
                this.eXITToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip1.TabIndex = 0;

            // ===== PRODUCT MENU ITEM ===== ✅ Event wired here
            this.pRODUCTToolStripMenuItem.Name = "pRODUCTToolStripMenuItem";
            this.pRODUCTToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.pRODUCTToolStripMenuItem.Text = "PRODUCT";
            this.pRODUCTToolStripMenuItem.Click +=
                new System.EventHandler(this.PRODUCTToolStripMenuItem_Click); // ✅ KEY LINE

            // ===== STOCK MENU ITEM =====
            this.sTOCKToolStripMenuItem.Name = "sTOCKToolStripMenuItem";
            this.sTOCKToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.sTOCKToolStripMenuItem.Text = "STOCK";
            this.sTOCKToolStripMenuItem.Click +=
                new System.EventHandler(this.STOCKToolStripMenuItem_Click); // ✅

            // ===== REPORT MENU ITEM =====
            this.rEPORTToolStripMenuItem.Name = "rEPORTToolStripMenuItem";
            this.rEPORTToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.rEPORTToolStripMenuItem.Text = "REPORT";
            this.rEPORTToolStripMenuItem.Click +=
                new System.EventHandler(this.REPORTToolStripMenuItem_Click); // ✅

            // ===== VIEW MENU ITEM =====
            this.vIEWToolStripMenuItem.Name = "vIEWToolStripMenuItem";
            this.vIEWToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.vIEWToolStripMenuItem.Text = "VIEW";

            // ===== EXIT MENU ITEM =====
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click +=
                new System.EventHandler(this.EXITToolStripMenuItem_Click); // ✅

            // ===== FORM SETTINGS =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;          // ✅ MDI enable
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StockMain";
            this.Text = "Mini Stock Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing +=
                new System.Windows.Forms.FormClosingEventHandler(this.StockMain_FormClosing); // ✅

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ===== FIELD DECLARATIONS =====
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pRODUCTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTOCKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPORTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vIEWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
    }
}
