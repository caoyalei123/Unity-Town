using UnityEngine;
using System.Collections;

/**
 * Represents a vehicle unit.
 * Vehicles travel along road-based paths through the town.
 */
public class VehicleUnit : Unit
{
	// The speed this vehicle moves at.
	public float speed = 1.5f;
	// The max distance to check ahead for path nodes.
	public float pathNodeMaxDistance = 20f;
	
	private int raycastLayerMask;
	private RaycastHit raycastHit;
	
	private PathNode targetNode;
	private bool movingToNode = false;
	
	private Vector3 pathStartPoint;
	private float pathStartTime;
	private float pathLength = 0f;
	private float pathCompletion = 0f;
	
	public override void Awake()
	{
		base.Awake();
		
		// Limit unit raycasting to Path Nodes layer.
		this.raycastLayerMask = (1 << LayerMask.NameToLayer(LayerConstants.PATH_NODES));
	}
	
	/**
	 * Uses raycasting to detect path nodes.
	 * Follows path if nodes are found.
	 */
	public void Update()
	{
		if (!this.movingToNode)
		{
			if (Physics.Raycast(this.transform.position, -this.transform.right, out this.raycastHit, this.pathNodeMaxDistance, raycastLayerMask))
			{
				Debug.DrawLine(this.transform.position, this.raycastHit.point, Color.cyan, 0.2f);
				
				if (this.raycastHit.collider.gameObject.tag == TagConstants.PATH_NODES)
				{
					Debug.Log("Vehicle detected path node.");
					
					PathNode pathNode = (PathNode) this.raycastHit.collider.gameObject.GetComponent("PathNode");
					
					this.MoveToNode(pathNode);
				}
			}
		}
		else if (this.targetNode != null)
		{
			float pathLengthComplete = (Time.time - this.pathStartTime) * this.speed;
			
			this.pathCompletion = (pathLengthComplete / pathLength);
			
			this.transform.position = Vector3.Lerp(this.pathStartPoint, this.targetNode.transform.position, this.pathCompletion);
			
			if (this.pathCompletion >= 1)
			{
				this.OnNodeReached();
			}
		}
	}
	
	private void MoveToNode(PathNode pathNode)
	{
		this.targetNode = pathNode;
		
		this.pathStartPoint = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		this.pathStartTime = Time.time;
		this.pathLength = Vector3.Distance(this.pathStartPoint, pathNode.transform.position);
		this.pathCompletion = 0;
		
		this.movingToNode = true;
	}
	
	private void OnNodeReached()
	{
		Debug.Log("Vehicle reached target node.");
		
		this.transform.rotation = this.targetNode.transform.rotation;
		
		this.targetNode = null;
		
		this.movingToNode = false;
	}
}
