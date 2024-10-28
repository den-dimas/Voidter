using System;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;
    Vector2 moveDirection;
    Vector2 moveVelocity;
    Vector2 moveFriction;
    Vector2 stopFriction;

    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        
        moveVelocity = 2.0f * maxSpeed / timeToFullSpeed;
        moveFriction = -2.0f * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2.0f * maxSpeed / (timeToStop * timeToStop);
    }

    public void Move() {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity += moveVelocity * Time.deltaTime * moveDirection;
        rb.velocity = new(Mathf.Clamp(rb.velocity.x, -maxSpeed.x, maxSpeed.x), Mathf.Clamp(rb.velocity.y, -maxSpeed.y, maxSpeed.y));
        rb.velocity -= GetFriction() * Time.deltaTime;

        if (Math.Abs(rb.velocity.x) < stopClamp.x && moveDirection.x == 0)
            rb.velocity = new(0, rb.velocity.y);

        if (Math.Abs(rb.velocity.y) < stopClamp.y && moveDirection.y == 0)
            rb.velocity = new(rb.velocity.x, 0);
    }

    public Vector2 GetFriction() {
        Vector2 totalFriction = Vector2.zero;

        if (moveDirection.x > 0)
            totalFriction.x = moveFriction.x;
        else if (moveDirection.x < 0)
            totalFriction.x = -moveFriction.x;
        else if (moveDirection.x == 0 && rb.velocity.x > 0)
            totalFriction.x = -stopFriction.x;
        else if (moveDirection.x == 0 && rb.velocity.x < 0)
            totalFriction.x = stopFriction.x;
        else
            totalFriction.x = 0;

        if (moveDirection.y > 0)
            totalFriction.y = moveFriction.y;
        else if (moveDirection.y < 0)
            totalFriction.y = -moveFriction.y;
        else if (moveDirection.y == 0 && rb.velocity.y > 0)
            totalFriction.y = -stopFriction.y;
        else if (moveDirection.y == 0 && rb.velocity.y < 0)
            totalFriction.y = stopFriction.y;
        else
            totalFriction.y = 0;

        return totalFriction;
    }
    
    public void MoveBound() {
    }

    public bool IsMoving() {
        if (moveDirection.magnitude != 0)
            return true;

        return false;
    }
}
