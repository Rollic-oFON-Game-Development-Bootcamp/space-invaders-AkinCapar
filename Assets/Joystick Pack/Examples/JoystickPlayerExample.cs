using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;
    private Vector2 playerPos;
    // public Rigidbody2D rb;


    public void FixedUpdate()
    {
        Vector3 direction = Vector3.up * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, (ForceMode2D)ForceMode.VelocityChange);
        //playerPos += direction * speed * Time.deltaTime;

        playerPos.x = Mathf.Clamp(playerPos.x + direction.x * speed, -2.3f, 2.3f);
        playerPos.y = Mathf.Clamp(playerPos.y + direction.y * speed, -4.6f, 4.6f);
        transform.position = playerPos;
    }
}