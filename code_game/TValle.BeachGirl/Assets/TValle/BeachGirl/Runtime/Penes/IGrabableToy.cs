using System;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Penes
{
	// Token: 0x02000096 RID: 150
	public interface IGrabableToy : IGrabableProp
	{
		// Token: 0x170001CD RID: 461
		// (get) Token: 0x0600047F RID: 1151
		Transform sensorBase { get; }

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000480 RID: 1152
		float sensorBaseWorldRadius { get; }
	}
}
