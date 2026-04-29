using UnityEngine;

public class BigDogSpawner : MonoBehaviour
{
    public GameObject Prefab_BigDog;

 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPrefab();

        }
    }

    private void SpawnPrefab()
    {
        Instantiate(Prefab_BigDog);

    }
}
