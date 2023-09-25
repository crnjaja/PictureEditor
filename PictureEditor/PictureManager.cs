using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public static class PictureManager
    {
        public static Image LoadImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select an Image File";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return Image.FromFile(openFileDialog.FileName);
                }
                return null;
            }
        }

        public static void SaveImage(Image imageToSave)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save an Image File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png; // Default to PNG
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 2:
                            format = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case 3:
                            format = System.Drawing.Imaging.ImageFormat.Bmp;
                            break;
                    }
                    imageToSave.Save(saveFileDialog.FileName, format);
                }
            }
        }
    }

}
