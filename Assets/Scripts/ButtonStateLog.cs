using UnityEngine;
using UnityEngine.UI;

namespace BananaParty.Input.TVRemote.Sample
{
    public class ButtonStateLog : MonoBehaviour
    {
        [SerializeField]
        private Text _text;

        private string _eventLog;

        private readonly TVRemote _tvRemote = new();

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
            while (_okButtonPressEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.OkButton)} press at {_okButtonPressEventQueue.Read().Time}\n" + _eventLog;

            while (_okButtonReleaseEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.OkButton)} release at {_okButtonReleaseEventQueue.Read().Time}\n" + _eventLog;


            while (_upButtonPressEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.UpButton)} press at {_upButtonPressEventQueue.Read().Time}\n" + _eventLog;

            while (_upButtonReleaseEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.UpButton)} release at {_upButtonReleaseEventQueue.Read().Time}\n" + _eventLog;


            while (_downButtonPressEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.DownButton)} press at {_downButtonPressEventQueue.Read().Time}\n" + _eventLog;

            while (_downButtonReleaseEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.DownButton)} release at {_downButtonReleaseEventQueue.Read().Time}\n" + _eventLog;


            while (_leftButtonPressEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.LeftButton)} press at {_leftButtonPressEventQueue.Read().Time}\n" + _eventLog;

            while (_leftButtonReleaseEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.LeftButton)} release at {_leftButtonReleaseEventQueue.Read().Time}\n" + _eventLog;


            while (_rightButtonPressEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.RightButton)} press at {_rightButtonPressEventQueue.Read().Time}\n" + _eventLog;

            while (_rightButtonReleaseEventQueue.HasUnreadEvents)
                _eventLog = $"{nameof(_tvRemote.RightButton)} release at {_rightButtonReleaseEventQueue.Read().Time}\n" + _eventLog;


            string currentStateText = string.Empty;

            currentStateText = $"{nameof(_tvRemote.OkButton)} held = {_tvRemote.OkButton.IsHeld}\n" + currentStateText;
            currentStateText = $"{nameof(_tvRemote.UpButton)} held = {_tvRemote.UpButton.IsHeld}\n" + currentStateText;
            currentStateText = $"{nameof(_tvRemote.DownButton)} held = {_tvRemote.DownButton.IsHeld}\n" + currentStateText;
            currentStateText = $"{nameof(_tvRemote.LeftButton)} held = {_tvRemote.LeftButton.IsHeld}\n" + currentStateText;
            currentStateText = $"{nameof(_tvRemote.RightButton)} held = {_tvRemote.RightButton.IsHeld}\n" + currentStateText;

            _text.text = currentStateText + "\n" + _eventLog;
        }
    }
}
