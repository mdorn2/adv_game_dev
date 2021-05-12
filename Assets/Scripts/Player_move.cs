using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_move : MonoBehaviour
{
    public float speed = 6f;

    public float gravity = -3f;

    public float jumpHeight = 3f;

    float jumps = 1f;

    public CharacterController controller;

    public Transform groundCheck;
    public Transform ceilingCheck;
    public float groundDistance = 0.4f;
    public float ceilingDistance = 0.2f;
    public LayerMask groundMask;
    public LayerMask deathMask;
    public LayerMask enemyMask;
    public LayerMask finishMask;

    Vector3 velocity;

    bool isGrounded;
    bool hitCeiling;
    bool isDead;
    bool hitEnemy;
    bool finish;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        hitCeiling = Physics.CheckSphere(ceilingCheck.position, -ceilingDistance, groundMask);
        isDead = Physics.CheckSphere(groundCheck.position, groundDistance, deathMask);
        hitEnemy = Physics.CheckCapsule(ceilingCheck.position, groundCheck.position, 1f, enemyMask);
        finish = Physics.CheckCapsule(ceilingCheck.position, groundCheck.position, 1f, finishMask);

        if (finish)
        {
            SceneManager.LoadScene("Assets/Scenes/finish.unity");
        }
        if (hitEnemy)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
            controller.slopeLimit = 45f;
            jumps = 1f;
        }
        if (hitCeiling && velocity.y > 0f)
        {
            velocity.y = -1f;
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Sprint"))
        {
            speed = 10f;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            speed = 6f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumps = 0f;
            Debug.Log("tried to jump");
        }

        if (!isGrounded)
        {
            controller.slopeLimit = 180f;
        }
        
        Vector3 move = Vector3.Normalize(transform.right * h + transform.forward * v);

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
