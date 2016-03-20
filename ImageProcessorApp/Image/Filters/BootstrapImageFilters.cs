using System;
using System.Collections.Generic;

namespace ImageProcessingApp.Image.Filters
{
    public enum FilterType
    {
        Gauss = 0,
        Laplacian
    }

    public struct ImageFilterData
    {
        public ImageFilterData(FilterType id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public FilterType Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }

    public static class ImageFilterFactory
    {
        public static IEnumerable<ImageFilterData> GetAvailableFilters()
        {
            return new List<ImageFilterData>
            {
                new ImageFilterData(FilterType.Gauss, GaussImageFilter.FilterName, GaussImageFilter.Description),
                new ImageFilterData(FilterType.Laplacian, LaplacianImageFilter.FilterName, LaplacianImageFilter.Description),
                //Add next filter data here:
            };
        }

        public static ImageFilter CreateFilter(FilterType type)
        {
            switch (type)
            {
                case FilterType.Gauss:
                    {
                        return new GaussImageFilter();
                    }
                case FilterType.Laplacian:
                    {
                        return new LaplacianImageFilter();
                    }
                //Add next filter here:
                default:
                    throw new ArgumentException("Invalid FilterType {0}", type.ToString());
            }
        }

        public static ImageFilter CreateFilter(FilterType type, params ImageFilterParam[] @params)
        {
            switch (type)
            {
                case FilterType.Gauss:
                    {
                        return new GaussImageFilter(@params);
                    }
                case FilterType.Laplacian:
                    {
                        return new LaplacianImageFilter(@params);
                    }
                //Add next filter here:
                default:
                    throw new ArgumentException("Invalid FilterType {0}", type.ToString());
            }
        }
    }
}
