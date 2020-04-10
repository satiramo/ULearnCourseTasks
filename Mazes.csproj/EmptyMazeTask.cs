namespace Mazes
{
	public static class EmptyMazeTask
	{
        public static void MoveRight(Robot robot, int width)
        {
            var stepsInRight = width - 3;
            for (int i = stepsInRight; i > 0; i--)
                robot.MoveTo(Direction.Right);
        }
        public static void MoveDown(Robot robot, int height)
        {
            var stepsInDown = height - 3;
            for (int i = stepsInDown; i > 0; i--)
                robot.MoveTo(Direction.Down);
        }
        public static void MoveOut(Robot robot, int width, int height)
		{
            MoveRight(robot, width);
            MoveDown(robot, height);
		}
	}
}