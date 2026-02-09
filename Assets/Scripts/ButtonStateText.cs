using UnityEngine;

namespace BananaParty.Input.TVRemote.Sample
{
    public class ButtonStateText : MonoBehaviour
    {
        private TVRemote _tvRemote = new();

        private EventQueue<PressEvent> _okButtonPressEventQueue;
        private EventQueue<ReleaseEvent> _okButtonReleaseEventQueue;

        private string _eventLog;

        private void OnEnable()
        {
            _okButtonPressEventQueue = _tvRemote.OkButton.PressEventHub.Subscribe();
            _okButtonReleaseEventQueue = _tvRemote.OkButton.ReleaseEventHub.Subscribe();
        }

        private void OnDisable()
        {
            _tvRemote.OkButton.PressEventHub.Unsubscribe(_okButtonPressEventQueue);
            _tvRemote.OkButton.ReleaseEventHub.Unsubscribe(_okButtonReleaseEventQueue);
        }
    }
}
