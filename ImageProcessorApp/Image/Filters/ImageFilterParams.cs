using OpenCvSharp;
using System.Collections.Generic;

namespace ImageProcessingApp.Image.Filters
{
    public struct ImageFilterParam
    {
        public ImageFilterParam(string name, double min, double max, double step, double defaultValue) : this()
        {
            Name = name;
            Min = min;
            Max = max;
            Step = step;
            Default = defaultValue;
            Value = Default;
        }

        public string Name { get; private set; }
        public double Min { get; private set; }
        public double Max { get; private set; }
        public double Step { get; private set; }
        public double Default { get; private set; }
        public double Value { get; set; }
    }

    public abstract class ImageFilter
    {
        Dictionary<string, ImageFilterParam> _params = new Dictionary<string, ImageFilterParam>();

        public ImageFilter(FilterType type, params ImageFilterParam[] @params)
        {
            FilterType = type;
            foreach (var p in @params)
            {
                _params.Add(p.Name, p);
            }
        }

        public IDictionary<string, ImageFilterParam> GetParameters()
        {
            return _params;
        }

        public abstract string Name { get; }
        public FilterType FilterType { get; private set; }

        //Pass img by ref
        public abstract void Apply(Mat img);
    }
}
