using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Conjuntos;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000036 RID: 54
	[AplicaAConjuntoDeFisico(para = "skin")]
	[Serializable]
	public struct InterpretacionDeFacialSkin
	{
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060001AF RID: 431 RVA: 0x000077EC File Offset: 0x000059EC
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x000077F4 File Offset: 0x000059F4
		[LabelLocalizado("Makeup Amount (Cheeks)", "US")]
		public Interpretacion.Capacidad makeUpOnCheeks
		{
			get
			{
				return this.m_makeUpCheeksAmount;
			}
			set
			{
				this.m_makeUpCheeksAmount = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x000077FD File Offset: 0x000059FD
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00007805 File Offset: 0x00005A05
		[LabelLocalizado("Makeup Amount (Eyeshadow)", "US")]
		public Interpretacion.Capacidad makeUpEyeshadow
		{
			get
			{
				return this.m_makeUpEyeshadowAmount;
			}
			set
			{
				this.m_makeUpEyeshadowAmount = value;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x0000780E File Offset: 0x00005A0E
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x00007816 File Offset: 0x00005A16
		[AplicaAConjuntoDeFisico(para = "skin", weigth = 50)]
		[LabelLocalizado("Makeup Max Amount", "US")]
		public Interpretacion.CantidadNoContable makeUpMaxAmount
		{
			get
			{
				return this.m_makeUpMaxAmount;
			}
			set
			{
				this.m_makeUpMaxAmount = value;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x0000781F File Offset: 0x00005A1F
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x00007827 File Offset: 0x00005A27
		[UIElementDisabled]
		[LabelLocalizado("Freckles (Not Implemented)", "US")]
		public Interpretacion.CantidadNoContable frecklesAmount { readonly get; set; }

		// Token: 0x04000098 RID: 152
		[SerializeField]
		private Interpretacion.Capacidad m_makeUpCheeksAmount;

		// Token: 0x04000099 RID: 153
		[SerializeField]
		private Interpretacion.Capacidad m_makeUpEyeshadowAmount;

		// Token: 0x0400009A RID: 154
		[SerializeField]
		private Interpretacion.CantidadNoContable m_makeUpMaxAmount;

		// Token: 0x0400009B RID: 155
		[LabelLocalizado("Difficulty", "US")]
		public SkinDifficulty difficulty;
	}
}
