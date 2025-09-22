using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform parentPosition;
    [SerializeField] private Transform childPosition;
    private Vector3 parentLastPosition;
    private Vector3 childLastPosition;

    void Start()
    {
        parentLastPosition = parentPosition.position;
        childLastPosition = childPosition.position;

    }

    void Update()
    {
        if (parentPosition.position != parentLastPosition || childPosition.position != childLastPosition)
        {
            MoveObject(parentPosition, childPosition);
            parentLastPosition = parentPosition.position;
            childLastPosition = childPosition.position;
        }
    }

    private void MoveObject(Transform parentPosition, Transform childPosition)
    {
        Debug.Log("Parent position : " + parentPosition.position);
        Debug.Log("Parent localPosition : " + parentPosition.localPosition);
        
        Debug.Log("Child position : " + childPosition.position);
        Debug.Log("Child localPosition : " + childPosition.localPosition);
    }
}

