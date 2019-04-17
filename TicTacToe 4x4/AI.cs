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
    static class AI
    {
        private static readonly string O_SYMBOL = "O";
        private static readonly string X_SYMBOL = "X";
        private static readonly int size = 4;

        delegate bool DelegateAIorEnemy(Button button);

        /// <summary>
        /// Главный метод класса AI
        /// </summary>
        /// <param name="listOfButtons">Список кнопок</param>
        /// <param name="bestMoves">Список лучших ходов</param>
        public static void MoveAI(List<Button> listOfButtons, List<Button> bestMoves)
        {
            bool isAIWinBool = false;
            bool isHumanWinBool = false;

            DelegateAIorEnemy DelegateAI = isAI;
            DelegateAIorEnemy DelegateEnemy = isEnemy;

            if (isWin(listOfButtons, isAI))
                isAIWinBool = true;

            else if (isWin(listOfButtons, isEnemy))
                isHumanWinBool = true;

            else if ((isAIWinBool == false) && (isHumanWinBool == false))
            {
                foreach (var button in bestMoves) // иначе выбираем лучший из доступных ходов
                {
                    if (button.IsEnabled == true)
                    {
                        button.Content = O_SYMBOL;
                        button.IsEnabled = false;
                        return; 
                    }
                }
            }
        }


        /// <summary>
        /// Ход компьютера
        /// </summary>
        /// <param name="button">Кнопка на которой изменим значение</param>
        private static void PerformMove(Button button)
        {
            button.Content = O_SYMBOL;
            button.IsEnabled = false;
        }


        /// <summary>
        /// Проверяем победит ли человек или компьютер в следующем ходу
        /// </summary>
        /// <param name="listOfButtons">Список кнопок</param>
        /// <param name="DelegateAIorEnemy">Делегат противник это или человек</param>
        /// <returns></returns>
        private static bool isWin(List<Button> listOfButtons, DelegateAIorEnemy DelegateAIorEnemy)
        {
            bool returnValue = false;

            if (isHorizontalWin(listOfButtons, DelegateAIorEnemy))
                returnValue = true;

            else if (isVerticalWin(listOfButtons, DelegateAIorEnemy) && returnValue == false)
                returnValue = true;

            else if (isDiagonalWin(listOfButtons, DelegateAIorEnemy) && returnValue == false)
                returnValue = true;

            return returnValue;
        }





        /// <summary>
        /// Проверяем может ли компьютер или человек следующим ходом выиграть игру по горизонтали
        /// </summary>
        /// <param name="listOfButtons">Список кнопок</param>
        /// <param name="DelegateAIorEnemy">Делегат противник это или человек</param>
        /// <returns>True = горизонтальная победа. </returns>
        private static bool isHorizontalWin(List<Button> listOfButtons, DelegateAIorEnemy DelegateAIorEnemy)
        {
            bool returnValue = false;
            for (int i = 0; i < size; i++)
            {
                Button firstButton = listOfButtons.ElementAt(i * size);
                Button secondButton = listOfButtons.ElementAt((i * size) + 1);
                Button thirdButton = listOfButtons.ElementAt((i * size) + 2);
                Button fouthButton = listOfButtons.ElementAt((i * size) + 3);

                isWinOnThreeSides(firstButton, secondButton, thirdButton, fouthButton, DelegateAIorEnemy, ref returnValue);
            }
            return returnValue;
        }


        /// <summary>
        /// Проверяем может ли компьютер или человек следующим ходом выиграть игру по вертикали
        /// </summary>
        /// <param name="listOfButtons">Список кнопок</param>
        /// <param name="DelegateAIorEnemy">Делегат противник это или человек</param>
        /// <returns>True = вертильная победа. </returns>
        private static bool isVerticalWin(List<Button> listOfButtons, DelegateAIorEnemy DelegateAIorEnemy)
        {
            bool returnValue = false;

            for (int i = 0; i < size; i++)
            {
                Button firstButton = listOfButtons.ElementAt(i);
                Button secondButton = listOfButtons.ElementAt(i + (1 * 4));
                Button thirdButton = listOfButtons.ElementAt(i + (2 * 4));
                Button fouthButton = listOfButtons.ElementAt(i + (3 * 4));

                isWinOnThreeSides(firstButton, secondButton, thirdButton, fouthButton, DelegateAIorEnemy, ref returnValue);
            }
            return returnValue;
        }

        /// <summary>
        /// Проверяем может ли компьютер или человек следующим ходом выиграть игру по диагонали
        /// </summary>
        /// <param name="listOfButtons">Список кнопок</param>
        /// <param name="DelegateAIorEnemy">Делегат противник это или человек</param>
        /// <returns>True = диагональя победа. </returns>
        private static bool isDiagonalWin(List<Button> listOfButtons, DelegateAIorEnemy DelegateAIorEnemy)
        {
            /* A1 A2 A3 A4
             * B1 B2 B3 B4
             * C1 C2 C3 C4
             * D1 D2 D3 D4 */
            bool returnValue = false;

            Button firstTopLeft = listOfButtons.ElementAt(0); // A1
            Button secondTopLeft = listOfButtons.ElementAt(5); // B2
            Button firstTopRight = listOfButtons.ElementAt(3); // A4
            Button secondTopRight = listOfButtons.ElementAt(6); // B3
            Button firstBottomLeft = listOfButtons.ElementAt(12); // D1
            Button secondBottomLeft = listOfButtons.ElementAt(9); // C2
            Button firstBottomRight = listOfButtons.ElementAt(10); // C3
            Button secondBottomRight = listOfButtons.ElementAt(15); // D4

            if (isWinOnThreeSides(firstTopLeft, secondTopLeft, firstBottomRight, secondBottomRight, DelegateAIorEnemy, ref returnValue))
                returnValue = true;

            else if (isWinOnThreeSides(firstBottomLeft, secondBottomLeft, firstTopRight, secondTopRight, DelegateAIorEnemy, ref returnValue))
                returnValue = true;

            return returnValue;
        }




        /*********************************
         * ДОПОЛНИТЕЛЬНЫЕ / ОБЩИЕ МЕТОДЫ *
         *********************************/

        /// <summary>
        /// Компьютер ли это
        /// </summary>
        /// <param name="button">Кнопка на которой необходио проверить</param>
        /// <returns>True = это компьютер</returns>
        private static bool isAI(Button button)
        {
            bool isAIBool = false;

            if (button.Content.Equals(O_SYMBOL))
                isAIBool = true;

            return isAIBool;
        }

        /// <summary>
        /// Человек ли это
        /// </summary>
        /// <param name="button">Кнопка на которой необходио проверить</param>
        /// <returns>True = это человек</returns>
        private static bool isEnemy(Button button)
        {
            bool isEnemyBool = false;

            if (button.Content.Equals(X_SYMBOL))
                isEnemyBool = true;

            return isEnemyBool;
        }

        /// <summary>
        /// Общий метод для определения победы. Если они все входные кнопки стоят в ряд.
        /// </summary>
        /// <param name="firstButton">1-я кнопка</param>
        /// <param name="secondButton">2-я кнопка</param>
        /// <param name="thirdButton">3-я кнопка</param>
        /// <param name="fouthButton">4-я кнопка</param>
        /// <param name="DelegateAIorEnemy">Делегат противник это или человек</param>
        /// <param name="returnValue">True = победа</param>
        /// <returns></returns>
        private static bool isWinOnThreeSides(Button firstButton, Button secondButton, Button thirdButton, Button fouthButton, DelegateAIorEnemy DelegateAIorEnemy, ref bool returnValue)
        {

            if (inRow(firstButton, secondButton, thirdButton, fouthButton, DelegateAIorEnemy))
                returnValue = true;

            else if (inRow(firstButton, secondButton, fouthButton, thirdButton, DelegateAIorEnemy))
                returnValue = true;

            else if (inRow(firstButton, thirdButton, fouthButton, secondButton, DelegateAIorEnemy))
                returnValue = true;

            else if (inRow(secondButton, thirdButton, fouthButton, firstButton, DelegateAIorEnemy))
                returnValue = true;

            return returnValue;
        }

        /// <summary>
        /// Есть ли победа в ряд (по вертикали, по горизонатли, по диагонали)
        /// </summary>
        /// <param name="first">1-я кнопка</param>
        /// <param name="second">2-я кнопка</param>
        /// <param name="third">3-я кнопка</param>
        /// <param name="fouth">4-я кнопка</param>
        /// <param name="DelegateAIorEnemy">Делегат противник это или человек</param>
        /// <returns>true = есть победа, false = нет победы</returns>
        private static bool inRow(Button first, Button second, Button third, Button fouth, DelegateAIorEnemy DelegateAIorEnemy)
        {
            bool returnValue = false;
            if (DelegateAIorEnemy(first) && DelegateAIorEnemy(second) && DelegateAIorEnemy(third))
            {
                if (fouth.IsEnabled == true)
                {
                    PerformMove(fouth);
                    returnValue = true;
                }
            }
            return returnValue;
        }
    }
}