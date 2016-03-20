using ImageProcessingApp.Image.Filters;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;


namespace ImageProcessingApp.Image.UserControls
{
    public class ImageFilterMenuViewModel : ReactiveObject
    {
        public ImageFilterMenuViewModel(IEnumerable<ImageFilterData> menuItems, SelectedFiltersViewModel selectedVM)
        {
            MenuTiles = menuItems.CreateDerivedCollection(ifd =>
            {
                var menuTile = new ImageFilterMenuTileViewModel(ifd.Id, ifd.Name, ifd.Description);
                menuTile.Add.Subscribe(x => selectedVM.AddFilter(ImageFilterFactory.CreateFilter(ifd.Id)));
                return menuTile;
            });
        }

        public IReactiveDerivedList<ImageFilterMenuTileViewModel> MenuTiles { get; private set; }
    }
}
