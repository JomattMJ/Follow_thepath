using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    // Adding array for the waypoints
    [SerializeField] Transform[] points;
    // Object moving speed
    [SerializeField]private float moveSpeed;

    //Get the array value using indexnumber
    private int indexNumber;
    // Start is called before the first frame update
    void Start()
    {
        //first assinging the player to the first waypoint.
        transform.position = points[indexNumber].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this condition is to compare the array size whether it is less or equal the index number.
        if(indexNumber <= points.Length - 1)
        {
            //assinging transform array position to target position.And calling Vector3 move towards function assinging to player.
            Vector3 targetPosition = points[indexNumber].position;
            transform.position = Vector3.MoveTowards(transform.position, points[indexNumber].transform.position, moveSpeed * Time.deltaTime);
            //Object Look towards the moving direction
            transform.LookAt(targetPosition);
            //Increment the index number
            if (transform.position == points[indexNumber].transform.position )
            {
                indexNumber++;
            }
            //For continue follow the path.
            if (indexNumber == points.Length)
            {
                indexNumber = 0;
            }
        }
        
    }
    //To draw the waypoint
    private void OnDrawGizmos()
    {
        if (points != null && points.Length > 1)
        {
            for (int i = 0; i < points.Length - 1; i++)
            {
                Gizmos.DrawLine(points[i].position, points[i + 1].position);
            }
        }
    }
}
