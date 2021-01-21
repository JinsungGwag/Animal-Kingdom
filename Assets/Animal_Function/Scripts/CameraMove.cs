using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //private Transform camTr;
    //private Transform animalTr;
    //private Transform camTargetTr;

    //[SerializeField]
    //private float rotSpeed = 100f;

    //private const float MAX_ROTATION_DEGREE = 45f;
    //private const float MIN_ROTATION_DEGREE = -45f;

    //private void Awake()
    //{
    //    camTr = GetComponent<Transform>();
    //}

    //private void Start()
    //{
    //    InitiateCam(animalTr);
    //}

    //private void FixedUpdate()
    //{
    //    RotateCam();
    //    CheckRotateLimit();
    //}

    //public bool InitiateCam(Transform target)
    //{
    //    if (target == null) return false;

    //    foreach(Transform child in target.GetComponentsInChildren<Transform>())
    //    {
    //        if(child.CompareTag("CamPoint"))
    //        {
    //            InitateCamTransform(child);
    //            InitiateCamProperty(target);
    //            return true;
    //        }
    //    }

    //    return false;
    //}

    //private void InitateCamTransform(Transform target)
    //{
    //    camTargetTr = target;
    //    camTr.parent = target;
    //    camTr.localRotation = Quaternion.identity;
    //    camTr.localPosition = Vector3.zero;
    //}

    //private void InitiateCamProperty(Transform target)
    //{
    //    Animal animal = target.GetComponent<Animal>();
    //    rotSpeed = animal.GetRotYSpeed();
    //}

    //private void RotateCam()
    //{
    //    if (camTr == null) return;

    //    float degreeY = Input.GetAxis("Mouse Y");
    //    Vector3 rotdir = (Vector3.left * degreeY);
    //    camTr.Rotate(rotdir.normalized * Time.deltaTime * rotSpeed);
    //}

    //private void CheckRotateLimit()
    //{
    //    Vector3 currentRot = camTr.localRotation.eulerAngles;
    //    currentRot.x = Clamp(currentRot.x, MIN_ROTATION_DEGREE, MAX_ROTATION_DEGREE);
    //    camTr.localRotation = Quaternion.Euler(currentRot);
    //}

    //private float Clamp(float value, float min, float max)
    //{
    //    Debug.Assert(min <= max);

    //    value = Wrap(value, -180, 180);
    //    return Mathf.Min(Mathf.Max(MIN_ROTATION_DEGREE, value), MAX_ROTATION_DEGREE);
    //}

    //private float Wrap(float value, float min, float max)
    //{
    //    Debug.Assert(min <= max);
    //    float n = (value - min) % (max - min);
    //    return (n >= 0) ? (n + min) : (n + max);
    //}


}
