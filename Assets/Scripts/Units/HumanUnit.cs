using UnityEngine;
using System.Collections;

public class HumanUnit : Unit
{
	public string name;
	public string bio;
	public int age;
	public int cash;
	
	private bool movingToLocation;
	private AccessibleLocation targetLocation;
	
	private LocationManager locationManager;
	
	private float movementDelta = 0;
	
	public override void Awake()
	{
		base.Awake();
	}
	
	public override void Start()
	{
		base.Start();
		
		this.locationManager = (LocationManager) Camera.main.GetComponent("LocationManager");
	}
	
	public override void Update()
	{
		base.Update();
		
		if (movingToLocation)
		{
			if (this.aStarAI.isPathComplete())
			{
				this.onLocationReached();
			}
		}
		else
		{
			movementDelta += Time.deltaTime;
			
			if (movementDelta > HumanConstants.MOVEMENT_DELAY)
			{
				movementDelta = 0;
				
				if (cash < HumanConstants.MIN_CASH)
				{
					this.goToCashMachine();
				}
				else
				{
					this.goToRandomShop();
				}
			}
		}
	}
	
	public void goToCashMachine()
	{
		Debug.Log("Going to cash machine. cash = " + this.cash);
		
		GameObject cashMachine = locationManager.getCashMachines()[0];
		
		if (cashMachine == null)
		{
			Debug.LogError("Got a null cash machine from Location Manager.");
			return;
		}
		
		this.targetLocation = (AccessibleLocation) cashMachine.GetComponent("CashMachineLocation");
		
		this.goToLocation(this.targetLocation);
	}
	
	public void goToRandomShop()
	{
		Debug.Log("Going to random shop. cash = " + this.cash);
		
		GameObject shop = locationManager.getRandomShop();
		
		if (shop == null)
		{
			Debug.LogError("Got a null shop from Location Manager.");
			return;
		}
		
		this.targetLocation = (AccessibleLocation) shop.GetComponent("ShopLocation");
		
		this.goToLocation(this.targetLocation);
	}
	
	private void goToLocation(AccessibleLocation location)
	{
		if (targetLocation == null)
		{
			Debug.LogError("Attempted to move to a null target location.");
			return;
		}
		
		if (targetLocation.accessPoint == null)
		{
			Debug.LogError("Attempted to move to a target location with a null access point.");
			return;
		}
		
		this.aStarAI.moveTo(targetLocation.accessPoint.transform.position);
		
		this.movingToLocation = true;
	}
	
	private void onLocationReached()
	{
		this.targetLocation.runHumanInteraction(this);
		
		this.targetLocation = null;
		this.movingToLocation = false;
	}
}
