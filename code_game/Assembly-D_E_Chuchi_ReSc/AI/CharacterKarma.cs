using System;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000320 RID: 800
	public class CharacterKarma : CustomMonobehaviour, ICharacterKarma
	{
		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06001136 RID: 4406 RVA: 0x0004A52A File Offset: 0x0004872A
		public ModificableDeFloat sumable
		{
			get
			{
				return this.m_sumable;
			}
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06001137 RID: 4407 RVA: 0x0004A532 File Offset: 0x00048732
		public ModificableDeFloat modificable
		{
			get
			{
				return this.m_modificable;
			}
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06001138 RID: 4408 RVA: 0x0004A53A File Offset: 0x0004873A
		public float valor
		{
			get
			{
				return this.m_valor;
			}
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x0004A542 File Offset: 0x00048742
		public void UpdateValor()
		{
			this.m_valor = this.m_sumable.AdicinarValorIncluyendo(0f);
			this.m_valor = this.m_modificable.ModificarValor(this.m_valor);
		}

		// Token: 0x04000DC0 RID: 3520
		[SerializeField]
		private ModificableDeFloat m_sumable = new ModificableDeFloat(0f);

		// Token: 0x04000DC1 RID: 3521
		[SerializeField]
		private ModificableDeFloat m_modificable = new ModificableDeFloat(1f);

		// Token: 0x04000DC2 RID: 3522
		[SerializeField]
		private float m_valor;
	}
}
