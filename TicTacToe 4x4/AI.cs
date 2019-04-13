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
    class AI
    {
        public const string O_SYMBOL = "O";
        public const string X_SYMBOL = "X";

        delegate bool DelegateAIorEnemy(Button button);

        public static void MoveAI(List<Button> ListOfButtons, List<Button> BEST_MOVES)
        {
            if (isAIWin(ListOfButtons)) // если следующим ходом выиграет компьютер, то выбираем этот ход
                return;

            else if (isHumanWin(ListOfButtons)) // если следующим ходом выиграет человек, то блокируем этот ход
                return;

            foreach (var button in BEST_MOVES) // иначе выбираем лучший из доступных ходов
            {
                if (button.IsEnabled == true)
                {
                    button.Content = O_SYMBOL;
                    button.IsEnabled = false;
                    return;
                }
            }
        }


        /// <summary>
        /// Ход компьютера
        /// </summary>
        private static void PerformMove(Button button)
        {
            button.Content = O_SYMBOL;
            button.IsEnabled = false;
        }



        
        /// <summary>
        /// Если следующим ходом выиграет компьютер, то выбираем этот ход
        /// </summary>
        private static bool isAIWin(List<Button> ListOfButtons)
        {
            DelegateAIorEnemy DelegateAI = isAI;

            if (isHorizontalWin(ListOfButtons, isAI))
                return true;

            else if (isVerticalWin(ListOfButtons, isAI))
                return true;

            else if (isDiagonalWin(ListOfButtons, isAI))
                return true;
            return false;
        }

        /// <summary>
        /// Если следующим ходом выиграет человек, то блокируем этот ход
        /// </summary>
        private static bool isHumanWin(List<Button> ListOfButtons)
        {
            DelegateAIorEnemy DelegateEnemy = isEnemy;

            if (isHorizontalWin(ListOfButtons, isEnemy))
                return true;

            else if (isVerticalWin(ListOfButtons, isEnemy))
                return true;

            else if (isDiagonalWin(ListOfButtons, isEnemy))
                return true;
            return false;
        }





        /// <summary>
        /// Проверяем может ли компьютер или человек следующим ходом выиграть игру по горизонтали
        /// </summary>
        private static bool isHorizontalWin(List<Button> ListOfButtons, DelegateAIorEnemy DelegateAIorEnemy)
        {
            for (int i = 0; i < 4; i++)
            {
                Button firstButton = ListOfButtons.ElementAt(i * 4);
                Button secondButton = ListOfButtons.ElementAt((i * 4) + 1);
                Button thirdButton = ListOfButtons.ElementAt((i * 4) + 2);
                Button fouthButton = ListOfButtons.ElementAt((i * 4) + 3);

                if (inRow(firstButton, secondButton, thirdButton, fouthButton, DelegateAIorEnemy))
                    return true;

                else if (inRow(firstButton, secondButton, fouthButton, thirdButton, DelegateAIorEnemy))
                    return true;

                else if (inRow(firstButton, thirdButton, fouthButton, secondButton, DelegateAIorEnemy))
                    return true;

                else if (inRow(secondButton, thirdButton, fouthButton, firstButton, DelegateAIorEnemy))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Проверяем может ли компьютер или человек следующим ходом выиграть игру по вертикали
        /// </summary>
        private static bool isVerticalWin(List<Button> ListOfButtons, DelegateAIorEnemy DelegateAIorEnemy)
        {
            for (int i = 0; i < 4; i++)
            {
                Button firstButton = ListOfButtons.ElementAt(i);
                Button secondButton = ListOfButtons.ElementAt(i + (1 * 4));
                Button thirdButton = ListOfButtons.ElementAt(i + (2 * 4));
                Button fouthButton = ListOfButtons.ElementAt(i + (3 * 4));

                if (inRow(firstButton, secondButton, thirdButton, fouthButton, DelegateAIorEnemy))
                    return true;

                else if (inRow(firstButton, secondButton, fouthButton, thirdButton, DelegateAIorEnemy))
                    return true;

                else if (inRow(firstButton, thirdButton, fouthButton, secondButton, DelegateAIorEnemy))
                    return true;

                else if (inRow(secondButton, thirdButton, fouthButton, firstButton, DelegateAIorEnemy))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Проверяем может ли компьютер или человек следующим ходом выиграть игру по диагонали
        /// </summary>
        private static bool isDiagonalWin(List<Button> ListOfButtons, DelegateAIorEnemy DelegateAIorEnemy)
        {
            /* A1 A2 A3 A4
             * B1 B2 B3 B4
             * C1 C2 C3 C4
             * D1 D2 D3 D4 */

            Button firstTopLeft = ListOfButtons.ElementAt(0); // A1
            Button secondTopLeft = ListOfButtons.ElementAt(5); // B2
            Button firstTopRight = ListOfButtons.ElementAt(3); // A4
            Button secondTopRight = ListOfButtons.ElementAt(6); // B3
            Button firstBottomLeft = ListOfButtons.ElementAt(12); // D1
            Button secondBottomLeft = ListOfButtons.ElementAt(9); // C2
            Button firstBottomRight = ListOfButtons.ElementAt(10); // C3
            Button secondBottomRight = ListOfButtons.ElementAt(15); // D4

            if (checkTopLeftToBottomRight(firstTopLeft, secondTopLeft, firstBottomRight, secondBottomRight, DelegateAIorEnemy))
                return true;
            else if (checkBottomLeftToTopRight(firstBottomLeft, secondBottomLeft, firstTopRight, secondTopRight, DelegateAIorEnemy))
                return true;
            return false;
        }

        /// <summary>
        /// Проверяем 1-ю диагональ (с левого верхнего угла до правого нижнего угла)
        /// </summary>
        private static bool checkTopLeftToBottomRight(Button firstTopLeft, Button secondTopLeft, Button firstBottomRight, Button secondBottomRight, DelegateAIorEnemy DelegateAIorEnemy)
        {

            if (inRow(firstTopLeft, secondTopLeft, firstBottomRight, secondBottomRight, DelegateAIorEnemy))
                return true;

            else if (inRow(firstTopLeft, secondTopLeft, secondBottomRight, firstBottomRight, DelegateAIorEnemy))
                return true;

            else if (inRow(firstTopLeft, firstBottomRight, secondBottomRight, secondTopLeft, DelegateAIorEnemy))
                return true;

            else if (inRow(secondTopLeft, firstBottomRight, secondBottomRight, firstTopLeft, DelegateAIorEnemy))
                return true;

            return false;
        }

        /// <summary>
        /// Проверяем 2-ю диагональ (с левого нижнего угла до правого верхнего угла)
        /// </summary>
        private static bool checkBottomLeftToTopRight(Button firstBottomLeft, Button secondBottomLeft, Button firstTopRight, Button secondTopRight, DelegateAIorEnemy DelegateAIorEnemy)
        {

            if (inRow(firstBottomLeft, secondBottomLeft, firstTopRight, secondTopRight, DelegateAIorEnemy))
                return true;

            else if (inRow(firstBottomLeft, secondBottomLeft, secondTopRight, firstTopRight, DelegateAIorEnemy))
                return true;

            else if (inRow(firstBottomLeft, firstTopRight, secondTopRight, secondBottomLeft, DelegateAIorEnemy))
                return true;

            else if (inRow(secondBottomLeft, firstTopRight, secondTopRight, firstBottomLeft, DelegateAIorEnemy))
                return true;

            return false;
        }



        /*************************
         * ДОПОЛНИТЕЛЬНЫЕ МЕТОДЫ *
         *************************/
        private static bool isAI(Button button)
        {
            if (button.Content.Equals(O_SYMBOL))
            {
                return true;
            }

            return false;
        }

        private static bool isEnemy(Button button)
        {
            if (button.Content.Equals(X_SYMBOL))
            {
                return true;
            }

            return false;
        }

        private static bool inRow(Button first, Button second, Button third, Button fouth, DelegateAIorEnemy DelegateAIorEnemy)
        {
            if (DelegateAIorEnemy(first) && DelegateAIorEnemy(second) && DelegateAIorEnemy(third))
            {
                if (fouth.IsEnabled == true)
                {
                    PerformMove(fouth);
                    return true;
                }
            }
            return false;
        }
    }
}