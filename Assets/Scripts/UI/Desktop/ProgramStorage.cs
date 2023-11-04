#nullable enable
using System;
using System.Collections.Generic;
using Configs;
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

        public void InstallProgram(DesktopProgramContext context)
        {
            if (_installedPrograms.ContainsKey(context.ProgramType))
            {
                Debug.LogError($"ProgramStorage.InstallProgram: the program is already installed");
                return;
            }

            _installedPrograms[context.ProgramType] = new ProgramData(context);
            OnInstalledProgram?.Invoke(context.ProgramType);
        }

        public void UpdateProgram(DesktopProgramContext context)
        {
            if (!_installedPrograms.ContainsKey(context.ProgramType))
            {
                Debug.LogError($"ProgramStorage.UpdateProgram: the program is not installed");
                return;
            }
            
            _installedPrograms[context.ProgramType].UpdateContext(context);
            OnUpdatedProgram?.Invoke(context.ProgramType);
        }
        
        public void RemoveProgram(DesktopProgramContext context)
        {
            if (!_installedPrograms.ContainsKey(context.ProgramType))
            {
                Debug.LogError($"ProgramStorage.RemoveProgram: the program is not installed");
                return;
            }

            _installedPrograms[context.ProgramType].Dispose();
            _installedPrograms.Remove(context.ProgramType);
            OnRemovedProgram?.Invoke(context.ProgramType);
        }

        public bool TryGetLoadedProgram(ProgramType type, out ProgramData? program)
        {
            if (!_installedPrograms.TryGetValue(type, out var result))
            {
                program = null;
                return false;
            }

            program = result;
            return true;
        }
    }
}