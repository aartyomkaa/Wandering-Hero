using System.Collections.Generic;
using UnityEngine;
using Wanderer;

namespace UI
{
    internal class HealthBar : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Indicator _healthTemplate;

        private List<Indicator> _hearts = new List<Indicator>();
        private int _healthCount;

        private void OnEnable()
        {
            _playerHealth.HealthChanged += OnHealthChanged;
        }

        private void Start()
        {
            InitHearts();
        }

        private void OnDisable()
        {
            _playerHealth.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int value)
        {
            _healthCount = 0;

            foreach (Indicator heart in _hearts)
            {
                if (heart.gameObject.activeSelf)
                    _healthCount++;
            }

            if (_healthCount > value)
            {
                for (int i = _hearts.Count - 1; i >= 0; i--)
                {
                    if (_hearts[i].gameObject.activeSelf)
                    {
                        _hearts[i].Disappear();
                        return;
                    }
                }
            }
            else if (_healthCount < value)
            {
                for (int i = 0; i < _hearts.Count; i++)
                {
                    if (_hearts[i].gameObject.activeSelf == false)
                    {
                        _hearts[i].gameObject.SetActive(true);
                        _healthCount++;

                        if (_healthCount == value)
                            return;
                    }
                }
            }
        }

        private void InitHearts()
        {
            for (int i = 0; i < _playerHealth.MaxHealth; i++)
            {
                var heart = Instantiate(_healthTemplate, transform);
                _hearts.Add(heart);
            }
        }
    }
}