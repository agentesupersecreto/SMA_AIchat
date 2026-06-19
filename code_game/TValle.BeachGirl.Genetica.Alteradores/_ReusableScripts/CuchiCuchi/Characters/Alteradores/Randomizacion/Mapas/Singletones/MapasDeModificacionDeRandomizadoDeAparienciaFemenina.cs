using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica.Randomizacion.Mapas.Abstracts;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Randomizacion.Mapas.Singletones
{
	// Token: 0x02000064 RID: 100
	[CreateAssetMenu(fileName = "MapasDeModificacionDeRandomizadoDeAparienciaFemenina", menuName = "Objetos/Genetica/Randomizado/Singletones/Mapas Mods Apariencia Femenina")]
	public class MapasDeModificacionDeRandomizadoDeAparienciaFemenina : MapaSingleton<MapasDeModificacionDeRandomizadoDeAparienciaFemenina>
	{
		// Token: 0x060004B2 RID: 1202 RVA: 0x000110FE File Offset: 0x0000F2FE
		protected override void OnJuegoLanzado()
		{
		}

		// Token: 0x04000218 RID: 536
		public bool activado = true;

		// Token: 0x04000219 RID: 537
		[CoolArrayItem]
		public List<MapaDeModificacionDeRandomizadoBase> mapas = new List<MapaDeModificacionDeRandomizadoBase>();
	}
}
