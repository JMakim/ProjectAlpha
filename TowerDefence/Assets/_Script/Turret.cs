using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject towerPrefab;
    public TowerType type;
    public UpgradeUI upgradeUI;
    
    [System.Serializable]
    public class UpgradeUI
    {
        public GameObject canvas;
        public GameObject upgradeBtn;
        public GameObject sellBtn;
    }

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

    public void UpgradeTurret()
    {
        Debug.Log("Upgrade Turret!");
    }
    public void SellTurret()
    {
        GameManager.Instance.turretsList.Remove(this);
        Destroy(gameObject);
    }


    public void ToggleUpgradeUI(bool isActive)
    {
        upgradeUI.canvas.SetActive(isActive);
    }
}
