using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000E7 RID: 231
	[Serializable]
	public class BuffOnKarmaEffecto : ByInteraccionEnScenaEffecto<BuffOnKarmaEffecto, BuffOnKarmaArg>
	{
		// Token: 0x0600048D RID: 1165 RVA: 0x0001B7B0 File Offset: 0x000199B0
		protected override void OnApply(object affected, BuffOnKarmaArg argument, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ICharacterKarma characterKarma = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (characterKarma == null)
			{
				return;
			}
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			Operation operation = argument.buffOn.operation;
			if (operation == Operation.add)
			{
				ModificadorDeFloat modificadorDeFloat = characterKarma.sumable.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -100f, 100f, 0.25f);
				base.UpdateQualityAndVisibility(buffEvento, -100f, 0f, 100f, modificadorDeFloat.valor.valor, 3f, true);
				argument.actualValue = new float?(modificadorDeFloat.valor.valor);
				return;
			}
			if (operation != Operation.mult)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			}
			ModificadorDeFloat modificadorDeFloat2 = characterKarma.modificable.ObtenerModificadorNotNull(buffEvento.id);
			modificadorDeFloat2.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.1f, 10f, 0.25f);
			base.UpdateQualityAndVisibility(buffEvento, 0.1f, 1f, 10f, modificadorDeFloat2.valor.valor, 3f, true);
			argument.actualValue = new float?(modificadorDeFloat2.valor.valor);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0001B939 File Offset: 0x00019B39
		protected override void OnStay(object affected, BuffOnKarmaArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0001B948 File Offset: 0x00019B48
		protected override void OnRemove(object affected, BuffOnKarmaArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ICharacterKarma characterKarma = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (characterKarma == null)
			{
				return;
			}
			if (argument.buffOn.modifier == SimpleModifier.value)
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation != Operation.mult)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
					}
					if (!characterKarma.modificable.TryRemoverModificador(evento.id))
					{
						Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
						return;
					}
				}
				else if (!characterKarma.sumable.TryRemoverModificador(evento.id))
				{
					Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
					return;
				}
				return;
			}
			throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
		}
	}
}
