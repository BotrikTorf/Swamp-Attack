using UnityEngine;

public class PlayerStateAxe : PlayerState
{
    public override void StartState(Destroyer destroyer)
    {
        Vector2 position = new Vector2(3.2f, -3.5f);
        destroyer.SetPosition(position);
    }

    public override void ExitState() { }
}
