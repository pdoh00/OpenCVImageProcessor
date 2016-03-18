using ReactiveUI;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Reactive.Linq;

namespace ImageProcessingApp.Image.UserControls
{
    /// <summary>
    /// Interaction logic for CineImageView.xaml
    /// </summary>
    public partial class CineImageView : UserControl, IViewFor<ImageViewModel>
    {
        public CineImageView()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, vm => vm.Image, v => v.image.Source);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ImageViewModel), typeof(CineImageView), new PropertyMetadata(null));

        public ImageViewModel ViewModel
        {
            get { return (ImageViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ImageViewModel)value; }
        }
    }
}
