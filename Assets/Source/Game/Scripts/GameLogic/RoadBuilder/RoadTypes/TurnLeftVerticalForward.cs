namespace GameLogic
{
    internal class TurnLeftVerticalForward : Road
    {
        public override RoadType GetRoadType(int x, int y)
        {
            if (y == 0)
            {
                return RoadType.StraightHorizontalLeft;
            }
            else if (y > 0)
            {
                return RoadType.TurnLeftHorizontalLeft;
            }
            else if (y < 0)
            {
                return RoadType.TurnRightHorizontalLeft;
            }

            throw new System.ApplicationException();
        }
    }
}