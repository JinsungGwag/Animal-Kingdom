using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mammal
{
    public override void Initiate()
    {
        walkSpeed = 15f;
        rotXSpeed = 100f;
        rotYSpeed = 50f;

        base.Initiate();
    }

    public override void SetActivaCamera(bool active)
    {
        base.SetActivaCamera(active);
        this.gameObject.SetActive(active);
    }
}
