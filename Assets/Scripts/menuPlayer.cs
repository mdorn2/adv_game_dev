using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPlayer : MonoBehaviour
{
    public float speed = 6f;

    public float runSpeed = 10f;

    public float gravity = -3f;

    public float jumpHeight = 3f;

    public float padJumpHeight = 10f;

    public float slideFriction = 0.3f;

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
    public LayerMask jumpMask;

    Vector3 velocity;

    bool isGrounded;
    bool hitCeiling;
    bool isDead;
    bool hitEnemy;
    bool finish;
    bool isJump;

    float h;
    float v;
    float ha;
    float va;
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

        if(isGrounded){
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            va = 0f;
            ha = 0f;
            Vector3 move = Vector3.Normalize(transform.right * h + transform.forward * v);
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumps = 0f;
        }

        if (!isGrounded)
        {
            ha = Input.GetAxis("Horizontal");
            va = Input.GetAxis("Vertical");
            controller.slopeLimit = 180f;
            Vector3 movea = Vector3.Normalize(transform.right * ha + transform.forward * va);
            controller.Move(movea * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Cancel")){
            SceneManager.LoadScene("LevelSelect");
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}

