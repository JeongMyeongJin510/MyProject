using UnityEngine;

public class PlayerView : MonoBehaviour
{
    bool isStartMove = false;
    Vector3 moveDirection;

    private float _rayCastMaxDist = 20.0f;
    void ShotRayCast()
    {
        RaycastHit hit;

        bool isRaycasted = Physics.Raycast(this.transform.position, this.transform.forward, out hit, _rayCastMaxDist);
        if (isRaycasted)
        {
            if (hit.collider != null)
            {
                Debug.Log($"감지된 물체 : {hit.collider.gameObject.name}");
                Destroy(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("올바르지 않은 오브젝트!");
            }
        }
        else
        {
            Debug.Log("감지되지 않음!");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, this.transform.forward * _rayCastMaxDist);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShotRayCast();
        }

        if (isStartMove == false)
        {
            moveDirection = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            isStartMove = true;
            moveDirection = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            isStartMove = true;
            moveDirection = Vector3.back;

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            isStartMove = true;
            moveDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            isStartMove = true;
            moveDirection = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * -90f);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(Vector3.up * 90f);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            var rigidBody = this.gameObject.GetComponent<Rigidbody>();
            if (rigidBody != null)
            {
                rigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            }
        }

        this.gameObject.transform.Translate(moveDirection * Time.deltaTime);

    }

}
