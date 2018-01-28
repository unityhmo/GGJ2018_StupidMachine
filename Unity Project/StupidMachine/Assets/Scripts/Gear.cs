using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    private GearController _gearController;
    private GameObject _selectedPivot;
    private Vector3 _originalPosition;
    private bool _isPlacedInGrid;
    [SerializeField] private bool _isStatic;

    public bool canRotate;

    private void Start()
    {
        _gearController = GameObject.FindGameObjectWithTag("GearController").GetComponent<GearController>();
        _originalPosition = transform.position;
    }

    public void Update()
    {
        if (canRotate)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * 200);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // box collides with pivots
        if (collider.GetType().Name.Equals("BoxCollider") &&
            collider.gameObject.layer == 8 &&
            !collider.gameObject.GetComponent<Pivot>().IsBusy)
        {
            _selectedPivot = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        // box deal with pivots
        if (collider.GetType().Name.Equals("BoxCollider") &&
            collider.gameObject.layer == 8 &&
            !_isPlacedInGrid)
        {
            if (_selectedPivot == collider.gameObject)
            {
                _selectedPivot = null;
            }
        }
    }

    public void StartMovement()
    {
        if (_selectedPivot != null)
        {
            _selectedPivot.GetComponent<Pivot>().IsBusy = false;
        }
    }

    public void EndMovement()
    {
        if (_selectedPivot == null)
        {
            // restart position
            Vector3 newPosition = new Vector3(_originalPosition.x, _originalPosition.y, _originalPosition.z);
            transform.position = newPosition;
            _isPlacedInGrid = false;
        }
        else
        {
            // move to selected pivot
            Vector3 newPosition = new Vector3(
                _selectedPivot.transform.position.x,
                _selectedPivot.transform.position.y,
                transform.position.z
            );
            transform.position = newPosition;

            _selectedPivot.GetComponent<Pivot>().IsBusy = true;
            _isPlacedInGrid = true;
        }
    }

    public bool IsPlacedInGrid
    {
        get { return _isPlacedInGrid; }
        set { _isPlacedInGrid = value; }
    }

    public bool IsStatic
    {
        get { return _isStatic; }
    }
}