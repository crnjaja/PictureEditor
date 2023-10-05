using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationLayer.ImageProcessing;
using PresentationLayer.ImageProcessing.EdgeDetector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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
                    Filter(selectedXFilter, selectedXFilter);

                }
                else
                {
                    Filter(selectedXFilter, selectedYFilter);
                }

                filtersApplied = true;
            }

            // If filters have been applied, enable the groupBoxEdgesDetection;
            // otherwise, show an error message
            if (filtersApplied)
            {
                groupBoxEdgesDetection.Enabled = true;
                pictureBox.Image = currentBitmap; // Display the filtered image in the picture box
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


      
        /// <summary>
        /// Apply the selected filters to the image and display the result in the picture box.
        /// </summary>
        /// <param name="xFilterName"></param>
        /// <param name="yFilterName"></param>
        public void Filter(string xFilterName, string yFilterName)
        {
            if (currentBitmap == null)
            {
                MessageBox.Show("You must load an image");
                return;
            }

            double[,] xFilterMatrix = GetFilterMatrix(xFilterName);
            double[,] yFilterMatrix = GetFilterMatrix(yFilterName);

            if (xFilterMatrix == null || yFilterMatrix == null)
            {
                MessageBox.Show("Invalid filter names");
                return;
            }

            ApplyEdgeDetector(xFilterMatrix, yFilterMatrix);
        }

        private double[,] GetFilterMatrix(string filterName)
        {
            switch (filterName)
            {
                case "Laplacian3x3":
                    return Matrix.Laplacian3x3;
                case "Laplacian5x5":
                    return Matrix.Laplacian5x5;
                case "LaplacianOfGaussian":
                    return Matrix.LaplacianOfGaussian;
                case "Gaussian3x3":
                    return Matrix.Gaussian3x3;
                case "Gaussian5x5Type1":
                    return Matrix.Gaussian5x5Type1;
                case "Gaussian5x5Type2":
                    return Matrix.Gaussian5x5Type2;
                case "Sobel3x3Horizontal":
                    return Matrix.Sobel3x3Horizontal;
                case "Sobel3x3Vertical":
                    return Matrix.Sobel3x3Vertical;
                case "Prewitt3x3Horizontal":
                    return Matrix.Prewitt3x3Horizontal;
                case "Prewitt3x3Vertical":
                    return Matrix.Prewitt3x3Vertical;
                case "Kirsch3x3Horizontal":
                    return Matrix.Kirsch3x3Horizontal;
                case "Kirsch3x3Vertical":
                    return Matrix.Kirsch3x3Vertical;
                default:
                    return Matrix.Laplacian3x3;
            }
        }

        /// <summary>
        ///  Apply the selected filters to the image and display the result in the picture box.
        /// </summary>
        /// <param name="xFilterMatrix"></param>
        /// <param name="yFilterMatrix"></param>
        private void ApplyEdgeDetector(double[,] xFilterMatrix, double[,] yFilterMatrix)
        {
            Bitmap newBitmap = new Bitmap(currentBitmap);
            BitmapData bitmapData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

            try
            {
                byte[] pixelBuffer  = new byte[bitmapData.Stride * bitmapData.Height];
                byte[] resultBuffer = new byte[bitmapData.Stride * bitmapData.Height];
                Marshal.Copy(bitmapData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                for (int offsetY = 1; offsetY < newBitmap.Height - 1; offsetY++)
                {
                    for (int offsetX = 1; offsetX < newBitmap.Width - 1; offsetX++)
                    {
                        ApplyFiltersToPixel(offsetX, offsetY,
                                                        bitmapData, pixelBuffer, resultBuffer, 
                                                        xFilterMatrix, yFilterMatrix);
                    }
                }

                Bitmap resultBitmap = new Bitmap(newBitmap.Width, newBitmap.Height);
                BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                try
                {
                    Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
                }
                finally
                {
                    resultBitmap.UnlockBits(resultData);
                }

                // update the current bitmap with the result
                currentBitmap = resultBitmap;
            }
            finally
            {
                newBitmap.UnlockBits(bitmapData);
            }
        }

        private void ApplyFiltersToPixel(int x, int y, BitmapData bitmapData, byte[] pixelBuffer, byte[] resultBuffer, double[,] xFilterMatrix, double[,] yFilterMatrix)
        {
            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            int filterOffset = 1;
            int byteOffset = y * bitmapData.Stride + x * 4;

            for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
            {
                for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                {
                    int calcOffset = byteOffset + (filterX * 4) + (filterY * bitmapData.Stride);

                    blueX += pixelBuffer[calcOffset] * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                    greenX += pixelBuffer[calcOffset + 1] * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                    redX += pixelBuffer[calcOffset + 2] * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                    blueY += pixelBuffer[calcOffset] * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                    greenY += pixelBuffer[calcOffset + 1] * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                    redY += pixelBuffer[calcOffset + 2] * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                }
            }

            double greenTotal = Math.Sqrt(greenX * greenX + greenY * greenY);
            double redTotal = Math.Sqrt(redX * redX + redY * redY);


            // trackBarThreshold est utilisé comme seuil pour déterminer si un pixel doit être considéré
            // comme blanc (255) ou noir (0) dans la composante verte après l'opération de filtrage.
            if (greenTotal < trackBarThreshold.Value)
            {
                greenTotal = 0;
            }
            else
            {
                greenTotal = 255;
            }


            resultBuffer[byteOffset] = (byte)(blueX);
            resultBuffer[byteOffset + 1] = (byte)(greenTotal);
            resultBuffer[byteOffset + 2] = (byte)(redTotal);
            resultBuffer[byteOffset + 3] = 255;
        }




    }
}