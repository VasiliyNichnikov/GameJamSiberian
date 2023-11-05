#nullable enable
using System.Collections.Generic;
using UnityEngine;

namespace UI.Programs.TrelloMiniGame.ViewModel
{
    public interface ITrelloTaskViewModel
    {
        int ColumnNumber { get; }
        string Title { get; }
        string Description { get; }
        string UserName { get; }
        string UserSurname { get; }
        Sprite UserIcon { get; }
        IReadOnlyCollection<string> Tags { get; }

        void OnMoveLeftColumnHandler();
        void OnMoveRightColumnHandler();
    }
}