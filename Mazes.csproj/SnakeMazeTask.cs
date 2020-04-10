namespace Mazes
{
	public static class SnakeMazeTask
	{

        public static void MoveRight(Robot robot, int steps)
        {            
            for (int i = steps; i > 0; i--)
                robot.MoveTo(Direction.Right);
        }

        public static void MoveLeft(Robot robot, int steps)
        {
            for (int i = steps; i > 0; i--)
                robot.MoveTo(Direction.Left);
        }

        public static void MoveHorizontal(Robot robot, int steps)
        {
            if(robot.X == 1)
                MoveRight(robot, steps);
            else
                MoveLeft(robot, steps);
        }

        public static void MoveDownIfCan(Robot robot, int steps, int height)
        {            
            if(height - robot.Y > 2)
                for (int i = steps; i > 0; i--)
                    robot.MoveTo(Direction.Down);
        }

        public static void MoveOut(Robot robot, int width, int height)
        {
            var horizontalSteps = width - 3;
            var verticalSteps = 2;           
            for (int i = (height - 1) / 2; i > 0; i--)
            {
                MoveHorizontal(robot, horizontalSteps);
                MoveDownIfCan(robot, verticalSteps, height);
            }
        }
    }
}