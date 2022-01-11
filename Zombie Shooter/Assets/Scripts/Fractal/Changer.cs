using UnityEngine;
using System.Collections;

public class Changer : MonoBehaviour
{
    public float angle = 30;
    public float scalar = 0.5f;
    public void Generated(RecursiveBundle bundle)
    {
        this.transform.position += this.transform.up * this.transform.localScale.y;
        this.transform.rotation *= Quaternion.Euler(angle * ((bundle.Index *2)-1), 90, 0);
        this.transform.localScale *= scalar;
    }
}