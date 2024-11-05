using UnityEngine;

public class MobBehavior : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField, Range(0.1f, 2)] private float _speed;
    private float _speedFactor;
    private MobSpawner _spawner;

    public MobBehavior Initialize(Transform target, float speedFactor, MobSpawner spawner)
    {
        _target = target;
        _speedFactor = speedFactor;
        _spawner = spawner;

        GetComponent<MobHealth>().OnDeathEvent.AddListener(() => _spawner.DestroyMob(this));

        return this;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 targetDir = (_target.position - transform.position).normalized;
        transform.Translate(targetDir * _speed * _speedFactor * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth h = other.GetComponent<PlayerHealth>();
        if (!h) return;
        h.TakeTimeDamage(5 * Time.deltaTime);
    }
}
