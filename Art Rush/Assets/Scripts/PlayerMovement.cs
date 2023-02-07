using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the Character Controller
    [SerializeReference]
    private CharacterController controller;

    // Player movement speed
    private float activeMoveSpeed;
    [SerializeField] private float normalSpeed = 15.0f;
    [SerializeField] private float dashSpeed = 30.0f;

    // Rotation variables
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Dash Variables
    [SerializeField] private float dashLength = 0.5f;
    [SerializeField] private float dashCooldown = 1f;
    // Internal Counters to manage Dash
    private float dashCounter;
    private float dashCooldownCounter;

    private void Start()
    {
        // Set Player speed to normal at the beginning
        activeMoveSpeed = normalSpeed;    
    }

    void Update()
    {
        // Get the Input and create a vector based on it
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        // If move actually has input complete process to move Player object
        if (move.magnitude >= 0.1f)
        {
            // Calculate Rotation of player and smoothen it for better visual
            float target_angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_angle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move player according to prior input
            controller.Move(move * Time.deltaTime * activeMoveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E");
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) //0 key to open Main Menu (not number pad)
        {
            SceneManager.LoadScene("TestingMenu");
        }

        // Dash Cooldown/Duration Controller
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCooldownCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = normalSpeed;
                dashCooldownCounter = dashCooldown;
            }
        }

        if (dashCooldownCounter > 0)
        { dashCooldownCounter -= Time.deltaTime; }
    }
}
