using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour

{
    public GameObject menu, story, credits;

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ShowCredits()
    {
       story.SetActive(false);
        credits.SetActive(true);
        menu.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        // Mostrar la sección de cómo jugar
        Debug.Log("Mostrar cómo jugar");
    }

    public void ShowStory()
    {
        story.SetActive(true);
        credits.SetActive(false);
        menu.SetActive(false);
    }

    public void QuitGame()
    {
        // Salir del juego (esto no funcionará en el editor de Unity)
        Application.Quit();
    }
    public void backMenu( )
    {
        story.SetActive(false);
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void backToMenu( )
    {
        SceneManager.LoadScene("Menu");
    }
}
