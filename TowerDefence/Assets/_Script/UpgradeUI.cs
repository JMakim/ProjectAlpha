using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject Turret;
    public GameObject ui;

    public void SetTarget()
    {
        transform.position = Turret.transform.position;
    }

    
}
