using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002C2 RID: 706
	[CreateAssetMenu(fileName = "MapaDeTiposDeBuffStackableMaxCount", menuName = "Objetos/Buff/MapaDeTiposDeBuffStackableMaxCount")]
	public class MapaDeTiposDeBuffStackableMaxCount : MapaSingleton<MapaDeTiposDeBuffStackableMaxCount>
	{
		// Token: 0x06001220 RID: 4640 RVA: 0x000553DC File Offset: 0x000535DC
		protected override void OnJuegoLanzado()
		{
			for (int i = 0; i < this.m_maxCounts.data.Count; i++)
			{
				if (this.m_maxCounts.data[i] == 0)
				{
					Debug.LogError("max count de stack tipo: " + this.m_maxCounts.nombres[i] + " es zero");
				}
			}
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x0005543C File Offset: 0x0005363C
		public int GetMaxCountDeTipo(string tipoID)
		{
			int num;
			if (this.m_maxCounts.dataDeNombre.TryGetValue(tipoID, out num))
			{
				return num;
			}
			return -1;
		}

		// Token: 0x04000D3B RID: 3387
		[FixedListV2(typeof(ProveedorDeStacksTipoIdsAttribute), "nombres", "data")]
		[SerializeField]
		private MapaDeTiposDeBuffStackableMaxCount.MaxCounts m_maxCounts = new MapaDeTiposDeBuffStackableMaxCount.MaxCounts();

		// Token: 0x020002C3 RID: 707
		[Serializable]
		public class MaxCounts
		{
			// Token: 0x17000454 RID: 1108
			// (get) Token: 0x06001223 RID: 4643 RVA: 0x00055474 File Offset: 0x00053674
			public IReadOnlyDictionary<string, int> dataDeNombre
			{
				get
				{
					if (this.m_dataDeNombre == null || this.m_dataDeNombre.Count == 0)
					{
						this.Init();
					}
					return this.m_dataDeNombre;
				}
			}

			// Token: 0x06001224 RID: 4644 RVA: 0x00055498 File Offset: 0x00053698
			private void Init()
			{
				this.m_dataDeNombre = new Dictionary<string, int>(this.nombres.Count);
				int num = Mathf.Min(this.nombres.Count, this.data.Count);
				for (int i = 0; i < num; i++)
				{
					this.m_dataDeNombre.Add(this.nombres[i], this.data[i]);
				}
			}

			// Token: 0x04000D3C RID: 3388
			public List<string> nombres = new List<string>();

			// Token: 0x04000D3D RID: 3389
			public List<int> data = new List<int>();

			// Token: 0x04000D3E RID: 3390
			[NonSerialized]
			private Dictionary<string, int> m_dataDeNombre;
		}
	}
}
