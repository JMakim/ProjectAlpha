using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestScript : MonoBehaviour
{
    public Button questButton, xButton;
    public Canvas questCanvas;
    public TMP_Text Quest1;
    // Start is called before the first frame update
    void Start()
    {
        questCanvas.gameObject.SetActive(false);
        questButton.onClick.AddListener(TaskOnClick);
        xButton.onClick.AddListener(TaskOnClick1);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("FirstTower") == 1)
        {
            Quest1.text = "Place a Tower (1/1) - Complete";
            //give t he playerr a reward
        }
    }

    void TaskOnClick()
    {
        questCanvas.gameObject.SetActive(true);
    }

    void TaskOnClick1()
    {
        questCanvas.gameObject.SetActive(false);
    }
}
