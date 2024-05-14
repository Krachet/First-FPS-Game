using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public GameObject wallParent;
    public GameObject[] wallTypes;
    public int numberOfWalls;
    public Transform[] startPos;
    private float offset = 6;

    private void Start()
    {
        SpawnLeft(startPos[0]);
        SpawnDown(startPos[1]);
        SpawnRight(startPos[2]);
        SpawnUp(startPos[3]);
        SpawnLeft(startPos[4]);
    }

    private void SpawnWall()
    {

    }

    private void SpawnLeft(Transform startingPos)
    {
        for (int i = 0; i < numberOfWalls/2; i++)
        {
            GameObject wall = Instantiate(wallTypes[Random.Range(0, wallTypes.Length)], startingPos.position, Quaternion.Euler(0, 90, 0));
            wall.transform.SetParent(wallParent.transform);
            wall.transform.localScale = new Vector3(3, 3, 1);
            wall.transform.position += new Vector3(0, 0, offset) * i;
        }
    }

    private void SpawnDown(Transform startingPos)
    {
        for (int i = 0; i < numberOfWalls; i++)
        {
            GameObject wall = Instantiate(wallTypes[Random.Range(0, wallTypes.Length)], startingPos.position, Quaternion.Euler(0, 0, 0));
            wall.transform.SetParent(wallParent.transform);
            wall.transform.localScale = new Vector3(3, 3, 1);
            wall.transform.position += new Vector3(offset, 0, 0) * i;
        }
    }

    private void SpawnRight(Transform startingPos)
    {
        for (int i = 0; i < numberOfWalls; i++)
        {
            GameObject wall = Instantiate(wallTypes[Random.Range(0, wallTypes.Length)], startingPos.position, Quaternion.Euler(0, -90, 0));
            wall.transform.SetParent(wallParent.transform);
            wall.transform.localScale = new Vector3(3, 3, 1);
            wall.transform.position += new Vector3(0, 0, -offset) * i;
        }
    }

    private void SpawnUp(Transform startingPos)
    {
        for (int i = 0; i < numberOfWalls; i++)
        {
            GameObject wall = Instantiate(wallTypes[Random.Range(0, wallTypes.Length)], startingPos.position, Quaternion.Euler(0, 0, 0));
            wall.transform.SetParent(wallParent.transform);
            wall.transform.localScale = new Vector3(3, 3, 1);
            wall.transform.position += new Vector3(-offset * i, 0, -6);
        }
    }
}
