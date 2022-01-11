using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        layerMask = LayerMask.GetMask("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = Input.mousePosition;
        Ray ray;
        Camera cam = Camera.main;
        ray = cam.ScreenPointToRay(v3);    //?

        RaycastHit hit; //?
        if (Physics.Raycast(ray, out hit, 1000, layerMask)) //?
        {
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);   //?
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}
