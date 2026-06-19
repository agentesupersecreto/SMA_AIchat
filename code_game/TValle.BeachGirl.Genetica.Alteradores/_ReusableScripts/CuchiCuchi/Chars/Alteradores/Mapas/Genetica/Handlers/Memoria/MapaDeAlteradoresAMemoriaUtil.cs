using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Handlers.Memoria
{
	// Token: 0x02000078 RID: 120
	public static class MapaDeAlteradoresAMemoriaUtil
	{
		// Token: 0x060005B2 RID: 1458 RVA: 0x00014F81 File Offset: 0x00013181
		public static bool IsValid(IJsonMemoryNode memoria)
		{
			return memoria != null && (memoria.children.Count > 0 || memoria.data.Count > 0);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00014FA8 File Offset: 0x000131A8
		public static void ANode(IJsonMemoryNode result, MapaDeValoresDeAlteradoresBase mapa)
		{
			if (mapa == null)
			{
				throw new ArgumentNullException("mapa", "mapa null reference.");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			try
			{
				foreach (ModificadoresDeAlterador modificadoresDeAlterador in mapa.ObtenerAlteradorModificadores())
				{
					IJsonMemoryNode jsonMemoryNode = (IJsonMemoryNode)result.FindChildNotNull(modificadoresDeAlterador.alteradorName);
					jsonMemoryNode.AddData("Index", modificadoresDeAlterador.index, true);
					jsonMemoryNode.AddData("Symetria", modificadoresDeAlterador.symetria, true);
					jsonMemoryNode.AddData("Volatil", modificadoresDeAlterador.volatil, true);
					jsonMemoryNode.AddData("Sensible", modificadoresDeAlterador.sensible, true);
					jsonMemoryNode.AddData("IndexCount", modificadoresDeAlterador.indexCount, true);
					jsonMemoryNode.AddData("IndexMaxCount", modificadoresDeAlterador.indexMaxCount, true);
					jsonMemoryNode.AddData("Mods", modificadoresDeAlterador.modificadores, true);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x000150C0 File Offset: 0x000132C0
		private static bool AlteradorMemoriaEsValido(IJsonMemoryNode alterMemo)
		{
			return alterMemo.data.ContainsKey("Index") && alterMemo.data.ContainsKey("Mods");
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x000150E8 File Offset: 0x000132E8
		public static void AMapa(MapaDeValoresDeAlteradoresBase result, IJsonMemoryNode memoria)
		{
			if (memoria == null)
			{
				throw new ArgumentNullException("memoria", "memoria null reference.");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result", "result null reference.");
			}
			List<ModificadoresDeAlterador> list = new List<ModificadoresDeAlterador>(memoria.children.Count);
			try
			{
				foreach (IMemoryNode<string, string> memoryNode in memoria.children)
				{
					IJsonMemoryNode jsonMemoryNode = (IJsonMemoryNode)memoryNode;
					if (MapaDeAlteradoresAMemoriaUtil.AlteradorMemoriaEsValido(jsonMemoryNode))
					{
						ModificadoresDeAlterador modificadoresDeAlterador = new ModificadoresDeAlterador();
						modificadoresDeAlterador.alteradorName = jsonMemoryNode.nodeID;
						int num;
						if (jsonMemoryNode.TryFindDataInt("Index", out num))
						{
							modificadoresDeAlterador.index = num;
						}
						float num2;
						if (jsonMemoryNode.TryFindDataFloat("Symetria", out num2))
						{
							modificadoresDeAlterador.symetria = num2;
						}
						modificadoresDeAlterador.volatil = jsonMemoryNode.FindDataBool("Volatil", false);
						modificadoresDeAlterador.sensible = jsonMemoryNode.FindDataBool("Sensible", false);
						modificadoresDeAlterador.indexCount = jsonMemoryNode.FindDataInt("IndexCount", 0);
						modificadoresDeAlterador.indexMaxCount = jsonMemoryNode.FindDataInt("IndexMaxCount", 0);
						float[] array;
						if (jsonMemoryNode.TryFindDataArrayEmpty("Mods", out array))
						{
							modificadoresDeAlterador.modificadores = array;
						}
						else
						{
							modificadoresDeAlterador.modificadores = new float[0];
						}
						list.Add(modificadoresDeAlterador);
					}
				}
				result.ReemplazarAlteradorModificadores(list);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// Token: 0x0400025E RID: 606
		public const string ModsDataKEy = "Mods";
	}
}
