using ImageProcessingApp.Image.Filters;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace ImageProcessingApp.Image.UserControls
{
    public class SelectedFiltersViewModel : ReactiveObject
    {
        ReactiveList<SelectedFilterTileViewModel> _selectedFilters;
        public SelectedFiltersViewModel()
        {
            _selectedFilters = new ReactiveList<SelectedFilterTileViewModel>();
            _selectedFilters.ChangeTrackingEnabled = true;
            Filters = _selectedFilters.CreateDerivedCollection(x => x);
            Filters.ChangeTrackingEnabled = true;

            var filtersChanged = Filters.Changed;
            Filters.ItemChanged.Subscribe(_ => Console.WriteLine("params changed"));
            

            FiltersChanged =
                filtersChanged
                //.CombineLatest(parametersChanged, (fc, pc) => Unit.Default)
                .Select(_ => Filters.Select(t => t.Filter));

        }

        public IReactiveDerivedList<SelectedFilterTileViewModel> Filters { get; private set; }
        public IObservable<IEnumerable<ImageFilter>> FiltersChanged { get; private set; }

        public void AddFilter(ImageFilter filter)
        {
            var filterVM = new SelectedFilterTileViewModel(filter.Name, filter);
            _selectedFilters.Add(filterVM);

            filterVM.Remove.Subscribe(_ => _selectedFilters.Remove(filterVM));

            filterVM.MoveUp
                .Subscribe(_ =>
                {
                    var theList = _selectedFilters.ToList();
                    var curIdx = theList.IndexOf(filterVM);
                    if (curIdx != theList.Count - 1)
                    {
                        _selectedFilters.Move(curIdx, curIdx + 1);
                    }

                });

            filterVM.MoveDown
                .Subscribe(_ =>
                {
                    var theList = _selectedFilters.ToList();
                    var curIdx = theList.IndexOf(filterVM);
                    if (curIdx > 0)
                    {
                        _selectedFilters.Move(curIdx, curIdx - 1);
                    }
                });
        }
        
    }
}
