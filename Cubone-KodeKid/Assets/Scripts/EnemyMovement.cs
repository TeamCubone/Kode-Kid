using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

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

    bool FacesRight()
    {
        // if scale faces right, its positive. If lower than zero, will go to else statement in the update()
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // the velocity of the enemy is +1 for right -1 for left. To flip, if triggered, the method will switch and go minus 1 or plus 1
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }


}
