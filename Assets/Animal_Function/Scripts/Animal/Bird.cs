using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bird : Animal
{
    protected float flySpeed;

    private bool isFly = false;

    public override void Initiate()
    {
        base.InitiateComponent();
    }

    public override void Move()
    {
        CheckFly();
        CheckFlyKey();

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

    private void CheckFlyKey()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            isFly = true;
    }

    private void CheckFly()
    {
        if (this.transform.position.y > floorHigh)
            isFly = true;
        else
            isFly = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            isFly = false;
            this.transform.localRotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y, 0);
            this.transform.position = new Vector3(this.transform.position.x, floorHigh, this.transform.position.z);
            Debug.Log("Bird get on the floor!");
        }
    }

    #region Get Property

    public float GetFlySpeed()
    {
        return flySpeed;
    }

    #endregion
}
