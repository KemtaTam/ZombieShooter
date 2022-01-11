using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float camPositionSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        offset.x = 1;
        offset.y = 11f;
        offset.z = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCamPosition = new Vector3(playerTransform.position.x + offset.x, offset.y, playerTransform.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, newCamPosition, camPositionSpeed * Time.deltaTime);
    }
}
