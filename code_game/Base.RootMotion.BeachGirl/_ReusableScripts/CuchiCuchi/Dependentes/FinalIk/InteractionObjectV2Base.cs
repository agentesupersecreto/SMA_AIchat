using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x0200007B RID: 123
	public abstract class InteractionObjectV2Base : InteractionObject
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00015CE0 File Offset: 0x00013EE0
		public bool interacting
		{
			get
			{
				return this.m_currentSystem != null;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00015CEE File Offset: 0x00013EEE
		public InteractionObjectV2Base.Estado estado
		{
			get
			{
				return this.m_estado;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00015CF6 File Offset: 0x00013EF6
		public override Transform lookAtTarget
		{
			get
			{
				if (this.otherLookAtTarget != null)
				{
					return this.otherLookAtTarget;
				}
				return null;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00015D0E File Offset: 0x00013F0E
		public float lookAtPriority
		{
			get
			{
				return this.m_lookAtPriorityV2;
			}
		}

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x060004A7 RID: 1191 RVA: 0x00015D18 File Offset: 0x00013F18
		// (remove) Token: 0x060004A8 RID: 1192 RVA: 0x00015D50 File Offset: 0x00013F50
		public event Action<InteractionObjectV2Base> Initiating;

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x060004A9 RID: 1193 RVA: 0x00015D88 File Offset: 0x00013F88
		// (remove) Token: 0x060004AA RID: 1194 RVA: 0x00015DC0 File Offset: 0x00013FC0
		public event Action<InteractionObjectV2Base> Initiated;

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x060004AB RID: 1195 RVA: 0x00015DF8 File Offset: 0x00013FF8
		// (remove) Token: 0x060004AC RID: 1196 RVA: 0x00015E30 File Offset: 0x00014030
		public event Action<InteractionObjectV2Base, InteractionSystem> staring;

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x060004AD RID: 1197 RVA: 0x00015E68 File Offset: 0x00014068
		// (remove) Token: 0x060004AE RID: 1198 RVA: 0x00015EA0 File Offset: 0x000140A0
		public event Action<InteractionObjectV2Base, InteractionSystem> stared;

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x060004AF RID: 1199 RVA: 0x00015ED8 File Offset: 0x000140D8
		// (remove) Token: 0x060004B0 RID: 1200 RVA: 0x00015F10 File Offset: 0x00014110
		public event Action<InteractionObjectV2Base, InteractionSystem> stoping;

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x060004B1 RID: 1201 RVA: 0x00015F48 File Offset: 0x00014148
		// (remove) Token: 0x060004B2 RID: 1202 RVA: 0x00015F80 File Offset: 0x00014180
		public event Action<InteractionObjectV2Base, InteractionSystem> stoped;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x060004B3 RID: 1203 RVA: 0x00015FB8 File Offset: 0x000141B8
		// (remove) Token: 0x060004B4 RID: 1204 RVA: 0x00015FF0 File Offset: 0x000141F0
		public event Action<InteractionObjectV2Base, InteractionEffector> staringOnEffector;

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x060004B5 RID: 1205 RVA: 0x00016028 File Offset: 0x00014228
		// (remove) Token: 0x060004B6 RID: 1206 RVA: 0x00016060 File Offset: 0x00014260
		public event Action<InteractionObjectV2Base, InteractionEffector> staredOnEffector;

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x060004B7 RID: 1207 RVA: 0x00016098 File Offset: 0x00014298
		// (remove) Token: 0x060004B8 RID: 1208 RVA: 0x000160D0 File Offset: 0x000142D0
		public event Action<InteractionObjectV2Base, InteractionEffector> stopingOnEffector;

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x060004B9 RID: 1209 RVA: 0x00016108 File Offset: 0x00014308
		// (remove) Token: 0x060004BA RID: 1210 RVA: 0x00016140 File Offset: 0x00014340
		public event Action<InteractionObjectV2Base, InteractionEffector> stopedOnEffector;

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x060004BB RID: 1211 RVA: 0x00016178 File Offset: 0x00014378
		// (remove) Token: 0x060004BC RID: 1212 RVA: 0x000161B0 File Offset: 0x000143B0
		public event InteractionObjectV2Base.UpdateHandler applying;

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x060004BD RID: 1213 RVA: 0x000161E8 File Offset: 0x000143E8
		// (remove) Token: 0x060004BE RID: 1214 RVA: 0x00016220 File Offset: 0x00014420
		public event InteractionObjectV2Base.UpdateHandler applyed;

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x00016255 File Offset: 0x00014455
		public float firstPauseTime
		{
			get
			{
				return this.m_FirstPauseTime;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0001625D File Offset: 0x0001445D
		public bool isInitiated
		{
			get
			{
				return this.m_isInitiated;
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00016268 File Offset: 0x00014468
		public override void Initiate()
		{
			this.initialSpeedInMod = new ValorModificable(this.defaultSpeedMod);
			this.speedInMod = new ValorModificable(this.defaultSpeedMod);
			this.speedOutMod = new ValorModificable(this.defaultSpeedMod);
			Action<InteractionObjectV2Base> initiating = this.Initiating;
			if (initiating != null)
			{
				initiating(this);
			}
			base.Initiate();
			this.m_length = base.length;
			this.m_customTargets = (from t in base.targetsRoot.GetComponentsInChildren<InteractionTargetTValle>()
				where t.enabled
				select t).ToArray<InteractionTargetTValle>();
			InteractionObject.InteractionEvent interactionEvent = this.events.FirstOrDefault((InteractionObject.InteractionEvent ev) => ev.pause);
			this.m_FirstPauseTime = ((interactionEvent != null) ? new float?(interactionEvent.time) : null).GetValueOrDefault(-1f);
			this.m_isInitiated = true;
			Action<InteractionObjectV2Base> initiated = this.Initiated;
			if (initiated != null)
			{
				initiated(this);
			}
			this.Initiating = null;
			this.Initiated = null;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00016384 File Offset: 0x00014584
		public void OnStartInteraction(InteractionSystem interactionSystem, InteractionEffector effector)
		{
			if (interactionSystem == null)
			{
				throw new ArgumentNullException("interactionSystem", "interactionSystem null reference.");
			}
			if (effector == null)
			{
				throw new ArgumentNullException("efecctor", "efecctor null reference.");
			}
			if (this.m_currentEffectors.Contains(effector))
			{
				throw new InvalidOperationException(string.Concat(new string[]
				{
					"Efecttor : ",
					effector.effectorType.ToString(),
					" de systema: ",
					interactionSystem.name,
					". se esta ejecutando dos veces sin haberse detenido."
				}));
			}
			if (this.m_currentSystem != null && this.m_currentSystem != interactionSystem)
			{
				throw new InvalidOperationException(base.GetType().Name + " con nombre: " + base.name + " no se puede ejecutar en dos sytemas diferentes.");
			}
			this.m_estado = InteractionObjectV2Base.Estado.empezando;
			this.m_currentEffectors.Add(effector);
			Action<InteractionObjectV2Base, InteractionEffector> action = this.staringOnEffector;
			if (action != null)
			{
				action(this, effector);
			}
			if (this.m_currentSystem == null)
			{
				Action<InteractionObjectV2Base, InteractionSystem> action2 = this.staring;
				if (action2 != null)
				{
					action2(this, interactionSystem);
				}
				this.m_CustomEffectorOfType.Clear();
				this.m_CustomEffector.Clear();
				if (interactionSystem.ik == null)
				{
					throw new InvalidOperationException("interaction system no esta inicializado");
				}
				interactionSystem.ik.GetComponentsInChildren<IIKCustomEffector>(this.m_CustomEffector);
				for (int i = 0; i < this.m_CustomEffector.Count; i++)
				{
					IIKCustomEffector iikcustomEffector = this.m_CustomEffector[i];
					for (int j = 0; j < iikcustomEffector.effectorsTypes.Count; j++)
					{
						CustomBipedEffector customBipedEffector = iikcustomEffector.effectorsTypes[j];
						if (!this.m_CustomEffectorOfType.ContainsKey(customBipedEffector))
						{
							this.m_CustomEffectorOfType.Add(customBipedEffector, iikcustomEffector);
						}
					}
				}
				this.m_currentSystem = interactionSystem;
				this.m_currentCharacter = interactionSystem.GetComponentInParent<IAnimatorCharacter>();
				Action<InteractionObjectV2Base, InteractionSystem> action3 = this.stared;
				if (action3 != null)
				{
					action3(this, interactionSystem);
				}
				this.OnStartInteractionOnSystem(interactionSystem);
			}
			if (!this.m_targetsValidChecked)
			{
				this.m_targetsValidChecked = true;
				InteractionSystemV3 interactionSystemV = interactionSystem as InteractionSystemV3;
				bool valueOrDefault = ((interactionSystemV != null) ? new bool?(interactionSystemV.doCheckInteractionObjects) : null).GetValueOrDefault(false);
				int valueOrDefault2 = ((interactionSystemV != null) ? new int?(interactionSystemV.IK_layer) : null).GetValueOrDefault(-1);
				if (valueOrDefault && valueOrDefault2 == 0)
				{
					if (this.m_customTargets.FirstOrDefault((InteractionTargetTValle t) => t.effectorType == CustomBipedEffector.codoDerecho) == null)
					{
						Debug.LogError(base.targetsRoot.name + " no contiene target " + CustomBipedEffector.codoDerecho.ToString(), base.targetsRoot);
					}
					if (this.m_customTargets.FirstOrDefault((InteractionTargetTValle t) => t.effectorType == CustomBipedEffector.codoIzquierdo) == null)
					{
						Debug.LogError(base.targetsRoot.name + " no contiene target " + CustomBipedEffector.codoIzquierdo.ToString(), base.targetsRoot);
					}
					if (this.m_customTargets.FirstOrDefault((InteractionTargetTValle t) => t.effectorType == CustomBipedEffector.rodillaDerecho) == null)
					{
						Debug.LogError(base.targetsRoot.name + " no contiene target " + CustomBipedEffector.rodillaDerecho.ToString(), base.targetsRoot);
					}
					if (this.m_customTargets.FirstOrDefault((InteractionTargetTValle t) => t.effectorType == CustomBipedEffector.rodillaIzquierdo) == null)
					{
						Debug.LogError(base.targetsRoot.name + " no contiene target " + CustomBipedEffector.rodillaIzquierdo.ToString(), base.targetsRoot);
					}
				}
			}
			Action<InteractionObjectV2Base, InteractionEffector> action4 = this.staredOnEffector;
			if (action4 != null)
			{
				action4(this, effector);
			}
			this.OnStartInteractionOnEffector(effector);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00016791 File Offset: 0x00014991
		public InteractionTargetTValle[] GetCustomTargets()
		{
			return this.m_customTargets;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00016799 File Offset: 0x00014999
		protected virtual void OnStartInteractionOnSystem(InteractionSystem interactionSystem)
		{
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0001679B File Offset: 0x0001499B
		protected virtual void OnStartInteractionOnEffector(InteractionEffector efecctor)
		{
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000167A0 File Offset: 0x000149A0
		public void SetDefaultSpeedIfNotInteracting()
		{
			if (this.m_currentSystem == null)
			{
				this.initialSpeedInMod = new ValorModificable(this.defaultSpeedMod);
				this.speedInMod = new ValorModificable(this.defaultSpeedMod);
				this.speedOutMod = new ValorModificable(this.defaultSpeedMod);
			}
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x000167EE File Offset: 0x000149EE
		public void OnPausedInteraction(InteractionSystem interactionSystem, InteractionEffector efecctor)
		{
			this.m_estado = InteractionObjectV2Base.Estado.pausado;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x000167F7 File Offset: 0x000149F7
		public void OnResumedInteraction(InteractionSystem interactionSystem, InteractionEffector efecctor)
		{
			this.m_estado = InteractionObjectV2Base.Estado.terminando;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00016800 File Offset: 0x00014A00
		public void OnStopInteraction(InteractionSystem interactionSystem, IKSolverFullBodyBiped solver, InteractionEffector efecctor)
		{
			if (interactionSystem == null)
			{
				throw new ArgumentNullException("interactionSystem", "interactionSystem null reference.");
			}
			if (efecctor == null)
			{
				throw new ArgumentNullException("efecctor", "efecctor null reference.");
			}
			this.m_currentEffectors.Remove(efecctor);
			if (this.m_currentSystem != null && this.m_currentSystem != interactionSystem)
			{
				throw new InvalidOperationException(base.GetType().Name + " con nombre: " + base.name + " no se puede detener en dos sytemas diferentes.");
			}
			if (this.m_currentEffectors.Count == 0)
			{
				this.m_currentSystem = null;
				this.m_currentCharacter = null;
			}
			Action<InteractionObjectV2Base, InteractionEffector> action = this.stopingOnEffector;
			if (action != null)
			{
				action(this, efecctor);
			}
			if (this.m_currentSystem == null)
			{
				this.initialSpeedInMod = new ValorModificable(this.defaultSpeedMod);
				this.speedInMod = new ValorModificable(this.defaultSpeedMod);
				this.speedOutMod = new ValorModificable(this.defaultSpeedMod);
				Action<InteractionObjectV2Base, InteractionSystem> action2 = this.stoping;
				if (action2 != null)
				{
					action2(this, interactionSystem);
				}
				this.m_CustomEffectorOfType.Clear();
				this.m_CustomEffector.Clear();
				Action<InteractionObjectV2Base, InteractionSystem> action3 = this.stoped;
				if (action3 != null)
				{
					action3(this, interactionSystem);
				}
				this.OnStopInteractionOnSystem(interactionSystem);
			}
			Action<InteractionObjectV2Base, InteractionEffector> action4 = this.stopedOnEffector;
			if (action4 != null)
			{
				action4(this, efecctor);
			}
			this.OnStopInteractionOnEffector(solver, efecctor);
			this.m_estado = InteractionObjectV2Base.Estado.detenido;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0001695C File Offset: 0x00014B5C
		protected virtual void OnStopInteractionOnSystem(InteractionSystem interactionSystem)
		{
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0001695E File Offset: 0x00014B5E
		protected virtual void OnStopInteractionOnEffector(IKSolverFullBodyBiped solver, InteractionEffector efecctor)
		{
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00016960 File Offset: 0x00014B60
		public virtual void Applying(IKSolverFullBodyBiped solver, InteractionEffector interactionEffector, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight)
		{
			InteractionObjectV2Base.UpdateHandler updateHandler = this.applying;
			if (updateHandler == null)
			{
				return;
			}
			updateHandler(solver, interactionEffector, effector, target, timer, weight);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0001697C File Offset: 0x00014B7C
		public override void Apply(IKSolverFullBodyBiped solver, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight)
		{
			base.Apply(solver, effector, target, timer, weight);
			for (int i = 0; i < this.customCurves.Length; i++)
			{
				float num = ((target == null || this.customCurves[i].ignorarIntTargetWeight) ? 1f : 1f);
				this.Apply(solver, effector, this.customCurves[i].type, this.customCurves[i].GetValue(timer), weight * num);
			}
			for (int j = 0; j < this.multiplierToCustomCurve.Length; j++)
			{
				int weightCurveIndex = base.GetWeightCurveIndex(this.multiplierToCustomCurve[j].curve);
				if (weightCurveIndex != -1)
				{
					float num2 = ((target == null || this.multiplierToCustomCurve[j].ignorarIntTargetWeight) ? 1f : 1f);
					this.Apply(solver, effector, this.multiplierToCustomCurve[j].result, this.multiplierToCustomCurve[j].GetValue(this.weightCurves[weightCurveIndex], timer), (this.multiplierToCustomCurve[j].ignorarInteractionEffectorWeight ? 1f : weight) * num2);
				}
				else if (!Warning.logged)
				{
					Warning.Log("InteractionObject Multiplier curve " + this.multiplierToCustomCurve[j].curve.ToString() + "does not exist.", base.transform, false);
				}
			}
			for (int k = 0; k < this.lerpToCustomCurve.Length; k++)
			{
				int weightCurveIndex2 = base.GetWeightCurveIndex(this.lerpToCustomCurve[k].curve);
				if (weightCurveIndex2 != -1)
				{
					float num3 = ((target == null || this.lerpToCustomCurve[k].ignorarIntTargetWeight) ? 1f : 1f);
					this.Apply(solver, effector, this.lerpToCustomCurve[k].result, this.lerpToCustomCurve[k].GetValue(this.weightCurves[weightCurveIndex2], timer), (this.lerpToCustomCurve[k].ignorarInteractionEffectorWeight ? 1f : weight) * num3);
				}
				else if (!Warning.logged)
				{
					Warning.Log("InteractionObject Multiplier curve " + this.lerpToCustomCurve[k].curve.ToString() + "does not exist.", base.transform, false);
				}
			}
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00016BB7 File Offset: 0x00014DB7
		protected void Apply(IKSolverFullBodyBiped solver, FullBodyBipedEffector effector, InteractionObjectV2Base.CustomCurva.Type type, float value, float weight)
		{
			if (type == InteractionObjectV2Base.CustomCurva.Type.iterations)
			{
				solver.iterations = Mathf.FloorToInt(Mathf.Lerp((float)solver.iterations, value, weight));
				return;
			}
			throw new ArgumentOutOfRangeException(type.ToString());
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00016BEC File Offset: 0x00014DEC
		protected sealed override void Apply(IKSolverFullBodyBiped solver, FullBodyBipedEffector effector, InteractionObject.WeightCurve.Type type, float value, float weight)
		{
			switch (type)
			{
			case InteractionObject.WeightCurve.Type.PositionWeight:
			case InteractionObject.WeightCurve.Type.RotationWeight:
			case InteractionObject.WeightCurve.Type.Pull:
			case InteractionObject.WeightCurve.Type.Reach:
			case InteractionObject.WeightCurve.Type.RotateBoneWeight:
			case InteractionObject.WeightCurve.Type.Push:
			case InteractionObject.WeightCurve.Type.PushParent:
			case InteractionObject.WeightCurve.Type.PoserWeight:
				base.Apply(solver, effector, type, value, weight);
				return;
			case InteractionObject.WeightCurve.Type.PositionOffsetX:
			{
				if (this.positionOffsetSpace != null || this.m_currentCharacter == null || !this.m_currentCharacter.bones.Contiene(this.positionOffsetBoneSpace))
				{
					Transform transform = ((this.positionOffsetSpace != null) ? this.positionOffsetSpace : solver.GetRoot());
					solver.GetEffector(effector).position += transform.rotation * (Vector3.right * value * weight * transform.lossyScale.Escala());
					return;
				}
				DatosDeBoneBase datosDeBoneBase = this.m_currentCharacter.bones.Obtener(this.positionOffsetBoneSpace);
				solver.GetEffector(effector).position += datosDeBoneBase.currentWorldRotation * (Vector3.right * value * weight * datosDeBoneBase.transform.lossyScale.Escala());
				return;
			}
			case InteractionObject.WeightCurve.Type.PositionOffsetY:
			{
				if (this.positionOffsetSpace != null || this.m_currentCharacter == null || !this.m_currentCharacter.bones.Contiene(this.positionOffsetBoneSpace))
				{
					Transform transform2 = ((this.positionOffsetSpace != null) ? this.positionOffsetSpace : solver.GetRoot());
					solver.GetEffector(effector).position += transform2.rotation * (Vector3.up * value * weight * transform2.lossyScale.Escala());
					return;
				}
				DatosDeBoneBase datosDeBoneBase2 = this.m_currentCharacter.bones.Obtener(this.positionOffsetBoneSpace);
				solver.GetEffector(effector).position += datosDeBoneBase2.currentWorldRotation * (Vector3.up * value * weight * datosDeBoneBase2.transform.lossyScale.Escala());
				return;
			}
			case InteractionObject.WeightCurve.Type.PositionOffsetZ:
			{
				if (this.positionOffsetSpace != null || this.m_currentCharacter == null || !this.m_currentCharacter.bones.Contiene(this.positionOffsetBoneSpace))
				{
					Transform transform3 = ((this.positionOffsetSpace != null) ? this.positionOffsetSpace : solver.GetRoot());
					solver.GetEffector(effector).position += transform3.rotation * (Vector3.forward * value * weight * transform3.lossyScale.Escala());
					return;
				}
				DatosDeBoneBase datosDeBoneBase3 = this.m_currentCharacter.bones.Obtener(this.positionOffsetBoneSpace);
				solver.GetEffector(effector).position += datosDeBoneBase3.currentWorldRotation * (Vector3.forward * value * weight * datosDeBoneBase3.transform.lossyScale.Escala());
				return;
			}
			default:
				throw new ArgumentOutOfRangeException(type.ToString());
			}
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00016F30 File Offset: 0x00015130
		public virtual void Applyed(IKSolverFullBodyBiped solver, InteractionEffector interactionEffector, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight, bool stopedOnUpdate)
		{
			for (int i = 0; i < this.multipliersV2.Count; i++)
			{
				InteractionObjectV2Base.MultiplierVersion2 multiplierVersion = this.multipliersV2[i];
				if (multiplierVersion.curve == multiplierVersion.result && !Warning.logged)
				{
					Warning.Log("InteractionObject Multiplier 'Curve' " + multiplierVersion.curve.ToString() + "and 'Result' are the same.", base.transform, false);
				}
				int weightCurveIndex = base.GetWeightCurveIndex(multiplierVersion.curve);
				if (weightCurveIndex != -1)
				{
					float num = ((target == null) ? 1f : target.GetValue(multiplierVersion.result));
					float num2 = 0f;
					InteractionEffectorV2 interactionEffectorV = interactionEffector as InteractionEffectorV2;
					if (interactionEffectorV != null)
					{
						num2 = interactionEffectorV.GetDefaultValueDeWeightCurveType(multiplierVersion.result);
					}
					float value = multiplierVersion.GetValue(this.weightCurves[weightCurveIndex], timer, num2);
					this.Apply(solver, effector, multiplierVersion.result, value, (multiplierVersion.ignorarInteractionEffectorWeight ? 1f : weight) * num);
				}
				else if (!Warning.logged)
				{
					Warning.Log("InteractionObject Multiplier curve " + multiplierVersion.curve.ToString() + "does not exist.", base.transform, false);
				}
			}
			InteractionObjectV2Base.UpdateHandler updateHandler = this.applyed;
			if (updateHandler == null)
			{
				return;
			}
			updateHandler(solver, interactionEffector, effector, target, timer, weight);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00017084 File Offset: 0x00015284
		public override float GetValue(InteractionObject.WeightCurve.Type weightCurveType, InteractionTarget target, float timer)
		{
			switch (weightCurveType)
			{
			case InteractionObject.WeightCurve.Type.PositionOffsetX:
			case InteractionObject.WeightCurve.Type.PositionOffsetY:
			case InteractionObject.WeightCurve.Type.PositionOffsetZ:
			case InteractionObject.WeightCurve.Type.RotateBoneWeight:
			case InteractionObject.WeightCurve.Type.PoserWeight:
				break;
			default:
				Debug.LogWarning("No se puede saber el valor por defecto de: " + weightCurveType.ToString() + ". puede causar resultados no deseados.", this);
				break;
			}
			float value = base.GetValue(weightCurveType, target, timer);
			if (value > 0f)
			{
				return value;
			}
			for (int i = 0; i < this.multipliersV2.Count; i++)
			{
				if (this.multipliersV2[i].result == weightCurveType)
				{
					int weightCurveIndex = base.GetWeightCurveIndex(this.multipliersV2[i].curve);
					if (weightCurveIndex != -1)
					{
						float num = ((target == null) ? 1f : target.GetValue(this.multipliersV2[i].result));
						float num2 = 0f;
						return this.multipliersV2[i].GetValue(this.weightCurves[weightCurveIndex], timer, num2) * num;
					}
				}
			}
			return 0f;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00017194 File Offset: 0x00015394
		protected bool ContieneCustomTarget(CustomBipedEffector effector, out InteractionTargetTValle customTarget)
		{
			for (int i = 0; i < this.m_customTargets.Length; i++)
			{
				InteractionTargetTValle interactionTargetTValle = this.m_customTargets[i];
				if (interactionTargetTValle.effectorType == effector)
				{
					customTarget = interactionTargetTValle;
					return true;
				}
			}
			customTarget = null;
			return false;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x000171D0 File Offset: 0x000153D0
		public bool CurveUsed(InteractionObjectV2Base.CustomCurva.Type type)
		{
			InteractionObjectV2Base.CustomCurva[] array = this.customCurves;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].type == type)
				{
					return true;
				}
			}
			InteractionObjectV2Base.MultiplierToCustomCurve[] array2 = this.multiplierToCustomCurve;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].result == type)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00017224 File Offset: 0x00015424
		public override bool CurveUsed(InteractionObject.WeightCurve.Type type)
		{
			if (base.CurveUsed(type))
			{
				return true;
			}
			using (List<InteractionObjectV2Base.MultiplierVersion2>.Enumerator enumerator = this.multipliersV2.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.result == type)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0001728C File Offset: 0x0001548C
		protected void ApplyCustomTargets(IKSolverFullBodyBiped solverFBIK, float timer, float weight, IList<InteractionObjectV2Base.CurvaForCustomEffector> curvas, bool stoped)
		{
			for (int i = 0; i < this.m_customTargets.Length; i++)
			{
				InteractionTargetTValle interactionTargetTValle = this.m_customTargets[i];
				if (!(interactionTargetTValle == null))
				{
					IIKCustomEffector iikcustomEffector;
					this.m_CustomEffectorOfType.TryGetValue(interactionTargetTValle.effectorType, out iikcustomEffector);
					this.ApplyCurvasCustomTargets(solverFBIK, iikcustomEffector, interactionTargetTValle, timer, weight, curvas, stoped);
				}
			}
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000172E4 File Offset: 0x000154E4
		protected void ApplyDefaultTypeMultiV2(IKSolverFullBodyBiped solverFBIK, float timer, float weight, IList<InteractionObjectV2Base.MultiplicadorNormal> multis, bool stoped)
		{
			for (int i = 0; i < multis.Count; i++)
			{
				InteractionObjectV2Base.MultiplicadorNormal multiplicadorNormal = multis[i];
				if (multiplicadorNormal.active)
				{
					int weightCurveIndex = base.GetWeightCurveIndex(multiplicadorNormal.curve);
					if (weightCurveIndex != -1)
					{
						float num = 1f;
						bool flag = false;
						for (int j = 0; j < this.m_customTargets.Length; j++)
						{
							InteractionTargetTValle interactionTargetTValle = this.m_customTargets[j];
							if (!(interactionTargetTValle == null) && multiplicadorNormal.CanApplyTo(interactionTargetTValle))
							{
								IIKCustomEffector iikcustomEffector;
								this.m_CustomEffectorOfType.TryGetValue(interactionTargetTValle.effectorType, out iikcustomEffector);
								this.ApplyCustom(solverFBIK, iikcustomEffector, interactionTargetTValle, interactionTargetTValle.effectorType, multiplicadorNormal.result, multiplicadorNormal.GetValue(this.weightCurves[weightCurveIndex], timer, this.m_estado), weight * num, stoped);
								flag = true;
							}
						}
						if (!flag && this.SetCustomPoseAsTargetsIfPosible)
						{
							IReadOnlyList<int> enumValoresInt = typeof(CustomBipedEffector).GetEnumValoresInt();
							for (int k = 0; k < enumValoresInt.Count; k++)
							{
								CustomBipedEffector customBipedEffector = (CustomBipedEffector)enumValoresInt[k];
								if (multiplicadorNormal.CanApplyTo(customBipedEffector))
								{
									IIKCustomEffector iikcustomEffector2;
									this.m_CustomEffectorOfType.TryGetValue(customBipedEffector, out iikcustomEffector2);
									this.ApplyCustomNoExist(solverFBIK, iikcustomEffector2, customBipedEffector, multiplicadorNormal.result, multiplicadorNormal.GetValue(this.weightCurves[weightCurveIndex], timer, this.m_estado), weight * num, stoped);
								}
							}
						}
					}
					else if (!Warning.logged)
					{
						Warning.Log("InteractionObject Multiplier curve " + multiplicadorNormal.curve.ToString() + "does not exist.", base.transform, false);
					}
				}
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00017478 File Offset: 0x00015678
		[Obsolete("remplazado por v2", true)]
		protected void ApplyDefaultTypeMulti(IKSolverFullBodyBiped solverFBIK, float timer, float weight, IList<InteractionObjectV2Base.MultiplicadorNormal> multi, bool stoped)
		{
			for (int i = 0; i < this.m_customTargets.Length; i++)
			{
				InteractionTargetTValle interactionTargetTValle = this.m_customTargets[i];
				if (!(interactionTargetTValle == null))
				{
					IIKCustomEffector iikcustomEffector;
					this.m_CustomEffectorOfType.TryGetValue(interactionTargetTValle.effectorType, out iikcustomEffector);
					this.ApplyDefaultTypeMulti(solverFBIK, iikcustomEffector, interactionTargetTValle, timer, weight, multi, stoped);
				}
			}
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x000174D0 File Offset: 0x000156D0
		[Obsolete("remplazado por v2", true)]
		private void ApplyDefaultTypeMulti(IKSolverFullBodyBiped solverFBIK, IIKCustomEffector solver, InteractionTargetTValle target, float timer, float weight, IList<InteractionObjectV2Base.MultiplicadorNormal> multis, bool stoped)
		{
			for (int i = 0; i < multis.Count; i++)
			{
				InteractionObjectV2Base.MultiplicadorNormal multiplicadorNormal = multis[i];
				int weightCurveIndex = base.GetWeightCurveIndex(multiplicadorNormal.curve);
				if (weightCurveIndex != -1)
				{
					float num = 1f;
					if (multiplicadorNormal.active && multiplicadorNormal.CanApplyTo(target))
					{
						this.ApplyCustom(solverFBIK, solver, target, target.effectorType, multiplicadorNormal.result, multiplicadorNormal.GetValue(this.weightCurves[weightCurveIndex], timer, this.m_estado), weight * num, stoped);
					}
				}
				else if (!Warning.logged)
				{
					Warning.Log("InteractionObject Multiplier curve " + multiplicadorNormal.curve.ToString() + "does not exist.", base.transform, false);
				}
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0001758C File Offset: 0x0001578C
		protected void ApplyCustomTypeMulti(IKSolverFullBodyBiped solverFBIK, float timer, float weight, IList<InteractionObjectV2Base.MultiplicadorCustom> multi, IList<InteractionObjectV2Base.CurvaForCustomEffector> curvas, bool stoped)
		{
			for (int i = 0; i < this.m_customTargets.Length; i++)
			{
				InteractionTargetTValle interactionTargetTValle = this.m_customTargets[i];
				if (!(interactionTargetTValle == null))
				{
					IIKCustomEffector iikcustomEffector;
					this.m_CustomEffectorOfType.TryGetValue(interactionTargetTValle.effectorType, out iikcustomEffector);
					this.ApplyCustomTypeMulti(solverFBIK, iikcustomEffector, interactionTargetTValle, timer, weight, curvas, multi, stoped);
				}
			}
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000175E4 File Offset: 0x000157E4
		private void ApplyCustomTypeMulti(IKSolverFullBodyBiped solverFBIK, IIKCustomEffector solver, InteractionTargetTValle target, float timer, float weight, IList<InteractionObjectV2Base.CurvaForCustomEffector> curvas, IList<InteractionObjectV2Base.MultiplicadorCustom> multis, bool stoped)
		{
			for (int i = 0; i < multis.Count; i++)
			{
				InteractionObjectV2Base.MultiplicadorCustom multiplicadorCustom = multis[i];
				int weightCurveIndex = this.GetWeightCurveIndex(curvas, multiplicadorCustom.curve);
				if (weightCurveIndex != -1)
				{
					float num = 1f;
					if (multiplicadorCustom.active && multiplicadorCustom.CanApplyTo(target))
					{
						this.ApplyCustom(solverFBIK, solver, target, target.effectorType, multiplicadorCustom.result, multiplicadorCustom.GetValue(curvas[weightCurveIndex], timer), weight * num, stoped);
					}
				}
				else if (!Warning.logged)
				{
					Warning.Log("InteractionObject Multiplier curve " + multiplicadorCustom.curve.ToString() + "does not exist.", base.transform, false);
				}
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0001769C File Offset: 0x0001589C
		private void ApplyCurvasCustomTargets(IKSolverFullBodyBiped solverFBIK, IIKCustomEffector solver, InteractionTargetTValle target, float timer, float weight, IList<InteractionObjectV2Base.CurvaForCustomEffector> curvas, bool stoped)
		{
			for (int i = 0; i < curvas.Count; i++)
			{
				float num = 1f;
				InteractionObjectV2Base.CurvaForCustomEffector curvaForCustomEffector = curvas[i];
				if (curvaForCustomEffector.active && curvaForCustomEffector.CanApplyTo(target))
				{
					this.ApplyCustom(solverFBIK, solver, target, target.effectorType, curvaForCustomEffector.type, curvaForCustomEffector.GetValue(timer), weight * num, stoped);
				}
			}
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x000176FE File Offset: 0x000158FE
		private void ApplyCustom(IKSolverFullBodyBiped solver, IIKCustomEffector customSolver, InteractionTargetTValle target, CustomBipedEffector effector, InteractionObjectV2Base.CurvaForCustomEffector.Type type, float value, float weight, bool stoped)
		{
			this.ApplyCustomToSolver(solver, target, effector, type, value, weight, stoped);
			if (customSolver != null)
			{
				this.ApplyCustomEffector(customSolver, target, effector, type, value, weight, stoped);
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00017727 File Offset: 0x00015927
		private void ApplyCustomNoExist(IKSolverFullBodyBiped solver, IIKCustomEffector customSolver, CustomBipedEffector effector, InteractionObjectV2Base.CurvaForCustomEffector.Type type, float value, float weight, bool stoped)
		{
			this.ApplyCustomNoExistToSolver(solver, effector, type, value, weight, stoped);
			if (customSolver != null)
			{
				this.ApplyCustomNoExistToEffector(customSolver, effector, type, value, weight, stoped);
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0001774C File Offset: 0x0001594C
		private void ApplyCustomNoExistToSolver(IKSolverFullBodyBiped solver, CustomBipedEffector effector, InteractionObjectV2Base.CurvaForCustomEffector.Type type, float value, float weight, bool stoped)
		{
			if (type != InteractionObjectV2Base.CurvaForCustomEffector.Type.RotationWeight)
			{
				if (type == InteractionObjectV2Base.CurvaForCustomEffector.Type.BendGoal)
				{
					if (effector <= CustomBipedEffector.codoDerecho)
					{
						if (effector <= CustomBipedEffector.hombroDerecho)
						{
							switch (effector)
							{
							case CustomBipedEffector.None:
							case CustomBipedEffector.head:
							case CustomBipedEffector.cuello1:
							case CustomBipedEffector.cuello2:
							case CustomBipedEffector.hombroIzquierdo:
								return;
							case CustomBipedEffector.head | CustomBipedEffector.cuello1:
							case CustomBipedEffector.head | CustomBipedEffector.cuello2:
							case CustomBipedEffector.cuello1 | CustomBipedEffector.cuello2:
							case CustomBipedEffector.head | CustomBipedEffector.cuello1 | CustomBipedEffector.cuello2:
								break;
							default:
								if (effector == CustomBipedEffector.hombroDerecho)
								{
									return;
								}
								break;
							}
						}
						else
						{
							if (effector == CustomBipedEffector.codoIzquierdo)
							{
								IKConstraintBend bendConstraint = solver.GetBendConstraint(FullBodyBipedChain.LeftArm);
								bendConstraint.weight = Mathf.Lerp(bendConstraint.weight, value, weight);
								bendConstraint.usarCurrentPoseWeight = Mathf.Lerp(0f, value, weight);
								return;
							}
							if (effector == CustomBipedEffector.codoDerecho)
							{
								IKConstraintBend bendConstraint2 = solver.GetBendConstraint(FullBodyBipedChain.RightArm);
								bendConstraint2.weight = Mathf.Lerp(bendConstraint2.weight, value, weight);
								bendConstraint2.usarCurrentPoseWeight = Mathf.Lerp(0f, value, weight);
								return;
							}
						}
					}
					else if (effector <= CustomBipedEffector.rodillaDerecho)
					{
						if (effector == CustomBipedEffector.rodillaIzquierdo)
						{
							IKConstraintBend bendConstraint3 = solver.GetBendConstraint(FullBodyBipedChain.LeftLeg);
							bendConstraint3.weight = Mathf.Lerp(bendConstraint3.weight, value, weight);
							bendConstraint3.usarCurrentPoseWeight = Mathf.Lerp(0f, value, weight);
							return;
						}
						if (effector == CustomBipedEffector.rodillaDerecho)
						{
							IKConstraintBend bendConstraint4 = solver.GetBendConstraint(FullBodyBipedChain.RightLeg);
							bendConstraint4.weight = Mathf.Lerp(bendConstraint4.weight, value, weight);
							bendConstraint4.usarCurrentPoseWeight = Mathf.Lerp(0f, value, weight);
							return;
						}
					}
					else if (effector == CustomBipedEffector.toeIzquierdo || effector == CustomBipedEffector.toeDerecho)
					{
						return;
					}
					throw new ArgumentOutOfRangeException(effector.ToString());
				}
				throw new ArgumentOutOfRangeException(type.ToString());
			}
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x000178DC File Offset: 0x00015ADC
		private void ApplyCustomToSolver(IKSolverFullBodyBiped solver, InteractionTargetTValle target, CustomBipedEffector effector, InteractionObjectV2Base.CurvaForCustomEffector.Type type, float value, float weight, bool stoped)
		{
			float num;
			if (target.esBendGoalV2)
			{
				if (target.esBendGoalAlwaysForced)
				{
					num = weight;
				}
				else
				{
					num = (1f - value) * weight;
				}
			}
			else
			{
				num = 0f;
			}
			if (stoped)
			{
				num = 0f;
			}
			if (type != InteractionObjectV2Base.CurvaForCustomEffector.Type.RotationWeight)
			{
				if (type == InteractionObjectV2Base.CurvaForCustomEffector.Type.BendGoal)
				{
					CustomBipedEffector effectorType = target.effectorType;
					if (effectorType <= CustomBipedEffector.codoDerecho)
					{
						if (effectorType <= CustomBipedEffector.hombroDerecho)
						{
							switch (effectorType)
							{
							case CustomBipedEffector.None:
							case CustomBipedEffector.head:
							case CustomBipedEffector.cuello1:
							case CustomBipedEffector.cuello2:
							case CustomBipedEffector.hombroIzquierdo:
								return;
							case CustomBipedEffector.head | CustomBipedEffector.cuello1:
							case CustomBipedEffector.head | CustomBipedEffector.cuello2:
							case CustomBipedEffector.cuello1 | CustomBipedEffector.cuello2:
							case CustomBipedEffector.head | CustomBipedEffector.cuello1 | CustomBipedEffector.cuello2:
								break;
							default:
								if (effectorType == CustomBipedEffector.hombroDerecho)
								{
									return;
								}
								break;
							}
						}
						else
						{
							if (effectorType == CustomBipedEffector.codoIzquierdo)
							{
								IKConstraintBend bendConstraint = solver.GetBendConstraint(FullBodyBipedChain.LeftArm);
								bendConstraint.weight = Mathf.Lerp(bendConstraint.weight, value, weight);
								bendConstraint.usaroverridenBendGoalPositionWeight = num;
								if (bendConstraint.usaroverridenBendGoalPositionWeight > 0f)
								{
									bendConstraint.overridenBendGoalPosition = target.bendGoalV2Position;
								}
								bendConstraint.bendGoal = (stoped ? null : ((target != null) ? target.transform : null));
								return;
							}
							if (effectorType == CustomBipedEffector.codoDerecho)
							{
								IKConstraintBend bendConstraint2 = solver.GetBendConstraint(FullBodyBipedChain.RightArm);
								bendConstraint2.weight = Mathf.Lerp(bendConstraint2.weight, value, weight);
								bendConstraint2.usaroverridenBendGoalPositionWeight = num;
								if (bendConstraint2.usaroverridenBendGoalPositionWeight > 0f)
								{
									bendConstraint2.overridenBendGoalPosition = target.bendGoalV2Position;
								}
								bendConstraint2.bendGoal = (stoped ? null : ((target != null) ? target.transform : null));
								return;
							}
						}
					}
					else if (effectorType <= CustomBipedEffector.rodillaDerecho)
					{
						if (effectorType == CustomBipedEffector.rodillaIzquierdo)
						{
							IKConstraintBend bendConstraint3 = solver.GetBendConstraint(FullBodyBipedChain.LeftLeg);
							bendConstraint3.weight = Mathf.Lerp(bendConstraint3.weight, value, weight);
							bendConstraint3.usaroverridenBendGoalPositionWeight = num;
							if (bendConstraint3.usaroverridenBendGoalPositionWeight > 0f)
							{
								bendConstraint3.overridenBendGoalPosition = target.bendGoalV2Position;
							}
							bendConstraint3.bendGoal = (stoped ? null : ((target != null) ? target.transform : null));
							return;
						}
						if (effectorType == CustomBipedEffector.rodillaDerecho)
						{
							IKConstraintBend bendConstraint4 = solver.GetBendConstraint(FullBodyBipedChain.RightLeg);
							bendConstraint4.weight = Mathf.Lerp(bendConstraint4.weight, value, weight);
							bendConstraint4.usaroverridenBendGoalPositionWeight = num;
							if (bendConstraint4.usaroverridenBendGoalPositionWeight > 0f)
							{
								bendConstraint4.overridenBendGoalPosition = target.bendGoalV2Position;
							}
							bendConstraint4.bendGoal = (stoped ? null : ((target != null) ? target.transform : null));
							return;
						}
					}
					else if (effectorType == CustomBipedEffector.toeIzquierdo || effectorType == CustomBipedEffector.toeDerecho)
					{
						return;
					}
					throw new ArgumentOutOfRangeException(target.effectorType.ToString());
				}
				throw new ArgumentOutOfRangeException(type.ToString());
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00017B58 File Offset: 0x00015D58
		private void ApplyCustomNoExistToEffector(IIKCustomEffector solver, CustomBipedEffector effector, InteractionObjectV2Base.CurvaForCustomEffector.Type type, float value, float weight, bool stoped)
		{
			if (type != InteractionObjectV2Base.CurvaForCustomEffector.Type.RotationWeight)
			{
				if (type != InteractionObjectV2Base.CurvaForCustomEffector.Type.BendGoal)
				{
					throw new ArgumentOutOfRangeException(type.ToString());
				}
			}
			else
			{
				solver.SetRotationWeightOf(effector, Mathf.Lerp(solver.GetRotationWeightOf(effector), value, weight));
				Transform transform = null;
				if (effector <= CustomBipedEffector.codoDerecho)
				{
					if (effector <= CustomBipedEffector.hombroDerecho)
					{
						switch (effector)
						{
						case CustomBipedEffector.None:
							goto IL_0174;
						case CustomBipedEffector.head:
						{
							DatosDeBoneBase datosDeBoneBase = this.m_currentCharacter.bones.Obtener(HumanBodyBones.Head);
							transform = ((datosDeBoneBase != null) ? datosDeBoneBase.transform : null);
							goto IL_0174;
						}
						case CustomBipedEffector.cuello1:
						{
							DatosDeBoneBase datosDeBoneBase2 = this.m_currentCharacter.bones.Obtener(HumanBodyBones.Neck);
							transform = ((datosDeBoneBase2 != null) ? datosDeBoneBase2.transform : null);
							goto IL_0174;
						}
						case CustomBipedEffector.head | CustomBipedEffector.cuello1:
						case CustomBipedEffector.head | CustomBipedEffector.cuello2:
						case CustomBipedEffector.cuello1 | CustomBipedEffector.cuello2:
						case CustomBipedEffector.head | CustomBipedEffector.cuello1 | CustomBipedEffector.cuello2:
							goto IL_0161;
						case CustomBipedEffector.cuello2:
							break;
						case CustomBipedEffector.hombroIzquierdo:
						{
							DatosDeBoneBase datosDeBoneBase3 = this.m_currentCharacter.bones.Obtener(HumanBodyBones.LeftShoulder);
							transform = ((datosDeBoneBase3 != null) ? datosDeBoneBase3.transform : null);
							goto IL_0174;
						}
						default:
						{
							if (effector != CustomBipedEffector.hombroDerecho)
							{
								goto IL_0161;
							}
							DatosDeBoneBase datosDeBoneBase4 = this.m_currentCharacter.bones.Obtener(HumanBodyBones.RightShoulder);
							transform = ((datosDeBoneBase4 != null) ? datosDeBoneBase4.transform : null);
							goto IL_0174;
						}
						}
					}
					else
					{
						if (effector != CustomBipedEffector.codoIzquierdo && effector != CustomBipedEffector.codoDerecho)
						{
							goto IL_0161;
						}
						goto IL_0174;
					}
				}
				else if (effector <= CustomBipedEffector.rodillaDerecho)
				{
					if (effector != CustomBipedEffector.rodillaIzquierdo && effector != CustomBipedEffector.rodillaDerecho)
					{
						goto IL_0161;
					}
					goto IL_0174;
				}
				else if (effector != CustomBipedEffector.toeIzquierdo && effector != CustomBipedEffector.toeDerecho)
				{
					goto IL_0161;
				}
				Debug.LogError("TODO: aun no es compatible con " + effector.ToString());
				goto IL_0174;
				IL_0161:
				throw new ArgumentOutOfRangeException(effector.ToString());
				IL_0174:
				if (transform != null)
				{
					solver.SetRotationTargetOf(effector, transform.rotation);
					return;
				}
			}
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00017D04 File Offset: 0x00015F04
		private void ApplyCustomEffector(IIKCustomEffector solver, InteractionTargetTValle target, CustomBipedEffector effector, InteractionObjectV2Base.CurvaForCustomEffector.Type type, float value, float weight, bool stoped)
		{
			if (type != InteractionObjectV2Base.CurvaForCustomEffector.Type.RotationWeight)
			{
				if (type != InteractionObjectV2Base.CurvaForCustomEffector.Type.BendGoal)
				{
					throw new ArgumentOutOfRangeException(type.ToString());
				}
			}
			else
			{
				solver.SetRotationWeightOf(effector, Mathf.Lerp(solver.GetRotationWeightOf(effector), value, weight));
				if (target != null)
				{
					solver.SetRotationTargetOf(effector, target.transform.rotation);
					return;
				}
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00017D64 File Offset: 0x00015F64
		private int GetWeightCurveIndex(IList<InteractionObjectV2Base.CurvaForCustomEffector> curvas, InteractionObjectV2Base.CurvaForCustomEffector.Type curvaType)
		{
			for (int i = 0; i < curvas.Count; i++)
			{
				if (curvas[i].type == curvaType)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x04000317 RID: 791
		[Header("V2 Config")]
		[Space]
		[Range(0f, 1f)]
		public float fixHandsInteractionTargetTwistWeight;

		// Token: 0x04000318 RID: 792
		[Tooltip("se buguea con bend goals  TODO")]
		public bool SetCustomPoseAsTargetsIfPosible;

		// Token: 0x04000319 RID: 793
		public List<InteractionObjectV2Base.MultiplierVersion2> multipliersV2;

		// Token: 0x0400031A RID: 794
		public InteractionObjectV2Base.CustomCurva[] customCurves;

		// Token: 0x0400031B RID: 795
		public InteractionObjectV2Base.MultiplierToCustomCurve[] multiplierToCustomCurve;

		// Token: 0x0400031C RID: 796
		public InteractionObjectV2Base.LerpToCustomCurve[] lerpToCustomCurve;

		// Token: 0x0400031D RID: 797
		[Space]
		[Range(0f, 1f)]
		[Tooltip("Solo para funciona interaction object de pies o pelvis")]
		public float highHeelPoseWeigth;

		// Token: 0x0400031E RID: 798
		[Range(0f, 1f)]
		[Tooltip("Solo para funciona interaction object de pies o pelvis")]
		public float highHeelToePoseWeigth = 1f;

		// Token: 0x0400031F RID: 799
		[Range(0f, 2f)]
		[Tooltip("Solo para funciona interaction object de pies o pelvis")]
		public float highHeelPoseHeightMod = 1f;

		// Token: 0x04000320 RID: 800
		public HumanBodyBones positionOffsetBoneSpace;

		// Token: 0x04000321 RID: 801
		public float defaultSpeedMod = 1f;

		// Token: 0x04000322 RID: 802
		public ValorModificable initialSpeedInMod;

		// Token: 0x04000323 RID: 803
		public ValorModificable speedInMod;

		// Token: 0x04000324 RID: 804
		public ValorModificable speedOutMod;

		// Token: 0x04000325 RID: 805
		[ReadOnlyUI]
		[SerializeField]
		private InteractionSystem m_currentSystem;

		// Token: 0x04000326 RID: 806
		[ReadOnlyUI]
		[SerializeField]
		private IAnimatorCharacter m_currentCharacter;

		// Token: 0x04000327 RID: 807
		private HashSet<InteractionEffector> m_currentEffectors = new HashSet<InteractionEffector>();

		// Token: 0x04000328 RID: 808
		[ReadOnlyUI]
		[SerializeField]
		protected InteractionObjectV2Base.Estado m_estado;

		// Token: 0x04000329 RID: 809
		public float lookAtVelocityMod = 1f;

		// Token: 0x0400032A RID: 810
		[SerializeField]
		private float m_lookAtPriorityV2 = 1f;

		// Token: 0x0400032B RID: 811
		private bool m_targetsValidChecked;

		// Token: 0x0400032C RID: 812
		protected InteractionTargetTValle[] m_customTargets;

		// Token: 0x0400032D RID: 813
		protected DiccionaryEnum<CustomBipedEffector, IIKCustomEffector> m_CustomEffectorOfType = new DiccionaryEnum<CustomBipedEffector, IIKCustomEffector>((CustomBipedEffector e) => (int)e);

		// Token: 0x0400032E RID: 814
		protected List<IIKCustomEffector> m_CustomEffector = new List<IIKCustomEffector>();

		// Token: 0x0400033B RID: 827
		[ReadOnlyUI]
		[SerializeField]
		private float m_length;

		// Token: 0x0400033C RID: 828
		[ReadOnlyUI]
		[SerializeField]
		private float m_FirstPauseTime;

		// Token: 0x0400033D RID: 829
		[ReadOnlyUI]
		[SerializeField]
		private bool m_isInitiated;

		// Token: 0x0200016A RID: 362
		public enum Estado
		{
			// Token: 0x04000846 RID: 2118
			detenido,
			// Token: 0x04000847 RID: 2119
			empezando,
			// Token: 0x04000848 RID: 2120
			pausado,
			// Token: 0x04000849 RID: 2121
			terminando
		}

		// Token: 0x0200016B RID: 363
		// (Invoke) Token: 0x06000BCB RID: 3019
		public delegate void UpdateHandler(IKSolverFullBodyBiped solver, InteractionEffector interactionEffector, FullBodyBipedEffector effector, InteractionTarget target, float timer, float weight);

		// Token: 0x0200016C RID: 364
		[Serializable]
		public class MultiplicadorCustom
		{
			// Token: 0x1700023E RID: 574
			// (get) Token: 0x06000BCE RID: 3022 RVA: 0x000361A5 File Offset: 0x000343A5
			public bool active
			{
				get
				{
					return this.applyToMask > CustomBipedEffector.None;
				}
			}

			// Token: 0x06000BCF RID: 3023 RVA: 0x000361B0 File Offset: 0x000343B0
			public bool CanApplyTo(InteractionTargetTValle target)
			{
				return ((int)this.applyToMask).HasFlag((int)target.effectorType);
			}

			// Token: 0x06000BD0 RID: 3024 RVA: 0x000361C3 File Offset: 0x000343C3
			public float GetValue(InteractionObjectV2Base.CurvaForCustomEffector weightCurve, float timer)
			{
				return (weightCurve.GetValue(timer) * this.multiplier).OutPow(this.outPower);
			}

			// Token: 0x0400084A RID: 2122
			public CustomBipedEffector applyToMask;

			// Token: 0x0400084B RID: 2123
			[Tooltip("The curve type to multiply.")]
			public InteractionObjectV2Base.CurvaForCustomEffector.Type curve;

			// Token: 0x0400084C RID: 2124
			[Tooltip("The multiplier of the curve's value.")]
			public float multiplier = 1f;

			// Token: 0x0400084D RID: 2125
			public float outPower = 1f;

			// Token: 0x0400084E RID: 2126
			public InteractionObjectV2Base.CurvaForCustomEffector.Type result;
		}

		// Token: 0x0200016D RID: 365
		[Serializable]
		public class MultiplicadorNormal
		{
			// Token: 0x1700023F RID: 575
			// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x000361FC File Offset: 0x000343FC
			public bool active
			{
				get
				{
					return this.applyToMask > CustomBipedEffector.None;
				}
			}

			// Token: 0x06000BD3 RID: 3027 RVA: 0x00036208 File Offset: 0x00034408
			public float GetValue(InteractionObject.WeightCurve weightCurve, float timer, InteractionObjectV2Base.Estado estado)
			{
				switch (estado)
				{
				case InteractionObjectV2Base.Estado.detenido:
				case InteractionObjectV2Base.Estado.pausado:
					return weightCurve.GetValue(timer) * this.multiplier;
				case InteractionObjectV2Base.Estado.empezando:
					return (weightCurve.GetValue(timer) * this.multiplier).OutPow(this.empezandoOutPower);
				case InteractionObjectV2Base.Estado.terminando:
					return (weightCurve.GetValue(timer) * this.multiplier).InPow(this.terminandoInPower);
				default:
					throw new ArgumentOutOfRangeException(estado.ToString());
				}
			}

			// Token: 0x06000BD4 RID: 3028 RVA: 0x00036282 File Offset: 0x00034482
			public bool CanApplyTo(InteractionTargetTValle target)
			{
				return ((int)this.applyToMask).HasFlag((int)target.effectorType);
			}

			// Token: 0x06000BD5 RID: 3029 RVA: 0x00036295 File Offset: 0x00034495
			public bool CanApplyTo(CustomBipedEffector customBipedEffector)
			{
				return ((int)this.applyToMask).HasFlag((int)customBipedEffector);
			}

			// Token: 0x0400084F RID: 2127
			public CustomBipedEffector applyToMask;

			// Token: 0x04000850 RID: 2128
			[Tooltip("The curve type to multiply.")]
			public InteractionObject.WeightCurve.Type curve;

			// Token: 0x04000851 RID: 2129
			[Tooltip("The multiplier of the curve's value.")]
			public float multiplier = 1f;

			// Token: 0x04000852 RID: 2130
			public float empezandoOutPower = 1f;

			// Token: 0x04000853 RID: 2131
			public float terminandoInPower = 1f;

			// Token: 0x04000854 RID: 2132
			public InteractionObjectV2Base.CurvaForCustomEffector.Type result;

			// Token: 0x04000855 RID: 2133
			[Header("OBSOLETO: reemplazarlo con empezandoOutPower, terminandoInPower")]
			[Obsolete("", true)]
			public float outPower = 1f;
		}

		// Token: 0x0200016E RID: 366
		[Serializable]
		public class CustomCurva
		{
			// Token: 0x06000BD7 RID: 3031 RVA: 0x000362D7 File Offset: 0x000344D7
			public float GetValue(float timer)
			{
				return this.curve.Evaluate(timer);
			}

			// Token: 0x04000856 RID: 2134
			[Tooltip("The type of the curve (InteractionObject.WeightCurve.Type).")]
			public InteractionObjectV2Base.CustomCurva.Type type;

			// Token: 0x04000857 RID: 2135
			[Tooltip("The weight curve.")]
			public AnimationCurve curve;

			// Token: 0x04000858 RID: 2136
			public bool ignorarIntTargetWeight;

			// Token: 0x020001E1 RID: 481
			[Serializable]
			public enum Type
			{
				// Token: 0x04000A2C RID: 2604
				iterations
			}
		}

		// Token: 0x0200016F RID: 367
		[Serializable]
		public class LerpToCustomCurve
		{
			// Token: 0x06000BD9 RID: 3033 RVA: 0x000362F0 File Offset: 0x000344F0
			public float GetValue(InteractionObject.WeightCurve weightCurve, float timer)
			{
				float value = weightCurve.GetValue(timer);
				float num = Mathf.InverseLerp(this.inputMinValue, this.inputMaxValue, value);
				if (this.outPower > 0f)
				{
					num = num.OutPow(this.outPower);
				}
				return Mathf.Lerp(this.outputMinValue, this.outputMaxValue, num);
			}

			// Token: 0x04000859 RID: 2137
			[Tooltip("The curve type to multiply.")]
			public InteractionObject.WeightCurve.Type curve;

			// Token: 0x0400085A RID: 2138
			public float inputMinValue;

			// Token: 0x0400085B RID: 2139
			public float inputMaxValue = 1f;

			// Token: 0x0400085C RID: 2140
			public float outputMinValue;

			// Token: 0x0400085D RID: 2141
			public float outputMaxValue = 1f;

			// Token: 0x0400085E RID: 2142
			[Tooltip("The resulting value will be applied to this channel.")]
			public InteractionObjectV2Base.CustomCurva.Type result;

			// Token: 0x0400085F RID: 2143
			[Tooltip("0.5 and 3, equals 0.875.")]
			public float outPower = 1f;

			// Token: 0x04000860 RID: 2144
			public bool ignorarIntTargetWeight;

			// Token: 0x04000861 RID: 2145
			public bool ignorarInteractionEffectorWeight;
		}

		// Token: 0x02000170 RID: 368
		[Serializable]
		public class MultiplierToCustomCurve
		{
			// Token: 0x06000BDB RID: 3035 RVA: 0x00036370 File Offset: 0x00034570
			public float GetValue(InteractionObject.WeightCurve weightCurve, float timer)
			{
				float num = Mathf.Abs(this.multiplier);
				return weightCurve.GetValue(timer) * num;
			}

			// Token: 0x04000862 RID: 2146
			[Tooltip("The curve type to multiply.")]
			public InteractionObject.WeightCurve.Type curve;

			// Token: 0x04000863 RID: 2147
			[Tooltip("The multiplier of the curve's value.")]
			public float multiplier = 1f;

			// Token: 0x04000864 RID: 2148
			[Tooltip("The resulting value will be applied to this channel.")]
			public InteractionObjectV2Base.CustomCurva.Type result;

			// Token: 0x04000865 RID: 2149
			public bool ignorarIntTargetWeight;

			// Token: 0x04000866 RID: 2150
			public bool ignorarInteractionEffectorWeight;
		}

		// Token: 0x02000171 RID: 369
		[Serializable]
		public class CurvaForCustomEffector
		{
			// Token: 0x17000240 RID: 576
			// (get) Token: 0x06000BDD RID: 3037 RVA: 0x000363A5 File Offset: 0x000345A5
			public bool active
			{
				get
				{
					return this.applyToMask > CustomBipedEffector.None;
				}
			}

			// Token: 0x06000BDE RID: 3038 RVA: 0x000363B0 File Offset: 0x000345B0
			public float GetValue(float timer)
			{
				return this.curve.Evaluate(timer);
			}

			// Token: 0x06000BDF RID: 3039 RVA: 0x000363BE File Offset: 0x000345BE
			public bool CanApplyTo(InteractionTargetTValle target)
			{
				return ((int)this.applyToMask).HasFlag((int)target.effectorType);
			}

			// Token: 0x04000867 RID: 2151
			public CustomBipedEffector applyToMask;

			// Token: 0x04000868 RID: 2152
			[Tooltip("The curve type to multiply.")]
			public InteractionObjectV2Base.CurvaForCustomEffector.Type type;

			// Token: 0x04000869 RID: 2153
			[Tooltip("The weight curve.")]
			public AnimationCurve curve;

			// Token: 0x020001E2 RID: 482
			[Serializable]
			public enum Type
			{
				// Token: 0x04000A2E RID: 2606
				RotationWeight,
				// Token: 0x04000A2F RID: 2607
				[Tooltip("Por ahora solo las rodillas usan BendGoal")]
				BendGoal
			}
		}

		// Token: 0x02000172 RID: 370
		[Serializable]
		public class MultiplierVersion2
		{
			// Token: 0x06000BE1 RID: 3041 RVA: 0x000363DC File Offset: 0x000345DC
			public float GetValue(InteractionObject.WeightCurve weightCurve, float timer, float defaultValue)
			{
				float value = weightCurve.GetValue(timer);
				float num = Mathf.InverseLerp(this.inputMinValue, this.inputMaxValue, value);
				if (this.outPower > 0f)
				{
					num = num.OutPow(this.outPower);
				}
				if (this.invertir)
				{
					num = 1f - num;
				}
				float num2;
				float num3;
				switch (this.defaultValueInfluence)
				{
				case InteractionObjectV2Base.MultiplierVersion2.DefaultValueInfluence.ninguna:
					num2 = this.outputMinValue;
					num3 = this.outputMaxValue;
					break;
				case InteractionObjectV2Base.MultiplierVersion2.DefaultValueInfluence.esOutputMinValue:
					num2 = defaultValue;
					num3 = this.outputMaxValue;
					break;
				case InteractionObjectV2Base.MultiplierVersion2.DefaultValueInfluence.esOutputMaxValue:
					num2 = this.outputMinValue;
					num3 = defaultValue;
					break;
				default:
					throw new ArgumentOutOfRangeException(this.defaultValueInfluence.ToString());
				}
				return Mathf.Lerp(num2, num3, num);
			}

			// Token: 0x0400086A RID: 2154
			[Tooltip("The curve type to multiply.")]
			public InteractionObject.WeightCurve.Type curve;

			// Token: 0x0400086B RID: 2155
			[Tooltip("The resulting value will be applied to this channel.")]
			public InteractionObject.WeightCurve.Type result;

			// Token: 0x0400086C RID: 2156
			[Tooltip("Zero or One to ignore, 0.5 and 3, equals 0.875.")]
			public float outPower = 1f;

			// Token: 0x0400086D RID: 2157
			public float inputMinValue;

			// Token: 0x0400086E RID: 2158
			public float inputMaxValue = 1f;

			// Token: 0x0400086F RID: 2159
			public float outputMinValue;

			// Token: 0x04000870 RID: 2160
			public float outputMaxValue = 1f;

			// Token: 0x04000871 RID: 2161
			public InteractionObjectV2Base.MultiplierVersion2.DefaultValueInfluence defaultValueInfluence;

			// Token: 0x04000872 RID: 2162
			public bool invertir;

			// Token: 0x04000873 RID: 2163
			public bool ignorarInteractionEffectorWeight;

			// Token: 0x020001E3 RID: 483
			public enum DefaultValueInfluence
			{
				// Token: 0x04000A31 RID: 2609
				ninguna,
				// Token: 0x04000A32 RID: 2610
				esOutputMinValue,
				// Token: 0x04000A33 RID: 2611
				esOutputMaxValue
			}
		}
	}
}
