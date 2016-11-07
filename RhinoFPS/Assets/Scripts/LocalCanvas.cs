using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocalCanvas : MonoBehaviour
{
    public static LocalCanvas instance;
    public Slider HealthBar;
	void Start ()
    {
        instance = this;
	}
}
