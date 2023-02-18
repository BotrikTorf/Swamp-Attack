using UnityEngine;

public class StateAtackMinotaurBlack : StatesMinotaurBlack
{
    private float _attackSpeed;
    private float _timeLastAttack;
    private int _damage;
    private StateMashineMinotaurBlack _stateMashine;

    public StateAtackMinotaurBlack(MinotaurBlack minotaur, StateMashineMinotaurBlack stateMashine)
    {
        _animator = minotaur.Animator;
        _target = minotaur.Target;
        _attackSpeed = 2;
        _stateMashine = stateMashine;
        _minotaur = minotaur;
    }

    public override void StartState()
    {
        _timeLastAttack = _attackSpeed;
        _damage = 10;
        _animator.enabled = true;
    }

    public override void ExitState() => _animator.enabled = false;

    public override void LogicUpdate()
    {
        _timeLastAttack += Time.deltaTime;

        if (_target == null)
        {
            _stateMashine.ChangesSate(_minotaur.StateCelebrations);
        }
        else if (_timeLastAttack > _attackSpeed && _target != null)
        {
            _animator.Play("AnimationMinotaurBlackAttack");
            _target.ApplyDamage(_damage);
            _timeLastAttack = 0;
        }
    }
}
