#nullable enable
using System;
using Game;
using Plot;
using UI;
using UI.Desktop;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance { get; private set; } = null!;
    public IDialogsManager GuiManager => _guiManager;

    [SerializeField] private DialogsManager _guiManager = null!;
    [SerializeField] private SceneData _sceneData = null!;

    private GameLoader _gameLoader = null!;
    private PlotManager _plotManager = null!;
    
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

        _gameLoader = new GameLoader(new ClicksController(_sceneData));
        _plotManager = new PlotManager(_gameLoader.ComputerFacade);
    }

    private void Start()
    {
        // Порядок важен
        _guiManager.Init(_sceneData.DialogsParent);
        
        _gameLoader.LoadGame();

        _plotManager.StartPlot();
    }

    private void Update()
    {
        _plotManager.CheckExecutionOfPlot();
    }
}
