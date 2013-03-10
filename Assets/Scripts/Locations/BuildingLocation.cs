using UnityEngine;
using System.Collections;

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
	
	public override void runHumanInteraction(HumanUnit humanUnit)
	{
		
	}
}