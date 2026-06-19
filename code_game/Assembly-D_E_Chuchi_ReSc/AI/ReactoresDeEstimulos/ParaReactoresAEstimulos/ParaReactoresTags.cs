using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.ParaReactoresAEstimulos
{
	// Token: 0x020003CA RID: 970
	[CreateAssetMenu(fileName = "ParaReactoresTags", menuName = "Objetos/Para Reactores Tags")]
	public sealed class ParaReactoresTags : MapaSingletonDeValoresUnicos<ParaReactoresTags>
	{
		// Token: 0x060014EC RID: 5356 RVA: 0x0005955C File Offset: 0x0005775C
		protected override void LoadValores(List<string> valores, List<string> fields)
		{
			valores.AddRange(this.tags);
			fields.AddRange(this.tags);
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnJuegoLanzadoValoresUnicos()
		{
		}

		// Token: 0x040010FD RID: 4349
		public List<string> tags = new List<string>();
	}
}
