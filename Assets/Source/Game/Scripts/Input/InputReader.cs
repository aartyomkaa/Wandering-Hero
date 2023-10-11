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

            _playerInput.Player.Move.performed += ctx => Move();
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
            if (Time.timeScale == 1)
            {
                Vector2Int moveDirection = Vector2Int.RoundToInt(_playerInput.Player.Move.ReadValue<Vector2>());

                if (moveDirection.x == 0 || moveDirection.y == 0)
                    _roadBuilder.Build(moveDirection);
            }
        }

        private void MoveUp()
        {
            _roadBuilder.Build(new Vector2Int(0, 1));
        }

        private void MoveLeft()
        {
            _roadBuilder.Build(new Vector2Int(-1, 0));
        }

        private void MoveRight()
        {
            _roadBuilder.Build(new Vector2Int(1, 0));
        }

        private void MoveDown()
        {
            _roadBuilder.Build(new Vector2Int(0, -1));
        }
    }
}