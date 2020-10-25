using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Animator animator;
    private int LeveltoLoad;
    void Start()
    {
    }
    void Update()
    {
        
    }
    public void FadeToLevel (int LevelIndex)
    {
        animator.SetTrigger("fadeOut");
        LeveltoLoad = LevelIndex;
    }
    public void onFadeComplete()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        FadeToLevel(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
        FadeToLevel(2);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
        FadeToLevel(0);
    }
}
