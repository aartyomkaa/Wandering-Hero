namespace GameLogic
{
    internal class StraightHorizontalRight : Road
    {
        public override RoadType GetRoadType(int x, int y)
        {
            if (y == 0)
            {
                return RoadType.StraightHorizontalRight;
            }
            else if (y > 0)
            {
                return RoadType.TurnLeftHorizontalRight;
            }
            else if (y < 0)
            {
                return RoadType.TurnRightHorizontalRight;
            }

            throw new System.ApplicationException();
        }
    }
}