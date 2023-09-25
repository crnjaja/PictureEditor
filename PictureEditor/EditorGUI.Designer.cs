namespace PresentationLayer
{

    partial class EditorGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorGUI));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button16 = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 28);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(644, 494);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(7, 40);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(114, 35);
            button1.TabIndex = 8;
            button1.Text = "Load Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button12
            // 
            button12.Location = new Point(7, 22);
            button12.Margin = new Padding(4, 3, 4, 3);
            button12.Name = "button12";
            button12.Size = new Size(114, 35);
            button12.TabIndex = 33;
            button12.Text = "Hell Filter";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(77, 63);
            button13.Margin = new Padding(4, 3, 4, 3);
            button13.Name = "button13";
            button13.Size = new Size(114, 35);
            button13.TabIndex = 34;
            button13.Text = "Cancel";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button14
            // 
            button14.Location = new Point(155, 40);
            button14.Margin = new Padding(4, 3, 4, 3);
            button14.Name = "button14";
            button14.Size = new Size(114, 35);
            button14.TabIndex = 36;
            button14.Text = "Save Image";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button16
            // 
            button16.Location = new Point(155, 22);
            button16.Margin = new Padding(4, 3, 4, 3);
            button16.Name = "button16";
            button16.Size = new Size(114, 35);
            button16.TabIndex = 39;
            button16.Text = "Black and White";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button14);
            groupBox1.Location = new Point(715, 28);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(276, 115);
            groupBox1.TabIndex = 40;
            groupBox1.TabStop = false;
            groupBox1.Text = "Picture";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button12);
            groupBox2.Controls.Add(button16);
            groupBox2.Controls.Add(button13);
            groupBox2.Location = new Point(715, 183);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(276, 115);
            groupBox2.TabIndex = 41;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filters";
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(715, 336);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(276, 115);
            groupBox3.TabIndex = 42;
            groupBox3.TabStop = false;
            groupBox3.Text = "Edges";
            // 
            // EditorGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 542);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EditorGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Program1_Elias_Romain";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button16;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
    }
}