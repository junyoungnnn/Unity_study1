using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorSelectManager : MonoBehaviour
{
    [SerializeField] int selectCount;
    [SerializeField] List<GameObject> charactorList;

    private void Start()
    {
        charactorList.Capacity = 5;
        Show();
    }
    private void Show()
    {
        for (int i = 0; i < charactorList.Count; i++)
        {
            charactorList[i].SetActive(false);
        }

        charactorList[selectCount].SetActive(true);
    }

    void Update()
    {
        
    }

    public void Left()
    {

    }

    public void Right()
    {

    }

    
}
