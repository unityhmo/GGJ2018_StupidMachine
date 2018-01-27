using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    private GearController _gearController;


    private void Start()
    {
        _gearController = GameObject.FindGameObjectWithTag("GearController").GetComponent<GearController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) // Pivots
        {
            Pivot pivot = other.gameObject.GetComponent<Pivot>();
            _gearController.SetSelectedPivot(pivot);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8) // Pivots
        {
            Pivot pivot = other.gameObject.GetComponent<Pivot>();

            if (pivot != null)
            {
                _gearController.CancelSelectedPivot(pivot);
            }
        }
    }
}