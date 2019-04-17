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
    /// Статус игры
    /// </summary>
    class GameStatus
    {
        public bool gameOver { get; private set; }
        public bool isTie { get; private set; }
        public string winner { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public GameStatus()
        {
            gameOver = false;
            isTie = false;
            winner = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameOver">текущий статус игры</param>
        /// <param name="winner">победитель. "О" или "X"</param>
        /// <param name="isTie">Ничья или нет</param>
        public GameStatus(bool gameOver, string winner, bool isTie)
        {
            this.gameOver = gameOver;
            this.winner = winner;
            this.isTie = isTie;
        }


        /// <summary>
        /// Имеют ли все входящие кнопки одинаковые значения
        /// </summary>
        /// <param name="A">1-я кнокпа</param>
        /// <param name="B">2-я кнокпа</param>
        /// <param name="C">3-я кнокпа</param>
        /// <param name="D">4-я кнокпа</param>
        /// <param name="gameOver">Текущий статус игры</param>
        /// <returns>Возвращает True, если все входные кнопки имеют одинаковые значения</returns>
        public static bool isEquals(Button A, Button B, Button C, Button D, ref bool gameOver)
        {
            bool returnValue = false;

            if (A.Content.Equals(B.Content) && A.Content.Equals(C.Content) && A.Content.Equals(D.Content)
                && B.Content.Equals(C.Content) && B.Content.Equals(D.Content)
                && C.Content.Equals(D.Content) && !A.Content.Equals(""))
            {
                gameOver = true;
                returnValue = true;
            }
            return returnValue;
        }
    }
}
