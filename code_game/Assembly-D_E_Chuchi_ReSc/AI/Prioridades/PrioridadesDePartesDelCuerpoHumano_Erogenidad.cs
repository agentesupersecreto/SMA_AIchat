using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Prioridades
{
	// Token: 0x020003CE RID: 974
	public class PrioridadesDePartesDelCuerpoHumano_Erogenidad : CustomMonobehaviour, IParteDelCuerpoHumanoPrioridadesContexto
	{
		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06001510 RID: 5392 RVA: 0x00059BA2 File Offset: 0x00057DA2
		// (set) Token: 0x06001511 RID: 5393 RVA: 0x00059BAA File Offset: 0x00057DAA
		public Sexo para { get; set; }

		// Token: 0x06001512 RID: 5394 RVA: 0x00059BB4 File Offset: 0x00057DB4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			Character componentEnRoot = this.GetComponentEnRoot(false);
			componentEnRoot.loadedAI += this.InitPrioridades;
			this.para = componentEnRoot.sexo;
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x00059C18 File Offset: 0x00057E18
		private static float Visual(ParteDelCuerpoHumano parteEstimulada, MapaDeEmociones mapas)
		{
			return PrioridadesDePartesDelCuerpoHumano_Erogenidad.ModDeParte(parteEstimulada, mapas.gruposDePartesHumanas.erogenoVisual, mapas.maxEmocionValuePorGrupo.placer);
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x00059C36 File Offset: 0x00057E36
		private static float Tactil(ParteDelCuerpoHumano parteEstimulada, MapaDeEmociones mapas)
		{
			return PrioridadesDePartesDelCuerpoHumano_Erogenidad.ModDeParte(parteEstimulada, mapas.gruposDePartesHumanas.erogeno, mapas.maxEmocionValuePorGrupo.placer);
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x00059C36 File Offset: 0x00057E36
		private static float Coital(ParteDelCuerpoHumano parteEstimulada, MapaDeEmociones mapas)
		{
			return PrioridadesDePartesDelCuerpoHumano_Erogenidad.ModDeParte(parteEstimulada, mapas.gruposDePartesHumanas.erogeno, mapas.maxEmocionValuePorGrupo.placer);
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x00059C54 File Offset: 0x00057E54
		private static float ModDeParte(ParteDelCuerpoHumano parteEstimulada, PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo, FloatPorGrupoDicc maxEmocionValuePorGrupo)
		{
			GrupoQueCompartenValores grupoDeParte = mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteEstimulada);
			return maxEmocionValuePorGrupo[grupoDeParte].valor * 0.333f;
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06001517 RID: 5399 RVA: 0x00005F51 File Offset: 0x00004151
		public PrioridadDeParteDelCuerpoHumanoContexto contexto
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x00059C7C File Offset: 0x00057E7C
		private void InitPrioridades(Character obj)
		{
			this.m_prioridadCoitalGetter = new Func<ParteDelCuerpoHumano, float>(this.GetPrioridadCoital);
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				this.m_prioridadesVisuales.Add(enumValoresInt[i], float.MinValue);
				this.m_prioridadesTactiles.Add(enumValoresInt[i], float.MinValue);
				this.m_todasLasPartes.Add((ParteDelCuerpoHumano)enumValoresInt[i]);
			}
			this.m_prioridadesCoitales.Add(32, float.MinValue);
			this.m_prioridadesCoitales.Add(31, float.MinValue);
			this.m_prioridadesCoitales.Add(9, float.MinValue);
			this.UpdatePrioridades();
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x00059D38 File Offset: 0x00057F38
		private float GetPrioridadCoital(ParteDelCuerpoHumano parte)
		{
			if (parte == ParteDelCuerpoHumano.bocaInterno)
			{
				return this.m_prioridadesCoitales[9];
			}
			if (parte == ParteDelCuerpoHumano.ano)
			{
				return this.m_prioridadesCoitales[31];
			}
			if (parte == ParteDelCuerpoHumano.vag)
			{
				return this.m_prioridadesCoitales[32];
			}
			return this.m_prioridadesTactiles[(int)parte] * 0.1f;
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x00059D90 File Offset: 0x00057F90
		private void CheckUpdatePrioridadesVisuales()
		{
			if (this.m_prioridadesVisualesUpdateID.IsCurrent())
			{
				return;
			}
			this.m_prioridadesVisualesUpdateID = ForcedUpdateId.current;
			this.UpdatePrioridadesVisuales();
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x00059DB1 File Offset: 0x00057FB1
		private void CheckUpdatePrioridadesTactiles()
		{
			if (this.m_prioridadesTactilesUpdateID.IsCurrent())
			{
				return;
			}
			this.m_prioridadesTactilesUpdateID = ForcedUpdateId.current;
			this.UpdatePrioridadesTactiles();
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x00059DD2 File Offset: 0x00057FD2
		private void CheckUpdatePrioridadesCoitales()
		{
			if (this.m_prioridadesCoitalesUpdateID.IsCurrent())
			{
				return;
			}
			this.m_prioridadesCoitalesUpdateID = ForcedUpdateId.current;
			this.UpdatePrioridadesCoitales();
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x00059DF3 File Offset: 0x00057FF3
		public void UpdatePrioridades()
		{
			this.UpdatePrioridadesVisuales();
			this.UpdatePrioridadesTactiles();
			this.UpdatePrioridadesCoitales();
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x00059E08 File Offset: 0x00058008
		private void UpdatePrioridadesVisuales()
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			MapaDeEmociones emociones = this.m_Personalidad.currentPersonalidad.emociones;
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				int num = enumValoresInt[i];
				this.m_prioridadesVisuales[num] = PrioridadesDePartesDelCuerpoHumano_Erogenidad.Visual((ParteDelCuerpoHumano)num, emociones);
			}
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x00059E64 File Offset: 0x00058064
		private void UpdatePrioridadesTactiles()
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			MapaDeEmociones emociones = this.m_Personalidad.currentPersonalidad.emociones;
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				int num = enumValoresInt[i];
				this.m_prioridadesTactiles[num] = PrioridadesDePartesDelCuerpoHumano_Erogenidad.Tactil((ParteDelCuerpoHumano)num, emociones);
			}
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x00059EC0 File Offset: 0x000580C0
		private void UpdatePrioridadesCoitales()
		{
			this.CheckUpdatePrioridadesTactiles();
			MapaDeEmociones emociones = this.m_Personalidad.currentPersonalidad.emociones;
			this.m_prioridadesCoitales[32] = PrioridadesDePartesDelCuerpoHumano_Erogenidad.Coital(ParteDelCuerpoHumano.vag, emociones);
			this.m_prioridadesCoitales[31] = PrioridadesDePartesDelCuerpoHumano_Erogenidad.Coital(ParteDelCuerpoHumano.ano, emociones);
			this.m_prioridadesCoitales[9] = PrioridadesDePartesDelCuerpoHumano_Erogenidad.Coital(ParteDelCuerpoHumano.bocaInterno, emociones);
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x00059F23 File Offset: 0x00058123
		public float PrioridadVisual(ParteDelCuerpoHumano parte)
		{
			return this.m_prioridadesVisuales[(int)parte];
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x00059F31 File Offset: 0x00058131
		public float PrioridadTactil(ParteDelCuerpoHumano parte)
		{
			return this.m_prioridadesTactiles[(int)parte];
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x00059F3F File Offset: 0x0005813F
		public float PrioridadCoital(ParteDelCuerpoHumano parte)
		{
			return this.GetPrioridadCoital(parte);
		}

		// Token: 0x06001524 RID: 5412 RVA: 0x00059F48 File Offset: 0x00058148
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesVisuales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMayorPrioridad(list, this.m_prioridadesVisuales);
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x00059F6F File Offset: 0x0005816F
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesVisuales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMenorPrioridad(list, this.m_prioridadesVisuales);
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x00059F96 File Offset: 0x00058196
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesTactiles();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMayorPrioridad(list, this.m_prioridadesTactiles);
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x00059FBD File Offset: 0x000581BD
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesTactiles();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMenorPrioridad(list, this.m_prioridadesTactiles);
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x00059FE4 File Offset: 0x000581E4
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesCoitales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMayorPrioridad(list, this.m_prioridadCoitalGetter);
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x0005A00B File Offset: 0x0005820B
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesCoitales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMenorPrioridad(list, this.m_prioridadCoitalGetter);
		}

		// Token: 0x04001109 RID: 4361
		public const float normalizacion = 0.333f;

		// Token: 0x0400110B RID: 4363
		private Personalidad m_Personalidad;

		// Token: 0x0400110C RID: 4364
		private ForcedUpdateId m_prioridadesVisualesUpdateID;

		// Token: 0x0400110D RID: 4365
		private ForcedUpdateId m_prioridadesTactilesUpdateID;

		// Token: 0x0400110E RID: 4366
		private ForcedUpdateId m_prioridadesCoitalesUpdateID;

		// Token: 0x0400110F RID: 4367
		private Dictionary<int, float> m_prioridadesVisuales = new Dictionary<int, float>();

		// Token: 0x04001110 RID: 4368
		private Dictionary<int, float> m_prioridadesTactiles = new Dictionary<int, float>();

		// Token: 0x04001111 RID: 4369
		private Dictionary<int, float> m_prioridadesCoitales = new Dictionary<int, float>();

		// Token: 0x04001112 RID: 4370
		private List<ParteDelCuerpoHumano> m_todasLasPartes = new List<ParteDelCuerpoHumano>();

		// Token: 0x04001113 RID: 4371
		private Func<ParteDelCuerpoHumano, float> m_prioridadCoitalGetter;
	}
}
