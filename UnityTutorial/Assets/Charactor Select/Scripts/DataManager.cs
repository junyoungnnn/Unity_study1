using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [SerializeField] int selectCount;
    

    public int SelectCount
    {
        get { return selectCount; }
        set
        {
            selectCount = value;
            Save();
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Score", SelectCount);
    }

    public void Load()
    {
        SelectCount = PlayerPrefs.GetInt("Score");
    }
}
