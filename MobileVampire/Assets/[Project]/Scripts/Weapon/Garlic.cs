using System.Collections.Generic;
using UnityEngine;

public class Garlic : Weapon
{
    private List<MobHealth> _mobInRange = new List<MobHealth>();

    void Start()
    {
        transform.localScale = Vector3.one * _stat.range;
    }

    public override void Attack()
    {
        for (int i = 0; i < _mobInRange.Count; i++)
        {
            _mobInRange[i].CurrentHealth -= _stat.damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MobHealth h = other.GetComponent<MobHealth>();
        if (h && !_mobInRange.Contains(h))
            _mobInRange.Add(h);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        MobHealth h = other.GetComponent<MobHealth>();
        if (h && _mobInRange.Contains(h))
            _mobInRange.Remove(h);
    }
}


