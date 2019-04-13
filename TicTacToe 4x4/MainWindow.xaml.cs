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
        public List<Button> BEST_MOVES;

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
                D2, D3, B4, C4 };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.Content = "X";
            button.IsEnabled = false;

            AI.MoveAI(ListOfButtons, BEST_MOVES);

            CheckWinner();
        }

        /// <summary>
        /// Проверяем, есть ли победитель
        /// </summary>
        private bool CheckWinner()
        {
            GameStatus status = checkHorizontal(); // проверяем строки
            if (isOver(status)) return true;

            status = checkVertical(); // проверяем столбцы
            if (isOver(status)) return true;

            status = checkDialog(); // проверяем 2 диагонали
            if (isOver(status)) return true;

            if (checkForTie()) // проверяем на возможность ничьи
            {
                MessageBox.Show("Ничья. Вы сумели свести игру в ничью.");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Проверяем строки
        /// </summary>
        private GameStatus checkHorizontal()
        {
            bool gameOver = false;
            string winner = null;

            if (GameStatus.isEquals(A1, A2, A3, A4, ref gameOver))
                winner = Convert.ToString(A1.Content);
            
            else if (GameStatus.isEquals(B1, B2, B3, B4, ref gameOver))
                winner = Convert.ToString(B1.Content);

            else if (GameStatus.isEquals(C1, C2, C3, C4, ref gameOver))
                winner = Convert.ToString(C1.Content);

            else if (GameStatus.isEquals(D1, D2, D3, D4, ref gameOver))
                winner = Convert.ToString(D1.Content);

            return new GameStatus(gameOver, winner, false);
        }

        /// <summary>
        /// Проверяем столбцы
        /// </summary>
        private GameStatus checkVertical()
        {
            bool gameOver = false;
            string winner = null;

            if (GameStatus.isEquals(A1, B1, C1, D1, ref gameOver))
                winner = Convert.ToString(A1.Content);

            else if (GameStatus.isEquals(A2, B2, C2, D2, ref gameOver))
                winner = Convert.ToString(B2.Content);

            else if (GameStatus.isEquals(A3, B3, C3, D3, ref gameOver))
                winner = Convert.ToString(C3.Content);

            else if (GameStatus.isEquals(A4, B4, C4, D4, ref gameOver))
                winner = Convert.ToString(D4.Content);

            return new GameStatus(gameOver, winner, false);
        }

        /// <summary>
        /// Проверяем 2 диагонали 
        /// </summary>
        private GameStatus checkDialog()
        {
            bool gameOver = false;
            string winner = null;

            if (GameStatus.isEquals(A1, B2, C3, D4, ref gameOver))
                winner = Convert.ToString(A1.Content);

            else if (GameStatus.isEquals(A4, B3, C2, D1, ref gameOver))
                winner = Convert.ToString(A4.Content);

            return new GameStatus(gameOver, winner, false);
        }


        /// <summary>
        /// Проверяем на ничью
        /// </summary>
        private bool checkForTie()
        {
            bool tie = true;
            foreach (var button in ListOfButtons)
            {
                if (button.IsEnabled == true)
                    tie = false;
            }
            return tie;
        }

        /// <summary>
        /// 
        /// </summary>
        private bool isOver(GameStatus status)
        {
            if (status.isGameOver)
            {
                status.winner = (status.winner == "O") ? ("К сожалению, Вы проиграли!") : ("Поздравляем, Вы выиграли!");
                MessageBox.Show(status.winner);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Кнопка Restart
        /// </summary>
        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            foreach (var button in ListOfButtons)
            {
                button.IsEnabled = true;
                button.Content = "";
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
