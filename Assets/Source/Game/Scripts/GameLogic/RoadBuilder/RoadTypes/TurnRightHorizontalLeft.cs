namespace GameLogic
{
    internal class TurnRightHorizontalLeft : Road
    {
        public override RoadType GetRoadType(int x, int y)
        {
            if (y != 0)
            {
                return RoadType.StraightVerticalForward;
            }
            else if (x > 0)
            {
                return RoadType.TurnRightVerticalForward;
            }
            else if (x < 0)
            {
                return RoadType.TurnLeftVerticalForward;
            }
            throw new System.ApplicationException();
        }
    }
}
