using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockMover : MonoBehaviour
{
    public Transform leftBoundary;
    public Transform rightBoundary;
    public Rigidbody blockRB;

    float moveSpeed;

    bool isMovingRight;


    // Start is called before the first frame update
    void Start()
    {
        leftBoundary = GameObject.Find("LeftBoundary").transform;
        rightBoundary = GameObject.Find("RightBoundary").transform;
        moveSpeed = GameObject.Find("Block Spawner").GetComponent<BlockSpawner>().currentSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)
        {
            MoveBlockRight();
        }
        else
        {
            MoveBlockLeft();    
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            blockRB.useGravity = true;
            moveSpeed = 0;

            // Find spawner, call spawn function
            GameObject spawner = GameObject.Find("Block Spawner");
            BlockSpawner spawnerScript = spawner.GetComponent<BlockSpawner>();
            spawnerScript.SpawnBlock();

            Destroy(this);
        }
    }


    void MoveBlockRight ()
    {
        // move block right
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // If we're too far to the right, turn around
        if (transform.position.x > rightBoundary.position.x)
        {
            isMovingRight = false;
        }
    }


    void MoveBlockLeft ()
    {
        // move block left
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // If we're too far to the left, turn around
        if (transform.position.x < leftBoundary.position.x)
        {
            isMovingRight = true;
        }
    }
}
