using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Mapas
{
	// Token: 0x02000139 RID: 313
	[CreateAssetMenu(fileName = "MapaDeCharacteresIDs", menuName = "Objetos/Characters/Mapas/Mapa De Characteres IDs")]
	public class MapaDeCharacteresIDs : AplicableScriptable
	{
		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06000D8C RID: 3468 RVA: 0x0002EE93 File Offset: 0x0002D093
		public IReadOnlyList<MapaDeCharacteresIDs.Par> lista
		{
			get
			{
				return this.m_characteres;
			}
		}

		// Token: 0x04000789 RID: 1929
		[SerializeField]
		private List<MapaDeCharacteresIDs.Par> m_characteres = new List<MapaDeCharacteresIDs.Par>();

		// Token: 0x0200020A RID: 522
		[Serializable]
		public class Par
		{
			// Token: 0x04000B28 RID: 2856
			public string nombre;

			// Token: 0x04000B29 RID: 2857
			public int ID;
		}
	}
}
