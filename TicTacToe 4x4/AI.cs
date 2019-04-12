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

        public static void MoveAI(List<Button> ListOfButtons)
        {
            if (isAIWin(ListOfButtons))
                return;

            else if (isHumanWin(ListOfButtons))
                return;
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
            if (isHorizontalWin(ListOfButtons))
                return true;

            else if (isVerticalWin(ListOfButtons))
                return true;

            else if (isDiagonalWin(ListOfButtons))
                return true;
            return false;
        }

        /// <summary>
        /// Если следующим ходом выиграет человек, то блокируем этот ход
        /// </summary>
        private static bool isHumanWin(List<Button> ListOfButtons)
        {
            if (isEnemyHorizontalWin(ListOfButtons))
                return true;

            else if (isEnemyVerticalWin(ListOfButtons))
                return true;

            else if (isEnemyDiagonalWin(ListOfButtons))
                return true;
            return false;
        }

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


        /// <summary>
        /// Проверяем может ли компьютер следующим ходом выиграть игру по горизонтали
        /// </summary>
        private static bool isHorizontalWin(List<Button> ListOfButtons)
        {
            for (int i = 0; i < 4; i++)
            {
                Button firstButton = ListOfButtons.ElementAt(i * 4);
                Button secondButton = ListOfButtons.ElementAt((i * 4) + 1);
                Button thirdButton = ListOfButtons.ElementAt((i * 4) + 2);
                Button fouthButton = ListOfButtons.ElementAt((i * 4) + 3);

                if (isAI(firstButton) && isAI(secondButton) && isAI(thirdButton))
                {
                    if (fouthButton.IsEnabled == true)
                    {
                        PerformMove(fouthButton);
                        return true;
                    }
                }

                else if (isAI(firstButton) && isAI(secondButton) && isAI(fouthButton))
                {
                    if (thirdButton.IsEnabled == true)
                    {
                        PerformMove(thirdButton);
                        return true;
                    }
                }

                else if (isAI(firstButton) && isAI(thirdButton) && isAI(fouthButton))
                {
                    if (secondButton.IsEnabled == true)
                    {
                        PerformMove(secondButton);
                        return true;
                    }
                }

                else if (isAI(secondButton) && isAI(thirdButton) && isAI(fouthButton))
                {
                    if (firstButton.IsEnabled == true)
                    {
                        PerformMove(firstButton);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяем может ли компьютер следующим ходом выиграть игру по вертикали
        /// </summary>
        private static bool isVerticalWin(List<Button> ListOfButtons)
        {
            for (int i = 0; i < 4; i++)
            {
                Button firstButton = ListOfButtons.ElementAt(i);
                Button secondButton = ListOfButtons.ElementAt(i + (1 * 4));
                Button thirdButton = ListOfButtons.ElementAt(i + (2 * 4));
                Button fouthButton = ListOfButtons.ElementAt(i + (3 * 4));


                if (isAI(firstButton) && isAI(secondButton) && isAI(thirdButton))
                {
                    if (fouthButton.IsEnabled == true)
                    {
                        PerformMove(fouthButton);
                        return true;
                    }
                }

                else if (isAI(firstButton) && isAI(secondButton) && isAI(fouthButton))
                {
                    if (thirdButton.IsEnabled == true)
                    {
                        PerformMove(thirdButton);
                        return true;
                    }
                }

                else if (isAI(firstButton) && isAI(thirdButton) && isAI(fouthButton))
                {
                    if (secondButton.IsEnabled == true)
                    {
                        PerformMove(secondButton);
                        return true;
                    }
                }

                else if (isAI(secondButton) && isAI(thirdButton) && isAI(fouthButton))
                {
                    if (firstButton.IsEnabled == true)
                    {
                        PerformMove(firstButton);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяем может ли компьютер следующим ходом выиграть игру по диагонали
        /// </summary>
        public static bool isDiagonalWin(List<Button> ListOfButtons)
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

            if (checkTopLeftToBottomRight(firstTopLeft, secondTopLeft, firstBottomRight, secondBottomRight))
                return true;
            else if (checkBottomLeftToTopRight(firstBottomLeft, secondBottomLeft, firstTopRight, secondTopRight))
                return true;
            return false;
        }

        private static bool checkTopLeftToBottomRight(Button firstTopLeft, Button secondTopLeft, Button firstBottomRight, Button secondBottomRight)
        {
            if (isAI(firstTopLeft) && isAI(secondTopLeft) && isAI(firstBottomRight))
            {
                if (secondBottomRight.IsEnabled == true)
                {
                    PerformMove(secondBottomRight);
                    return true;
                }
            }
            else if (isAI(firstTopLeft) && isAI(secondTopLeft) && isAI(secondBottomRight))
            {
                if (firstBottomRight.IsEnabled == true)
                {
                    PerformMove(firstBottomRight);
                    return true;
                }
            }
            else if (isAI(firstTopLeft) && isAI(firstBottomRight) && isAI(secondBottomRight))
            {
                if (secondTopLeft.IsEnabled == true)
                {
                    PerformMove(secondTopLeft);
                    return true;
                }
            }
            else if (isAI(secondTopLeft) && isAI(firstBottomRight) && isAI(secondBottomRight))
            {
                if (firstTopLeft.IsEnabled == true)
                {
                    PerformMove(firstTopLeft);
                    return true;
                }
            }
            return false;
        }

        private static bool checkBottomLeftToTopRight(Button firstBottomLeft, Button secondBottomLeft, Button firstTopRight, Button secondTopRight)
        {
            if (isAI(firstBottomLeft) && isAI(secondBottomLeft) && isAI(firstTopRight))
            {
                if (secondTopRight.IsEnabled == true)
                {
                    PerformMove(secondTopRight);
                    return true;
                }
            }
            else if (isAI(firstBottomLeft) && isAI(secondBottomLeft) && isAI(secondTopRight))
            {
                if (firstTopRight.IsEnabled == true)
                {
                    PerformMove(firstTopRight);
                    return true;
                }
            }
            else if (isAI(firstBottomLeft) && isAI(firstTopRight) && isAI(secondTopRight))
            {
                if (secondBottomLeft.IsEnabled == true)
                {
                    PerformMove(secondBottomLeft);
                    return true;
                }
            }
            else if (isAI(secondBottomLeft) && isAI(firstTopRight) && isAI(secondTopRight))
            {
                if (firstBottomLeft.IsEnabled == true)
                {
                    PerformMove(firstBottomLeft);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяем может ли человек следующим ходом выиграть игру по горизонтали
        /// </summary>
        private static bool isEnemyHorizontalWin(List<Button> ListOfButtons)
        {
            for (int i = 0; i < 4; i++)
            {
                Button firstButton = ListOfButtons.ElementAt(i * 4);
                Button secondButton = ListOfButtons.ElementAt((i * 4) + 1);
                Button thirdButton = ListOfButtons.ElementAt((i * 4) + 2);
                Button fouthButton = ListOfButtons.ElementAt((i * 4) + 3);

                if (isEnemy(firstButton) && isEnemy(secondButton) && isEnemy(thirdButton))
                {
                    if (fouthButton.IsEnabled == true)
                    {
                        PerformMove(fouthButton);
                        return true;
                    }
                }

                else if (isEnemy(firstButton) && isEnemy(secondButton) && isEnemy(fouthButton))
                {
                    if (thirdButton.IsEnabled == true)
                    {
                        PerformMove(thirdButton);
                        return true;
                    }
                }

                else if (isEnemy(firstButton) && isEnemy(thirdButton) && isEnemy(fouthButton))
                {
                    if (secondButton.IsEnabled == true)
                    {
                        PerformMove(secondButton);
                        return true;
                    }
                }

                else if (isEnemy(secondButton) && isEnemy(thirdButton) && isEnemy(fouthButton))
                {
                    if (firstButton.IsEnabled == true)
                    {
                        PerformMove(firstButton);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяем может ли человек следующим ходом выиграть игру по вертикали
        /// </summary>
        private static bool isEnemyVerticalWin(List<Button> ListOfButtons)
        {
            for (int i = 0; i < 4; i++)
            {
                Button firstButton = ListOfButtons.ElementAt(i);
                Button secondButton = ListOfButtons.ElementAt(i + (1 * 4));
                Button thirdButton = ListOfButtons.ElementAt(i + (2 * 4));
                Button fouthButton = ListOfButtons.ElementAt(i + (3 * 4));


                if (isEnemy(firstButton) && isEnemy(secondButton) && isEnemy(thirdButton))
                {
                    if (fouthButton.IsEnabled == true)
                    {
                        PerformMove(fouthButton);
                        return true;
                    }
                }

                else if (isEnemy(firstButton) && isEnemy(secondButton) && isEnemy(fouthButton))
                {
                    if (thirdButton.IsEnabled == true)
                    {
                        PerformMove(thirdButton);
                        return true;
                    }
                }

                else if (isEnemy(firstButton) && isEnemy(thirdButton) && isEnemy(fouthButton))
                {
                    if (secondButton.IsEnabled == true)
                    {
                        PerformMove(secondButton);
                        return true;
                    }
                }

                else if (isEnemy(secondButton) && isEnemy(thirdButton) && isEnemy(fouthButton))
                {
                    if (firstButton.IsEnabled == true)
                    {
                        PerformMove(firstButton);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяем может ли человек следующим ходом выиграть игру по диагонали
        /// </summary>
        public static bool isEnemyDiagonalWin(List<Button> ListOfButtons)
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

            if (checkEnemyTopLeftToBottomRight(firstTopLeft, secondTopLeft, firstBottomRight, secondBottomRight))
                return true;
            else if (checkEnemyBottomLeftToTopRight(firstBottomLeft, secondBottomLeft, firstTopRight, secondTopRight))
                return true;
            
            return false;
        }

        private static bool checkEnemyTopLeftToBottomRight(Button firstTopLeft, Button secondTopLeft, Button firstBottomRight, Button secondBottomRight)
        {
            if (isEnemy(firstTopLeft) && isEnemy(secondTopLeft) && isEnemy(firstBottomRight))
            {
                if (secondBottomRight.IsEnabled == true)
                {
                    PerformMove(secondBottomRight);
                    return true;
                }
            }
            else if (isEnemy(firstTopLeft) && isEnemy(secondTopLeft) && isEnemy(secondBottomRight))
            {
                if (firstBottomRight.IsEnabled == true)
                {
                    PerformMove(firstBottomRight);
                    return true;
                }
            }
            else if (isEnemy(firstTopLeft) && isEnemy(firstBottomRight) && isEnemy(secondBottomRight))
            {
                if (secondTopLeft.IsEnabled == true)
                {
                    PerformMove(secondTopLeft);
                    return true;
                }
            }
            else if (isEnemy(secondTopLeft) && isEnemy(firstBottomRight) && isEnemy(secondBottomRight))
            {
                if (firstTopLeft.IsEnabled == true)
                {
                    PerformMove(firstTopLeft);
                    return true;
                }
            }
            return false;
        }

        private static bool checkEnemyBottomLeftToTopRight(Button firstBottomLeft, Button secondBottomLeft, Button firstTopRight, Button secondTopRight)
        {
            if (isEnemy(firstBottomLeft) && isEnemy(secondBottomLeft) && isEnemy(firstTopRight))
            {
                if (secondTopRight.IsEnabled == true)
                {
                    PerformMove(secondTopRight);
                    return true;
                }
            }
            else if (isEnemy(firstBottomLeft) && isEnemy(secondBottomLeft) && isEnemy(secondTopRight))
            {
                if (firstTopRight.IsEnabled == true)
                {
                    PerformMove(firstTopRight);
                    return true;
                }
            }
            else if (isEnemy(firstBottomLeft) && isEnemy(firstTopRight) && isEnemy(secondTopRight))
            {
                if (secondBottomLeft.IsEnabled == true)
                {
                    PerformMove(secondBottomLeft);
                    return true;
                }
            }
            else if (isEnemy(secondBottomLeft) && isEnemy(firstTopRight) && isEnemy(secondTopRight))
            {
                if (firstBottomLeft.IsEnabled == true)
                {
                    PerformMove(firstBottomLeft);
                    return true;
                }
            }
            return false;
        }

    }
}
