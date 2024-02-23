using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int _healthpointsb;

    private void Awake()
    {
        _healthpointsb = 1000;
    }

    public bool TakeHit()
    {
        _healthpointsb -= 50;
        bool isDead = _healthpointsb <= 0;
        if (isDead) _Die();
        return isDead;
    }

    private void _Die()
    {
        Destroy(gameObject);
    }
}
