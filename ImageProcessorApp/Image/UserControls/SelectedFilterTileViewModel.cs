using ImageProcessingApp.Image.Filters;
using ReactiveUI;

namespace ImageProcessingApp.Image.UserControls
{
    public class SelectedFilterTileViewModel : ReactiveObject
    {
        readonly ReactiveList<FilterParameterTileViewModel> _FilterParameters;

        public SelectedFilterTileViewModel(string name, ImageFilter filter)
        {
            Filter = filter;
            _FilterParameters = new ReactiveList<FilterParameterTileViewModel>();
            foreach (var fp in Filter.Parameters)
            {
                _FilterParameters.Add(new FilterParameterTileViewModel(fp));
            }

            Parameters = _FilterParameters.CreateDerivedCollection(fp => fp);
            Parameters.ChangeTrackingEnabled = true;

            Name = name;
            Remove = ReactiveCommand.Create();
            MoveUp = ReactiveCommand.Create();
            MoveDown = ReactiveCommand.Create();
        }

        public ImageFilter Filter { get; private set; }

        public string Name { get; private set; }
        //public IReactiveDerivedList<FilterParameterTileViewModel> Parameters { get; private set; }
        public ReactiveCommand<object> Remove { get; private set; }
        public ReactiveCommand<object> MoveUp { get; private set; }
        public ReactiveCommand<object> MoveDown { get; private set; }

        private IReactiveDerivedList<FilterParameterTileViewModel> _Parameters;
        public IReactiveDerivedList<FilterParameterTileViewModel> Parameters
        {
            get { return _Parameters; }
            set { this.RaiseAndSetIfChanged(ref _Parameters, value); }
        }
    }

}
