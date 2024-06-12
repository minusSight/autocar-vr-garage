using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    const int SCENE_MENU = 0;
    const int SCENE_GAME = 1;
    const int SCENE_POLY = 2;

    public GameObject ingame, settings;

    public bool toggleSound, toggleMusic;
    public Text music, sound;

    public void PlayGame()
    {
        StartCoroutine(LoadYourAsyncScene(SCENE_GAME));
    }

    IEnumerator LoadYourAsyncScene(int sceneindex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneindex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void GoToPolygon()
    {
        StartCoroutine(LoadYourAsyncScene(SCENE_POLY));
    }

    public void GoToMenu()
    {
        StartCoroutine(LoadYourAsyncScene(SCENE_MENU));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowSettings()
    {
        settings.SetActive(true);
        ingame.SetActive(false);
    }
    public void ShowMenu()
    {
        settings.SetActive(false);
        ingame.SetActive(true);
    }

    public void ToggleSound()
    {
        toggleSound= !toggleSound;
        sound.text = $"«‚ÛÍ " + (toggleSound ? "¬ À" : "¬€ À");
    }

    public void ToggleMusic()
    {
        toggleMusic = !toggleMusic;
        music.text = $"ÃÛÁ˚Í‡ " + (toggleMusic ? "¬ À" : "¬€ À");
    }
}
