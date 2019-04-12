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
        public bool gameOver;
        public bool isTie;
        public string winner;

        public GameStatus()
        {
            gameOver = false;
            isTie = false;
            winner = null;
        }

        public GameStatus(bool gameOver, string winner, bool isTie)
        {
            this.gameOver = gameOver;
            this.winner = winner;
            this.isTie = isTie;
        }

        public bool isGameOver => gameOver;

        /// <summary>
        /// Возвращает True, если все входные кнопки имеют одинаковые значения
        /// </summary>
        public static bool isEquals(Button A, Button B, Button C, Button D, ref bool gameOver)
        {
            if (A.Content.Equals(B.Content) && A.Content.Equals(C.Content) && A.Content.Equals(D.Content)
                && B.Content.Equals(C.Content) && B.Content.Equals(D.Content)
                && C.Content.Equals(D.Content) && !A.Content.Equals(""))
            {
                gameOver = true;
                return true;
            }
            return false;
        }


    }
}
