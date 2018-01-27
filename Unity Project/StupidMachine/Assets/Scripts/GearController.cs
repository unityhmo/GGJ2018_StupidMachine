using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    [SerializeField] private GameObject[] _pivots;
    [SerializeField] GameObject _selectedPivot;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetSelectedPivot(Pivot pivot)
    {
        if (_selectedPivot != null)
        {
            _selectedPivot.GetComponent<Pivot>().SetISelected(false);
        }

        _selectedPivot = pivot.gameObject;
        _selectedPivot.GetComponent<Pivot>().SetISelected(true);
    }

    public void CancelSelectedPivot(Pivot pivot)
    {
        if (_selectedPivot != null && _selectedPivot == pivot.gameObject)
        {
            _selectedPivot.GetComponent<Pivot>().SetISelected(false);
            _selectedPivot = null;
        }
    }

    public GameObject SelectedPivot
    {
        get { return _selectedPivot; }
    }
}