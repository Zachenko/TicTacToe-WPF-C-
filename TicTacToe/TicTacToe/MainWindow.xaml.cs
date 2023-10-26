using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
        int x = 0;

        public void checkWin(string letter)
        {
            if (n1.Text == letter && n2.Text == letter && n3.Text == letter ||
                n4.Text == letter && n5.Text == letter && n6.Text == letter ||
                n7.Text == letter && n8.Text == letter && n9.Text == letter ||
                n1.Text == letter && n4.Text == letter && n7.Text == letter ||
                n2.Text == letter && n5.Text == letter && n8.Text == letter ||
                n3.Text == letter && n6.Text == letter && n9.Text == letter ||
                n1.Text == letter && n5.Text == letter && n9.Text == letter ||
                n3.Text == letter && n5.Text == letter && n7.Text == letter)
            {
                
            }
        }

        public void SetX(object sender, RoutedEventArgs e)
        {
            string sourceName = ((FrameworkElement)e.Source).Name;
            int labelId = int.Parse(Regex.Match(sourceName, @"\d+").Value);
            var currLabel = (TextBlock)this.FindName(sourceName);
            finding = true;

            if (isPlaying)
            {
                if (datePosition[labelId - 1] == 0)
                {
                    currLabel.Text = "X";
                    datePosition[labelId - 1] = labelId;
                    checkWin("X");

                    if (isPlaying)
                    {
                        while (finding)
                        {
                            foreach (var i in datePosition)
                            {
                                if (i == 0) break;
                                if (x == 4)
                                {
                                    if (datePosition[8] != 0) finding = false;
                                }
                            }

                            Random random = new Random();
                            int oPosition = random.Next(1, 9);

                            if (datePosition[oPosition - 1] != 0) continue;

                            x++;
                            datePosition[oPosition - 1] = oPosition;

                            var oLabel = (TextBlock)this.FindName($"n{oPosition}");
                            oLabel.Text = "O";

                            checkWin("O");
                            break;
                        }
                    }
                }
            }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            int place = 1;
            int place1 = 0;
            while (place < 10)
            {
                var currLabel = (TextBlock)this.FindName($"n{place++}");
                currLabel.Text = " ";
                datePosition[place1++] = 0;
            }

            isPlaying = true;
            finding = true;
            x = 0;
        }
    }
}
