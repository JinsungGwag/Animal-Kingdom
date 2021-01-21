using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bird : Animal
{
    protected float flySpeed;

    private bool isFly = false;

    public override void Move()
    {
        Transform target;
        float moveSpeed;

        if (isFly)
        {
            moveSpeed = flySpeed;
            target = base.GetAnimalTransform();
        }
        else
        {
            moveSpeed = base.walkSpeed;
            target = base.GetCamTransform();
        }

        WalkAnimal(moveSpeed);
        RotateAniaml_LR();
        RotateAnimal_UD(target);
    }

    #region Get Property

    public float GetFlySpeed()
    {
        return flySpeed;
    }

    #endregion
}
