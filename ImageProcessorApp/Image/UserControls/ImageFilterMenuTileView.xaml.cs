using ReactiveUI;
using System.Windows;
using System.Windows.Controls;

namespace ImageProcessingApp.Image.UserControls
{
    /// <summary>
    /// Interaction logic for ImageFilterMenuTile.xaml
    /// </summary>
    public partial class ImageFilterMenuTileView : UserControl, IViewFor<ImageFilterMenuTileViewModel>
    {
        public ImageFilterMenuTileView()
        {
            InitializeComponent();
            this.OneWayBind(ViewModel, vm => vm.Name, v => v.txtFilterName.Text);
            this.OneWayBind(ViewModel, vm => vm.Description, v => v.txtDescription.Text);
            this.BindCommand(ViewModel, vm => vm.Add, v => v.btnAdd);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ImageFilterMenuTileViewModel), typeof(ImageFilterMenuTileView), new PropertyMetadata(null));

        public ImageFilterMenuTileViewModel ViewModel
        {
            get { return (ImageFilterMenuTileViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ImageFilterMenuTileViewModel)value; }
        }
    }
}
