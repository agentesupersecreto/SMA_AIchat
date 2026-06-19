using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000B7 RID: 183
	public class BuffOnEmotionGainOfInteractionEffecto : Efecto<BuffOnEmotionGainOfInteractionEffecto, BuffOnEmotionGainOfInteractionArg>
	{
		// Token: 0x060003CB RID: 971 RVA: 0x000157D0 File Offset: 0x000139D0
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
			BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg = (BuffOnEmotionGainOfInteractionArg)argument;
			ReaccionHumana emo = buffOnEmotionGainOfInteractionArg.emo;
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(emo);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			float num = Mathf.Clamp(buffOnEmotionGainOfInteractionArg.gain, 1E-09f, float.MaxValue);
			if (buffOnEmotionGainOfInteractionArg.changedByFatigue)
			{
				MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
				Character character = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
				float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString, 1f);
				buffOnEmotionGainOfInteractionArg.substractedByFatigue = 1f / Mathf.Lerp(1f, buffOnEmotionGainOfInteractionArg.gain, applyableFatigueMod);
				num = buffOnEmotionGainOfInteractionArg.gain * buffOnEmotionGainOfInteractionArg.substractedByFatigue;
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			for (int i = 0; i < buffOnEmotionGainOfInteractionArg.data.Length; i++)
			{
				BuffOnEmotionGainOfInteractionArg.Data data = buffOnEmotionGainOfInteractionArg.data[i];
				for (int j = 0; j < data.estimuladas.Length; j++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimuladas[j];
					componentNotNull.GetModificadorTradicionalNotNull(data.tipo, parteDelCuerpoHumano, new ParteQuePuedeEstimular?(data.estiulante), data.direccion).gainModificable.ObtenerModificadorNotNull(buffEvento.id).valor.valor = num;
				}
			}
			DisplayableBuff displayableBuff = buffEvento as DisplayableBuff;
			if (displayableBuff == null)
			{
				return;
			}
			displayableBuff.UpdateQualityAndVisibility(0.1f, 1f, 10f, num, 3f, emo.EsPositiva());
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00015980 File Offset: 0x00013B80
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
			BuffOnEmotionGainOfInteractionArg buffOnEmotionGainOfInteractionArg = (BuffOnEmotionGainOfInteractionArg)argument;
			ReaccionHumana emo = buffOnEmotionGainOfInteractionArg.emo;
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(emo);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			for (int i = 0; i < buffOnEmotionGainOfInteractionArg.data.Length; i++)
			{
				BuffOnEmotionGainOfInteractionArg.Data data = buffOnEmotionGainOfInteractionArg.data[i];
				for (int j = 0; j < data.estimuladas.Length; j++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimuladas[j];
					ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional modificadorTradicional = componentNotNull.GetModificadorTradicional(data.tipo, parteDelCuerpoHumano, new ParteQuePuedeEstimular?(data.estiulante), data.direccion);
					if (modificadorTradicional == null || !modificadorTradicional.gainModificable.TryRemoverModificador(buffEvento.id))
					{
						Debug.LogError("no se puedo remover buff " + buffEvento.id + " no existia en modificables ", caster as MonoBehaviour);
					}
				}
			}
		}
	}
}
