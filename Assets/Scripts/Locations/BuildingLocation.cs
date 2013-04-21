using UnityEngine;
using System.Collections;

/**
 * Represents a physical building location.
 */
public class BuildingLocation : AccessibleLocation
{
	public string name;
	public string description;
	public bool openToPublic;
	
	public override void Start()
	{
		base.Start();
	}
	
	public override void Update()
	{
		base.Update();
	}
	
	public override void RunHumanInteraction(HumanUnit humanUnit)
	{
		
	}
}
