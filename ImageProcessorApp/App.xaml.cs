using System.IO;
using System.Windows;

namespace ImageProcessingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var filePath = "";
            if(e.Args.Length > 0 && e.Args[0] != null)
            {
                if(File.Exists(e.Args[0]))
                {
                    filePath = e.Args[0];
                }
            }
            else
            {
                var ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
                var result = ofd.ShowDialog();
                if (result.HasValue && result.Value == true)
                {
                    filePath = ofd.FileName;
                }

            }
            
            if(string.IsNullOrWhiteSpace(filePath))
            {
                Application.Current.Shutdown(-1);
            }

            var bootstrap = new Bootstrap(filePath);
            bootstrap.Start();
        }
    }
}
