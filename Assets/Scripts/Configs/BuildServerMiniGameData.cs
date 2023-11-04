#nullable enable
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
    [CreateAssetMenu(fileName = "BuildServerMiniGameData", menuName = "Configs/BuildServerMiniGameData", order = 0)]
    public class BuildServerMiniGameData : ScriptableObject
    {
        public IReadOnlyCollection<string> Questions => _questions;
        public IReadOnlyCollection<string> Errors => _errors;
        public string Susses => _susses;
        public string Task => _task;
        public string Hint => _hint;
        
        [SerializeField] private string[] _questions = null!; // t  w  x  y  z
        [SerializeField] private string[] _errors = null!;
        [SerializeField] private string _susses = null!;
        [SerializeField] private string _task = null!;
        [SerializeField] private string _hint = null!;
    }
}