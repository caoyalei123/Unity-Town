using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Represents a location which is accessible to units.
 */
public abstract class AccessibleLocation : MonoBehaviour
{
	// The game object a unit must reach to interact
	// with this location.
	public GameObject accessPoint;
	// The unit stat buffs this location provides.
	public Dictionary<string, float> unitStatBuffs;
	
	// True if this location is currently active.
	protected bool activeLocation = true;
	
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
	public virtual void RunHumanInteraction(HumanUnit humanUnit)
	{
		foreach (string statName in this.unitStatBuffs.Keys)
		{
			humanUnit.ApplyStatBuff(statName, this.unitStatBuffs[statName]);
		}
	}
}
