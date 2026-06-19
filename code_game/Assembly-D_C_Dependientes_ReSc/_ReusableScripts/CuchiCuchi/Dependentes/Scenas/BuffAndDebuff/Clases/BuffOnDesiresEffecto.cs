using System;
using Assets.TValle.Tools.Runtime.Characters;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Tiempo;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000D1 RID: 209
	[Serializable]
	public class BuffOnDesiresEffecto : ByInteraccionEnScenaEffecto<BuffOnDesiresEffecto, BuffOnDesiresArg>
	{
		// Token: 0x06000453 RID: 1107 RVA: 0x0001807C File Offset: 0x0001627C
		protected override void OnApply(object affected, BuffOnDesiresArg argument, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			Deseos deseos = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (deseos == null)
			{
				return;
			}
			switch (argument.buffOn.modifier)
			{
			case EmotionModifier.defaultValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation == Operation.add)
				{
					ModificadorDeFloat modificadorDeFloat;
					switch (argument.buffOn.desires)
					{
					case Desires.Crotch:
						modificadorDeFloat = deseos.sumablePercentage.entrepierna.ObtenerModificadorNotNull(buffEvento.id);
						break;
					case Desires.Ass:
						modificadorDeFloat = deseos.sumablePercentage.trasero.ObtenerModificadorNotNull(buffEvento.id);
						break;
					case Desires.Breast:
						modificadorDeFloat = deseos.sumablePercentage.senos.ObtenerModificadorNotNull(buffEvento.id);
						break;
					case Desires.Mouth:
						modificadorDeFloat = deseos.sumablePercentage.labios.ObtenerModificadorNotNull(buffEvento.id);
						break;
					default:
						throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
					}
					modificadorDeFloat.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -200f, 200f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, -200f, 0f, 200f, modificadorDeFloat.valor.valor, 3f, true);
					argument.actualValue = new float?(modificadorDeFloat.valor.valor);
					return;
				}
				if (operation != Operation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				ModificadorDeFloat modificadorDeFloat2;
				switch (argument.buffOn.desires)
				{
				case Desires.Crotch:
					modificadorDeFloat2 = deseos.modificablesPercentage.entrepierna.ObtenerModificadorNotNull(buffEvento.id);
					break;
				case Desires.Ass:
					modificadorDeFloat2 = deseos.modificablesPercentage.trasero.ObtenerModificadorNotNull(buffEvento.id);
					break;
				case Desires.Breast:
					modificadorDeFloat2 = deseos.modificablesPercentage.senos.ObtenerModificadorNotNull(buffEvento.id);
					break;
				case Desires.Mouth:
					modificadorDeFloat2 = deseos.modificablesPercentage.labios.ObtenerModificadorNotNull(buffEvento.id);
					break;
				default:
					throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
				}
				modificadorDeFloat2.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.333f, 3f, 0.25f);
				base.UpdateQualityAndVisibility(buffEvento, 0.333f, 1f, 3f, modificadorDeFloat2.valor.valor, 3f, true);
				argument.actualValue = new float?(modificadorDeFloat2.valor.valor);
				return;
			}
			case EmotionModifier.minValue:
				break;
			case EmotionModifier.maxValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation == Operation.add)
				{
					ModificadorDeFloat modificadorDeFloat3;
					switch (argument.buffOn.desires)
					{
					case Desires.Crotch:
						modificadorDeFloat3 = deseos.valoresMaximosSumablePercentage.entrepierna.ObtenerModificadorNotNull(buffEvento.id);
						break;
					case Desires.Ass:
						modificadorDeFloat3 = deseos.valoresMaximosSumablePercentage.trasero.ObtenerModificadorNotNull(buffEvento.id);
						break;
					case Desires.Breast:
						modificadorDeFloat3 = deseos.valoresMaximosSumablePercentage.senos.ObtenerModificadorNotNull(buffEvento.id);
						break;
					case Desires.Mouth:
						modificadorDeFloat3 = deseos.valoresMaximosSumablePercentage.labios.ObtenerModificadorNotNull(buffEvento.id);
						break;
					default:
						throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
					}
					modificadorDeFloat3.valor.valor = BuffEffectoDisminutionReturn.Add(argument.buffOn.value, -200f, 200f, 0.25f);
					base.UpdateQualityAndVisibility(buffEvento, -200f, 0f, 200f, modificadorDeFloat3.valor.valor, 3f, true);
					argument.actualValue = new float?(modificadorDeFloat3.valor.valor);
					return;
				}
				if (operation != Operation.mult)
				{
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				ModificadorDeFloat modificadorDeFloat4;
				switch (argument.buffOn.desires)
				{
				case Desires.Crotch:
					modificadorDeFloat4 = deseos.valoresMaximosModificablePercentage.entrepierna.ObtenerModificadorNotNull(buffEvento.id);
					break;
				case Desires.Ass:
					modificadorDeFloat4 = deseos.valoresMaximosModificablePercentage.trasero.ObtenerModificadorNotNull(buffEvento.id);
					break;
				case Desires.Breast:
					modificadorDeFloat4 = deseos.valoresMaximosModificablePercentage.senos.ObtenerModificadorNotNull(buffEvento.id);
					break;
				case Desires.Mouth:
					modificadorDeFloat4 = deseos.valoresMaximosModificablePercentage.labios.ObtenerModificadorNotNull(buffEvento.id);
					break;
				default:
					throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
				}
				modificadorDeFloat4.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.1f, 10f, 0.25f);
				base.UpdateQualityAndVisibility(buffEvento, 0.1f, 1f, 10f, modificadorDeFloat4.valor.valor, 3f, true);
				argument.actualValue = new float?(modificadorDeFloat4.valor.valor);
				return;
			}
			case EmotionModifier.gain:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation == Operation.mult)
					{
						ModificadorDeFloat modificadorDeFloat5;
						switch (argument.buffOn.desires)
						{
						case Desires.Crotch:
							modificadorDeFloat5 = deseos.modificablesGains.entrepierna.ObtenerModificadorNotNull(buffEvento.id);
							break;
						case Desires.Ass:
							modificadorDeFloat5 = deseos.modificablesGains.trasero.ObtenerModificadorNotNull(buffEvento.id);
							break;
						case Desires.Breast:
							modificadorDeFloat5 = deseos.modificablesGains.senos.ObtenerModificadorNotNull(buffEvento.id);
							break;
						case Desires.Mouth:
							modificadorDeFloat5 = deseos.modificablesGains.labios.ObtenerModificadorNotNull(buffEvento.id);
							break;
						default:
							throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
						}
						modificadorDeFloat5.valor.valor = BuffEffectoDisminutionReturn.Mul(argument.buffOn.value, 0.1f, 10f, 0.25f);
						base.UpdateQualityAndVisibility(buffEvento, 0.1f, 1f, 10f, modificadorDeFloat5.valor.valor, 3f, true);
						argument.actualValue = new float?(modificadorDeFloat5.valor.valor);
						return;
					}
					throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00018710 File Offset: 0x00016910
		protected override void OnStay(object affected, BuffOnDesiresArg argument, object buff, object caster)
		{
			this.OnApply(affected, argument, buff, caster);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00018720 File Offset: 0x00016920
		protected override void OnRemove(object affected, BuffOnDesiresArg argument, object buff, object caster)
		{
			Evento evento = buff as Evento;
			if (evento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			Deseos deseos = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (deseos == null)
			{
				return;
			}
			switch (argument.buffOn.modifier)
			{
			case EmotionModifier.defaultValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation != Operation.mult)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
					}
					switch (argument.buffOn.desires)
					{
					case Desires.Crotch:
						if (!deseos.modificablesPercentage.entrepierna.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Ass:
						if (!deseos.modificablesPercentage.trasero.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Breast:
						if (!deseos.modificablesPercentage.senos.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Mouth:
						if (!deseos.modificablesPercentage.labios.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					default:
						throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
					}
				}
				else
				{
					switch (argument.buffOn.desires)
					{
					case Desires.Crotch:
						if (!deseos.sumablePercentage.entrepierna.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Ass:
						if (!deseos.sumablePercentage.trasero.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Breast:
						if (!deseos.sumablePercentage.senos.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Mouth:
						if (!deseos.sumablePercentage.labios.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					default:
						throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
					}
				}
				break;
			}
			case EmotionModifier.minValue:
				break;
			case EmotionModifier.maxValue:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation != Operation.mult)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
					}
					switch (argument.buffOn.desires)
					{
					case Desires.Crotch:
						if (!deseos.valoresMaximosModificablePercentage.entrepierna.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Ass:
						if (!deseos.valoresMaximosModificablePercentage.trasero.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Breast:
						if (!deseos.valoresMaximosModificablePercentage.senos.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Mouth:
						if (!deseos.valoresMaximosModificablePercentage.labios.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					default:
						throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
					}
				}
				else
				{
					switch (argument.buffOn.desires)
					{
					case Desires.Crotch:
						if (!deseos.valoresMaximosSumablePercentage.entrepierna.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Ass:
						if (!deseos.valoresMaximosSumablePercentage.trasero.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Breast:
						if (!deseos.valoresMaximosSumablePercentage.senos.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Mouth:
						if (!deseos.valoresMaximosSumablePercentage.labios.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					default:
						throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
					}
				}
				break;
			}
			case EmotionModifier.gain:
			{
				Operation operation = argument.buffOn.operation;
				if (operation != Operation.add)
				{
					if (operation != Operation.mult)
					{
						throw new ArgumentOutOfRangeException(argument.buffOn.operation.ToString());
					}
					switch (argument.buffOn.desires)
					{
					case Desires.Crotch:
						if (!deseos.modificablesGains.entrepierna.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Ass:
						if (!deseos.modificablesGains.trasero.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Breast:
						if (!deseos.modificablesGains.senos.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					case Desires.Mouth:
						if (!deseos.modificablesGains.labios.TryRemoverModificador(evento.id))
						{
							Debug.LogError("no se puedo remover buff " + evento.id + " no existia en modificables ", caster as MonoBehaviour);
							return;
						}
						break;
					default:
						throw new ArgumentOutOfRangeException(argument.buffOn.desires.ToString());
					}
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException(argument.buffOn.modifier.ToString());
			}
		}
	}
}
