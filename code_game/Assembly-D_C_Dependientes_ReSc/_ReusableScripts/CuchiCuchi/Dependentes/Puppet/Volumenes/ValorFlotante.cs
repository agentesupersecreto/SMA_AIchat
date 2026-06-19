using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Volumenes
{
	// Token: 0x0200011B RID: 283
	[Serializable]
	public class ValorFlotante
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x00020CB2 File Offset: 0x0001EEB2
		public float valorMidifcado
		{
			get
			{
				return this.modificable.ModificarValor(this.@base);
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x00020CC5 File Offset: 0x0001EEC5
		public float valorPromediado
		{
			get
			{
				return this.modificable.PromediarConValor(this.@base);
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x00020CD8 File Offset: 0x0001EED8
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x00020CE0 File Offset: 0x0001EEE0
		public float @base
		{
			get
			{
				return this.m_base;
			}
			set
			{
				this.m_base = value;
			}
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00020CE9 File Offset: 0x0001EEE9
		public void LoadBase(float val)
		{
			this.@base = val;
		}

		// Token: 0x0400048B RID: 1163
		[SerializeField]
		private float m_base;

		// Token: 0x0400048C RID: 1164
		public ModificableDeFloat modificable = new ModificableDeFloat(1f);
	}
}
