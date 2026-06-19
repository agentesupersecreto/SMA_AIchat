using System;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Menus.Maps
{
	// Token: 0x020000AD RID: 173
	[CreateAssetMenu(fileName = "PrefabRadialMenuMap", menuName = "Objetos/Activities/PrefabRadialMenuMap")]
	public class PrefabRadialMenuMap : RadialMenuMap, IRadialMenuMap
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x0002566D File Offset: 0x0002386D
		public GameObject prefab
		{
			get
			{
				return this.m_prefab;
			}
		}

		// Token: 0x040003ED RID: 1005
		[SerializeField]
		private GameObject m_prefab;
	}
}
