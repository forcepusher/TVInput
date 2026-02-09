using UnityEngine;
using UnityEngine.UI;

namespace BananaParty.Input.TVRemote.Sample
{
    public class ButtonStateLog : MonoBehaviour
    {
        [SerializeField]
        private Text _text;

        private string _eventLog;

        private TVRemote _tvRemote = new();

        private EventQueue<PressEvent> _okButtonPressEventQueue;
        private EventQueue<ReleaseEvent> _okButtonReleaseEventQueue;

        private EventQueue<PressEvent> _upButtonPressEventQueue;
        private EventQueue<ReleaseEvent> _upButtonReleaseEventQueue;

        private EventQueue<PressEvent> _downButtonPressEventQueue;
        private EventQueue<ReleaseEvent> _downButtonReleaseEventQueue;

        private EventQueue<PressEvent> _leftButtonPressEventQueue;
        private EventQueue<ReleaseEvent> _leftButtonReleaseEventQueue;

        private EventQueue<PressEvent> _rightButtonPressEventQueue;
        private EventQueue<ReleaseEvent> _rightButtonReleaseEventQueue;

        private void OnEnable()
        {
            _okButtonPressEventQueue = _tvRemote.OkButton.PressEventHub.Subscribe();
            _okButtonReleaseEventQueue = _tvRemote.OkButton.ReleaseEventHub.Subscribe();

            _upButtonPressEventQueue = _tvRemote.UpButton.PressEventHub.Subscribe();
            _upButtonReleaseEventQueue = _tvRemote.UpButton.ReleaseEventHub.Subscribe();

            _downButtonPressEventQueue = _tvRemote.DownButton.PressEventHub.Subscribe();
            _downButtonReleaseEventQueue = _tvRemote.DownButton.ReleaseEventHub.Subscribe();

            _leftButtonPressEventQueue = _tvRemote.LeftButton.PressEventHub.Subscribe();
            _leftButtonReleaseEventQueue = _tvRemote.LeftButton.ReleaseEventHub.Subscribe();

            _rightButtonPressEventQueue = _tvRemote.RightButton.PressEventHub.Subscribe();
            _rightButtonReleaseEventQueue = _tvRemote.RightButton.ReleaseEventHub.Subscribe();
        }

        private void OnDisable()
        {
            _tvRemote.OkButton.PressEventHub.Unsubscribe(_okButtonPressEventQueue);
            _tvRemote.OkButton.ReleaseEventHub.Unsubscribe(_okButtonReleaseEventQueue);

            _tvRemote.UpButton.PressEventHub.Unsubscribe(_upButtonPressEventQueue);
            _tvRemote.UpButton.ReleaseEventHub.Unsubscribe(_upButtonReleaseEventQueue);

            _tvRemote.DownButton.PressEventHub.Unsubscribe(_downButtonPressEventQueue);
            _tvRemote.DownButton.ReleaseEventHub.Unsubscribe(_downButtonReleaseEventQueue);

            _tvRemote.LeftButton.PressEventHub.Unsubscribe(_leftButtonPressEventQueue);
            _tvRemote.LeftButton.ReleaseEventHub.Unsubscribe(_leftButtonReleaseEventQueue);

            _tvRemote.RightButton.PressEventHub.Unsubscribe(_rightButtonPressEventQueue);
            _tvRemote.RightButton.ReleaseEventHub.Unsubscribe(_rightButtonReleaseEventQueue);
        }

        // Yes, FixedUpdate with input is intentional
        private void FixedUpdate()
        {
            string currentStateText = string.Empty;

            currentStateText = $"{_tvRemote.OkButton.IsHeld}" + currentStateText;

            while (_okButtonPressEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.OkButton)} press at {_okButtonPressEventQueue.Read().Time}\n" + _eventLog;

            while (_okButtonReleaseEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.OkButton)} release at {_okButtonReleaseEventQueue.Read().Time}\n" + _eventLog;
        }
    }
}
