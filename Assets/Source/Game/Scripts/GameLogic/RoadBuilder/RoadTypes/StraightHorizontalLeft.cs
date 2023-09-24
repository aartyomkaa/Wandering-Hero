namespace GameLogic
{
    internal class StraightHorizontalLeft : Road
    {
        public override RoadType GetRoadType(int x, int y)
        {
            if (y == 0)
            {
                return RoadType.StraightHorizontalLeft;
            }
            else if (y > 0)
            {
                return RoadType.TurnRightHorizontalLeft;
            }
            else if (y < 0)
            {
                return RoadType.TurnLeftHorizontalLeft;
            }

            throw new System.ApplicationException();
        }
    }
}