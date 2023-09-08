using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float Speed;
    private Touch _touch;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
        }
    }

    private void FixedUpdate()
    {
        if (_touch.phase == TouchPhase.Moved)
        {
            _rigidbody.velocity = new Vector3(_touch.deltaPosition.x * Speed * Time.fixedDeltaTime,
                transform.position.y,
                _touch.deltaPosition.y * Speed * Time.fixedDeltaTime);
        }
    }
}
