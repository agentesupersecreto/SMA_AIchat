using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Prioridades
{
	// Token: 0x020003D0 RID: 976
	public class PrioridadesDePartesDelCuerpoHumano_Sensibilidad : CustomMonobehaviour, IParteDelCuerpoHumanoPrioridadesContexto
	{
		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06001542 RID: 5442 RVA: 0x0005A4E0 File Offset: 0x000586E0
		// (set) Token: 0x06001543 RID: 5443 RVA: 0x0005A4E8 File Offset: 0x000586E8
		public Sexo para { get; set; }

		// Token: 0x06001544 RID: 5444 RVA: 0x0005A4F4 File Offset: 0x000586F4
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

		// Token: 0x06001545 RID: 5445 RVA: 0x0005A558 File Offset: 0x00058758
		private static float Visual(ParteDelCuerpoHumano parteEstimulada, MapaDeEmociones mapas)
		{
			return PrioridadesDePartesDelCuerpoHumano_Sensibilidad.ModDeParte(parteEstimulada, ParteQuePuedeEstimular.ojos, mapas.gruposDePartesHumanas.seinsibilidad, mapas.gruposDePartesEstimulantes.seinsibilidad, mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulados, mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulantes);
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x0005A591 File Offset: 0x00058791
		private static float Tactil(ParteDelCuerpoHumano parteEstimulada, MapaDeEmociones mapas)
		{
			return PrioridadesDePartesDelCuerpoHumano_Sensibilidad.ModDeParte(parteEstimulada, ParteQuePuedeEstimular.manos, mapas.gruposDePartesHumanas.seinsibilidad, mapas.gruposDePartesEstimulantes.seinsibilidad, mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulados, mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulantes);
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x0005A5C6 File Offset: 0x000587C6
		private static float Coital(ParteDelCuerpoHumano parteEstimulada, MapaDeEmociones mapas)
		{
			return PrioridadesDePartesDelCuerpoHumano_Sensibilidad.ModDeParte(parteEstimulada, ParteQuePuedeEstimular.pene, mapas.gruposDePartesHumanas.seinsibilidad, mapas.gruposDePartesEstimulantes.seinsibilidad, mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulados, mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulantes);
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x0005A5FC File Offset: 0x000587FC
		private static float ModDeParte(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular estimulante, PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo, PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo, FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada, FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante)
		{
			GrupoQueCompartenValores grupoDeParte = mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteEstimulada);
			GrupoQueCompartenValores grupoDeParte2 = mapaDeParteEstimulanteGrupo.GetGrupoDeParte(estimulante);
			float valor = modEstimuloGeneradoPorGrupoDeParteEstimulada[grupoDeParte].valor;
			float valor2 = modEstimuloGeneradoPorGrupoDeParteEstimulante[grupoDeParte2].valor;
			return valor * valor2 * 15f;
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06001549 RID: 5449 RVA: 0x00006318 File Offset: 0x00004518
		public PrioridadDeParteDelCuerpoHumanoContexto contexto
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor;
			}
		}

		// Token: 0x0600154A RID: 5450 RVA: 0x0005A63C File Offset: 0x0005883C
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

		// Token: 0x0600154B RID: 5451 RVA: 0x0005A6F8 File Offset: 0x000588F8
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

		// Token: 0x0600154C RID: 5452 RVA: 0x0005A750 File Offset: 0x00058950
		private void CheckUpdatePrioridadesVisuales()
		{
			if (this.m_prioridadesVisualesUpdateID.IsCurrent())
			{
				return;
			}
			this.m_prioridadesVisualesUpdateID = ForcedUpdateId.current;
			this.UpdatePrioridadesVisuales();
		}

		// Token: 0x0600154D RID: 5453 RVA: 0x0005A771 File Offset: 0x00058971
		private void CheckUpdatePrioridadesTactiles()
		{
			if (this.m_prioridadesTactilesUpdateID.IsCurrent())
			{
				return;
			}
			this.m_prioridadesTactilesUpdateID = ForcedUpdateId.current;
			this.UpdatePrioridadesTactiles();
		}

		// Token: 0x0600154E RID: 5454 RVA: 0x0005A792 File Offset: 0x00058992
		private void CheckUpdatePrioridadesCoitales()
		{
			if (this.m_prioridadesCoitalesUpdateID.IsCurrent())
			{
				return;
			}
			this.m_prioridadesCoitalesUpdateID = ForcedUpdateId.current;
			this.UpdatePrioridadesCoitales();
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x0005A7B3 File Offset: 0x000589B3
		public void UpdatePrioridades()
		{
			this.UpdatePrioridadesVisuales();
			this.UpdatePrioridadesTactiles();
			this.UpdatePrioridadesCoitales();
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x0005A7C8 File Offset: 0x000589C8
		private void UpdatePrioridadesVisuales()
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			MapaDeEmociones emociones = this.m_Personalidad.currentPersonalidad.emociones;
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				int num = enumValoresInt[i];
				this.m_prioridadesVisuales[num] = PrioridadesDePartesDelCuerpoHumano_Sensibilidad.Visual((ParteDelCuerpoHumano)num, emociones);
			}
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x0005A824 File Offset: 0x00058A24
		private void UpdatePrioridadesTactiles()
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			MapaDeEmociones emociones = this.m_Personalidad.currentPersonalidad.emociones;
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				int num = enumValoresInt[i];
				this.m_prioridadesTactiles[num] = PrioridadesDePartesDelCuerpoHumano_Sensibilidad.Tactil((ParteDelCuerpoHumano)num, emociones);
			}
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x0005A880 File Offset: 0x00058A80
		private void UpdatePrioridadesCoitales()
		{
			this.CheckUpdatePrioridadesTactiles();
			MapaDeEmociones emociones = this.m_Personalidad.currentPersonalidad.emociones;
			this.m_prioridadesCoitales[32] = PrioridadesDePartesDelCuerpoHumano_Sensibilidad.Coital(ParteDelCuerpoHumano.vag, emociones);
			this.m_prioridadesCoitales[31] = PrioridadesDePartesDelCuerpoHumano_Sensibilidad.Coital(ParteDelCuerpoHumano.ano, emociones);
			this.m_prioridadesCoitales[9] = PrioridadesDePartesDelCuerpoHumano_Sensibilidad.Coital(ParteDelCuerpoHumano.bocaInterno, emociones);
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x0005A8E3 File Offset: 0x00058AE3
		public float PrioridadVisual(ParteDelCuerpoHumano parte)
		{
			return this.m_prioridadesVisuales[(int)parte];
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x0005A8F1 File Offset: 0x00058AF1
		public float PrioridadTactil(ParteDelCuerpoHumano parte)
		{
			return this.m_prioridadesTactiles[(int)parte];
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x0005A8FF File Offset: 0x00058AFF
		public float PrioridadCoital(ParteDelCuerpoHumano parte)
		{
			return this.GetPrioridadCoital(parte);
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x0005A908 File Offset: 0x00058B08
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesVisuales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMayorPrioridad(list, this.m_prioridadesVisuales);
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x0005A92F File Offset: 0x00058B2F
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesVisuales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMenorPrioridad(list, this.m_prioridadesVisuales);
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x0005A956 File Offset: 0x00058B56
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesTactiles();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMayorPrioridad(list, this.m_prioridadesTactiles);
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x0005A97D File Offset: 0x00058B7D
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesTactiles();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMenorPrioridad(list, this.m_prioridadesTactiles);
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x0005A9A4 File Offset: 0x00058BA4
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesCoitales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMayorPrioridad(list, this.m_prioridadCoitalGetter);
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x0005A9CB File Offset: 0x00058BCB
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesCoitales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMenorPrioridad(list, this.m_prioridadCoitalGetter);
		}

		// Token: 0x0400111F RID: 4383
		public const float normalizacion = 15f;

		// Token: 0x04001120 RID: 4384
		private Personalidad m_Personalidad;

		// Token: 0x04001122 RID: 4386
		private ForcedUpdateId m_prioridadesVisualesUpdateID;

		// Token: 0x04001123 RID: 4387
		private ForcedUpdateId m_prioridadesTactilesUpdateID;

		// Token: 0x04001124 RID: 4388
		private ForcedUpdateId m_prioridadesCoitalesUpdateID;

		// Token: 0x04001125 RID: 4389
		private Dictionary<int, float> m_prioridadesVisuales = new Dictionary<int, float>();

		// Token: 0x04001126 RID: 4390
		private Dictionary<int, float> m_prioridadesTactiles = new Dictionary<int, float>();

		// Token: 0x04001127 RID: 4391
		private Dictionary<int, float> m_prioridadesCoitales = new Dictionary<int, float>();

		// Token: 0x04001128 RID: 4392
		private List<ParteDelCuerpoHumano> m_todasLasPartes = new List<ParteDelCuerpoHumano>();

		// Token: 0x04001129 RID: 4393
		private Func<ParteDelCuerpoHumano, float> m_prioridadCoitalGetter;
	}
}
