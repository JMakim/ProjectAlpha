using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public bool isZoomed = false;
    public Camera[] cameraList;

    private Vector3 zoomSpeed;
    private Vector3 camOriginPos;
    private Quaternion camOriginRot;
    private Vector3 culculatedPos;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 /*|| Input.GetMouseButtonDown(0)*/)
        {
            Touch myTouch = Input.GetTouch(Input.touchCount - 1);//save last touch infomation      //<------ changed this for mouse
            if (myTouch.phase == TouchPhase.Began)//if user continues the touch                    //<------ changed this for mouse
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 1000,1<<0))//only cast on default gameobjects
                {
                    //Debug.Log("cast on other");
                    switch (hitInfo.transform.tag)
                    {
                        case "TowerPlatform":
                            hitInfo.transform.GetComponent<TowerPlatform>().SpawnTurret();
                            break;
                        case "ResourceDrop":
                            GameManager.Instance.resourceCount += 50;
                            Destroy(hitInfo.transform.gameObject);
                            break;
                        case "Turret":
                            if (!isZoomed)
                            {
                                hitInfo.transform.GetComponent<Turret>().ToggleUpgradeUI(true);
                                camOriginPos = Camera.main.transform.position;
                                camOriginRot = Camera.main.transform.rotation;
                                Vector3 dir = hitInfo.transform.position - Camera.main.transform.position;
                                culculatedPos = hitInfo.transform.position - dir.normalized * 10;
                                foreach (Camera cam in cameraList)
                                {
                                    cam.transform.LookAt(culculatedPos);
                                }
                                isZoomed = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if(Physics.Raycast(ray, out hitInfo,1000,1<<LayerMask.NameToLayer("TurretUI")))
                {
                    //Debug.Log("cast on TurretUI");
                    foreach (Turret turret in GameManager.Instance.turretsList)
                    {
                        if (turret.upgradeUI.canvas.activeSelf && turret.upgradeUI.canvas != hitInfo.transform.gameObject)
                        {
                            turret.ToggleUpgradeUI(false);
                        }
                    }
                }
                else
                {
                    foreach (Turret turret in GameManager.Instance.turretsList)//if ray does not cast on turretUI, close the upgrade ui
                    {
                        if (turret.upgradeUI.canvas.activeSelf)
                        {
                            turret.ToggleUpgradeUI(false);
                            if (isZoomed)
                            {
                                foreach (Camera cam in cameraList)
                                {
                                    cam.transform.position = camOriginPos;
                                    cam.transform.rotation = camOriginRot;
                                }
                                isZoomed = false;
                            }
                        }
                    }
                }
            }
        }
        if (isZoomed)
        {
            foreach (Camera cam in cameraList)
            {
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, culculatedPos, ref zoomSpeed, 0.2f);
            }
        }
    }


}
