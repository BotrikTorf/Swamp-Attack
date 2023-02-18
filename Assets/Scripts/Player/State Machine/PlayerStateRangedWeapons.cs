using UnityEngine;

public class PlayerStateRangedWeapons : PlayerState
{
    public override void StartState(Destroyer destroyer)
    {
        Vector2 position = new Vector2(-11, -3.5f);
        destroyer.SetPosition(position);
    }

    public override void ExitState() { }
}
