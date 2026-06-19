using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000D9 RID: 217
	[Serializable]
	public class BuffOnEyacAmountEffecto : ByInteraccionEnScenaEffecto<BuffOnEyacAmountEffecto, BuffOnEyacAmountArg>
	{
		// Token: 0x06000467 RID: 1127 RVA: 0x0001A010 File Offset: 0x00018210
		protected override void OnApply(object affected, BuffOnEyacAmountArg argument, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			SemenParaPene semenParaPene = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (semenParaPene == null)
			{
				return;
			}
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			if (argument.buffOn.operation == ProductOperation.mult)
			{
				ModificadorDeFloat modificadorDeFloat = semenParaPene.cantidadModificable.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.1f, 10f, 0.25f);
				base.UpdateQualityAndVisibility(buffEvento, 0.1f, 1f, 10f, modificadorDeFloat.valor.valor, 3f, true);
				argument.actualValue = new float?(modificadorDeFloat.valor.valor);
				return;
			}
			throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0001A116 File Offset: 0x00018316
		protected override void OnStay(object affected, BuffOnEyacAmountArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0001A124 File Offset: 0x00018324
		protected override void OnRemove(object affected, BuffOnEyacAmountArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			SemenParaPene semenParaPene = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (semenParaPene == null)
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
			if (!semenParaPene.cantidadModificable.TryRemoverModificador(evento.id))
			{
				Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
				return;
			}
		}
	}
}
