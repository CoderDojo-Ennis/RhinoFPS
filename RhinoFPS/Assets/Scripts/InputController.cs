using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public static KeyCode Forward = KeyCode.W;
    public static KeyCode Back = KeyCode.S;
    public static KeyCode Left = KeyCode.A;
    public static KeyCode Right = KeyCode.D;
    public static KeyCode Jump = KeyCode.Space;
    public static KeyCode Fire = KeyCode.Mouse0;
    public static KeyCode Pause = KeyCode.Escape;
    public static KeyCode Reload = KeyCode.R;
    public static KeyCode Scoreboard = KeyCode.Tab;

    public static float MouseSensitivity = 10f;

    public static float GetHorizontalMove()
    {
        float h = 0;
        if (Input.GetKey(Left))
        {
            h-=1;
        }
        if (Input.GetKey(Right))
        {
            h+=1;
        }
        return h;
    }

    public static float GetVerticalMove()
    {
        float v = 0;
        if (Input.GetKey(Back))
        {
            v -= 1;
        }
        if (Input.GetKey(Forward))
        {
            v += 1;
        }
        return v;
    }

    public static float GetVerticalLook()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            return -Input.GetAxisRaw("Mouse Y") * MouseSensitivity;
        }
        return 0;
    }

    public static float GetHorizontalLook()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            return Input.GetAxisRaw("Mouse X") * MouseSensitivity;
        }
        return 0;
    }
}
