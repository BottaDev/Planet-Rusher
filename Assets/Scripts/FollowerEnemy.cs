using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : EnemyEntity
{
	public float rotationSpeed = 6f;
	public float detectionRadius;
	public LayerMask targetMask;

	public Transform target;

	protected override void Update()
	{
		if (isFreezed)
			return;

		base.Update();

		if (target != null)
		{
			var rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

			float distance = Vector3.Distance(transform.position, target.position);

			if (distance > detectionRadius * 2)
				target = null;
		}
		else
		{
			DetectEnemiesInRange();
		}
	}

	private void DetectEnemiesInRange()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, targetMask);

		if (hitColliders.Length > 0)
			target = hitColliders[0].transform;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, detectionRadius);
	}


}
