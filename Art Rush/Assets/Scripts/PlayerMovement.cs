using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeReference]
    private CharacterController controller;

    [SerializeField]
    private float normalSpeed = 15.0f;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Dash
    private float activeMoveSpeed;
    [SerializeField]
    private float dashSpeed = 30.0f;
    [SerializeField]
    private float dashLength = 0.5f;
    [SerializeField]
    private float dashCooldown = 1f;

    private float dashCounter;
    private float dashCooldownCounter;

    // Interactions
    public SpawnItems touching;

    private void Start()
    {
        activeMoveSpeed = normalSpeed;    
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

        if (Input.GetKeyDown(KeyCode.E) && touching.tag == "Item Spawner")
        {
            Debug.Log("Item Spawner");
            // touching.SpawnProp();
        }

        if (Input.GetKeyDown(KeyCode.E) && touching.tag == "Counter")
        {
            Debug.Log("Counter");
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //Escape key to open Main Menu
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
