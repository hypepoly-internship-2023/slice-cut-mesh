using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BzKovSoft.ObjectSlicer;

public class MySlicer : BzSliceableObjectBase
{
	protected override BzSliceTryData PrepareData(Plane plane)
	{
		// colliders that will be participating in slicing
		var colliders = gameObject.GetComponentsInChildren<Collider>();

		// return data
		return new BzSliceTryData()
		{
			// componentManager: this class will manage components on sliced objects
			componentManager = new StaticComponentManager(gameObject, plane, colliders),
			plane = plane,
		};
	}

	protected override void OnSliceFinished(BzSliceTryResult result)
	{

	}
}
