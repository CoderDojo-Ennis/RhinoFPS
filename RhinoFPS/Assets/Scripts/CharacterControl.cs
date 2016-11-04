﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CharacterControl : NetworkBehaviour
{
    public float SpeedMultiplier;
    public Transform LocalCamera;
    public Transform FirePos;
    Rigidbody rbody;
    public float maxVelocityChange = 10.0f;
    public float JumpForce;
    public bool Grounded;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public GameObject BulletHole;

    public float speed = 60.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    [SyncVar(hook = "OnPlayerColourChange")]
    Color randColor;
    public override void OnStartLocalPlayer()
    {
        randColor = new Color(Random.value, Random.value, Random.value);
        CmdSetColour(randColor);
        //GetComponent<MeshRenderer>().material.color = randColor;
        rbody = GetComponent<Rigidbody>();
        CursorLockManager.instance.CursorLockable = true;
        CursorLockManager.instance.LockCursor();
        gameObject.layer = 8;
        LocalCamera.gameObject.SetActive(true);
    }

    public override void OnStartClient()
    {
        OnPlayerColourChange(randColor);
    }

    void OnPlayerColourChange(Color newColour)
    {
        GetComponent<MeshRenderer>().material.color = newColour;
    }

    [Command]
    void CmdSetColour(Color setColour)
    {
        randColor = setColour;
        //GetComponent<MeshRenderer>().material.color = setColour;
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

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        float snapDistance = 1.5f;
        if (controller.isGrounded == false)
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(new Ray(transform.position, Vector3.down), out hitInfo, snapDistance))
            {
                controller.Move(hitInfo.point - (transform.position + new Vector3(0, controller.height / 2, 0)));
            }
            else
            {
            }
        }

    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            Vector3 MoveVector = new Vector3();
            if (Grounded)
            {
                MoveVector.z += SpeedMultiplier * InputController.GetVerticalMove() * Time.fixedDeltaTime;
                MoveVector.x += SpeedMultiplier * InputController.GetHorizontalMove() * Time.fixedDeltaTime;
            }
            transform.Rotate(transform.up, InputController.GetHorizontalLook());
            float CamAngle = LocalCamera.localEulerAngles.x + InputController.GetVerticalLook();
            if (CamAngle > 180)
            {
                CamAngle = Mathf.Clamp(CamAngle, 269, 370);
            }
            else
            {
                CamAngle = Mathf.Clamp(CamAngle, -10, 89);
            }
            LocalCamera.localEulerAngles = new Vector3(CamAngle, 0, 0);

            CharacterController controller = GetComponent<CharacterController>();
            //if (controller.isGrounded)
            {
                //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                MoveVector = transform.TransformDirection(MoveVector);
                MoveVector *= speed;
                if (Input.GetKeyDown(InputController.Jump))
                {
                    MoveVector.y = jumpSpeed;
                }

            }

            //MoveVector.y -= gravity * Time.deltaTime;
            controller.SimpleMove(MoveVector* Time.deltaTime);

            //MoveVector = transform.TransformDirection(MoveVector);
            //rbody.AddForce(MoveVector, ForceMode.Impulse);
            // Apply a force that attempts to reach our target velocity
            /*
            Vector3 velocity = rbody.velocity;
            Vector3 velocityChange = (MoveVector - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rbody.AddForce(velocityChange, ForceMode.VelocityChange);
              */

            /*
                // Jump
                if (Input.GetKeyDown(InputController.Jump) && Grounded)
            {
                Grounded = false;
                rbody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
                //rbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
            */

            //Shoot
            if (Input.GetKeyDown(InputController.Fire))
            {
                CmdFire(gameObject, FirePos.forward, FirePos.position);
            }
        }
    }

    [Command]
    void CmdFire(GameObject firedBy, Vector3 bRotation, Vector3 bPosition)
    {
        RaycastHit info;
        Debug.Log(bPosition + "rot" + bRotation);
        if (Physics.Raycast(new Ray(bPosition, bRotation), out info))
        {
            Debug.Log(info.transform.name);
            CharacterControl playerHit = info.transform.GetComponent<CharacterControl>();
            if (playerHit != null)
            {
                Debug.Log("Hit Player");
                //Damage the enemy
            }
            else
            {
                Debug.Log("Hit");
                //Hit something else
                GameObject hole = (GameObject)Instantiate(BulletHole, info.point,Quaternion.LookRotation(info.normal));
                NetworkServer.Spawn(hole);
            }
        }
        //GameObject b = (GameObject)Instantiate(BulletPrefab, bPosition, bRotation);
        //b.GetComponent<Rigidbody>().velocity = b.transform.forward * BulletSpeed;
        //NetworkServer.Spawn(b);
        //firedBy.GetComponent<CharacterControl>().SetBulletLayer(b);
        //Debug.Log(b.transform.position);
    }

    public void SetBulletLayer(GameObject bullet)
    {
        bullet.layer = 9;
    }
}
