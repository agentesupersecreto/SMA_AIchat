using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica.Randomizacion.Mapas.Abstracts;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Randomizacion.Mapas.Singletones
{
	// Token: 0x02000065 RID: 101
	[CreateAssetMenu(fileName = "MapasDeModificacionDeRandomizadoDePersonalidadFemenina", menuName = "Objetos/Genetica/Randomizado/Singletones/Mapas Mods Personalidad Femenina")]
	public class MapasDeModificacionDeRandomizadoDePersonalidadFemenina : MapaSingleton<MapasDeModificacionDeRandomizadoDePersonalidadFemenina>
	{
		// Token: 0x060004B4 RID: 1204 RVA: 0x0001111A File Offset: 0x0000F31A
		protected override void OnJuegoLanzado()
		{
		}

		// Token: 0x0400021A RID: 538
		[CoolArrayItem]
		public List<MapaDeModificacionDeRandomizadoBase> mapas = new List<MapaDeModificacionDeRandomizadoBase>();
	}
}
