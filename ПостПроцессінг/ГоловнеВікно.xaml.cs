using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ПостПроцессінг
{
    /// <summary>
    /// Interaction logic for ГоловнеВікно.xaml
    /// </summary>
    public partial class ГоловнеВікно : Window
    {
        public ГоловнеВікно()
        {
            InitializeComponent();
            this.DataContext = new Людина() { Імя = "Андрій", Прізвище = "Курдюмов" };
        }
    }
}