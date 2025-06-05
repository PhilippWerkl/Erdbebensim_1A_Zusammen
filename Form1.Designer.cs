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
            grpErregerParameter = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            txtFreq = new TextBox();
            txtAmp = new TextBox();
            lblAktuell = new Label();
            rbSquare = new RadioButton();
            rbDoubleSinus = new RadioButton();
            rbSinus = new RadioButton();
            vScrollBar1 = new VScrollBar();
            grpBuildingParameters = new GroupBox();
            label1 = new Label();
            txtFloors = new TextBox();
            label4 = new Label();
            txtDamping = new TextBox();
            label3 = new Label();
            txtSpring = new TextBox();
            label2 = new Label();
            txtMass = new TextBox();
            pictureBoxSimulation = new PictureBox();
            tabDiagrams = new TabPage();
            btnRandomize = new Button();
            lblDamping = new Label();
            lblSpring = new Label();
            lblMass = new Label();
            lblFloors = new Label();
            btnApplyParameters = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)statusLamp).BeginInit();
            tabControl1.SuspendLayout();
            tabBuilding.SuspendLayout();
            grpErregerParameter.SuspendLayout();
            grpBuildingParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSimulation).BeginInit();
            SuspendLayout();
            // 
            // statusLamp
            // 
            statusLamp.BackColor = Color.FromArgb(192, 0, 0);
            statusLamp.BorderStyle = BorderStyle.FixedSingle;
            statusLamp.Location = new Point(21, 123);
            statusLamp.Margin = new Padding(6, 7, 6, 7);
            statusLamp.Name = "statusLamp";
            statusLamp.Size = new Size(413, 23);
            statusLamp.TabIndex = 16;
            statusLamp.TabStop = false;
            // 
            // btnStop
            // 
            btnStop.Cursor = Cursors.Hand;
            btnStop.Location = new Point(234, 24);
            btnStop.Margin = new Padding(6, 7, 6, 7);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(201, 83);
            btnStop.TabIndex = 15;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Cursor = Cursors.Hand;
            btnStart.Location = new Point(23, 24);
            btnStart.Margin = new Padding(6, 7, 6, 7);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(201, 83);
            btnStart.TabIndex = 14;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabBuilding);
            tabControl1.Controls.Add(tabDiagrams);
            tabControl1.Location = new Point(23, 161);
            tabControl1.Margin = new Padding(6, 7, 6, 7);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2811, 1339);
            tabControl1.TabIndex = 13;
            // 
            // tabBuilding
            // 
            tabBuilding.Controls.Add(grpErregerParameter);
            tabBuilding.Controls.Add(vScrollBar1);
            tabBuilding.Controls.Add(grpBuildingParameters);
            tabBuilding.Controls.Add(pictureBoxSimulation);
            tabBuilding.Location = new Point(10, 55);
            tabBuilding.Margin = new Padding(6, 7, 6, 7);
            tabBuilding.Name = "tabBuilding";
            tabBuilding.Padding = new Padding(6, 7, 6, 7);
            tabBuilding.Size = new Size(2791, 1274);
            tabBuilding.TabIndex = 1;
            tabBuilding.Text = "Parameter";
            tabBuilding.UseVisualStyleBackColor = true;
            // 
            // grpErregerParameter
            // 
            grpErregerParameter.Controls.Add(label6);
            grpErregerParameter.Controls.Add(label5);
            grpErregerParameter.Controls.Add(txtFreq);
            grpErregerParameter.Controls.Add(txtAmp);
            grpErregerParameter.Controls.Add(lblAktuell);
            grpErregerParameter.Controls.Add(rbSquare);
            grpErregerParameter.Controls.Add(rbDoubleSinus);
            grpErregerParameter.Controls.Add(rbSinus);
            grpErregerParameter.Location = new Point(1304, 22);
            grpErregerParameter.Name = "grpErregerParameter";
            grpErregerParameter.Size = new Size(784, 437);
            grpErregerParameter.TabIndex = 18;
            grpErregerParameter.TabStop = false;
            grpErregerParameter.Text = "Erregerfunktionsparameter";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(255, 288);
            label6.Name = "label6";
            label6.Size = new Size(125, 37);
            label6.TabIndex = 23;
            label6.Text = "Frequenz";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(255, 220);
            label5.Name = "label5";
            label5.Size = new Size(141, 37);
            label5.TabIndex = 22;
            label5.Text = "Amplitude";
            // 
            // txtFreq
            // 
            txtFreq.Location = new Point(24, 285);
            txtFreq.Name = "txtFreq";
            txtFreq.Size = new Size(225, 43);
            txtFreq.TabIndex = 21;
            // 
            // txtAmp
            // 
            txtAmp.Location = new Point(24, 217);
            txtAmp.Name = "txtAmp";
            txtAmp.Size = new Size(225, 43);
            txtAmp.TabIndex = 20;
            // 
            // lblAktuell
            // 
            lblAktuell.AutoSize = true;
            lblAktuell.Location = new Point(420, 59);
            lblAktuell.Name = "lblAktuell";
            lblAktuell.Size = new Size(90, 37);
            lblAktuell.TabIndex = 19;
            lblAktuell.Text = "label5";
            // 
            // rbSquare
            // 
            rbSquare.AutoSize = true;
            rbSquare.Location = new Point(24, 153);
            rbSquare.Name = "rbSquare";
            rbSquare.Size = new Size(152, 41);
            rbSquare.TabIndex = 18;
            rbSquare.TabStop = true;
            rbSquare.Text = "Rechteck";
            rbSquare.UseVisualStyleBackColor = true;
            // 
            // rbDoubleSinus
            // 
            rbDoubleSinus.AutoSize = true;
            rbDoubleSinus.Location = new Point(24, 106);
            rbDoubleSinus.Name = "rbDoubleSinus";
            rbDoubleSinus.Size = new Size(195, 41);
            rbDoubleSinus.TabIndex = 17;
            rbDoubleSinus.TabStop = true;
            rbDoubleSinus.Text = "Doppelsinus";
            rbDoubleSinus.UseVisualStyleBackColor = true;
            // 
            // rbSinus
            // 
            rbSinus.AutoSize = true;
            rbSinus.Location = new Point(24, 59);
            rbSinus.Name = "rbSinus";
            rbSinus.Size = new Size(110, 41);
            rbSinus.TabIndex = 16;
            rbSinus.TabStop = true;
            rbSinus.Text = "Sinus";
            rbSinus.UseVisualStyleBackColor = true;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(1248, 7);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(40, 1255);
            vScrollBar1.TabIndex = 17;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // grpBuildingParameters
            // 
            grpBuildingParameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpBuildingParameters.Controls.Add(btnApplyParameters);
            grpBuildingParameters.Controls.Add(btnRandomize);
            grpBuildingParameters.Controls.Add(label1);
            grpBuildingParameters.Controls.Add(txtFloors);
            grpBuildingParameters.Controls.Add(label4);
            grpBuildingParameters.Controls.Add(txtDamping);
            grpBuildingParameters.Controls.Add(label3);
            grpBuildingParameters.Controls.Add(txtSpring);
            grpBuildingParameters.Controls.Add(label2);
            grpBuildingParameters.Controls.Add(txtMass);
            grpBuildingParameters.Location = new Point(2097, 22);
            grpBuildingParameters.Margin = new Padding(6, 7, 6, 7);
            grpBuildingParameters.Name = "grpBuildingParameters";
            grpBuildingParameters.Padding = new Padding(6, 7, 6, 7);
            grpBuildingParameters.Size = new Size(705, 437);
            grpBuildingParameters.TabIndex = 12;
            grpBuildingParameters.TabStop = false;
            grpBuildingParameters.Text = "Gebäudeparameter:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(258, 59);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(150, 37);
            label1.TabIndex = 5;
            label1.Text = "Stockwerke";
            // 
            // txtFloors
            // 
            txtFloors.Location = new Point(32, 50);
            txtFloors.Margin = new Padding(6, 7, 6, 7);
            txtFloors.Name = "txtFloors";
            txtFloors.Size = new Size(211, 43);
            txtFloors.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(258, 274);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(270, 37);
            label4.TabIndex = 8;
            label4.Text = "Dämpfungskonstante";
            // 
            // txtDamping
            // 
            txtDamping.Location = new Point(32, 265);
            txtDamping.Margin = new Padding(6, 7, 6, 7);
            txtDamping.Name = "txtDamping";
            txtDamping.Size = new Size(211, 43);
            txtDamping.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(258, 201);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(199, 37);
            label3.TabIndex = 7;
            label3.Text = "Federkonstante";
            // 
            // txtSpring
            // 
            txtSpring.Location = new Point(32, 192);
            txtSpring.Margin = new Padding(6, 7, 6, 7);
            txtSpring.Name = "txtSpring";
            txtSpring.Size = new Size(211, 43);
            txtSpring.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(258, 130);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(91, 37);
            label2.TabIndex = 6;
            label2.Text = "Masse";
            // 
            // txtMass
            // 
            txtMass.Location = new Point(32, 120);
            txtMass.Margin = new Padding(6, 7, 6, 7);
            txtMass.Name = "txtMass";
            txtMass.Size = new Size(211, 43);
            txtMass.TabIndex = 4;
            // 
            // pictureBoxSimulation
            // 
            pictureBoxSimulation.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxSimulation.Location = new Point(6, 7);
            pictureBoxSimulation.Margin = new Padding(6, 7, 6, 7);
            pictureBoxSimulation.Name = "pictureBoxSimulation";
            pictureBoxSimulation.Size = new Size(1289, 1254);
            pictureBoxSimulation.TabIndex = 0;
            pictureBoxSimulation.TabStop = false;
            pictureBoxSimulation.Paint += pictureBoxSimulation_Paint;
            pictureBoxSimulation.Resize += pictureBoxSimulation_Resize;
            // 
            // tabDiagrams
            // 
            tabDiagrams.Location = new Point(10, 55);
            tabDiagrams.Margin = new Padding(6, 7, 6, 7);
            tabDiagrams.Name = "tabDiagrams";
            tabDiagrams.Size = new Size(2791, 1274);
            tabDiagrams.TabIndex = 3;
            tabDiagrams.Text = "Diagramme";
            tabDiagrams.UseVisualStyleBackColor = true;
            // 
            // btnRandomize
            // 
            btnRandomize.Cursor = Cursors.Hand;
            btnRandomize.Location = new Point(511, 349);
            btnRandomize.Margin = new Padding(6, 7, 6, 7);
            btnRandomize.Name = "btnRandomize";
            btnRandomize.Size = new Size(162, 58);
            btnRandomize.TabIndex = 4;
            btnRandomize.Text = "Zufall";
            btnRandomize.UseVisualStyleBackColor = true;
            btnRandomize.Click += btnRandomize_Click;
            // 
            // lblDamping
            // 
            lblDamping.AutoSize = true;
            lblDamping.BackColor = Color.White;
            lblDamping.Location = new Point(1908, 109);
            lblDamping.Margin = new Padding(6, 0, 6, 0);
            lblDamping.Name = "lblDamping";
            lblDamping.Size = new Size(77, 37);
            lblDamping.TabIndex = 3;
            lblDamping.Text = "(leer)";
            // 
            // lblSpring
            // 
            lblSpring.AutoSize = true;
            lblSpring.BackColor = Color.White;
            lblSpring.Location = new Point(1908, 38);
            lblSpring.Margin = new Padding(6, 0, 6, 0);
            lblSpring.Name = "lblSpring";
            lblSpring.Size = new Size(77, 37);
            lblSpring.TabIndex = 2;
            lblSpring.Text = "(leer)";
            // 
            // lblMass
            // 
            lblMass.AutoSize = true;
            lblMass.BackColor = Color.White;
            lblMass.Location = new Point(1314, 109);
            lblMass.Margin = new Padding(6, 0, 6, 0);
            lblMass.Name = "lblMass";
            lblMass.Size = new Size(77, 37);
            lblMass.TabIndex = 1;
            lblMass.Text = "(leer)";
            // 
            // lblFloors
            // 
            lblFloors.AutoSize = true;
            lblFloors.BackColor = Color.White;
            lblFloors.Location = new Point(1314, 38);
            lblFloors.Margin = new Padding(6, 0, 6, 0);
            lblFloors.Name = "lblFloors";
            lblFloors.Size = new Size(77, 37);
            lblFloors.TabIndex = 0;
            lblFloors.Text = "(leer)";
            // 
            // btnApplyParameters
            // 
            btnApplyParameters.Cursor = Cursors.Hand;
            btnApplyParameters.Location = new Point(32, 349);
            btnApplyParameters.Margin = new Padding(6, 7, 6, 7);
            btnApplyParameters.Name = "btnApplyParameters";
            btnApplyParameters.Size = new Size(198, 58);
            btnApplyParameters.TabIndex = 12;
            btnApplyParameters.Text = "Anwenden";
            btnApplyParameters.UseVisualStyleBackColor = true;
            btnApplyParameters.Click += btnApplyParameters_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2856, 1524);
            Controls.Add(tabControl1);
            Controls.Add(statusLamp);
            Controls.Add(lblDamping);
            Controls.Add(btnStop);
            Controls.Add(lblSpring);
            Controls.Add(btnStart);
            Controls.Add(lblFloors);
            Controls.Add(lblMass);
            Margin = new Padding(6);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)statusLamp).EndInit();
            tabControl1.ResumeLayout(false);
            tabBuilding.ResumeLayout(false);
            grpErregerParameter.ResumeLayout(false);
            grpErregerParameter.PerformLayout();
            grpBuildingParameters.ResumeLayout(false);
            grpBuildingParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSimulation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox statusLamp;
        private Button btnStop;
        private Button btnStart;
        private TabControl tabControl1;
        private TabPage tabBuilding;
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
        private TabPage tabDiagrams;
        private System.Windows.Forms.Timer timer1;
        private ToolTip toolTip1;
        private VScrollBar vScrollBar1;
        private GroupBox grpErregerParameter;
        private RadioButton rbSquare;
        private RadioButton rbDoubleSinus;
        private RadioButton rbSinus;
        private Label lblAktuell;
        private Label label6;
        private Label label5;
        private TextBox txtFreq;
        private TextBox txtAmp;
    }
}
