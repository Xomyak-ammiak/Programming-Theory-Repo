using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public GameObject transition;
    public Animator transitionAnimator;

    public float maxSpeed, maxMass, maxDive, speedCost, hookCost, lineCost;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(transition);
    }

    public void ResetParameters()
    {
        maxSpeed = 1;
        maxMass = 1;
        maxDive = 1;
        speedCost = 1;
        hookCost = 1;
        lineCost = 1;
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
        Save();
        maxSpeed = 0;
        maxMass = 0;
        maxDive = 0;
        speedCost = 0;
        hookCost = 0;
        lineCost = 0;
        Debug.Log("maxSpeed: " + maxSpeed + " maxMass: " + maxMass + " maxDive: " + maxDive + " speedCost: " + speedCost + " hookCost: " + hookCost + " lineCost: " + lineCost);
        Load();
        Debug.Log("maxSpeed: " + maxSpeed + " maxMass: " + maxMass + " maxDive: " + maxDive + " speedCost: " + speedCost + " hookCost: " + hookCost + " lineCost: " + lineCost);
    }

    [System.Serializable]
    class SaveData
    {
        public float maxSpeed, maxMass, maxDive, speedCost, hookCost, lineCost;
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
        }
        Debug.Log("maxSpeed: " + maxSpeed + " maxMass: " + maxMass + " maxDive: " + maxDive + " speedCost: " + speedCost + " hookCost: " + hookCost + " lineCost: " + lineCost);
    }
}
