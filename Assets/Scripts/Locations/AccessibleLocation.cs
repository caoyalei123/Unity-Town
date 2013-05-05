using UnityEngine;
using System.Collections;

/**
 * Represents a location which is accessible to units.
 */
public abstract class AccessibleLocation : MonoBehaviour
{
	// The game object a unit must reach to interact
	// with this location.
	public GameObject accessPoint;
	// True if this location is currently active.
	public bool active = true;
	
	public virtual void Start()
	{
	
	}
	
	public virtual void Update()
	{
	
	}
	
	/**
	 * Runs a location specific interaction between
	 * this location and a human unit.
	 * 
	 * Interactions may affect the state of both the unit
	 * and the location.
	 */
	public abstract void RunHumanInteraction(HumanUnit humanUnit);
}
