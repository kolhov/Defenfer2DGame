using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float movementSpeed = 0;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
}
