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
	// Token: 0x020000DF RID: 223
	[Serializable]
	public class BuffOnHoleWearingBottomEffecto : ByInteraccionEnScenaEffecto<BuffOnHoleWearingBottomEffecto, BuffOnHoleWearingBottomArg>
	{
		// Token: 0x06000477 RID: 1143 RVA: 0x0001A68C File Offset: 0x0001888C
		protected override void OnApply(object affected, BuffOnHoleWearingBottomArg argument, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			SensitiveFemaleHoleBottom toPart = argument.buffOn.toPart;
			OrganHoleController organHoleController;
			if (toPart != SensitiveFemaleHoleBottom.throatBottom)
			{
				if (toPart != SensitiveFemaleHoleBottom.vagBottom)
				{
					if (toPart != SensitiveFemaleHoleBottom.anusBottom)
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
			if (!(organHoleController != null))
			{
				return;
			}
			if (argument.buffOn.modifier != SimpleModifier.value)
			{
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
			if (argument.buffOn.operation == AddOperation.add)
			{
				ModificadorDeFloat modificadorDeFloat = organHoleController.profundidad.sumable.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -1f, 1f, 1f);
				base.UpdateQualityAndVisibility(buffEvento, -1f, 0f, 1f, modificadorDeFloat.valor.valor, 3f, true);
				argument.actualValue = new float?(modificadorDeFloat.valor.valor);
				return;
			}
			throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0001A801 File Offset: 0x00018A01
		protected override void OnStay(object affected, BuffOnHoleWearingBottomArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0001A810 File Offset: 0x00018A10
		protected override void OnRemove(object affected, BuffOnHoleWearingBottomArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				Debug.LogError("no se puedo remover buff, buff no es valido ", caster as MonoBehaviour);
				return;
			}
			SensitiveFemaleHoleBottom toPart = argument.buffOn.toPart;
			OrganHoleController organHoleController;
			if (toPart != SensitiveFemaleHoleBottom.throatBottom)
			{
				if (toPart != SensitiveFemaleHoleBottom.vagBottom)
				{
					if (toPart != SensitiveFemaleHoleBottom.anusBottom)
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
			if (organHoleController != null)
			{
				if (argument.buffOn.modifier != SimpleModifier.value)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
				}
				if (argument.buffOn.operation != AddOperation.add)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				if (!organHoleController.profundidad.sumable.TryRemoverModificador(evento.id))
				{
					Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
					return;
				}
			}
		}
	}
}
