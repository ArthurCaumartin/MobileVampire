using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private UIJoystickControler _rightControler;
    [SerializeField] private UIJoystickControler _leftControler;
    public static UIJoystickControler CurrentJoystick;

    private void Start()
    {
        _rightControler.enabled = true;
        _leftControler.enabled = false;
        CurrentJoystick = _rightControler;
    }

    public void SwapControlerMainHand()
    {
        _rightControler.enabled = !_rightControler.enabled;
        _leftControler.enabled = !_leftControler.enabled;
        CurrentJoystick =_rightControler.enabled ? _rightControler : _leftControler;
    }
}
