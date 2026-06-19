using System;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000C6 RID: 198
	public class BuffOnMinFavorabilityValueLayer2Effecto : Efecto<BuffOnMinFavorabilityValueLayer2Effecto, BuffOnMinFavorabilityValueLayer2Arg>
	{
		// Token: 0x0600041A RID: 1050 RVA: 0x00016D74 File Offset: 0x00014F74
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = (BuffEvento)buff;
			BuffOnMinFavorabilityValueLayer2Arg buffOnMinFavorabilityValueLayer2Arg = (BuffOnMinFavorabilityValueLayer2Arg)argument;
			buffOnMinFavorabilityValueLayer2Arg.flagUpdateNonLocalizedTextV2 = true;
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ConsentToHero consentToHero = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (consentToHero == null)
			{
				return;
			}
			consentToHero.GetComponentNotNull<EmocionHacia>().GetHaciaNotNull(buffOnMinFavorabilityValueLayer2Arg.towardID).minimoLimiteValor.ObtenerModificadorNotNull(buffEvento.id).valor.valor = buffOnMinFavorabilityValueLayer2Arg.value;
			buffEvento.quality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(7f, 13f, (buffOnMinFavorabilityValueLayer2Arg.value / 100f).OutPow(4f)));
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00016E18 File Offset: 0x00015018
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			Evento evento = (Evento)buff;
			BuffOnMinFavorabilityValueLayer2Arg buffOnMinFavorabilityValueLayer2Arg = (BuffOnMinFavorabilityValueLayer2Arg)argument;
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ConsentToHero consentToHero = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (consentToHero == null)
			{
				return;
			}
			if (!consentToHero.GetComponentNotNull<EmocionHacia>().GetHaciaNotNull(buffOnMinFavorabilityValueLayer2Arg.towardID).minimoLimiteValor.TryRemoverModificador(evento.id))
			{
				Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}
	}
}
