using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZagMovement : MonoBehaviour
{
    public float speed = 5f;
    public float frequency = 20f;  // Speed of sine movement
    public float magnitude = 0.5f; // Size of sine movement


    private Vector2 axis;
    private Vector2 pos;


    void Start()
    {
        pos = transform.position;
        axis = transform.right; // side to side movement axis
    }

    void Update()
    {
        pos += -speed * Time.deltaTime * Vector2.up;
        transform.position = pos + magnitude * Mathf.Sin(Time.time * frequency) * axis;
    }
}
