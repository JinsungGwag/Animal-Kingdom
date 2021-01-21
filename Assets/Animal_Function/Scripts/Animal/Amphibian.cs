using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Amphibian : Animal
{
    protected float swimSpeed;

    private bool isSwim = false;

    public override void Initiate()
    {
        base.InitiateComponent();
    }

    public override void Move()
    {
        float moveSpeed;
        if (isSwim) moveSpeed = swimSpeed;
        else        moveSpeed = base.walkSpeed;

        WalkAnimal(moveSpeed);
        RotateAniaml_LR();
        RotateAnimal_UD(base.GetCamTransform());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Water"))
        {
            isSwim = true;
        }
        else
        {
            isSwim = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Water"))
        {
            isSwim = false;
        }
        else
        {
            isSwim = true;
        }
    }

    #region Get Property

    public float GetSwimSpeed()
    {
        return swimSpeed;
    }

    #endregion
}
