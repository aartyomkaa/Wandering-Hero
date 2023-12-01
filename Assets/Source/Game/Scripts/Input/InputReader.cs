using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    internal class InputReader : MonoBehaviour
    {
        [SerializeField] private RoadBuilder _roadBuilder;

        [SerializeField] private Button _up;
        [SerializeField] private Button _left;
        [SerializeField] private Button _right;
        [SerializeField] private Button _down;

        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();

            _playerInput.Player.Move.performed += ctx => OnMove();
        }

        private void OnEnable()
        {
            _up.onClick.AddListener(OnMoveUp);
            _left.onClick.AddListener(OnMoveLeft);
            _right.onClick.AddListener(OnMoveRight);
            _down.onClick.AddListener(OnMoveDown);

            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _up.onClick.RemoveListener(OnMoveUp);
            _left.onClick.RemoveListener(OnMoveLeft);
            _right.onClick.RemoveListener(OnMoveRight);
            _down.onClick.RemoveListener(OnMoveDown);

            _playerInput.Disable();
        }

        private void OnMove()
        {
            if (Time.timeScale == 1)
            {
                Vector2Int moveDirection = Vector2Int.RoundToInt(_playerInput.Player.Move.ReadValue<Vector2>());

                if (moveDirection.x == 0 || moveDirection.y == 0)
                    _roadBuilder.Build(moveDirection);
            }
        }

        private void OnMoveUp()
        {
            _roadBuilder.Build(new Vector2Int(0, 1));
        }

        private void OnMoveLeft()
        {
            _roadBuilder.Build(new Vector2Int(-1, 0));
        }

        private void OnMoveRight()
        {
            _roadBuilder.Build(new Vector2Int(1, 0));
        }

        private void OnMoveDown()
        {
            _roadBuilder.Build(new Vector2Int(0, -1));
        }
    }
}