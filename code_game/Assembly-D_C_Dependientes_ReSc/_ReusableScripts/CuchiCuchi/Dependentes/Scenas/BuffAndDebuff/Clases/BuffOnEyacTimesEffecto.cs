using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000DB RID: 219
	[Serializable]
	public class BuffOnEyacTimesEffecto : ByInteraccionEnScenaEffecto<BuffOnEyacTimesEffecto, BuffOnEyacTimesArg>
	{
		// Token: 0x0600046C RID: 1132 RVA: 0x0001A1F4 File Offset: 0x000183F4
		protected override void OnApply(object affected, BuffOnEyacTimesArg argument, object buff, object caster)
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
				ModificadorDeFloat modificadorDeFloat = semenParaPene.contraccionesModificable.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.1f, 10f, 0.25f);
				base.UpdateQualityAndVisibility(buffEvento, 0.1f, 1f, 10f, modificadorDeFloat.valor.valor, 3f, true);
				argument.actualValue = new float?(modificadorDeFloat.valor.valor);
				return;
			}
			throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0001A2FA File Offset: 0x000184FA
		protected override void OnStay(object affected, BuffOnEyacTimesArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0001A308 File Offset: 0x00018508
		protected override void OnRemove(object affected, BuffOnEyacTimesArg argument, object buff, object caster)
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
			if (!semenParaPene.contraccionesModificable.TryRemoverModificador(evento.id))
			{
				Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
				return;
			}
		}
	}
}
