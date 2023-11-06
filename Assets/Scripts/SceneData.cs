#nullable enable
using UnityEngine;
using Utils;

/// <summary>
/// Данные которые лежат на сцене
/// </summary>
public class SceneData : MonoBehaviour
{
    /// <summary>
    /// Родитель в котором создаются диалоге
    /// </summary>
    public Transform DialogsParent => _dialogsParent;
    public DisplayBlocker DisplayBlocker => _displayBlocker;
    
    [SerializeField] private Transform _dialogsParent = null!;
    [SerializeField] private DisplayBlocker _displayBlocker = null!;
}