using ReactiveUI;
using System.Windows;
using System.Windows.Controls;

namespace ImageProcessingApp.Image.UserControls
{
    /// <summary>
    /// Interaction logic for ImageProcessingMenu.xaml
    /// </summary>
    public partial class ImageFilterMenuView : UserControl, IViewFor<ImageFilterMenuViewModel>
    {
        public ImageFilterMenuView()
        {
            InitializeComponent();
            this.OneWayBind(ViewModel, vm => vm.MenuTiles, v => v.lstMenuItems.ItemsSource);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ImageFilterMenuViewModel), typeof(ImageFilterMenuView), new PropertyMetadata(null));

        public ImageFilterMenuViewModel ViewModel
        {
            get { return (ImageFilterMenuViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ImageFilterMenuViewModel)value; }
        }
    }
}
