using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private EnemyState _targetEnemyState;

    protected Player Target { get; private set; }

    public EnemyState TargetEnemyState => _targetEnemyState;

    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
