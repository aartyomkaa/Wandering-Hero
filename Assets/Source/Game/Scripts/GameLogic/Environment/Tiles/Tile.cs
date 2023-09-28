using UnityEngine;

namespace GameLogic
{
    public abstract class Tile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _selectIndicator;

        protected SpriteRenderer _par = null;

        protected void OnDisable()
        {
            if (_par != null)
                _par.gameObject.SetActive(false);
        }

        public virtual void Restart()
        {
            if (_par != null)
                _par.gameObject.SetActive(false);
        }

        public virtual void Highlight()
        {
            if (_par == null)
                _par = Instantiate(_selectIndicator, gameObject.transform.position + Constants.StaticVariables.SelectOffset, _selectIndicator.transform.rotation, transform);
            else
                _par.gameObject.SetActive(true);
        }
    }
}