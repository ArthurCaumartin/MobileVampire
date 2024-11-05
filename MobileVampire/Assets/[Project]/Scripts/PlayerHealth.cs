using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private ScriptableHealth _health;

    void Start()
    {
        _health.SetLife(100, 50);
        _health.OnLifeDeplete.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    public void TakeTimeDamage(float value)
    {
        _health.CurrentHealth -= value;
    }

}
