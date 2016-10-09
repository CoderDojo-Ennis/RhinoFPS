using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
	void Update ()
    {
        Vector3 MoveVector = new Vector3();
        if (Input.GetKey(InputController.Forward))
        {

        }
        GetComponent<CharacterController>().SimpleMove(MoveVector);
    }
}
