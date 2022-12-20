using System.Drawing;
using ZXing.QrCode;

namespace QrCodeGenerator;

public static class Service
{
    public static byte[] GerarQRCodeDataMatrix(string text, int largura, int altura)
    {
        Byte[] byteArray;
        var qrCodeWriter = new ZXing.BarcodeWriterPixelData
        {
            Format = ZXing.BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = altura,
                Width = largura
            }
        };
        var pixelData = qrCodeWriter.Write(text);

        using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        
        using var ms = new MemoryStream();
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        try
        {
            System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }
        // save to stream as PNG
        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        byteArray = ms.ToArray();
        return byteArray;
    }
   public static void SaveBitmap(string fileName, int width, int height, byte[] imageData)
   {
       // Convert back to image.
       using var ms = new MemoryStream(imageData);
       var image = Image.FromStream(ms);
       image.Save(fileName);
   }
}