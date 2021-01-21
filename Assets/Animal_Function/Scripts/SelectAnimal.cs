using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnimal : MonoBehaviour
{
    public Animal startAnimal;

    private Animal nowAnimal;
    private Animal targetAnimal;

    private PlayerMove moveComp;

    private const float MAX_DISTANCE = 1000f;
    private const float CAST_RADIUS = 3f;

    private void Awake()
    {
        moveComp = GetComponent<PlayerMove>();
        targetAnimal = null;
        nowAnimal = startAnimal;
    }

    private void Start()
    {
        this.transform.parent = startAnimal.transform;
        this.transform.localPosition = Vector3.zero;

        startAnimal.SetActivaCamera(true);
        moveComp.ChangePlayingAnimal(startAnimal);
    }

    // Update is called once per frame
    void Update()
    {
        GetTargetObject();

        if (targetAnimal == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
            ChangeAnimal();
    }

    private void GetTargetObject()
    {
        Ray ray = nowAnimal.GetCamera().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.SphereCast(ray, CAST_RADIUS, out hit, MAX_DISTANCE))
        {
            if(hit.transform.CompareTag("Animal"))
            {
                targetAnimal = hit.transform.GetComponent<Animal>();
                Debug.Log("You see animal - " + hit.transform.name);
                return;
            }
        }

        targetAnimal = null;
    }

    private void ChangeAnimal()
    {
        if (targetAnimal == null) return;

        this.transform.parent = targetAnimal.transform;
        this.transform.localPosition = Vector3.zero;

        nowAnimal.SetActivaCamera(false);
        targetAnimal.SetActivaCamera(true);

        moveComp.ChangePlayingAnimal(targetAnimal);

        nowAnimal = targetAnimal;
    }
}
