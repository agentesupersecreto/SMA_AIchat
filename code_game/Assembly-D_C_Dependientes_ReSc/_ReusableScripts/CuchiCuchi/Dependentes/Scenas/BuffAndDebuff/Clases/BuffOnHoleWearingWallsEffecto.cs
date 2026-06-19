using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Characters.Controladores.Holes;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000E3 RID: 227
	[Serializable]
	public class BuffOnHoleWearingWallsEffecto : ByInteraccionEnScenaEffecto<BuffOnHoleWearingWallsEffecto, BuffOnHoleWearingWallsArg>
	{
		// Token: 0x06000483 RID: 1155 RVA: 0x0001AC48 File Offset: 0x00018E48
		protected override void OnApply(object affected, BuffOnHoleWearingWallsArg argument, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			SensitiveFemaleHoleWalls toPart = argument.buffOn.toPart;
			OrganHoleController organHoleController;
			if (toPart != SensitiveFemaleHoleWalls.throatWalls)
			{
				if (toPart != SensitiveFemaleHoleWalls.vagWalls)
				{
					if (toPart != SensitiveFemaleHoleWalls.anusWalls)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.toPart.ToString());
					}
					MonoBehaviour monoBehaviour = affected as MonoBehaviour;
					organHoleController = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
				}
				else
				{
					MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
					organHoleController = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
				}
			}
			else
			{
				MonoBehaviour monoBehaviour3 = affected as MonoBehaviour;
				organHoleController = ((monoBehaviour3 != null) ? monoBehaviour3.GetComponentEnRoot(false) : null);
			}
			if (organHoleController == null)
			{
				return;
			}
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			if (argument.buffOn.operation == AddOperation.add)
			{
				ModificadorDeFloat modificadorDeFloat = organHoleController.anchura.sumable.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -1f, 1f, 1f);
				base.UpdateQualityAndVisibility(buffEvento, -1f, 0f, 1f, modificadorDeFloat.valor.valor, 3f, true);
				argument.actualValue = new float?(modificadorDeFloat.valor.valor);
				return;
			}
			throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0001ADBA File Offset: 0x00018FBA
		protected override void OnStay(object affected, BuffOnHoleWearingWallsArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0001ADC8 File Offset: 0x00018FC8
		protected override void OnRemove(object affected, BuffOnHoleWearingWallsArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				Debug.LogError("no se puedo remover buff, buff no es valido ", caster as MonoBehaviour);
				return;
			}
			SensitiveFemaleHoleWalls toPart = argument.buffOn.toPart;
			OrganHoleController organHoleController;
			if (toPart != SensitiveFemaleHoleWalls.throatWalls)
			{
				if (toPart != SensitiveFemaleHoleWalls.vagWalls)
				{
					if (toPart != SensitiveFemaleHoleWalls.anusWalls)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.toPart.ToString());
					}
					MonoBehaviour monoBehaviour = affected as MonoBehaviour;
					organHoleController = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
				}
				else
				{
					MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
					organHoleController = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
				}
			}
			else
			{
				MonoBehaviour monoBehaviour3 = affected as MonoBehaviour;
				organHoleController = ((monoBehaviour3 != null) ? monoBehaviour3.GetComponentEnRoot(false) : null);
			}
			if (organHoleController == null)
			{
				return;
			}
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			if (argument.buffOn.operation != AddOperation.add)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
			}
			if (!organHoleController.anchura.sumable.TryRemoverModificador(evento.id))
			{
				Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
				return;
			}
		}
	}
}
