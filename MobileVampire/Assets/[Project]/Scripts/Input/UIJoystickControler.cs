using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIJoystickControler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [SerializeField] private RectTransform _joystick;
    [SerializeField] private RectTransform _joystickStick;
    private bool _isPointerDown;
    private Vector2 _pointerPosition;

    private void OnEnable()
    {
        EnableJoyStick(false);
    }

    private void EnableJoyStick(bool isActif, Vector3 enablePosition = new Vector3())
    {
        _isPointerDown = isActif;
        _joystick.gameObject.SetActive(isActif);
        if (isActif)
        {
            _joystick.position = enablePosition;
            _joystickStick.position = Vector3.zero;
        }
    }

    private void MoveStick(Vector3 pointerPos)
    {
        if (!_isPointerDown) return;

        float pointerDistance = Vector3.Distance(_joystick.position, pointerPos);
        float maxStickDistance = _joystick.rect.width;

        if (pointerDistance > maxStickDistance)
        {
            Vector3 pointerDir = (pointerPos - _joystick.position).normalized;
            _joystickStick.position = _joystick.position + (pointerDir * maxStickDistance);
        }
        else
        {
            _joystickStick.position = pointerPos;
        }
    }

    public Vector2 GetNormalizeDirection()
    {
        if (_isPointerDown)
        {
            return (_pointerPosition - (Vector2)_joystick.position).normalized;
        }
        else return Vector2.zero;
    }

    public Vector2 GetDistanceDiretion()
    {
        if (_isPointerDown)
        {
            return (_pointerPosition - (Vector2)_joystick.position).normalized
                    * Mathf.InverseLerp(0, _joystick.rect.width, Vector2.Distance(_joystick.position, _pointerPosition));
        }
        else return Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EnableJoyStick(true, eventData.position);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        _pointerPosition = eventData.position;
        MoveStick(eventData.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EnableJoyStick(false);
    }
}
