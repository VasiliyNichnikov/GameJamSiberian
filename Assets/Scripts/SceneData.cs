#nullable enable
using UnityEngine;

/// <summary>
/// Данные которые лежат на сцене
/// </summary>
public class SceneData : MonoBehaviour
{
    /// <summary>
    /// Родитель в котором создаются диалоге
    /// </summary>
    public Transform DialogsParent => _dialogsParent;
    
    [SerializeField] private Transform _dialogsParent = null!;
}