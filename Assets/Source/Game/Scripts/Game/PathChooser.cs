using System;
using UnityEngine;

public class PathChooser : MonoBehaviour
{
    private PlayerInput _playerInput;

    public event Action<Vector2Int> Moved;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Move.performed += ctx => Move();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void Move()
    {
        Vector2Int moveDirection = Vector2Int.RoundToInt(_playerInput.Player.Move.ReadValue<Vector2>());

        Moved.Invoke(moveDirection);
    }
}
