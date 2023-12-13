using Shop;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Store))]
    internal class StorePanel : Screen
    {
        [SerializeField] private MapStylesContent _mapContent;
        [SerializeField] private HeroesContent _heroesContent;
        [SerializeField] private ScrollRect _scrollRect;

        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Button _switchLeft;
        [SerializeField] private Button _switchRight;        
        [SerializeField] private Button _heroesButton;
        [SerializeField] private Button _mapStylesButton;

        private Store _store;
        private IItem _selectedItem;
        private Content _selectedContent;

        private void OnEnable()
        {
            _buyButton.onClick.AddListener(OnBuyButtonClick);
            _switchLeft.onClick.AddListener(SwitchLeft);
            _switchRight.onClick.AddListener(SwitchRight);
            _heroesButton.onClick.AddListener(OnHeroesButtonClick);
            _mapStylesButton.onClick.AddListener(OnMapStylesButtonClick);
            _selectButton.onClick.AddListener(OnSelectButtonClick);
        }

        private void Start()
        {
            _store = GetComponent<Store>();

            _selectedContent = _heroesContent;
            _scrollRect.content = GetRectTransform(_selectedContent);
            _selectedItem = _selectedContent.GetSelectedItem();
        }

        private void OnDisable()
        {
            _buyButton.onClick.RemoveListener(OnBuyButtonClick);
            _switchLeft.onClick.RemoveListener(SwitchLeft);
            _switchRight.onClick.RemoveListener(SwitchRight);
            _heroesButton.onClick.RemoveListener(OnHeroesButtonClick);
            _mapStylesButton.onClick.RemoveListener(OnMapStylesButtonClick);
            _selectButton.onClick.RemoveListener(OnSelectButtonClick);
        }

        private void SwitchLeft()
        {
            ButtonAudio.Play();

            _selectedContent.ScrollLeft();

            CheckItem();
        }

        private void SwitchRight()
        {
            ButtonAudio.Play();

            _selectedContent.ScrollRight();
            
            CheckItem();
        }

        private void CheckItem()
        {
            _selectedItem = _selectedContent.GetSelectedItem();

            if (_selectedItem.IsUnlocked)
            {
                _buyButton.gameObject.SetActive(false);
                _selectButton.gameObject.SetActive(true);
            }
            else
            {
                _buyButton.gameObject.SetActive(true);
                _selectButton.gameObject.SetActive(false);
            }
        }

        private void OnBuyButtonClick()
        {
            ButtonAudio.Play();
            _store.ProceedToBuy(_selectedItem);

            CheckItem();
        }

        private void OnHeroesButtonClick()
        {
            ButtonAudio.Play();
            _mapContent.gameObject.SetActive(false);
            _heroesContent.gameObject.SetActive(true);
            _selectedContent = _heroesContent;

            _scrollRect.content = GetRectTransform(_selectedContent);
        }

        private void OnMapStylesButtonClick()
        {
            ButtonAudio.Play();
            _heroesContent.gameObject.SetActive(false);
            _mapContent.gameObject.SetActive(true);
            _selectedContent = _mapContent;

            _scrollRect.content = GetRectTransform(_selectedContent);
        }

        private void OnSelectButtonClick()
        {
            ButtonAudio.Play();
            _store.ProceedToSelect(_selectedItem);
        }

        private RectTransform GetRectTransform(Content content)
        {
            if (content.gameObject.TryGetComponent<RectTransform>(out RectTransform transform))
                return transform;

            throw new System.Exception();
        }
    }
}
