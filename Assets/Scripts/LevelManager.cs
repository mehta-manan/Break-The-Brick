using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;
    public string[] sceneNames;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (PlayerPrefs.GetInt(sceneNames[i]) == 1)
                buttons[i].interactable = true;
        }
    }
}
