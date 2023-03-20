using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    // Character Controller reference
    [SerializeReference] private CharacterController controller;

    //Used for the multiplayer controls, want different key presses to only affect one player not both
    [SerializeField]
    private int playerNumber;
    private string playerDash;
    
    // Player speed variables
    public float activeMoveSpeed;
    [SerializeField] private float normalSpeed = 15.0f;
    [SerializeField] private float dashSpeed = 35.0f;

    // Rotation Variables
    private float turnSmoothTime = 0.06f;
    private float turnSmoothVelocity;

    // Dash Variables
    [SerializeField] private float dashLength = 0.5f;
    [SerializeField] private float dashCooldown = 1f;
    // Dash Managing variables
    private float dashCounter;
    private float dashCooldownCounter;

    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }


    private void Start()
    {
        // Start set player's speed to default (normalSpeed)
        activeMoveSpeed = normalSpeed;
        Time.timeScale = 1f; //after pausing and reloading scene we need to make the player move again
        playerDash = "Dash" + playerNumber;
        
    }


    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }
        // Create Vector from player input
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"+playerNumber), 0f, Input.GetAxisRaw("Vertical"+playerNumber)).normalized;
        // Move and Rotate player
        if (move.magnitude >= 0.1f)
        {
            // Smooth Rotation
            float target_angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_angle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // Move using character controller
            controller.Move(move * Time.deltaTime * activeMoveSpeed);
        }

        // Filler Spot for Interaction Key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Debug.Log("E was pressed");
        }


        if (Input.GetKeyDown(KeyCode.Alpha0)) //0 key to open Main Menu (not number pad)
        {
            SceneManager.LoadScene("TestingMenu");
        }

        // If Dash key (space) is pressed
        if (Input.GetButtonDown(playerDash))
        {
            // If cooldown is 0 and is not already dashing
            if (dashCooldownCounter <= 0 && dashCounter <= 0)
            {
                // Increase speed
                activeMoveSpeed = dashSpeed;
                // Set counter for duration of dash
                dashCounter = dashLength;
            }
        }

        // Tick down the duration of Dash
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            // Reset Player speed to normal and set cooldown
            if (dashCounter <= 0)
            {
                activeMoveSpeed = normalSpeed;
                dashCooldownCounter = dashCooldown;
            }
        }
        // Tick down the cooldown counter
        if (dashCooldownCounter > 0)
        { dashCooldownCounter -= Time.deltaTime; }
        
    }
    public void ChangeSpeed(float speed)
    {
        activeMoveSpeed = speed;
        // Debug.Log(activeMoveSpeed);
    }
}
