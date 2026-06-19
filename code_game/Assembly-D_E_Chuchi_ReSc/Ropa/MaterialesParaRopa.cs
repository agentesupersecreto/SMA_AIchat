using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Materiales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x02000103 RID: 259
	[ProveedorMaterialesDeRopaID("ids", "labels")]
	public sealed class MaterialesParaRopa : ColeccionDeMaterialesGenerica<MaterialesParaRopa, MapaDeMaterialesParaRopa, MaterialParaRopaData>
	{
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x0001E45A File Offset: 0x0001C65A
		public IReadOnlyDictionary<string, IReadOnlyList<MaterialParaRopaData>> materialesDePrenda
		{
			get
			{
				return this.m_materialesDePrenda;
			}
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0001E462 File Offset: 0x0001C662
		protected override IEnumerator PreInitData()
		{
			while (!AsyncSingleton<RopaParaAvatarUnificado>.instanceInitiated)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001E46C File Offset: 0x0001C66C
		protected override void InitSyncData(bool esEditorTime)
		{
			base.InitSyncData(esEditorTime);
			RopaParaAvatarUnificado instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			foreach (MapaDeMaterialesParaRopa mapaDeMaterialesParaRopa in this.m_mapas)
			{
				foreach (MaterialParaRopaData materialParaRopaData in mapaDeMaterialesParaRopa.materiales)
				{
					int num = 0;
					foreach (string text in materialParaRopaData.paraPrendasID)
					{
						if (string.IsNullOrWhiteSpace(text))
						{
							Debug.LogError("material: " + materialParaRopaData.stringDisplayId + " prenda id es invalida", mapaDeMaterialesParaRopa);
						}
						else if (!instance.Contiene(text))
						{
							Debug.LogError(string.Concat(new string[] { "material: ", materialParaRopaData.stringDisplayId, " para ropa ", text, ", no existe data para esta id de ropa" }), mapaDeMaterialesParaRopa);
						}
						else
						{
							num++;
						}
					}
					if (num == 0)
					{
						Debug.LogError("material: " + materialParaRopaData.stringDisplayId + " no es para ninguna prenda de ropa", mapaDeMaterialesParaRopa);
					}
				}
			}
			this.m_materialesDePrenda.Clear();
			foreach (MaterialParaRopaData materialParaRopaData2 in base.dataDeMateriales)
			{
				foreach (string text2 in materialParaRopaData2.paraPrendasID)
				{
					IReadOnlyList<MaterialParaRopaData> readOnlyList;
					if (!this.m_materialesDePrenda.TryGetValue(text2, out readOnlyList))
					{
						readOnlyList = new List<MaterialParaRopaData>();
						this.m_materialesDePrenda.Add(text2, readOnlyList);
					}
					((List<MaterialParaRopaData>)readOnlyList).Add(materialParaRopaData2);
				}
			}
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0001E6D8 File Offset: 0x0001C8D8
		public void InyectMap(MapaDeMaterialesParaRopa map)
		{
			if (map == null)
			{
				throw new ArgumentNullException("map", "map null reference.");
			}
			this.m_mapas.Add(map);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0001E700 File Offset: 0x0001C900
		[Obsolete("", true)]
		public void ObtenerDataDeMaterialesParaPrendaID(string ropaID, ICollection<MaterialParaRopaData> result)
		{
			for (int i = 0; i < base.dataDeMateriales.Count; i++)
			{
				MaterialParaRopaData materialParaRopaData = base.dataDeMateriales[i];
				if (materialParaRopaData.EsParaRopaId(ropaID))
				{
					result.Add(materialParaRopaData);
				}
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0001E740 File Offset: 0x0001C940
		public string ConvertirID(long materialID)
		{
			string text;
			if (!this.m_conversorDeIDs.TryGetValue(materialID, out text))
			{
				Debug.LogWarning("no se pudo convertir id antigua: " + materialID.ToString() + " a id nueva");
				return null;
			}
			return text;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0001E77C File Offset: 0x0001C97C
		public void LoadPosiblesMaterialesDePrenda(string prendaID, List<List<MaterialParaRopaData>> resultadoListaPorIndex, SimplePoolDeCollection<List<MaterialParaRopaData>, MaterialParaRopaData> opcionalPool = null)
		{
			if (resultadoListaPorIndex == null)
			{
				throw new ArgumentNullException("resultadoListaPorIndex", "resultadoListaPorIndex null reference.");
			}
			if (opcionalPool != null)
			{
				for (int i = 0; i < resultadoListaPorIndex.Count; i++)
				{
					opcionalPool.ReturnItem(resultadoListaPorIndex[i]);
				}
			}
			resultadoListaPorIndex.Clear();
			MapaDeRopa.RopaData ropaData = AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerData(prendaID);
			if (ropaData == null)
			{
				return;
			}
			IReadOnlyList<MaterialParaRopaData> readOnlyList;
			if (!this.m_materialesDePrenda.TryGetValue(prendaID, out readOnlyList))
			{
				return;
			}
			int num = Mathf.Clamp(ropaData.cantidadDeMateriales, 0, 100);
			for (int j = 0; j < num; j++)
			{
				List<MaterialParaRopaData> list;
				if (opcionalPool != null)
				{
					list = opcionalPool.GetItem();
				}
				else
				{
					list = new List<MaterialParaRopaData>();
				}
				for (int k = 0; k < readOnlyList.Count; k++)
				{
					MaterialParaRopaData materialParaRopaData = readOnlyList[k];
					if (materialParaRopaData.indexes.Contains(j))
					{
						list.Add(materialParaRopaData);
					}
				}
				if (list.Count == 0)
				{
					string[] array = new string[5];
					array[0] = "Prenda ";
					array[1] = prendaID;
					array[2] = " mat slot ";
					int num2 = 3;
					List<MaterialParaRopaData> list2 = list;
					array[num2] = ((list2 != null) ? list2.ToString() : null);
					array[4] = " has no mats";
					Debug.LogError(string.Concat(array), this);
				}
				resultadoListaPorIndex.Add(list);
			}
			if (resultadoListaPorIndex.Count == 0)
			{
				Debug.LogError("Prenda " + prendaID + " has no mats", this);
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0001E8C2 File Offset: 0x0001CAC2
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				text = "Test All Pendas",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0001E8DC File Offset: 0x0001CADC
		public override void Aplicar1()
		{
			base.Aplicar1();
			foreach (KeyValuePair<string, IReadOnlyList<MaterialParaRopaData>> keyValuePair in this.m_materialesDePrenda)
			{
				Debug.LogWarning("___Checking PRENDA " + keyValuePair.Key);
				foreach (MaterialParaRopaData materialParaRopaData in keyValuePair.Value)
				{
					Debug.LogWarning("____Checking MATERIAL " + materialParaRopaData.stringId);
					if (materialParaRopaData.IsPostInitValid())
					{
						Debug.LogWarning("is valid");
					}
					else
					{
						Debug.LogError("is not valid", base.mapaDeMaterial[materialParaRopaData.stringId]);
					}
					if (materialParaRopaData.address != null)
					{
						Debug.LogWarning("has addres");
					}
					else
					{
						Debug.LogError("has no addres", base.mapaDeMaterial[materialParaRopaData.stringId]);
					}
					if (materialParaRopaData.chanceMaterial > 0f)
					{
						Debug.LogWarning("has chance");
					}
					else
					{
						Debug.LogWarning("has no chance", base.mapaDeMaterial[materialParaRopaData.stringId]);
					}
					if (materialParaRopaData.indexes.Count > 0)
					{
						Debug.LogWarning("has indexes");
					}
					else
					{
						Debug.LogError("has no indexes", base.mapaDeMaterial[materialParaRopaData.stringId]);
					}
					if (materialParaRopaData.indexes.Distinct<int>().Count<int>() == materialParaRopaData.indexes.Count)
					{
						Debug.LogWarning("has no indexes duplicated");
					}
					else
					{
						Debug.LogError("has duplicated indexes", base.mapaDeMaterial[materialParaRopaData.stringId]);
					}
					Debug.LogWarning("____" + materialParaRopaData.stringId + " was checked");
				}
				List<List<MaterialParaRopaData>> list = new List<List<MaterialParaRopaData>>();
				this.LoadPosiblesMaterialesDePrenda(keyValuePair.Key, list, null);
				Debug.LogWarning("___" + keyValuePair.Key + " was checked");
			}
		}

		// Token: 0x04000448 RID: 1096
		[NonSerialized]
		private Dictionary<string, IReadOnlyList<MaterialParaRopaData>> m_materialesDePrenda = new Dictionary<string, IReadOnlyList<MaterialParaRopaData>>();

		// Token: 0x04000449 RID: 1097
		[SerializeField]
		private LongKeyStringValueDictionary m_conversorDeIDs = new LongKeyStringValueDictionary();
	}
}
