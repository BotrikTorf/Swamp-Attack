using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] public List<Weapon> _weapons;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private CanvasGame _canvasGame;
    [SerializeField] private Destroyer _destroyer;

    private PlayerStateMachine _playerStateMachine;
    private PlayerStateAxe _playerStateAxe;
    private PlayerStateRangedWeapons _playerStateRangedWeapons;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;
    private float _passedAfterShot = 0;


    public event UnityAction ChangingCoins;

    public bool HaveAnimationLost { get; private set; }
    public int Money { get; private set; }
    public Animator Animator => _animator;

    public Destroyer Destroyer => _destroyer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentWeapon = _weapons[0];
        _currentWeapon.GetAnimator(Animator);
        _currentHealth = _health;
        _playerStateMachine = new PlayerStateMachine(this);
        _playerStateAxe = new PlayerStateAxe();
        _playerStateRangedWeapons = new PlayerStateRangedWeapons();
        _playerStateMachine.Initialize(_playerStateAxe);
    }

    private void OnEnable()
    {
        _canvasGame.ChangeState += OnChangeState;
    }

    private void OnDisable()
    {
        _canvasGame.ChangeState -= OnChangeState;
    }

    private void Update()
    {
        _passedAfterShot += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint, _passedAfterShot);

            if (_currentWeapon.IsAttackPassed)
            {
                _passedAfterShot = 0;
            }
        }
    }

    public void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        ChangingCoins?.Invoke();
    }

    private void OnChangeState(int numberState, int numberWeapon)
    {
        _currentWeapon = _weapons[numberWeapon];
        _currentWeapon.GetAnimator(Animator);

        if (numberState == 0)
        {
            _playerStateMachine.ChangeState(_playerStateAxe);
        }
        else if(numberState == 1)
        {
            _playerStateMachine.ChangeState(_playerStateRangedWeapons);
        }
    }


}
