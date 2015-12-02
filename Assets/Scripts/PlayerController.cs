using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Controller2D))]
public class PlayerController : MonoBehaviour
{

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float decelerationTime = 0.03f;
    float moveSpeedWalk = 6;
    float moveSpeedRun = 10;
    float targetVelocityX;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    public float wallSlideSpeedMaxDown = 6;
    float timeToWallUnstick;
    bool wallSliding;

    public static Vector2 checkpointLocation;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    public Vector3 velocity;
    float velocityXSmoothing;

    private Animator animator;

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        animator = GetComponent<Animator>();

        checkpointLocation = transform.position;

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            die();
        }


        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        int wallDirX = (controller.collisions.left) ? -1 : 1;
        animator.SetBool("grounded", controller.collisions.below);
        bool running = Input.GetKey(KeyCode.LeftShift) || Input.GetAxisRaw("Run") > 0.01;
        targetVelocityX = input.x * (running ? moveSpeedRun : moveSpeedWalk);
        if(running)
        {
            animator.SetFloat("walkAnimationSpeedMultiplier", moveSpeedRun/moveSpeedWalk);
        }
        else
        {
            animator.SetFloat("walkAnimationSpeedMultiplier", 1f);
        }

        float transitionTime;
        if (Math.Abs(targetVelocityX) > 0)
        {
            // Décélération progressive en cas de changement de direction
            transitionTime = (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne;
            animator.SetBool("right", Math.Sign(targetVelocityX) == 1);
        }
        else
        {
            // Décélération brusque en cas d'arrêt
            transitionTime = decelerationTime;
        }
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, transitionTime);

        // Wall sticking pour faire des wall leap
        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax && input.y >= -0.25)
            {
                velocity.y = -wallSlideSpeedMax;
            }
            else if (input.y < -0.25)
            {
                velocity.y = -wallSlideSpeedMaxDown;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (input.x != wallDirX && input.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }

        }

        // Gestion des sauts
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (wallSliding)
            {
                if (wallDirX == Math.Sign(input.x))
                {
                    velocity.x = -wallDirX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                else if (input.x == 0)
                {
                    velocity.x = -wallDirX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else
                {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;

                }
            }
            if (controller.collisions.below)
            {
                velocity.y = maxJumpVelocity;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            if (velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;
            }
        }


        velocity.y += gravity * Time.deltaTime;
        animator.SetFloat("velocityX", targetVelocityX);
        controller.Move(velocity * Time.deltaTime, input);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }


    }

    public void die()
    {
        Vector2 positionExplosion = transform.position;

        GameObject explosion = Instantiate(GameObject.FindWithTag("Explosion"), positionExplosion, transform.rotation) as GameObject;
        explosion.GetComponent<AudioSource>().enabled = true;
        Destroy(explosion, 1.6f);
        transform.position = checkpointLocation;
        velocity = new Vector2(0f , 0f);
    }


}