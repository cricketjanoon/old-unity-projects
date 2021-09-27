using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 5;
    public float spawnDelay=0.5f;

    private bool movingRight = false;
    private float xMax, xMin;


    // Use this for initialization
    void Start() {

        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));

        xMin = leftEdge.x + 5;
        xMax = rightEdge.x - 5;

        SpawnUntilFull();
    }



    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
            enemy.transform.parent = freePosition;
        }
        if(NextFreePosition())
            Invoke("SpawnUntilFull", spawnDelay);
    }

    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child;
        }

    }



    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void Update() {

        if (movingRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        float leftEdgeOfFormation = transform.position.x + (0.5f * width);
        float rightEdgeOfFormation = transform.position.x - (0.5f * width);
        if (leftEdgeOfFormation < xMin)
        {
            movingRight = true;
        }
        else if (rightEdgeOfFormation > xMax)
        {
            movingRight = false;
        }

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }


    }

    Transform NextFreePosition()
    {
        foreach (Transform childPosition in transform)
        {
            if (childPosition.childCount == 0)
                return childPosition;
        }
            return null;
    }

    bool AllMembersDead()
    {
        foreach (Transform childPosition in transform)
        {
            if (childPosition.childCount > 0)
                return false;
        }

        return true;
    }
}
