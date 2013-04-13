using UnityEngine;
using System.Collections;

/**
 * Provides access to all existing units.
 */
public class UnitManager : MonoBehaviour
{
	private GameObject[] humans;
	
	public void Awake()
	{
		this.humans = GameObject.FindGameObjectsWithTag(TagConstants.HUMANS);
		
		Debug.Log("Started with " + this.getHumanCount() + " humans.");
	}
	
	public void Start()
	{
	
	}
	
	public void Update ()
	{
	
	}
	
	public GameObject[] getHumans()
	{
		return this.humans;
	}
	
	public int getHumanCount()
	{
		return this.humans.Length;
	}
}
