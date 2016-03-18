using ImageProcessingApp.Image.Filters;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Reactive.Linq;
using System.Linq;
using OpenCvSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media;
using OpenCvSharp.Extensions;
using System.Windows;
using System.Runtime.InteropServices;

namespace ImageProcessingApp.Image.UserControls
{
    public class ImageViewModel : ReactiveObject
    {
        public ImageViewModel(string filePath, IObservable<IEnumerable<ImageFilter>> filtersChanged)
        {
            UpdateImage(filePath, new List<ImageFilter>());

            filtersChanged.Subscribe(filters =>
            {
                UpdateImage(filePath, filters);
            });
        }

        private void UpdateImage(string filePath, IEnumerable<ImageFilter> filters)
        {
            Mat m = new Mat(filePath, ImreadModes.GrayScale);
            foreach (var f in filters)
            {
                f.Apply(m);
            }
           
            Image = ImgConversion.BitmapToBitmapSource(m.ToBitmap());
        }

        private BitmapSource _Image;
        public BitmapSource Image
        {
            get { return _Image; }
            set { this.RaiseAndSetIfChanged(ref _Image, value); }
        }

        
    }

    public static class ImgConversion
    {
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public static BitmapSource BitmapToBitmapSource(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            lock (bitmap)
            {
                IntPtr hBitmap = bitmap.GetHbitmap();

                try
                {
                    return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        hBitmap,
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
                }
                finally
                {
                    DeleteObject(hBitmap);
                }
            }
        }
    }
}
