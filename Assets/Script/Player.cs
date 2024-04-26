using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField] float _speed;
    private Rigidbody _rigidbody;

    private void Awake()
    {
       _rigidbody = GetComponent<Rigidbody>();
        HideandLockCursor();
    }

    /* Start is called before the first frame update
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 horizontalDirection = horizontal * _camera.transform.right;
        Vector3 verticalaDirection = vertical * _camera.transform.forward;
        horizontalDirection.y = 0;
        verticalaDirection.y = 0;

        Vector3 movementDirection = horizontalDirection + verticalaDirection;
        _rigidbody.velocity = movementDirection * _speed * Time.fixedDeltaTime;
    }

    void HideandLockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
