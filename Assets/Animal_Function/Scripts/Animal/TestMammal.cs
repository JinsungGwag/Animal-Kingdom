using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMammal : Mammal
{
    public override void Initiate()
    {
        walkSpeed = 15f;
        rotXSpeed = 100f;
        rotYSpeed = 50f;

        base.InitiateComponent();
    }
}
