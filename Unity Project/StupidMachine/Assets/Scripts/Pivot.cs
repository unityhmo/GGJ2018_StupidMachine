using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    [SerializeField] private bool isSelected;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            transform.GetComponent<Renderer>().material.SetColor("_TintColor", Color.red);
        }
    }

    public void SetISelected(bool newStatus)
    {
        isSelected = newStatus;
    }
}