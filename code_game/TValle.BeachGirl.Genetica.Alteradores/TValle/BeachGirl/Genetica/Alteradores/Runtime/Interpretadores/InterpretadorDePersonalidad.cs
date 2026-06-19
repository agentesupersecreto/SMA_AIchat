using System;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000028 RID: 40
	public static class InterpretadorDePersonalidad
	{
		// Token: 0x0600010D RID: 269 RVA: 0x0000655C File Offset: 0x0000475C
		public static InterpretacionDePersonalidad Interpretar(IInterpretadorHelperConAlteradoresDePersonalidad helper, ITraitsInterpretadorHelper helperTraits, IPersonalidadInterpretadorHelper helperPersonalidad)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (helperTraits == null)
			{
				throw new ArgumentNullException("helperTraits", "helperTraits null reference.");
			}
			if (helperPersonalidad == null)
			{
				throw new ArgumentNullException("helperPersonalidad", "helperPersonalidad null reference.");
			}
			InterpretacionDePersonalidad interpretacionDePersonalidad = default(InterpretacionDePersonalidad);
			interpretacionDePersonalidad.patience = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.patienceValorPolarizado);
			interpretacionDePersonalidad.estandaresAltos = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.estandaresAltosValorPolarizado);
			interpretacionDePersonalidad.responsiveness = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.responsivenessValorPolarizado);
			interpretacionDePersonalidad.expressiveness = InterHelper.GetParaGenesPorValor<Interpretacion.Capacidad>(helperTraits.expressivenessValorPolarizado);
			interpretacionDePersonalidad.traits = default(PersonalidadTraits);
			interpretacionDePersonalidad.traits.perverted = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.perverted, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.honest = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.honest, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.exhibitionist = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.exhibitionist, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.extroverted = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.extroverted, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.optimistic = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.optimistic, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.respectful = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.respectful, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.shy = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.shy, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.rude = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.dominant, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.masochist = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.masoquista, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.submissive = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.submissive, helperPersonalidad.middle);
			interpretacionDePersonalidad.traits.passive = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(helperPersonalidad.hybristophilia, helperPersonalidad.middle);
			return interpretacionDePersonalidad;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00006740 File Offset: 0x00004940
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
			}
			return InterHelper.GetParaGenesPorValor<T_Enum>(InterpretadorDePersonalidad.GetValueConOffsetCentrado(num));
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000676C File Offset: 0x0000496C
		private static int GetValueConOffsetCentrado(float offset)
		{
			if (offset >= 3f)
			{
				return 2;
			}
			if (offset >= 1.5f)
			{
				return 1;
			}
			if (offset >= 0.6666f)
			{
				return 0;
			}
			if (offset >= 0.3333f)
			{
				return -1;
			}
			return -2;
		}
	}
}
