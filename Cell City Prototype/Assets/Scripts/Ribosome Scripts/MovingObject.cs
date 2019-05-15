using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{

    public float movetime = 1f;
    //public LayerMask blockinglayer;

    //private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private float inverseMoveTime;

	protected virtual void Start ()
    {
        //boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / movetime;
	}

    protected IEnumerator SmoothMovement (Vector2 end)
    {
        float sqrRemainingDistance = ((Vector2)transform.position - end).sqrMagnitude;

        while(sqrRemainingDistance > float.Epsilon)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = ((Vector2)transform.position - end).sqrMagnitude;
            yield return null;
        }
    }
}
