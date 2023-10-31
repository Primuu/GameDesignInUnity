using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    public float delay = 3.0f;
    public GameObject block;
    // Modifications
    public int objectsToGenerate = 10;
    public List<Material> materials = new List<Material>();
    private List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        // Modifications
        Bounds bounds = GetComponent<Renderer>().bounds;
        float blockHeight = block.transform.localScale.y;

        // Modifications
        for(int i=0; i<objectsToGenerate; i++)
        {
            float randomX = Random.Range(-bounds.extents.x, bounds.extents.x);
            float randomZ = Random.Range(-bounds.extents.z, bounds.extents.z);
            float posY = bounds.max.y + blockHeight / 2;

            Vector3 randomPosition = new Vector3(randomX, posY, randomZ) + bounds.center;
            randomPosition.y = posY;
            positions.Add(randomPosition);
        }
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects()
    {
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            Renderer blockRenderer = newBlock.GetComponent<Renderer>();
            blockRenderer.material = materials[Random.Range(0, materials.Count)];

            yield return new WaitForSeconds(this.delay);
        }
        StopCoroutine(GenerateObjects());
    }
}
