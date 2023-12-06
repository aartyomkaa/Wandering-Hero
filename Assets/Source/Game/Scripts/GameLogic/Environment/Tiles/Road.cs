namespace GameLogic
{
    internal abstract class Road : Tile
    {
        protected RoadType RoadType;

        public RoadType Type => RoadType;

        public abstract RoadType GetRoadType(int x, int y);
    }
}