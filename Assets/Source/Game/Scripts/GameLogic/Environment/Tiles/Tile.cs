﻿using UnityEngine;

namespace GameLogic
{
    public abstract class Tile : MonoBehaviour
    {
        private static Vector3 SelectOffset = new Vector3(0, 1.4f, 0);

        [SerializeField] private SpriteRenderer _selectIndicator;

        protected SpriteRenderer Sprite = null;

        protected void OnDisable()
        {
            if (Sprite != null)
                Sprite.gameObject.SetActive(false);
        }

        public virtual void Restart()
        {
            if (Sprite != null)
                Sprite.gameObject.SetActive(false);
        }

        public virtual void Highlight()
        {
            if (Sprite == null)
            {
                Sprite = Instantiate(
                    _selectIndicator,
                    transform.position + SelectOffset,
                    _selectIndicator.transform.rotation,
                    transform);
            }
            else
            {
                Sprite.gameObject.SetActive(true);
            }
        }
    }
}