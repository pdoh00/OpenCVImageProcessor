using ImageProcessingApp.Image.UserControls;
using ReactiveUI;

namespace ImageProcessingApp
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel(ImageViewModel imageViewModel, 
            ImageFilterMenuViewModel imageFilterMenuViewModel,
            SelectedFiltersViewModel selectedFiltersViewModel)
        {
            ImageViewModel = imageViewModel;
            ImageFilterMenuViewModel = imageFilterMenuViewModel;
            SelectedFiltersViewModel = selectedFiltersViewModel;
        }

        public ImageViewModel ImageViewModel { get; private set; }
        public ImageFilterMenuViewModel ImageFilterMenuViewModel { get; private set; }
        public SelectedFiltersViewModel SelectedFiltersViewModel { get; private set; }
    }
}
