using System;
namespace Mazes
{
	public static class DiagonalMazeTask
	{
        public static void SmartMove(Robot robot, int areaSidesProportion, bool rightMoveFirst, int width, int height)
        {
            bool canGoRight = true, canGoDown = true;
            while (canGoRight && canGoDown)
            {
                if (rightMoveFirst)
                {
                    canGoRight = MoveRightIfCan(robot, areaSidesProportion, width, height);
                    canGoDown = MoveDownIfCan(robot, 1, width, height);
                }
                else
                {
                    canGoDown = MoveDownIfCan(robot, areaSidesProportion, width, height);
                    canGoRight = MoveRightIfCan(robot, 1, width, height);
                }
            }
        }

        public static bool MoveRightIfCan(Robot robot, int areaSidesProportion, int width, int height)
        {
            if (robot.X + areaSidesProportion <= width -2)
            {
                for (int i = 0; i < areaSidesProportion; i++)
                    robot.MoveTo(Direction.Right);
                return true;
            }
            else
                return false;
        }

        public static bool MoveDownIfCan(Robot robot, int areaSidesProportion, int width, int height)
        {
            if (robot.Y + areaSidesProportion <= height - 2)
            {
                for (int i = 0; i < areaSidesProportion; i++)
                    robot.MoveTo(Direction.Down);
                return true;
            }
            else
                return false;
        }

        public static void MoveOut(Robot robot, int width, int height)
		{
            int areaSidesProportion = (Math.Max(width, height) - 2) / (Math.Min(width, height)-2);            
            bool rightMoveFirst;
            if (width >= height)
            {
                rightMoveFirst = true;
            }
            else
            {
                rightMoveFirst = false;
            }
            SmartMove(robot, areaSidesProportion, rightMoveFirst, width, height);
        }
	}
}