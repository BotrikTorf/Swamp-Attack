using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyState _firstEnemyState;

    private Player _target;
    private EnemyState _currentEnemyState;

    public EnemyState CurrentEnemy => _currentEnemyState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_firstEnemyState);
    }

    private void Update()
    {
        if (_currentEnemyState == null)
            return;

        EnemyState nextEnemyState = _currentEnemyState.GetNextState();

        if (nextEnemyState != null)
            Transit(nextEnemyState);
    }

    private void Reset(EnemyState startEnemyState)
    {
        _currentEnemyState = startEnemyState;

        if (_currentEnemyState != null)
            _currentEnemyState.Enter(_target);
    }

    private void Transit(EnemyState nextEnemyState)
    {
        if (_currentEnemyState != null)
            _currentEnemyState.Exit();

        _currentEnemyState = nextEnemyState;

        if (_currentEnemyState != null)
            _currentEnemyState.Enter(_target);
    }
}
