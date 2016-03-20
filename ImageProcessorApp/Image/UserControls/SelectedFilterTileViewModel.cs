using ImageProcessingApp.Image.Filters;
using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Linq;

namespace ImageProcessingApp.Image.UserControls
{
    public class SelectedFilterTileViewModel : ReactiveObject
    {
        public SelectedFilterTileViewModel(string name, ImageFilter filter)
        {
            FilterType = filter.FilterType;
            Parameters = new ReactiveList<FilterParameterTileViewModel>();
            Parameters.ChangeTrackingEnabled = true;

            foreach (var fp in filter.GetParameters().Values)
            {
                Parameters.Add(new FilterParameterTileViewModel(fp));
            }
            
            Name = name;
            Remove = ReactiveCommand.Create();
            MoveUp = ReactiveCommand.Create();
            MoveDown = ReactiveCommand.Create();

            ParamChanged = Parameters.ItemChanged.Select(_=> Unit.Default);
        }

        public FilterType FilterType { get; private set; }
        public string Name { get; private set; }
        public ReactiveCommand<object> Remove { get; private set; }
        public ReactiveCommand<object> MoveUp { get; private set; }
        public ReactiveCommand<object> MoveDown { get; private set; }

        public IObservable<Unit> ParamChanged { get; private set; }

        private ReactiveList<FilterParameterTileViewModel> _Parameters;
        public ReactiveList<FilterParameterTileViewModel> Parameters
        {
            get { return _Parameters; }
            set { this.RaiseAndSetIfChanged(ref _Parameters, value); }
        }
    }

}
