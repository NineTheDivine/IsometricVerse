using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Plane : MonoBehaviour
{
    [SerializeField] FlappyManager manager;

    Animator anim = null;
    Rigidbody2D _rigidbody = null;

    [SerializeField] float flapForce = 3.0f;
    [SerializeField] float fowardSpeed = 3.0f;
    private float _additionalSpeed = 0.0f;
    private const float _maxSpeed = 10.0f;
    public bool isDead = false;
    public bool isFlap = false;
    public bool isStop = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (anim == null)
        {
            Debug.Log("Animator not found in Plane");
        }
        if (_rigidbody == null)
        {
            Debug.Log("Rigidbody not found in Plane");
        }
    }

    private void Start()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (isDead || isStop)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = fowardSpeed + _additionalSpeed;

        if (isFlap)
        {
            velocity.y = flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        Debug.Log("Player Died");
        anim.SetBool("IsDie", true);
        isDead = true;
        manager.ChangeState(FlappyManager.GameState.Dead);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
            manager.AddScore(1);
    }

    void OnFlap(InputValue input)
    {
        if (isDead || isFlap)
            return;
        isFlap = true;
    }

    public void setStop(bool state)
    {
        isStop = state;
        if (isStop)
        {
            _rigidbody.gravityScale = 0.0f;
        }
        else
        {
            _rigidbody.gravityScale = 1.0f;
        }
    }

    public void setAdditionalSpeed(float value)
    {
        if (value >= _maxSpeed)
            _additionalSpeed = _maxSpeed;
        else
            _additionalSpeed = value;
    }
}
