#nullable enable
using System;
using Pool;
using UI.Programs.TrelloMiniGame.ViewModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.TrelloMiniGame.View
{
    public class TrelloTaskView : MonoBehaviour, IPointerClickHandler, IDisposable, IArrowObject, IObjectPool
    {
        [SerializeField] private Text _title = null!;
        [SerializeField] private Text _description = null!;
        [SerializeField] private Text _userName = null!;
        [SerializeField] private Text _userSurname = null!;
        [SerializeField] private Image _userIcon = null!;
        [SerializeField] private RectTransform _centerEmptyObject = null!;
        [Header("Tags")]
        [SerializeField] private RectTransform _tagsHolder = null!;
        [SerializeField] private TagView _tagPrefab = null!;

        private TrelloTasksPool? _pool;
        private ITrelloTaskViewModel _viewModel = null!;
        private TrelloArrowsManager _trelloArrowsManager = null!;
        
        public void Init(ITrelloTaskViewModel viewModel, TrelloArrowsManager trelloArrowsManager)
        {
            _trelloArrowsManager = trelloArrowsManager;
            _viewModel = viewModel;
            _title.text = _viewModel.Title;
            _description.text = _viewModel.Description;
            _userName.text = _viewModel.UserName;
            _userSurname.text = _viewModel.UserSurname;
            _userIcon.sprite = _viewModel.UserIcon;

            _viewModel.OnShowArrows += OnShowArrows;
            
            CreateTags();
        }

        private void CreateTags()
        {
            foreach (var tagName in _viewModel.Tags)
            {
                var view = Instantiate(_tagPrefab, _tagsHolder, false);
                view.gameObject.SetActive(true);
                view.Init(tagName);
            }
        }

        private void OnShowArrows()
        {
            _trelloArrowsManager.Show(this);
        }

        public void OnPointerClick(PointerEventData eventData) => _viewModel.OnClickTaskHandler();


        public void RemoveToPool() => _pool?.RemoveObject(this);
        
        public void Dispose()
        {
            _viewModel.OnShowArrows -= OnShowArrows;
        }

        RectTransform IArrowObject.RectTransform => _centerEmptyObject;
        int IArrowObject.ColumnNumber => _viewModel.ColumnNumber;
        void IArrowObject.MoveLeft() => _viewModel.OnMoveLeftColumnHandler();
        void IArrowObject.MoveRight()=> _viewModel.OnMoveRightColumnHandler();

        void IObjectPool.InitPool<T>(IPool<T> pool) => _pool = (TrelloTasksPool)pool;
        void IObjectPool.Show() => gameObject.SetActive(true);
        void IObjectPool.Hide() => gameObject.SetActive(false);
    }
}