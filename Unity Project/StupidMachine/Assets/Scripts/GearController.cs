﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pivots;
    [SerializeField] GameObject _selectedPivot;

    private GameObject _target;
    private bool _isMouseDrag;
    private Vector3 _screenPosition;
    private Vector3 _offset;
    private GearController _gearController;
    private PlayerSounds _playerSounds;

    private void Start()
    {
        _gearController = GameObject.FindGameObjectWithTag("GearController").GetComponent<GearController>();

        _pivots = new List<GameObject>();

        foreach (GameObject pivot in GameObject.FindGameObjectsWithTag("Pivot"))
        {
            _pivots.Add(pivot);
        }

        _playerSounds = GetComponent<PlayerSounds>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            _target = ReturnClickedObject(out hitInfo);
            if (_target != null && _target.layer == 9) // Gears
            {
                Gear targetGear = _target.GetComponent<Gear>();
                if (targetGear.IsStatic)
                {
                    return;
                }

                targetGear.StartMovement();
                _isMouseDrag = true;
                //Convert world position to screen position.
                _screenPosition = Camera.main.WorldToScreenPoint(_target.transform.position);
                _offset = _target.transform.position -
                          Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                              _screenPosition.z));
            }
        }

        if (!_isMouseDrag)
        {
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isMouseDrag = false;
            _target.GetComponent<Gear>().EndMovement();
            _playerSounds.PlayGearClickSound();
        }

        if (_isMouseDrag)
        {
            //track mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPosition.z);

            //convert screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + _offset;

            //It will update target gameobject's current postion.
            _target.transform.position = currentPosition;
        }
    }

    private GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}