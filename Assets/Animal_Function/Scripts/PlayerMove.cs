using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animal targetAnimal;
    
    private void FixedUpdate()
    {
        if (targetAnimal == null) return;
        targetAnimal.Move();
    }
    
    public void ChangePlayingAnimal(Animal target)
    {
        targetAnimal = target;
    }
}

