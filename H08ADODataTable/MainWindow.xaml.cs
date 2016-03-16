using System;
using System.Data; //for general ADO-classes
using System.Data.SqlClient; //for SQL Server specific classes
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

namespace H08ADODataTable
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    DataTable dt;
    DataView dv;
    List<string> cities;
    public MainWindow()
    {
      InitializeComponent();
      //IniMyStuff();
    }

    private void IniMyStuff()
    {
      //asetetaan kaupunkien nimet ComboBoxiin
      cities = new List<string>();
      //VE1 kaupungin nimet "kovakoodattu"
      //cities.Add("Jyväskylä");
      //cities.Add("Helsinki");
      //cities.Add("New York");
      //VE2 käydään loopittamalla DataTable läpi
      string kaupunki = "";
      foreach (DataRow item in dt.Rows)
      {
        kaupunki = item["City"].ToString();
        //tai
        kaupunki = item[3].ToString();
        //lisätään kukin kaupunki vain kerran listaan
        if (!cities.Contains(kaupunki))
          cities.Add(kaupunki);
      }
      //VE3 LINQ:lla voi tehdä kyselyn tyypitettyyn DataTableen, huom ei kaikille DataTablella
      //joten ei toimi tässä
      //var result = (from c in dt
      //              select c.City).Distinct();
      //databindaus
      cbCities.ItemsSource = cities;
    }
    private void btnGetData_Click(object sender, RoutedEventArgs e)
    {
      //haetaan viiniasiakkaat palvelimelta ja näytetään ne ListBoxissa
      try
      {
        GetData();
        //VE1 dataview filtteroitta tai sorttaatte
        dv = dt.DefaultView;
        //datan sitominen UI-kontrolliin, 
        //kelpaa: DataTable, DataView, DataReader, oliokokoelma
        lbCustomers.DataContext = dv;
        //huom DataTable sarake (column) on casesensitiivinen
        lbCustomers.DisplayMemberPath = "Lastname";

        IniMyStuff();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void lbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //vaihdetaan stackpanelin datacontext viittaamaan valittuun asiakkaaseen
      spCustomer.DataContext = lbCustomers.SelectedItem;
    }

    #region METHODS
    private void GetData()
    {
      //luodaan yhteys tietokantaan connectionstringin avulla
      try
      {
        using (SqlConnection conn = 
          new SqlConnection(H08ADODataTable.Properties.Settings.Default.Tietokanta))
        {
          dt = new DataTable();
          string sql = "SELECT * FROM vCustomers";
          SqlDataAdapter da = new SqlDataAdapter(sql, conn);
          //pistetään dataadapter hakemaan tiedot muistiin=DataTableen
          da.Fill(dt);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    #endregion

    private void cbCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //asetetaan DataView:llä filtteri
      dv.RowFilter = string.Format("City LIKE '{0}'", cbCities.SelectedValue);
    }
  }
}
