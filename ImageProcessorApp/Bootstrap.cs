using System;
using ImageProcessingApp.Image.Filters;
using ImageProcessingApp.Image.UserControls;
using OpenCvSharp;
using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.Linq;

namespace ImageProcessingApp
{
    class Bootstrap
    {
        MainWindowView _mainView;

        public Bootstrap(string fileLocation)
        {
            Locator.CurrentMutable.Register(() => new CineImageView(), typeof(IViewFor<ImageViewModel>));
            Locator.CurrentMutable.Register(() => new ImageFilterMenuView(), typeof(IViewFor<ImageFilterMenuViewModel>));
            Locator.CurrentMutable.Register(() => new ImageFilterMenuTileView(), typeof(IViewFor<ImageFilterMenuTileViewModel>));
            Locator.CurrentMutable.Register(() => new SelectedFilterTileView(), typeof(IViewFor<SelectedFilterTileViewModel>));
            Locator.CurrentMutable.Register(() => new FilterParameterTileView(), typeof(IViewFor<FilterParameterTileViewModel>));
            Locator.CurrentMutable.Register(() => new SelectedFiltersView(), typeof(IViewFor<SelectedFiltersViewModel>));
            
            var imgFilters = ImageFilterFactory.GetAvailableFilters();
            var selectedFilters = new List<ImageFilter>();
            var selectedFiltersVM = new SelectedFiltersViewModel();
            var imgFilterMenuVM = new ImageFilterMenuViewModel(imgFilters, selectedFiltersVM);

            var cineImgVM = new ImageViewModel(fileLocation, selectedFiltersVM.FiltersChanged);

            var mainWinVM = new MainWindowViewModel(cineImgVM, imgFilterMenuVM, selectedFiltersVM);

            _mainView = new MainWindowView(mainWinVM);
        }

        public void Start()
        {
            _mainView.ShowDialog();
        }
        
    }
}
