using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    /// <summary>
    /// When exit it will set how long it takes and the slow mo effect time
    /// </summary>
    [SerializeField] float LvlLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMo = 0.2f;
    public Animator animator;

    /// <summary>
    ///  On collision to the exit, it will trigger to next level
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }


    /// <summary>
    /// Next level transition slowly
    /// </summary>
    /// <returns></returns>
    public IEnumerator LoadNextLevel()
    {
        animator.SetTrigger("FadeOut");
        Time.timeScale = LevelExitSlowMo;
        yield return new WaitForSecondsRealtime(LvlLoadDelay);
        Time.timeScale = 1f;


        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // when next scene is winnning screen it will destroy layout we have
        if (currentSceneIndex + 1 == 6)
            Destroy(GameObject.FindWithTag("GameSesh"));

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
