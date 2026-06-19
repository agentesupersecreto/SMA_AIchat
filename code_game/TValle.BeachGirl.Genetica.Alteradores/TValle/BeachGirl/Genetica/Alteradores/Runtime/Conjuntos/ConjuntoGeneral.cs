using System;
using Assets._ReusableScripts.Genetica;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos
{
	// Token: 0x02000060 RID: 96
	[Serializable]
	public class ConjuntoGeneral : IConjuntoDeGenes
	{
		// Token: 0x0600046E RID: 1134 RVA: 0x000106BC File Offset: 0x0000E8BC
		public ConjuntoGeneral(string nombreDeConjunto)
		{
			if (string.IsNullOrWhiteSpace(nombreDeConjunto))
			{
				throw new NotSupportedException();
			}
			this.m_nombreDeConjunto = nombreDeConjunto;
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x000106D9 File Offset: 0x0000E8D9
		public string conjuntoName
		{
			get
			{
				return this.m_nombreDeConjunto;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x000106E1 File Offset: 0x0000E8E1
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x000106E9 File Offset: 0x0000E8E9
		public float fitnes
		{
			get
			{
				return this.m_fitnes;
			}
			set
			{
				this.m_fitnes = Mathf.Clamp01(value);
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x000106F7 File Offset: 0x0000E8F7
		public bool GenePertenece(object identificador)
		{
			return true;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x000106FA File Offset: 0x0000E8FA
		public void ResetFitnes()
		{
			this.m_fitnes = 0f;
		}

		// Token: 0x040001FC RID: 508
		[SerializeField]
		[ReadOnlyUI]
		private string m_nombreDeConjunto;

		// Token: 0x040001FD RID: 509
		[SerializeField]
		[Range(0f, 1f)]
		private float m_fitnes;
	}
}
