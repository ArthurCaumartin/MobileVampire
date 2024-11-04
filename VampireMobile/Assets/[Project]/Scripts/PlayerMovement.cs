using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private UIJoystickControler _controler;
    [Space]
    [SerializeField] private float _moveSpeed = 5;


    void Update()
    {
        transform.Translate(_controler.GetDistanceDiretion() * _moveSpeed * Time.deltaTime);
    }
}
