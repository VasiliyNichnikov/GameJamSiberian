using System.Collections.Generic;
using UnityEngine;


namespace UI.Programs.InstallerIDE.ViewModel
{
    public class MissionLogicViewModel : MonoBehaviour
    {

        public bool ChangeDiskLogic(bool _isComplete)
        {
            return _isComplete;
        }

        public bool DeselectTogglesLogic(List<DeselectToggleViewModel> _toggle)
        {
            bool _isComplete = false;
            foreach (var _state in _toggle)
            {
                _isComplete = _isComplete || _state.GetValue();
            }
            return !_isComplete;
        }
    }
}
