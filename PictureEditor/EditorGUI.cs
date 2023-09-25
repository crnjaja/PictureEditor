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
        private Bitmap currentBitmap;
        private Image originalImage;

        public EditorGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            originalImage = pictureBox1.Image;
            SetPictureBoxImage(originalImage);
        }

        private void SetPictureBoxImage(Image image)
        {
            if (pictureBox1.Image != originalImage)  // Ensure we're not disposing the original image
            {
                pictureBox1.Image?.Dispose();
            }
            currentBitmap = new Bitmap(image, pictureBox1.Size);
            pictureBox1.Image = currentBitmap;
        }

        #region MACHADO_Events


        private void button1_Click(object sender, EventArgs e)
        {
            var loadedImage = PictureManager.LoadImage();
            if (loadedImage != null)
            {
                SetPictureBoxImage(loadedImage);
                originalImage = pictureBox1.Image;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PictureManager.SaveImage(pictureBox1.Image);
        }

        #endregion

        #region MACHADO_ApplyFilters


        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageFilters.ApplyFilter(new Bitmap(pictureBox1.Image), 1, 1, 10, 15);
        }

        private void button13_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = originalImage;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = originalImage;
            pictureBox1.Image = ImageFilters.BlackWhite(new Bitmap(pictureBox1.Image));
        }

        #endregion


    }
}