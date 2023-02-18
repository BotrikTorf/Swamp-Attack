using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _target;
    private Animator _animator;

    public Player Target => _target;
    public int Reward => _reward;

    public event UnityAction<Enemy> Dying;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            _health = 0;

        Destroy(gameObject);
        Dying?.Invoke(this);
    }
}
