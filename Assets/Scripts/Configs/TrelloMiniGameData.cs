#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UI.Programs.Messenger;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Configs
{
    [CreateAssetMenu(fileName = "TrelloMiniGameData", menuName = "Configs/TrelloMiniGameData", order = 0)]
    public class TrelloMiniGameData : ScriptableObject
    {
        public enum TaskTag
        {
            UI,
            Code,
            Idea
        }
        
        [Serializable]
        public struct TaskData
        {
            public string Title => _title;
            public string Description => _description;
            public UserType User => _user;
            public int RightNumberColumn => _rightNumberColumn;
            public ReadOnlyCollection<TaskTag> Tags => new ReadOnlyCollection<TaskTag>(_tags);
            
            [SerializeField] private string _title;
            [SerializeField, TextArea] private string _description;
            [SerializeField] private UserType _user;
            [SerializeField] private TaskTag[] _tags;
            [FormerlySerializedAs("_numberColumn")]
            [Header("Answer: (Starting with 1)"), Range(1, 4)]
            [SerializeField] private int _rightNumberColumn;
        }
        
        [Serializable]
        public struct ColumnData
        {
            public string TitleText => _titleText;
            public IReadOnlyCollection<TaskData> Tasks => _tasks;
            
            [SerializeField] private string _titleText;
            [SerializeField] private TaskData[] _tasks;
        }

        public ColumnData FirstColumnData => _firstColumn;
        public ColumnData SecondColumnData => _secondColumn;
        public ColumnData ThirdColumnData => _thirdColumn;
        public ColumnData FourthColumnData => _fourthColumn;
        
        [SerializeField] private ColumnData _firstColumn;
        [SerializeField] private ColumnData _secondColumn;
        [SerializeField] private ColumnData _thirdColumn;
        [SerializeField] private ColumnData _fourthColumn;

        [SerializeField] 
        private MessengerData.UserData[] _users = null!;

        public MessengerData.UserData GetUserByType(UserType type) => _users.First(data => data.Type == type);
    }
}