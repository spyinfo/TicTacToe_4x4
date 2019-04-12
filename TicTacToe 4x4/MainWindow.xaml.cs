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
        public static List<Button> BEST_MOVES;

        public MainWindow()
        {
            InitializeComponent();

            // Список кнопок (полей)
            ListOfButtons = new List<Button>() {
                A1, A2, A3, A4,
                B1, B2, B3, B4,
                C1, C2, C3, C4,
                D1, D2, D3, D4 };

            // Список кнопок (полей) от лучшего к худшему
            BEST_MOVES = new List<Button>() {
                B2, C3, B3, C2,
                A1, D4, D1, A4,
                A2, A3, B1, C1,
                D2, D3, B4, C4};

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.Content = "X";
            button.IsEnabled = false;
            BEST_MOVES.Remove(button);

            AI.MoveAI(ListOfButtons, BEST_MOVES);

            CheckWinner();
        }

        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            foreach (var button in ListOfButtons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
            BEST_MOVES = new List<Button> {
                B2, C3, B3, C2,
                A1, D4, D1, A4,
                A2, A3, B1, C1,
                D2, D3, B4, C4 };


        }

        /// <summary>
        /// Проверяем, есть ли победитель
        /// </summary>
        private void CheckWinner()
        {
            if ((A1.ContentStringFormat == "X") && (A2.ContentStringFormat == "X") && (A3.ContentStringFormat == "X") && (A4.ContentStringFormat == "X"))
            {
                MessageBox.Show("Поздравляем вы выиграли!");
                return;
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
