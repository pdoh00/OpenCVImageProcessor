using OpenCvSharp;

namespace ImageProcessingApp.Image.Filters
{
    /// <summary>
    /// Calculates the Laplacian of an image.
    /// <seealso cref="http://docs.opencv.org/3.1.0/d4/d86/group__imgproc__filter.html#gad78703e4c8fe703d479c1860d76429e6"/>
    /// </summary>
    public class LaplacianImageFilter : ImageFilter
    {
        public LaplacianImageFilter() :
            this(new ImageFilterParam("KernalSize", 1.0, 101.0, 2.0, 9.0),
                 new ImageFilterParam("Scale", 0.0, 100.0, 0.01, 0.75))
        { }

        public LaplacianImageFilter(ImageFilterParam kernalSize, ImageFilterParam scale) :
            this(new[] { kernalSize, scale })
        { }

        public LaplacianImageFilter(params ImageFilterParam[] @params) : base(FilterType.Laplacian, @params) { }

        public static string Description
        {
            get
            {
                return "Calculates the Laplacian of the source image by adding up the second x and y derivatives calculated using the Sobel operator";
            }
        }

        public static string FilterName
        {
            get
            {
                return "Laplacian";
            }
        }

        /// <summary>
        /// Calculates the Laplacian of the source image by adding up the second x and y derivatives calculated using the Sobel operator
        /// and applies it to the input image
        /// </summary>
        /// <param name="img">Image to Laplca</param>
        /// <param name="parameters">A <see cref="LaplacianImageFilterParams"/></param>
        public override void Apply(Mat img)
        {
            var kernalSize = (int)GetParameters()["KernalSize"].Value;
            var scale = GetParameters()["Scale"].Value;
            Cv2.Laplacian(img, img, MatType.CV_8UC1, kernalSize, scale, 0, BorderTypes.Default);
        }

        public override string Name
        {
            get { return FilterName; }
        }

    }
}
