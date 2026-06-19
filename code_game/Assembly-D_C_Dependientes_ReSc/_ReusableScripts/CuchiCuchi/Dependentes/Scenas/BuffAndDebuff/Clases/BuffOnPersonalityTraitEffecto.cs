using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000EB RID: 235
	[Serializable]
	public class BuffOnPersonalityTraitEffecto : ByInteraccionEnScenaEffecto<BuffOnPersonalityTraitEffecto, BuffOnPersonalityTraitArg>
	{
		// Token: 0x06000497 RID: 1175 RVA: 0x0001BC30 File Offset: 0x00019E30
		protected override void OnApply(object affected, BuffOnPersonalityTraitArg argument, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			Personalidad personalidad = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (personalidad == null)
			{
				return;
			}
			PersonalidadRasgoCompleto personalidadRasgoCompleto = argument.buffOn.trait.Parse();
			CollecionDeMapasDePersonalidad.PersonalidadCompleta currentPersonalidad = personalidad.currentPersonalidad;
			PersonalidadDinamica personalidadDinamica;
			if (currentPersonalidad == null)
			{
				personalidadDinamica = null;
			}
			else
			{
				MapaDePersonalidad personalidad2 = currentPersonalidad.personalidad;
				personalidadDinamica = ((personalidad2 != null) ? personalidad2.rasgos : null);
			}
			PersonalidadDinamica personalidadDinamica2 = personalidadDinamica;
			if (personalidadDinamica2 == null)
			{
				return;
			}
			Modificable mod = personalidadDinamica2.GetMod(personalidadRasgoCompleto);
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			Operation operation = argument.buffOn.operation;
			if (operation == Operation.add)
			{
				ModificadorDeFloat modificadorDeFloat = mod.sumable.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -100f, 100f, 0.25f);
				base.UpdateQualityAndVisibility(buffEvento, -100f, 0f, 100f, modificadorDeFloat.valor.valor, 3f, true);
				argument.actualValue = new float?(modificadorDeFloat.valor.valor);
				return;
			}
			if (operation != Operation.mult)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			}
			ModificadorDeFloat modificadorDeFloat2 = mod.modificable.ObtenerModificadorNotNull(buffEvento.id);
			modificadorDeFloat2.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.1f, 10f, 0.25f);
			base.UpdateQualityAndVisibility(buffEvento, 0.1f, 1f, 10f, modificadorDeFloat2.valor.valor, 3f, true);
			argument.actualValue = new float?(modificadorDeFloat2.valor.valor);
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001BE08 File Offset: 0x0001A008
		protected override void OnStay(object affected, BuffOnPersonalityTraitArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0001BE18 File Offset: 0x0001A018
		protected override void OnRemove(object affected, BuffOnPersonalityTraitArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			Personalidad personalidad = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (personalidad == null)
			{
				return;
			}
			PersonalidadRasgoCompleto personalidadRasgoCompleto = argument.buffOn.trait.Parse();
			CollecionDeMapasDePersonalidad.PersonalidadCompleta currentPersonalidad = personalidad.currentPersonalidad;
			PersonalidadDinamica personalidadDinamica;
			if (currentPersonalidad == null)
			{
				personalidadDinamica = null;
			}
			else
			{
				MapaDePersonalidad personalidad2 = currentPersonalidad.personalidad;
				personalidadDinamica = ((personalidad2 != null) ? personalidad2.rasgos : null);
			}
			PersonalidadDinamica personalidadDinamica2 = personalidadDinamica;
			if (personalidadDinamica2 == null)
			{
				return;
			}
			Modificable mod = personalidadDinamica2.GetMod(personalidadRasgoCompleto);
			if (argument.buffOn.modifier == SimpleModifier.value)
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation != Operation.mult)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
					}
					if (!mod.modificable.TryRemoverModificador(evento.id))
					{
						Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
						return;
					}
				}
				else if (!mod.sumable.TryRemoverModificador(evento.id))
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
