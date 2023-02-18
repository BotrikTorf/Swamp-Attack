using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStateMachine
{
    private Animator _animator;
    private Player _player;
    public PlayerState CurrentPlayerState { get; private set; }
    public PlayerStateMachine(Player player)
    {
        _animator = player.Animator;
        _player = player;
    }

    public void Initialize(PlayerState startingState)
    {
        CurrentPlayerState = startingState;
        startingState.StartState(_player.Destroyer);
    }

    public void ChangeState(PlayerState newState)
    {
        if (CurrentPlayerState != newState && newState is PlayerStateRangedWeapons)
        {
            _animator.Play("AnimationAxeToGun");
            ChangesSate(newState);

        }
        else if(CurrentPlayerState != newState && newState is PlayerStateAxe)
        {
            _animator.Play("AnimationGunToAxe");
            ChangesSate(newState);
        }
    }

    public void ChangesSate(PlayerState state)
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = state;
        state.StartState(_player.Destroyer);
    }
}
