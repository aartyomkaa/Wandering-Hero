using UnityEngine;

namespace Constants
{
    internal static class StaticVariables
    {
        public const string Intercat = "Interact";
        public const string Restart = "Restart";
        public const string Walking = "Walking";
        public const string Attack = "Attack";
        public const string Death = "Death";
        public const string Dance = "Dance";
        public const string Hit = "Hit";

<<<<<<< HEAD
        public const string LostText = "Lost";
        public const string LoseText = "Lose";
        public const string VictoryText = "Victory";
        public const string LeaderboardName = "leader";

        public const string MusicVolume = "MusicVolume";
=======
        public static Vector3 Offset = new Vector3(0, 1, 0);
        public static Vector3 SelectOffset = new Vector3(0, 1.4f, 0);
        public static Vector3 IndicatorOffset = new Vector3(0, 2, 0);
        public static Vector3 ControllerPosition = new Vector3(800, 437, 0);
        public static Vector3 ControllerPositionVertical = new Vector3(0, 280, 0);
        public static Vector3[] TileRotations = { new Vector3(0, 90, 0), new Vector3(0, -90, 0), new Vector3(0, 180, 0), new Vector3(0, -180, 0) };

        public static string LostText = "Lost";
        public static string LoseText = "Lose";
        public static string VictoryText = "Victory";
        public static string LeaderboardName = "leader";

        public static string MusicVolume = "MusicVolume";
        public static string Coins = "Coins";
>>>>>>> NewPatch
    }
}