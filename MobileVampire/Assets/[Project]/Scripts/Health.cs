using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Health", menuName = "GameAsset/Health")]
public class ScriptableHealth : ScriptableObject
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth = 100;
    [Space]
    public UnityEvent<float, float> OnLifeChange;
    public UnityEvent OnLifeDeplete;

    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            if(_currentHealth <= 0)
            {
                OnLifeChange.Invoke(_maxHealth, 0);
                OnLifeDeplete.Invoke();
                return;
            }

            OnLifeChange.Invoke(_maxHealth, _currentHealth);
        }
    }

    public void SetLife(float max, float current)
    {
        _maxHealth = max;
        CurrentHealth = current;
    }
}
