using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000E9 RID: 233
	[Serializable]
	public class BuffOnOxygenDemandEffecto : ByInteraccionEnScenaEffecto<BuffOnOxygenDemandEffecto, BuffOnOxygenDemandArg>
	{
		// Token: 0x06000492 RID: 1170 RVA: 0x0001BA54 File Offset: 0x00019C54
		protected override void OnApply(object affected, BuffOnOxygenDemandArg argument, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ICharacterRespirador characterRespirador = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (characterRespirador == null)
			{
				return;
			}
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			if (argument.buffOn.operation == ProductOperation.mult)
			{
				ModificadorDeFloat modificadorDeFloat = characterRespirador.demandaDeOxigenoModificable.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.1f, 10f, 0.25f);
				base.UpdateQualityAndVisibility(buffEvento, 0.1f, 1f, 10f, modificadorDeFloat.valor.valor, 3f, false);
				argument.actualValue = new float?(modificadorDeFloat.valor.valor);
				return;
			}
			throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0001BB54 File Offset: 0x00019D54
		protected override void OnStay(object affected, BuffOnOxygenDemandArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0001BB64 File Offset: 0x00019D64
		protected override void OnRemove(object affected, BuffOnOxygenDemandArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ICharacterRespirador characterRespirador = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (characterRespirador == null)
			{
				return;
			}
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			if (argument.buffOn.operation != ProductOperation.mult)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			}
			if (!characterRespirador.demandaDeOxigenoModificable.TryRemoverModificador(evento.id))
			{
				Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
				return;
			}
		}
	}
}
