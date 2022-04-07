using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Animator transitionAnimator;

    private float _maxSpeed;
    public float maxSpeed
    {
        get { return _maxSpeed; }
        set
        {
            if (value < 1)
            {
                _maxSpeed = 1;
                return;
            }
            if (value > 6)
            {
                _maxSpeed = 6;
                return;
            }
            _maxSpeed = value;
        }
    }

    private float _maxMass;
    public float maxMass
    {
        get { return _maxMass; }
        set
        {
            if (value < 1)
            {
                _maxMass = 1;
                return;
            }
            if (value > 6)
            {
                _maxMass = 6;
                return;
            }
            _maxMass = value;
        }
    }

    private float _maxDive;
    public float maxDive
    {
        get { return _maxDive; }
        set
        {
            if (value < 1)
            {
                _maxDive = 1;
                return;
            }
            if (value > 6)
            {
                _maxDive = 6;
                return;
            }
            _maxDive = value;
        }
    }


    private float _speedCost;
    public float speedCost
    {
        get { return _speedCost; }
        set
        {
            if (value < 0)
            {
                _speedCost = 0;
                return;
            }
            _speedCost = value;
        }
    }

    private float _hookCost;
    public float hookCost
    {
        get { return _hookCost; }
        set
        {
            if (value < 0)
            {
                _hookCost = 0;
                return;
            }
            _hookCost = value;
        }
    }

    private float _lineCost;
    public float lineCost
    {
        get { return _lineCost; }
        set
        {
            if (value < 0)
            {
                _lineCost = 0;
                return;
            }
            _lineCost = value;
        }
    }

    private float _money;
    public float money
    {
        get { return _money; }
        set
        {
            if (value < 0)
            {
                _money = 0;
                return;
            }
            _money = value;
        }
    }

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
        money = 100;
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
