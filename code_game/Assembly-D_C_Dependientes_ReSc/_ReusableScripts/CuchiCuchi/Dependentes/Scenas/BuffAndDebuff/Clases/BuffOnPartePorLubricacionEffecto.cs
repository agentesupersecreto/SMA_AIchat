using System;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.Characters.Holes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Holes.Controlladores;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000CA RID: 202
	public class BuffOnPartePorLubricacionEffecto : Efecto<BuffOnPartePorLubricacionEffecto, BuffOnPartePorLubricacionArg>
	{
		// Token: 0x06000428 RID: 1064 RVA: 0x00017054 File Offset: 0x00015254
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null)
			{
				return;
			}
			BuffOnPartePorLubricacionArg buffOnPartePorLubricacionArg = (BuffOnPartePorLubricacionArg)argument;
			if (buffOnPartePorLubricacionArg.parte.CanBePenetrated())
			{
				HoleController holeController;
				switch (buffOnPartePorLubricacionArg.parte)
				{
				case SensitiveBodyPart.throat:
				case SensitiveBodyPart.throatBottom:
				case SensitiveBodyPart.throatWalls:
				{
					MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
					holeController = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
					break;
				}
				case SensitiveBodyPart.vag:
				case SensitiveBodyPart.vagBottom:
				case SensitiveBodyPart.vagWalls:
				{
					MonoBehaviour monoBehaviour3 = affected as MonoBehaviour;
					holeController = ((monoBehaviour3 != null) ? monoBehaviour3.GetComponentEnRoot(false) : null);
					break;
				}
				case SensitiveBodyPart.anus:
				case SensitiveBodyPart.anusBottom:
				case SensitiveBodyPart.anusWalls:
				{
					MonoBehaviour monoBehaviour4 = affected as MonoBehaviour;
					holeController = ((monoBehaviour4 != null) ? monoBehaviour4.GetComponentEnRoot(false) : null);
					break;
				}
				default:
					throw new ArgumentOutOfRangeException(buffOnPartePorLubricacionArg.parte.ToString());
				}
				ModificadorDeFloat modificadorDeFloat = holeController.timeTryingToOpenHoleModificable.ObtenerModificadorNotNull(buffEvento.id);
				ModificadorDeFloatBase modificadorDeFloatBase = holeController.modificableDeHardPointsDesgastePorSegundo.ObtenerModificadorNotNull(buffEvento.id);
				modificadorDeFloat.valor.valor = Mathf.Lerp(1f, 0.01f, buffOnPartePorLubricacionArg.weight);
				modificadorDeFloatBase.valor.valor = Mathf.Lerp(1f, 1.5f, buffOnPartePorLubricacionArg.weight);
			}
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(ReaccionHumana.dolor);
			Component component = emocionesHumanasBase.ObtenerEmocion(ReaccionHumana.placer);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull2 = component.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			if (buffOnPartePorLubricacionArg.parte.CanBePenetrated())
			{
				foreach (object obj in typeof(IntercouseInterationReceivedType).GetEnumValoresLimpiosObject())
				{
					IntercouseInterationReceivedType intercouseInterationReceivedType = (IntercouseInterationReceivedType)obj;
					for (int i = 0; i < TriggeringBodyPartHelper.canPenetrateParts.Count; i++)
					{
						TriggeringBodyPart triggeringBodyPart = TriggeringBodyPartHelper.canPenetrateParts[i];
						ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvancedNotNull = componentNotNull.GetModificadorAdvancedNotNull((InterationReceivedType)intercouseInterationReceivedType, triggeringBodyPart, buffOnPartePorLubricacionArg.parte);
						modificadorAdvancedNotNull.gainModificable.ObtenerModificadorNotNull(buffEvento.id).valor.valor = Mathf.Lerp(1f, 0.01f, buffOnPartePorLubricacionArg.weight);
						modificadorAdvancedNotNull.interPositionMinMaxModificable.ObtenerModificadorNotNull(buffEvento.id).valor.valor = Mathf.Lerp(1f, 5f, buffOnPartePorLubricacionArg.weight);
						componentNotNull2.GetModificadorAdvancedNotNull((InterationReceivedType)intercouseInterationReceivedType, triggeringBodyPart, buffOnPartePorLubricacionArg.parte).gainModificable.ObtenerModificadorNotNull(buffEvento.id).valor.valor = Mathf.Lerp(1f, 0.5f, buffOnPartePorLubricacionArg.pleasureReductionWeight);
					}
				}
			}
			foreach (object obj2 in typeof(AllTocuhInterationReceivedType).GetEnumValoresLimpiosObject())
			{
				AllTocuhInterationReceivedType allTocuhInterationReceivedType = (AllTocuhInterationReceivedType)obj2;
				for (int j = 0; j < TriggeringBodyPartHelper.canTouchParts.Count; j++)
				{
					TriggeringBodyPart triggeringBodyPart2 = TriggeringBodyPartHelper.canTouchParts[j];
					ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvancedNotNull2 = componentNotNull.GetModificadorAdvancedNotNull((InterationReceivedType)allTocuhInterationReceivedType, triggeringBodyPart2, buffOnPartePorLubricacionArg.parte);
					modificadorAdvancedNotNull2.gainModificable.ObtenerModificadorNotNull(buffEvento.id).valor.valor = Mathf.Lerp(1f, 0.01f, buffOnPartePorLubricacionArg.weight);
					modificadorAdvancedNotNull2.interPositionMinMaxModificable.ObtenerModificadorNotNull(buffEvento.id).valor.valor = Mathf.Lerp(1f, 5f, buffOnPartePorLubricacionArg.weight);
					componentNotNull2.GetModificadorAdvancedNotNull((InterationReceivedType)allTocuhInterationReceivedType, triggeringBodyPart2, buffOnPartePorLubricacionArg.parte).gainModificable.ObtenerModificadorNotNull(buffEvento.id).valor.valor = Mathf.Lerp(1f, 0.5f, buffOnPartePorLubricacionArg.pleasureReductionWeight);
				}
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0001743C File Offset: 0x0001563C
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null)
			{
				return;
			}
			BuffOnPartePorLubricacionArg buffOnPartePorLubricacionArg = (BuffOnPartePorLubricacionArg)argument;
			if (buffOnPartePorLubricacionArg.parte.CanBePenetrated())
			{
				HoleController holeController;
				switch (buffOnPartePorLubricacionArg.parte)
				{
				case SensitiveBodyPart.throat:
				case SensitiveBodyPart.throatBottom:
				case SensitiveBodyPart.throatWalls:
				{
					MonoBehaviour monoBehaviour2 = affected as MonoBehaviour;
					holeController = ((monoBehaviour2 != null) ? monoBehaviour2.GetComponentEnRoot(false) : null);
					break;
				}
				case SensitiveBodyPart.vag:
				case SensitiveBodyPart.vagBottom:
				case SensitiveBodyPart.vagWalls:
				{
					MonoBehaviour monoBehaviour3 = affected as MonoBehaviour;
					holeController = ((monoBehaviour3 != null) ? monoBehaviour3.GetComponentEnRoot(false) : null);
					break;
				}
				case SensitiveBodyPart.anus:
				case SensitiveBodyPart.anusBottom:
				case SensitiveBodyPart.anusWalls:
				{
					MonoBehaviour monoBehaviour4 = affected as MonoBehaviour;
					holeController = ((monoBehaviour4 != null) ? monoBehaviour4.GetComponentEnRoot(false) : null);
					break;
				}
				default:
					throw new ArgumentOutOfRangeException(buffOnPartePorLubricacionArg.parte.ToString());
				}
				holeController.timeTryingToOpenHoleModificable.RemoverModificador(buffEvento.id);
				holeController.modificableDeHardPointsDesgastePorSegundo.RemoverModificador(buffEvento.id);
			}
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(ReaccionHumana.dolor);
			Component component = emocionesHumanasBase.ObtenerEmocion(ReaccionHumana.placer);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull = emocion.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion componentNotNull2 = component.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			if (buffOnPartePorLubricacionArg.parte.CanBePenetrated())
			{
				foreach (object obj in typeof(IntercouseInterationReceivedType).GetEnumValoresLimpiosObject())
				{
					IntercouseInterationReceivedType intercouseInterationReceivedType = (IntercouseInterationReceivedType)obj;
					for (int i = 0; i < TriggeringBodyPartHelper.canPenetrateParts.Count; i++)
					{
						TriggeringBodyPart triggeringBodyPart = TriggeringBodyPartHelper.canPenetrateParts[i];
						ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced = componentNotNull.GetModificadorAdvanced((InterationReceivedType)intercouseInterationReceivedType, triggeringBodyPart, buffOnPartePorLubricacionArg.parte);
						if (modificadorAdvanced != null)
						{
							modificadorAdvanced.gainModificable.RemoverModificador(buffEvento.id);
							modificadorAdvanced.interPositionMinModificable.RemoverModificador(buffEvento.id);
						}
						ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced2 = componentNotNull2.GetModificadorAdvanced((InterationReceivedType)intercouseInterationReceivedType, triggeringBodyPart, buffOnPartePorLubricacionArg.parte);
						if (modificadorAdvanced2 != null)
						{
							modificadorAdvanced2.gainModificable.RemoverModificador(buffEvento.id);
							modificadorAdvanced2.interPositionMinModificable.RemoverModificador(buffEvento.id);
						}
					}
				}
			}
			foreach (object obj2 in typeof(AllTocuhInterationReceivedType).GetEnumValoresLimpiosObject())
			{
				AllTocuhInterationReceivedType allTocuhInterationReceivedType = (AllTocuhInterationReceivedType)obj2;
				for (int j = 0; j < TriggeringBodyPartHelper.canTouchParts.Count; j++)
				{
					TriggeringBodyPart triggeringBodyPart2 = TriggeringBodyPartHelper.canTouchParts[j];
					ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced3 = componentNotNull.GetModificadorAdvanced((InterationReceivedType)allTocuhInterationReceivedType, triggeringBodyPart2, buffOnPartePorLubricacionArg.parte);
					if (modificadorAdvanced3 != null)
					{
						modificadorAdvanced3.gainModificable.RemoverModificador(buffEvento.id);
						modificadorAdvanced3.interPositionMinModificable.RemoverModificador(buffEvento.id);
					}
					ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced4 = componentNotNull2.GetModificadorAdvanced((InterationReceivedType)allTocuhInterationReceivedType, triggeringBodyPart2, buffOnPartePorLubricacionArg.parte);
					if (modificadorAdvanced4 != null)
					{
						modificadorAdvanced4.gainModificable.RemoverModificador(buffEvento.id);
						modificadorAdvanced4.interPositionMinModificable.RemoverModificador(buffEvento.id);
					}
				}
			}
		}
	}
}
