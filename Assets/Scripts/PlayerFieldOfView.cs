using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerFieldOfView : MonoBehaviour
{
	public float viewRadius;
	public float viewAngle;
	
	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();
	
	public LayerMask targetMask;
	public LayerMask obstacleMask;
	
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	IEnumerator FindTargetsWithDelay(float delay)
	{
		while (true)
		{
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
		}
	}
	
	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal)
		{
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
	
	void FindVisibleTargets()
	{
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
		
		for (int i=0; i<targetsInViewRadius.Length; i++)
		{
			Transform target = targetsInViewRadius[i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
			{
				float distToTarget = Vector3.Distance(transform.position, target.position);
				if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
				{
					visibleTargets.Add(target);
				}
			}
		}
	}
}
