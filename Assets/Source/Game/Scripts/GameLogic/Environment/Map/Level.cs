﻿using UnityEngine;

namespace GameLogic
{
<<<<<<< HEAD
    internal class Level : MonoBehaviour
=======
    [System.Serializable]
    internal class Level
>>>>>>> NewPatch
    {
        [SerializeField] private Vector2Int _mapSize;
        [SerializeField] private int _healAmount;
        [SerializeField] private int _battleAmount;
        [SerializeField] private int _upgradeAmount;
        [SerializeField] private Vector3 _cameraPosition;
        [SerializeField] private Quaternion _cameraRotation;
        [SerializeField] private Vector3 _mobilePortretCameraPosition;
        [SerializeField] private Vector3 _mobilePortretCameraRotation;

        public Vector2Int MapSize => _mapSize;
<<<<<<< HEAD

        public int HealAmount => _healAmount;

        public int BattleAmount => _battleAmount;

        public int UpgradeAmount => _upgradeAmount;

        public Vector3 CameraPosition => _cameraPosition;

        public Quaternion CameraRotation => _cameraRotation;

        public Vector3 MobilePortretCameraPosition => _mobilePortretCameraPosition;

        public Vector3 MobilePortretCameraRotation => _mobilePortretCameraRotation;
    }
}
=======
        public int HealAmount => _healAmount;
        public int BattleAmount => _battleAmount;
        public int UpgradeAmount => _upgradeAmount;
        public Vector3 CameraPosition => _cameraPosition;
        public Quaternion CameraRotation => _cameraRotation;
        public Vector3 MobilePortretCameraPosition => _mobilePortretCameraPosition;
        public Vector3 MobilePortretCameraRotation => _mobilePortretCameraRotation;
    }
}
>>>>>>> NewPatch
