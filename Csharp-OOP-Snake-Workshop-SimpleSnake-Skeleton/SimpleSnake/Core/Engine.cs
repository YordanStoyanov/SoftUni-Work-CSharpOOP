using SimpleSnake.Core.Contracts;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.GameObjects;
using SimpleSnake.Core.Contracts;
using SimpleSnake.GameObjects;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {

        private readonly Point[] pointsOfDirection;
        private Direction direction;
        private Wall wall;
        private readonly Snake snake;
        private double sleepTime;
        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100;
            this.pointsOfDirection = new GameObjects.Point[4];
        }
        public void Run()
        {
            this.CreateDirection();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }
                bool isMoving = this.snake
                .IsMoving(this.pointsOfDirection[(int)this.direction]);
                if (!isMoving)
                {
                    AskUserForRestart();
                }
                this.PrintStatisticsinfo();
                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void PrintStatisticsinfo()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;
            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine($"Player points: {this.snake.SnakePoints}");
            Console.SetCursorPosition(leftX, topY + 1);
            Console.WriteLine($"Player level: {this.snake.SnakeLevel}");
            Console.SetCursorPosition(leftX, topY + 2);
            Console.WriteLine("Food Points: '*' - 1, '$' - 2, '#' - 3");
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 6;
            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");
            Console.SetCursorPosition(leftX, topY + 1);
            Console.Write("Your choice: ");
            string input = Console.ReadLine();
            if (input.Contains("y"))
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private void CreateDirection()
        {
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }

            Console.CursorVisible = false;
        }
    }
}
