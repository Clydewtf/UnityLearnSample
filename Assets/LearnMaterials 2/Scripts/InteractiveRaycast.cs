using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRaycast : InteractiveBox
{
    public GameObject prefab;

    private InteractiveBox selectedBox;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleLeftClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            HandleRightClick();
        }
    }

    void HandleLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("InteractivePlane"))
            {
                CreateInteractiveBox(hit.point, hit.normal);
            }
            else if (hit.collider.TryGetComponent<InteractiveBox>(out InteractiveBox clickedBox))
            {
                SetNextBox(clickedBox);
            }
        }
    }

    void CreateInteractiveBox(Vector3 position, Vector3 normal)
    {
        GameObject newBox = Instantiate(prefab, position, Quaternion.identity);
        InteractiveBox interactiveBox = newBox.GetComponent<InteractiveBox>();

        if (interactiveBox != null)
        {
            // Поворот объекта в соответствии с нормалью поверхности
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
            newBox.transform.rotation = rotation;

            SetNextBox(interactiveBox);
        }
    }

    void SetNextBox(InteractiveBox box)
    {
        if (selectedBox == null)
        {
            selectedBox = box;
        }
        else
        {
            selectedBox.AddNext(box);
            selectedBox = null;
        }
    }

    void HandleRightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent<InteractiveBox>(out InteractiveBox clickedBox))
            {
                Destroy(clickedBox.gameObject);
            }
        }
    }
}
