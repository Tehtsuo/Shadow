namespace Shadow
{
    partial class Shadow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboMaster = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSlave = new System.Windows.Forms.ComboBox();
            this.checkFollow = new System.Windows.Forms.CheckBox();
            this.checkCancel = new System.Windows.Forms.CheckBox();
            this.checkAttack = new System.Windows.Forms.CheckBox();
            this.checkSpectral = new System.Windows.Forms.CheckBox();
            this.checkWhm = new System.Windows.Forms.CheckBox();
            this.checkMount = new System.Windows.Forms.CheckBox();
            this.textMount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkInteractions = new System.Windows.Forms.CheckBox();
            this.checkMenuFollow = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBlue = new System.Windows.Forms.CheckBox();
            this.checkRed = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboMaster
            // 
            this.comboMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboMaster.FormattingEnabled = true;
            this.comboMaster.Location = new System.Drawing.Point(0, 27);
            this.comboMaster.Name = "comboMaster";
            this.comboMaster.Size = new System.Drawing.Size(184, 21);
            this.comboMaster.TabIndex = 0;
            this.comboMaster.DropDown += new System.EventHandler(this.PopulateCombos);
            this.comboMaster.SelectedIndexChanged += new System.EventHandler(this.comboMaster_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Master";
            // 
            // comboSlave
            // 
            this.comboSlave.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboSlave.FormattingEnabled = true;
            this.comboSlave.Location = new System.Drawing.Point(0, 61);
            this.comboSlave.Name = "comboSlave";
            this.comboSlave.Size = new System.Drawing.Size(184, 21);
            this.comboSlave.TabIndex = 2;
            this.comboSlave.DropDown += new System.EventHandler(this.PopulateCombos);
            this.comboSlave.SelectedIndexChanged += new System.EventHandler(this.comboSlave_SelectedIndexChanged);
            // 
            // checkFollow
            // 
            this.checkFollow.AutoSize = true;
            this.checkFollow.Location = new System.Drawing.Point(0, 0);
            this.checkFollow.Margin = new System.Windows.Forms.Padding(0);
            this.checkFollow.Name = "checkFollow";
            this.checkFollow.Size = new System.Drawing.Size(57, 16);
            this.checkFollow.TabIndex = 3;
            this.checkFollow.Text = "Follow";
            this.toolTip1.SetToolTip(this.checkFollow, "Follow master, including extra moves to ensure proper zoning\r\n");
            this.checkFollow.UseVisualStyleBackColor = true;
            // 
            // checkCancel
            // 
            this.checkCancel.AutoSize = true;
            this.checkCancel.Location = new System.Drawing.Point(0, 16);
            this.checkCancel.Margin = new System.Windows.Forms.Padding(0);
            this.checkCancel.Name = "checkCancel";
            this.checkCancel.Size = new System.Drawing.Size(58, 17);
            this.checkCancel.TabIndex = 7;
            this.checkCancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.checkCancel, "If master is no longer invisible or sneaked, cancel my invisible or sneak buff.  " +
        "Requires associated windower/ashita addon.");
            this.checkCancel.UseVisualStyleBackColor = true;
            // 
            // checkAttack
            // 
            this.checkAttack.AutoSize = true;
            this.checkAttack.Location = new System.Drawing.Point(92, 0);
            this.checkAttack.Margin = new System.Windows.Forms.Padding(0);
            this.checkAttack.Name = "checkAttack";
            this.checkAttack.Size = new System.Drawing.Size(55, 16);
            this.checkAttack.TabIndex = 4;
            this.checkAttack.Text = "Attack";
            this.toolTip1.SetToolTip(this.checkAttack, "Melee target, including ensuring facing target and within melee distance");
            this.checkAttack.UseVisualStyleBackColor = true;
            // 
            // checkSpectral
            // 
            this.checkSpectral.AutoSize = true;
            this.checkSpectral.Location = new System.Drawing.Point(0, 0);
            this.checkSpectral.Margin = new System.Windows.Forms.Padding(0);
            this.checkSpectral.Name = "checkSpectral";
            this.checkSpectral.Size = new System.Drawing.Size(79, 16);
            this.checkSpectral.TabIndex = 5;
            this.checkSpectral.Text = "Spectral Jig";
            this.toolTip1.SetToolTip(this.checkSpectral, "Use spectral jig if master has sneak or invisible buff");
            this.checkSpectral.UseVisualStyleBackColor = true;
            // 
            // checkWhm
            // 
            this.checkWhm.AutoSize = true;
            this.checkWhm.Location = new System.Drawing.Point(92, 0);
            this.checkWhm.Margin = new System.Windows.Forms.Padding(0);
            this.checkWhm.Name = "checkWhm";
            this.checkWhm.Size = new System.Drawing.Size(80, 16);
            this.checkWhm.TabIndex = 6;
            this.checkWhm.Text = "Sneak/Invis";
            this.toolTip1.SetToolTip(this.checkWhm, "Use sneak or invisible if master has sneak or invisible buff");
            this.checkWhm.UseVisualStyleBackColor = true;
            // 
            // checkMount
            // 
            this.checkMount.AutoSize = true;
            this.checkMount.Location = new System.Drawing.Point(0, 16);
            this.checkMount.Margin = new System.Windows.Forms.Padding(0);
            this.checkMount.Name = "checkMount";
            this.checkMount.Size = new System.Drawing.Size(57, 16);
            this.checkMount.TabIndex = 8;
            this.checkMount.Text = "Mount";
            this.toolTip1.SetToolTip(this.checkMount, "Mount/dismount based on master\'s status");
            this.checkMount.UseVisualStyleBackColor = true;
            // 
            // textMount
            // 
            this.textMount.Location = new System.Drawing.Point(95, 35);
            this.textMount.Name = "textMount";
            this.textMount.Size = new System.Drawing.Size(86, 21);
            this.textMount.TabIndex = 9;
            this.textMount.Text = "Raptor";
            this.toolTip1.SetToolTip(this.textMount, "Specify the mount you want the slave to use");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 33);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mount Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkInteractions
            // 
            this.checkInteractions.AutoSize = true;
            this.checkInteractions.Location = new System.Drawing.Point(0, 0);
            this.checkInteractions.Margin = new System.Windows.Forms.Padding(0);
            this.checkInteractions.Name = "checkInteractions";
            this.checkInteractions.Size = new System.Drawing.Size(83, 17);
            this.checkInteractions.TabIndex = 11;
            this.checkInteractions.Text = "Interactions";
            this.toolTip1.SetToolTip(this.checkInteractions, "Interact with cutscene targets the master uses");
            this.checkInteractions.UseVisualStyleBackColor = true;
            // 
            // checkMenuFollow
            // 
            this.checkMenuFollow.AutoSize = true;
            this.checkMenuFollow.Location = new System.Drawing.Point(92, 0);
            this.checkMenuFollow.Margin = new System.Windows.Forms.Padding(0);
            this.checkMenuFollow.Name = "checkMenuFollow";
            this.checkMenuFollow.Size = new System.Drawing.Size(86, 17);
            this.checkMenuFollow.TabIndex = 12;
            this.checkMenuFollow.Text = "Menu Follow";
            this.toolTip1.SetToolTip(this.checkMenuFollow, "Attempt to follow master through menus");
            this.checkMenuFollow.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 249);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(184, 32);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Open Abyssea Boxes";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.checkBlue, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkRed, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 14);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(184, 18);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // checkBlue
            // 
            this.checkBlue.AutoSize = true;
            this.checkBlue.Location = new System.Drawing.Point(0, 0);
            this.checkBlue.Margin = new System.Windows.Forms.Padding(0);
            this.checkBlue.Name = "checkBlue";
            this.checkBlue.Size = new System.Drawing.Size(47, 17);
            this.checkBlue.TabIndex = 12;
            this.checkBlue.Text = "Blue";
            this.toolTip1.SetToolTip(this.checkBlue, "Open blue pyxi");
            this.checkBlue.UseVisualStyleBackColor = true;
            // 
            // checkRed
            // 
            this.checkRed.AutoSize = true;
            this.checkRed.Location = new System.Drawing.Point(92, 0);
            this.checkRed.Margin = new System.Windows.Forms.Padding(0);
            this.checkRed.Name = "checkRed";
            this.checkRed.Size = new System.Drawing.Size(44, 17);
            this.checkRed.TabIndex = 13;
            this.checkRed.Text = "Red";
            this.toolTip1.SetToolTip(this.checkRed, "Open red pyxi");
            this.checkRed.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboSlave);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboMaster);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(184, 85);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process Selection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Slave";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 85);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(184, 79);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Movement/Combat";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.checkFollow, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkAttack, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkMount, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textMount, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 14);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(184, 65);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 164);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(184, 53);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stealth";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.checkCancel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.checkSpectral, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkWhm, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 14);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(184, 39);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 217);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox5.Size = new System.Drawing.Size(184, 32);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "NPC Interaction";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.checkMenuFollow, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.checkInteractions, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 14);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(184, 18);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // Shadow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 284);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Shadow";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Text = "Shadow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Shadow_FormClosing);
            this.Load += new System.EventHandler(this.Shadow_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboMaster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboSlave;
        private System.Windows.Forms.CheckBox checkFollow;
        private System.Windows.Forms.CheckBox checkAttack;
        private System.Windows.Forms.CheckBox checkSpectral;
        private System.Windows.Forms.CheckBox checkWhm;
        private System.Windows.Forms.CheckBox checkCancel;
        private System.Windows.Forms.CheckBox checkMount;
        private System.Windows.Forms.TextBox textMount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkInteractions;
        private System.Windows.Forms.CheckBox checkMenuFollow;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBlue;
        private System.Windows.Forms.CheckBox checkRed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}

