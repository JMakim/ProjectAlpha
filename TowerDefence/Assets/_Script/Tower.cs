using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject towerPrefab;
    public TowerType type;

    public enum TowerType
    {
        NONE,
        TURRET1,
        TURRET2,
        TURRET3,
        TURRET4
    }
    void Start()
    {
        //type = TowerType.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
