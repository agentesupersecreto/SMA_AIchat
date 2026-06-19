using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders.CondicionesMedicas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000A9 RID: 169
	public class BuffOfMedicalConditionEffecto : Efecto<BuffOfMedicalConditionEffecto, BuffOfMedicalConditionArg>
	{
		// Token: 0x0600038B RID: 907 RVA: 0x00014444 File Offset: 0x00012644
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
			AlteradoresDeAparienciaFemenina alteradoresDeAparienciaFemenina = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null || alteradoresDeAparienciaFemenina == null)
			{
				return;
			}
			BuffOfMedicalConditionArg buffOfMedicalConditionArg = (BuffOfMedicalConditionArg)argument;
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(ReaccionHumana.dolor);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + ReaccionHumana.dolor.ToString(), caster as MonoBehaviour);
				return;
			}
			Alterador alterador = alteradoresDeAparienciaFemenina.Obtener(buffOfMedicalConditionArg.alteratorName);
			if (alterador == null)
			{
				Debug.LogError("no se puedo encontrar alterador " + buffOfMedicalConditionArg.alteratorName, caster as MonoBehaviour);
				return;
			}
			if (alterador.cantidadDeModificadores == 0)
			{
				Debug.LogError("alterador " + buffOfMedicalConditionArg.alteratorName + " no tiene modificadores", caster as MonoBehaviour);
				return;
			}
			List<float> list = new List<float>(alterador.cantidadDeModificadores);
			alterador.ExportarModificadores(list);
			float num = Mathf.Clamp01(list[0]);
			float num2;
			float num3;
			float num4;
			if (!buffOfMedicalConditionArg.esMedicalJob)
			{
				num2 = Mathf.Lerp(buffOfMedicalConditionArg.maxPainGain, 1f, 0.9f);
				num3 = Mathf.Lerp(buffOfMedicalConditionArg.maxPainExpandV2, 1f, 0.9f);
				num4 = Mathf.Lerp(buffOfMedicalConditionArg.maxPainIncreaseV2, 1f, 0.9f);
				num2 = Mathf.Clamp(num2, 1E-09f, float.MaxValue);
				num3 = Mathf.Clamp(num3, 1E-09f, float.MaxValue);
				num3 = Mathf.Clamp(num3, 1E-09f, float.MaxValue);
			}
			else
			{
				num2 = Mathf.Clamp(buffOfMedicalConditionArg.maxPainGain, 1E-09f, float.MaxValue);
				num4 = Mathf.Clamp(buffOfMedicalConditionArg.maxPainIncreaseV2, 1E-09f, float.MaxValue);
				num3 = Mathf.Clamp(buffOfMedicalConditionArg.maxPainExpandV2, 1E-09f, float.MaxValue);
			}
			DateTime now = Singleton<TiempoDeJuego>.instance.now;
			float num5;
			if (!buffOfMedicalConditionArg.esModelo)
			{
				num5 = Mathf.Clamp(num, 0f, 0.7425f);
			}
			else if (now >= buffOfMedicalConditionArg.fechaDeTratamientoStart && now <= buffOfMedicalConditionArg.fechaDeTratamientoEnd)
			{
				float num6 = Mathf.Lerp(0.7425f, 0f, buffOfMedicalConditionArg.tratamientoEfectividad);
				float num7 = 1f * buffOfMedicalConditionArg.tratamientoRate;
				float num8 = Mathf.InverseLerp(0f, num7, (float)(Singleton<TiempoDeJuego>.instance.now - buffOfMedicalConditionArg.fechaDeTratamientoStart).TotalDays / 7f);
				num5 = Mathf.Lerp(num, num6, num8.InPow(6f));
				num5 = Mathf.Clamp01(num5);
			}
			else
			{
				float num9 = 0.5f * buffOfMedicalConditionArg.contagioRate;
				float num10 = Mathf.InverseLerp(0f, num9, (float)(Singleton<TiempoDeJuego>.instance.now - buffOfMedicalConditionArg.fechaDeContagio).TotalDays / 365.2425f);
				num5 = Mathf.Clamp01(num + num10);
			}
			list[0] = num5;
			alterador.Modificar(list);
			float num11 = (buffOfMedicalConditionArg.lastSicknessLvl = AlteracionesDeCondicionesMedicas.GetSickessLvl(num5));
			float num12 = Mathf.Lerp(1f, num2, num11);
			float num13 = Mathf.Lerp(1f, num4, num11);
			float num14 = Mathf.Lerp(1f, num3, num11);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			for (int i = 0; i < buffOfMedicalConditionArg.painData.Length; i++)
			{
				GenericDataOfInteractionMultArg genericDataOfInteractionMultArg = buffOfMedicalConditionArg.painData[i];
				foreach (InterationReceivedType interationReceivedType in genericDataOfInteractionMultArg.interationReceivedTypes)
				{
					foreach (TriggeringBodyPart triggeringBodyPart in genericDataOfInteractionMultArg.fromParts)
					{
						foreach (SensitiveBodyPart sensitiveBodyPart in genericDataOfInteractionMultArg.toParts)
						{
							ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvancedNotNull = componentNotNull.GetModificadorAdvancedNotNull(interationReceivedType, triggeringBodyPart, sensitiveBodyPart);
							ModificadorDeFloat modificadorDeFloat = modificadorAdvancedNotNull.gainModificable.ObtenerModificadorNotNull(buffEvento.id);
							ModificadorDeFloat modificadorDeFloat2 = modificadorAdvancedNotNull.interPositionMinMaxModificable.ObtenerModificadorNotNull(buffEvento.id);
							ModificadorDeFloatBase modificadorDeFloatBase = modificadorAdvancedNotNull.interExpandModificable.ObtenerModificadorNotNull(buffEvento.id);
							modificadorDeFloat.valor.valor = num12;
							modificadorDeFloat2.valor.valor = num13;
							modificadorDeFloatBase.valor.valor = num14;
						}
					}
				}
			}
			if (buffEvento is DisplayableBuff)
			{
				(buffEvento as DisplayableBuff).quality = ItemQuality.Doomed;
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x000148DC File Offset: 0x00012ADC
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null)
			{
				return;
			}
			BuffOfMedicalConditionArg buffOfMedicalConditionArg = (BuffOfMedicalConditionArg)argument;
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(ReaccionHumana.dolor);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + ReaccionHumana.dolor.ToString(), caster as MonoBehaviour);
				return;
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			for (int i = 0; i < buffOfMedicalConditionArg.painData.Length; i++)
			{
				GenericDataOfInteractionMultArg genericDataOfInteractionMultArg = buffOfMedicalConditionArg.painData[i];
				foreach (InterationReceivedType interationReceivedType in genericDataOfInteractionMultArg.interationReceivedTypes)
				{
					foreach (SensitiveBodyPart sensitiveBodyPart in genericDataOfInteractionMultArg.toParts)
					{
						foreach (TriggeringBodyPart triggeringBodyPart in genericDataOfInteractionMultArg.fromParts)
						{
							ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvancedNotNull = componentNotNull.GetModificadorAdvancedNotNull(interationReceivedType, triggeringBodyPart, sensitiveBodyPart);
							if (modificadorAdvancedNotNull == null || !modificadorAdvancedNotNull.gainModificable.TryRemoverModificador(buffEvento.id) || !modificadorAdvancedNotNull.interExpandModificable.TryRemoverModificador(buffEvento.id))
							{
								Debug.LogError("no se puedo remover buff " + buffEvento.id + " no existia en modificables ", caster as MonoBehaviour);
							}
						}
					}
				}
			}
		}
	}
}
