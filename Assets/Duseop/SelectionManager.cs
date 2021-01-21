using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class AnimalInfo
{
    public string animalName;
    public string animalSpecific;
}
public class SelectionManager : MonoBehaviour
{
    public List<AnimalInfo> animalInfos;
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private bool isCameraMoving = false;
    [SerializeField] private bool isLookingInfo = false;
    [SerializeField] private GameObject animalInfoPage;
    [SerializeField] private Text animalName;
    [SerializeField] private Text animalSpecific;
    
    private Vector3 previousPosition;

    private Transform _selection;

    private void Update()
    {
        Selection();
    }

    private void Selection()
    {
        if (_selection != null)
        {
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Transform selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                if(!isCameraMoving&&!isLookingInfo)
                {
                    Renderer selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                    }

                    _selection = selection;

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        IEnumerator changeAnimal = ChangeAnimal(Camera.main.transform.position, selection.position);
                        isCameraMoving = true;
                        StartCoroutine(changeAnimal);
                    }

                    if(Input.GetMouseButton(0))
                    {
                        previousPosition = Camera.main.transform.position;
                        IEnumerator changeAnimal = ChangeAnimal(Camera.main.transform.position, new Vector3(selection.position.x+1,selection.position.y,selection.position.z-3));
                        isCameraMoving = true;
                        StartCoroutine(changeAnimal);
                       // animalName.text = animalInfos[Int32.Parse(selection.tag)].animalName;
                       // animalSpecific.text = animalInfos[Int32.Parse(selection.tag)].animalSpecific;
                        ShowInfo();
                    }
                }
            }
        }
    }

    IEnumerator ChangeAnimal(Vector3 current, Vector3 next)
    {
        float elapsedTime = 0f;
        float waitTime = 1.5f;
        while (elapsedTime<waitTime)
        {
            Camera.main.transform.position = Vector3.Lerp(current, next, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isCameraMoving = false;
        yield return null;
    }

    public void ShowInfo()
    {
        isLookingInfo = true;
        animalInfoPage.SetActive(true);
        animalInfoPage.GetComponent<Animator>().SetBool("open", true);
    }

    public void HideInfo()
    {
        isLookingInfo = false;
        animalInfoPage.GetComponent<Animator>().SetBool("open", false);
        animalInfoPage.SetActive(false);
        GoBack(previousPosition);
    }

    private void GoBack(Vector3 previousPos)
    {
        IEnumerator changeAnimal = ChangeAnimal(Camera.main.transform.position, previousPos);
        isCameraMoving = true;
        StartCoroutine(changeAnimal);
    }

    private void SetInfoPage()
    {

    }
    

}
