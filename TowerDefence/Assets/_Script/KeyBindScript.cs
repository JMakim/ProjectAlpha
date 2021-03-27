using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyBindScript : MonoBehaviour
{
    public InputField pauseBind;
    // Start is called before the first frame update
    void Start()
    {

        pauseBind.text = "p";
        PlayerPrefs.SetString("PauseBind", pauseBind.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBind()
    {
        PlayerPrefs.SetString("PauseBind", pauseBind.text);
    }
    
}
