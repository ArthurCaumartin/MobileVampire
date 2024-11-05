using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Mob _mobPrefab;
    [SerializeField] private float _spawnPerSecond = 3;
    [SerializeField] private float _spawnDistance = 20;
    [Space]
    [SerializeField] private float _mobSpeed;
    private float _spawnTime;

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
        Vector3 pos = Random.insideUnitSphere;
        pos = new Vector3(pos.x, 0, pos.z);
        pos = _playerTransform.position + (pos.normalized * _spawnDistance);
        Mob newMob = Instantiate(_mobPrefab, pos, Quaternion.identity);
        newMob.Initialize(_playerTransform, _mobSpeed);
    }
}

public class Mob : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField, Range(0.1f, 2)] private float _speed;
    private float _speedFactor;

    public Mob Initialize(Transform target, float speedFactor)
    {
        _target = target;
        _speedFactor = speedFactor;
        return this;
    }

    private void Update()
    {
    }
}
