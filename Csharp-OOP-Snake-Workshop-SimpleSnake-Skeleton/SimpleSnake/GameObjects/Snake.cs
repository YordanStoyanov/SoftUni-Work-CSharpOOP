using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const int snakeStartLenght = 6;
        private readonly Queue<Point> snakeElements;
        private readonly Food[] foods;
        private readonly Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private const char snakeSymbol = '\u25CF';
        private int foodIndex;
        private const char emptySpaceSymbol = ' ';
        private bool isFoodSpawned;
        private int snakePoints;
        private int snakeLevel;

        public Snake(Wall wall)
        {
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];
            this.wall = wall;
            this.foodIndex = RandomFoodNumber;
            this.isFoodSpawned = false;
            this.snakePoints = 0;
            this.snakeLevel = 1;
            this.GetFood();
            this.CreateSnake();
        }

        public int SnakePoints
        {
            get
            {
                return this.snakePoints;
            }
        }
        public int SnakeLevel
        {
            get
            {
                return this.snakeLevel / 100;
            }
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= snakeStartLenght; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFood()
        {
            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodAsterisk(this.wall);

            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Type[] foodTypes = assembly
            //    .GetTypes()
            //    .Where(t => t.Name.StartsWith("Food"))
            //    .ToArray();
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);
            bool isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);
            if (isPointOfSnake)
            {
                return false;
            }
            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);
            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }
            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);
            if (!this.isFoodSpawned)
            {
                this.foods[foodIndex].SetRandomPosition(this.snakeElements);
                this.isFoodSpawned = true;
            }
            if (this.foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(emptySpaceSymbol);
            this.snakeLevel++;
            return true;
        }

        private void Eat(Point direction, Point correntSnakeHead)
        {
            int length = this.foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, correntSnakeHead);
            }
            this.snakePoints += length;
            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        public int RandomFoodNumber
        {
            get
            {
                return new Random().Next(0, this.foods.Length);
            }
        }
    }
}
