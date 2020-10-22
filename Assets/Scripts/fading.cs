
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private int LeveltoLoad;

    void Update()
    {
        
    }
    public void FadeToLevel (int LevelIndex)
    {
        animator.SetTrigger("FadeOut");
        LeveltoLoad = LevelIndex;
    }
    public void onFadeComplete()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
}
