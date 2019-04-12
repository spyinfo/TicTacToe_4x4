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
        public static void MoveAI(List<Button> ListOfButtons)
        {
            if (isWin(ListOfButtons))
                return;
            //else if (isHumanWin(ListOfButtons))
            //    return;
        }

        /// <summary>
        /// Ход компьютера
        /// </summary>
        private static void PerformMove(Button button)
        {
            button.Content = "O";
            button.IsEnabled = false;
        }


        /// <summary>
        /// Если следующим ходом выиграет компьюьтер
        /// </summary>
        private static bool isWin(List<Button> ListOfButtons)
        {
            if (isHorizontalWin(ListOfButtons))
                return true;


            return false;
        }

        private static bool isAi(Button button)
        {
            if (button.Content.Equals("O"))
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// Проверяем каждую строку на наличие победы
        /// </summary>
        private static bool isHorizontalWin(List<Button> ListOfButtons)
        {
            for (byte i = 0; i < 4; i++)
            {
                Button firstButton = ListOfButtons.ElementAt(i * 4);
                Button secondButton = ListOfButtons.ElementAt((i * 4) + 1);
                Button thirdButton = ListOfButtons.ElementAt((i * 4) + 2);
                Button fouthButton = ListOfButtons.ElementAt((i * 4) + 3);

                if (isAi(firstButton) && isAi(secondButton) && isAi(thirdButton))
                {
                    if (fouthButton.IsEnabled == true)
                    {
                        PerformMove(fouthButton);
                        return true;
                    }
                }

                else if (isAi(firstButton) && isAi(secondButton) && isAi(fouthButton))
                {
                    if (thirdButton.IsEnabled == true)
                    {
                        PerformMove(thirdButton);
                        return true;
                    }
                }

                else if (isAi(firstButton) && isAi(thirdButton) && isAi(fouthButton))
                {
                    if (secondButton.IsEnabled == true)
                    {
                        PerformMove(secondButton);
                        return true;
                    }
                }

                else if (isAi(secondButton) && isAi(thirdButton) && isAi(fouthButton))
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


    }
}
