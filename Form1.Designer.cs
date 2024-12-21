
namespace Lab_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            textBox4 = new System.Windows.Forms.TextBox();
            zedGraphControl1 = new ZedGraph.ZedGraphControl();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            buttonras = new System.Windows.Forms.Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.Name = "textBox1";
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // textBox2
            // 
            textBox2.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(textBox2, "textBox2");
            textBox2.Name = "textBox2";
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox3
            // 
            textBox3.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(textBox3, "textBox3");
            textBox3.Name = "textBox3";
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = System.Drawing.SystemColors.Window;
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = System.Drawing.SystemColors.Window;
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = System.Drawing.SystemColors.Window;
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = System.Drawing.SystemColors.Window;
            label4.Name = "label4";
            // 
            // textBox4
            // 
            textBox4.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(textBox4, "textBox4");
            textBox4.Name = "textBox4";
            textBox4.KeyPress += textBox4_KeyPress;
            // 
            // zedGraphControl1
            // 
            resources.ApplyResources(zedGraphControl1, "zedGraphControl1");
            zedGraphControl1.Name = "zedGraphControl1";
            zedGraphControl1.ScrollGrace = 0D;
            zedGraphControl1.ScrollMaxX = 0D;
            zedGraphControl1.ScrollMaxY = 0D;
            zedGraphControl1.ScrollMaxY2 = 0D;
            zedGraphControl1.ScrollMinX = 0D;
            zedGraphControl1.ScrollMinY = 0D;
            zedGraphControl1.ScrollMinY2 = 0D;
            zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.FromArgb(76, 75, 105);
            menuStrip1.ImageScalingSize = new System.Drawing.Size(19, 19);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { очиститьToolStripMenuItem, nextToolStripMenuItem, закрытьToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            menuStrip1.MouseDown += menuStrip1_MouseDown;
            // 
            // очиститьToolStripMenuItem
            // 
            resources.ApplyResources(очиститьToolStripMenuItem, "очиститьToolStripMenuItem");
            очиститьToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            очиститьToolStripMenuItem.Click += очиститьToolStripMenuItem_Click;
            // 
            // nextToolStripMenuItem
            // 
            nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            resources.ApplyResources(nextToolStripMenuItem, "nextToolStripMenuItem");
            // 
            // закрытьToolStripMenuItem
            // 
            resources.ApplyResources(закрытьToolStripMenuItem, "закрытьToolStripMenuItem");
            закрытьToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            закрытьToolStripMenuItem.Click += закрытьToolStripMenuItem_Click;
            // 
            // buttonras
            // 
            buttonras.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(buttonras, "buttonras");
            buttonras.Name = "buttonras";
            buttonras.UseVisualStyleBackColor = false;
            buttonras.Click += buttonras_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(44, 43, 60);
            Controls.Add(buttonras);
            Controls.Add(zedGraphControl1);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            MouseDown += Form1_MouseDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.Button buttonras;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}

