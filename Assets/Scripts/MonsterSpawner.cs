using UnityEngine;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject Prefab_Monster;
    public Transform SpawnPosition_A;
    public Transform SpawnPosition_B;
    public Transform SpawnPosition_C;

    private List<GameObject> _gMonsterObjList = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            var gObj = Instantiate(Prefab_Monster);
            gObj.transform.position = SpawnPosition_B.position;
            gObj.transform.SetParent(this.gameObject.transform);

            _gMonsterObjList.Add(gObj);

        }
    }

    

}

