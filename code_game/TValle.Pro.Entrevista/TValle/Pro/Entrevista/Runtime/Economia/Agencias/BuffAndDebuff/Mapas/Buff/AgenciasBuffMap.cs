using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Mapas.Buff
{
	// Token: 0x020000E3 RID: 227
	[CreateAssetMenu(fileName = "AgenciasBuffMap", menuName = "Objetos/Buff/AgenciasBuffMap")]
	public class AgenciasBuffMap : BuffMap
	{
		// Token: 0x0600081D RID: 2077 RVA: 0x0002F692 File Offset: 0x0002D892
		public BuffEvento GetEventoBuffParaAgencias<T>(DateTime start, string idSegundaria, AgenciasArg<T> argumento) where T : AgenciasArg<T>
		{
			argumento.agenciasID = this.agenciasID;
			return base.GetEventoBuff(start, idSegundaria, argumento, null);
		}

		// Token: 0x040004A0 RID: 1184
		[StringSelectorV2(typeof(ProveedorDeAgenciasIdsAttribute))]
		public List<string> agenciasID = new List<string>();
	}
}
