using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mammal : Animal
{    
    protected float runSpeed;

    private bool isRunning = false;

    public override void Initiate()
    {
        base.InitiateComponent();
    }

    public override void Move()
    {
        float moveSpeed;
        if (isRunning) moveSpeed = runSpeed;
        else        moveSpeed = base.walkSpeed;

        WalkAnimal(moveSpeed);
        RotateAniaml_LR();
        RotateAnimal_UD(base.GetCamTransform());
    }

    #region Get Property

    public float GetSwimSpeed()
    {
        return runSpeed;
    }

    public void IsRunning(bool active)
    {
        isRunning = active;
    }

    #endregion

}
