using UnityEngine;

public class MonsterView : MonoBehaviour
{
    public GameObject TargetPlayer;
    [SerializeField] private Transform TargetPlayerTransform;


    private void Update()
    {
        if (TargetPlayer == null)
        {
            return;
        }

        this.transform.LookAt(TargetPlayer.transform);

    }

}
