using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000BA RID: 186
	[Serializable]
	public class BuffOnEmotionIntervalExpandOfInteractionEffecto : Efecto<BuffOnEmotionIntervalExpandOfInteractionEffecto, BuffOnEmotionIntervalExpandOfInteractionArg>
	{
		// Token: 0x060003DE RID: 990 RVA: 0x00015C3C File Offset: 0x00013E3C
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
			BuffOnEmotionIntervalExpandOfInteractionArg buffOnEmotionIntervalExpandOfInteractionArg = (BuffOnEmotionIntervalExpandOfInteractionArg)argument;
			ReaccionHumana emo = buffOnEmotionIntervalExpandOfInteractionArg.emo;
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(emo);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			float num = Mathf.Clamp(buffOnEmotionIntervalExpandOfInteractionArg.expand, 1E-09f, float.MaxValue);
			if (buffOnEmotionIntervalExpandOfInteractionArg.changedByFatigue)
			{
				MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
				Character character = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
				float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString, 1f);
				buffOnEmotionIntervalExpandOfInteractionArg.substractedByFatigue = 1f / Mathf.Lerp(1f, buffOnEmotionIntervalExpandOfInteractionArg.expand, applyableFatigueMod);
				num = buffOnEmotionIntervalExpandOfInteractionArg.expand * buffOnEmotionIntervalExpandOfInteractionArg.substractedByFatigue;
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			for (int i = 0; i < buffOnEmotionIntervalExpandOfInteractionArg.data.Length; i++)
			{
				BuffOnEmotionIntervalExpandOfInteractionArg.Data data = buffOnEmotionIntervalExpandOfInteractionArg.data[i];
				for (int j = 0; j < data.estimuladas.Length; j++)
				{
					componentNotNull.GetModificadorTradicionalNotNull(data.tipo, data.estimuladas[j], new ParteQuePuedeEstimular?(data.estiulante), data.direccion).interExpandModificable.ObtenerModificadorNotNull(buffEvento.id).valor.valor = num;
				}
			}
			DisplayableBuff displayableBuff = buffEvento as DisplayableBuff;
			if (displayableBuff == null)
			{
				return;
			}
			displayableBuff.UpdateQualityAndVisibility(0.2f, 1f, 5f, num, 2f, emo.EsPositiva());
		}

		// Token: 0x060003DF RID: 991 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00015DE8 File Offset: 0x00013FE8
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
			BuffOnEmotionIntervalExpandOfInteractionArg buffOnEmotionIntervalExpandOfInteractionArg = (BuffOnEmotionIntervalExpandOfInteractionArg)argument;
			ReaccionHumana emo = buffOnEmotionIntervalExpandOfInteractionArg.emo;
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(emo);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			for (int i = 0; i < buffOnEmotionIntervalExpandOfInteractionArg.data.Length; i++)
			{
				BuffOnEmotionIntervalExpandOfInteractionArg.Data data = buffOnEmotionIntervalExpandOfInteractionArg.data[i];
				for (int j = 0; j < data.estimuladas.Length; j++)
				{
					ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional modificadorTradicional = componentNotNull.GetModificadorTradicional(data.tipo, data.estimuladas[j], new ParteQuePuedeEstimular?(data.estiulante), data.direccion);
					if (modificadorTradicional == null || !modificadorTradicional.interExpandModificable.TryRemoverModificador(buffEvento.id))
					{
						Debug.LogError("no se puedo remover buff " + buffEvento.id + " no existia en modificables ", caster as MonoBehaviour);
					}
				}
			}
		}
	}
}
