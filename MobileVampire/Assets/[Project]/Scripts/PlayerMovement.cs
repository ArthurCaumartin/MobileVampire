using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;

    void Update()
    {
        Vector3 inputDir = InputManager.CurrentJoystick.GetDistanceDiretion();
        
        Vector3 moveDir = new Vector3(inputDir.x, inputDir.y, 0);
        transform.Translate(moveDir * _moveSpeed * Time.deltaTime);
    }
}
