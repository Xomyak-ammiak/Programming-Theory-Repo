using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHelper : MonoBehaviour
{
    public void ContinueGame()
    {
        StartCoroutine(LoadScene(1));
        MainManager.Instance.Load();
    }

    public void NewGame()
    {
        StartCoroutine(LoadScene(1));
        MainManager.Instance.ResetParameters();
    }

    IEnumerator LoadScene(int levelindex)
    {
        MainManager.Instance.StartTransitionAnimation();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelindex);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}