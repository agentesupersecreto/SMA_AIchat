using System;
using Assets.TValle.BeachGirl;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Particulas.Skins
{
	// Token: 0x0200015A RID: 346
	[Serializable]
	public class SemenHit : IClearable
	{
		// Token: 0x060007D2 RID: 2002 RVA: 0x000246AA File Offset: 0x000228AA
		public void Clear()
		{
			this.parteImpactada = ParteDelCuerpoHumano.pecho;
			this.tipo = TipoDeSemen.semen;
			this.velocidad = 0f;
			this.pene = null;
			this.intersection = Vector3.zero;
			this.normal = Vector3.zero;
		}

		// Token: 0x04000629 RID: 1577
		public ParteDelCuerpoHumano parteImpactada;

		// Token: 0x0400062A RID: 1578
		public TipoDeSemen tipo;

		// Token: 0x0400062B RID: 1579
		public float velocidad;

		// Token: 0x0400062C RID: 1580
		public IPeneSimple pene;

		// Token: 0x0400062D RID: 1581
		public Vector3 intersection;

		// Token: 0x0400062E RID: 1582
		public Vector3 normal;
	}
}
