using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    [SerializeField] private bool _isBusy;
	public int position=-1;

    public bool IsBusy
    {
        get { return _isBusy; }
        set { _isBusy = value; }
    }
}