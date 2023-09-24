using TMPro;
using UnityEngine;

namespace UI
{
    internal class LeaderboardEntryView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _picture;

        public void SetData(LeaderboardEntry entry)
        {
            if (entry == null)
                return;

            _rank.text = entry.Rank;
            _playerName.text = entry.Name;
            _score.text = entry.Score;
            _picture.text = entry.Picture;
        }
    }
}
