using Agava.WebUtility;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public class PathChooser : MonoBehaviour
    {
        [SerializeField] private Button _up;
        [SerializeField] private Button _left;
        [SerializeField] private Button _right;
        [SerializeField] private Button _down;
        [SerializeField] private MobileController _controller;

        private PlayerInput _playerInput;

        public event Action<Vector2Int> Moved;

        private void Awake()
        {
            _playerInput = new PlayerInput();

            _playerInput.Player.Move.performed += ctx => Move();

            if (Device.IsMobile == false)
                _controller.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _up.onClick.AddListener(MoveUp);
            _left.onClick.AddListener(MoveLeft);
            _right.onClick.AddListener(MoveRight);
            _down.onClick.AddListener(MoveDown);

            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _up.onClick.RemoveListener(MoveUp);
            _left.onClick.RemoveListener(MoveLeft);
            _right.onClick.RemoveListener(MoveRight);
            _down.onClick.RemoveListener(MoveDown);

            _playerInput.Disable();
        }

        private void Move()
        {
            Vector2Int moveDirection = Vector2Int.RoundToInt(_playerInput.Player.Move.ReadValue<Vector2>());

            if (moveDirection.x == 0 || moveDirection.y == 0)
                Moved.Invoke(moveDirection);
        }

        private void MoveUp()
        {
            Moved.Invoke(new Vector2Int(0, 1));
        }

        private void MoveLeft()
        {
            Moved.Invoke(new Vector2Int(-1, 0));
        }

        private void MoveRight()
        {
            Moved.Invoke(new Vector2Int(1, 0));
        }

        private void MoveDown()
        {
            Moved.Invoke(new Vector2Int(0, -1));
        }
    }
}