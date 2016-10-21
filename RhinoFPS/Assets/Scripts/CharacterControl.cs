using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CharacterControl : NetworkBehaviour
{
    public float SpeedMultiplier;
    GameObject Camera;
    Rigidbody rbody;
    public float maxVelocityChange = 10.0f;
    public float JumpForce;
    public bool Grounded;

    Color randColor;
    public override void OnStartLocalPlayer()
    {
        Camera = GetComponentInChildren<Camera>().gameObject;
        randColor = new Color(Random.value, Random.value, Random.value);
        GetComponent<MeshRenderer>().material.color = randColor;
        rbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (!isLocalPlayer)
        {
            Camera.SetActive(false);
        }
    }

    void OnCollisionStay()
    {
        if (isLocalPlayer)
        {
            Grounded = true;
        }
    }

    void OnCollisionExit()
    {
        if (isLocalPlayer)
        {
            Grounded = false;
        }
    }

    void FixedUpdate ()
    {
        if (isLocalPlayer)
        {
            Vector3 MoveVector = new Vector3();
            if (Grounded)
            {
                if (Input.GetKey(InputController.Forward))
                {
                    MoveVector.z += SpeedMultiplier;
                }
                if (Input.GetKey(InputController.Back))
                {
                    MoveVector.z -= SpeedMultiplier;
                }
                if (Input.GetKey(InputController.Left))
                {
                    MoveVector.x -= SpeedMultiplier;
                }
                if (Input.GetKey(InputController.Right))
                {
                    MoveVector.x += SpeedMultiplier;
                }
            }
            // transform.Translate(MoveVector);


            // Calculate how fast we should be moving
            //Vector3 targetVelocity;// = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            MoveVector = transform.TransformDirection(MoveVector);
            //MoveVector *= speed;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rbody.velocity;
            Vector3 velocityChange = (MoveVector - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rbody.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (Input.GetKeyDown(InputController.Jump) && Grounded)
            {
                Grounded = false;
                rbody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
                //rbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }
    }
}
