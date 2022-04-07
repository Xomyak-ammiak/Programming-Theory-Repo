using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIHelper : MonoBehaviour
{
    public GameObject shopCanvas;
    public Text upHookText, upLineText, upSpeedText;
    public Text speedCost, hookCost, lineCost;

    private void Awake()
    {
        speedCost.text = "" + MainManager.Instance.speedCost;
        hookCost.text = "" + MainManager.Instance.hookCost;
        lineCost.text = "" + MainManager.Instance.lineCost;
    }

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
        if (MainManager.Instance.maxSpeed == 6)
        {
            upSpeedText.text = "LVL max";
            speedCost.text = "";
            return;
        }

        Debug.Log("UpdateSpeed");
        if (MainManager.Instance.money >= MainManager.Instance.speedCost)
        {
            MainManager.Instance.maxSpeed++;
            MainManager.Instance.money -= MainManager.Instance.speedCost;
            MainManager.Instance.speedCost *= 1.2f;

            upSpeedText.text = "LVL " + MainManager.Instance.maxSpeed;
            speedCost.text = "" + MainManager.Instance.speedCost;
        }
    }

    public void UpdateMass()
    {
        if(MainManager.Instance.maxMass == 6)
        {
            upHookText.text = "LVL max";
            hookCost.text = "";
            return;
        }

        Debug.Log("UpdateMass");
        if (MainManager.Instance.money >= MainManager.Instance.hookCost)
        {
            MainManager.Instance.maxMass++;
            MainManager.Instance.money -= MainManager.Instance.hookCost;
            MainManager.Instance.hookCost *= 1.2f;

            upHookText.text = "LVL " + MainManager.Instance.maxMass;
            hookCost.text = "" + MainManager.Instance.hookCost;
        }
    }

    public void UpdateDive()
    {
        if (MainManager.Instance.maxDive == 6)
        {
            upLineText.text = "LVL max";
            lineCost.text = "";
            return;
        }

        Debug.Log("UpdateDive");
        if (MainManager.Instance.money >= MainManager.Instance.lineCost)
        {
            MainManager.Instance.maxDive++;
            MainManager.Instance.money -= MainManager.Instance.lineCost;
            MainManager.Instance.lineCost *= 1.2f;

            upLineText.text = "LVL " + MainManager.Instance.maxDive;
            lineCost.text = "" + MainManager.Instance.lineCost;
        }
    }
}
