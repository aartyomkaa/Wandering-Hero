using TMPro;
using UnityEngine;

namespace UI
{
    internal class StarsScore : MonoBehaviour
    {
        [SerializeField] private ScorePanel _scorePanel;
        [SerializeField] private TMP_Text _text;

        private void OnEnable()
        {
            _scorePanel.ScoreChanged += OnScoreChange;
        }

        private void OnDisable()
        {
            _scorePanel.ScoreChanged -= OnScoreChange;
        }

        public void OnScoreChange(int value)
        {
            _text.text = value.ToString();
        }
    }
}