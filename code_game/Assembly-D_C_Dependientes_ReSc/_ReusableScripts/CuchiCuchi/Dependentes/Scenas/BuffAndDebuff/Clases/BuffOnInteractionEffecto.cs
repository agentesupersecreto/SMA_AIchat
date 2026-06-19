using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000E5 RID: 229
	[Serializable]
	public class BuffOnInteractionEffecto : ByInteraccionEnScenaEffecto<BuffOnInteractionEffecto, BuffOnInteractionArg>
	{
		// Token: 0x06000488 RID: 1160 RVA: 0x0001AF14 File Offset: 0x00019114
		protected override void OnApply(object affected, BuffOnInteractionArg argument, object buff, object caster)
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
			Emotion emotion = argument.buffOn.emotion;
			ReaccionHumana reaccionHumana = emotion.Parse();
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(reaccionHumana);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emotion.ToString(), caster as MonoBehaviour);
				return;
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			InterationReceivedType interationReceivedType = argument.buffOn.interationReceivedType;
			TriggeringBodyPart fromPart = argument.buffOn.fromPart;
			SensitiveBodyPart toPart = argument.buffOn.toPart;
			switch (argument.buffOn.modifier)
			{
			case InteractionModifier.damage:
				if (argument.buffOn.operation == ProductOperation.mult)
				{
					float num = ((emotion == Emotion.pleasure) ? 3f : 10f);
					float num2 = ((emotion == Emotion.pleasure) ? 0.333f : 0.1f);
					ModificadorDeFloat modificadorDeFloat = componentNotNull.GetModificadorAdvancedNotNull(interationReceivedType, fromPart, toPart).gainModificable.ObtenerModificadorNotNull(buffEvento.id);
					modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, num2, num, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, num2, 1f, num, modificadorDeFloat.valor.valor, 3f, emotion.IsGood());
					argument.actualValue = new float?(modificadorDeFloat.valor.valor);
					return;
				}
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			case InteractionModifier.gainIntervalExpand:
				if (reaccionHumana != ReaccionHumana.placer && reaccionHumana != ReaccionHumana.dolor)
				{
					throw new NotSupportedException();
				}
				if (argument.buffOn.operation == ProductOperation.mult)
				{
					ModificadorDeFloat modificadorDeFloat2 = componentNotNull.GetModificadorAdvancedNotNull(interationReceivedType, fromPart, toPart).interExpandModificable.ObtenerModificadorNotNull(buffEvento.id);
					modificadorDeFloat2.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.2f, 5f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, 0.2f, 1f, 5f, modificadorDeFloat2.valor.valor, 3f, emotion.IsGood());
					argument.actualValue = new float?(modificadorDeFloat2.valor.valor);
					return;
				}
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			case InteractionModifier.gainMinMaxIntervalPosition:
				if (reaccionHumana != ReaccionHumana.placer && reaccionHumana != ReaccionHumana.dolor)
				{
					throw new NotSupportedException();
				}
				if (argument.buffOn.operation == ProductOperation.mult)
				{
					ModificadorDeFloat modificadorDeFloat3 = componentNotNull.GetModificadorAdvancedNotNull(interationReceivedType, fromPart, toPart).interPositionMinMaxModificable.ObtenerModificadorNotNull(buffEvento.id);
					modificadorDeFloat3.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.2f, 5f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, 0.2f, 1f, 5f, modificadorDeFloat3.valor.valor, 3f, emotion.IsGood());
					argument.actualValue = new float?(modificadorDeFloat3.valor.valor);
					return;
				}
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			case InteractionModifier.gainMinIntervalPosition:
				if (reaccionHumana != ReaccionHumana.placer && reaccionHumana != ReaccionHumana.dolor)
				{
					throw new NotSupportedException();
				}
				if (argument.buffOn.operation == ProductOperation.mult)
				{
					ModificadorDeFloat modificadorDeFloat4 = componentNotNull.GetModificadorAdvancedNotNull(interationReceivedType, fromPart, toPart).interPositionMinModificable.ObtenerModificadorNotNull(buffEvento.id);
					modificadorDeFloat4.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.2f, 5f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, 0.2f, 1f, 5f, modificadorDeFloat4.valor.valor, 3f, emotion.IsGood());
					argument.actualValue = new float?(modificadorDeFloat4.valor.valor);
					return;
				}
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			case InteractionModifier.gainMaxIntervalPosition:
				if (reaccionHumana != ReaccionHumana.placer && reaccionHumana != ReaccionHumana.dolor)
				{
					throw new NotSupportedException();
				}
				if (argument.buffOn.operation == ProductOperation.mult)
				{
					ModificadorDeFloat modificadorDeFloat5 = componentNotNull.GetModificadorAdvancedNotNull(interationReceivedType, fromPart, toPart).interPositionMaxModificable.ObtenerModificadorNotNull(buffEvento.id);
					modificadorDeFloat5.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.2f, 5f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, 0.2f, 1f, 5f, modificadorDeFloat5.valor.valor, 3f, emotion.IsGood());
					argument.actualValue = new float?(modificadorDeFloat5.valor.valor);
					return;
				}
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			default:
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0001B40E File Offset: 0x0001960E
		protected override void OnStay(object affected, BuffOnInteractionArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0001B41C File Offset: 0x0001961C
		protected override void OnRemove(object affected, BuffOnInteractionArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null)
			{
				return;
			}
			Emotion emotion = argument.buffOn.emotion;
			ReaccionHumana reaccionHumana = emotion.Parse();
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(reaccionHumana);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emotion.ToString(), caster as MonoBehaviour);
				return;
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			InterationReceivedType interationReceivedType = argument.buffOn.interationReceivedType;
			TriggeringBodyPart fromPart = argument.buffOn.fromPart;
			SensitiveBodyPart toPart = argument.buffOn.toPart;
			switch (argument.buffOn.modifier)
			{
			case InteractionModifier.damage:
			{
				if (argument.buffOn.operation != ProductOperation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced = componentNotNull.GetModificadorAdvanced(interationReceivedType, fromPart, toPart);
				if (modificadorAdvanced == null || !modificadorAdvanced.gainModificable.TryRemoverModificador(evento.id))
				{
					Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
					return;
				}
				break;
			}
			case InteractionModifier.gainIntervalExpand:
			{
				if (reaccionHumana != ReaccionHumana.placer && reaccionHumana != ReaccionHumana.dolor)
				{
					throw new NotSupportedException();
				}
				if (argument.buffOn.operation != ProductOperation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced2 = componentNotNull.GetModificadorAdvanced(interationReceivedType, fromPart, toPart);
				if (modificadorAdvanced2 == null || !modificadorAdvanced2.interExpandModificable.TryRemoverModificador(evento.id))
				{
					Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
					return;
				}
				break;
			}
			case InteractionModifier.gainMinMaxIntervalPosition:
			{
				if (reaccionHumana != ReaccionHumana.placer && reaccionHumana != ReaccionHumana.dolor)
				{
					throw new NotSupportedException();
				}
				if (argument.buffOn.operation != ProductOperation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced3 = componentNotNull.GetModificadorAdvanced(interationReceivedType, fromPart, toPart);
				if (modificadorAdvanced3 == null || !modificadorAdvanced3.interPositionMinMaxModificable.TryRemoverModificador(evento.id))
				{
					Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
					return;
				}
				break;
			}
			case InteractionModifier.gainMinIntervalPosition:
			{
				if (reaccionHumana != ReaccionHumana.placer && reaccionHumana != ReaccionHumana.dolor)
				{
					throw new NotSupportedException();
				}
				if (argument.buffOn.operation != ProductOperation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced4 = componentNotNull.GetModificadorAdvanced(interationReceivedType, fromPart, toPart);
				if (modificadorAdvanced4 == null || !modificadorAdvanced4.interPositionMinModificable.TryRemoverModificador(evento.id))
				{
					Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
					return;
				}
				break;
			}
			case InteractionModifier.gainMaxIntervalPosition:
			{
				if (reaccionHumana != ReaccionHumana.placer && reaccionHumana != ReaccionHumana.dolor)
				{
					throw new NotSupportedException();
				}
				if (argument.buffOn.operation != ProductOperation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced5 = componentNotNull.GetModificadorAdvanced(interationReceivedType, fromPart, toPart);
				if (modificadorAdvanced5 == null || !modificadorAdvanced5.interPositionMaxModificable.TryRemoverModificador(evento.id))
				{
					Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
					return;
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
		}
	}
}
