using System;
using System.Collections;
using System.Linq;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Behaviours
{
	// Token: 0x02000127 RID: 295
	public sealed class TValleSemiPuppetBehaviour : BehaviourBase
	{
		// Token: 0x060005F0 RID: 1520 RVA: 0x00021944 File Offset: 0x0001FB44
		protected override void OnInitiate()
		{
			base.OnInitiate();
			ConfiguracionGlobal.Layers layersStatic = ConfiguracionGlobal.layersStatic;
			this.collisionLayers = layersStatic.MaskForLayer(layersStatic.ragdoll);
			this.collisionLayers &= ~(1 << layersStatic.ground);
			this.collisionLayers &= ~(1 << layersStatic.wall);
			this.collisionLayers &= ~(1 << layersStatic.glassWall);
			this.collisionLayers &= ~(1 << layersStatic.superficieObstaculo);
			this.groupStates = this.groupOverrides.Select((TValleSemiPuppetBehaviour.MusclePropsGroup mpg) => new TValleSemiPuppetBehaviour.MuscleStateGroup
			{
				groups = mpg.groups,
				side = mpg.side,
				state = new TValleSemiPuppetBehaviour.MuscleState()
			}).ToArray<TValleSemiPuppetBehaviour.MuscleStateGroup>();
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00021A38 File Offset: 0x0001FC38
		protected override void OnDeactivate()
		{
			base.OnDeactivate();
			if (this.m_BlendMappingCorrutina != null && !this.m_BlendMappingCorrutina.finalizada)
			{
				GlobalUpdater.Corrutina blendMappingCorrutina = this.m_BlendMappingCorrutina;
				if (blendMappingCorrutina != null)
				{
					blendMappingCorrutina.Stop();
				}
			}
			foreach (Muscle muscle in this.puppetMaster.muscles)
			{
				TValleSemiPuppetBehaviour.MuscleState state = this.GetState(muscle.grupo);
				this.ResetState(state);
			}
			if (GlobalUpdater.IsInScene && GlobalUpdater.instancia != null && this.puppetMaster != null)
			{
				this.m_BlendMappingCorrutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this.puppetMaster, this.BlendMappingRutine(1f, 0.5f), new ManualCorrutina.OnEndedHandler(this.BlendMappingRutineEnded));
			}
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x00021AF8 File Offset: 0x0001FCF8
		private void BlendMappingRutineEnded(MonoBehaviour owner, ManualCorrutina ended, Exception error)
		{
			if (error != null && this.puppetMaster != null)
			{
				float num = (float)(base.isActiveAndEnabled ? 0 : 1);
				Muscle[] muscles = this.puppetMaster.muscles;
				for (int i = 0; i < muscles.Length; i++)
				{
					muscles[i].state.mappingWeightMlp = num;
				}
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00021B4C File Offset: 0x0001FD4C
		private IEnumerator BlendMappingRutine(float target, float speed)
		{
			bool finalizado = false;
			while (this.puppetMaster != null && !finalizado)
			{
				finalizado = true;
				foreach (Muscle muscle in this.puppetMaster.muscles)
				{
					muscle.state.mappingWeightMlp = Mathf.MoveTowards(muscle.state.mappingWeightMlp, target, Time.deltaTime * speed);
					finalizado &= muscle.state.mappingWeightMlp == target;
				}
				yield return null;
			}
			yield break;
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00021B6C File Offset: 0x0001FD6C
		protected override void OnActivate()
		{
			base.OnActivate();
			if (this.m_BlendMappingCorrutina != null && !this.m_BlendMappingCorrutina.finalizada)
			{
				GlobalUpdater.Corrutina blendMappingCorrutina = this.m_BlendMappingCorrutina;
				if (blendMappingCorrutina != null)
				{
					blendMappingCorrutina.Stop();
				}
			}
			foreach (Muscle muscle in this.puppetMaster.muscles)
			{
				TValleSemiPuppetBehaviour.MuscleState state = this.GetState(muscle.grupo);
				this.ResetState(state);
			}
			this.m_BlendMappingCorrutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this.puppetMaster, this.BlendMappingRutine(0f, 1f), new ManualCorrutina.OnEndedHandler(this.BlendMappingRutineEnded));
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00021C0C File Offset: 0x0001FE0C
		private void ResetState(TValleSemiPuppetBehaviour.MuscleState state)
		{
			state.fixedFrameID = -1;
			state.regainUnMappingCoolDownResult = 0f;
			state.lastTimeHit = 0f;
			state.mappingBlendSpeedResult = (this.whenHit.mappingBlendSpeed + this.whenCollided.mappingBlendSpeed) / 2f;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00021C59 File Offset: 0x0001FE59
		protected override void OnReadBehaviour()
		{
			bool enabled = base.enabled;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00021C64 File Offset: 0x0001FE64
		protected override void OnLateUpdate()
		{
			if (!this.puppetMaster.isAlive)
			{
				return;
			}
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				Muscle muscle = this.puppetMaster.muscles[i];
				TValleSemiPuppetBehaviour.MuscleProps props = this.GetProps(muscle.grupo);
				muscle.state.mappingWeightMlp = Mathf.Clamp(muscle.state.mappingWeightMlp, props.minMappingWeight, props.maxMappingWeight);
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00021CDC File Offset: 0x0001FEDC
		protected override void OnFixedUpdate()
		{
			this.collisions = 0;
			if (!this.puppetMaster.isActive)
			{
				return;
			}
			if (!this.puppetMaster.isAlive)
			{
				base.enabled = false;
				return;
			}
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				Muscle muscle = this.puppetMaster.muscles[i];
				TValleSemiPuppetBehaviour.MuscleState state = this.GetState(muscle.grupo);
				if (Time.time - state.lastTimeHit >= state.regainUnMappingCoolDownResult)
				{
					TValleSemiPuppetBehaviour.MuscleProps props = this.GetProps(muscle.grupo);
					float num = Mathf.Clamp01(muscle.state.mappingWeightMlp);
					num = Mathf.Lerp(0.1f, 1f, num);
					muscle.state.mappingWeightMlp = Mathf.MoveTowards(muscle.state.mappingWeightMlp, 0f, Time.deltaTime * state.mappingBlendSpeedResult * props.regainUnMappingSpeed * num);
				}
			}
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00021DC8 File Offset: 0x0001FFC8
		protected override void OnMuscleHitBehaviour(MuscleHit hit)
		{
			if (!base.enabled)
			{
				return;
			}
			if (!this.puppetMaster.isActive || this.puppetMaster.isBlending)
			{
				return;
			}
			float num = this.collisionThreshold;
			float impulse = this.GetImpulse(new Vector3(0f, 0f, hit.unPin), hit.muscleIndex, ref num);
			float num2 = 1f;
			float num3 = num * num2;
			if (impulse <= num3)
			{
				return;
			}
			this.MapFromCollisionOrHit(hit.muscleIndex, impulse, this.whenHit);
			if (hit.force.sqrMagnitude > 0f)
			{
				this.puppetMaster.muscles[hit.muscleIndex].rigidbody.AddForceAtPosition(hit.force, hit.position);
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00021E84 File Offset: 0x00020084
		protected override void OnMuscleCollisionBehaviour(MuscleCollision m)
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.collisions > this.maxCollisions)
			{
				return;
			}
			if (!LayerMaskExtensions.Contains(this.collisionLayers, m.collision.gameObject.layer))
			{
				return;
			}
			if (!this.puppetMaster.isActive || this.puppetMaster.isBlending)
			{
				return;
			}
			float num = this.collisionThreshold;
			float impulse = this.GetImpulse(m, ref num);
			float num2 = 1f;
			float num3 = num * num2;
			if (impulse <= num3)
			{
				return;
			}
			this.collisions++;
			this.MapFromCollisionOrHit(m.muscleIndex, impulse, this.whenCollided);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00021F24 File Offset: 0x00020124
		private void MapFromCollisionOrHit(int muscleIndex, float mapping, TValleSemiPuppetBehaviour.MappingLossAndGainConfig config)
		{
			if (muscleIndex >= this.puppetMaster.muscles.Length)
			{
				return;
			}
			TValleSemiPuppetBehaviour.MuscleProps props = this.GetProps(this.puppetMaster.muscles[muscleIndex].grupo);
			for (int i = 0; i < this.puppetMaster.muscles.Length; i++)
			{
				this.MapMuscle(i, mapping * this.GetFalloff(i, muscleIndex, props.mapParents, props.mapChildren, props.mapGroup), config.maxDamageSpeed);
			}
			TValleSemiPuppetBehaviour.MuscleState state = this.GetState(this.puppetMaster.muscles[muscleIndex].grupo);
			state.lastTimeHit = Time.time;
			int frameCount = FixedFrameCounter.frameCount;
			if (state.fixedFrameID == frameCount)
			{
				state.mappingBlendSpeedResult = (state.mappingBlendSpeedResult + config.mappingBlendSpeed) / 2f;
				state.regainUnMappingCoolDownResult = (state.regainUnMappingCoolDownResult + config.regainUnMappingCoolDown) / 2f;
			}
			else
			{
				state.mappingBlendSpeedResult = config.mappingBlendSpeed;
				state.regainUnMappingCoolDownResult = config.regainUnMappingCoolDown;
			}
			state.fixedFrameID = frameCount;
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00022024 File Offset: 0x00020224
		private void MapMuscle(int muscleIndex, float mapping, float maxDamageSpeed)
		{
			if (mapping <= 0f)
			{
				return;
			}
			if (this.puppetMaster.muscles[muscleIndex].state.immunity >= 1f)
			{
				return;
			}
			TValleSemiPuppetBehaviour.MuscleProps props = this.GetProps(this.puppetMaster.muscles[muscleIndex].grupo);
			float num = 1f;
			float num2 = ((this.collisionResistance.mode == Weight.Mode.Float) ? this.collisionResistance.floatValue : this.collisionResistance.GetValue(this.puppetMaster.muscles[muscleIndex].targetVelocity.magnitude));
			float num3 = mapping / (props.collisionResistance * num2 * num);
			num3 *= 1f - this.puppetMaster.muscles[muscleIndex].state.immunity;
			float mappingWeightMlp = this.puppetMaster.muscles[muscleIndex].state.mappingWeightMlp;
			float num4 = 1f - Mathf.Clamp01(mappingWeightMlp);
			num4 = Mathf.Lerp(0.1f, 1f, num4);
			float num5 = maxDamageSpeed * Time.fixedDeltaTime * num4;
			num3 = Mathf.Clamp(num3, -num5, num5);
			Muscle muscle = this.puppetMaster.muscles[muscleIndex];
			muscle.state.mappingWeightMlp = muscle.state.mappingWeightMlp + num3;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00022158 File Offset: 0x00020358
		private TValleSemiPuppetBehaviour.MuscleProps GetProps(Muscle.GroupCompleto group)
		{
			for (int i = 0; i < this.groupOverrides.Length; i++)
			{
				TValleSemiPuppetBehaviour.MusclePropsGroup musclePropsGroup = this.groupOverrides[i];
				for (int j = 0; j < musclePropsGroup.groups.Length; j++)
				{
					if (musclePropsGroup.groups[j] == group)
					{
						return musclePropsGroup.props;
					}
				}
			}
			return this.defaults;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x000221B0 File Offset: 0x000203B0
		private TValleSemiPuppetBehaviour.MuscleState GetState(Muscle.GroupCompleto group)
		{
			for (int i = 0; i < this.groupStates.Length; i++)
			{
				TValleSemiPuppetBehaviour.MuscleStateGroup muscleStateGroup = this.groupStates[i];
				for (int j = 0; j < muscleStateGroup.groups.Length; j++)
				{
					if (muscleStateGroup.groups[j] == group)
					{
						return muscleStateGroup.state;
					}
				}
			}
			return this.defaultState;
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00022204 File Offset: 0x00020404
		private float GetImpulse(MuscleCollision m, ref float layerThreshold)
		{
			float num = this.GetImpulse(m.collision.impulse, m.muscleIndex);
			foreach (TValleSemiPuppetBehaviour.CollisionResistanceMultiplier collisionResistanceMultiplier in this.collisionResistanceMultipliers)
			{
				if (LayerMaskExtensions.Contains(collisionResistanceMultiplier.layers, m.collision.collider.gameObject.layer))
				{
					if (collisionResistanceMultiplier.multiplier <= 0f)
					{
						num = float.PositiveInfinity;
					}
					else
					{
						num /= collisionResistanceMultiplier.multiplier;
					}
					layerThreshold = collisionResistanceMultiplier.collisionThreshold;
					break;
				}
			}
			return num;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00022294 File Offset: 0x00020494
		private float GetImpulse(Vector3 impulse, int muscleIndex, ref float layerThreshold)
		{
			float num = this.GetImpulse(impulse, muscleIndex);
			TValleSemiPuppetBehaviour.CollisionResistanceMultiplier[] array = this.collisionResistanceMultipliers;
			int num2 = 0;
			if (num2 < array.Length)
			{
				TValleSemiPuppetBehaviour.CollisionResistanceMultiplier collisionResistanceMultiplier = array[num2];
				if (collisionResistanceMultiplier.multiplier <= 0f)
				{
					num = float.PositiveInfinity;
				}
				else
				{
					num /= collisionResistanceMultiplier.multiplier;
				}
				layerThreshold = collisionResistanceMultiplier.collisionThreshold;
			}
			return num;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x000222EC File Offset: 0x000204EC
		private float GetImpulse(Vector3 impulse, int muscleIndex)
		{
			return impulse.sqrMagnitude / this.puppetMaster.muscles[muscleIndex].rigidbody.mass * 0.3f;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00022314 File Offset: 0x00020514
		private float GetFalloff(int i, int muscleIndex, float falloffParents, float falloffChildren, float falloffGroup)
		{
			float num = this.GetFalloff(i, muscleIndex, falloffParents, falloffChildren);
			Muscle muscle = this.puppetMaster.muscles[i];
			Muscle muscle2 = this.puppetMaster.muscles[muscleIndex];
			if (falloffGroup > 0f && i != muscleIndex && this.InGroup(muscle, muscle2))
			{
				num = Mathf.Max(num, falloffGroup);
			}
			return num;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0002236C File Offset: 0x0002056C
		private float GetFalloff(int i, int muscleIndex, float falloffParents, float falloffChildren)
		{
			if (i == muscleIndex)
			{
				return 1f;
			}
			bool flag = this.puppetMaster.muscles[muscleIndex].childFlags[i];
			int num = this.puppetMaster.muscles[muscleIndex].kinshipDegrees[i];
			return Mathf.Pow(flag ? falloffChildren : falloffParents, (float)num);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x000223BC File Offset: 0x000205BC
		private bool InGroup(Muscle muscle1, Muscle muscle2)
		{
			foreach (TValleSemiPuppetBehaviour.MusclePropsGroup musclePropsGroup in this.groupOverrides)
			{
				if (muscle1.side == musclePropsGroup.side && muscle2.side == musclePropsGroup.side && musclePropsGroup.groups.Contains(muscle1.grupo) && musclePropsGroup.groups.Contains(muscle2.grupo))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00002BEA File Offset: 0x00000DEA
		public override void OnReactivate()
		{
		}

		// Token: 0x040004BF RID: 1215
		public TValleSemiPuppetBehaviour.MappingLossAndGainConfig whenHit = new TValleSemiPuppetBehaviour.MappingLossAndGainConfig
		{
			maxDamageSpeed = 3f,
			mappingBlendSpeed = 0.1f,
			regainUnMappingCoolDown = 3f
		};

		// Token: 0x040004C0 RID: 1216
		[Space]
		public TValleSemiPuppetBehaviour.MappingLossAndGainConfig whenCollided = new TValleSemiPuppetBehaviour.MappingLossAndGainConfig
		{
			maxDamageSpeed = 1f,
			mappingBlendSpeed = 1f,
			regainUnMappingCoolDown = 0.05f
		};

		// Token: 0x040004C1 RID: 1217
		[Obsolete("", true)]
		[NonSerialized]
		public float mappingBlendSpeed = 0.1f;

		// Token: 0x040004C2 RID: 1218
		[Obsolete("", true)]
		[NonSerialized]
		public float maxDamageSpeed = 3f;

		// Token: 0x040004C3 RID: 1219
		[Obsolete("", true)]
		[NonSerialized]
		public float regainUnMappingCoolDown = 3f;

		// Token: 0x040004C4 RID: 1220
		[Space]
		[Tooltip("An optimisation. Will only process up to this number of collisions per physics step.")]
		[Range(1f, 30f)]
		public int maxCollisions = 30;

		// Token: 0x040004C5 RID: 1221
		[ReadOnlyUI]
		[SerializeField]
		private int collisions;

		// Token: 0x040004C6 RID: 1222
		[Tooltip("Will unpin the muscles that collide with those layers.")]
		public LayerMask collisionLayers;

		// Token: 0x040004C7 RID: 1223
		[Tooltip("The collision impulse sqrMagnitude threshold under which collisions will be ignored.")]
		public float collisionThreshold;

		// Token: 0x040004C8 RID: 1224
		public Weight collisionResistance = new Weight(3f, "Smaller value means more unpinning from collisions so the characters get knocked out more easily. If using a curve, the value will be evaluated by each muscle's target velocity magnitude. This can be used to make collision resistance higher while the character moves or animates faster.");

		// Token: 0x040004C9 RID: 1225
		[Tooltip("Multiplies collision resistance for the specified layers.")]
		public TValleSemiPuppetBehaviour.CollisionResistanceMultiplier[] collisionResistanceMultipliers;

		// Token: 0x040004CA RID: 1226
		[LargeHeader("Muscle States")]
		[Tooltip("Automatico")]
		public TValleSemiPuppetBehaviour.MuscleState defaultState;

		// Token: 0x040004CB RID: 1227
		[Tooltip("Automatico")]
		public TValleSemiPuppetBehaviour.MuscleStateGroup[] groupStates;

		// Token: 0x040004CC RID: 1228
		[LargeHeader("Muscle Group Properties")]
		[Tooltip("The default muscle properties. If there are no 'Group Overrides', this will be used for all muscles.")]
		public TValleSemiPuppetBehaviour.MuscleProps defaults;

		// Token: 0x040004CD RID: 1229
		[Tooltip("Overriding default muscle properties for some muscle groups (for example making the feet stiffer or the hands looser).")]
		public TValleSemiPuppetBehaviour.MusclePropsGroup[] groupOverrides;

		// Token: 0x040004CE RID: 1230
		[SerializeField]
		private float[] m_currentMapping;

		// Token: 0x040004CF RID: 1231
		private GlobalUpdater.Corrutina m_BlendMappingCorrutina;

		// Token: 0x02000128 RID: 296
		[Serializable]
		public class MuscleState
		{
			// Token: 0x040004D0 RID: 1232
			public int fixedFrameID = -1;

			// Token: 0x040004D1 RID: 1233
			public float lastTimeHit;

			// Token: 0x040004D2 RID: 1234
			public float mappingBlendSpeedResult;

			// Token: 0x040004D3 RID: 1235
			public float regainUnMappingCoolDownResult;
		}

		// Token: 0x02000129 RID: 297
		[Serializable]
		public struct MuscleProps
		{
			// Token: 0x040004D4 RID: 1236
			[Tooltip("How much will collisions with muscles of this group unpin parent muscles?")]
			[Range(0f, 1f)]
			public float mapParents;

			// Token: 0x040004D5 RID: 1237
			[Tooltip("How much will collisions with muscles of this group unpin child muscles?")]
			[Range(0f, 1f)]
			public float mapChildren;

			// Token: 0x040004D6 RID: 1238
			[Tooltip("How much will collisions with muscles of this group unpin muscles of the same group?")]
			[Range(0f, 1f)]
			public float mapGroup;

			// Token: 0x040004D7 RID: 1239
			[Tooltip("If 1, muscles of this group will always be mapped to the ragdoll.")]
			[Range(0f, 1f)]
			public float minMappingWeight;

			// Token: 0x040004D8 RID: 1240
			[Tooltip("If 0, muscles of this group will not be mapped to the ragdoll pose even if they are unpinned.")]
			[Range(0f, 1f)]
			public float maxMappingWeight;

			// Token: 0x040004D9 RID: 1241
			[Tooltip("How fast will muscles of this group regain their pin weight (multiplier)?")]
			public float regainUnMappingSpeed;

			// Token: 0x040004DA RID: 1242
			[Tooltip("Smaller value means more unpinning from collisions (multiplier).")]
			public float collisionResistance;
		}

		// Token: 0x0200012A RID: 298
		[Serializable]
		public class MuscleStateGroup
		{
			// Token: 0x040004DB RID: 1243
			public Muscle.GroupCompleto[] groups;

			// Token: 0x040004DC RID: 1244
			public Muscle.MuscleSide side;

			// Token: 0x040004DD RID: 1245
			public TValleSemiPuppetBehaviour.MuscleState state;
		}

		// Token: 0x0200012B RID: 299
		[Serializable]
		public struct MusclePropsGroup
		{
			// Token: 0x040004DE RID: 1246
			[HideInInspector]
			public string name;

			// Token: 0x040004DF RID: 1247
			[Tooltip("Muscle groups to which those properties apply.")]
			public Muscle.GroupCompleto[] groups;

			// Token: 0x040004E0 RID: 1248
			public Muscle.MuscleSide side;

			// Token: 0x040004E1 RID: 1249
			[Tooltip("The muscle properties for those muscle groups.")]
			public TValleSemiPuppetBehaviour.MuscleProps props;
		}

		// Token: 0x0200012C RID: 300
		[Serializable]
		public struct CollisionResistanceMultiplier
		{
			// Token: 0x040004E2 RID: 1250
			public LayerMask layers;

			// Token: 0x040004E3 RID: 1251
			[Tooltip("Multiplier for the 'Collision Resistance' for these layers.")]
			public float multiplier;

			// Token: 0x040004E4 RID: 1252
			[Tooltip("Overrides 'Collision Threshold' for these layers.")]
			public float collisionThreshold;
		}

		// Token: 0x0200012D RID: 301
		[Serializable]
		public class MappingLossAndGainConfig
		{
			// Token: 0x040004E5 RID: 1253
			[Header("Gain Mapping (go to physics)")]
			public float maxDamageSpeed = 3f;

			// Token: 0x040004E6 RID: 1254
			[Header("Loose Mapping (go back to kinematics)")]
			public float mappingBlendSpeed = 0.1f;

			// Token: 0x040004E7 RID: 1255
			public float regainUnMappingCoolDown = 3f;
		}
	}
}
