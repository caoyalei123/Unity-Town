using UnityEngine;
using System.Collections;

/**
 * Represents a human unit.
 * Human units visit shops and interact with items in the town.
 */
public class HumanUnit : Unit
{
	public string unitName;
	public string bio;
	public int age;
	public int cash;
	
	private bool movingToLocation;
	private AccessibleLocation targetLocation;
	
	private LocationManager locationManager;
	private UnitManager unitManager;
	
	private float movementDelta = 0;
	
	public override void Awake()
	{
		base.Awake();
	}
	
	public override void Start()
	{
		base.Start();
		
		this.locationManager = (LocationManager) Camera.main.GetComponent("LocationManager");
		this.unitManager = (UnitManager) Camera.main.GetComponent("UnitManager");
	}
	
	public void Update()
	{
		if (this.movingToLocation)
		{
			if (this.aStarAI.IsPathComplete())
			{
				this.OnLocationReached();
			}
		}
		else
		{
			this.movementDelta += Time.deltaTime;
			
			if (this.movementDelta > HumanConstants.MOVEMENT_DELAY)
			{
				this.movementDelta = 0;
				
				if (this.cash < HumanConstants.MIN_CASH)
				{
					this.GoToCashMachine();
				}
				else
				{
					this.GoToRandomShop();
				}
			}
		}
	}
	
	public override void SelectUnit()
	{
		base.SelectUnit();
		
		this.unitManager.SelectHuman(this);
	}
	
	public void GoToCashMachine()
	{
		Debug.Log("Going to cash machine. cash = " + this.cash);
		
		GameObject cashMachine = this.locationManager.GetCashMachines()[0];
		
		if (cashMachine == null)
		{
			Debug.LogError("Got a null cash machine from Location Manager.");
			return;
		}
		
		this.targetLocation = (AccessibleLocation) cashMachine.GetComponent("CashMachineLocation");
		
		this.GoToLocation(this.targetLocation);
	}
	
	public void GoToRandomShop()
	{
		Debug.Log("Going to random shop. cash = " + this.cash);
		
		GameObject shop = this.locationManager.GetRandomShop();
		
		if (shop == null)
		{
			Debug.LogError("Got a null shop from Location Manager.");
			return;
		}
		
		this.targetLocation = (AccessibleLocation) shop.GetComponent("ShopLocation");
		
		this.GoToLocation(this.targetLocation);
	}
	
	private void GoToLocation(AccessibleLocation location)
	{
		if (location == null)
		{
			Debug.LogError("Attempted to move to a null target location.");
			return;
		}
		
		if (location.accessPoint == null)
		{
			Debug.LogError("Attempted to move to a target location with a null access point.");
			return;
		}
		
		this.aStarAI.MoveTo(location.accessPoint.transform.position);
		
		this.movingToLocation = true;
	}
	
	private void OnLocationReached()
	{
		this.targetLocation.RunHumanInteraction(this);
		
		this.targetLocation = null;
		this.movingToLocation = false;
	}
}
