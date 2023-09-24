namespace GameLogic
{
    internal class TurnLeftVerticalBackward : Road
    {
        public override RoadType GetRoadType(int x, int y)
        {
            if (y < 0)
            {
                return RoadType.TurnLeftHorizontalLeft;
            }
            else if (y > 0)
            {
                return RoadType.TurnRightHorizontalLeft;
            }
            else if (x < 0)
            {
                return RoadType.StraightHorizontalLeft;
            }

            throw new System.ApplicationException();
        }
    }
}