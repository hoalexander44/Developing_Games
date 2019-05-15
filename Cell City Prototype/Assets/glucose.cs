using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glucose : MonoBehaviour {
    public float moveSpeed = 15;

    float maxX = 60.1f;
    float minX = -60.1f;
    float maxY = 40.2f;
    float minY = -40.2f;

    Vector3 targetPosition;

    bool shouldMove = false;

    //   private float tChange = 0; // force new direction in the first Update
    private float randomX;
    private float randomY;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);

            //Check if Glucose has arrived at targetPosition
            if (transform.position == targetPosition)
            {
                shouldMove = false;
            }
        }
    }

    public void moveTo()
    {
        shouldMove = true;
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);

        float targetX = transform.position.x + randomX;
        float targetY = transform.position.y + randomY;

        targetPosition = new Vector3(targetX, targetY, 0);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);
    }
}
