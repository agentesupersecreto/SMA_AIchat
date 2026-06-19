using System;
using Assets.TValle.BeachGirl;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000D5 RID: 213
	[Serializable]
	public class BuffOnEmotionEffecto : ByInteraccionEnScenaEffecto<BuffOnEmotionEffecto, BuffOnEmotionArg>
	{
		// Token: 0x0600045D RID: 1117 RVA: 0x000192E4 File Offset: 0x000174E4
		protected override void OnApply(object affected, BuffOnEmotionArg argument, object buff, object caster)
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
			bool flag = (!(emocionesHumanasBase.owner is IMaleCharacter) || emotion != Emotion.pleasure) && emotion.IsGood();
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(reaccionHumana);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emotion.ToString(), caster as MonoBehaviour);
				return;
			}
			switch (argument.buffOn.modifier)
			{
			case EmotionModifier.defaultValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation == Operation.add)
				{
					ModificadorDeFloat modificadorDeFloat = emocion.sumadorDeValor.ObtenerModificadorNotNull(buffEvento.id);
					modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -100f, 100f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, -100f, 0f, 100f, modificadorDeFloat.valor.valor, 3f, flag);
					argument.actualValue = new float?(modificadorDeFloat.valor.valor);
					return;
				}
				if (operation != Operation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				ModificadorDeFloat modificadorDeFloat2 = emocion.multiplicadorDeValor.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat2.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.333f, 3f, 0.25f);
				base.UpdateQualityAndVisibility(buffEvento, 0.333f, 1f, 3f, modificadorDeFloat2.valor.valor, 3f, flag);
				argument.actualValue = new float?(modificadorDeFloat2.valor.valor);
				return;
			}
			case EmotionModifier.minValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation == Operation.add)
				{
					ModificadorDeFloat modificadorDeFloat3 = emocion.minimoLimiteValorSumado.ObtenerModificadorNotNull(buffEvento.id);
					modificadorDeFloat3.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -100f, 99f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, -100f, 0f, 99f, modificadorDeFloat3.valor.valor, 3f, flag);
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
						float num = ((emotion == Emotion.pleasure) ? 2f : 10f);
						float num2 = ((emotion == Emotion.pleasure) ? 0.5f : 0.1f);
						ModificadorDeFloat modificadorDeFloat4 = emocion.multiplicadorDeAumento.ObtenerModificadorNotNull(buffEvento.id);
						modificadorDeFloat4.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, num2, num, 0.25f);
						base.UpdateQualityAndVisibility(buffEvento, num2, 1f, num, modificadorDeFloat4.valor.valor, 3f, flag);
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

		// Token: 0x0600045E RID: 1118 RVA: 0x000196CA File Offset: 0x000178CA
		protected override void OnStay(object affected, BuffOnEmotionArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x000196D8 File Offset: 0x000178D8
		protected override void OnRemove(object affected, BuffOnEmotionArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				Debug.LogError("no se puedo remover buff, buff no es valido ", caster as MonoBehaviour);
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
					if (!emocion.multiplicadorDeValor.TryRemoverModificador(evento.id))
					{
						Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
						return;
					}
				}
				else if (!emocion.sumadorDeValor.TryRemoverModificador(evento.id))
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
				else if (!emocion.minimoLimiteValorSumado.TryRemoverModificador(evento.id))
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
					if (!emocion.multiplicadorDeAumento.TryRemoverModificador(evento.id))
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
