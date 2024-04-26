using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    private Rigidbody _rigidbody;

    private void Awake()
    {
       _rigidbody = GetComponent<Rigidbody>(); 
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

        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
        _rigidbody.velocity = movementDirection * _speed * Time.fixedDeltaTime;
    }
}
