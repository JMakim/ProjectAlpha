using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject UpgradeUIPrefab;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 10000) && hitInfo.collider.gameObject.tag == "Turret")
            {
               

                    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        UpgradeUIPrefab.GetComponent<UpgradeUI>().ui.SetActive(true);
                    }
   
            }


            else
            {
                UpgradeUIPrefab.GetComponent<UpgradeUI>().ui.SetActive(false);
            }
        }
        






    }


}
