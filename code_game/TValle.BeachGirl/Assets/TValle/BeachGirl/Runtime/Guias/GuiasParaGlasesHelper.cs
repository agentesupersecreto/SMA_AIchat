using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Guias
{
	// Token: 0x020000A5 RID: 165
	public class GuiasParaGlasesHelper : CustomMonobehaviour
	{
		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x00010516 File Offset: 0x0000E716
		public float distanciaTemporalPorDefecto
		{
			get
			{
				return this.m_distanciaTemporalPorDefecto;
			}
		}

		// Token: 0x040002FF RID: 767
		public Transform head;

		// Token: 0x04000300 RID: 768
		public GuiasParaGlasesHelper.Guias guias = new GuiasParaGlasesHelper.Guias();

		// Token: 0x04000301 RID: 769
		[ReadOnlyUI]
		[SerializeField]
		private float m_distanciaTemporalPorDefecto;

		// Token: 0x02000194 RID: 404
		[Serializable]
		public class Guias
		{
			// Token: 0x040008E8 RID: 2280
			public Transform front1;

			// Token: 0x040008E9 RID: 2281
			public Transform front2;

			// Token: 0x040008EA RID: 2282
			public Transform front3;

			// Token: 0x040008EB RID: 2283
			public Transform noseL;

			// Token: 0x040008EC RID: 2284
			public Transform noseR;

			// Token: 0x040008ED RID: 2285
			public Transform temporalL;

			// Token: 0x040008EE RID: 2286
			public Transform temporalR;

			// Token: 0x040008EF RID: 2287
			public Transform orejaL;

			// Token: 0x040008F0 RID: 2288
			public Transform orejaR;
		}
	}
}
