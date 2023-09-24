namespace GameLogic
{
    internal class Roadfinder
    {
        private Road _road;

        public Roadfinder(Road road)
        {
            _road = road;
        }

        public RoadType Find(int x, int y)
        {
            RoadType type = _road.GetRoadType(x, y);

            return type;
        }
    }
}