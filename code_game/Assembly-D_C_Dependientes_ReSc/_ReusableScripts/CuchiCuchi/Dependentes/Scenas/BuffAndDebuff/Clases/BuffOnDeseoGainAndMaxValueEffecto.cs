using System;
using Assets.Base.Plugins.Runtime;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000AD RID: 173
	public class BuffOnDeseoGainAndMaxValueEffecto : Efecto<BuffOnDeseoGainAndMaxValueEffecto, BuffOnDeseoGainAndMaxValueArg>
	{
		// Token: 0x06000399 RID: 921 RVA: 0x00014D08 File Offset: 0x00012F08
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			BuffOnDeseoGainAndMaxValueArg buffOnDeseoGainAndMaxValueArg = argument as BuffOnDeseoGainAndMaxValueArg;
			if (buffOnDeseoGainAndMaxValueArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			Deseos deseos = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (deseos == null)
			{
				return;
			}
			ModificadorDeFloat modificadorDeFloat;
			ModificadorDeFloat modificadorDeFloat2;
			switch (buffOnDeseoGainAndMaxValueArg.des)
			{
			case Desires.All:
			case Desires.None:
				return;
			case Desires.Crotch:
				modificadorDeFloat = deseos.modificablesGains.entrepierna.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat2 = deseos.valoresMaximosSumablePercentage.entrepierna.ObtenerModificadorNotNull(buffEvento.id);
				break;
			case Desires.Ass:
				modificadorDeFloat = deseos.modificablesGains.trasero.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat2 = deseos.valoresMaximosSumablePercentage.trasero.ObtenerModificadorNotNull(buffEvento.id);
				break;
			case Desires.Breast:
				modificadorDeFloat = deseos.modificablesGains.senos.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat2 = deseos.valoresMaximosSumablePercentage.senos.ObtenerModificadorNotNull(buffEvento.id);
				break;
			case Desires.Mouth:
				modificadorDeFloat = deseos.modificablesGains.labios.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat2 = deseos.valoresMaximosSumablePercentage.labios.ObtenerModificadorNotNull(buffEvento.id);
				break;
			default:
				throw new ArgumentOutOfRangeException(buffOnDeseoGainAndMaxValueArg.des.ToString());
			}
			modificadorDeFloat.valor.valor = (modificadorDeFloat2.valor.valor = buffOnDeseoGainAndMaxValueArg.mod);
			buffEvento.quality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(1f, 13f, MathfExtension.InverseLerpConMedio(0.2f, 1f, 5f, buffOnDeseoGainAndMaxValueArg.mod * (float)stacks).InInOutOutPow(2f, 2f, 0.5f)));
		}

		// Token: 0x0600039A RID: 922 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00014EC4 File Offset: 0x000130C4
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			BuffOnDeseoGainAndMaxValueArg buffOnDeseoGainAndMaxValueArg = argument as BuffOnDeseoGainAndMaxValueArg;
			if (buffOnDeseoGainAndMaxValueArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			Deseos deseos = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (deseos == null)
			{
				return;
			}
			switch (buffOnDeseoGainAndMaxValueArg.des)
			{
			case Desires.All:
			case Desires.None:
				return;
			case Desires.Crotch:
				deseos.modificablesGains.entrepierna.TryRemoverModificador(buffEvento.id);
				deseos.valoresMaximosSumablePercentage.entrepierna.TryRemoverModificador(buffEvento.id);
				return;
			case Desires.Ass:
				deseos.modificablesGains.trasero.TryRemoverModificador(buffEvento.id);
				deseos.valoresMaximosSumablePercentage.trasero.TryRemoverModificador(buffEvento.id);
				return;
			case Desires.Breast:
				deseos.modificablesGains.senos.TryRemoverModificador(buffEvento.id);
				deseos.valoresMaximosSumablePercentage.senos.TryRemoverModificador(buffEvento.id);
				return;
			case Desires.Mouth:
				deseos.modificablesGains.labios.TryRemoverModificador(buffEvento.id);
				deseos.valoresMaximosSumablePercentage.labios.TryRemoverModificador(buffEvento.id);
				return;
			default:
				throw new ArgumentOutOfRangeException(buffOnDeseoGainAndMaxValueArg.des.ToString());
			}
		}
	}
}
