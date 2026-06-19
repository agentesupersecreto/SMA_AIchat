using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica.Handlers.Memoria
{
	// Token: 0x0200006A RID: 106
	[MemoriaFunctions]
	public static class MemoriaDePiscinaDeSujetosUtil
	{
		// Token: 0x060004D5 RID: 1237 RVA: 0x00011650 File Offset: 0x0000F850
		public static void LeerIDs(string rutaDeIDs, string PiscinaID, IList<string> ids)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = rutaDeIDs + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			if (jsonMemoryNode != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in jsonMemoryNode.data)
				{
					ids.Add(keyValuePair.Key);
				}
			}
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000116C8 File Offset: 0x0000F8C8
		public static void EscribirIDs<TSujetoIdentificable>(string rutaDeIDs, string PiscinaID, IReadOnlyList<TSujetoIdentificable> sujetos) where TSujetoIdentificable : ISujetoIdentificable
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = rutaDeIDs + PiscinaID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.EscribirDeep(text);
			foreach (TSujetoIdentificable tsujetoIdentificable in sujetos)
			{
				jsonMemoryNode.AddData(tsujetoIdentificable.sujetoID.ToString(), "Key es ID de sujeto Apariencia", true);
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00011754 File Offset: 0x0000F954
		public static void BorrarIDs(string rutaDeIDs, string PiscinaID)
		{
			if (!SingletonV2<MemoriaJson>.IsInScene)
			{
				SingletonV2<MemoriaJson>.TryIniciar();
			}
			string text = rutaDeIDs + PiscinaID;
			GlobalSingletonV2<MemoriaJson>.instance.RemoverDeep(text);
		}
	}
}
