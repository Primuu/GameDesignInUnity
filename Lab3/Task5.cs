using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubesToGenerate = 10;
    private List<Vector3> usedPositions = new List<Vector3>();
// Script assumes that the plan is 10x10 and the cube is 1x1
    private float planeHalfLength = 50.0f;
    private float planeHalfWidth = 50.0f;
    private float cubeHalfSize = 0.5f;

    void Start()
    {
        for (int i = 0; i < numberOfCubesToGenerate; i++)
        {
            GenerateCube();
        }
    }

    void GenerateCube()
    {
        Vector3 randomPosition;
        do
        {
            randomPosition = new Vector3(
                Random.Range(-planeHalfLength + cubeHalfSize, planeHalfLength - cubeHalfSize),
                cubeHalfSize,
                Random.Range(-planeHalfWidth + cubeHalfSize, planeHalfWidth - cubeHalfSize)
            );
        }
        while (IsPositionUsed(randomPosition));

        usedPositions.Add(randomPosition);
        Instantiate(cubePrefab, randomPosition, Quaternion.identity);
    }

    bool IsPositionUsed(Vector3 position)
    {
        foreach(Vector3 usedPosition in usedPositions)
        {
            if (Vector3.Distance(position, usedPosition) < cubeHalfSize * 2)
            {
                return true;
            }
        }
        return false;
    }

}
