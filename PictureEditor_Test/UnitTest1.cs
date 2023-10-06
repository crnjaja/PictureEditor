using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using PresentationLayer;
using PresentationLayer.ImageProcessing;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PictureEditor_Test
{
    [TestClass]
    public class UnitTest1
    {

        public static string ResourcesPath = Directory.GetCurrentDirectory() + "\\Ressources";
        public static string OriginalPath = ResourcesPath + "\\original.bmp";
        public static string HellPath       = ResourcesPath + "\\FilterHell.bmp";


        [TestMethod]
        public void TestMethod1()
        {
            //1)  Pour tester les filtres, 2 filtres à tester, il faut dabord le faire manuellement, sauver l'image fait manuellement, la mettre dans le dossier ressources
            // et ensuite le test doit refaire mon truc manuel, et comparer mes 2 imgages pixel par pixel.

            // 2) Pour faire ça avec les algos, same avec 3 algos

            // Pour ces 5 trucs à tester, je dois couvrir le 100% de code coverage
        
            
        }

        [TestMethod]
        public void TestMethod2()
        {
            // 1) Load images
            //Bitmap hellFilterApplied = (Bitmap)Image.FromFile(HellPath);         // 1) Load the image with the filter already applied
            Bitmap hellFilterApplied = new Bitmap(HellPath);         // 1) Load the image with the filter already applied
            Bitmap imageTest            = new Bitmap(OriginalPath);    // 2) Load the original image to modify and then compare with the other image

            // 2) Apply the filter
            imageTest = ImageFilters.ApplyFilter( imageTest , 1, 1, 10, 15);

            // 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 1 RGB value for each pixel
            Assert.IsTrue(CompareImages(hellFilterApplied, imageTest, 1));
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