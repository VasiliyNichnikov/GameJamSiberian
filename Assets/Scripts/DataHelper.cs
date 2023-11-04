#nullable enable
using Configs;
using UnityEngine;

public class DataHelper: MonoBehaviour
{
    public static DataHelper Instance { get; private set; } = null!;
    
    public MessengerData MessengerData => _messengerData;
    public TrelloMiniGameData TrelloMiniGameData => _trelloMiniGameData;
    public ProgramsIconData ProgramsIconData => _programsIconData;

    [SerializeField] private MessengerData _messengerData = null!;
    [SerializeField] private TrelloMiniGameData _trelloMiniGameData = null!;
    [SerializeField] private ProgramsIconData _programsIconData = null!;
    
    private void Awake()
    {
        Instance = this;
    }
}