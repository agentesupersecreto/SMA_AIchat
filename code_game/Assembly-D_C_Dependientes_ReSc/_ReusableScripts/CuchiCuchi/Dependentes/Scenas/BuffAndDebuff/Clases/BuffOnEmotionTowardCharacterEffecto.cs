using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000D7 RID: 215
	[Serializable]
	public class BuffOnEmotionTowardCharacterEffecto : ByInteraccionEnScenaEffecto<BuffOnEmotionTowardCharacterEffecto, BuffOnEmotionTowardCharacterArg>
	{
		// Token: 0x06000462 RID: 1122 RVA: 0x0001997C File Offset: 0x00017B7C
		protected override void OnApply(object affected, BuffOnEmotionTowardCharacterArg argument, object buff, object caster)
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
			EmocionHacia.Hacia haciaNotNull = emocion.GetComponentNotNull<EmocionHacia>().GetHaciaNotNull(argument.buffOn.towardID);
			switch (argument.buffOn.modifier)
			{
			case EmotionModifier.defaultValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation == Operation.add)
				{
					ModificadorDeFloat modificadorDeFloat = haciaNotNull.sumadorDeValor.ObtenerModificadorNotNull(buffEvento.id);
					modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -100f, 100f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, -100f, 0f, 100f, modificadorDeFloat.valor.valor, 2f, emotion.IsGood());
					argument.actualValue = new float?(modificadorDeFloat.valor.valor);
					return;
				}
				if (operation != Operation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				ModificadorDeFloat modificadorDeFloat2 = haciaNotNull.multiplicadorDeValor.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat2.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.333f, 3f, 0.25f);
				base.UpdateQualityAndVisibility(buffEvento, 0.333f, 1f, 3f, modificadorDeFloat2.valor.valor, 3f, emotion.IsGood());
				argument.actualValue = new float?(modificadorDeFloat2.valor.valor);
				return;
			}
			case EmotionModifier.minValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation == Operation.add)
				{
					ModificadorDeFloat modificadorDeFloat3 = haciaNotNull.minimoLimiteValor.ObtenerModificadorNotNull(buffEvento.id);
					modificadorDeFloat3.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -100f, 99f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, -100f, 0f, 99f, modificadorDeFloat3.valor.valor, 2f, emotion.IsGood());
					argument.actualValue = new float?(modificadorDeFloat3.valor.valor);
					return;
				}
				if (operation != Operation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				break;
			}
			case EmotionModifier.maxValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add && operation != Operation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				break;
			}
			case EmotionModifier.gain:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation == Operation.mult)
					{
						ModificadorDeFloat modificadorDeFloat4 = haciaNotNull.multiplicadorDeAumento.ObtenerModificadorNotNull(buffEvento.id);
						modificadorDeFloat4.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.1f, 10f, 0.25f);
						base.UpdateQualityAndVisibility(buffEvento, 0.1f, 1f, 10f, modificadorDeFloat4.valor.valor, 3f, emotion.IsGood());
						argument.actualValue = new float?(modificadorDeFloat4.valor.valor);
						return;
					}
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00019D54 File Offset: 0x00017F54
		protected override void OnStay(object affected, BuffOnEmotionTowardCharacterArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00019D64 File Offset: 0x00017F64
		protected override void OnRemove(object affected, BuffOnEmotionTowardCharacterArg argument, object buff, object caster)
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
			EmocionHacia.Hacia haciaNotNull = emocion.GetComponentNotNull<EmocionHacia>().GetHaciaNotNull(argument.buffOn.towardID);
			switch (argument.buffOn.modifier)
			{
			case EmotionModifier.defaultValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation != Operation.mult)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
					}
					if (!haciaNotNull.multiplicadorDeValor.TryRemoverModificador(evento.id))
					{
						Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
						return;
					}
				}
				else if (!haciaNotNull.sumadorDeValor.TryRemoverModificador(evento.id))
				{
					Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
					return;
				}
				break;
			}
			case EmotionModifier.minValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation != Operation.mult)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
					}
				}
				else if (!haciaNotNull.minimoLimiteValor.TryRemoverModificador(evento.id))
				{
					Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
					return;
				}
				break;
			}
			case EmotionModifier.maxValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add && operation != Operation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				break;
			}
			case EmotionModifier.gain:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation != Operation.mult)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
					}
					if (!haciaNotNull.multiplicadorDeAumento.TryRemoverModificador(evento.id))
					{
						Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
						return;
					}
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
		}
	}
}
