using ImageProcessingApp.Image.Filters;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ImageProcessingApp.Image.UserControls
{
    public class SelectedFiltersViewModel : ReactiveObject
    {
        Subject<IEnumerable<ImageFilter>> _FiltersChanged = new Subject<IEnumerable<ImageFilter>>();
        Subject<Unit> _ParamChanged = new Subject<Unit>();
        
        public SelectedFiltersViewModel()
        {
            _Filters = new ReactiveList<SelectedFilterTileViewModel>();
            _Filters.ChangeTrackingEnabled = true;

            _ParamChanged.Subscribe(_ => Console.WriteLine("Param changed"));

            Filters.Changed
                .CombineLatest(_ParamChanged, (fc, pc) => Unit.Default)
                .Subscribe(_ => _FiltersChanged.OnNext(_Filters.Select(fvm => CreateImageFilterModel(fvm))));

            FiltersChanged = _FiltersChanged;
        }

        private static ImageFilter CreateImageFilterModel(SelectedFilterTileViewModel fvm)
        {
            var @params = new List<ImageFilterParam>();
            foreach (var p in fvm.Parameters)
            {
                @params.Add(new ImageFilterParam(p.Name, p.Min, p.Max, p.Step, p.Default) { Value = p.Value });
            }
            return ImageFilterFactory.CreateFilter(fvm.FilterType, @params.ToArray());
        }

        private ReactiveList<SelectedFilterTileViewModel> _Filters;
        public ReactiveList<SelectedFilterTileViewModel> Filters
        {
            get { return _Filters; }
            set { this.RaiseAndSetIfChanged(ref _Filters, value); }
        }

        public IObservable<IEnumerable<ImageFilter>> FiltersChanged { get; private set; }

        public void AddFilter(ImageFilter filter)
        {
            var filterVM = new SelectedFilterTileViewModel(filter.Name, filter);

            filterVM.ParamChanged.Subscribe(_ => _ParamChanged.OnNext(Unit.Default));
            filterVM.Remove.Subscribe(_ => _Filters.Remove(filterVM));
            filterVM.MoveUp.Subscribe(_ =>
                {
                    var theList = _Filters.ToList();
                    var curIdx = theList.IndexOf(filterVM);
                    if (curIdx != theList.Count - 1)
                    {
                        _Filters.Move(curIdx, curIdx + 1);
                    }
                });
            filterVM.MoveDown.Subscribe(_ =>
                {
                    var theList = _Filters.ToList();
                    var curIdx = theList.IndexOf(filterVM);
                    if (curIdx > 0)
                    {
                        _Filters.Move(curIdx, curIdx - 1);
                    }
                });

            Filters.Add(filterVM);
        }
    }
}
