using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa.Globales
{
	// Token: 0x02000142 RID: 322
	public class ConjuntosDeRopa : AsyncSingleton<ConjuntosDeRopa>
	{
		// Token: 0x06000756 RID: 1878 RVA: 0x000226C4 File Offset: 0x000208C4
		protected override void InitSyncData(bool esEditorTime)
		{
			base.InitSyncData(esEditorTime);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x000226CD File Offset: 0x000208CD
		protected override IEnumerator PostInitData()
		{
			this.m_ConjuntoPorKey = this.m_Conjuntos.ToDictionary((ConjuntosDeRopa.ConjuntoPar m) => m.id);
			yield break;
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x000226DC File Offset: 0x000208DC
		public MapaConjuntoDeRopa GetConjunto(string id)
		{
			ConjuntosDeRopa.ConjuntoPar conjuntoPar;
			if (!this.m_ConjuntoPorKey.TryGetValue(id, out conjuntoPar))
			{
				Debug.LogError("No se encontro conversacion de id " + id);
				return null;
			}
			return conjuntoPar.conjunto;
		}

		// Token: 0x040005CD RID: 1485
		[SerializeField]
		private List<ConjuntosDeRopa.ConjuntoPar> m_Conjuntos = new List<ConjuntosDeRopa.ConjuntoPar>();

		// Token: 0x040005CE RID: 1486
		private Dictionary<string, ConjuntosDeRopa.ConjuntoPar> m_ConjuntoPorKey;

		// Token: 0x02000143 RID: 323
		[Serializable]
		public class ConjuntoPar
		{
			// Token: 0x040005CF RID: 1487
			public string id;

			// Token: 0x040005D0 RID: 1488
			public MapaConjuntoDeRopa conjunto;
		}
	}
}
