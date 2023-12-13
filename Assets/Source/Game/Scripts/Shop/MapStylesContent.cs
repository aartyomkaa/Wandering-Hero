using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    internal class MapStylesContent : Content
    {
        [SerializeField] private MapStyle[] _mapStyles;

        protected override void Start()
        {
            base.Start();

            _selectedItem = _mapStyles[0];
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
                _selectedItem = _mapStyles[_scrollIndex];
            }

            base.ScrollLeft();
        }

        public override void ScrollRight()
        {
            if (_scrollIndex != _mapStyles.Length - 1)
            {
                _scrollIndex++;

                _selectedItem = _mapStyles[_scrollIndex];
            }

            base.ScrollRight();
        }

        protected override void FillImages()
        {
            foreach (var item in _mapStyles)
            {
                Image newImage = Instantiate(_imagePrefab, transform);

                newImage.sprite = item.Image;

                _images.Add(newImage);
            }
        }
    }
}
