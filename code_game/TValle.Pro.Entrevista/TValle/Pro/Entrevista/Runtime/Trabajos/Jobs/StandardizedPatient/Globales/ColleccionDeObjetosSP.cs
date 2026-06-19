using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.CustomMonoBehaviours.Runtime;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient.Globales
{
	// Token: 0x0200006B RID: 107
	public class ColleccionDeObjetosSP : InstantiatedSingleton<ColleccionDeObjetosSP>
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x0001C2AE File Offset: 0x0001A4AE
		public IReadOnlyList<ColleccionDeObjetosSP.Par> camillas
		{
			get
			{
				return this.m_Objetos;
			}
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0001C2B8 File Offset: 0x0001A4B8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ObjetoDeId = this.m_Objetos.ToDictionary((ColleccionDeObjetosSP.Par c) => c.id, (ColleccionDeObjetosSP.Par p) => p.prefab);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0001C31C File Offset: 0x0001A51C
		public GameObject GetObject(string id)
		{
			GameObject gameObject;
			if (this.m_ObjetoDeId.TryGetValue(id, out gameObject))
			{
				return gameObject;
			}
			return null;
		}

		// Token: 0x040002B9 RID: 697
		[SerializeField]
		private ColleccionDeObjetosSP.Par[] m_Objetos;

		// Token: 0x040002BA RID: 698
		private Dictionary<string, GameObject> m_ObjetoDeId;

		// Token: 0x020001FC RID: 508
		[Serializable]
		public class Par
		{
			// Token: 0x040009AC RID: 2476
			public string id;

			// Token: 0x040009AD RID: 2477
			[InspectorName("Object")]
			public GameObject prefab;
		}
	}
}
