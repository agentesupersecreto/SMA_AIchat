using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Auras;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias
{
	// Token: 0x020000C7 RID: 199
	public static class AgenciasHelper
	{
		// Token: 0x06000784 RID: 1924 RVA: 0x0002A448 File Offset: 0x00028648
		public static void ModeloEsAceptadaPorAgencia(Character modelo, Agencia agencia, IJsonMemoryNode memoriaDeAgencia, ref AgenciasHelper.Respuesta respuesta)
		{
			if (agencia == null)
			{
				throw new ArgumentNullException("agencia", "agencia null reference.");
			}
			if (modelo == null)
			{
				throw new ArgumentNullException("modelo", "modelo null reference.");
			}
			InterpretadorDeFemales componentInChildren = modelo.GetComponentInChildren<InterpretadorDeFemales>();
			if (componentInChildren == null)
			{
				throw new ArgumentNullException("interpretacion", "interpretacion null reference.");
			}
			if (respuesta == null)
			{
				respuesta = new AgenciasHelper.Respuesta();
			}
			AgenciasHelper.IRespuesta respuesta2 = respuesta;
			respuesta2.Clear();
			componentInChildren.Interpretar();
			object obj = componentInChildren.interpretacion;
			AgenciasHelper.RequerimientosSonCumplido<Agencia.Requerimiento>(agencia.requerimientos, obj, respuesta2.requerimientosActivados);
			AgenciasHelper.RequerimientosSonCumplido<Agencia.AntiRequerimiento>(agencia.antiRequerimientos, obj, respuesta2.antiRequerimientosActivados);
			AgenciasHelper.RequerimientosSonCumplido<Agencia.Bonus, AgenciasHelper.BonusRespuesta>(agencia.bonuses, obj, respuesta2.bonusesActivados, memoriaDeAgencia);
			AgenciasHelper.RequerimientosSonCumplido<Agencia.Bonus, AgenciasHelper.BonusRespuesta>(agencia.antiBonuses, obj, respuesta2.antiBonusesActivados, memoriaDeAgencia);
			bool flag = agencia.requerimientos.ScrambledAndCountEquals(respuesta2.requerimientosActivados, (Agencia.Requerimiento req) => req.rutaV2);
			flag = flag && respuesta2.antiRequerimientosActivados.Count == 0;
			respuesta2.Poblar(modelo, agencia, flag);
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0002A564 File Offset: 0x00028764
		private static void RequerimientosSonCumplido<T>(IReadOnlyList<T> requerimientos, object interpretacion, IList<T> resultado) where T : Agencia.RequerimientoBase
		{
			for (int i = 0; i < requerimientos.Count; i++)
			{
				T t = requerimientos[i];
				if (AgenciasHelper.RequerimientoCumplido(t, interpretacion))
				{
					resultado.Add(t);
				}
			}
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0002A5A0 File Offset: 0x000287A0
		private static void RequerimientosSonCumplido<T, T_par>(IReadOnlyList<T> requerimientos, object interpretacion, IList<T_par> resultado, IJsonMemoryNode memoriaDeAgencia) where T : Agencia.RequerimientoBase where T_par : AgenciasHelper.IParRespuesta<T>, new()
		{
			for (int i = 0; i < requerimientos.Count; i++)
			{
				T t = requerimientos[i];
				if (AgenciasHelper.RequerimientoCumplido(t, interpretacion))
				{
					bool flag = memoriaDeAgencia != null && memoriaDeAgencia.FindChildNotNull<IJsonMemoryNode>(t.rutaV2).FindDataBool("EsUnlocked", false);
					T_par t_par = new T_par();
					t_par.requerimiento = t;
					t_par.estaDesblokeado = flag;
					resultado.Add(t_par);
				}
			}
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0002A624 File Offset: 0x00028824
		private static bool RequerimientoCumplido(Agencia.RequerimientoBase req, object interpretacion)
		{
			if (req == null || string.IsNullOrWhiteSpace(req.rutaV2))
			{
				return false;
			}
			int num = Convert.ToInt32(interpretacion.GetValueNestedOptimizado(BindingFlags.Instance | BindingFlags.Public, req.rutaSeparada));
			int valorPrimario = req.valorPrimario;
			int valorSegundario = req.valorSegundario;
			int valorTerciario = req.valorTerciario;
			return valorPrimario == num || (req.usarValorSegundario && valorSegundario == num) || (req.usarValorTerciario && valorTerciario == num);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0002A68C File Offset: 0x0002888C
		public static void ModeloQuiereIrAgencia(Character modelo, Agencia agencia, out Agencia.AI.Par parTarget, out ParteDelCuerpoHumano estimuladaTarget, out float ConsentActual, out float ConsentOffsetParaParTargetModificado, out float ConsentNecesarioParaParTargetModificado, out float ConsentOffsetParaParTargetNoModificado, out float ConsentNecesarioParaParTargetNoModificado, out bool EsConsentidoIrAAgenciaModificado, out bool EsConsentidoIrAAgenciaNoModificado)
		{
			Personalidad componentInChildren = modelo.GetComponentInChildren<Personalidad>();
			ConsentNecesario componentInChildren2 = modelo.GetComponentInChildren<ConsentNecesario>();
			ConcentToHeroMinimoDeFemale componentInChildren3 = modelo.GetComponentInChildren<ConcentToHeroMinimoDeFemale>();
			float num = Mathf.Lerp(1f, 0.75f, componentInChildren.sumicion);
			float num2 = Mathf.Lerp(1f, 0.75f, componentInChildren.optimismo);
			float num3 = Mathf.Lerp(1f, 0.75f, componentInChildren.GetTraitScore(TraitHumano.gustoPorDinero).GetWeigthDeScore());
			if (agencia.aI.equivalentes.Count == 0)
			{
				throw new InvalidOperationException("Agencia: " + agencia.ID + " no AI");
			}
			estimuladaTarget = ParteDelCuerpoHumano.pecho;
			parTarget = null;
			ConsentOffsetParaParTargetNoModificado = float.MaxValue;
			ConsentNecesarioParaParTargetNoModificado = 0f;
			ConsentActual = componentInChildren2.consentActual;
			for (int i = 0; i < agencia.aI.equivalentes.Count; i++)
			{
				Agencia.AI.Par par = agencia.aI.equivalentes[i];
				try
				{
					List<ParteDelCuerpoHumano> list;
					if (par.estimuladas.Count > 0)
					{
						list = par.estimuladas;
					}
					else
					{
						list = AgenciasHelper.m_Temp;
						list.Add(AgenciasHelper.ParteConMenosConsentNesesaria(componentInChildren2, par.tipoDeEstimulo, DireccionDeEstimulo.recibida, par.estimulante, par.tag));
					}
					for (int j = 0; j < list.Count; j++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = list[j];
						float num4;
						float num5;
						componentInChildren2.EsConsentidoConJerarquia(par.tipoDeEstimulo, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, par.estimulante, out num4, out num5, 1f, null, null, par.tag);
						if (num4 <= ConsentOffsetParaParTargetNoModificado)
						{
							estimuladaTarget = parteDelCuerpoHumano;
							parTarget = par;
							ConsentOffsetParaParTargetNoModificado = num4;
							ConsentNecesarioParaParTargetNoModificado = num5;
						}
					}
				}
				finally
				{
					AgenciasHelper.m_Temp.Clear();
				}
			}
			if (parTarget == null)
			{
				throw new InvalidOperationException("Agencia: " + agencia.ID + " no AI parTarget");
			}
			EsConsentidoIrAAgenciaNoModificado = ConsentOffsetParaParTargetNoModificado >= 1f;
			float num6 = AgenciasHelper.ObtenerModAConsentPorTipoDePersonaje(parTarget.tipoDePersonaje, componentInChildren, componentInChildren3);
			float num7 = num * num2 * num6 * num3;
			EsConsentidoIrAAgenciaModificado = componentInChildren2.EsConsentidoConJerarquia(parTarget.tipoDeEstimulo, DireccionDeEstimulo.recibida, estimuladaTarget, parTarget.estimulante, out ConsentOffsetParaParTargetModificado, out ConsentNecesarioParaParTargetModificado, num7, null, null, parTarget.tag);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0002A8CC File Offset: 0x00028ACC
		public static ParteDelCuerpoHumano ParteConMenosConsentNesesaria(Character modelo, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, string tag = null)
		{
			return AgenciasHelper.ParteConMenosConsentNesesaria(modelo.GetComponentInChildren<ConsentNecesario>(), tipo, direccion, estimulante, tag);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0002A8E0 File Offset: 0x00028AE0
		public static ParteDelCuerpoHumano ParteConMenosConsentNesesaria(ConsentNecesario consentNecesario, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, string tag = null)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.pecho;
			float num = float.MaxValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano2.EsFemenina())
				{
					float num2 = consentNecesario.ParaConJerarquia(tipo, direccion, parteDelCuerpoHumano2, estimulante, null, null, tag);
					if (num2 < num)
					{
						num = num2;
						parteDelCuerpoHumano = parteDelCuerpoHumano2;
					}
				}
			}
			return parteDelCuerpoHumano;
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0002A974 File Offset: 0x00028B74
		private static float ObtenerModAConsentPorTipoDePersonaje(TipoDePersonaje tipoDePersonaje, Personalidad personalidad, ConcentToHeroMinimoDeFemale consentAura)
		{
			float num;
			if (tipoDePersonaje == TipoDePersonaje.mainCharacter)
			{
				num = consentAura.porGustoWeigth;
			}
			else
			{
				try
				{
					AgenciasHelper.ObtenerTraitDeTipoDePersonaje(tipoDePersonaje, AgenciasHelper.m_traitsConW_Temp);
					num = 0f;
					for (int i = 0; i < AgenciasHelper.m_traitsConW_Temp.Count; i++)
					{
						ValueTuple<TraitHumano, float> valueTuple = AgenciasHelper.m_traitsConW_Temp[i];
						float weigthDeScore = personalidad.GetTraitScore(valueTuple.Item1).GetWeigthDeScore();
						num += weigthDeScore * valueTuple.Item2;
					}
				}
				finally
				{
					AgenciasHelper.m_traitsConW_Temp.Clear();
				}
			}
			return Mathf.Lerp(1f, 0.5f, num);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0002AA0C File Offset: 0x00028C0C
		private static void ObtenerTraitDeTipoDePersonaje(TipoDePersonaje tipoDePersonaje, IList<ValueTuple<TraitHumano, float>> resultado)
		{
			switch (tipoDePersonaje)
			{
			case TipoDePersonaje.mainCharacter:
				throw new InvalidOperationException();
			case TipoDePersonaje.maleSegundaryNormal:
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorNormales, 1f));
				return;
			case TipoDePersonaje.maleSegundaryHandsomeModel:
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorMusculosos, 0.5f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorJovenes, 0.5f));
				return;
			case TipoDePersonaje.maleSegundaryPornStart:
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorMusculosos, 0.5f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorPervertidos, 0.5f));
				return;
			case TipoDePersonaje.maleSegundaryCreepy:
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorAutistas, 0.3f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorPervertidos, 0.5f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorTimidos, 0.2f));
				return;
			case TipoDePersonaje.maleSegundaryOld:
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorViejos, 0.75f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorPervertidos, 0.25f));
				return;
			case TipoDePersonaje.maleSegundaryStranger:
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorNormales, 0.3f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorPervertidos, 0.25f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorTimidos, 0.25f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorPatanes, 0.2f));
				return;
			case TipoDePersonaje.maleSegundaryBadGuy:
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorPatanes, 0.7f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorMusculosos, 0.15f));
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorPervertidos, 0.15f));
				return;
			case TipoDePersonaje.femaleSegundary:
				resultado.Add(new ValueTuple<TraitHumano, float>(TraitHumano.gustoPorMujeres, 1f));
				return;
			default:
				throw new ArgumentOutOfRangeException(tipoDePersonaje.ToString());
			}
		}

		// Token: 0x04000448 RID: 1096
		public const float earnings = 10000f;

		// Token: 0x04000449 RID: 1097
		private static List<ParteDelCuerpoHumano> m_Temp = new List<ParteDelCuerpoHumano>();

		// Token: 0x0400044A RID: 1098
		private static List<ValueTuple<TraitHumano, float>> m_traitsConW_Temp = new List<ValueTuple<TraitHumano, float>>();

		// Token: 0x02000256 RID: 598
		[SerializeField]
		public class Respuesta : AgenciasHelper.IRespuesta, IClearable
		{
			// Token: 0x170002CC RID: 716
			// (get) Token: 0x060010F8 RID: 4344 RVA: 0x00050F7B File Offset: 0x0004F17B
			public IReadOnlyList<Agencia.Requerimiento> requerimientosActivados
			{
				get
				{
					return this.m_requerimientosActivados;
				}
			}

			// Token: 0x170002CD RID: 717
			// (get) Token: 0x060010F9 RID: 4345 RVA: 0x00050F83 File Offset: 0x0004F183
			public IReadOnlyList<Agencia.AntiRequerimiento> antiRequerimientosActivados
			{
				get
				{
					return this.m_antiRequerimientosActivados;
				}
			}

			// Token: 0x170002CE RID: 718
			// (get) Token: 0x060010FA RID: 4346 RVA: 0x00050F8B File Offset: 0x0004F18B
			public IReadOnlyList<AgenciasHelper.BonusRespuesta> bonusesActivados
			{
				get
				{
					return this.m_bonusesActivados;
				}
			}

			// Token: 0x170002CF RID: 719
			// (get) Token: 0x060010FB RID: 4347 RVA: 0x00050F93 File Offset: 0x0004F193
			public IReadOnlyList<AgenciasHelper.BonusRespuesta> antiBonusesActivados
			{
				get
				{
					return this.m_antiBonusesActivados;
				}
			}

			// Token: 0x170002D0 RID: 720
			// (get) Token: 0x060010FC RID: 4348 RVA: 0x00050F9B File Offset: 0x0004F19B
			public Character modelo
			{
				get
				{
					return this.m_modelo;
				}
			}

			// Token: 0x170002D1 RID: 721
			// (get) Token: 0x060010FD RID: 4349 RVA: 0x00050FA3 File Offset: 0x0004F1A3
			public Agencia agencia
			{
				get
				{
					return this.m_agencia;
				}
			}

			// Token: 0x170002D2 RID: 722
			// (get) Token: 0x060010FE RID: 4350 RVA: 0x00050FAB File Offset: 0x0004F1AB
			public bool esAceptada
			{
				get
				{
					return this.m_esAceptada;
				}
			}

			// Token: 0x170002D3 RID: 723
			// (get) Token: 0x060010FF RID: 4351 RVA: 0x00050FB3 File Offset: 0x0004F1B3
			public bool esValida
			{
				get
				{
					return this.m_modelo != null && this.m_agencia != null;
				}
			}

			// Token: 0x06001100 RID: 4352 RVA: 0x00050FD1 File Offset: 0x0004F1D1
			public void Clear()
			{
				this.m_modelo = null;
				this.m_agencia = null;
				this.m_requerimientosActivados.Clear();
				this.m_antiRequerimientosActivados.Clear();
				this.m_bonusesActivados.Clear();
				this.m_antiBonusesActivados.Clear();
			}

			// Token: 0x170002D4 RID: 724
			// (get) Token: 0x06001101 RID: 4353 RVA: 0x0005100D File Offset: 0x0004F20D
			List<Agencia.Requerimiento> AgenciasHelper.IRespuesta.requerimientosActivados
			{
				get
				{
					return this.m_requerimientosActivados;
				}
			}

			// Token: 0x170002D5 RID: 725
			// (get) Token: 0x06001102 RID: 4354 RVA: 0x00051015 File Offset: 0x0004F215
			List<Agencia.AntiRequerimiento> AgenciasHelper.IRespuesta.antiRequerimientosActivados
			{
				get
				{
					return this.m_antiRequerimientosActivados;
				}
			}

			// Token: 0x170002D6 RID: 726
			// (get) Token: 0x06001103 RID: 4355 RVA: 0x0005101D File Offset: 0x0004F21D
			List<AgenciasHelper.BonusRespuesta> AgenciasHelper.IRespuesta.bonusesActivados
			{
				get
				{
					return this.m_bonusesActivados;
				}
			}

			// Token: 0x170002D7 RID: 727
			// (get) Token: 0x06001104 RID: 4356 RVA: 0x00051025 File Offset: 0x0004F225
			List<AgenciasHelper.BonusRespuesta> AgenciasHelper.IRespuesta.antiBonusesActivados
			{
				get
				{
					return this.m_antiBonusesActivados;
				}
			}

			// Token: 0x06001105 RID: 4357 RVA: 0x00051030 File Offset: 0x0004F230
			void AgenciasHelper.IRespuesta.Poblar(Character modelo, Agencia agencia, bool esAceptada)
			{
				if (agencia == null)
				{
					throw new ArgumentNullException("agencia", "agencia null reference.");
				}
				if (modelo == null)
				{
					throw new ArgumentNullException("modelo", "modelo null reference.");
				}
				this.m_modelo = modelo;
				this.m_agencia = agencia;
				this.m_esAceptada = esAceptada;
			}

			// Token: 0x04000B34 RID: 2868
			[SerializeField]
			private List<Agencia.Requerimiento> m_requerimientosActivados = new List<Agencia.Requerimiento>();

			// Token: 0x04000B35 RID: 2869
			[SerializeField]
			private List<Agencia.AntiRequerimiento> m_antiRequerimientosActivados = new List<Agencia.AntiRequerimiento>();

			// Token: 0x04000B36 RID: 2870
			[SerializeField]
			private List<AgenciasHelper.BonusRespuesta> m_bonusesActivados = new List<AgenciasHelper.BonusRespuesta>();

			// Token: 0x04000B37 RID: 2871
			[SerializeField]
			private List<AgenciasHelper.BonusRespuesta> m_antiBonusesActivados = new List<AgenciasHelper.BonusRespuesta>();

			// Token: 0x04000B38 RID: 2872
			[SerializeField]
			private Character m_modelo;

			// Token: 0x04000B39 RID: 2873
			[SerializeField]
			private Agencia m_agencia;

			// Token: 0x04000B3A RID: 2874
			[SerializeField]
			private bool m_esAceptada;
		}

		// Token: 0x02000257 RID: 599
		private interface IRespuesta : IClearable
		{
			// Token: 0x170002D8 RID: 728
			// (get) Token: 0x06001107 RID: 4359
			List<Agencia.Requerimiento> requerimientosActivados { get; }

			// Token: 0x170002D9 RID: 729
			// (get) Token: 0x06001108 RID: 4360
			List<Agencia.AntiRequerimiento> antiRequerimientosActivados { get; }

			// Token: 0x170002DA RID: 730
			// (get) Token: 0x06001109 RID: 4361
			List<AgenciasHelper.BonusRespuesta> bonusesActivados { get; }

			// Token: 0x170002DB RID: 731
			// (get) Token: 0x0600110A RID: 4362
			List<AgenciasHelper.BonusRespuesta> antiBonusesActivados { get; }

			// Token: 0x0600110B RID: 4363
			void Poblar(Character modelo, Agencia agencia, bool esAceptada);
		}

		// Token: 0x02000258 RID: 600
		[Serializable]
		public struct BonusRespuesta : AgenciasHelper.IParRespuesta<Agencia.Bonus>
		{
			// Token: 0x170002DC RID: 732
			// (get) Token: 0x0600110C RID: 4364 RVA: 0x000510B8 File Offset: 0x0004F2B8
			// (set) Token: 0x0600110D RID: 4365 RVA: 0x000510C0 File Offset: 0x0004F2C0
			Agencia.Bonus AgenciasHelper.IParRespuesta<Agencia.Bonus>.requerimiento
			{
				get
				{
					return this.bonus;
				}
				set
				{
					this.bonus = value;
				}
			}

			// Token: 0x170002DD RID: 733
			// (get) Token: 0x0600110E RID: 4366 RVA: 0x000510C9 File Offset: 0x0004F2C9
			// (set) Token: 0x0600110F RID: 4367 RVA: 0x000510D1 File Offset: 0x0004F2D1
			bool AgenciasHelper.IParRespuesta<Agencia.Bonus>.estaDesblokeado
			{
				get
				{
					return this.estaDesblokeado;
				}
				set
				{
					this.estaDesblokeado = value;
				}
			}

			// Token: 0x04000B3B RID: 2875
			public Agencia.Bonus bonus;

			// Token: 0x04000B3C RID: 2876
			public bool estaDesblokeado;
		}

		// Token: 0x02000259 RID: 601
		private interface IParRespuesta<T> where T : Agencia.RequerimientoBase
		{
			// Token: 0x170002DE RID: 734
			// (get) Token: 0x06001110 RID: 4368
			// (set) Token: 0x06001111 RID: 4369
			T requerimiento { get; set; }

			// Token: 0x170002DF RID: 735
			// (get) Token: 0x06001112 RID: 4370
			// (set) Token: 0x06001113 RID: 4371
			bool estaDesblokeado { get; set; }
		}
	}
}
