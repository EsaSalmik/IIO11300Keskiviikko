using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace H5MoviesXML
{
  /// <summary>
  /// Interaction logic for Movies0.xaml
  /// </summary>
  public partial class Movies0 : Window
  {
    public Movies0()
    {
      InitializeComponent();
    }

    private void btnOpenMovies1_Click(object sender, RoutedEventArgs e)
    {
      OpenWindow(new Movies1());
    }
    private void btnOpenMovies2_Click(object sender, RoutedEventArgs e)
    {
      OpenWindow(new Movies2());
    }
    private void OpenWindow(Window myWin)
    {
      myWin.ShowDialog();
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

  }
}
