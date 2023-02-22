using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(StateMashineMinotaurBlack))]
[RequireComponent(typeof(Transform))]
public class MinotaurBlack : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private StateMashineMinotaurBlack _stateMachine;
    private StateAtackMinotaurBlack _stateAtack;
    private StateCelebrationsMinotaurBlack _stateCelebrations;
    private StateRunMinotaurBlack _stateRun;
    private Player _target;
    private Animator _animator;



    public Player Target => _target;
    public int Reward => _reward;
    public Animator Animator => _animator;
    public Transform Position => GetComponent<Transform>();

    public StateAtackMinotaurBlack StateAtack => _stateAtack;
    public StateCelebrationsMinotaurBlack StateCelebrations => _stateCelebrations;

    public event UnityAction<MinotaurBlack> Dying;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _stateMachine = GetComponent<StateMashineMinotaurBlack>();
        _stateRun = new StateRunMinotaurBlack( this, _stateMachine);
        _stateAtack = new StateAtackMinotaurBlack(this, _stateMachine);
        _stateCelebrations = new StateCelebrationsMinotaurBlack(this, _stateMachine);
        _stateMachine.Initialize(_stateRun);

    }

    private void Update() => _stateMachine.CurrentPlayerState.LogicUpdate();

    public void Init(Player target) => _target = target;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
            Dying?.Invoke(this);
        }
    }

    public void Move(Vector3 position) => transform.position = position;
}
