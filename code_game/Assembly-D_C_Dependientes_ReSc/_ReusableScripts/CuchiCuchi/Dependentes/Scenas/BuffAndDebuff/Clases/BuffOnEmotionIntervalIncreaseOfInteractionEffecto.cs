using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000BE RID: 190
	[Serializable]
	public class BuffOnEmotionIntervalIncreaseOfInteractionEffecto : Efecto<BuffOnEmotionIntervalIncreaseOfInteractionEffecto, BuffOnEmotionIntervalIncreaseOfInteractionArg>
	{
		// Token: 0x060003F1 RID: 1009 RVA: 0x000160A0 File Offset: 0x000142A0
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
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
			BuffOnEmotionIntervalIncreaseOfInteractionArg buffOnEmotionIntervalIncreaseOfInteractionArg = (BuffOnEmotionIntervalIncreaseOfInteractionArg)argument;
			ReaccionHumana emo = buffOnEmotionIntervalIncreaseOfInteractionArg.emo;
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(emo);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			float num = Mathf.Clamp(buffOnEmotionIntervalIncreaseOfInteractionArg.increase, 1E-09f, float.MaxValue);
			if (buffOnEmotionIntervalIncreaseOfInteractionArg.changedByFatigue)
			{
				MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
				Character character = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
				float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString, 1f);
				buffOnEmotionIntervalIncreaseOfInteractionArg.substractedByFatigue = 1f / Mathf.Lerp(1f, buffOnEmotionIntervalIncreaseOfInteractionArg.increase, applyableFatigueMod);
				num = buffOnEmotionIntervalIncreaseOfInteractionArg.increase * buffOnEmotionIntervalIncreaseOfInteractionArg.substractedByFatigue;
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			for (int i = 0; i < buffOnEmotionIntervalIncreaseOfInteractionArg.data.Length; i++)
			{
				BuffOnEmotionIntervalIncreaseOfInteractionArg.Data data = buffOnEmotionIntervalIncreaseOfInteractionArg.data[i];
				for (int j = 0; j < data.estimuladas.Length; j++)
				{
					ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional modificadorTradicionalNotNull = componentNotNull.GetModificadorTradicionalNotNull(data.tipo, data.estimuladas[j], new ParteQuePuedeEstimular?(data.estiulante), data.direccion);
					ModificadorDeFloat modificadorDeFloat;
					switch (buffOnEmotionIntervalIncreaseOfInteractionArg.tipo)
					{
					case BuffOnEmotionIntervalIncreaseOfInteractionArg.Tipo.minMax:
						modificadorDeFloat = modificadorTradicionalNotNull.interPositionMinMaxModificable.ObtenerModificadorNotNull(buffEvento.id);
						break;
					case BuffOnEmotionIntervalIncreaseOfInteractionArg.Tipo.min:
						modificadorDeFloat = modificadorTradicionalNotNull.interPositionMinModificable.ObtenerModificadorNotNull(buffEvento.id);
						break;
					case BuffOnEmotionIntervalIncreaseOfInteractionArg.Tipo.max:
						modificadorDeFloat = modificadorTradicionalNotNull.interPositionMaxModificable.ObtenerModificadorNotNull(buffEvento.id);
						break;
					default:
						throw new ArgumentOutOfRangeException(buffOnEmotionIntervalIncreaseOfInteractionArg.tipo.ToString());
					}
					modificadorDeFloat.valor.valor = num;
				}
			}
			DisplayableBuff displayableBuff = buffEvento as DisplayableBuff;
			if (displayableBuff == null)
			{
				return;
			}
			displayableBuff.UpdateQualityAndVisibility(0.2f, 1f, 5f, num, 2f, emo.EsPositiva());
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x000162C4 File Offset: 0x000144C4
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				Debug.LogError("no se puedo encontrar BuffEvento ", caster as MonoBehaviour);
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null)
			{
				Debug.LogError("no se puedo encontrar EmocionesHumanasBase ", caster as MonoBehaviour);
				return;
			}
			BuffOnEmotionIntervalIncreaseOfInteractionArg buffOnEmotionIntervalIncreaseOfInteractionArg = (BuffOnEmotionIntervalIncreaseOfInteractionArg)argument;
			ReaccionHumana emo = buffOnEmotionIntervalIncreaseOfInteractionArg.emo;
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(emo);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			for (int i = 0; i < buffOnEmotionIntervalIncreaseOfInteractionArg.data.Length; i++)
			{
				BuffOnEmotionIntervalIncreaseOfInteractionArg.Data data = buffOnEmotionIntervalIncreaseOfInteractionArg.data[i];
				for (int j = 0; j < data.estimuladas.Length; j++)
				{
					ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional modificadorTradicional = componentNotNull.GetModificadorTradicional(data.tipo, data.estimuladas[j], new ParteQuePuedeEstimular?(data.estiulante), data.direccion);
					ModificableDeFloat modificableDeFloat;
					switch (buffOnEmotionIntervalIncreaseOfInteractionArg.tipo)
					{
					case BuffOnEmotionIntervalIncreaseOfInteractionArg.Tipo.minMax:
						modificableDeFloat = ((modificadorTradicional != null) ? modificadorTradicional.interPositionMinMaxModificable : null);
						break;
					case BuffOnEmotionIntervalIncreaseOfInteractionArg.Tipo.min:
						modificableDeFloat = ((modificadorTradicional != null) ? modificadorTradicional.interPositionMinModificable : null);
						break;
					case BuffOnEmotionIntervalIncreaseOfInteractionArg.Tipo.max:
						modificableDeFloat = ((modificadorTradicional != null) ? modificadorTradicional.interPositionMaxModificable : null);
						break;
					default:
						throw new ArgumentOutOfRangeException(buffOnEmotionIntervalIncreaseOfInteractionArg.tipo.ToString());
					}
					if (modificadorTradicional == null || !modificableDeFloat.TryRemoverModificador(buffEvento.id))
					{
						Debug.LogError("no se puedo remover buff " + buffEvento.id + " no existia en modificables ", caster as MonoBehaviour);
					}
				}
			}
		}
	}
}
