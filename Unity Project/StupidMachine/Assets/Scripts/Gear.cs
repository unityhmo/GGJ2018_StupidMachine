using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    private GearController _gearController;

	public bool canRotate;

    private void Start()
    {
        _gearController = GameObject.FindGameObjectWithTag("GearController").GetComponent<GearController>();
    }

	public void Update(){
		if (canRotate) {
			transform.Rotate(Vector3.back * Time.deltaTime*200);
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) // Pivots
        {
            Pivot pivot = other.gameObject.GetComponent<Pivot>();
            _gearController.SetSelectedPivot(pivot);
        }
		if (other.gameObject.layer == 9) // Gears
		{
			if (other.gameObject.GetComponent<Gear> ().canRotate == true) {
				canRotate = true;
			}
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