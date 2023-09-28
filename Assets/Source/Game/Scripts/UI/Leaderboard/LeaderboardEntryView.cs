using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI
{
    internal class LeaderboardEntryView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private Image _image;

        private Coroutine _setImage;

        public void SetData(LeaderboardEntry entry)
        {
            if (entry == null)
                return;

            if (_setImage != null)
                StopCoroutine(_setImage);
            else
                _setImage = StartCoroutine(SetImage(entry.Picture));

            _rank.text = entry.Rank;
            _playerName.text = entry.Name;
            _score.text = entry.Score;
        }

        private IEnumerator SetImage(string url)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError
                || request.result == UnityWebRequest.Result.DataProcessingError)
            {
                throw new System.Exception();
            }
            else
            {
                Texture2D texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), Vector2.zero);
                _image.sprite = sprite;
            }      
        }
    }
}
