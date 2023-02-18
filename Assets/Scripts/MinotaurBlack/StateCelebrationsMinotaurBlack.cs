
public class StateCelebrationsMinotaurBlack : StatesMinotaurBlack
{
    public StateCelebrationsMinotaurBlack(MinotaurBlack minotaur, StateMashineMinotaurBlack stateMashine)
    {
        _animator = minotaur.Animator;
    }

    public override void StartState()
    {
        _animator.enabled = true;
        _animator.Play("AnimationMinotaurBlackCelebrations");
    }

    public override void ExitState() { }

    public override void LogicUpdate() { }
}
