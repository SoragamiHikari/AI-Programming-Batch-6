using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField] private float _speed;
    [SerializeField] private float _powerUpDuration;
    [SerializeField] private int _health;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Transform _respawnPoint;
    private Rigidbody _rigidbody;
    private Coroutine _powerUpCoroutine;

    public Action OnPowerUpStart;
    public Action OnPowerUpEnd;
    private bool _isPowerUpActive = false;

    private void Awake()
    {
       _rigidbody = GetComponent<Rigidbody>();
        HideandLockCursor();
        UpdateUI();
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

        Vector3 movementDirection = (horizontalDirection + verticalaDirection);
        _rigidbody.velocity = movementDirection * _speed * Time.fixedDeltaTime;
    }

    void HideandLockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PickPowerUp()
    {
        if( _powerUpCoroutine != null )
        {
            StopCoroutine( _powerUpCoroutine );
        }

        _powerUpCoroutine = StartCoroutine(StartPowerUp());
    }

    private IEnumerator StartPowerUp()
    {
        _isPowerUpActive = true;
        if(OnPowerUpStart != null)
        {
            OnPowerUpStart();
        }
        
        yield return new WaitForSeconds(_powerUpDuration);

        _isPowerUpActive = false;
        if(OnPowerUpEnd != null)
        {
            OnPowerUpEnd();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_isPowerUpActive)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy>().Dead();
            }
        }
    }

    private void UpdateUI()
    {
        _healthText.text = "Health : " + _health;
    }

    public void Dead()
    {
        _health -= 1;
        if(_health > 0)
        {
            transform.position = _respawnPoint.position;
        }
        else
        {
            _health = 0;
            SceneManager.LoadScene("LoseScene");
        }
        UpdateUI();
    }
}
