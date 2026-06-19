using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime.Clases.Conjuntos.Version1;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x020003A7 RID: 935
	[Serializable]
	public class RazaData : IRazaInterpretadorHelper
	{
		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x060017E5 RID: 6117 RVA: 0x0007016D File Offset: 0x0006E36D
		float IRazaInterpretadorHelper.african
		{
			get
			{
				return this.african;
			}
		}

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x060017E6 RID: 6118 RVA: 0x00070175 File Offset: 0x0006E375
		float IRazaInterpretadorHelper.anime
		{
			get
			{
				return this.anime;
			}
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x060017E7 RID: 6119 RVA: 0x0007017D File Offset: 0x0006E37D
		float IRazaInterpretadorHelper.asian
		{
			get
			{
				return this.asian;
			}
		}

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x060017E8 RID: 6120 RVA: 0x00070185 File Offset: 0x0006E385
		float IRazaInterpretadorHelper.cau
		{
			get
			{
				return this.cau;
			}
		}

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x060017E9 RID: 6121 RVA: 0x0007018D File Offset: 0x0006E38D
		float IRazaInterpretadorHelper.latina
		{
			get
			{
				return this.latina;
			}
		}

		// Token: 0x060017EA RID: 6122 RVA: 0x00070198 File Offset: 0x0006E398
		public void Generate(HelperDeInterpretadorBase helper)
		{
			RazaData.GenerateCalculeData();
			MapaDeAlteracionesAparienciaFemeninaBase mapaDeAlteracionesAparienciaFemeninaBase = helper.alteradoresDeAparienciaFemenina.mapaDeValores;
			if (mapaDeAlteracionesAparienciaFemeninaBase == null)
			{
				mapaDeAlteracionesAparienciaFemeninaBase = new MapaDeAlteracionesAparienciaFemeninaIndependiente();
				helper.alteradoresDeAparienciaFemenina.mapaDeValores = mapaDeAlteracionesAparienciaFemeninaBase;
				helper.alteradoresDeAparienciaFemenina.Save();
			}
			mapaDeAlteracionesAparienciaFemeninaBase.PrepareAlteradoresDicc();
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc = mapaDeAlteracionesAparienciaFemeninaBase.preparedAlteradoresDicc;
			this.african = RazaData.GetScore(preparedAlteradoresDicc, "african");
			this.anime = RazaData.GetScore(preparedAlteradoresDicc, "anime");
			this.asian = RazaData.GetScore(preparedAlteradoresDicc, "asian");
			this.cau = RazaData.GetScore(preparedAlteradoresDicc, "cau");
			this.latina = RazaData.GetScore(preparedAlteradoresDicc, "latina");
		}

		// Token: 0x060017EB RID: 6123 RVA: 0x00070240 File Offset: 0x0006E440
		private static float GetScore(IReadOnlyDictionary<string, ModificadoresDeAlterador> currentAlteradores, string etnisidad)
		{
			float score = RazaData.GetScore(currentAlteradores, RazaData.m_ojosData[etnisidad]);
			float score2 = RazaData.GetScore(currentAlteradores, RazaData.m_caraData[etnisidad]);
			float score3 = RazaData.GetScore(currentAlteradores, RazaData.m_narizData[etnisidad]);
			float score4 = RazaData.GetScore(currentAlteradores, RazaData.m_bocaData[etnisidad]);
			float score5 = RazaData.GetScore(currentAlteradores, RazaData.m_headData[etnisidad]);
			float score6 = RazaData.GetScore(currentAlteradores, RazaData.m_pielData[etnisidad]);
			float num = 0f;
			if (RazaData.m_ojosData[etnisidad].Count > 0)
			{
				num += 1f;
			}
			if (RazaData.m_caraData[etnisidad].Count > 0)
			{
				num += 1f;
			}
			if (RazaData.m_narizData[etnisidad].Count > 0)
			{
				num += 1f;
			}
			if (RazaData.m_bocaData[etnisidad].Count > 0)
			{
				num += 1f;
			}
			if (RazaData.m_headData[etnisidad].Count > 0)
			{
				num += 1f;
			}
			if (RazaData.m_pielData[etnisidad].Count > 0)
			{
				num += 1f;
			}
			if (num == 0f)
			{
				return 0f;
			}
			return (score + score2 + score3 + score4 + score5 + score6) / num;
		}

		// Token: 0x060017EC RID: 6124 RVA: 0x00070390 File Offset: 0x0006E590
		private static float GetScore(IReadOnlyDictionary<string, ModificadoresDeAlterador> currentMods, IReadOnlyDictionary<string, ModificadoresDeAlterador> mapaMods)
		{
			if (mapaMods.Count == 0)
			{
				return 0f;
			}
			float num = 0f;
			foreach (KeyValuePair<string, ModificadoresDeAlterador> keyValuePair in mapaMods)
			{
				ModificadoresDeAlterador modificadoresDeAlterador;
				if (currentMods.TryGetValue(keyValuePair.Key, out modificadoresDeAlterador))
				{
					num += modificadoresDeAlterador.SimilitudDeModificadores(keyValuePair.Value);
				}
			}
			return num / (float)mapaMods.Count;
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x00070410 File Offset: 0x0006E610
		private static void GenerateCalculeData()
		{
			if (RazaData.m_dataHaSidoGenerada)
			{
				return;
			}
			RazaData.m_ojosData = new Dictionary<string, Dictionary<string, ModificadoresDeAlterador>>();
			RazaData.m_caraData = new Dictionary<string, Dictionary<string, ModificadoresDeAlterador>>();
			RazaData.m_narizData = new Dictionary<string, Dictionary<string, ModificadoresDeAlterador>>();
			RazaData.m_bocaData = new Dictionary<string, Dictionary<string, ModificadoresDeAlterador>>();
			RazaData.m_headData = new Dictionary<string, Dictionary<string, ModificadoresDeAlterador>>();
			RazaData.m_pielData = new Dictionary<string, Dictionary<string, ModificadoresDeAlterador>>();
			SujetoMapasFemeninosDefectoGetter instance = MapaSingleton<SujetoMapasFemeninosDefectoGetter>.instance;
			string[] nombres = DiccionarioDeStrings<DiccionarioDeConjuntoEyes1>.nombres;
			string[] nombres2 = DiccionarioDeStrings<DiccionarioDeConjuntoFace1>.nombres;
			string[] nombres3 = DiccionarioDeStrings<DiccionarioDeConjuntoNose1>.nombres;
			string[] nombres4 = DiccionarioDeStrings<DiccionarioDeConjuntoMouth1>.nombres;
			string[] nombres5 = DiccionarioDeStrings<DiccionarioDeConjuntoHead1>.nombres;
			string[] nombres6 = DiccionarioDeStrings<DiccionarioDeConjuntoSkin1>.nombres;
			Dictionary<string, ModificadoresDeAlterador> dictionary = ((MapaDeAlteracionesAparienciaFemeninaDependiente)instance.african.aparienciaFisicaMapa.@base).propios.ToDictionary((ModificadoresDeAlterador mod) => mod.alteradorName);
			RazaData.m_ojosData.Add("african", RazaData.GenerateData(nombres, dictionary));
			RazaData.m_caraData.Add("african", RazaData.GenerateData(nombres2, dictionary));
			RazaData.m_narizData.Add("african", RazaData.GenerateData(nombres3, dictionary));
			RazaData.m_bocaData.Add("african", RazaData.GenerateData(nombres4, dictionary));
			RazaData.m_headData.Add("african", RazaData.GenerateData(nombres5, dictionary));
			RazaData.m_pielData.Add("african", RazaData.GenerateData(nombres6, dictionary));
			Dictionary<string, ModificadoresDeAlterador> dictionary2 = ((MapaDeAlteracionesAparienciaFemeninaDependiente)instance.anime.aparienciaFisicaMapa.@base).propios.ToDictionary((ModificadoresDeAlterador mod) => mod.alteradorName);
			RazaData.m_ojosData.Add("anime", RazaData.GenerateData(nombres, dictionary2));
			RazaData.m_caraData.Add("anime", RazaData.GenerateData(nombres2, dictionary2));
			RazaData.m_narizData.Add("anime", RazaData.GenerateData(nombres3, dictionary2));
			RazaData.m_bocaData.Add("anime", RazaData.GenerateData(nombres4, dictionary2));
			RazaData.m_headData.Add("anime", RazaData.GenerateData(nombres5, dictionary2));
			RazaData.m_pielData.Add("anime", RazaData.GenerateData(nombres6, dictionary2));
			Dictionary<string, ModificadoresDeAlterador> dictionary3 = ((MapaDeAlteracionesAparienciaFemeninaDependiente)instance.asian.aparienciaFisicaMapa.@base).propios.ToDictionary((ModificadoresDeAlterador mod) => mod.alteradorName);
			RazaData.m_ojosData.Add("asian", RazaData.GenerateData(nombres, dictionary3));
			RazaData.m_caraData.Add("asian", RazaData.GenerateData(nombres2, dictionary3));
			RazaData.m_narizData.Add("asian", RazaData.GenerateData(nombres3, dictionary3));
			RazaData.m_bocaData.Add("asian", RazaData.GenerateData(nombres4, dictionary3));
			RazaData.m_headData.Add("asian", RazaData.GenerateData(nombres5, dictionary3));
			RazaData.m_pielData.Add("asian", RazaData.GenerateData(nombres6, dictionary3));
			Dictionary<string, ModificadoresDeAlterador> dictionary4 = ((MapaDeAlteracionesAparienciaFemeninaDependiente)instance.caucasica.aparienciaFisicaMapa.@base).propios.ToDictionary((ModificadoresDeAlterador mod) => mod.alteradorName);
			RazaData.m_ojosData.Add("cau", RazaData.GenerateData(nombres, dictionary4));
			RazaData.m_caraData.Add("cau", RazaData.GenerateData(nombres2, dictionary4));
			RazaData.m_narizData.Add("cau", RazaData.GenerateData(nombres3, dictionary4));
			RazaData.m_bocaData.Add("cau", RazaData.GenerateData(nombres4, dictionary4));
			RazaData.m_headData.Add("cau", RazaData.GenerateData(nombres5, dictionary4));
			RazaData.m_pielData.Add("cau", RazaData.GenerateData(nombres6, dictionary4));
			Dictionary<string, ModificadoresDeAlterador> dictionary5 = ((MapaDeAlteracionesAparienciaFemeninaDependiente)instance.latina.aparienciaFisicaMapa.@base).propios.ToDictionary((ModificadoresDeAlterador mod) => mod.alteradorName);
			RazaData.m_ojosData.Add("latina", RazaData.GenerateData(nombres, dictionary5));
			RazaData.m_caraData.Add("latina", RazaData.GenerateData(nombres2, dictionary5));
			RazaData.m_narizData.Add("latina", RazaData.GenerateData(nombres3, dictionary5));
			RazaData.m_bocaData.Add("latina", RazaData.GenerateData(nombres4, dictionary5));
			RazaData.m_headData.Add("latina", RazaData.GenerateData(nombres5, dictionary5));
			RazaData.m_pielData.Add("latina", RazaData.GenerateData(nombres6, dictionary5));
			RazaData.m_dataHaSidoGenerada = true;
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x00070890 File Offset: 0x0006EA90
		private static Dictionary<string, ModificadoresDeAlterador> GenerateData(string[] alteradoresNombres, Dictionary<string, ModificadoresDeAlterador> mapaAlteradores)
		{
			Dictionary<string, ModificadoresDeAlterador> dictionary = new Dictionary<string, ModificadoresDeAlterador>();
			foreach (string text in alteradoresNombres)
			{
				if (mapaAlteradores.ContainsKey(text))
				{
					dictionary.Add(text, mapaAlteradores[text]);
				}
			}
			return dictionary;
		}

		// Token: 0x0400119B RID: 4507
		[Range(0f, 1f)]
		public float african;

		// Token: 0x0400119C RID: 4508
		[Range(0f, 1f)]
		public float anime;

		// Token: 0x0400119D RID: 4509
		[Range(0f, 1f)]
		public float asian;

		// Token: 0x0400119E RID: 4510
		[Range(0f, 1f)]
		public float cau;

		// Token: 0x0400119F RID: 4511
		[Range(0f, 1f)]
		public float latina;

		// Token: 0x040011A0 RID: 4512
		private static bool m_dataHaSidoGenerada;

		// Token: 0x040011A1 RID: 4513
		private static Dictionary<string, Dictionary<string, ModificadoresDeAlterador>> m_ojosData;

		// Token: 0x040011A2 RID: 4514
		private static Dictionary<string, Dictionary<string, ModificadoresDeAlterador>> m_caraData;

		// Token: 0x040011A3 RID: 4515
		private static Dictionary<string, Dictionary<string, ModificadoresDeAlterador>> m_narizData;

		// Token: 0x040011A4 RID: 4516
		private static Dictionary<string, Dictionary<string, ModificadoresDeAlterador>> m_bocaData;

		// Token: 0x040011A5 RID: 4517
		private static Dictionary<string, Dictionary<string, ModificadoresDeAlterador>> m_headData;

		// Token: 0x040011A6 RID: 4518
		private static Dictionary<string, Dictionary<string, ModificadoresDeAlterador>> m_pielData;
	}
}
