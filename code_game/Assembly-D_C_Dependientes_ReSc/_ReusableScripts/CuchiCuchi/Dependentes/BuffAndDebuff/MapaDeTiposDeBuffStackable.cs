using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002C1 RID: 705
	[CreateAssetMenu(fileName = "TipoDeBuffStackable", menuName = "Objetos/Buff/MapaDeTiposDeBuffStackable")]
	public class MapaDeTiposDeBuffStackable : MapaSingletonDeValoresUnicos<MapaDeTiposDeBuffStackable>
	{
		// Token: 0x0600121D RID: 4637 RVA: 0x000553AE File Offset: 0x000535AE
		protected override void LoadValores(List<string> valores, List<string> fields)
		{
			valores.AddRange(this.m_tipos);
			fields.AddRange(this.m_tipos);
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnJuegoLanzadoValoresUnicos()
		{
		}

		// Token: 0x04000D3A RID: 3386
		[SerializeField]
		private List<string> m_tipos = new List<string>();
	}
}
