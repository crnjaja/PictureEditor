namespace PresentationLayer
{
    /// <summary>
    /// Application GUI for Picture Editor Program
    /// </summary>
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
            pictureBox = new PictureBox();
            btnLoadImage = new Button();
            btnFilterHell = new Button();
            btnCancelFilters = new Button();
            btnSaveImage = new Button();
            btnFilterBlackWhite = new Button();
            groupBoxPictureData = new GroupBox();
            groupBoxFilters = new GroupBox();
            listBox_YFilter = new ListBox();
            btnApplyFilters = new Button();
            listBox_XFilter = new ListBox();
            groupBoxEdgesDetection = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            groupBoxPictureData.SuspendLayout();
            groupBoxFilters.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(34, 77);
            pictureBox.Margin = new Padding(10, 8, 10, 8);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1561, 1347);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(20, 109);
            btnLoadImage.Margin = new Padding(10, 8, 10, 8);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(340, 96);
            btnLoadImage.TabIndex = 8;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // btnFilterHell
            // 
            btnFilterHell.Location = new Point(20, 75);
            btnFilterHell.Margin = new Padding(10, 8, 10, 8);
            btnFilterHell.Name = "btnFilterHell";
            btnFilterHell.Size = new Size(340, 96);
            btnFilterHell.TabIndex = 33;
            btnFilterHell.Text = "Hell Filter";
            btnFilterHell.UseVisualStyleBackColor = true;
            btnFilterHell.Click += btnFilterHell_Click;
            // 
            // btnCancelFilters
            // 
            btnCancelFilters.Location = new Point(20, 412);
            btnCancelFilters.Margin = new Padding(10, 8, 10, 8);
            btnCancelFilters.Name = "btnCancelFilters";
            btnCancelFilters.Size = new Size(340, 96);
            btnCancelFilters.TabIndex = 34;
            btnCancelFilters.Text = "Cancel";
            btnCancelFilters.UseVisualStyleBackColor = true;
            btnCancelFilters.Click += btnCancelFilters_Click;
            // 
            // btnSaveImage
            // 
            btnSaveImage.Location = new Point(391, 109);
            btnSaveImage.Margin = new Padding(10, 8, 10, 8);
            btnSaveImage.Name = "btnSaveImage";
            btnSaveImage.Size = new Size(340, 96);
            btnSaveImage.TabIndex = 36;
            btnSaveImage.Text = "Save Image";
            btnSaveImage.UseVisualStyleBackColor = true;
            btnSaveImage.Click += btnSaveImage_Click;
            // 
            // btnFilterBlackWhite
            // 
            btnFilterBlackWhite.Location = new Point(391, 75);
            btnFilterBlackWhite.Margin = new Padding(10, 8, 10, 8);
            btnFilterBlackWhite.Name = "btnFilterBlackWhite";
            btnFilterBlackWhite.Size = new Size(340, 96);
            btnFilterBlackWhite.TabIndex = 39;
            btnFilterBlackWhite.Text = "Black and White";
            btnFilterBlackWhite.UseVisualStyleBackColor = true;
            btnFilterBlackWhite.Click += btnFilterBlackWhite_Click;
            // 
            // groupBoxPictureData
            // 
            groupBoxPictureData.Controls.Add(btnLoadImage);
            groupBoxPictureData.Controls.Add(btnSaveImage);
            groupBoxPictureData.Location = new Point(1673, 77);
            groupBoxPictureData.Margin = new Padding(10, 8, 10, 8);
            groupBoxPictureData.Name = "groupBoxPictureData";
            groupBoxPictureData.Padding = new Padding(10, 8, 10, 8);
            groupBoxPictureData.Size = new Size(751, 314);
            groupBoxPictureData.TabIndex = 40;
            groupBoxPictureData.TabStop = false;
            groupBoxPictureData.Text = "Picture";
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.Controls.Add(listBox_YFilter);
            groupBoxFilters.Controls.Add(btnApplyFilters);
            groupBoxFilters.Controls.Add(listBox_XFilter);
            groupBoxFilters.Controls.Add(btnFilterHell);
            groupBoxFilters.Controls.Add(btnFilterBlackWhite);
            groupBoxFilters.Controls.Add(btnCancelFilters);
            groupBoxFilters.Location = new Point(1673, 407);
            groupBoxFilters.Margin = new Padding(10, 8, 10, 8);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Padding = new Padding(10, 8, 10, 8);
            groupBoxFilters.Size = new Size(751, 524);
            groupBoxFilters.TabIndex = 41;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Filters";
            // 
            // listBox_YFilter
            // 
            listBox_YFilter.FormattingEnabled = true;
            listBox_YFilter.ItemHeight = 41;
            listBox_YFilter.Location = new Point(391, 216);
            listBox_YFilter.Name = "listBox_YFilter";
            listBox_YFilter.Size = new Size(335, 168);
            listBox_YFilter.TabIndex = 43;
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.Location = new Point(391, 412);
            btnApplyFilters.Margin = new Padding(10, 8, 10, 8);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(340, 96);
            btnApplyFilters.TabIndex = 42;
            btnApplyFilters.Text = "Apply";
            btnApplyFilters.UseVisualStyleBackColor = true;
            btnApplyFilters.Click += btnApplyFilters_Click;
            // 
            // listBox_XFilter
            // 
            listBox_XFilter.FormattingEnabled = true;
            listBox_XFilter.ItemHeight = 41;
            listBox_XFilter.Location = new Point(25, 216);
            listBox_XFilter.Name = "listBox_XFilter";
            listBox_XFilter.Size = new Size(335, 168);
            listBox_XFilter.TabIndex = 40;
            // 
            // groupBoxEdgesDetection
            // 
            groupBoxEdgesDetection.Location = new Point(1673, 1110);
            groupBoxEdgesDetection.Margin = new Padding(10, 8, 10, 8);
            groupBoxEdgesDetection.Name = "groupBoxEdgesDetection";
            groupBoxEdgesDetection.Padding = new Padding(10, 8, 10, 8);
            groupBoxEdgesDetection.Size = new Size(751, 314);
            groupBoxEdgesDetection.TabIndex = 42;
            groupBoxEdgesDetection.TabStop = false;
            groupBoxEdgesDetection.Text = "Edges detector";
            // 
            // EditorGUI
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2460, 1481);
            Controls.Add(groupBoxEdgesDetection);
            Controls.Add(groupBoxFilters);
            Controls.Add(groupBoxPictureData);
            Controls.Add(pictureBox);
            Margin = new Padding(10, 8, 10, 8);
            Name = "EditorGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Program1_Elias_Romain";
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            groupBoxPictureData.ResumeLayout(false);
            groupBoxFilters.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Button btnLoadImage;
        private Button btnFilterHell;
        private Button btnCancelFilters;
        private Button btnSaveImage;
        private Button btnFilterBlackWhite;
        private GroupBox groupBoxPictureData;
        private GroupBox groupBoxFilters;
        private GroupBox groupBoxEdgesDetection;
        private ListBox listBox_YFilter;
        private Button btnApplyFilters;
        private ListBox listBox_XFilter;
    }
}