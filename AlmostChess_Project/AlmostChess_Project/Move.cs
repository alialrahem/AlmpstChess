using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostChess_Project
{
    public class Move : Pawns
    {
        private int targetX;
        private int targetY;
        private int destinationX;
        private int destinationY;

        public Move()
        {
            targetX = 0;
            targetY = 0;
            destinationX = 0;
            destinationY = 0;
            Exit = false;
        }
        public bool Exit { get; set; } 
        public void MakeMove()
        {
            getInput();

            if (!Exit)
                rearangePawns();
        }

        private void getInput()
        {
            
         
            Console.WriteLine("Enter Target's X coordinate between 0 and 7: ");
            Exit = validateInput(int.TryParse(Console.ReadLine(), out targetX));
            
            if (!Exit) 
            {
                Console.WriteLine("Enter Target's Y coordinate  between 0 and 7: ");
                Exit = validateInput(int.TryParse(Console.ReadLine(), out targetY));
            }
            
            if (!Exit) 
            {
                Console.WriteLine("Enter Destination's  x coordinate  between 0 and 7: ");
                Exit = validateInput(int.TryParse(Console.ReadLine(), out destinationX));
            }
            
            if (!Exit) 
            {
                Console.WriteLine("Enter Destination's Y coordinate  between 0 and 7: ");
                Exit = validateInput(int.TryParse(Console.ReadLine(), out destinationY));
            }            
        }

        private bool validateInput(bool parsed)
        {
            bool error = false;

            if (!parsed)
                error = true;
            else if (targetX < 0 || targetY < 0 || destinationX < 0 || destinationY < 0)
                error = true;
            else if (targetX > ChessBoard.DIMENSION || targetY > ChessBoard.DIMENSION || destinationX > ChessBoard.DIMENSION || destinationY > ChessBoard.DIMENSION)
                error = true;

            if (error)
                Console.WriteLine("Invalid input");

            return error;
        }

        private void rearangePawns()
        {
            pawns[destinationX, destinationY] = pawns[targetX,targetY]; 
            pawns[targetX, targetY] = SPACE; 
        }
    }
}
