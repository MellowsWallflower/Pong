using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    // Homework task 2: use loops to spawn grenades in a border pattern (see blackboard task 2 image, 1%)
    public GameObject grenade;
    public Vector3 spawnPosition;
    void Start()
    {
        //TestWhileLoop();
        //TestForLoop();
        SpawnGrenades(420);
    }
    
    void SpawnGrenades(int grenadeCount)
    {
        float xMin, xMax, zMin, zMax;
        xMin = zMin = -10.0f;
        xMax = zMax = 10.0f;

        // Spawn grenades along the top border
        for (float x = xMin; x <= xMax; x += 1.0f)
        {
            SpawnGrenade(new Vector3(x, 0.0f, zMax));
        }

        // Spawn grenades along the bottom border
        for (float x = xMin; x <= xMax; x += 1.0f)
        {
            SpawnGrenade(new Vector3(x, 0.0f, zMin));
        }

        // Spawn grenades along the left border
        for (float z = zMin + 1.0f; z <= zMax - 1.0f; z += 1.0f)
        {
            SpawnGrenade(new Vector3(xMin, 0.0f, z));
        }

        // Spawn grenades along the right border
        for (float z = zMin + 1.0f; z <= zMax - 1.0f; z += 1.0f)
        {
            SpawnGrenade(new Vector3(xMax, 0.0f, z));
        }
    }

    void SpawnGrenade(Vector3 position)
    {
        GameObject clone = Instantiate(grenade, spawnPosition + position, Quaternion.identity);
        Destroy(clone, 5.0f);
    }
}
