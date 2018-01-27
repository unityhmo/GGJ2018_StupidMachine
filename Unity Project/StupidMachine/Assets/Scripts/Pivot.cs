using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    [SerializeField] private bool _isSelected;

    void Update()
    {
        if (_isSelected)
        {
            transform.GetComponent<Renderer>().material.SetColor("_TintColor", Color.red);
        }
    }

    public void SetISelected(bool newStatus)
    {
        _isSelected = newStatus;
    }
}