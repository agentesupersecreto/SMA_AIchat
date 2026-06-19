using System;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000C0 RID: 192
	[Serializable]
	public class BuffOnFavorabilityValueTowardCharacterEffecto : Efecto<BuffOnFavorabilityValueTowardCharacterEffecto, BuffOnFavorabilityTowardCharacterValueArg>
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x000164F0 File Offset: 0x000146F0
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = (BuffEvento)buff;
			BuffOnFavorabilityTowardCharacterValueArg buffOnFavorabilityTowardCharacterValueArg = (BuffOnFavorabilityTowardCharacterValueArg)argument;
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ConsentToHero consentToHero = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (consentToHero == null)
			{
				return;
			}
			consentToHero.GetComponentNotNull<EmocionHacia>().GetHaciaNotNull(buffOnFavorabilityTowardCharacterValueArg.towardID).sumadorDeValor.ObtenerModificadorNotNull(buffEvento.id).valor.valor = Mathf.Clamp(buffOnFavorabilityTowardCharacterValueArg.add * (float)stacks, -33f, 33f);
			buffEvento.quality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(1f, 13f, MathfExtension.InverseLerpConMedio(-66f, 0f, 66f, buffOnFavorabilityTowardCharacterValueArg.add * (float)stacks).InInOutOutPow(2f, 2f, 0.5f)));
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000165B8 File Offset: 0x000147B8
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			Evento evento = (Evento)buff;
			BuffOnFavorabilityTowardCharacterValueArg buffOnFavorabilityTowardCharacterValueArg = (BuffOnFavorabilityTowardCharacterValueArg)argument;
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ConsentToHero consentToHero = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (consentToHero == null)
			{
				return;
			}
			if (!consentToHero.GetComponentNotNull<EmocionHacia>().GetHaciaNotNull(buffOnFavorabilityTowardCharacterValueArg.towardID).sumadorDeValor.TryRemoverModificador(evento.id))
			{
				Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
			}
		}
	}
}
