﻿using Configs;
using UI.Desktop;
using UI.Programs.InstallerIDE.View;
using UI.Programs.InstallerIDE.ViewModel;
using UnityEngine;

namespace ProgramsLogic
{
    /// <summary>
    /// Установщик IDE
    /// </summary>
    public class InstallerIdeProgram : ProgramData
    {
        public override ProgramType Type => ProgramType.InstallerIde;
        
        public bool IsCompleted { get; private set; }
        
        public InstallerIdeProgram(DesktopProgramContext context) : base(context)
        {
        }

        protected override void OnClickHandlerBase()
        {
            if (Main.Instance.ComputerFacade.IsProgramInstalled(ProgramType.IDE))
            {
                Debug.LogWarning("InstallerIdeProgram.OnClickHandlerBase: program is already installed");
                return;
            }
            
            var dialog = Main.Instance.GuiManager.ShowDialog<InstallerIDEDialog>();
            dialog.Init(new InstallerIDEViewModel(dialog.Hide));
            dialog.SetHideAction(() =>
            {
                State.Close();
                IsCompleted = true;
            });
            State.Open();
        }
    }
}