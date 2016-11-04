using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuUI : MonoBehaviour
{
    public InputField NameField;
    public Button SubmitButton;

    public void SubmitPressed()
    {
        PlayerPrefs.SetString("PlayerName", NameField.text);
        SceneManager.LoadScene("MultiplayerTest");
    }
}
