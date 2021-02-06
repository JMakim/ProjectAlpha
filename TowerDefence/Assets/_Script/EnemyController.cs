using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject wp;
    private List<Transform> wayPointsList = new List<Transform>();
    private Transform target;
    private int targetIndex;

    public float moveSpeed;
    public bool isLoop;
    public bool isDestroyOnArrive;

    // Start is called before the first frame update
    void Start()
    {
        SetWayPoints();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void SetWayPoints()
    {
        wp = GameObject.FindGameObjectWithTag("WayPoints");
        for (int i = 0; i < wp.transform.childCount; i++)
        {
            wayPointsList.Add(wp.transform.GetChild(i));
        }
        target = wayPointsList[0];
    }

    void Move()
    {
        //Debug.Log("Currently moving to: " + targetIndex);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.05f)//adjust this value when having performance issues on mobile.
        {
            if (targetIndex < wayPointsList.Count - 1)//move to the next target
            {
                targetIndex += 1;
                target = wayPointsList[targetIndex];
            }
            else if (isLoop)//last waypoint->first waypoint
            {
                targetIndex = 0;
                target = wayPointsList[targetIndex];
            }
            
            else if (isDestroyOnArrive&&targetIndex==wayPointsList.Count-1)
            {
                GameManager.Instance.healthCount -= 5;
                Destroy(gameObject);
            }
        }

    }
}
