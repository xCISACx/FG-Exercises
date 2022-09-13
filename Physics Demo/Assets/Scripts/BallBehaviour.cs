using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField] private float force;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        var mousePosition = Input.mousePosition;
        var castPoint = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.point);

            var dir = (GetComponent<Renderer>().bounds.center - hit.point).normalized;

            _rigidbody.AddForce(dir * force, ForceMode.Impulse);
        }
    }
}
