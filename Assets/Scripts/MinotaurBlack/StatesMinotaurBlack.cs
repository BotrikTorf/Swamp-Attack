using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatesMinotaurBlack
{
    private protected Player _target;
    private protected Animator _animator;
    private protected MinotaurBlack _minotaur;

    public abstract void StartState();

    public abstract void ExitState();

    public abstract void LogicUpdate();
}
