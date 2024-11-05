using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private MobBehavior _mobPrefab;
    [SerializeField] private float _spawnPerSecond = 3;
    [Space]
    [SerializeField] private float _mobSpeed;
    private float _spawnTime;
    private float _spawnDistance = 20;
    private List<MobBehavior> _mobList = new List<MobBehavior>();

    private void Start()
    {
        _spawnDistance = Vector2.Distance(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Vector3.zero)) * 1.1f;
    }

    private void Update()
    {
        _spawnTime += Time.deltaTime;
        if (_spawnTime > 1 / _spawnPerSecond)
        {
            _spawnTime = 0;
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector3 pos = Random.insideUnitCircle;
        pos = _playerTransform.position + (pos.normalized * _spawnDistance);

        MobBehavior newMob = Instantiate(_mobPrefab, pos, Quaternion.identity);
        _mobList.Add(newMob.Initialize(_playerTransform, _mobSpeed, this));
    }

    public void DestroyMob(MobBehavior toDestroy)
    {
        if(_mobList.Contains(toDestroy))
        {
            _mobList.Remove(toDestroy);
            Destroy(toDestroy.gameObject);
        }
    }
}
