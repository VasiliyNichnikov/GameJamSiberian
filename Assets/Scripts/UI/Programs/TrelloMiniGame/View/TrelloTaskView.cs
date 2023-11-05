#nullable enable
using System;
using Pool;
using UI.Programs.TrelloMiniGame.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Programs.TrelloMiniGame.View
{
    public class TrelloTaskView : MonoBehaviour, IArrowObject, IObjectPool
    {
        [SerializeField] private Text _title = null!;
        [SerializeField] private Text _userName = null!;
        [SerializeField] private Text _userSurname = null!;
        [SerializeField] private Image _userIcon = null!;
        [SerializeField] private TrelloArrowsManager _arrowsManager = null!;
        [Header("Tags")]
        [SerializeField] private RectTransform _tagsHolder = null!;
        [SerializeField] private TagView _tagPrefab = null!;

        private TrelloTasksPool? _pool;
        private ITrelloTaskViewModel _viewModel = null!;
        
        public void Init(ITrelloTaskViewModel viewModel)
        {
            _viewModel = viewModel;
            _title.text = _viewModel.Title;
            _userName.text = _viewModel.UserName;
            _userSurname.text = _viewModel.UserSurname;
            _userIcon.sprite = _viewModel.UserIcon;
            
            _arrowsManager.Init(this);
            CreateTags();
        }

        private void CreateTags()
        {
            _tagsHolder.DestroyChildren();
            foreach (var tagName in _viewModel.Tags)
            {
                var view = Instantiate(_tagPrefab, _tagsHolder, false);
                view.gameObject.SetActive(true);
                view.Init(tagName);
            }
        }

        public void RemoveToPool() => _pool?.RemoveObject(this);
        
        int IArrowObject.ColumnNumber => _viewModel.ColumnNumber;
        void IArrowObject.MoveLeft() => _viewModel.OnMoveLeftColumnHandler();
        void IArrowObject.MoveRight()=> _viewModel.OnMoveRightColumnHandler();

        void IObjectPool.InitPool<T>(IPool<T> pool) => _pool = (TrelloTasksPool)pool;
        void IObjectPool.Show() => gameObject.SetActive(true);
        void IObjectPool.Hide() => gameObject.SetActive(false);
    }
}