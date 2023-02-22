using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _enemyDied = 0;
    private int _enemiesAppeared;

    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay && _currentWave.Count > _spawned)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count == _spawned && _enemyDied == 0)
        {
            _currentWaveNumber++;

            if (_currentWaveNumber < _waves.Count)
            {
                SetWave(_currentWaveNumber);
            }
        }
    }

    private void InstantiateEnemy()
    {
        if (_target != null)
        {
            if (_currentWaveNumber == 0)
            {
                Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position,
                    _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
                enemy.Init(_target);
                enemy.Dying += OnEnemyDying;
            }
            else
            {
                MinotaurBlack minotaur = Instantiate(_currentWave.Template, _spawnPoint.position,
                    _spawnPoint.rotation, _spawnPoint).GetComponent<MinotaurBlack>();
                minotaur.Init(_target);
                minotaur.Dying += OnEnemyDying;
            }

            _enemyDied++;
            _enemiesAppeared++;
            EnemyCountChanged?.Invoke(_enemiesAppeared, _currentWave.Count);
        }
    }

    private void SetWave(int index)
    {
        _enemiesAppeared = 0;
        _currentWave = _waves[index];
        _spawned = 0;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        _enemyDied--;
        enemy.Dying -= OnEnemyDying;
        _target.AddMoney(enemy.Reward);
    }

    private void OnEnemyDying(MinotaurBlack minotaur)
    {
        _enemyDied--;
        minotaur.Dying -= OnEnemyDying;
        _target.AddMoney(minotaur.Reward);
    }

}


[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;

}
