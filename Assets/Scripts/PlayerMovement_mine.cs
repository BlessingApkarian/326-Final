using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_mine : MonoBehaviour
{

    public CharacterController controller; // motor that drives player
    public Transform cam;


    public float gravity = 9.8f;
    public float speed = 1f;
    public float jumpSpeed = 5f;
    public float verticalSpeed = 0f;

    public float smoothTurnTime = 0.1f;
    public float turnSmoothVel;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 5;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // move x & z, normalize makes us able to move diagonal

        if (direction.magnitude >= 0.1f) // keys are being pressed
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // atan2 method calculates angle between the x-axis and the vector starting at 0 (look at a graph with a line) 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, smoothTurnTime); // smooth player turning
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // rotation & move direction 
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            // jumping
            if (controller.isGrounded)
            {
                verticalSpeed = 0;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    verticalSpeed = jumpSpeed;
                }
            }
            else
            {
                verticalSpeed -= gravity * Time.deltaTime;
            }

            direction.y = verticalSpeed;
            controller.Move(direction * Time.deltaTime);
        }
    }
}
