using System;
using System.Collections.Generic;
using Assets.Base.Joints;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Sexual
{
	// Token: 0x0200003F RID: 63
	public interface IFemaleHole : IHole, IPenetrable, IComponentStartable, IPhysicsHole
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000133 RID: 307
		Character characterOwner { get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000134 RID: 308
		IFemaleChar femaleChar { get; }

		// Token: 0x06000135 RID: 309
		void ObtenerHolesCollidersDelCharExcluyendo(List<Collider> result, IHole hole);
	}
}
