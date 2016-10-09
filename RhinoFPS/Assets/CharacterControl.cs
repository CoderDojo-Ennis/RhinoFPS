using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CharacterControl : NetworkBehaviour
{
    public float SpeedMultiplier;

    Color randColor;
    public override void OnStartLocalPlayer()
    {
        randColor = new Color(Random.value, Random.value, Random.value);
        GetComponent<MeshRenderer>().material.color = randColor;
    }

    void FixedUpdate ()
    {
        if (isLocalPlayer)
        {
            Vector3 MoveVector = new Vector3();
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
            transform.Translate(MoveVector);
        }
    }
}
