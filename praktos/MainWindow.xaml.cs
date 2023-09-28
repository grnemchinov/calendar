using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Path = System.IO.Path;

namespace praktos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (!File.Exists("D:\\data.json"))
                File.Create("D:\\data.json").Close();
            InitializeComponent();
            DateTime datetime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            date_choose.DisplayDate = datetime;
            date_choose.SelectedDate = datetime;
            date_choose.Text = date_choose.DisplayDate.ToLongDateString();
           
        }

        private void UpdateField()
        {
            wrap_panel.Children.Clear();
            int DayCount = DateTime.DaysInMonth(date_choose.DisplayDate.Year, date_choose.DisplayDate.Month);
            List<Data> datas = JSONconv.getInfo<List<Data>>("D:\\data.json");
            for (int i = 1; i <= DayCount; i++)
            {
                string path = "";
                if (datas != null)
                {
                    foreach (Data data in datas)
                    {
                        if (data.Index == i && data.date == date_choose.DisplayDate)
                        {
                            switch (data.chosedPositions.First())
                            {
                                case "Даня":
                                    path = "resources\\burger.png";
                                    break;
                                case "Гриша":
                                    path = "resources\\soup.png";
                                    break;
                                case "Артем":
                                    path = "resources\\sushi.png";
                                    break;
                                case "Кирилл":
                                    path = "resources\\morozhkapng.png";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                dayInterface day = new dayInterface(date_choose.SelectedDate.Value, i, path);
                day.day_count.Content = i;
                wrap_panel.Children.Add(day);
            }
        }

        private void date_choose_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            wrap_panel.Children.Clear();
            UpdateField();

        }


        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if ((e.OriginalSource as Button).Name == "next_month")
            {
                date_choose.SelectedDate = date_choose.SelectedDate.Value.AddMonths(1);
            }
            else
            {
                date_choose.SelectedDate = date_choose.SelectedDate.Value.AddMonths(-1);
            }
        }
    }
}
