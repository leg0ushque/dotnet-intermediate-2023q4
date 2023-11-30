namespace GameOfLife
{
    class Cell
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int Age { get; set; }
        public bool IsAlive { get; set; }

        public bool IsAliveInNextGen { get; set; }
        public int AgeInNextGen { get; set; }

        public Cell(int row, int column, int age, bool alive, bool nextGenIsAlive = false, int nextGenAge = 0)
        {
            PositionX = row * 5;
            PositionY = column * 5;
            Age = age;
            IsAlive = alive;
            IsAliveInNextGen = nextGenIsAlive;
            AgeInNextGen = nextGenAge;
        }
    }
}