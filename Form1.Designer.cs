namespace Erdbebensim.Zusaammen_GUI___Vis_
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
            statusLamp = new PictureBox();
            btnStop = new Button();
            btnStart = new Button();
            tabControl1 = new TabControl();
            tabBuilding = new TabPage();
            vScrollBar1 = new VScrollBar();
            groupBox1 = new GroupBox();
            btnResetDefaults = new Button();
            btnRandomize = new Button();
            lblDamping = new Label();
            lblSpring = new Label();
            btnClose = new Button();
            lblMass = new Label();
            lblFloors = new Label();
            grpBuildingParameters = new GroupBox();
            btnApplyParameters = new Button();
            label1 = new Label();
            txtFloors = new TextBox();
            label4 = new Label();
            txtDamping = new TextBox();
            label3 = new Label();
            txtSpring = new TextBox();
            label2 = new Label();
            txtMass = new TextBox();
            pictureBoxSimulation = new PictureBox();
            tabErreger = new TabPage();
            groupBox2 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            btnApplyExcitation = new Button();
            txtFrequency = new TextBox();
            txtAmplitude = new TextBox();
            pictureBox1 = new PictureBox();
            tabDiagrams = new TabPage();
            timer1 = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)statusLamp).BeginInit();
            tabControl1.SuspendLayout();
            tabBuilding.SuspendLayout();
            groupBox1.SuspendLayout();
            grpBuildingParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSimulation).BeginInit();
            tabErreger.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // statusLamp
            // 
            statusLamp.BackColor = Color.FromArgb(192, 0, 0);
            statusLamp.BorderStyle = BorderStyle.FixedSingle;
            statusLamp.Location = new Point(18, 106);
            statusLamp.Margin = new Padding(5, 6, 5, 6);
            statusLamp.Name = "statusLamp";
            statusLamp.Size = new Size(358, 20);
            statusLamp.TabIndex = 16;
            statusLamp.TabStop = false;
            // 
            // btnStop
            // 
            btnStop.Cursor = Cursors.Hand;
            btnStop.Location = new Point(203, 21);
            btnStop.Margin = new Padding(5, 6, 5, 6);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(174, 72);
            btnStop.TabIndex = 15;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Cursor = Cursors.Hand;
            btnStart.Location = new Point(20, 21);
            btnStart.Margin = new Padding(5, 6, 5, 6);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(174, 72);
            btnStart.TabIndex = 14;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabBuilding);
            tabControl1.Controls.Add(tabErreger);
            tabControl1.Controls.Add(tabDiagrams);
            tabControl1.Location = new Point(20, 139);
            tabControl1.Margin = new Padding(5, 6, 5, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2436, 1158);
            tabControl1.TabIndex = 13;
            // 
            // tabBuilding
            // 
            tabBuilding.Controls.Add(vScrollBar1);
            tabBuilding.Controls.Add(groupBox1);
            tabBuilding.Controls.Add(grpBuildingParameters);
            tabBuilding.Controls.Add(pictureBoxSimulation);
            tabBuilding.Location = new Point(8, 46);
            tabBuilding.Margin = new Padding(5, 6, 5, 6);
            tabBuilding.Name = "tabBuilding";
            tabBuilding.Padding = new Padding(5, 6, 5, 6);
            tabBuilding.Size = new Size(2420, 1104);
            tabBuilding.TabIndex = 1;
            tabBuilding.Text = "Gebäude";
            tabBuilding.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(1082, 6);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(40, 1085);
            vScrollBar1.TabIndex = 17;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(btnResetDefaults);
            groupBox1.Controls.Add(btnRandomize);
            groupBox1.Controls.Add(lblDamping);
            groupBox1.Controls.Add(lblSpring);
            groupBox1.Controls.Add(btnClose);
            groupBox1.Controls.Add(lblMass);
            groupBox1.Controls.Add(lblFloors);
            groupBox1.Location = new Point(1139, 410);
            groupBox1.Margin = new Padding(5, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 6, 5, 6);
            groupBox1.Size = new Size(1290, 683);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Aktuelle Parameter:";
            // 
            // btnResetDefaults
            // 
            btnResetDefaults.Cursor = Cursors.Hand;
            btnResetDefaults.Location = new Point(1124, 621);
            btnResetDefaults.Margin = new Padding(5, 6, 5, 6);
            btnResetDefaults.Name = "btnResetDefaults";
            btnResetDefaults.Size = new Size(140, 50);
            btnResetDefaults.TabIndex = 14;
            btnResetDefaults.Text = "Reset";
            btnResetDefaults.UseVisualStyleBackColor = true;
            btnResetDefaults.Click += btnResetDefaults_Click;
            // 
            // btnRandomize
            // 
            btnRandomize.Cursor = Cursors.Hand;
            btnRandomize.Location = new Point(11, 315);
            btnRandomize.Margin = new Padding(5, 6, 5, 6);
            btnRandomize.Name = "btnRandomize";
            btnRandomize.Size = new Size(140, 50);
            btnRandomize.TabIndex = 4;
            btnRandomize.Text = "Zufall";
            btnRandomize.UseVisualStyleBackColor = true;
            btnRandomize.Click += btnRandomize_Click;
            // 
            // lblDamping
            // 
            lblDamping.AutoSize = true;
            lblDamping.BackColor = Color.White;
            lblDamping.Location = new Point(28, 246);
            lblDamping.Margin = new Padding(5, 0, 5, 0);
            lblDamping.Name = "lblDamping";
            lblDamping.Size = new Size(68, 32);
            lblDamping.TabIndex = 3;
            lblDamping.Text = "(leer)";
            // 
            // lblSpring
            // 
            lblSpring.AutoSize = true;
            lblSpring.BackColor = Color.White;
            lblSpring.Location = new Point(28, 195);
            lblSpring.Margin = new Padding(5, 0, 5, 0);
            lblSpring.Name = "lblSpring";
            lblSpring.Size = new Size(68, 32);
            lblSpring.TabIndex = 2;
            lblSpring.Text = "(leer)";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Location = new Point(-437, 608);
            btnClose.Margin = new Padding(5, 6, 5, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 53);
            btnClose.TabIndex = 12;
            btnClose.Text = "&Beenden";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblMass
            // 
            lblMass.AutoSize = true;
            lblMass.BackColor = Color.White;
            lblMass.Location = new Point(28, 144);
            lblMass.Margin = new Padding(5, 0, 5, 0);
            lblMass.Name = "lblMass";
            lblMass.Size = new Size(68, 32);
            lblMass.TabIndex = 1;
            lblMass.Text = "(leer)";
            // 
            // lblFloors
            // 
            lblFloors.AutoSize = true;
            lblFloors.BackColor = Color.White;
            lblFloors.Location = new Point(28, 93);
            lblFloors.Margin = new Padding(5, 0, 5, 0);
            lblFloors.Name = "lblFloors";
            lblFloors.Size = new Size(68, 32);
            lblFloors.TabIndex = 0;
            lblFloors.Text = "(leer)";
            // 
            // grpBuildingParameters
            // 
            grpBuildingParameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpBuildingParameters.Controls.Add(btnApplyParameters);
            grpBuildingParameters.Controls.Add(label1);
            grpBuildingParameters.Controls.Add(txtFloors);
            grpBuildingParameters.Controls.Add(label4);
            grpBuildingParameters.Controls.Add(txtDamping);
            grpBuildingParameters.Controls.Add(label3);
            grpBuildingParameters.Controls.Add(txtSpring);
            grpBuildingParameters.Controls.Add(label2);
            grpBuildingParameters.Controls.Add(txtMass);
            grpBuildingParameters.Location = new Point(1139, 19);
            grpBuildingParameters.Margin = new Padding(5, 6, 5, 6);
            grpBuildingParameters.Name = "grpBuildingParameters";
            grpBuildingParameters.Padding = new Padding(5, 6, 5, 6);
            grpBuildingParameters.Size = new Size(1290, 378);
            grpBuildingParameters.TabIndex = 12;
            grpBuildingParameters.TabStop = false;
            grpBuildingParameters.Text = "Gebäudeparameter:";
            // 
            // btnApplyParameters
            // 
            btnApplyParameters.Cursor = Cursors.Hand;
            btnApplyParameters.Location = new Point(28, 285);
            btnApplyParameters.Margin = new Padding(5, 6, 5, 6);
            btnApplyParameters.Name = "btnApplyParameters";
            btnApplyParameters.Size = new Size(172, 50);
            btnApplyParameters.TabIndex = 12;
            btnApplyParameters.Text = "Anwenden";
            btnApplyParameters.UseVisualStyleBackColor = true;
            btnApplyParameters.Click += btnApplyParameters_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(224, 51);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(134, 32);
            label1.TabIndex = 5;
            label1.Text = "Stockwerke";
            // 
            // txtFloors
            // 
            txtFloors.Location = new Point(28, 43);
            txtFloors.Margin = new Padding(5, 6, 5, 6);
            txtFloors.Name = "txtFloors";
            txtFloors.Size = new Size(183, 39);
            txtFloors.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(224, 237);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(243, 32);
            label4.TabIndex = 8;
            label4.Text = "Dämpfungskonstante";
            // 
            // txtDamping
            // 
            txtDamping.Location = new Point(28, 229);
            txtDamping.Margin = new Padding(5, 6, 5, 6);
            txtDamping.Name = "txtDamping";
            txtDamping.Size = new Size(183, 39);
            txtDamping.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(224, 174);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(179, 32);
            label3.TabIndex = 7;
            label3.Text = "Federkonstante";
            // 
            // txtSpring
            // 
            txtSpring.Location = new Point(28, 166);
            txtSpring.Margin = new Padding(5, 6, 5, 6);
            txtSpring.Name = "txtSpring";
            txtSpring.Size = new Size(183, 39);
            txtSpring.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 112);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(81, 32);
            label2.TabIndex = 6;
            label2.Text = "Masse";
            // 
            // txtMass
            // 
            txtMass.Location = new Point(28, 104);
            txtMass.Margin = new Padding(5, 6, 5, 6);
            txtMass.Name = "txtMass";
            txtMass.Size = new Size(183, 39);
            txtMass.TabIndex = 4;
            // 
            // pictureBoxSimulation
            // 
            pictureBoxSimulation.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxSimulation.Location = new Point(5, 6);
            pictureBoxSimulation.Margin = new Padding(5, 6, 5, 6);
            pictureBoxSimulation.Name = "pictureBoxSimulation";
            pictureBoxSimulation.Size = new Size(1117, 1085);
            pictureBoxSimulation.TabIndex = 0;
            pictureBoxSimulation.TabStop = false;
            pictureBoxSimulation.Paint += pictureBoxSimulation_Paint;
            pictureBoxSimulation.Resize += pictureBoxSimulation_Resize;
            // 
            // tabErreger
            // 
            tabErreger.Controls.Add(groupBox2);
            tabErreger.Controls.Add(pictureBox1);
            tabErreger.Location = new Point(8, 46);
            tabErreger.Margin = new Padding(5, 6, 5, 6);
            tabErreger.Name = "tabErreger";
            tabErreger.Size = new Size(2420, 1104);
            tabErreger.TabIndex = 2;
            tabErreger.Text = "Erregerfunktion";
            tabErreger.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(btnApplyExcitation);
            groupBox2.Controls.Add(txtFrequency);
            groupBox2.Controls.Add(txtAmplitude);
            groupBox2.Location = new Point(1329, 6);
            groupBox2.Margin = new Padding(5, 6, 5, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 6, 5, 6);
            groupBox2.Size = new Size(588, 781);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Erregerfunktion:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(208, 194);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(113, 32);
            label6.TabIndex = 4;
            label6.Text = "Frequenz";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(208, 104);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(125, 32);
            label5.TabIndex = 3;
            label5.Text = "Amplitude";
            // 
            // btnApplyExcitation
            // 
            btnApplyExcitation.Location = new Point(419, 293);
            btnApplyExcitation.Margin = new Padding(5, 6, 5, 6);
            btnApplyExcitation.Name = "btnApplyExcitation";
            btnApplyExcitation.Size = new Size(140, 50);
            btnApplyExcitation.TabIndex = 2;
            btnApplyExcitation.Text = "Anwenden";
            btnApplyExcitation.UseVisualStyleBackColor = true;
            // 
            // txtFrequency
            // 
            txtFrequency.Location = new Point(11, 186);
            txtFrequency.Margin = new Padding(5, 6, 5, 6);
            txtFrequency.Name = "txtFrequency";
            txtFrequency.Size = new Size(183, 39);
            txtFrequency.TabIndex = 1;
            // 
            // txtAmplitude
            // 
            txtAmplitude.Location = new Point(11, 96);
            txtAmplitude.Margin = new Padding(5, 6, 5, 6);
            txtAmplitude.Name = "txtAmplitude";
            txtAmplitude.Size = new Size(183, 39);
            txtAmplitude.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.Location = new Point(5, 6);
            pictureBox1.Margin = new Padding(5, 6, 5, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1313, 1421);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tabDiagrams
            // 
            tabDiagrams.Location = new Point(8, 46);
            tabDiagrams.Margin = new Padding(5, 6, 5, 6);
            tabDiagrams.Name = "tabDiagrams";
            tabDiagrams.Size = new Size(2420, 1104);
            tabDiagrams.TabIndex = 3;
            tabDiagrams.Text = "Diagramme";
            tabDiagrams.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2475, 1318);
            Controls.Add(tabControl1);
            Controls.Add(statusLamp);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)statusLamp).EndInit();
            tabControl1.ResumeLayout(false);
            tabBuilding.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpBuildingParameters.ResumeLayout(false);
            grpBuildingParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSimulation).EndInit();
            tabErreger.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox statusLamp;
        private Button btnStop;
        private Button btnStart;
        private TabControl tabControl1;
        private TabPage tabBuilding;
        private GroupBox groupBox1;
        private Button btnResetDefaults;
        private Button btnRandomize;
        private Label lblDamping;
        private Label lblSpring;
        private Label lblMass;
        private Label lblFloors;
        private GroupBox grpBuildingParameters;
        private Label label1;
        private Button btnApplyParameters;
        private TextBox txtFloors;
        private Label label4;
        private TextBox txtDamping;
        private Label label3;
        private TextBox txtSpring;
        private Label label2;
        private TextBox txtMass;
        private PictureBox pictureBoxSimulation;
        private TabPage tabErreger;
        private GroupBox groupBox2;
        private Label label6;
        private Label label5;
        private Button btnApplyExcitation;
        private TextBox txtFrequency;
        private TextBox txtAmplitude;
        private PictureBox pictureBox1;
        private TabPage tabDiagrams;
        private Button btnClose;
        private System.Windows.Forms.Timer timer1;
        private ToolTip toolTip1;
        private VScrollBar vScrollBar1;
    }
}
