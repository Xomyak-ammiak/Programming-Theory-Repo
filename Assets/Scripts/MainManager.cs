using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Animator transitionAnimator;

    public float maxSpeed { get; set; }
    public float maxMass { get; set; }
    public float maxDive { get; set; }

    public float speedCost { get; set; }
    public float hookCost { get; set; }
    public float lineCost { get; set; }
    public float money { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void ResetParameters()
    {
        maxSpeed = 1;
        maxMass = 1;
        maxDive = 1;
        speedCost = 1;
        hookCost = 1;
        lineCost = 1;
        money = 0;
    }

    public void StartTransitionAnimation()
    {
        transitionAnimator.SetTrigger("Start");
    }

    public void loadTest()
    {
        maxSpeed = 1;
        maxMass = 2;
        maxDive = 3;
        speedCost = 4;
        hookCost = 5;
        lineCost = 6;
        money = 0;
        Save();
        maxSpeed = 0;
        maxMass = 0;
        maxDive = 0;
        speedCost = 0;
        hookCost = 0;
        lineCost = 0;
        money = 0;
        Debug.Log("maxSpeed: " + maxSpeed + " maxMass: " + maxMass + " maxDive: " + maxDive + " speedCost: " + speedCost + " hookCost: " + hookCost + " lineCost: " + lineCost + " money: " + money);
        Load();
        Debug.Log("maxSpeed: " + maxSpeed + " maxMass: " + maxMass + " maxDive: " + maxDive + " speedCost: " + speedCost + " hookCost: " + hookCost + " lineCost: " + lineCost + " money: " + money);
    }

    [System.Serializable]
    class SaveData
    {
        public float maxSpeed, maxMass, maxDive, speedCost, hookCost, lineCost, money;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.maxSpeed = maxSpeed;
        data.maxMass = maxMass;
        data.maxDive = maxDive;
        data.speedCost = speedCost;
        data.hookCost = hookCost;
        data.lineCost = lineCost;
        data.money = money;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxSpeed = data.maxSpeed;
            maxMass = data.maxMass;
            maxDive = data.maxDive;
            speedCost = data.speedCost;
            hookCost = data.hookCost;
            lineCost = data.lineCost;
            money = data.money;
        }
        Debug.Log("maxSpeed: " + maxSpeed + " maxMass: " + maxMass + " maxDive: " + maxDive + " speedCost: " + speedCost + " hookCost: " + hookCost + " lineCost: " + lineCost + " money: " + money);
    }
}
