using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandToggle : MonoBehaviour
{
    Toggle m_Toggle;
    public Toggle t1;
    public bool rHand;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Toggle GameObject
        m_Toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        m_Toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_Toggle);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ToggleValueChanged(Toggle change)
    {
        t1.isOn = false;
        if (rHand)
        {
            PlayerPrefs.SetInt("Hand", 0);
        }
        if (!rHand)
        {
            PlayerPrefs.SetInt("Hand", 1);
        }
    }
}
