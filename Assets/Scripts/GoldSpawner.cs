using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject Prefab_Gold;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnGold();
        }
    }

    private void SpawnGold()
    {
        Instantiate(Prefab_Gold);
    }
}
