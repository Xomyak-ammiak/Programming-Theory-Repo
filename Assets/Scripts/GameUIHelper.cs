using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIHelper : MonoBehaviour
{
    public GameObject shopCanvas;

    public void ReturnToMenu()
    {
        StartCoroutine(LoadScene(0));
        MainManager.Instance.ResetParameters();
    }

    IEnumerator LoadScene(int levelindex)
    {
        MainManager.Instance.StartTransitionAnimation();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelindex);
    }

    public void OpenShop()
    {
        if(shopCanvas.activeSelf == true)
        {
            shopCanvas.SetActive(false);
            return;
        }
        shopCanvas.SetActive(true);
    }

    public void CloseShop()
    {
        shopCanvas.SetActive(false);
    }

    public void UpdateSpeed()
    {
        Debug.Log(1);
        if (MainManager.Instance.money >= MainManager.Instance.speedCost)
        {
            MainManager.Instance.maxSpeed++;
            MainManager.Instance.money -= MainManager.Instance.speedCost;
            MainManager.Instance.speedCost *= 1.2f;
        }
    }

    public void UpdateMass()
    {
        Debug.Log(1);
        if (MainManager.Instance.money >= MainManager.Instance.hookCost)
        {
            MainManager.Instance.maxMass++;
            MainManager.Instance.money -= MainManager.Instance.hookCost;
            MainManager.Instance.hookCost *= 1.2f;
        }
    }

    public void UpdateDive()
    {
        Debug.Log(1);
        if (MainManager.Instance.money >= MainManager.Instance.lineCost)
        {
            MainManager.Instance.maxDive++;
            MainManager.Instance.money -= MainManager.Instance.lineCost;
            MainManager.Instance.lineCost *= 1.2f;
        }
    }
}
