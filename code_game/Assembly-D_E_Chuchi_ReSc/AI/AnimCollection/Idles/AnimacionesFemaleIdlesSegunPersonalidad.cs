using System;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics.AnimCollection;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.AnimCollection.Idles
{
	// Token: 0x02000563 RID: 1379
	[Obsolete("", true)]
	public class AnimacionesFemaleIdlesSegunPersonalidad : ColleccionDeAnimacionesEvaluablesBase<AnimacionesFemaleIdlesSegunPersonalidad, AnimacionesFemaleIdlesSegunPersonalidad.Item>
	{
		// Token: 0x02000564 RID: 1380
		[Serializable]
		public class Item : AnimacionEvaluableItemBase
		{
			// Token: 0x170008EA RID: 2282
			// (get) Token: 0x06002184 RID: 8580 RVA: 0x0007D27C File Offset: 0x0007B47C
			[Obsolete("", true)]
			public override int ID
			{
				get
				{
					return this.m_ID;
				}
			}

			// Token: 0x040015CD RID: 5581
			[HideInInspector]
			[SerializeField]
			private int m_ID;

			// Token: 0x040015CE RID: 5582
			public PersonalidadDinamica para = new PersonalidadDinamica();
		}
	}
}
