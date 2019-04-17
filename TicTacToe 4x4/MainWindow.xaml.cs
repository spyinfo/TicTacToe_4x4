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
        private const int size = 4;

        private List<Button> listOfButtons;
        private List<Button> bestMoves;

        public MainWindow()
        {
            InitializeComponent();

            // Список кнопок (полей)
            listOfButtons = new List<Button>() {
                A1, A2, A3, A4,
                B1, B2, B3, B4,
                C1, C2, C3, C4,
                D1, D2, D3, D4 };

            // Список кнопок (полей) от лучшего к худшему
            bestMoves = new List<Button>() {
                B2, C3, B3, C2,
                A1, D4, D1, A4,
                A2, A3, B1, C1,
                D2, D3, B4, C4 };
        }

        /// <summary>
        /// Клик на поле (кнопку)
        /// </summary>
        private void ClickOnButton(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.Content = "X";
            button.IsEnabled = false;

            AI.MoveAI(listOfButtons, bestMoves);

            if (CheckWinner())
            {
                foreach (var element in listOfButtons)
                {
                    element.IsEnabled = true;
                    element.Content = "";
                }
            }
        }

        /// <summary>
        /// Проверяем, есть ли победитель
        /// </summary>
        /// <returns>True = есть победитель. False = нет победителя</returns>
        private bool CheckWinner()
        {
            bool returnValue = false;

            // Двумерный массив кнопок (полей)
            Button[,] arrayOfButtons = new Button[size, size]
            {
                {A1, A2, A3, A4},
                {B1, B2, B3, B4},
                {C1, C2, C3, C4},
                {D1, D2, D3, D4},
            };

            GameStatus status = checkHorizontalAndVertical(arrayOfButtons); // проверяем строки и столбцы
            if (isOver(status)) returnValue = true;

            status = checkDialog(); // проверяем 2 диагонали
            if (isOver(status)) returnValue = true;

            if (checkForTie() && returnValue == false) // проверяем на возможность ничьи
            {
                MessageBox.Show("Ничья. Вы сумели свести игру в ничью.");
                returnValue = true;
            }
            return returnValue;
        }


        /// <summary>
        /// Проверяем строки и столбцы
        /// </summary>
        /// <param name="arrayOfButtons">Двумерный массив кнопок</param>
        /// <returns>Обновляем статус игры</returns>
        private GameStatus checkHorizontalAndVertical(Button[,] arrayOfButtons)
        {
            bool gameOver = false;
            string winner = null;

            for (int i = 0; i < size; i++)
            {
                if (GameStatus.isEquals(arrayOfButtons[i, 0], arrayOfButtons[i, 1], arrayOfButtons[i, 2], arrayOfButtons[i, 3], ref gameOver))
                    winner = Convert.ToString(arrayOfButtons[i, 0].Content);

                if (GameStatus.isEquals(arrayOfButtons[0, i], arrayOfButtons[1, i], arrayOfButtons[2, i], arrayOfButtons[3, i], ref gameOver))
                    winner = Convert.ToString(arrayOfButtons[0, i].Content);
            }
            return new GameStatus(gameOver, winner, false);
        }


        /// <summary>
        /// Проверяем 2 диагонали 
        /// </summary>
        /// <returns>Обновляем статус игры</returns>
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
        /// <returns>True = ничья</returns>
        private bool checkForTie()
        {
            bool tie = true;
            foreach (var button in listOfButtons)
            {
                if (button.IsEnabled == true)
                    tie = false;
            }
            return tie;
        }

        /// <summary>
        /// Достигнут ли конец игры
        /// </summary>
        /// <param name="status">Статус игры</param>
        /// <returns>True = есть победитель. False = нет победителя</returns>
        private bool isOver(GameStatus status)
        {
            bool returnValue = false;
            if (status.gameOver)
            {
                MessageBox.Show((status.winner == "O") ? ("К сожалению, Вы проиграли!") : ("Поздравляем, Вы выиграли!"));
                returnValue = true;
            }
            return returnValue;
        }


        /// <summary>
        /// Кнопка Restart
        /// </summary>
        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            foreach (var button in listOfButtons)
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
