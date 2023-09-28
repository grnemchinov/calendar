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

namespace praktos
{
    /// <summary>
    /// Логика взаимодействия для dayInterface.xaml
    /// </summary>
    public partial class dayInterface : UserControl
    {
        public DateTime date;
        public int index;
        public dayInterface(DateTime date, int index, string food)
        {
            InitializeComponent();
            if (food != "")
                image.Source = (new ImageSourceConverter().ConvertFromString(food) as ImageSource);
            this.date = date;
            this.index = index;
        }

        private void open_dayInfo_Click(object sender, RoutedEventArgs e)
        {
            DayWindow DW = new DayWindow(date, index);
            DW.Show();
        }
    }
}
