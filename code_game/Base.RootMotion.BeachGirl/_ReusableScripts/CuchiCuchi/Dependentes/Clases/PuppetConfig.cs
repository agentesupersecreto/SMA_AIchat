using System;
using System.Collections;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Clases
{
	// Token: 0x0200005D RID: 93
	[Serializable]
	public class PuppetConfig : ConfiguracionParaTarget<PuppetMaster>
	{
		// Token: 0x060003FB RID: 1019 RVA: 0x00013380 File Offset: 0x00011580
		protected override void OnAplicarOnFemale(PuppetMaster target, FemaleAnimController controller)
		{
			bool flag = this.flagPuppetModoPorAnimatorState;
			this.flagPuppetModoPorAnimatorState = false;
			PuppetMaster p = target;
			if (p.targetRoot == null)
			{
				Debug.LogWarning("Please assign 'Target Root' for PuppetMaster using a Humanoid Config.", p.transform);
				return;
			}
			if (p.targetAnimator == null)
			{
				Debug.LogError("PuppetMaster 'Target Root' does not have an Animator component. Can not use Humanoid Config.", p.transform);
				return;
			}
			if (!p.targetAnimator.isHuman)
			{
				Debug.LogError("PuppetMaster target is not a Humanoid. Can not use Humanoid Config.", p.transform);
				return;
			}
			p.state = this.state;
			p.stateSettings = this.stateSettings;
			List<GlobalUpdater.Corrutina> list = ((controller.GetData(target) ?? new List<GlobalUpdater.Corrutina>()) as List<GlobalUpdater.Corrutina>) ?? new List<GlobalUpdater.Corrutina>();
			for (int i = 0; i < list.Count; i++)
			{
				GlobalUpdater.Corrutina corrutina = list[i];
				if (corrutina != null && !corrutina.finalizada)
				{
					corrutina.Stop();
				}
			}
			list.Clear();
			controller.SetData(target, list);
			if (!flag)
			{
				p.mode = this.startMode.mode;
				p.blendTime = this.startMode.blendTime;
				for (int j = 0; j < this.delayedMode.Count; j++)
				{
					PuppetConfig.DelayedMode modeDel = this.delayedMode[j];
					if (controller.animatedPoseID == FemaleAnimatedPoseIDs.None)
					{
						GlobalUpdater.instancia.Invokar(delegate
						{
							if (p)
							{
								p.mode = modeDel.mode;
								p.blendTime = modeDel.blendTime;
							}
						}, modeDel.startTime);
					}
					else
					{
						GlobalUpdater.Corrutina corrutina2 = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, controller, PuppetConfig.DelayModeRutine(modeDel, p, controller, this), null);
						list.Add(corrutina2);
					}
				}
				controller.SetData(target, list);
			}
			else
			{
				GlobalUpdater.Corrutina corrutina3 = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.lateUpdate1, controller, PuppetConfig.DelayModeByAnimatorRutine(p, controller, this), null);
				list.Add(corrutina3);
				controller.SetData(target, list);
			}
			p.fixTargetTransforms = this.fixTargetTransforms;
			p.solverIterationCount = this.solverIterationCount;
			p.mappingWeight = this.mappingWeight;
			p.pinWeight = this.pinWeight;
			p.muscleWeight = this.muscleWeight;
			Vector3 lossyScale = p.transform.lossyScale;
			float num = Mathf.Pow(lossyScale.x * lossyScale.y * lossyScale.z, 0.33333334f);
			p.muscleSpring = this.muscleSpring * Mathf.Pow(num, 2f);
			p.muscleDamper = this.muscleDamper * Mathf.Pow(num, 2f);
			p.pinPow = this.pinPow;
			p.pinDistanceFalloff = this.pinDistanceFalloff;
			p.updateJointAnchors = this.updateJointAnchors;
			p.supportTranslationAnimation = true;
			p.angularLimits = this.angularLimits;
			p.internalCollisions = this.internalCollisions;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000136D1 File Offset: 0x000118D1
		private static IEnumerator DelayModeByAnimatorRutine(PuppetMaster target, FemaleAnimController controller, PuppetConfig sender)
		{
			target.mode = PuppetMaster.Mode.Disabled;
			target.blendTime = 0.5f;
			yield return new ManualCorrutina.TValleWaitForSeconds(0.5f);
			target.mode = PuppetMaster.Mode.Kinematic;
			target.blendTime = 0.5f;
			for (;;)
			{
				yield return null;
				if (!controller.animator.IsInTransition(0))
				{
					AnimatorStateInfo animatorStateInfo = controller.animator.GetCurrentAnimatorStateInfo(0);
					if (animatorStateInfo.loop)
					{
						float num = animatorStateInfo.normalizedTime * animatorStateInfo.length;
						float tiempoEnd = num + 0.5f;
						float currentTime = num;
						do
						{
							yield return null;
							animatorStateInfo = controller.animator.GetCurrentAnimatorStateInfo(0);
							if (controller.animator.IsInTransition(0) || !animatorStateInfo.loop)
							{
								break;
							}
							currentTime = animatorStateInfo.normalizedTime * animatorStateInfo.length;
						}
						while (currentTime <= tiempoEnd);
						if (currentTime >= tiempoEnd)
						{
							break;
						}
					}
				}
			}
			target.mode = PuppetMaster.Mode.Active;
			target.blendTime = 1f;
			yield break;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x000136E7 File Offset: 0x000118E7
		private static IEnumerator DelayModeRutine(PuppetConfig.DelayedMode modeDel, PuppetMaster target, FemaleAnimController controller, PuppetConfig sender)
		{
			float startTime = Time.time;
			for (;;)
			{
				yield return null;
				if (Time.time - startTime > 10f)
				{
					break;
				}
				if (controller.character.bodyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
				{
					goto IL_008A;
				}
			}
			Debug.LogError("AnimatorStateInfo was never completed");
			IL_008A:
			float dalayStartTime = Time.time;
			bool flag;
			do
			{
				yield return null;
				flag = Time.time - dalayStartTime > modeDel.startTime * 0.333f;
			}
			while (!flag);
			if (target != null)
			{
				target.mode = modeDel.mode;
				target.blendTime = modeDel.blendTime * 0.333f;
			}
			yield break;
		}

		// Token: 0x040002A6 RID: 678
		[LargeHeader("Simulation")]
		public PuppetMaster.State state;

		// Token: 0x040002A7 RID: 679
		public PuppetMaster.StateSettings stateSettings = PuppetMaster.StateSettings.Default;

		// Token: 0x040002A8 RID: 680
		public PuppetConfig.Mode startMode = new PuppetConfig.Mode();

		// Token: 0x040002A9 RID: 681
		public List<PuppetConfig.DelayedMode> delayedMode = new List<PuppetConfig.DelayedMode>();

		// Token: 0x040002AA RID: 682
		[Obsolete]
		[NonSerialized]
		public PuppetMaster.Mode mode;

		// Token: 0x040002AB RID: 683
		[Obsolete]
		[NonSerialized]
		public float blendTime = 0.1f;

		// Token: 0x040002AC RID: 684
		[Obsolete]
		[NonSerialized]
		public PuppetMaster.Mode endMode;

		// Token: 0x040002AD RID: 685
		[Obsolete]
		[NonSerialized]
		public float endModeLoadDelay;

		// Token: 0x040002AE RID: 686
		public bool fixTargetTransforms = true;

		// Token: 0x040002AF RID: 687
		public int solverIterationCount = 6;

		// Token: 0x040002B0 RID: 688
		[Obsolete]
		[NonSerialized]
		public bool visualizeTargetPose;

		// Token: 0x040002B1 RID: 689
		[LargeHeader("Master Weights")]
		[Range(0f, 1f)]
		public float mappingWeight = 1f;

		// Token: 0x040002B2 RID: 690
		[Range(0f, 1f)]
		public float pinWeight = 1f;

		// Token: 0x040002B3 RID: 691
		[Range(0f, 1f)]
		public float muscleWeight = 1f;

		// Token: 0x040002B4 RID: 692
		[LargeHeader("Joint and Muscle Settings")]
		public float muscleSpring = 100f;

		// Token: 0x040002B5 RID: 693
		public float muscleDamper;

		// Token: 0x040002B6 RID: 694
		[Range(1f, 8f)]
		public float pinPow = 4f;

		// Token: 0x040002B7 RID: 695
		[Range(0f, 100f)]
		public float pinDistanceFalloff = 5f;

		// Token: 0x040002B8 RID: 696
		public bool updateJointAnchors = true;

		// Token: 0x040002B9 RID: 697
		public bool angularLimits;

		// Token: 0x040002BA RID: 698
		public bool internalCollisions;

		// Token: 0x040002BB RID: 699
		[NonSerialized]
		public bool flagPuppetModoPorAnimatorState;

		// Token: 0x0200015D RID: 349
		[Serializable]
		public class Mode
		{
			// Token: 0x040007EA RID: 2026
			public PuppetMaster.Mode mode;

			// Token: 0x040007EB RID: 2027
			public float blendTime = 0.1f;
		}

		// Token: 0x0200015E RID: 350
		[Serializable]
		public class DelayedMode : PuppetConfig.Mode
		{
			// Token: 0x040007EC RID: 2028
			public float startTime;
		}
	}
}
