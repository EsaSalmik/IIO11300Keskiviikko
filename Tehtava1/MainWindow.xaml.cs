/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 19.1.2016
* Authors: Tatu Reijonen, Esa Salmikangas
*/
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            try
            {
                double result;
                result = BusinessLogicWindow.CalculatePerimeter(1, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
        }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {


    }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            /*try
             {
                 double result;
                 result = BusinessLogicWindow.CalculatePerimeter(1, 1);

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 //yield to an user that everything okay

             }*/

            try
            {
                double length = double.Parse(textBox_Length.Text);
                double height = double.Parse(textBox_Height.Text);
                /* textBox_Area.Text = (length * height).ToString(); */
                double area1 = length * height;
                textBox_Area.Text = area1.ToString();
                double extrawidth = double.Parse(textBox_Width.Text) * 2;
                length = length - extrawidth;
                height = height - extrawidth;
                double area2 = length * height;
                area2 = area1 - area2;
                textBox_PerimeterArea.Text = area2.ToString();
                length = length * 2;
                height = height * 2;
                textBox_Perimeter.Text = (length + height).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
//                throw;
            }




        }

        private void btnCalculateAreaOO_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //lasketaan pinta-ala Ikkuna-olion avulla
                //luodaan luokasta olio
                JAMK.IT.IIO11300.Ikkuna ikk = new JAMK.IT.IIO11300.Ikkuna();
                ikk.Korkeus = double.Parse(textBox_Height.Text);
                ikk.Leveys = double.Parse(textBox_Length.Text);
                //tulos käyttäjälle
                //VE metodilla
                //MessageBox.Show(ikk.LaskePintaAla().ToString());
                //VE property
                MessageBox.Show(ikk.PintaAla.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class BusinessLogicWindow
    {
    /// <summary>
    /// CalculatePerimeter calculates the perimeter of a window
    /// </summary>
    public static double CalculatePerimeter(double widht, double height)
        {
            throw new System.NotImplementedException();
        }
    }
}
