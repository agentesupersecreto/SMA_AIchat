using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000DD RID: 221
	[Serializable]
	public class BuffOnFavorabilityReqOfInteractionEffecto : ByInteraccionEnScenaEffecto<BuffOnFavorabilityReqOfInteractionEffecto, BuffOnFavorabilityReqOfInteractionArg>
	{
		// Token: 0x06000471 RID: 1137 RVA: 0x0001A3D8 File Offset: 0x000185D8
		protected override void OnApply(object affected, BuffOnFavorabilityReqOfInteractionArg argument, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ConsentNecesario consentNecesario = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (consentNecesario == null)
			{
				return;
			}
			ParteDelCuerpoHumano part = argument.buffOn.toPart.GetPart();
			ParteQuePuedeEstimular partSimple = argument.buffOn.fromPart.GetPartSimple();
			DireccionDeEstimulo direccionDeEstimulo;
			TipoDeEstimulo tipoDeEstimuloSimple = argument.buffOn.interationReceivedType.GetTipoDeEstimuloSimple(out direccionDeEstimulo);
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			Operation operation = argument.buffOn.operation;
			if (operation == Operation.add)
			{
				throw new NotImplementedException();
			}
			if (operation != Operation.mult)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			}
			ModificadorDeFloat modificadorDeFloat = consentNecesario.GetModificadorNotNull(tipoDeEstimuloSimple, part, new ParteQuePuedeEstimular?(partSimple), direccionDeEstimulo).modificable.ObtenerModificadorNotNull(buffEvento.id);
			modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.1f, 10f, 0.25f);
			base.UpdateQualityAndVisibility(buffEvento, 0.1f, 1f, 10f, modificadorDeFloat.valor.valor, 3f, false);
			argument.actualValue = new float?(modificadorDeFloat.valor.valor);
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0001A53C File Offset: 0x0001873C
		protected override void OnStay(object affected, BuffOnFavorabilityReqOfInteractionArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0001A54C File Offset: 0x0001874C
		protected override void OnRemove(object affected, BuffOnFavorabilityReqOfInteractionArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			ConsentNecesario consentNecesario = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (consentNecesario == null)
			{
				return;
			}
			ParteDelCuerpoHumano part = argument.buffOn.toPart.GetPart();
			ParteQuePuedeEstimular partSimple = argument.buffOn.fromPart.GetPartSimple();
			DireccionDeEstimulo direccionDeEstimulo;
			TipoDeEstimulo tipoDeEstimuloSimple = argument.buffOn.interationReceivedType.GetTipoDeEstimuloSimple(out direccionDeEstimulo);
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			Operation operation = argument.buffOn.operation;
			if (operation == Operation.add)
			{
				throw new NotImplementedException();
			}
			if (operation != Operation.mult)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			}
			ConsentNecesario.Modificables modificador = consentNecesario.GetModificador(tipoDeEstimuloSimple, part, new ParteQuePuedeEstimular?(partSimple), direccionDeEstimulo);
			if (modificador == null || !modificador.modificable.TryRemoverModificador(evento.id))
			{
				Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
				return;
			}
		}
	}
}
