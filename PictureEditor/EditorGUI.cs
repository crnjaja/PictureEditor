﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationLayer.Image.EdgeFinder;
using PresentationLayer.Image.Filters;
using PresentationLayer.ImageProcessing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


// TODO :
// Finaliser le merge total
// Ajouter edge detector
// Ajouter le filtre en X et Y
//  SAVE IMAGE ne fonctionne pas
// Tester LOAD IMAGE


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
        ///  Form load event handler, acts as the constructor for the form.
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

        #region initialisation
        /// <summary>
        /// Populate the filters list boxes with the available filters 
        /// </summary>
        private void PopulateFiltersListBoxes()
        {
            // Fill listBox_XFilter & listBox_YFilter with enum values
            foreach (EdgeFinderAlgorithms algorithm in Enum.GetValues(typeof(EdgeFinderAlgorithms)))
            {
                listBox_X_Algorithms.Items.Add(algorithm);
                listBox_Y_Algorithms.Items.Add(algorithm);
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

        #endregion


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
            groupBoxEdgesDetection.Enabled = true;
        }

        /// <summary>
        /// Apply the Black and White filter to the image and display the result in the picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilterBlackWhite_Click(object sender, EventArgs e)
        {
            pictureBox.Image = ImageFilters.BlackWhite(new Bitmap(pictureBox.Image));
            groupBoxEdgesDetection.Enabled = true;
        }

    

        /// <summary>
        /// Apply the selected filters X & Y to the image and display the result in the picture box.
        /// Enable now the Edge Detection group box to be used.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyEdgeDetector_Click(object sender, EventArgs e)
        {
            bool filtersApplied = false; // To track whether filters have been applied


            // Check that X and Y filters have been selected
            if (listBox_X_Algorithms.SelectedItem != null &&
                listBox_Y_Algorithms.SelectedItem != null)
            {
                // Apply the selected filters to the image
                string selectedXFilter = listBox_X_Algorithms.SelectedItem.ToString();
                string selectedYFilter = listBox_Y_Algorithms.SelectedItem.ToString();

                // Verify the checkbox value, and apply the filter accordingly (X, Y or the same)
                if (checkBox_SameXY.Checked)
                {
                    //filter(selectedXFilter, selectedXFilter);

                }
                else
                {
                    //filter(selectedXFilter, selectedYFilter);
                }

               // ConvertToXYCoord(pictureBoxResult);

                filtersApplied = true;
            }

            // If filters have been applied, enable the groupBoxEdgesDetection;
            // otherwise, show an error message
            if (filtersApplied)
            {
                groupBoxEdgesDetection.Enabled = true;
            }
            else
            {
                MessageBox.Show("The image must be filtered first, or both X and Y filters must be selected.");
            }
        }

        /// <summary>
        /// If checked, disble the Y filter list box and set the Y filter to the same as the X filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_SameXY_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SameXY.Checked)
            {
                listBox_Y_Algorithms.Enabled = false;
                listBox_Y_Algorithms.SelectedItem = listBox_X_Algorithms.SelectedItem;
            }
            else
            {
                listBox_Y_Algorithms.Enabled = true;
            }
        }

        #endregion

        /// <summary>
        /// Cancel the selected filters and edge detector, and display the original image in the picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelFilters_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox.Image = originalImage;
            groupBoxEdgesDetection.Enabled = false;
        }





    }
}