using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Vector3 _destroy;

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }
}
