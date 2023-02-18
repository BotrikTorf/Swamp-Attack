using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

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

        if (_currentWave.Count == _spawned)
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

        }
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _target.AddMoney(enemy.Reward);
    }

    private void OnEnemyDying(MinotaurBlack minotaur)
    {
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
