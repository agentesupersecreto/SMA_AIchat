using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000F8 RID: 248
	public abstract class RopaParaAvatarBase<T> : AsyncSingleton<T>, IRopaParaAvatar where T : RopaParaAvatarBase<T>
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x0001C708 File Offset: 0x0001A908
		public static ICollection<string> ids
		{
			get
			{
				return AsyncSingleton<T>.instance.m_ropaDisponibleV2.Keys;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600061C RID: 1564 RVA: 0x0001C71E File Offset: 0x0001A91E
		public static ICollection<string> labels
		{
			get
			{
				return AsyncSingleton<T>.instance.m_ropaDisponibleV2.Values.Select((MapaDeRopa.RopaData v) => v.stringDisplayId).ToArray<string>();
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x0001C75D File Offset: 0x0001A95D
		public IReadOnlyDictionary<string, MapaDeRopa.RopaData> dataDeRopaPorID
		{
			get
			{
				return this.m_ropaDisponibleV2;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600061E RID: 1566 RVA: 0x0001C765 File Offset: 0x0001A965
		public IReadOnlyDictionary<MapaDeRopa.TipoDePrenda, IReadOnlyList<MapaDeRopa.RopaData>> prendasPorTipo
		{
			get
			{
				return this.m_prendasPorTipo;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x0001C76D File Offset: 0x0001A96D
		public IReadOnlyDictionary<MapaDeRopa.RopaData, List<MapaDeRopa.RopaData>> subPrendasDePrenda
		{
			get
			{
				return this.m_subPrendasDePrenda;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x0001C775 File Offset: 0x0001A975
		[Obsolete("still works, but returns the first parent")]
		public IReadOnlyDictionary<MapaDeRopa.RopaData, MapaDeRopa.RopaData> padreDePrenda
		{
			get
			{
				return this.m_padreDePrenda;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x0001C77D File Offset: 0x0001A97D
		public IReadOnlyDictionary<MapaDeRopa.RopaData, List<MapaDeRopa.RopaData>> padresDePrenda
		{
			get
			{
				return this.m_padresDePrenda;
			}
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0001C788 File Offset: 0x0001A988
		protected override void InitSyncData(bool esEditorTime)
		{
			this.m_ropaDisponibleV2 = new Dictionary<string, MapaDeRopa.RopaData>();
			List<ValueTuple<MapaDeRopa.RopaData, MapaDeRopa>> list = new List<ValueTuple<MapaDeRopa.RopaData, MapaDeRopa>>();
			foreach (MapaDeRopa mapaDeRopa in this.m_mapas)
			{
				foreach (MapaDeRopa.RopaData ropaData in mapaDeRopa.piezas)
				{
					if (!ropaData.IsPreInitValid())
					{
						Debug.LogError("item de ropa no es pre init valido name: " + ropaData.nombreCorto + " Id: " + ropaData.stringId, mapaDeRopa);
					}
					else
					{
						if (!ropaData.iniciado)
						{
							ropaData.Init();
						}
						if (!ropaData.IsPostInitValid())
						{
							Debug.LogError("item de ropa no es post init valido name: " + ropaData.nombreCorto + " Id: " + ropaData.stringId, mapaDeRopa);
						}
						else
						{
							this.FixCubreAndSex(mapaDeRopa);
							list.Add(new ValueTuple<MapaDeRopa.RopaData, MapaDeRopa>(ropaData, mapaDeRopa));
						}
					}
				}
			}
			this.m_prendasPorTipo.Clear();
			foreach (object obj in typeof(MapaDeRopa.TipoDePrenda).GetEnumValoresObject())
			{
				MapaDeRopa.TipoDePrenda tipoDePrenda = (MapaDeRopa.TipoDePrenda)obj;
				this.m_prendasPorTipo.Add(tipoDePrenda, new List<MapaDeRopa.RopaData>());
			}
			foreach (ValueTuple<MapaDeRopa.RopaData, MapaDeRopa> valueTuple in list)
			{
				MapaDeRopa.RopaData item = valueTuple.Item1;
				if (this.m_ropaDisponibleV2.ContainsKey(item.stringId))
				{
					Debug.LogError("item de ropa con id repetido id: " + item.stringId + "  name: " + item.nombreCompleto, valueTuple.Item2);
				}
				else
				{
					this.m_ropaDisponibleV2.Add(item.stringId, item);
					IReadOnlyList<MapaDeRopa.RopaData> readOnlyList;
					if (!this.m_prendasPorTipo.TryGetValue(item.tipoDePrenda, out readOnlyList))
					{
						readOnlyList = new List<MapaDeRopa.RopaData>();
						this.m_prendasPorTipo.Add(item.tipoDePrenda, readOnlyList);
					}
					((List<MapaDeRopa.RopaData>)readOnlyList).Add(item);
				}
			}
			foreach (ValueTuple<MapaDeRopa.RopaData, MapaDeRopa> valueTuple2 in list)
			{
				MapaDeRopa.RopaData item2 = valueTuple2.Item1;
				if (!string.IsNullOrWhiteSpace(item2.idParaMaterialesString) && !this.m_ropaDisponibleV2.ContainsKey(item2.idParaMaterialesString))
				{
					Debug.LogError("id para materiales no existe : " + valueTuple2.Item1.idParaMaterialesString + " name: " + valueTuple2.Item1.nombreCompleto, valueTuple2.Item2);
				}
				foreach (MapaDeRopa.RopaData.Interacciones interacciones in item2.interacciones)
				{
					if (!this.m_ropaDisponibleV2.ContainsKey(interacciones.subPrendaIDString))
					{
						Debug.LogError(string.Concat(new string[]
						{
							"sub prenda id: ",
							valueTuple2.Item1.idParaMaterialesString,
							" de interaccion: ",
							interacciones.id.ToString(),
							" no existe, name: ",
							valueTuple2.Item1.nombreCompleto
						}), valueTuple2.Item2);
					}
				}
			}
			this.m_subPrendasDePrenda = new Dictionary<MapaDeRopa.RopaData, List<MapaDeRopa.RopaData>>();
			this.m_padreDePrenda = new Dictionary<MapaDeRopa.RopaData, MapaDeRopa.RopaData>();
			this.m_padresDePrenda = new Dictionary<MapaDeRopa.RopaData, List<MapaDeRopa.RopaData>>();
			foreach (ValueTuple<MapaDeRopa.RopaData, MapaDeRopa> valueTuple3 in list)
			{
				MapaDeRopa.RopaData item3 = valueTuple3.Item1;
				List<MapaDeRopa.RopaData> list2;
				if (!this.m_subPrendasDePrenda.TryGetValue(item3, out list2))
				{
					list2 = new List<MapaDeRopa.RopaData>();
					this.m_subPrendasDePrenda.Add(item3, list2);
				}
				foreach (MapaDeRopa.RopaData.Interacciones interacciones2 in item3.interacciones)
				{
					MapaDeRopa.RopaData ropaData2;
					if (this.dataDeRopaPorID.TryGetValue(interacciones2.subPrendaIDString, out ropaData2))
					{
						this.m_padreDePrenda.TryAdd(ropaData2, item3);
						List<MapaDeRopa.RopaData> list3;
						if (!this.m_padresDePrenda.TryGetValue(ropaData2, out list3))
						{
							list3 = new List<MapaDeRopa.RopaData>();
							this.m_padresDePrenda.Add(ropaData2, list3);
						}
						if (!list3.Contains(item3))
						{
							list3.Add(item3);
						}
						if (!list2.Contains(ropaData2))
						{
							list2.Add(ropaData2);
						}
					}
				}
			}
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0001CCEC File Offset: 0x0001AEEC
		protected void FixCubreAndSex(MapaDeRopa map)
		{
			if (map == null)
			{
				throw new ArgumentNullException("map", "map null reference.");
			}
			int i = 0;
			while (i < map.piezas.Count)
			{
				MapaDeRopa.RopaData ropaData = map.piezas[i];
				RopaCubre ropaCubre = ropaData.cubreFlag;
				Sexo paraSexo = ropaData.paraSexo;
				if (paraSexo == Sexo.masculino)
				{
					ropaCubre &= ~(RopaCubre.labiosVaginales | RopaCubre.vaginaHole);
					goto IL_006F;
				}
				if (paraSexo == Sexo.femenino)
				{
					ropaCubre &= ~(RopaCubre.pene | RopaCubre.testiculos);
					goto IL_006F;
				}
				Debug.LogError("pieza de ropa: " + ropaData.stringDisplayId + " sexo es incorecto");
				IL_0076:
				i++;
				continue;
				IL_006F:
				ropaData.cubreFlag = ropaCubre;
				goto IL_0076;
			}
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0001CD81 File Offset: 0x0001AF81
		public bool Contiene(string ropaId)
		{
			return !string.IsNullOrWhiteSpace(ropaId) && this.m_ropaDisponibleV2.ContainsKey(ropaId);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0001CD9C File Offset: 0x0001AF9C
		public bool PiezaEsMainPrenda(string ropaId)
		{
			MapaDeRopa.RopaData ropaData;
			return !string.IsNullOrWhiteSpace(ropaId) && this.m_ropaDisponibleV2.TryGetValue(ropaId, out ropaData) && !this.m_padresDePrenda.ContainsKey(ropaData);
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0001CDD4 File Offset: 0x0001AFD4
		public MapaDeRopa.RopaData ObtenerData(string ropaId)
		{
			if (string.IsNullOrWhiteSpace(ropaId))
			{
				return null;
			}
			MapaDeRopa.RopaData ropaData;
			if (!this.m_ropaDisponibleV2.TryGetValue(ropaId, out ropaData))
			{
				Debug.LogWarning("ropa de id " + ropaId + ", fallo, pieza no esta en singleton de IDs");
				return null;
			}
			return ropaData;
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0001CE14 File Offset: 0x0001B014
		public MapaDeRopa.RopaData SeleccionarFirstSubPrenda(string ropaId, Predicate<MapaDeRopa.RopaData> selector)
		{
			MapaDeRopa.RopaData ropaData = this.ObtenerData(ropaId);
			if (ropaData == null)
			{
				return null;
			}
			return RopaParaAvatarBase<T>.FindDeep(ropaData, this, selector);
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0001CE38 File Offset: 0x0001B038
		public MapaDeRopa.RopaData SeleccionarBestSubPrenda(string ropaId, Predicate<MapaDeRopa.RopaData> selector)
		{
			MapaDeRopa.RopaData ropaData = this.ObtenerData(ropaId);
			if (ropaData == null)
			{
				return null;
			}
			MapaDeRopa.RopaData ropaData2 = null;
			int num = -1;
			RopaParaAvatarBase<T>.FindBestDeep(ropaData, this, selector, ropaData.cubreFlag, ref ropaData2, ref num);
			return ropaData2;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001CE6C File Offset: 0x0001B06C
		private static MapaDeRopa.RopaData FindDeep(MapaDeRopa.RopaData data, IRopaParaAvatar ropaParaAvatar, Predicate<MapaDeRopa.RopaData> selector)
		{
			if (selector(data))
			{
				return data;
			}
			for (int i = 0; i < data.interacciones.Count; i++)
			{
				MapaDeRopa.RopaData.Interacciones interacciones = data.interacciones[i];
				MapaDeRopa.RopaData ropaData = ropaParaAvatar.ObtenerData(interacciones.subPrendaIDString);
				if (ropaData != null)
				{
					MapaDeRopa.RopaData ropaData2 = RopaParaAvatarBase<T>.FindDeep(ropaData, ropaParaAvatar, selector);
					if (ropaData2 != null)
					{
						return ropaData2;
					}
				}
			}
			return null;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0001CEC8 File Offset: 0x0001B0C8
		private static void FindBestDeep(MapaDeRopa.RopaData data, IRopaParaAvatar ropaParaAvatar, Predicate<MapaDeRopa.RopaData> selector, RopaCubre originalFlags, ref MapaDeRopa.RopaData best, ref int bestScore)
		{
			if (selector(data))
			{
				int num = RopaParaAvatarBase<T>.CountSharedFlags(originalFlags, data.cubreFlag);
				if (num > bestScore)
				{
					bestScore = num;
					best = data;
				}
			}
			for (int i = 0; i < data.interacciones.Count; i++)
			{
				MapaDeRopa.RopaData.Interacciones interacciones = data.interacciones[i];
				MapaDeRopa.RopaData ropaData = ropaParaAvatar.ObtenerData(interacciones.subPrendaIDString);
				if (ropaData != null)
				{
					RopaParaAvatarBase<T>.FindBestDeep(ropaData, ropaParaAvatar, selector, originalFlags, ref best, ref bestScore);
				}
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0001CF3C File Offset: 0x0001B13C
		private static int CountSharedFlags(RopaCubre a, RopaCubre b)
		{
			int num = (int)(a & b);
			int num2 = 0;
			while (num != 0)
			{
				num2 += num & 1;
				num >>= 1;
			}
			return num2;
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001CF60 File Offset: 0x0001B160
		[Obsolete("still works, but returns the first parent")]
		public MapaDeRopa.RopaData ObtenerRootData(string ropaId)
		{
			MapaDeRopa.RopaData ropaData = this.ObtenerData(ropaId);
			if (ropaData == null)
			{
				return null;
			}
			return this.obtenerRootData(ropaData);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0001CF84 File Offset: 0x0001B184
		[Obsolete("still works, but returns the first parent")]
		private MapaDeRopa.RopaData obtenerRootData(MapaDeRopa.RopaData data)
		{
			MapaDeRopa.RopaData ropaData;
			if (this.m_padreDePrenda.TryGetValue(data, out ropaData))
			{
				return this.obtenerRootData(ropaData);
			}
			return data;
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001CFAC File Offset: 0x0001B1AC
		public MapaDeRopa.RopaData ObtenerFirstRootData(string ropaId)
		{
			MapaDeRopa.RopaData ropaData;
			try
			{
				this.ObtenerRootData(ropaId, RopaParaAvatarBase<T>.rootsTEMP);
				if (RopaParaAvatarBase<T>.rootsTEMP.Count == 0)
				{
					ropaData = null;
				}
				else
				{
					ropaData = RopaParaAvatarBase<T>.rootsTEMP[0];
				}
			}
			finally
			{
				RopaParaAvatarBase<T>.rootsTEMP.Clear();
			}
			return ropaData;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0001D000 File Offset: 0x0001B200
		public void ObtenerRootData(string ropaId, List<MapaDeRopa.RopaData> roots)
		{
			MapaDeRopa.RopaData ropaData = this.ObtenerData(ropaId);
			if (ropaData == null)
			{
				return;
			}
			HashSet<MapaDeRopa.RopaData> hashSet = new HashSet<MapaDeRopa.RopaData>();
			hashSet.Add(ropaData);
			this.obtenerRootData(ropaData, hashSet);
			roots.AddRange(hashSet);
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0001D038 File Offset: 0x0001B238
		private void obtenerRootData(MapaDeRopa.RopaData data, HashSet<MapaDeRopa.RopaData> todosLosPadres)
		{
			List<MapaDeRopa.RopaData> list;
			if (this.m_padresDePrenda.TryGetValue(data, out list))
			{
				if (list.Count > 0)
				{
					todosLosPadres.Remove(data);
				}
				for (int i = 0; i < list.Count; i++)
				{
					todosLosPadres.Add(list[i]);
				}
				for (int j = 0; j < list.Count; j++)
				{
					this.obtenerRootData(list[j], todosLosPadres);
				}
				return;
			}
			todosLosPadres.Add(data);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0001D0B0 File Offset: 0x0001B2B0
		public void SeleccionarJerarquiaPadres(string padreRopaId, string hijoRopaId, IList<MapaDeRopa.RopaData> padres)
		{
			try
			{
				MapaDeRopa.RopaData ropaData = this.ObtenerData(padreRopaId);
				if (ropaData != null)
				{
					MapaDeRopa.RopaData ropaData2 = this.ObtenerData(hijoRopaId);
					if (ropaData2 != null)
					{
						RopaParaAvatarBase<T>.GenerarAcendencia(ropaData, this);
						List<MapaDeRopa.RopaData> list;
						if (RopaParaAvatarBase<T>.m_tempAcendencia.TryGetValue(ropaData2, out list))
						{
							for (int i = 0; i < list.Count; i++)
							{
								padres.Add(list[i]);
							}
						}
					}
				}
			}
			finally
			{
				RopaParaAvatarBase<T>.FinalizarDecendencia();
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001D124 File Offset: 0x0001B324
		private static void GenerarAcendencia(MapaDeRopa.RopaData data, IRopaParaAvatar ropaParaAvatar)
		{
			List<MapaDeRopa.RopaData> item;
			if (!RopaParaAvatarBase<T>.m_tempAcendencia.TryGetValue(data, out item))
			{
				item = RopaParaAvatarBase<T>.m_poolDeHeraquia.GetItem();
				RopaParaAvatarBase<T>.m_tempAcendencia.Add(data, item);
			}
			HashSetList<string> item2 = RopaParaAvatarBase<T>.m_poolDeSubPrendas.GetItem();
			try
			{
				for (int i = 0; i < data.interacciones.Count; i++)
				{
					MapaDeRopa.RopaData.Interacciones interacciones = data.interacciones[i];
					item2.Add(interacciones.subPrendaIDString);
				}
				for (int j = 0; j < item2.Count; j++)
				{
					MapaDeRopa.RopaData ropaData = ropaParaAvatar.ObtenerData(item2[j]);
					if (ropaData != null)
					{
						List<MapaDeRopa.RopaData> item3;
						if (!RopaParaAvatarBase<T>.m_tempAcendencia.TryGetValue(ropaData, out item3))
						{
							item3 = RopaParaAvatarBase<T>.m_poolDeHeraquia.GetItem();
							RopaParaAvatarBase<T>.m_tempAcendencia.Add(ropaData, item3);
						}
						item3.AddRange(item);
						item3.Add(data);
						RopaParaAvatarBase<T>.GenerarAcendencia(ropaData, ropaParaAvatar);
					}
				}
			}
			finally
			{
				item2.Clear();
			}
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0001D218 File Offset: 0x0001B418
		private static void FinalizarDecendencia()
		{
			foreach (KeyValuePair<MapaDeRopa.RopaData, List<MapaDeRopa.RopaData>> keyValuePair in RopaParaAvatarBase<T>.m_tempAcendencia)
			{
				List<MapaDeRopa.RopaData> value = keyValuePair.Value;
				value.Clear();
				RopaParaAvatarBase<T>.m_poolDeHeraquia.ReturnItem(value);
			}
			RopaParaAvatarBase<T>.m_tempAcendencia.Clear();
		}

		// Token: 0x04000413 RID: 1043
		[SerializeField]
		protected List<MapaDeRopa> m_mapas = new List<MapaDeRopa>();

		// Token: 0x04000414 RID: 1044
		[Obsolete("", true)]
		[NonSerialized]
		private Dictionary<int, MapaDeRopa.RopaData> m_ropaDisponible = new Dictionary<int, MapaDeRopa.RopaData>();

		// Token: 0x04000415 RID: 1045
		[NonSerialized]
		private Dictionary<string, MapaDeRopa.RopaData> m_ropaDisponibleV2 = new Dictionary<string, MapaDeRopa.RopaData>();

		// Token: 0x04000416 RID: 1046
		[NonSerialized]
		private Dictionary<MapaDeRopa.TipoDePrenda, IReadOnlyList<MapaDeRopa.RopaData>> m_prendasPorTipo = new Dictionary<MapaDeRopa.TipoDePrenda, IReadOnlyList<MapaDeRopa.RopaData>>();

		// Token: 0x04000417 RID: 1047
		private Dictionary<MapaDeRopa.RopaData, List<MapaDeRopa.RopaData>> m_subPrendasDePrenda;

		// Token: 0x04000418 RID: 1048
		private Dictionary<MapaDeRopa.RopaData, MapaDeRopa.RopaData> m_padreDePrenda;

		// Token: 0x04000419 RID: 1049
		private Dictionary<MapaDeRopa.RopaData, List<MapaDeRopa.RopaData>> m_padresDePrenda;

		// Token: 0x0400041A RID: 1050
		private static List<MapaDeRopa.RopaData> rootsTEMP = new List<MapaDeRopa.RopaData>();

		// Token: 0x0400041B RID: 1051
		private static SimplePool<List<MapaDeRopa.RopaData>> m_poolDeHeraquia = new SimplePool<List<MapaDeRopa.RopaData>>();

		// Token: 0x0400041C RID: 1052
		private static SimplePool<HashSetList<string>> m_poolDeSubPrendas = new SimplePool<HashSetList<string>>();

		// Token: 0x0400041D RID: 1053
		private static Dictionary<MapaDeRopa.RopaData, List<MapaDeRopa.RopaData>> m_tempAcendencia = new Dictionary<MapaDeRopa.RopaData, List<MapaDeRopa.RopaData>>();
	}
}
