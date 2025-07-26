using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    protected SpriteRenderer sprite;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get => movementDirection; }

    protected float jumpdeg = 0.0f;
    protected float jumpheight = 0.0f;

    protected int playerSpeed = 5;

    protected bool _isJumping = false;

    public Area currentArea = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if (_rigidbody == null)
        {
            Debug.Log("PlayerController Rigidbody is empty");
            return;
        }
        if (sprite == null)
        {
            Debug.Log("PlayerController SpriteRenderer is empty");
            return;
        }
    }

    private void FixedUpdate()
    {
        if (_isJumping)
            JumpAction();

    }

    void OnMove(InputValue input)
    {
        movementDirection = input.Get<Vector2>();
        movementDirection = movementDirection.normalized;
        _rigidbody.velocity = movementDirection * playerSpeed;
        if (_rigidbody.velocity.x > 0)
            sprite.flipX = true;
        else if (_rigidbody.velocity.x < 0)
            sprite.flipX = false;
    }

    void OnJump(InputValue input)
    {
        if (_isJumping)
            return;
        _isJumping=true;
    }

    void OnEnter(InputValue input)
    {
        if (currentArea != null)
            currentArea.ActivateArea();
    }

    void JumpAction()
    {
        jumpdeg = Mathf.Lerp(jumpdeg, 2.0f, Time.deltaTime * playerSpeed);
        jumpheight += Mathf.Cos(jumpdeg);
        transform.position += new Vector3(0, Mathf.Cos(jumpdeg) / 10.0f, 0);
        if (jumpheight < 0.0f)
        {
            jumpheight = 0.0f;
            jumpdeg = 0.0f;
            _isJumping = false;
        }
    }

    public void SetArea(Area area)
    {
        if (currentArea != null)
            return;
        currentArea = area;
    }
}
