using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000023 RID: 35
	public static class InterpretadorDeGustos
	{
		// Token: 0x060000FD RID: 253 RVA: 0x00005028 File Offset: 0x00003228
		public static InterpretacionDeGustos Interpretar(IInterpretadorHelperConAlteradoresDePersonalidad helper, ITraitsInterpretadorHelper helperTraits, IDeseosInterpretadorHelper deseosDefautls, IDeseosInterpretadorHelper deseosCurrent)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (helperTraits == null)
			{
				throw new ArgumentNullException("helperTraits", "helperTraits null reference.");
			}
			if (deseosDefautls == null)
			{
				throw new ArgumentNullException("deseosDefautls", "deseosDefautls null reference.");
			}
			if (deseosCurrent == null)
			{
				throw new ArgumentNullException("deseosCurrent", "deseosCurrent null reference.");
			}
			if (deseosDefautls == deseosCurrent)
			{
				throw new InvalidOperationException();
			}
			InterpretacionDeGustos interpretacionDeGustos = default(InterpretacionDeGustos);
			if (deseosDefautls.facialInitial != 0f || deseosDefautls.crotchInitial != 0f || deseosDefautls.assInitial != 0f)
			{
				Debug.LogError("Todos los deseos iniciales deben ser 50");
			}
			if (deseosDefautls.facialGain != 1f || deseosDefautls.crotchGain != 1f || deseosDefautls.assGain != 1f)
			{
				Debug.LogError("Todos los deseos mods iniciales deben ser 1");
			}
			interpretacionDeGustos.facialInitial = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(Mathf.InverseLerp(-100f, 100f, deseosCurrent.facialInitial));
			interpretacionDeGustos.crotchInitial = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(Mathf.InverseLerp(-100f, 100f, deseosCurrent.crotchInitial));
			interpretacionDeGustos.assInitial = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(Mathf.InverseLerp(-100f, 100f, deseosCurrent.assInitial));
			interpretacionDeGustos.facialGain = InterpretadorDeGustos.GetGain<Interpretacion.Capacidad>(deseosDefautls.facialGain, deseosCurrent.facialGain);
			interpretacionDeGustos.crotchGain = InterpretadorDeGustos.GetGain<Interpretacion.Capacidad>(deseosDefautls.crotchGain, deseosCurrent.crotchGain);
			interpretacionDeGustos.assGain = InterpretadorDeGustos.GetGain<Interpretacion.Capacidad>(deseosDefautls.assGain, deseosCurrent.assGain);
			interpretacionDeGustos.deseoByVisual = InterpretadorDeGustos.GetSensi<Interpretacion.Capacidad>(deseosDefautls.deseoByVisual, deseosCurrent.deseoByVisual);
			interpretacionDeGustos.deseoByVerbal = InterpretadorDeGustos.GetSensi<Interpretacion.Capacidad>(deseosDefautls.deseoByVerbal, deseosCurrent.deseoByVerbal);
			interpretacionDeGustos.deseoByTouch = InterpretadorDeGustos.GetSensi<Interpretacion.Capacidad>(deseosDefautls.deseoByTouch, deseosCurrent.deseoByTouch);
			interpretacionDeGustos.deseoByExposure = InterpretadorDeGustos.GetSensi<Interpretacion.Capacidad>(deseosDefautls.deseoByExposure, deseosCurrent.deseoByExposure);
			interpretacionDeGustos.deseoByCoital = InterpretadorDeGustos.GetSensi<Interpretacion.Capacidad>(deseosDefautls.deseoByCoital, deseosCurrent.deseoByCoital);
			interpretacionDeGustos.deseoGainIndirecto = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.deseoGainIndirectoValorPolarizado);
			interpretacionDeGustos.corruptionByDesires = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.corruptionByDesiresValorPolarizado);
			interpretacionDeGustos.deseosResiliance = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.deseosResilianceValorPolarizado);
			interpretacionDeGustos.dispuestaAChupar = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.dispuestaAChuparValorPolarizado);
			interpretacionDeGustos.dispuestaARiding = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.dispuestaARidingValorPolarizado);
			interpretacionDeGustos.dispuestaARidingAnal = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.dispuestaARidingAnalValorPolarizado);
			interpretacionDeGustos.gustoPorPervertidos = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorPervertidosValorPolarizado);
			interpretacionDeGustos.gustoPorTimidos = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorTimidosValorPolarizado);
			interpretacionDeGustos.gustoPorPatanes = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorPatanesValorPolarizado);
			interpretacionDeGustos.gustoPorIntelectuales = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorIntelectualesValorPolarizado);
			interpretacionDeGustos.gustoPorConfiados = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorConfiadosValorPolarizado);
			interpretacionDeGustos.gustoPorAutistas = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorAutistasValorPolarizado);
			interpretacionDeGustos.gustoPorDinero = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorDineroValorPolarizado);
			interpretacionDeGustos.gustoPorHumildad = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorHumildadValorPolarizado);
			interpretacionDeGustos.gustoPorGordos = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorGordosValorPolarizado);
			interpretacionDeGustos.gustoPorViejos = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorViejosValorPolarizado);
			interpretacionDeGustos.gustoPorDelgados = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorDelgadosValorPolarizado);
			interpretacionDeGustos.gustoPorMusculosos = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorMusculososValorPolarizado);
			interpretacionDeGustos.gustoPorJovenes = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.gustoPorJovenesValorPolarizado);
			return interpretacionDeGustos;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005370 File Offset: 0x00003570
		private static T_Enum GetSensi<T_Enum>(float defaultVal, float currentVal) where T_Enum : Enum
		{
			float num;
			if (defaultVal != 0f)
			{
				num = currentVal / defaultVal;
			}
			else
			{
				num = 1E+13f;
				Debug.LogError("Default value era zero");
			}
			return InterHelper.GetParaGenesPorValor<T_Enum>(InterpretadorDeGustos.GetEnumValueParaSensi(num));
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000053A6 File Offset: 0x000035A6
		private static int GetEnumValueParaSensi(float offset)
		{
			if (offset >= 5f)
			{
				return 2;
			}
			if (offset >= 2f)
			{
				return 1;
			}
			if (offset >= 0.5f)
			{
				return 0;
			}
			if (offset >= 0.25f)
			{
				return -1;
			}
			return -2;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000053D4 File Offset: 0x000035D4
		private static T_Enum GetGain<T_Enum>(float defaultVal, float currentVal) where T_Enum : Enum
		{
			float num;
			if (defaultVal != 0f)
			{
				num = currentVal / defaultVal;
			}
			else
			{
				num = 1E+13f;
				Debug.LogError("Default value era zero");
			}
			return InterHelper.GetParaGenesPorValor<T_Enum>(InterpretadorDeGustos.GetEnumValueParaGain(num));
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000540A File Offset: 0x0000360A
		private static int GetEnumValueParaGain(float offset)
		{
			if (offset >= 10f)
			{
				return 2;
			}
			if (offset >= 3f)
			{
				return 1;
			}
			if (offset >= 0.333f)
			{
				return 0;
			}
			if (offset >= 0.1f)
			{
				return -1;
			}
			return -2;
		}
	}
}
