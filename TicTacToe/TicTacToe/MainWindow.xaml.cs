using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TicTacToe
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

        int[] datePosition = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        bool isPlaying = true;
        bool finding = true;

        public void checkWin()
        {
            if (n1.Text == "X" && n2.Text == "X" && n3.Text == "X" ||
                n4.Text == "X" && n5.Text == "X" && n6.Text == "X" ||
                n7.Text == "X" && n8.Text == "X" && n9.Text == "X" ||
                n1.Text == "X" && n4.Text == "X" && n7.Text == "X" ||
                n2.Text == "X" && n5.Text == "X" && n8.Text == "X" ||
                n3.Text == "X" && n6.Text == "X" && n9.Text == "X" ||
                n1.Text == "X" && n5.Text == "X" && n9.Text == "X" ||
                n3.Text == "X" && n5.Text == "X" && n7.Text == "X")
            {
                
            }
        }

        public void SetX(object sender, RoutedEventArgs e)
        {
            string sourceName = ((FrameworkElement)e.Source).Name;
            int labelId = int.Parse(Regex.Match(sourceName, @"\d+").Value);
            var currLabel = (TextBlock)this.FindName(sourceName);

            if (isPlaying)
            {
                if (datePosition[labelId - 1] == 0)
                {
                    currLabel.Text = "X";
                    datePosition[labelId - 1] = labelId;
                    checkWin();

                    if (isPlaying)
                    {
                        while (finding)
                        {
                            foreach (var i in datePosition)
                            {
                                Debug.WriteLine(i);
                            }
                        }
                    }
                }
            }
        }
    }
}
