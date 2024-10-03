using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{
    public float horizontalSpeed = 3f;
    public float horizontalRange = 5f;

    private float startX;

    void Start()
    {
        startX = transform.position.x;
        StartCoroutine(MoveHorizontally());
    }

    IEnumerator MoveHorizontally()
    {
        while (true)
        {
            float x = Mathf.PingPong(Time.time * horizontalSpeed, horizontalRange) - horizontalRange / 2;
            transform.position = new Vector2(startX + x, transform.position.y);
            yield return null;
        }
    }
}
