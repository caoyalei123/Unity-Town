using UnityEngine;
using System.Collections;

public abstract class AccessibleLocation : MonoBehaviour
{
	public GameObject accessPoint;
	
	public virtual void Start()
	{
	
	}
	
	public virtual void Update()
	{
	
	}
	
	public abstract void runHumanInteraction(HumanUnit humanUnit);
}