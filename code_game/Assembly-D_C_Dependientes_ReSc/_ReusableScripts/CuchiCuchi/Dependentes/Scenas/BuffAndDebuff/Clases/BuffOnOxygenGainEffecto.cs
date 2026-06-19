using System;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000C8 RID: 200
	public class BuffOnOxygenGainEffecto : Efecto<BuffOnOxygenGainEffecto, BuffOnOxygenGainArg>
	{
		// Token: 0x06000421 RID: 1057 RVA: 0x00016EE4 File Offset: 0x000150E4
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			BuffOnOxygenGainArg buffOnOxygenGainArg = argument as BuffOnOxygenGainArg;
			if (buffOnOxygenGainArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ICharacterRespirador characterRespirador = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (characterRespirador == null)
			{
				return;
			}
			ModificadorDeFloat modificadorDeFloat;
			if (buffOnOxygenGainArg.justForCansamiento)
			{
				modificadorDeFloat = characterRespirador.demandaDeOxigenoAntesDeCansanrseModificable.ObtenerModificadorNotNull(buffEvento.id);
			}
			else
			{
				modificadorDeFloat = characterRespirador.demandaDeOxigenoModificable.ObtenerModificadorNotNull(buffEvento.id);
			}
			modificadorDeFloat.valor.valor = buffOnOxygenGainArg.gainMod;
			float num = 10f;
			buffEvento.quality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(1f, 13f, MathfExtension.InverseLerpConMedio(1f / num, 1f, num, buffOnOxygenGainArg.gainMod * (float)stacks).InInOutOutPow(2f, 2f, 0.5f)));
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00016FB4 File Offset: 0x000151B4
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
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
			if (!characterRespirador.demandaDeOxigenoModificable.TryRemoverModificador(buffEvento.id))
			{
				Debug.LogError("no se puedo remover buff " + buffEvento.id + " no existia en modificables ", caster as MonoBehaviour);
			}
		}
	}
}
