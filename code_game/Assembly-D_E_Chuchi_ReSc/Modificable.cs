using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x0200000C RID: 12
	[Serializable]
	public class Modificable
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00003870 File Offset: 0x00001A70
		public Modificable(PersonalidadRasgoCompleto Rasgo)
		{
			this.rasgo = Rasgo;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600005F RID: 95 RVA: 0x0000389F File Offset: 0x00001A9F
		public ModificableDeFloat sumable
		{
			get
			{
				return this.m_sumable;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000038A7 File Offset: 0x00001AA7
		public ModificableDeFloat modificable
		{
			get
			{
				return this.m_modificable;
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000038AF File Offset: 0x00001AAF
		public float Sumar(float valor)
		{
			valor = this.m_sumable.AdicinarValorIncluyendo(valor);
			return valor;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000038C0 File Offset: 0x00001AC0
		public float Multiplicar(float valor)
		{
			valor = this.m_modificable.ModificarValor(valor);
			return valor;
		}

		// Token: 0x0400001F RID: 31
		public PersonalidadRasgoCompleto rasgo;

		// Token: 0x04000020 RID: 32
		[SerializeField]
		private ModificableDeFloat m_sumable = new ModificableDeFloat(0f);

		// Token: 0x04000021 RID: 33
		[SerializeField]
		private ModificableDeFloat m_modificable = new ModificableDeFloat(1f);
	}
}
