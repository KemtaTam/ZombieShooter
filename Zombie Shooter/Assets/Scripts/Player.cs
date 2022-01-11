using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float moveSpeed;
    Aim aim;
    Shot shot;
    public Transform gunBarrel;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        aim = FindObjectOfType<Aim>();
        navMeshAgent.updateRotation = false;
        shot = FindObjectOfType<Shot>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) dir.z = -1f;
        if (Input.GetKey(KeyCode.S)) dir.z = 1f;
        if (Input.GetKey(KeyCode.A)) dir.x = 1f;
        if (Input.GetKey(KeyCode.D)) dir.x = -1f;
        navMeshAgent.velocity = dir.normalized * moveSpeed; //?

        Vector3 forward = aim.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));

        if (Input.GetMouseButtonDown(0))
        {
            var from = gunBarrel.position;
            var target = aim.transform.position;
            var to = new Vector3(target.x, from.y, target.z);

            var direction = (to - from).normalized;
            RaycastHit hit;
            if (Physics.Raycast(from, to - from, out hit, 100)) to = new Vector3(hit.point.x, from.y, hit.point.z);
            else to = from + direction * 100;

            if (hit.transform != null)
            {
                var zombie = hit.transform.GetComponent<Zombie>();
                if (zombie != null) zombie.Kill();
            }

            shot.Show(from, to);
        }
    }
}
 