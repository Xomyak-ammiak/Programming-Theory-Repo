using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIHelper : MonoBehaviour
{
    public void ReturnToMenu()
    {
        StartCoroutine(LoadScene(0));
        MainManager.Instance.ResetParameters();
    }

    public void animationTest()
    {
        MainManager.Instance.StartTransitionAnimation();
    }

    IEnumerator LoadScene(int levelindex)
    {
        MainManager.Instance.StartTransitionAnimation();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelindex);
    }
}
