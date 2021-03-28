using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Canvas uiLeft, uiRight;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Hand") == 0)
        {
            uiLeft.gameObject.SetActive(false);
        }
        else
        {
            uiRight.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
