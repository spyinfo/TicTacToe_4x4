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
        private List<Button> ListOfButtons;
        private List<Button> BEST_MOVES;

        public MainWindow()
        {
            InitializeComponent();

            ListOfButtons = new List<Button>() {
                A1, A2, A3, A4,
                B1, B2, B3, B4,
                C1, C2, C3, C4,
                D1, D2, D3, D4 };

            BEST_MOVES = new List<Button>() {
                B2, C3, B3, C2,
                A1, A4, D1, D4,
                A2, A3, B1, C1,
                D2, D3, B4, C4};
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            var button = (Button)sender;
            if (ListOfButtons.Contains(button))
            {
                button.Content = "X";
                BEST_MOVES.Remove(button);
                var move = MoveAI(ListOfButtons);
            }
        }

        //private void Button_Click_Restart(object sender, RoutedEventArgs e)
        //{
        //    foreach (var element in ListOfButtons)
        //    {
        //        element.Content = "";
        //    }
        //}

        /// <summary>
        /// Ход компьютера
        /// </summary>
        private Button MoveAI(List<Button> ListOfButtons)
        {
            Button move = new Button();

            foreach (var button in BEST_MOVES)
            {
                button.Content = "O";
                BEST_MOVES.Remove(button);
                return move;
            }
            return move;
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
