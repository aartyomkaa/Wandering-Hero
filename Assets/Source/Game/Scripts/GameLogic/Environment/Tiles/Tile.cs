using UnityEngine;

namespace GameLogic
{
    public abstract class Tile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _selectIndicator;

        protected SpriteRenderer _sprite = null;

        protected void OnDisable()
        {
            if (_sprite != null)
                _sprite.gameObject.SetActive(false);
        }

        public virtual void Restart()
        {
            if (_sprite != null)
                _sprite.gameObject.SetActive(false);
        }

        public virtual void Highlight()
        {
            if (_sprite == null)
            {
                _sprite = Instantiate(_selectIndicator, gameObject.transform.position +
                    Constants.StaticVariables.SelectOffset, _selectIndicator.transform.rotation, transform);
            }
            else
            {
                _sprite.gameObject.SetActive(true);
            }
        }
    }
}