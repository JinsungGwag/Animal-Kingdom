using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    /* �ʿ� �������� */
    private Transform animalTr;   // ������ ������ ��ġ ����
    [SerializeField]
    private Transform camTr;      // ������ ī�޶��� ��ġ ����
    //private AnimalAnim animalAnimComp;    // ������ �̵� �ִϸ��̼�
    [SerializeField]
    private Camera cam;

    /* ������ �����̴� �ӵ� */
    [SerializeField]
    protected float walkSpeed;    // �̵� �ӵ�
    [SerializeField]
    protected float rotXSpeed;    // �¿� ȸ�� �ӵ�
    [SerializeField]
    protected float rotYSpeed;    // ���� ȸ�� �ӵ�

    /* ���� ���� ID */
    protected int ID;

    private const float MAX_ROTATION_DEGREE = 45f;
    private const float MIN_ROTATION_DEGREE = -45f;

    public abstract void Initiate();
    public abstract void Move();

    public void InitiateComponent()
    {
        animalTr = GetComponent<Transform>();
        cam = transform.GetComponentInChildren<Camera>();
        camTr = cam.transform.GetComponent<Transform>();

        Debug.Log("Initiate " + this.transform.name + " / cam is null? " + (cam == null));
        
        SetActivaCamera(false);
    }

    private void Awake()
    {
        Initiate();
    }

    #region Animal Moving & Rotating Method

    public void WalkAnimal(float speed)
    {
        if (animalTr == null) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movedir = (Vector3.forward * v) + (Vector3.right * h);

        animalTr.Translate(movedir.normalized * Time.deltaTime * speed, Space.Self);
    }

    public void RotateAniaml_LR()
    {
        if (animalTr == null) return;

        float degreeX = Input.GetAxis("Mouse X");
        Vector3 rotdir = (Vector3.up * degreeX);
        animalTr.Rotate(rotdir.normalized * Time.deltaTime * rotXSpeed);
    }

    public void RotateAnimal_UD(Transform target)
    {
        if (target == null) return;

        float degreeY = Input.GetAxis("Mouse Y");
        Vector3 rotdir = (Vector3.left * degreeY);
        target.Rotate(rotdir.normalized * Time.deltaTime * rotYSpeed);

        CheckRotateLimit();
    }

    private void CheckRotateLimit()
    {
        Vector3 currentRot = camTr.localRotation.eulerAngles;
        currentRot.x = Clamp(currentRot.x, MIN_ROTATION_DEGREE, MAX_ROTATION_DEGREE);
        camTr.localRotation = Quaternion.Euler(currentRot);
    }

    private float Clamp(float value, float min, float max)
    {
        Debug.Assert(min <= max);

        value = Wrap(value, -180, 180);
        return Mathf.Min(Mathf.Max(MIN_ROTATION_DEGREE, value), MAX_ROTATION_DEGREE);
    }

    private float Wrap(float value, float min, float max)
    {
        Debug.Assert(min <= max);
        float n = (value - min) % (max - min);
        return (n >= 0) ? (n + min) : (n + max);
    }
    
    public void SetActivaCamera(bool active)
    {
        cam.enabled = active;
    }

    #endregion

    #region Get Property

    public int GetAnimalID()
    {
        return ID;
    }

    public float GetWalkSpeed()
    {
        return walkSpeed;
    }

    public Transform GetAnimalTransform()
    {
        return animalTr;
    }

    public Transform GetCamTransform()
    {
        return camTr;
    }

    public Camera GetCamera()
    {
        return cam;
    }

    #endregion
}
