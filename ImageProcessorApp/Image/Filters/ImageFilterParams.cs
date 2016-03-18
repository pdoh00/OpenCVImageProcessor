using OpenCvSharp;
using ReactiveUI;
using System.Collections.Generic;

namespace ImageProcessingApp.Image.Filters
{
    public class ImageFilterParam : ReactiveObject
    {
        public ImageFilterParam(string name, double min, double max, double step, double defaultValue)
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
        private double _Value;
        public double Value
        {
            get { return _Value; }
            set { this.RaiseAndSetIfChanged(ref _Value, value); }
        }
        
    }

    public abstract class ImageFilter : ReactiveObject
    {
        Dictionary<string, ImageFilterParam> _params = new Dictionary<string, ImageFilterParam>();
        ReactiveList<ImageFilterParam> _p = new ReactiveList<ImageFilterParam>();

        public ImageFilter(params ImageFilterParam[] @params)
        {
            _p.ChangeTrackingEnabled = true;
            foreach (var p in @params)
            {
                _p.Add(p);
                _params.Add(p.Name, p);
            }
        }

        public ReactiveList<ImageFilterParam> Parameters { get { return _p; } }

        public IDictionary<string, ImageFilterParam> GetParameters()
        {
            return _params;
        }

        public abstract string Name { get; }

        //Pass img by ref
        public abstract void Apply(Mat img);
    }

}
