using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Semen
{
	// Token: 0x02000084 RID: 132
	public interface ISemenRegistrable
	{
		// Token: 0x06000340 RID: 832
		void RegistrarContacto(IPeneSimple emisor, TipoDeSemen tipo, Vector3 wPosition, Vector3 wNormal, Vector3 velocity, IReadOnlyList<BodyPartEnum> impactadas);
	}
}
