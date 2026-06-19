using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Globales;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Sonidos.Characters
{
	// Token: 0x02000062 RID: 98
	public class CharacterPitchDeExpulsiones : CustomMonobehaviour
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00003E21 File Offset: 0x00002021
		public ModificableDeFloat modificableNasal
		{
			get
			{
				return this.m_modificableNasal;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060001BA RID: 442 RVA: 0x00003E29 File Offset: 0x00002029
		public ModificableDeFloat modificableVocal
		{
			get
			{
				return this.m_modificableVocal;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00003E31 File Offset: 0x00002031
		public float pitchDeVocal
		{
			get
			{
				if (this.m_updateVocalID.IsCurrent())
				{
					return this.m_pitchDeVocal;
				}
				this.m_updateVocalID = ForcedUpdateId.current;
				this.m_pitchDeVocal = this.m_modificableVocal.ModificarValor(1f);
				return this.m_pitchDeVocal;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060001BC RID: 444 RVA: 0x00003E6E File Offset: 0x0000206E
		public float pitchDeNazal
		{
			get
			{
				if (this.m_updateNasalID.IsCurrent())
				{
					return this.m_pitchDeNazal;
				}
				this.m_updateNasalID = ForcedUpdateId.current;
				this.m_pitchDeNazal = this.m_modificableNasal.ModificarValor(1f);
				return this.m_pitchDeNazal;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00003EAB File Offset: 0x000020AB
		public int cantidadDeExpresionesConSonidos
		{
			get
			{
				return Singleton<MapasDeSonidosDeExpresionesVerbalesSexuales>.instance.mapas.Count;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00003EBC File Offset: 0x000020BC
		public int expresionesSonidosIndex
		{
			get
			{
				return this.m_expresionesSonidosIndex;
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00003EC4 File Offset: 0x000020C4
		public void ActualizarExpresionesSonidosIndex()
		{
			if (this.flagCambiarExpresionesSonidosIndex < 0)
			{
				return;
			}
			try
			{
				this.m_expresionesSonidosIndex = Mathf.Clamp(this.flagCambiarExpresionesSonidosIndex, 0, this.cantidadDeExpresionesConSonidos - 1);
			}
			finally
			{
				this.flagCambiarExpresionesSonidosIndex = -1;
			}
		}

		// Token: 0x04000118 RID: 280
		[SerializeField]
		private ModificableDeFloat m_modificableNasal = new ModificableDeFloat(1f);

		// Token: 0x04000119 RID: 281
		[SerializeField]
		private ModificableDeFloat m_modificableVocal = new ModificableDeFloat(1f);

		// Token: 0x0400011A RID: 282
		private ForcedUpdateId m_updateNasalID;

		// Token: 0x0400011B RID: 283
		private ForcedUpdateId m_updateVocalID;

		// Token: 0x0400011C RID: 284
		public int flagCambiarExpresionesSonidosIndex = -1;

		// Token: 0x0400011D RID: 285
		[ReadOnlyUI]
		[SerializeField]
		private float m_pitchDeVocal = 1f;

		// Token: 0x0400011E RID: 286
		[ReadOnlyUI]
		[SerializeField]
		private float m_pitchDeNazal = 1f;

		// Token: 0x0400011F RID: 287
		[ReadOnlyUI]
		[SerializeField]
		private int m_expresionesSonidosIndex = -1;
	}
}
