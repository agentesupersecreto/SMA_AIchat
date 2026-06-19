using System;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Mapas
{
	// Token: 0x02000397 RID: 919
	[CreateAssetMenu(fileName = "MapaSingletonDefaultInterpretacion", menuName = "Objetos/Genetica/Mapa Singleton Default Interpretacion")]
	public class MapaSingletonDefaultInterpretacion : MapaSingleton<MapaSingletonDefaultInterpretacion>
	{
		// Token: 0x060016F6 RID: 5878 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnJuegoLanzado()
		{
		}

		// Token: 0x040010AD RID: 4269
		public InterpretacionCompletaDeFemale interpretacion;
	}
}
