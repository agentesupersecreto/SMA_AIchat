using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Prioridades
{
	// Token: 0x020003CF RID: 975
	public class PrioridadesDePartesDelCuerpoHumano_Privacidad : CustomMonobehaviour, IParteDelCuerpoHumanoPrioridadesContexto
	{
		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x0600152B RID: 5419 RVA: 0x0005A066 File Offset: 0x00058266
		// (set) Token: 0x0600152C RID: 5420 RVA: 0x0005A06E File Offset: 0x0005826E
		public Sexo para { get; set; }

		// Token: 0x0600152D RID: 5421 RVA: 0x0005A078 File Offset: 0x00058278
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

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x0600152E RID: 5422 RVA: 0x0000D704 File Offset: 0x0000B904
		public PrioridadDeParteDelCuerpoHumanoContexto contexto
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x0005A0DC File Offset: 0x000582DC
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

		// Token: 0x06001530 RID: 5424 RVA: 0x0005A198 File Offset: 0x00058398
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
			return this.m_prioridadesVisuales[(int)parte] * 0.1f;
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x0005A1F0 File Offset: 0x000583F0
		private void CheckUpdatePrioridadesVisuales()
		{
			if (this.m_prioridadesVisualesUpdateID.IsCurrent())
			{
				return;
			}
			this.m_prioridadesVisualesUpdateID = ForcedUpdateId.current;
			this.UpdatePrioridadesVisuales();
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x0005A211 File Offset: 0x00058411
		private void CheckUpdatePrioridadesTactiles()
		{
			if (this.m_prioridadesTactilesUpdateID.IsCurrent())
			{
				return;
			}
			this.m_prioridadesTactilesUpdateID = ForcedUpdateId.current;
			this.UpdatePrioridadesTactiles();
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x0005A232 File Offset: 0x00058432
		private void CheckUpdatePrioridadesCoitales()
		{
			if (this.m_prioridadesCoitalesUpdateID.IsCurrent())
			{
				return;
			}
			this.m_prioridadesCoitalesUpdateID = ForcedUpdateId.current;
			this.UpdatePrioridadesCoitales();
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0005A253 File Offset: 0x00058453
		public void UpdatePrioridades()
		{
			this.UpdatePrioridadesVisuales();
			this.UpdatePrioridadesTactiles();
			this.UpdatePrioridadesCoitales();
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x0005A268 File Offset: 0x00058468
		private void UpdatePrioridadesVisuales()
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			MapaDeEmociones emociones = this.m_Personalidad.currentPersonalidad.emociones;
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				int num = enumValoresInt[i];
				this.m_prioridadesVisuales[num] = ConsentNecesario.NecesarioVisualBaseRecibida((ParteDelCuerpoHumano)num, emociones) * 0.666f;
			}
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x0005A2C8 File Offset: 0x000584C8
		private void UpdatePrioridadesTactiles()
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			MapaDeEmociones emociones = this.m_Personalidad.currentPersonalidad.emociones;
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				int num = enumValoresInt[i];
				this.m_prioridadesTactiles[num] = ConsentNecesario.NecesarioTactilBaseRecibida((ParteDelCuerpoHumano)num, emociones) * 0.666f;
			}
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x0005A328 File Offset: 0x00058528
		private void UpdatePrioridadesCoitales()
		{
			this.CheckUpdatePrioridadesVisuales();
			MapaDeEmociones emociones = this.m_Personalidad.currentPersonalidad.emociones;
			this.m_prioridadesCoitales[32] = ConsentNecesario.NecesarioCoitalBaseRecibida(ParteDelCuerpoHumano.vag, emociones) * 0.666f;
			this.m_prioridadesCoitales[31] = ConsentNecesario.NecesarioCoitalBaseRecibida(ParteDelCuerpoHumano.ano, emociones) * 0.666f;
			this.m_prioridadesCoitales[9] = ConsentNecesario.NecesarioCoitalBaseRecibida(ParteDelCuerpoHumano.bocaInterno, emociones) * 0.666f;
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x0005A39D File Offset: 0x0005859D
		public float PrioridadVisual(ParteDelCuerpoHumano parte)
		{
			return this.m_prioridadesVisuales[(int)parte];
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x0005A3AB File Offset: 0x000585AB
		public float PrioridadTactil(ParteDelCuerpoHumano parte)
		{
			return this.m_prioridadesTactiles[(int)parte];
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x0005A3B9 File Offset: 0x000585B9
		public float PrioridadCoital(ParteDelCuerpoHumano parte)
		{
			return this.GetPrioridadCoital(parte);
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x0005A3C2 File Offset: 0x000585C2
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesVisuales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMayorPrioridad(list, this.m_prioridadesVisuales);
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x0005A3E9 File Offset: 0x000585E9
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadVisual(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesVisuales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMenorPrioridad(list, this.m_prioridadesVisuales);
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x0005A410 File Offset: 0x00058610
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesTactiles();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMayorPrioridad(list, this.m_prioridadesTactiles);
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0005A437 File Offset: 0x00058637
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadTactil(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesTactiles();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMenorPrioridad(list, this.m_prioridadesTactiles);
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x0005A45E File Offset: 0x0005865E
		public ParteDelCuerpoHumano ObtenerLaDeMayorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesCoitales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMayorPrioridad(list, this.m_prioridadCoitalGetter);
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x0005A485 File Offset: 0x00058685
		public ParteDelCuerpoHumano ObtenerLaDeMenorPrioridadCoital(IReadOnlyList<ParteDelCuerpoHumano> list)
		{
			this.CheckUpdatePrioridadesCoitales();
			if (list == null || list.Count == 0)
			{
				list = this.m_todasLasPartes;
			}
			return PrioridadesDePartesDelCuerpoHumano.ObtenerLaDeMenorPrioridad(list, this.m_prioridadCoitalGetter);
		}

		// Token: 0x04001114 RID: 4372
		public const float normalizacion = 0.666f;

		// Token: 0x04001115 RID: 4373
		private Personalidad m_Personalidad;

		// Token: 0x04001117 RID: 4375
		private ForcedUpdateId m_prioridadesVisualesUpdateID;

		// Token: 0x04001118 RID: 4376
		private ForcedUpdateId m_prioridadesTactilesUpdateID;

		// Token: 0x04001119 RID: 4377
		private ForcedUpdateId m_prioridadesCoitalesUpdateID;

		// Token: 0x0400111A RID: 4378
		private Dictionary<int, float> m_prioridadesVisuales = new Dictionary<int, float>();

		// Token: 0x0400111B RID: 4379
		private Dictionary<int, float> m_prioridadesTactiles = new Dictionary<int, float>();

		// Token: 0x0400111C RID: 4380
		private Dictionary<int, float> m_prioridadesCoitales = new Dictionary<int, float>();

		// Token: 0x0400111D RID: 4381
		private List<ParteDelCuerpoHumano> m_todasLasPartes = new List<ParteDelCuerpoHumano>();

		// Token: 0x0400111E RID: 4382
		private Func<ParteDelCuerpoHumano, float> m_prioridadCoitalGetter;
	}
}
