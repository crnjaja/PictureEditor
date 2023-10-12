using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using PresentationLayer;
using PresentationLayer.ImageProcessing;
using PresentationLayer.ImageProcessing.EdgeDetector;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PictureEditor_Test
{
    [TestClass]
    public class ImageFilters_Test
    {

        public static string ResourcesPath = Directory.GetCurrentDirectory() + "\\Ressources";
        public static string OriginalPath = ResourcesPath + "\\original.bmp";
        public static string HellPath       = ResourcesPath + "\\FilterHell.bmp";
        public static string BlackWhitePath  = ResourcesPath + "\\BlackAndWhite.bmp";



        [TestMethod]
        public void TestMethod1()
        {
            //1)  Pour tester les filtres, 2 filtres à tester, il faut dabord le faire manuellement, sauver l'image fait manuellement, la mettre dans le dossier ressources
            // et dans les paramètres -> (propriétés > Toujours copier !).
            // Ensuite le test doit refaire mon truc manuel, et comparer mes 2 imgages pixel par pixel.

            // 2) Pour faire ça avec les algos, same avec 3 algos

            // Pour ces 5 trucs à tester, je dois couvrir le 100% de code coverage


        }

        /// <summary>
        /// Test the filter "Hell" with the original image. 
        /// The filter "Hell" is applied to the original image and then compared pixel by pixel with the image already modified.
        /// </summary>
        [TestMethod]
        public void TestFilterHell()
        {
            // 1) Load images
            Bitmap hellFilterApplied = new Bitmap(HellPath);         // 1) Load the image with the filter already applied
            Bitmap imageTest            = new Bitmap(OriginalPath);    // 2) Load the original image to modify and then compare with the other image

            // 2) Apply the filter
            imageTest = ImageFilters.ApplyFilter( imageTest , 1, 1, 10, 15);

            // 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 1 RGB value for each pixel
            int tolerance = 1;
            Assert.IsTrue(CompareImages(hellFilterApplied, imageTest, tolerance));
        }

        /// <summary>
        /// Test the filter "BlackWhite" with the original image. 
        /// The filter "BlackWhite" is applied to the original image and then compared pixel by pixel with the image already modified.
        /// </summary>
        [TestMethod]
        public void TestFilterBlackAndWhite()
        {
            // 1) Load images
            Bitmap bwFilterApplied = new Bitmap(BlackWhitePath);         // 1) Load the image with the filter already applied
            Bitmap imageTest = new Bitmap(OriginalPath);                        // 2) Load the original image to modify and then compare with the other image

            // 2) Apply the filter
            imageTest = ImageFilters.BlackWhite(imageTest);

            // 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 1 RGB value for each pixel
            int tolerance = 1;
            Assert.IsTrue(CompareImages(bwFilterApplied, imageTest, tolerance));
        }

        [TestMethod]
        public void TestEdgeDetectorAlgo_()
        {
            // 1) Load images
            Bitmap bwFilterApplied = new Bitmap(BlackWhitePath);         // 1) Load the image with the filter already applied
            Bitmap imageTest = new Bitmap(OriginalPath);                        // 2) Load the original image to modify and then compare with the other image

            // Get the matrix
            double[,] xFilterMatrix = GetFilterMatrix(xFilterName);
            double[,] yFilterMatrix = GetFilterMatrix(yFilterName);

            if (xFilterMatrix == null || yFilterMatrix == null)
            {
                MessageBox.Show("Invalid filter names");
                return;
            }

            // 2) Apply the algorithm
            imageTest = ApplyEdgeDetector(xFilterMatrix, yFilterMatrix);

            // 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 1 RGB value for each pixel
            int tolerance = 1;
            Assert.IsTrue(CompareImages(bwFilterApplied, imageTest, tolerance));
        }


        /// <summary>
        /// Compares two images pixel by pixel to check if they are identical.
        /// </summary>
        /// <param name="imageA">The first image to compare.</param>
        /// <param name="imageB">The second image to compare.</param>
        /// <returns>True if the images are identical; otherwise, false.</returns>
        private bool CompareImages(Bitmap imageA, Bitmap imageB, int tolerance)
        {
            // Check if the images have the same dimensions
            if (imageA.Width != imageB.Width ||
                imageA.Height != imageB.Height)
            {
                return false;
            }

            // Iterate through each pixel and compare colors
            for (int i = 0; i < imageA.Width; i++)
            {
                for (int j = 0; j < imageA.Height; j++)
                {
                    // Get the color of the pixel in each image
                    Color pixelColorA = imageA.GetPixel(i, j);
                    Color pixelColorB = imageB.GetPixel(i, j);

                    // Compare color components with tolerance
                    if (Math.Abs(pixelColorA.R - pixelColorB.R) > tolerance ||
                        Math.Abs(pixelColorA.G - pixelColorB.G) > tolerance ||
                        Math.Abs(pixelColorA.B - pixelColorB.B) > tolerance ||
                        Math.Abs(pixelColorA.A - pixelColorB.A) > tolerance)
                    {
                        // If the difference in any color component is greater than the tolerance, the images are not identical
                        return false;
                    }
                }
            }

            // If all pixels are within the tolerance range, the images are considered the same
            return true;
        }


    }
}