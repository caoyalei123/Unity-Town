using UnityEngine;
using System.Collections;

public class ShopLocation : BuildingLocation
{
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
		humanUnit.cash -= 20;
	}
}