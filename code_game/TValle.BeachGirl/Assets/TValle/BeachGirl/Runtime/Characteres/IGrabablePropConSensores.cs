using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Characteres
{
	// Token: 0x020000B2 RID: 178
	public interface IGrabablePropConSensores : IGrabableProp
	{
		// Token: 0x1700020B RID: 523
		// (get) Token: 0x0600054C RID: 1356
		bool propEstaActivo { get; }

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x0600054D RID: 1357
		bool linkedSensors { get; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x0600054E RID: 1358
		[TupleElementNames(new string[] { "sensorTransform", "sensorWorldRadius" })]
		IReadOnlyList<ValueTuple<Transform, float>> sensorsData
		{
			[return: TupleElementNames(new string[] { "sensorTransform", "sensorWorldRadius" })]
			get;
		}

		// Token: 0x0600054F RID: 1359
		void UpdateSensorsData();
	}
}
