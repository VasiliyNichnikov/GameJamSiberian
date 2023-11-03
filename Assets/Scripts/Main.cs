#nullable enable
using Game;
using UI;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance { get; private set; } = null!;

    public IDialogsManager GuiManager => _guiManager;

    [SerializeField] private DialogsManager _guiManager = null!;
    [SerializeField] private SceneData _sceneData = null!;

    private GameLoader _gameLoader = null!;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }

        _gameLoader = new GameLoader();
    }

    private void Start()
    {
        // Порядок важен
        _guiManager.Init(_sceneData.DialogsParent);
        _gameLoader.LoadGame();
    }
}
