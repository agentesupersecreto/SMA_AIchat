using System;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000C4 RID: 196
	[Serializable]
	public class BuffOnMinFavorabilityValueEffecto : Efecto<BuffOnMinFavorabilityValueEffecto, BuffOnMinFavorabilityValueArg>
	{
		// Token: 0x06000411 RID: 1041 RVA: 0x0001684C File Offset: 0x00014A4C
		public static float ReduceValorByFatigue(float added, float fatigaMod, out float substractedByFatigue)
		{
			substractedByFatigue = Mathf.Lerp(0f, added, fatigaMod);
			return added - substractedByFatigue;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00016860 File Offset: 0x00014A60
		public static float SimularValor(IReadOnlyList<IDataOfInteractionArg> data, ConsentNecesario consentNecesario, EmocionesFemeninasValues? emos)
		{
			float num = 0f;
			for (int i = 0; i < data.Count; i++)
			{
				IDataOfInteractionArg dataOfInteractionArg = data[i];
				for (int j = 0; j < dataOfInteractionArg.estimuladas.Length; j++)
				{
					float num2 = consentNecesario.ParaConJerarquia(dataOfInteractionArg.tipo, dataOfInteractionArg.direccion, dataOfInteractionArg.estimuladas[j], dataOfInteractionArg.estiulante, emos, null, null);
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000168D0 File Offset: 0x00014AD0
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = (BuffEvento)buff;
			BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg = (BuffOnMinFavorabilityValueArg)argument;
			buffOnMinFavorabilityValueArg.flagUpdateNonLocalizedTextV2 = true;
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ConsentToHero consentToHero = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (consentToHero == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
			ConsentNecesario consentNecesario = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
			if (consentNecesario == null)
			{
				return;
			}
			EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
			float num = BuffOnMinFavorabilityValueEffecto.SimularValor(buffOnMinFavorabilityValueArg.data, consentNecesario, new EmocionesFemeninasValues?(emptyValid));
			ModificadorDeFloat modificadorDeFloat = consentToHero.minimoLimiteValor.ObtenerModificadorNotNull(buffEvento.id);
			buffOnMinFavorabilityValueArg.added = (modificadorDeFloat.valor.valor = num * 1.0001f);
			if (buffOnMinFavorabilityValueArg.changedByFatigue)
			{
				MonoBehaviour monoBehaviour3 = affected as MonoBehaviour;
				Character character = ((monoBehaviour3 != null) ? monoBehaviour3.GetComponentEnRoot(false) : null);
				float applyableFatigueMod = MemoriaDeNpc.GetApplyableFatigueMod(GlobalSingletonV2<MemoriaJson>.instance, character.ID_UnicoString, 1f);
				num = (modificadorDeFloat.valor.valor = BuffOnMinFavorabilityValueEffecto.ReduceValorByFatigue(buffOnMinFavorabilityValueArg.added, applyableFatigueMod, out buffOnMinFavorabilityValueArg.substractedByFatigue));
			}
			EmocionesFemeninasValues emocionesFemeninasValues = consentNecesario.emociones.ObtenerModsFemeninos(true);
			for (int i = 0; i < buffOnMinFavorabilityValueArg.dataExcluir.Length; i++)
			{
				BuffOnMinFavorabilityValueArg.ExclusionData exclusionData = buffOnMinFavorabilityValueArg.dataExcluir[i];
				for (int j = 0; j < exclusionData.estimuladas.Length; j++)
				{
					float num2;
					float num3;
					if (!consentNecesario.EsConsentidoConJerarquia(exclusionData.tipo, exclusionData.direccion, exclusionData.estimuladas[j], exclusionData.estiulante, out num2, out num3, 1f, new EmocionesFemeninasValues?(emocionesFemeninasValues), null, null))
					{
						consentNecesario.GetModificadorNotNull(exclusionData.tipo, exclusionData.estimuladas[j], new ParteQuePuedeEstimular?(exclusionData.estiulante), exclusionData.direccion).minimo.ObtenerModificadorNotNull(buffEvento.id).valor.valor = num * 1f * exclusionData.weight;
					}
				}
			}
			if (buffOnMinFavorabilityValueArg.force)
			{
				for (int k = 0; k < buffOnMinFavorabilityValueArg.data.Length; k++)
				{
					BuffOnMinFavorabilityValueArg.Data data = buffOnMinFavorabilityValueArg.data[k];
					for (int l = 0; l < data.estimuladas.Length; l++)
					{
						consentNecesario.GetModificadorNotNull(data.tipo, data.estimuladas[l], new ParteQuePuedeEstimular?(data.estiulante), data.direccion).maximo.ObtenerModificadorNotNull(buffEvento.id).valor.valor = 100f;
					}
				}
			}
			buffEvento.quality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(7f, 13f, ((buffOnMinFavorabilityValueArg.added - buffOnMinFavorabilityValueArg.substractedByFatigue) / 100f).OutPow(4f)));
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00016B88 File Offset: 0x00014D88
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			Evento evento = (Evento)buff;
			BuffOnMinFavorabilityValueArg buffOnMinFavorabilityValueArg = (BuffOnMinFavorabilityValueArg)argument;
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ConsentToHero consentToHero = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (consentToHero != null && !consentToHero.minimoLimiteValor.TryRemoverModificador(evento.id))
			{
				Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
			}
			MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
			ConsentNecesario consentNecesario = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
			if (consentNecesario != null)
			{
				for (int i = 0; i < buffOnMinFavorabilityValueArg.dataExcluir.Length; i++)
				{
					BuffOnMinFavorabilityValueArg.ExclusionData exclusionData = buffOnMinFavorabilityValueArg.dataExcluir[i];
					for (int j = 0; j < exclusionData.estimuladas.Length; j++)
					{
						ConsentNecesario.Modificables modificador = consentNecesario.GetModificador(exclusionData.tipo, exclusionData.estimuladas[j], new ParteQuePuedeEstimular?(exclusionData.estiulante), exclusionData.direccion);
						if (modificador != null)
						{
							modificador.minimo.TryRemoverModificador(evento.id);
						}
					}
				}
				for (int k = 0; k < buffOnMinFavorabilityValueArg.data.Length; k++)
				{
					BuffOnMinFavorabilityValueArg.Data data = buffOnMinFavorabilityValueArg.data[k];
					for (int l = 0; l < data.estimuladas.Length; l++)
					{
						ConsentNecesario.Modificables modificadorNotNull = consentNecesario.GetModificadorNotNull(data.tipo, data.estimuladas[l], new ParteQuePuedeEstimular?(data.estiulante), data.direccion);
						if (modificadorNotNull != null)
						{
							modificadorNotNull.maximo.TryRemoverModificador(evento.id);
						}
					}
				}
			}
		}
	}
}
