using System;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs;
using Assets._ReusableScripts.Genetica.NPCs;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Genetica
{
	// Token: 0x020000B0 RID: 176
	public class PiscinaNpcDeSujetoComponent : CustomMonobehaviour
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000678 RID: 1656 RVA: 0x000259CD File Offset: 0x00023BCD
		public PiscinaDeNpcsManager piscinaOwner
		{
			get
			{
				return this.m_piscinaOwner;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x000259D5 File Offset: 0x00023BD5
		public SujetoIdentificableNpcAlteradoresFemeninos self
		{
			get
			{
				return this.m_self;
			}
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x000259E0 File Offset: 0x00023BE0
		public void Bind(PiscinaDeNpcsManager piscina, SujetoIdentificableNpcAlteradoresFemeninos mapa)
		{
			if (this.m_binded)
			{
				throw new InvalidOperationException();
			}
			if (mapa == null)
			{
				throw new ArgumentNullException("mapa", "mapa null reference.");
			}
			if (piscina == null)
			{
				throw new ArgumentNullException("piscina", "piscina null reference.");
			}
			this.m_piscinaOwner = piscina;
			this.m_self = mapa;
			this.m_binded = true;
		}

		// Token: 0x040003F2 RID: 1010
		[SerializeField]
		[ReadOnlyUI]
		private PiscinaDeNpcsManager m_piscinaOwner;

		// Token: 0x040003F3 RID: 1011
		[SerializeField]
		[ReadOnlyUI]
		private SujetoIdentificableNpcAlteradoresFemeninos m_self;

		// Token: 0x040003F4 RID: 1012
		private bool m_binded;
	}
}
