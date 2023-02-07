using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float playerSpeed = 15.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Dash
    public float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f;
    public float dashCooldown = 1f;

    public float dashCounter;
    public float dashCooldownCounter;

    private void Start()
    {
        activeMoveSpeed = playerSpeed;    
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        if (move.magnitude >= 0.1f)
        {
            float target_angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_angle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(move * Time.deltaTime * activeMoveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E was pressed");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCooldownCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) //0 key to open Main Menu (not number pad)
        {
            SceneManager.LoadScene("TestingMenu");
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = playerSpeed;
                dashCooldownCounter = dashLength;
            }
        }

        if (dashCooldownCounter > 0)
        { dashCooldownCounter -= Time.deltaTime; }
    }
}
