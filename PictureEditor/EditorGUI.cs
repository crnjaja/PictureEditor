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


// TODO :
// Finaliser le merge total
// Ajouter le filtre en X et Y
//  SAVE IMAGE ne fonctionne pas
// Tester LOAD IMAGE
// Ajouter edge detector

namespace PresentationLayer
{
    /// <summary>
    ///  Controller for the Picture Editor Program GUI 
    /// </summary>
    public partial class EditorGUI : Form
    {
        // A T T R I B U T E S
        private Bitmap currentBitmap;       // Bitmap currently being displayed in the picture box
        private Image originalImage;         // Original image loaded into the picture box (used for resetting)

        // C  O N S T R U C T O R
        public EditorGUI()
        {
            InitializeComponent();
        }

        // M E T H O D S
        /// <summary>
        ///  Load the original image into the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            // 1) Load the original image into the picture box (and keep a reference to it)
            originalImage = pictureBox.Image;
            SetPictureBoxImage(originalImage);

            // 2) Disable the Edge Detection group box (until the filters have been applied)
            groupBoxEdgesDetection.Enabled = false;

            // 3) Populate the filters list boxes with the available filters
            PopulateFiltersListBoxes();

        }

        /// <summary>
        /// Populate the filters list boxes with the available filters 
        /// </summary>
        private void PopulateFiltersListBoxes()
        {
            // Remplissez listBox_XFilter & listBox_YFilter avec les valeurs de l'enum
            foreach (EdgeFinderAlgorithms algorithm in Enum.GetValues(typeof(EdgeFinderAlgorithms)))
            {
                listBox_XFilter.Items.Add(algorithm);
                listBox_YFilter.Items.Add(algorithm);
            }
        }

        /// <summary>
        ///  Set the picture box image to the given image (disposing the previous image in the picture box) 
        /// </summary>
        /// <param name="image"></param>
        private void SetPictureBoxImage(Image image)
        {
            if (pictureBox.Image != originalImage)  // Ensure we're not disposing the original image
            {
                pictureBox.Image?.Dispose();
            }
            currentBitmap = new Bitmap(image, pictureBox.Size);
            pictureBox.Image = currentBitmap;
        }

        #region GroupBox_PictureData_LoadSave

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            var loadedImage = PictureManager.LoadImage();
            if (loadedImage != null)
            {
                SetPictureBoxImage(loadedImage);
                originalImage = pictureBox.Image;
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            PictureManager.SaveImage(pictureBox.Image);
        }

        #endregion

        #region GroupBox_Filters

        /// <summary>
        /// Apply the Hell filter to the image and display the result in the picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilterHell_Click(object sender, EventArgs e)
        {
            // new Bitmap(pictureBox.Image) creates a copy of the image in the picture box
            pictureBox.Image = ImageFilters.ApplyFilter(new Bitmap(pictureBox.Image), 1, 1, 10, 15);
        }

        /// <summary>
        /// Apply the Black and White filter to the image and display the result in the picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilterBlackWhite_Click(object sender, EventArgs e)
        {
            pictureBox.Image = ImageFilters.BlackWhite(new Bitmap(pictureBox.Image));
        }

        /// <summary>
        /// Cancel the selected filters and display the original image in the picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelFilters_Click(object sender, EventArgs e)
        {
            pictureBox.Image = originalImage;
        }

        /// <summary>
        /// Apply the selected filters to the image and display the result in the picture box.
        /// Enable now the Edge Detection group box to be used.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyFilters_Click(object sender, EventArgs e)
        {


            /*
            if (listBox_XFilter.SelectedItem.ToString().Length > 0 && listBox_YFilter.SelectedItem.ToString().Length > 0)
            {
                filter(listBoxXFilter.SelectedItem.ToString(), listBoxYFilter.SelectedItem.ToString());
                ConvertToXYCoord(pictureBoxResult);
            }
            else
            {
                labelErrors.Text = "2 filters must be selected";
            }*/
        }

        #endregion






    }
}