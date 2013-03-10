using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
	protected AstarAI aStarAI;
	
	public virtual void Awake()
	{
		aStarAI = (AstarAI) gameObject.GetComponent("AstarAI");
	}
	
	public virtual void Start()
	{
	
	}
	
	public virtual void Update()
	{
	
	}
}
