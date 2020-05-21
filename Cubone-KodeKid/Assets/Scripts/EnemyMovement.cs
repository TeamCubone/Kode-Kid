using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// Moving speed of enemy
    /// </summary>
    [SerializeField] float moveSpeed = 2f;

    /// <summary>
    /// giving the rigid body to the enemy so they have gravity effect
    /// </summary>
    Rigidbody2D myRigidBody;
    // Start is called before the first frame update

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (FacesRight())
        {
            //moves right
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            //moves left
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    // if scale faces right, its positive. If lower than zero, will go to else statement in the update()
    bool FacesRight()
    {
        return transform.localScale.x > 0;
    }

    // the velocity of the enemy is +1 for right -1 for left. To flip, if triggered, the method will switch and go minus 1 or plus 1
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }


}
