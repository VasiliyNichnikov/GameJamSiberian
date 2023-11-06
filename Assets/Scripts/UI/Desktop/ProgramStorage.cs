#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using ProgramsLogic;
using UnityEngine;

namespace UI.Desktop
{
    public class ProgramStorage
    {
        /// <summary>
        /// Срабатывает при установке программы
        /// </summary>
        public event Action<ProgramType>? OnInstalledProgram;
        /// <summary>
        /// Обновляется при обновление программу
        /// </summary>
        public event Action<ProgramType>? OnUpdatedProgram;
        /// <summary>
        /// Удален при обновление программы
        /// </summary>
        public event Action<ProgramType>? OnRemovedProgram;
        
        private readonly Dictionary<ProgramType, ProgramData> _installedPrograms = new();

        public void InstallProgram(ProgramData program)
        {
            if (_installedPrograms.ContainsKey(program.Type))
            {
                Debug.LogError($"ProgramStorage.InstallProgram: the program is already installed: {program.Type}");
                return;
            }

            _installedPrograms[program.Type] = program;
            OnInstalledProgram?.Invoke(program.Type);
        }

        public void UpdateProgram(ProgramType programType, DesktopProgramContext context)
        {
            if (!_installedPrograms.ContainsKey(programType))
            {
                Debug.LogError($"ProgramStorage.UpdateProgram: the program is not installed");
                return;
            }
            
            _installedPrograms[programType].UpdateContext(context);
            OnUpdatedProgram?.Invoke(programType);
        }
        
        public void RemoveProgram(ProgramType programType)
        {
            if (!_installedPrograms.ContainsKey(programType))
            {
                Debug.LogError($"ProgramStorage.RemoveProgram: the program is not installed");
                return;
            }
            
            _installedPrograms.Remove(programType);
            OnRemovedProgram?.Invoke(programType);
        }

        public IReadOnlyCollection<IProgram> Programs => _installedPrograms.Select(kvp => kvp.Value).Cast<IProgram>().ToList();

        public bool TryGetProgram(ProgramType program, out IProgram? result)
        {
            if (!_installedPrograms.TryGetValue(program, out var programData))
            {
                result = null;
                return false;
            }

            result = programData;
            return true;
        }
    }
}