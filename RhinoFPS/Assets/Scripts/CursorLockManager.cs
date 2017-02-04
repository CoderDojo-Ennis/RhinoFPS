using UnityEngine;
using System.Collections;

public class CursorLockManager : MonoBehaviour
{
    public static CursorLockManager instance;
    public bool CursorLockable = false;

	void Start ()
    {
        instance = this;
        UnlockCursor();
	}
	
	void Update ()
    {
        /*
        if (Input.GetKeyDown(InputController.Pause))
        {
            UnlockCursor();
        }

        if (Input.GetKeyDown(InputController.Fire))
        {
            LockCursor();
        }
        */
        if (Input.GetKeyDown(InputController.Scoreboard))
        {
            UnlockCursor();
        }
        if (Input.GetKeyUp(InputController.Scoreboard))
        {
            LockCursor();
        }
    }

    public void LockCursor()
    {
        if (CursorLockable)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
