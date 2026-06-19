using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores
{
	// Token: 0x02000030 RID: 48
	public sealed class ConsentPorGustosDeModelaje : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x00006DE4 File Offset: 0x00004FE4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentToHero = this.GetComponentEnRoot(false);
			if (this.m_ConsentToHero == null)
			{
				throw new ArgumentNullException("m_ConsentToHero", "m_ConsentToHero null reference.");
			}
			this.m_BuffDeCharacter = this.GetComponentEnRoot(false);
			if (this.m_BuffDeCharacter == null)
			{
				Debug.LogException(new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference."), this);
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00006E52 File Offset: 0x00005052
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00006E5A File Offset: 0x0000505A
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00006E63 File Offset: 0x00005063
		public void Change([TupleElementNames(new string[] { "tipoDeEstimulo", "direccion", "estiulante", "estimuladas" })] ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] inclusiones, [TupleElementNames(new string[] { "wieght", "tipoDeEstimulo", "direccion", "estiulante", "estimuladas" })] ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] exclusiones)
		{
			this.ChangeMinConsentTo(inclusiones, exclusiones);
			this.ChangeDeshieloToMax(inclusiones);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00006E74 File Offset: 0x00005074
		private void ChangeDeshieloToMax([TupleElementNames(new string[] { "tipoDeEstimulo", "direccion", "estiulante", "estimuladas" })] ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] deshielos)
		{
			string text = BuffMap.GenerateBuffID("Tvalle.Buff.DeshieloByModelingCareerChoice", string.Empty);
			this.m_BuffDeCharacter.eventos.Remove(text);
			BuffMap map = Singleton<BuffManager>.instance.GetMap("Tvalle.Buff.DeshieloByModelingCareerChoice");
			if (map == null)
			{
				Debug.LogException(new ArgumentNullException("map", "map null reference."));
			}
			Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
			BuffOnDeshieloDeEstimuloEnPartesArg buffOnDeshieloDeEstimuloEnPartesArg;
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnDeshieloDeEstimuloEnPartesArg>(efecto.argumentoID, out buffOnDeshieloDeEstimuloEnPartesArg))
			{
				Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
			buffOnDeshieloDeEstimuloEnPartesArg.value = 100f;
			buffOnDeshieloDeEstimuloEnPartesArg.data = deshielos.Select(([TupleElementNames(new string[] { "tipoDeEstimulo", "direccion", "estiulante", "estimuladas" })] ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> p) => new BuffOnDeshieloDeEstimuloEnPartesArg.Data
			{
				direccion = p.Item2,
				tipo = p.Item1,
				estiulante = p.Item3,
				estimuladas = p.Item4.ToArray<ParteDelCuerpoHumano>()
			}).ToArray<BuffOnDeshieloDeEstimuloEnPartesArg.Data>();
			BuffEvento eventoBuff = map.GetEventoBuff(Singleton<TiempoDeJuego>.instance.now, string.Empty, buffOnDeshieloDeEstimuloEnPartesArg, null);
			if (eventoBuff == null)
			{
				Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
			}
			this.m_BuffDeCharacter.eventos.AddOrStackUp(eventoBuff, false, false);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00006F90 File Offset: 0x00005190
		private void ChangeMinConsentTo([TupleElementNames(new string[] { "tipoDeEstimulo", "direccion", "estiulante", "estimuladas" })] ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] inclusiones, [TupleElementNames(new string[] { "wieght", "tipoDeEstimulo", "direccion", "estiulante", "estimuladas" })] ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>>[] exclusiones)
		{
			string text = BuffMap.GenerateBuffID("Tvalle.Buff.MinFavorabilityByModelingCareerChoice", string.Empty);
			this.m_BuffDeCharacter.eventos.Remove(text);
			BuffMap map = Singleton<BuffManager>.instance.GetMap("Tvalle.Buff.MinFavorabilityByModelingCareerChoice");
			if (map == null)
			{
				Debug.LogException(new ArgumentNullException("map", "map null reference."));
			}
			Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
			BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg;
			if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<BuffOnMinFavorabilityValueArg>(efecto.argumentoID, out buffOnMinFavorabilityValueArg))
			{
				Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
			}
			buffOnMinFavorabilityValueArg.data = inclusiones.Select(([TupleElementNames(new string[] { "tipoDeEstimulo", "direccion", "estiulante", "estimuladas" })] ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> p) => new BuffOnMinFavorabilityValueArg.Data
			{
				direccion = p.Item2,
				tipo = p.Item1,
				estiulante = p.Item3,
				estimuladas = p.Item4.ToArray<ParteDelCuerpoHumano>()
			}).ToArray<BuffOnMinFavorabilityValueArg.Data>();
			buffOnMinFavorabilityValueArg.dataExcluir = exclusiones.Select(([TupleElementNames(new string[] { "wieght", "tipoDeEstimulo", "direccion", "estiulante", "estimuladas" })] ValueTuple<float, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular, IReadOnlyList<ParteDelCuerpoHumano>> p) => new BuffOnMinFavorabilityValueArg.ExclusionData
			{
				weight = p.Item1,
				direccion = p.Item3,
				tipo = p.Item2,
				estiulante = p.Item4,
				estimuladas = p.Item5.ToArray<ParteDelCuerpoHumano>()
			}).ToArray<BuffOnMinFavorabilityValueArg.ExclusionData>();
			buffOnMinFavorabilityValueArg.force = true;
			buffOnMinFavorabilityValueArg.changedByFatigue = true;
			DisplayableBuff eventoBuff = map.GetEventoBuff<DisplayableBuff>(Singleton<TiempoDeJuego>.instance.now, string.Empty, buffOnMinFavorabilityValueArg, null);
			if (eventoBuff == null)
			{
				Debug.LogException(new ArgumentNullException("buff", "buff null reference."), this);
			}
			eventoBuff.showSmallMsgOnApplied = true;
			eventoBuff.showSmallMsgOnEnd = false;
			eventoBuff.showSmallMsgOnStart = false;
			this.m_BuffDeCharacter.eventos.AddOrStackUp(eventoBuff, false, false);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00002BEA File Offset: 0x00000DEA
		[Obsolete("usar el otro metodo q crea buff", true)]
		public void Cambiar(float valor)
		{
		}

		// Token: 0x040000C4 RID: 196
		private ConsentToHero m_ConsentToHero;

		// Token: 0x040000C5 RID: 197
		private BuffDeCharacter m_BuffDeCharacter;
	}
}
