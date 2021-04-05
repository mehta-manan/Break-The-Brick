using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool play = false;

    public GameObject settingsUI;

    AudioSource audioS;
    public AudioClip[] audioC;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void PauseGame()
    {
        PlayAudio();
        HandleGame(0f, !play);
    }

    public void ResumeGame()
    {
        PlayAudio();
        HandleGame(1f, play);
    }

    public void RestartGame()
    {
        // ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LoadLevel(string levelScene)
    {
        Time.timeScale = 1f;

        if (levelScene == "Menu" || levelScene == "Level Selection")
            PlayAudio();

        SceneManager.LoadScene(levelScene);
    }

    private void HandleGame(float time, bool toggleUI)
    {
        Time.timeScale = time;
        settingsUI.SetActive(toggleUI);
    }

    public void Quit()
    {
        Debug.Log("Application was quit.");
        PlayAudio();
        Application.Quit();
    }

    private void PlayAudio()
    {
        int index = Random.Range(0, audioC.Length);
        audioS.clip = audioC[index];
        audioS.Play();
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        Camera.main.backgroundColor = Color.black;
    }
}
