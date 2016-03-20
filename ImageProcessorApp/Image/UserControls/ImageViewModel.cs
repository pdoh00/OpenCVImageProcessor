using ImageProcessingApp.Image.Filters;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Image.UserControls
{
    public class ImageViewModel : ReactiveObject
    {
        public ImageViewModel(string filePath, IObservable<IEnumerable<ImageFilter>> filtersChanged)
        {


            UpdateImage(filePath, new List<ImageFilter>());

            filtersChanged
                .Subscribe(filters =>
            {
                UpdateImage(filePath, filters);
            });
        }

        private void UpdateImage(string filePath, IEnumerable<ImageFilter> filters)
        {
            if (File.Exists(filePath))
            {
                Mat m = new Mat(filePath, ImreadModes.GrayScale);
                foreach (var f in filters)
                {
                    f.Apply(m);
                }

                Image = ImgConversion.BitmapToBitmapSource(m.ToBitmap());
            }
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
