namespace GameLogic
{
    internal class TurnRightVerticalBackward : Road
    {
        public override RoadType GetRoadType(int x, int y)
        {
            if (y < 0)
            {
                return RoadType.TurnRightHorizontalRight;
            }
            else if (y > 0)
            {
                return RoadType.TurnLeftHorizontalRight;
            }
            else if (x > 0)
            {
                return RoadType.StraightHorizontalRight;
            }

            throw new System.ApplicationException();
        }
    }
}