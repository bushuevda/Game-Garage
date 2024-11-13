using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    CharacterController _characterController;
    public float gravity = -9.8f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaZ = Input.GetAxis("Vertical") * speed;
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector3 moving = new Vector3(deltaX, 0, deltaZ);
        moving = Vector3.ClampMagnitude(moving, speed);
        moving.y = gravity;
        moving *= Time.deltaTime;

        moving = transform.TransformDirection(moving);
        _characterController.Move(moving);
    }
}
