using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCameraTheme : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        string theme = PlayerPrefs.GetString("theme");
        Theme(theme);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
    }

    public void Theme(string themeColour)
    {
        if (themeColour == "Blue")
        {
            mainCamera.backgroundColor = Color.blue;
            PlayerPrefs.SetString("theme", "Blue");
        }

        else if (themeColour == "Red")
        {
            mainCamera.backgroundColor = Color.red;
            PlayerPrefs.SetString("theme", "Red");
        }

        else if (themeColour == "Green")
        {
            mainCamera.backgroundColor = Color.green;
            PlayerPrefs.SetString("theme", "Green");
        }

        else if (themeColour == "Yellow")
        {
            mainCamera.backgroundColor = Color.yellow;
            PlayerPrefs.SetString("theme", "Yellow");
        }

        else if (themeColour == "Black")
        {
            mainCamera.backgroundColor = Color.black;
            PlayerPrefs.SetString("theme", "Black");
        }
    }
}
