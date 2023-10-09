using UnityEngine;

namespace Constants
{
    internal static class StaticVariables
    {
        public static int Intercat = Animator.StringToHash("Interact");
        public static int Restart = Animator.StringToHash("Restart");
        public static int Walking = Animator.StringToHash("Walking");
        public static int Attack = Animator.StringToHash("Attack");
        public static int Death = Animator.StringToHash("Death");
        public static int Dance = Animator.StringToHash("Dance");
        public static int Hit = Animator.StringToHash("Hit");

        public static Vector3 Offset = new Vector3(0, 1, 0);
        public static Vector3 SelectOffset = new Vector3(0, 1.4f, 0);
        public static Vector3 IndicatorOffset = new Vector3(0, 2, 0);
        public static Vector3 ControllerPosition = new Vector3(800, 437, 0);
        public static Vector3 ControllerPositionVertical = new Vector3(0, 280, 0);

        public static string WalkSound = "Walk";
        public static string ThemeSound = "Theme";
        public static string AttackSound = "Attack";
        public static string DefeatSound = "Defeat";
        public static string VictorySound = "Victory";
        public static string InteractSound = "Interact";
        public static string PlaceRoadSound = "PlaceRoad";
        public static string SkeletonAttack = "SkeletonAttack";
        public static string ButtonClickSound = "ButtonClick";

        public static string LostText = "Lost";
        public static string LoseText = "Lose";
        public static string VictoryText = "Victory";
        public static string LeaderboardName = "leader";
    }
}