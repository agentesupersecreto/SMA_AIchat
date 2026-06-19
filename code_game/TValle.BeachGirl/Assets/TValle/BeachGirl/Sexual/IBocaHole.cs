using System;
using Assets.Base.Joints;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Sexual
{
	// Token: 0x02000042 RID: 66
	public interface IBocaHole : IFemaleHole, IHole, IPenetrable, IComponentStartable, IPhysicsHole
	{
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000136 RID: 310
		TipoDeOralSex currentOralSexTipo { get; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000137 RID: 311
		Rigidbody rootParaNoPenetracionSuckJoints { get; }
	}
}
