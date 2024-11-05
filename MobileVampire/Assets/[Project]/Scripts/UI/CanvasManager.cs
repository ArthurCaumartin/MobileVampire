using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private ScriptableHealth _playerHealth;
    [Space]
    [SerializeField] private Image _playerLifeBar;

    private void Start()
    {
        SubToEvent();
    }

    private void SubToEvent()
    {
        _playerHealth.OnLifeChange.AddListener(SetPlayerLifeUI);
    }

    public void SetPlayerLifeUI(float max, float current)
    {
        _playerLifeBar.fillAmount = Mathf.InverseLerp(0, max, current); 
    }
}
