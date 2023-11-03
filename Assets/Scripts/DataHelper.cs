#nullable enable
using Configs;
using UnityEngine;

public class DataHelper: MonoBehaviour
{
    public static DataHelper Instance { get; private set; } = null!;
    
    public MessengerData MessengerData => _messengerData;
    [SerializeField] private MessengerData _messengerData = null!;

    private void Awake()
    {
        Instance = this;
    }
}