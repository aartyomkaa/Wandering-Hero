using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    internal class HeroesContent : Content
    {
        [SerializeField] private Hero[] _heroes;

        protected override void Start()
        {
            base.Start();

            _selectedItem = _heroes[0];
        }

        public override IItem GetSelectedItem()
        {
            return _selectedItem;
        }

        public override void ScrollLeft()
        {
            if (_scrollIndex != 0)
            {
                _scrollIndex--;
                _selectedItem = _heroes[_scrollIndex];
            }

            base.ScrollLeft();
        }

        public override void ScrollRight()
        {
            if (_scrollIndex != _heroes.Length - 1)
            {
                _scrollIndex++;
                _selectedItem = _heroes[_scrollIndex];
            }

            base.ScrollRight();
        }

        protected override void FillImages()
        {
            foreach (var item in _heroes)
            {
                Image newImage = Instantiate(_imagePrefab, transform);

                newImage.sprite = item.Image;

                _images.Add(newImage);
            }
        }
    }
}
