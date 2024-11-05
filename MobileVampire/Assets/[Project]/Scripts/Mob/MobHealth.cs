using UnityEngine;
using UnityEngine.Events;

public class MobHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth = 100;
    public UnityEvent OnDeathEvent;

    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
                OnDeathEvent.Invoke();
        }
    }
}