using UnityEngine;
using System.Collections;

public class RecursiveInstantiator : MonoBehaviour
{

	public int recurse = 5;
	public int splitNumber = 2;
	public Vector3 pivotPosition;

	public float lsX=0.5F, lsY=-0.1F, lsZ=0.5F;

	// Use this for initialization
	void Start()
	{
		recurse -= 1;

		for (int i = 0; i < splitNumber; i++)
		{
			if (recurse>0)
			{
				var copy = Instantiate(gameObject);
				var recursive = copy.GetComponent<RecursiveInstantiator>();
				recursive.SendMessage("Generated", new RecursiveBundle() { Index = i, Parent = this });
			}
            else
            {
				transform.localScale += new Vector3(lsX, lsY, lsZ);			
				this.transform.GetChild(0).GetComponent<Renderer>().materials[0].color = Color.red;
			}
		}
	}

}