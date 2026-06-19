using System;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Clases
{
	// Token: 0x0200005F RID: 95
	[Serializable]
	public class PuppetMusclesConfig : ConfiguracionParaTarget<PuppetMaster>
	{
		// Token: 0x06000402 RID: 1026 RVA: 0x000137D4 File Offset: 0x000119D4
		protected override void OnAplicarOnFemale(PuppetMaster target, FemaleAnimController controller)
		{
			Animator targetAnimator = target.targetAnimator;
			Muscle muscle = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.Hips);
			Muscle muscle2 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.Spine);
			Muscle muscle3 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.Chest);
			Muscle muscle4 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.Neck);
			Muscle muscle5 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.Head);
			Muscle muscle6 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.LeftShoulder);
			Muscle muscle7 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.RightShoulder);
			Muscle muscle8 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.LeftUpperArm);
			Muscle muscle9 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.RightUpperArm);
			Muscle muscle10 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.LeftLowerArm);
			Muscle muscle11 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.RightLowerArm);
			Muscle muscle12 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.LeftHand);
			Muscle muscle13 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.RightHand);
			Muscle muscle14 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.LeftUpperLeg);
			Muscle muscle15 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.RightUpperLeg);
			Muscle muscle16 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.LeftLowerLeg);
			Muscle muscle17 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.RightLowerLeg);
			Muscle muscle18 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.LeftFoot);
			Muscle muscle19 = PuppetMusclesConfig.Buscar(targetAnimator, target, HumanBodyBones.RightFoot);
			this.hips.AplicarOnFemale(muscle, controller);
			this.spine1.AplicarOnFemale(muscle2, controller);
			this.spine2.AplicarOnFemale(muscle3, controller);
			this.neck.AplicarOnFemale(muscle4, controller);
			this.head.AplicarOnFemale(muscle5, controller);
			this.shoulders.l.AplicarOnFemale(muscle6, controller);
			this.upperarms.l.AplicarOnFemale(muscle8, controller);
			this.forearms.l.AplicarOnFemale(muscle10, controller);
			this.hands.l.AplicarOnFemale(muscle12, controller);
			this.thighs.l.AplicarOnFemale(muscle14, controller);
			this.calfs.l.AplicarOnFemale(muscle16, controller);
			this.feets.l.AplicarOnFemale(muscle18, controller);
			this.shoulders.l.AplicarOnFemale(muscle7, controller);
			this.upperarms.r.AplicarOnFemale(muscle9, controller);
			this.forearms.r.AplicarOnFemale(muscle11, controller);
			this.hands.r.AplicarOnFemale(muscle13, controller);
			this.thighs.r.AplicarOnFemale(muscle15, controller);
			this.calfs.r.AplicarOnFemale(muscle17, controller);
			this.feets.r.AplicarOnFemale(muscle19, controller);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x000139F6 File Offset: 0x00011BF6
		public static Muscle Buscar(Animator animator, PuppetMaster target, HumanBodyBones bone)
		{
			Transform boneTransform = animator.GetBoneTransform(bone);
			if (boneTransform == null)
			{
				throw new ArgumentNullException("trans", "trans null reference.");
			}
			Muscle muscle = PuppetMusclesConfig.Buscar(boneTransform, target);
			if (muscle == null)
			{
				throw new ArgumentNullException("muscle", "muscle null reference.");
			}
			return muscle;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x00013A34 File Offset: 0x00011C34
		public static Muscle Buscar(Transform trans, PuppetMaster target)
		{
			foreach (Muscle muscle in target.muscles)
			{
				if (muscle.target == trans)
				{
					return muscle;
				}
			}
			return null;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00013A6C File Offset: 0x00011C6C
		public static Muscle Buscar(string transName, PuppetMaster target)
		{
			foreach (Muscle muscle in target.muscles)
			{
				if (muscle.target.name == transName)
				{
					return muscle;
				}
			}
			return null;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00013AA8 File Offset: 0x00011CA8
		public void CopiarDesde(PuppetMusclesConfig other)
		{
			this.hips.CopiarDesde(other.hips);
			this.spine1.CopiarDesde(other.spine1);
			this.spine2.CopiarDesde(other.spine2);
			this.neck.CopiarDesde(other.neck);
			this.head.CopiarDesde(other.head);
			this.thighs.CopiarDesde(other.thighs);
			this.calfs.CopiarDesde(other.calfs);
			this.feets.CopiarDesde(other.feets);
			this.shoulders.CopiarDesde(other.shoulders);
			this.upperarms.CopiarDesde(other.upperarms);
			this.forearms.CopiarDesde(other.forearms);
			this.hands.CopiarDesde(other.hands);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00013B84 File Offset: 0x00011D84
		public PuppetMuscleConfig Buscar(Muscle.GroupCompleto grupo, Side side)
		{
			switch (grupo)
			{
			case Muscle.GroupCompleto.Hips:
				return this.hips;
			case Muscle.GroupCompleto.Spine:
				return this.spine1;
			case Muscle.GroupCompleto.Head:
				return this.head;
			case Muscle.GroupCompleto.Arm:
				if (side == Side.L)
				{
					return this.upperarms.l;
				}
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				return this.upperarms.r;
			case Muscle.GroupCompleto.Hand:
				if (side == Side.L)
				{
					return this.hands.l;
				}
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				return this.hands.r;
			case Muscle.GroupCompleto.Leg:
				if (side == Side.L)
				{
					return this.thighs.l;
				}
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				return this.thighs.r;
			case Muscle.GroupCompleto.Foot:
				if (side == Side.L)
				{
					return this.feets.l;
				}
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				return this.feets.r;
			case Muscle.GroupCompleto.Neck:
				return this.neck;
			case Muscle.GroupCompleto.Chest:
				return this.spine2;
			case Muscle.GroupCompleto.ForeArm:
				if (side == Side.L)
				{
					return this.forearms.l;
				}
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				return this.forearms.r;
			case Muscle.GroupCompleto.Calf:
				if (side == Side.L)
				{
					return this.calfs.l;
				}
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				return this.calfs.r;
			case Muscle.GroupCompleto.Shoulder:
				if (side == Side.L)
				{
					return this.shoulders.l;
				}
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				return this.shoulders.r;
			}
			throw new ArgumentOutOfRangeException(grupo.ToString());
		}

		// Token: 0x040002BD RID: 701
		[Header("Spine")]
		public PuppetMuscleConfig hips = new PuppetMuscleConfig();

		// Token: 0x040002BE RID: 702
		public PuppetMuscleConfig spine1 = new PuppetMuscleConfig();

		// Token: 0x040002BF RID: 703
		public PuppetMuscleConfig spine2 = new PuppetMuscleConfig();

		// Token: 0x040002C0 RID: 704
		public PuppetMuscleConfig neck = new PuppetMuscleConfig();

		// Token: 0x040002C1 RID: 705
		public PuppetMuscleConfig head = new PuppetMuscleConfig();

		// Token: 0x040002C2 RID: 706
		[Header("Legs")]
		public PuppetMuscleConfigPar thighs = new PuppetMuscleConfigPar();

		// Token: 0x040002C3 RID: 707
		public PuppetMuscleConfigPar calfs = new PuppetMuscleConfigPar();

		// Token: 0x040002C4 RID: 708
		public PuppetMuscleConfigPar feets = new PuppetMuscleConfigPar();

		// Token: 0x040002C5 RID: 709
		[Header("Arms")]
		public PuppetMuscleConfigPar shoulders = new PuppetMuscleConfigPar();

		// Token: 0x040002C6 RID: 710
		public PuppetMuscleConfigPar upperarms = new PuppetMuscleConfigPar();

		// Token: 0x040002C7 RID: 711
		public PuppetMuscleConfigPar forearms = new PuppetMuscleConfigPar();

		// Token: 0x040002C8 RID: 712
		public PuppetMuscleConfigPar hands = new PuppetMuscleConfigPar();
	}
}
