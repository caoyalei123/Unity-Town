using UnityEngine;
using System.Collections;
using Pathfinding;

public class AstarAI : MonoBehaviour
{
	// The calculated path
	public Path path;

	// The AI's speed per second
	public float speed = 100;

	// The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	private Seeker seeker;
	private CharacterController controller;
	
	// The waypoint we are currently moving towards
	private int currentWaypoint = 0;
	
	private bool pathComplete = false;
	
	public void Awake()
	{
		this.seeker = GetComponent<Seeker>();
		this.controller = GetComponent<CharacterController>();
	}
	
	public void MoveTo(Vector3 targetPosition)
	{
		//Debug.Log("Human Unit move to x: " + targetPosition.x + ", y: " + targetPosition.y + ", z: " + targetPosition.z);
		
		this.seeker.StartPath(this.transform.position, targetPosition, this.OnPathComplete);
		
		this.pathComplete = false;
	}

	public void OnPathComplete(Path p)
	{
		//Debug.Log("Yey, we got a path back. Did it have an error? " + p.error);
		
		if (!p.error)
		{
			this.path = p;
			// Reset the waypoint counter
			this.currentWaypoint = 0;
		}
		else
		{
			Debug.LogError("Path finding error: " + p.errorLog);
		}
	}

	public void FixedUpdate()
	{
		if (this.path == null)
		{
			// We have no path to move after yet
			return;
		}
		
		if (this.currentWaypoint >= this.path.vectorPath.Count)
		{
			//Debug.Log("End Of Path Reached");
			
			this.path = null;
			this.pathComplete = true;
			this.currentWaypoint = 0;
			
			return;
		}

		// Direction to the next waypoint
		Vector3 dir = (this.path.vectorPath[this.currentWaypoint] - this.transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		this.controller.SimpleMove(dir);

		// Check if we are close enough to the next waypoint
		// If we are, proceed to follow the next waypoint
		if (Vector3.Distance(this.transform.position, this.path.vectorPath[this.currentWaypoint]) < this.nextWaypointDistance)
		{
			this.currentWaypoint++;
			return;
		}
	}
	
	public bool IsPathComplete()
	{
		return this.pathComplete;
	}
}
