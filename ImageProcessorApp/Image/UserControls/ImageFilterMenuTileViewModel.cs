using ImageProcessingApp.Image.Filters;
using ReactiveUI;

namespace ImageProcessingApp.Image.UserControls
{
    public class ImageFilterMenuTileViewModel : ReactiveObject
    {
        public ImageFilterMenuTileViewModel(FilterType filterId, string name, string description)
        {
            FilterId = filterId;
            Name = name;
            Description = description;
            Add = ReactiveCommand.Create();
        }

        public FilterType FilterId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ReactiveCommand<object> Add { get; private set; }
    }
}
