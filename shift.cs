using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Net.WebRequestMethods;

namespace Pbl_Ortak_Proje
{
    internal class Program
    {

        static void Main()
        {
            //Declaring Variables.
            int point_move1 = 0;
            int point_move2 = 0;
            int point_move3 = 0;
            int point_move4 = 0;
            int point_move5 = 0;
            int point_move6 = 0;
            int move;
            int board_score = 0;
            int board_control = 0;
            int player_score = 0;
            int computer_score = 0;
            int memory1, memory2, memory3;
            int a1 = 0;
            int b1 = 0;
            int c1 = 0;
            int a2 = 0;
            int b2 = 0;
            int c2 = 0;
            int a3 = 0;
            int b3 = 0;
            int c3 = 0;
            int x;
            int y;
            int counter = 1;

            //For loop to calculate the number of rounds.
            for (int i = 1; i < 6; i++)
            {
                board_score = 0;
                counter = 1;
                //For the first round the initiator enters the numbers to the board by hand.
                if (i == 1)
                {
                    for (int v = 1; v < 10; v++)
                    {

                        //Taking x,y cordinations from the user.
                        Console.Write("Input x: ");
                        x = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Input y: ");
                        y = Convert.ToInt16(Console.ReadLine());

                        //Check if the entered cordinations are empty, then if empty, assigning the value to them.
                        if ((x == 1 && y == 1) && a1 == 0)
                        {
                            a1 = v;
                        }
                        else if ((x == 1 && y == 2) && a2 == 0)
                        {
                            a2 = v;
                        }
                        else if ((x == 1 && y == 3) && a3 == 0)
                        {
                            a3 = v;
                        }
                        else if ((x == 2 && y == 1) && b1 == 0)
                        {
                            b1 = v;
                        }
                        else if ((x == 2 && y == 2) && b2 == 0)
                        {
                            b2 = v;
                        }
                        else if ((x == 2 && y == 3) && b3 == 0)
                        {
                            b3 = v;
                        }
                        else if ((x == 3 && y == 1) && c1 == 0)
                        {
                            c1 = v;
                        }
                        else if ((x == 3 && y == 2) && c2 == 0)
                        {
                            c2 = v;
                        }
                        else if ((x == 3 && y == 3) && c3 == 0)
                        {
                            c3 = v;
                        }
                        //Error handlling: If there is any wrong input from the user it shows a message.
                        else
                        {
                            Console.WriteLine("Please Try Again");
                            v--;
                        }
                        //Showing the board each time to make it easier to enter the numbers.
                        if (v != 9)
                        {
                            Console.WriteLine("+ - - - +");
                            Console.WriteLine("| {0} {1} {2} |", a1, a2, a3);
                            Console.WriteLine("| {0} {1} {2} |", b1, b2, b3);
                            Console.WriteLine("| {0} {1} {2} |", c1, c2, c3);
                            Console.WriteLine("+ - - - +");
                        }



                    }
                }
                //After the first round, the umbers will be entered randomly to the board using Random() function.
                else
                {
                    Random random = new Random();
                    a1 = random.Next(1, 10);
                    a2 = random.Next(1, 10);
                    //Check if there are any randomly similar  values inside the board, and assigning new random value to them.
                    while (a2 == a1)
                        a2 = random.Next(1, 10);
                    a3 = random.Next(1, 10);
                    while (a3 == a2 || a3 == a1)
                        a3 = random.Next(1, 10);
                    b1 = random.Next(1, 10);
                    while (b1 == a1 || b1 == a2 || b1 == a3)
                        b1 = random.Next(1, 10);
                    b2 = random.Next(1, 10);
                    while (b2 == b1 || b2 == a1 || b2 == a2 || b2 == a3)
                        b2 = random.Next(1, 10);
                    b3 = random.Next(1, 10);
                    while (b3 == b1 || b3 == b2 || b3 == a1 || b3 == a2 || b3 == a3)
                        b3 = random.Next(1, 10);
                    c1 = random.Next(1, 10);
                    while (c1 == a1 || c1 == a2 || c1 == a3 || c1 == b1 || c1 == b2 || c1 == b3)
                        c1 = random.Next(1, 10);
                    c2 = random.Next(1, 10);
                    while (c2 == a1 || c2 == a2 || c2 == a3 || c2 == b1 || c2 == b2 || c2 == b3 || c2 == c1)
                        c2 = random.Next(1, 10);
                    c3 = random.Next(1, 10);
                    while (c3 == a1 || c3 == a2 || c3 == a3 || c3 == b1 || c3 == b2 || c3 == b3 || c3 == c1 || c3 == c2)
                        c3 = random.Next(1, 10);

                }


                //Check if there are any board series made(series by the initiator)
                board_score = 0;
                if (a1 == a2 + 1 && a2 == a3 + 1 || a1 == a2 - 1 && a2 == a3 - 1)
                {
                    board_score++;
                }
                if (b1 == b2 + 1 && b2 == b3 + 1 || b1 == b2 - 1 && b2 == b3 - 1)
                {
                    board_score++;

                }
                if (c1 == c2 + 1 && c2 == c3 + 1 || c1 == c2 - 1 && c2 == c3 - 1)
                {
                    board_score++;

                }
                if (a1 == b1 + 1 && b1 == c1 + 1 || a1 == b1 - 1 && b1 == c1 - 1)
                {
                    board_score++;

                }
                if (a2 == b2 + 1 && b2 == c2 + 1 || a2 == b2 - 1 && b2 == c2 - 1)
                {
                    board_score++;

                }
                if (a3 == b3 + 1 && b3 == c3 + 1 || a3 == b3 - 1 && b3 == c3 - 1)
                {
                    board_score++;

                }
                if (a1 == b2 + 1 && b2 == c3 + 1 || a1 == b2 - 1 && b2 == c3 - 1)
                {
                    board_score++;

                }
                if (c1 == b2 + 1 && b2 == a3 + 1 || c1 == b2 - 1 && b2 == a3 - 1)
                {
                    board_score++;

                }


                //New value of the board score is multiplied by itself(1, 3, 9)
                board_score = board_score * board_score;
                Console.WriteLine("-------------- Round " + i + "--------------");
                Console.WriteLine("                           Turn : " + counter + " / Player");
                Console.WriteLine("+ - - - +");
                Console.Write("| {0} {1} {2} |", a1, a2, a3);
                Console.WriteLine("      Board Score: " + board_score);
                Console.Write("| {0} {1} {2} |", b1, b2, b3);
                Console.WriteLine("      Player Score: " + player_score);
                Console.Write("| {0} {1} {2} |", c1, c2, c3);
                Console.WriteLine("      Computer Score: " + computer_score);
                Console.WriteLine("+ - - - +");
                Console.WriteLine("Lets Begin!");

                if (board_score > 0)
                {
                    board_control = 1;

                }

                //Commands(Moves) part
                while (true)
                {
                    //Player enters the move.
                    Console.Write("Select A Move:");
                    move = Convert.ToInt16(Console.ReadLine());
                    //Checking the moves entered
                    if (move == 1)
                    {
                        //This code shifts the series by one block to the right
                        memory1 = a1;
                        memory2 = a2;
                        memory3 = a3;
                        a1 = memory3;
                        a2 = memory1;
                        a3 = memory2;
                        Console.WriteLine("Playing Move 1...");
                    }
                    else if (move == 2)
                    {
                        memory1 = b1;
                        memory2 = b2;
                        memory3 = b3;
                        b1 = memory3;
                        b2 = memory1;
                        b3 = memory2;
                        Console.WriteLine("Playing Move 2...");
                    }
                    else if (move == 3)
                    {
                        memory1 = c1;
                        memory2 = c2;
                        memory3 = c3;
                        c1 = memory3;
                        c2 = memory1;
                        c3 = memory2;
                        Console.WriteLine("Playing Move 3...");
                    }
                    //This code shifts the numbers one block downwards.
                    else if (move == 4)
                    {
                        memory1 = a1;
                        memory2 = b1;
                        memory3 = c1;
                        a1 = memory3;
                        b1 = memory1;
                        c1 = memory2;
                        Console.WriteLine("Playing Move 4...");
                    }
                    else if (move == 5)
                    {
                        memory1 = a2;
                        memory2 = b2;
                        memory3 = c2;
                        a2 = memory3;
                        b2 = memory1;
                        c2 = memory2;
                        Console.WriteLine("Playing Move 5...");
                    }
                    else if (move == 6)
                    {
                        memory1 = a3;
                        memory2 = b3;
                        memory3 = c3;
                        a3 = memory3;
                        b3 = memory1;
                        c3 = memory2;
                        Console.WriteLine("Playing Move 6...");
                    }
                    //check if there is any series in the board
                    board_score = 0;

                    if (a1 == a2 + 1 && a2 == a3 + 1 || a1 == a2 - 1 && a2 == a3 - 1)
                    {
                        board_score++;
                    }
                    if (b1 == b2 + 1 && b2 == b3 + 1 || b1 == b2 - 1 && b2 == b3 - 1)
                    {
                        board_score++;

                    }
                    if (c1 == c2 + 1 && c2 == c3 + 1 || c1 == c2 - 1 && c2 == c3 - 1)
                    {
                        board_score++;

                    }
                    if (a1 == b1 + 1 && b1 == c1 + 1 || a1 == b1 - 1 && b1 == c1 - 1)
                    {
                        board_score++;

                    }
                    if (a2 == b2 + 1 && b2 == c2 + 1 || a2 == b2 - 1 && b2 == c2 - 1)
                    {
                        board_score++;

                    }
                    if (a3 == b3 + 1 && b3 == c3 + 1 || a3 == b3 - 1 && b3 == c3 - 1)
                    {
                        board_score++;

                    }
                    if (a1 == b2 + 1 && b2 == c3 + 1 || a1 == b2 - 1 && b2 == c3 - 1)
                    {
                        board_score++;

                    }
                    if (c1 == b2 + 1 && b2 == a3 + 1 || c1 == b2 - 1 && b2 == a3 - 1)
                    {
                        board_score++;

                    }
                    board_score = board_score * board_score;
                    //Board score must be zero in order to start the game, board_control is used to check that.
                    if (board_score == 0 && board_control == 1)
                    {
                        board_control = 0;
                    }
                    
                    //Giving score to the player.
                    if (board_score > 0 && board_control == 0)
                    {
                        player_score += board_score;

                        Console.WriteLine("-------------- Round " + i + "--------------");
                        Console.WriteLine("                           Turn : " + counter + " / Player");
                        Console.WriteLine("+ - - - +");
                        Console.Write("| {0} {1} {2} |", a1, a2, a3);
                        Console.WriteLine("      Board Score: " + board_score);
                        Console.Write("| {0} {1} {2} |", b1, b2, b3);
                        Console.WriteLine("      Player Score: " + player_score);
                        Console.Write("| {0} {1} {2} |", c1, c2, c3);
                        Console.WriteLine("      Computer Score: " + computer_score);
                        Console.WriteLine("+ - - - +");
                        Console.WriteLine("End Of Round.");
                        Console.WriteLine("Press A Button To Continue");

                        Console.ReadLine();
                        Console.Clear();

                        a1 = 0; a2 = 0; a3 = 0; b1 = 0; b2 = 0; b3 = 0; c1 = 0; c2 = 0; c3 = 0;
                        break;
                    }
                    //New turn
                    else
                    {
                        counter++;
                        Console.WriteLine("-------------- Round " + i + "--------------");
                        Console.WriteLine("                           Turn : " + counter + " / Computer");
                        Console.WriteLine("+ - - - +");
                        Console.Write("| {0} {1} {2} |", a1, a2, a3);
                        Console.WriteLine("      Board Score: " + board_score);
                        Console.Write("| {0} {1} {2} |", b1, b2, b3);
                        Console.WriteLine("      Player Score: " + player_score);
                        Console.Write("| {0} {1} {2} |", c1, c2, c3);
                        Console.WriteLine("      Computer Score: " + computer_score);
                        Console.WriteLine("+ - - - +");


                    }
                    
                    //Checking the moves of computer player one by one

                    for (move = 1; move < 7; move++)
                    {
                        if (move == 1)
                        {
                            memory1 = a1;
                            memory2 = a2;
                            memory3 = a3;
                            a1 = memory3;
                            a2 = memory1;
                            a3 = memory2;

                        }
                        else if (move == 2)
                        {
                            memory1 = b1;
                            memory2 = b2;
                            memory3 = b3;
                            b1 = memory3;
                            b2 = memory1;
                            b3 = memory2;
                        }
                        else if (move == 3)
                        {
                            memory1 = c1;
                            memory2 = c2;
                            memory3 = c3;
                            c1 = memory3;
                            c2 = memory1;
                            c3 = memory2;
                        }
                        else if (move == 4)
                        {
                            memory1 = a1;
                            memory2 = b1;
                            memory3 = c1;
                            a1 = memory3;
                            b1 = memory1;
                            c1 = memory2;
                        }
                        else if (move == 5)
                        {
                            memory1 = a2;
                            memory2 = b2;
                            memory3 = c2;
                            a2 = memory3;
                            b2 = memory1;
                            c2 = memory2;

                        }
                        else if (move == 6)
                        {
                            memory1 = a3;
                            memory2 = b3;
                            memory3 = c3;
                            a3 = memory3;
                            b3 = memory1;
                            c3 = memory2;
                        }
                        //Checking if computer player got any points from its moves.
                        board_score = 0;
                        if (a1 == a2 + 1 && a2 == a3 + 1 || a1 == a2 - 1 && a2 == a3 - 1)
                        {
                            board_score++;
                        }
                        if (b1 == b2 + 1 && b2 == b3 + 1 || b1 == b2 - 1 && b2 == b3 - 1)
                        {
                            board_score++;

                        }
                        if (c1 == c2 + 1 && c2 == c3 + 1 || c1 == c2 - 1 && c2 == c3 - 1)
                        {
                            board_score++;

                        }
                        if (a1 == b1 + 1 && b1 == c1 + 1 || a1 == b1 - 1 && b1 == c1 - 1)
                        {
                            board_score++;

                        }
                        if (a2 == b2 + 1 && b2 == c2 + 1 || a2 == b2 - 1 && b2 == c2 - 1)
                        {
                            board_score++;

                        }
                        if (a3 == b3 + 1 && b3 == c3 + 1 || a3 == b3 - 1 && b3 == c3 - 1)
                        {
                            board_score++;

                        }
                        if (a1 == b2 + 1 && b2 == c3 + 1 || a1 == b2 - 1 && b2 == c3 - 1)
                        {
                            board_score++;

                        }
                        if (c1 == b2 + 1 && b2 == a3 + 1 || c1 == b2 - 1 && b2 == a3 - 1)
                        {
                            board_score++;

                        }
                        // Storing the score made by anyone of the six movements.
                        board_score = board_score * board_score;
                        if (move == 1)
                        {
                            point_move1 = board_score;

                            memory1 = a1;
                            memory2 = a2;
                            memory3 = a3;
                            a1 = memory2;
                            a2 = memory3;
                            a3 = memory1;
                        }
                        else if (move == 2)
                        {
                            point_move2 = board_score;
                            memory1 = b1;
                            memory2 = b2;
                            memory3 = b3;
                            b1 = memory2;
                            b2 = memory3;
                            b3 = memory1;
                        }
                        else if (move == 3)
                        {
                            point_move3 = board_score;

                            memory1 = c1;
                            memory2 = c2;
                            memory3 = c3;
                            c1 = memory2;
                            c2 = memory3;
                            c3 = memory1;
                        }
                        else if (move == 4)
                        {
                            point_move4 = board_score;

                            memory1 = a1;
                            memory2 = b1;
                            memory3 = c1;
                            a1 = memory2;
                            b1 = memory3;
                            c1 = memory1;
                        }
                        else if (move == 5)
                        {
                            point_move5 = board_score;

                            memory1 = a2;
                            memory2 = b2;
                            memory3 = c2;
                            a2 = memory2;
                            b2 = memory3;
                            c2 = memory1;
                        }
                        else if (move == 6)
                        {
                            point_move6 = board_score;

                            memory1 = a3;
                            memory2 = b3;
                            memory3 = c3;
                            a3 = memory2;
                            b3 = memory3;
                            c3 = memory1;
                        }
                    }
                    //using Max function to compare which move gives computer player the highest points, and playing it.
                    int max1 = Math.Max(point_move1, point_move2);
                    int max2 = Math.Max(max1, point_move3);
                    int max3 = Math.Max(max2, point_move4);
                    int max4 = Math.Max(max3, point_move5);
                    int max5 = Math.Max(max4, point_move6);
                    if (max5 == point_move3)
                    {
                        memory1 = c1;
                        memory2 = c2;
                        memory3 = c3;
                        c1 = memory3;
                        c2 = memory1;
                        c3 = memory2;
                        Console.WriteLine("Playing Move 3...");
                    }
                    else if (max5 == point_move4)
                    {
                        memory1 = a1;
                        memory2 = b1;
                        memory3 = c1;
                        a1 = memory3;
                        b1 = memory1;
                        c1 = memory2;
                        Console.WriteLine("Playing Move 4...");
                    }
                    else if (max5 == point_move1)
                    {
                        memory1 = a1;
                        memory2 = a2;
                        memory3 = a3;
                        a1 = memory3;
                        a2 = memory1;
                        a3 = memory2;
                        Console.WriteLine("Playing Move 1...");
                    }
                    else if (max5 == point_move2)
                    {
                        memory1 = b1;
                        memory2 = b2;
                        memory3 = b3;
                        b1 = memory3;
                        b2 = memory1;
                        b3 = memory2;
                        Console.WriteLine("Playing Move 2...");
                    }
                    else if (max5 == point_move6)
                    {
                        memory1 = a3;
                        memory2 = b3;
                        memory3 = c3;
                        a3 = memory3;
                        b3 = memory1;
                        c3 = memory2;
                        Console.WriteLine("Playing Move 6...");
                    }
                    else
                    {
                        memory1 = a2;
                        memory2 = b2;
                        memory3 = c2;
                        a2 = memory3;
                        b2 = memory1;
                        c2 = memory2;
                        Console.WriteLine("Playing Move 5...");
                    }
                    board_score = 0;
                    if (a1 == a2 + 1 && a2 == a3 + 1 || a1 == a2 - 1 && a2 == a3 - 1)
                    {
                        board_score++;
                    }
                    if (b1 == b2 + 1 && b2 == b3 + 1 || b1 == b2 - 1 && b2 == b3 - 1)
                    {
                        board_score++;

                    }
                    if (c1 == c2 + 1 && c2 == c3 + 1 || c1 == c2 - 1 && c2 == c3 - 1)
                    {
                        board_score++;

                    }
                    if (a1 == b1 + 1 && b1 == c1 + 1 || a1 == b1 - 1 && b1 == c1 - 1)
                    {
                        board_score++;

                    }
                    if (a2 == b2 + 1 && b2 == c2 + 1 || a2 == b2 - 1 && b2 == c2 - 1)
                    {
                        board_score++;

                    }
                    if (a3 == b3 + 1 && b3 == c3 + 1 || a3 == b3 - 1 && b3 == c3 - 1)
                    {
                        board_score++;

                    }
                    if (a1 == b2 + 1 && b2 == c3 + 1 || a1 == b2 - 1 && b2 == c3 - 1)
                    {
                        board_score++;

                    }
                    if (c1 == b2 + 1 && b2 == a3 + 1 || c1 == b2 - 1 && b2 == a3 - 1)
                    {
                        board_score++;

                    }
                    board_score = board_score * board_score;
                    //Giving score to the computer player.
                    if (board_score > 0 && board_control == 0)
                    {
                        computer_score = computer_score + board_score;
                        Console.WriteLine("-------------- Round " + i + "--------------");
                        Console.WriteLine("                           Turn : " + counter + " / Computer");
                        Console.WriteLine("+ - - - +");
                        Console.Write("| {0} {1} {2} |", a1, a2, a3);
                        Console.WriteLine("      Board Score: " + board_score);
                        Console.Write("| {0} {1} {2} |", b1, b2, b3);
                        Console.WriteLine("      Player Score: " + player_score);
                        Console.Write("| {0} {1} {2} |", c1, c2, c3);
                        Console.WriteLine("      Computer Score: " + computer_score);
                        Console.WriteLine("+ - - - +");


                        Console.WriteLine("End Of Round.");
                        Console.WriteLine("Press A Button To Continue");
                        Console.ReadLine();
                        Console.Clear();
                        counter = 1;
                        a1 = 0; a2 = 0; a3 = 0; b1 = 0; b2 = 0; b3 = 0; c1 = 0; c2 = 0; c3 = 0;
                        break;
                    }
                    else
                    {
                        counter++;
                        Console.WriteLine("-------------- Round " + i + "--------------");
                        Console.WriteLine("                           Turn : " + counter + " / Player");
                        Console.WriteLine("+ - - - +");
                        Console.Write("| {0} {1} {2} |", a1, a2, a3);
                        Console.WriteLine("      Board Score: " + board_score);
                        Console.Write("| {0} {1} {2} |", b1, b2, b3);
                        Console.WriteLine("      Player Score: " + player_score);
                        Console.Write("| {0} {1} {2} |", c1, c2, c3);
                        Console.WriteLine("      Computer Score: " + computer_score);
                        Console.WriteLine("+ - - - +");



                    }
                }
            }
            //Final result-The winner.
            Console.WriteLine("Game Over!");
            Console.WriteLine("Thanks For Playing!");
            if (player_score > computer_score)
            {
                Console.WriteLine("Player Wins!");
            }
            else if (computer_score > player_score)
            {
                Console.WriteLine("Computer Wins!");
            }
            else
            {
                Console.WriteLine("It's a Tie!");
            }


        }
    }
}