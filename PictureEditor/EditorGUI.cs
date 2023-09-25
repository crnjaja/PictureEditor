using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer
{
    public partial class EditorGUI : Form
    {
        #region MACHADO_Atributes

        Bitmap map;
        System.Drawing.Image Origin;

        #endregion

        public EditorGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Origin = pictureBox1.Image;
            Bitmap temp = new Bitmap(pictureBox1.Image,
                new Size(pictureBox1.Width, pictureBox1.Height));
            pictureBox1.Image = temp;
            map = new Bitmap(pictureBox1.Image);
        }

        #region MACHADO_FileManagement

        public void SaveImage()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            FolderBrowserDialog fl = new FolderBrowserDialog();
            if (fl.ShowDialog() != DialogResult.Cancel)
            {

                pictureBox1.Image.Save(fl.SelectedPath + @"\" + textBox1.Text + @".png", System.Drawing.Imaging.ImageFormat.Png);
            };
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = op.FileName;
                pictureBox1.Load(path);
                Bitmap temp = new Bitmap(pictureBox1.Image,
                   new Size(pictureBox1.Width, pictureBox1.Height));
                pictureBox1.Image = temp;
                map = new Bitmap(pictureBox1.Image);
                Origin = pictureBox1.Image;
            }
        }

        #endregion


        #region MACHADO_Events


        private void button1_Click(object sender, EventArgs e)
        {
            LoadImage();
        }


        private void button14_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        #endregion

        #region MACHADO_ApplyFilters


        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageFilters.ApplyFilter(new Bitmap(pictureBox1.Image), 1, 1, 10, 15);
        }

        private void button13_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = Origin;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Origin;
            pictureBox1.Image = ImageFilters.BlackWhite(new Bitmap(pictureBox1.Image));
        }

        #endregion


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}