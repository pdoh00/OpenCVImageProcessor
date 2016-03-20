using OpenCvSharp;
using System.Collections.Generic;

namespace ImageProcessingApp.Image.Filters
{
    /// <summary>
    /// Blurs an image using a Gaussian filter.
    /// <seealso cref="http://docs.opencv.org/3.1.0/d4/d86/group__imgproc__filter.html#gaabe8c836e97159a9193fb0b11ac52cf1"/>
    /// </summary>
    public class GaussImageFilter : ImageFilter
    {
        Dictionary<string, ImageFilterParam> _params = new Dictionary<string, ImageFilterParam>();

        /// <summary>
        /// Create a GaussImageFilter with default ImageFilterParam values
        /// </summary>
        public GaussImageFilter() :
            this(new ImageFilterParam("KernalSize", 3.0, 101.0, 2.0, 3.0),
                 new ImageFilterParam("SigmaX", 0.0, 100.0, 0.1, 1.6),
                 new ImageFilterParam("SigmaY", 0.0, 100.0, 0.1, 1.6))
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernalSize">Gaussian kernel size. kernalSize must be positive and odd. Or, it can be zero and then is computed from sigma.</param>
        /// <param name="sigmaX">Gaussian kernel standard deviation in X direction.</param>
        /// <param name="sigmaY">Gaussian kernel standard deviation in Y direction; if sigmaY is zero, it is set to be equal to sigmaX, if both sigmas are zeros, 
        public GaussImageFilter(ImageFilterParam kernalSize, ImageFilterParam sigmaX, ImageFilterParam sigmaY) :
            this(new[] { kernalSize, sigmaX, sigmaY })
        { }

        public GaussImageFilter(params ImageFilterParam[] @params) : base(FilterType.Gauss, @params) { }

        public static string Description
        {
            get
            {
                return "Convolves the source image with the specified Gaussian kernel";
            }
        }

        public static string FilterName
        {
            get
            {
                return "Gauss";
            }
        }

        /// <summary>
        /// Applies a Gaussian Blur to img
        /// </summary>
        /// <param name="img">Image to blur</param>
        /// <param name="parameters">A <seealso cref="GaussImageFilterParams"/></param>
        public override void Apply(Mat img)
        {
            var kernalSize = GetParameters()["KernalSize"].Value;
            var sigmaX = GetParameters()["SigmaX"].Value;
            var sigmaY = GetParameters()["SigmaY"].Value;

            Cv2.GaussianBlur(img, img, new Size(kernalSize, kernalSize), sigmaX, sigmaY, BorderTypes.Default);
        }

        public override string Name
        {
            get { return FilterName; }
        }
    }
}
