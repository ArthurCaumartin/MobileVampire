using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSet;

    private void Start()
    {
        _offSet = _target.TransformPoint(transform.position);
    }

    private void Update()
    {
        transform.position = _target.position + _offSet;
    }
}
