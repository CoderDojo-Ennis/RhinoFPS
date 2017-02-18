using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocalCanvas : MonoBehaviour
{
    public static LocalCanvas instance;
    public Slider HealthBar;
    public GameObject Crosshair;
    public GameObject SceneCam;
    
    void Start ()
    {
        instance = this;
	}
}
