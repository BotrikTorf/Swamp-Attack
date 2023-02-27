using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] public List<Weapon> _weapons;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private WeaponPanel _weaponPanel;
    [SerializeField] private Destroyer _destroyer;

    private PlayerStateMachine _playerStateMachine;
    private PlayerStateAxe _playerStateAxe;
    private PlayerStateRangedWeapons _playerStateRangedWeapons;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;
    private float _passedAfterShot = 0;


    public event UnityAction ChangingCoins;
    public event UnityAction<int, int> ChangingHealth;

    public int Money { get; private set; }
    public Animator Animator => _animator;

    public Destroyer Destroyer => _destroyer;

    private void OnEnable() => _weaponPanel.ChangeState += OnChangeState;

    private void OnDisable() => _weaponPanel.ChangeState -= OnChangeState;

    private void Start()
    {
        Money = 100;
        _animator = GetComponent<Animator>();
        _currentWeapon = _weapons[0];
        _currentWeapon.GetAnimator(Animator);
        _currentHealth = _health;
        _playerStateMachine = new PlayerStateMachine(this);
        _playerStateAxe = new PlayerStateAxe();
        _playerStateRangedWeapons = new PlayerStateRangedWeapons();
        _playerStateMachine.Initialize(_playerStateAxe);
        ChangingCoins?.Invoke();

    }

    private void Update()
    {
        _passedAfterShot += Time.deltaTime;


    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        ChangingCoins?.Invoke();
        _weapons.Add(weapon);
        _weaponPanel.BuyWeapon(weapon);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        ChangingHealth?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        Money += money;
        ChangingCoins?.Invoke();
    }

    private void OnChangeState(int numberState, Weapon weapon)
    {
        for (int i = 0; i < _weapons.Count; i++)
            if (_weapons[i] == weapon)
                _currentWeapon = _weapons[i];

        _currentWeapon.GetAnimator(Animator);

        if (numberState == 0)
            _playerStateMachine.ChangeState(_playerStateAxe);
        else if (numberState == 1)
            _playerStateMachine.ChangeState(_playerStateRangedWeapons);
    }

    public void Shoot()
    {
        _currentWeapon.Shoot(_shootPoint, _passedAfterShot);

        if (_currentWeapon.IsAttackPassed)
            _passedAfterShot = 0;
    }
}
