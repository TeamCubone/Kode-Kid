using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] float LvlLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMo = 0.2f;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }


    public IEnumerator LoadNextLevel()
    {
        animator.SetTrigger("FadeOut");
        Time.timeScale = LevelExitSlowMo;
        yield return new WaitForSecondsRealtime(LvlLoadDelay);
        Time.timeScale = 1f;


        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex + 1 == 6)
            Destroy(GameObject.FindWithTag("GameSesh"));

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
