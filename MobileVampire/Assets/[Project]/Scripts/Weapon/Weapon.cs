using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Stat _stat;
    private float _attackTime;

    private void Update()
    {
        _attackTime += Time.deltaTime;
        if (_attackTime >= 1 / _stat.attackSpeed)
        {
            Attack();
        }
    }

    public virtual void Attack()
    {

    }
}
