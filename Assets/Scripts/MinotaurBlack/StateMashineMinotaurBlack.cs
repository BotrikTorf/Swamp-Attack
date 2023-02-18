using UnityEngine;

public class StateMashineMinotaurBlack : MonoBehaviour
{
    public StatesMinotaurBlack CurrentPlayerState { get; private set; }

    public void Initialize(StatesMinotaurBlack startingState)
    {
        CurrentPlayerState = startingState;
        startingState.StartState();
    }

    public void ChangesSate(StatesMinotaurBlack state)
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = state;
        state.StartState();
    }
}
