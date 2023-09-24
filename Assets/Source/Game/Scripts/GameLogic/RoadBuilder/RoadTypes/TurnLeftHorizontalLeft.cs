namespace GameLogic
{
    internal class TurnLeftHorizontalLeft : Road
    {
        public override RoadType GetRoadType(int x, int y)
        {
            if (y < 0)
            {
                return RoadType.StraightVerticalBackward;
            }
            else if (x > 0)
            {
                return RoadType.TurnRightVerticalBackward;
            }
            else if (x < 0)
            {
                return RoadType.TurnLeftVerticalBackward;
            }
            throw new System.ApplicationException();
        }
    }
}
