using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200003D RID: 61
	[AplicaAConjuntoDeFisico(para = "hair")]
	[Serializable]
	public struct InterpretacionDePubicHair
	{
		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00008028 File Offset: 0x00006228
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x00008030 File Offset: 0x00006230
		[AplicaAConjuntoDeFisico(para = "hair", weigth = 50)]
		[LabelLocalizado("Density", "US")]
		public Interpretacion.Capacidad density
		{
			get
			{
				return this.m_density;
			}
			set
			{
				this.m_density = value;
			}
		}

		// Token: 0x04000102 RID: 258
		[SerializeField]
		private Interpretacion.Capacidad m_density;

		// Token: 0x04000103 RID: 259
		[AplicaAConjuntoDeFisico(para = "hair", weigth = 10)]
		[LabelLocalizado("Color", "US")]
		public FreeColor color;
	}
}
