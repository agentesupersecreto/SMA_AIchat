using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000FC RID: 252
	[Serializable]
	public class Suavizacion
	{
		// Token: 0x040005C2 RID: 1474
		[Obsolete("", true)]
		[NonSerialized]
		public float distanciaMaximaMod;

		// Token: 0x040005C3 RID: 1475
		[Range(0f, 1f)]
		public float penetracionDeParteWParaMaxValores = 0.99f;

		// Token: 0x040005C4 RID: 1476
		[Obsolete("", true)]
		[NonSerialized]
		public float modMinimo;

		// Token: 0x040005C5 RID: 1477
		[Obsolete("", true)]
		[NonSerialized]
		public float modMinimoSiEsPunta;

		// Token: 0x040005C6 RID: 1478
		public float inPower = 2f;

		// Token: 0x040005C7 RID: 1479
		[Range(0f, 1f)]
		public float mod = 1f;
	}
}
