using UnityEngine;
using System.Collections;

public class DetatchAndHinge : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public HingeJoint hinge;

    public void Generated(RecursiveBundle bundle)
    {
        var parentBody = bundle.Parent.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        hinge.connectedBody = parentBody;
        hinge.connectedAnchor = bundle.Parent.pivotPosition;
    }
}