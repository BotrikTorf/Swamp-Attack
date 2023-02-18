using UnityEngine;

public class StateRunMinotaurBlack : StatesMinotaurBlack
{
    private float _speed;
    private Transform _position;
    private StateMashineMinotaurBlack _stateMashine;
    private float _transitionRange;
    private float _rangeSpread;

    public StateRunMinotaurBlack(MinotaurBlack minotaur, StateMashineMinotaurBlack stateMashine)
    {
        _animator = minotaur.Animator;
        _target = minotaur.Target;
        _minotaur = minotaur;
        _stateMashine = stateMashine;
    }


    public override void StartState()
    {
        _animator.Play("AnimationMinotaurBlackRun");
        _position = _minotaur.Position;
        _speed = 2;
        _transitionRange = 2;
        _rangeSpread = 0.2f;
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    public override void ExitState() => _animator.enabled = false;

    public override void LogicUpdate()
    {
        if (_target == null)
        {
            _stateMashine.ChangesSate(_minotaur.StateCelebrations);
        }
        else
        {
            if (Vector2.Distance(_position.position, _target.transform.position) < _transitionRange)
            {
                _stateMashine.ChangesSate(_minotaur.StateAtack);
            }
            else
            {
                Vector3 newposition = Vector3.MoveTowards(_position.position, _target.transform.position,
                    _speed * Time.deltaTime);
                _minotaur.Move(newposition);
            }
        }
    }
}
