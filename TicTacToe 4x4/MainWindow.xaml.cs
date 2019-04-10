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

namespace TicTacToe_4x4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Button> ListOfButtons = new List<Button>();

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            var button = (Button)sender;
            ListOfButtons.Add(button);
            if (button.Content != null) button.Content = "X"; 
        }

        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            foreach (var element in ListOfButtons)
            {
                element.Content = "";
            }
        }

        /// <summary>
        /// О программе
        /// </summary>
        private void Button_Click_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developed by Parviz Abdulloev"
            + Environment.NewLine 
            + "for Glusker A.I. in the course of practical work."
            + Environment.NewLine, "About");
        }
    }
}
