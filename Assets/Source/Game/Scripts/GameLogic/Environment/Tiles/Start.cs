namespace GameLogic
{
    internal class Start : InterestTile
    {
        public override void Restart()
        {
            gameObject.SetActive(true);
        }
    }
}