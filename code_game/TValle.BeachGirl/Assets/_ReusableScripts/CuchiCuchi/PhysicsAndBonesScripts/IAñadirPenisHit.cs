using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000F4 RID: 244
	internal interface IAñadirPenisHit
	{
		// Token: 0x06000A67 RID: 2663
		void Añadir(Dictionary<PenisPart, RaycastHit> hits, float largoAgujero, int cantidadRealDeHitsContraPartes);
	}
}
