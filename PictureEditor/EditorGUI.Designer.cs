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
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            button14 = new Button();
            button1 = new Button();
            groupBox2 = new GroupBox();
            button13 = new Button();
            button16 = new Button();
            button12 = new Button();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(24, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(550, 408);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button14);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(605, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(222, 100);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Picture";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button14
            // 
            button14.Location = new Point(118, 55);
            button14.Name = "button14";
            button14.Size = new Size(98, 30);
            button14.TabIndex = 1;
            button14.Text = "Save image";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button1
            // 
            button1.Location = new Point(118, 22);
            button1.Name = "button1";
            button1.Size = new Size(98, 30);
            button1.TabIndex = 0;
            button1.Text = "Load image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button13);
            groupBox2.Controls.Add(button16);
            groupBox2.Controls.Add(button12);
            groupBox2.Location = new Point(610, 167);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(217, 100);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filters";
            // 
            // button13
            // 
            button13.Location = new Point(60, 58);
            button13.Name = "button13";
            button13.Size = new Size(98, 30);
            button13.TabIndex = 2;
            button13.Text = "Cancel";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button16
            // 
            button16.Location = new Point(113, 22);
            button16.Name = "button16";
            button16.Size = new Size(98, 30);
            button16.TabIndex = 1;
            button16.Text = "Black & White";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // button12
            // 
            button12.Location = new Point(6, 22);
            button12.Name = "button12";
            button12.Size = new Size(98, 30);
            button12.TabIndex = 0;
            button12.Text = "Hell Filter";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(610, 291);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(217, 100);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Edges";
            // 
            // EditorGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Name = "EditorGUI";
            Text = "EditorGUI";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private Button button14;
        private Button button1;
        private GroupBox groupBox2;
        private Button button13;
        private Button button16;
        private Button button12;
        private GroupBox groupBox3;
    }
}