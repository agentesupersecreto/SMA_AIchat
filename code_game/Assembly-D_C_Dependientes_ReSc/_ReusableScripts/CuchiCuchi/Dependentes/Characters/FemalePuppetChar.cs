using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x0200022B RID: 555
	public sealed class FemalePuppetChar : FemaleChar, IPuppetChar, IPuppetCharacter, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable, IFemaleCharacterIdleable, ICharacterIdleable
	{
		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x0003FC10 File Offset: 0x0003DE10
		public bool enAutoInteraccionCoitalHands
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.enAutoInteraccionCoitalHands;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000E50 RID: 3664 RVA: 0x0003FC1D File Offset: 0x0003DE1D
		public bool handsEsIdle
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.handsEsIdle;
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000E51 RID: 3665 RVA: 0x0003FC2A File Offset: 0x0003DE2A
		public bool headEsIdle
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.headEsIdle;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000E52 RID: 3666 RVA: 0x0003FC37 File Offset: 0x0003DE37
		public bool pelvisEsIdle
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.pelvisEsIdle;
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000E53 RID: 3667 RVA: 0x0003FC44 File Offset: 0x0003DE44
		public bool idle
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.idle;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000E54 RID: 3668 RVA: 0x0003FC51 File Offset: 0x0003DE51
		public float desarrollandoActividadPor
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.desarrollandoActividadPor;
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000E55 RID: 3669 RVA: 0x0003FC5E File Offset: 0x0003DE5E
		public float idlePor
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.idlePor;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000E56 RID: 3670 RVA: 0x0003FC6B File Offset: 0x0003DE6B
		public bool enAutoInteraccionCoital
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.enAutoInteraccionCoital;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000E57 RID: 3671 RVA: 0x0003FC78 File Offset: 0x0003DE78
		public bool enAutoInteraccionCoitalHead
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.enAutoInteraccionCoitalHead;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000E58 RID: 3672 RVA: 0x0003FC85 File Offset: 0x0003DE85
		public bool enAutoInteraccionCoitalHips
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.enAutoInteraccionCoitalHips;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000E59 RID: 3673 RVA: 0x0003FC92 File Offset: 0x0003DE92
		public bool enAutoInteraccion
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.enAutoInteraccion;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000E5A RID: 3674 RVA: 0x0003FC9F File Offset: 0x0003DE9F
		public bool enAutoInteraccionMassage
		{
			get
			{
				return this.m_FemalePuppetCharIdleable.enAutoInteraccionMassage;
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000E5B RID: 3675 RVA: 0x0003FCAC File Offset: 0x0003DEAC
		public override bool isAlive
		{
			get
			{
				return base.isAlive && this.m_PuppetMaster.state == PuppetMaster.State.Alive;
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000E5C RID: 3676 RVA: 0x0003FCC6 File Offset: 0x0003DEC6
		public HashSetList<Collider> puppetColliders
		{
			get
			{
				return this.m_puppetColliders;
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000E5D RID: 3677 RVA: 0x0003FCCE File Offset: 0x0003DECE
		public CharacterMuscles musculos
		{
			get
			{
				return this.m_Muscles;
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000E5E RID: 3678 RVA: 0x0003011F File Offset: 0x0002E31F
		public new AnimatorCharacter self
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000E5F RID: 3679 RVA: 0x00023ABA File Offset: 0x00021CBA
		public BehaviourPuppet puppetBehaviour
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000E60 RID: 3680 RVA: 0x0003011F File Offset: 0x0002E31F
		Character IPuppetChar.character
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x0003FCD8 File Offset: 0x0003DED8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PuppetMaster = base.transform.GetComponentInChildren<PuppetMaster>();
			this.m_ik = base.transform.GetComponentInChildren<FullBodyBipedIK>();
			if (this.m_PuppetMaster == null)
			{
				throw new ArgumentNullException("m_PuppetMaster", "m_PuppetMaster null reference.");
			}
			this.m_FemalePuppetCharIdleable = base.GetComponentNotNull<FemalePuppetCharIdleable>();
			PuppetMaster puppetMaster = this.m_PuppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPuppetPostInitiate));
			this.m_modContact = this.m_PuppetMaster.GetComponentNotNull<ModificadorDeMasaDeContactosUser>();
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x0003FD6F File Offset: 0x0003DF6F
		protected override void StartUnityEvent()
		{
			if (!this.m_PuppetMaster.initiated)
			{
				throw new NotSupportedException();
			}
			base.StartUnityEvent();
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x0003FD8C File Offset: 0x0003DF8C
		private void OnPuppetPostInitiate()
		{
			PuppetMaster puppetMaster = this.m_PuppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPuppetPostInitiate));
			this.m_Muscles.head = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.Head);
			this.m_Muscles.anteBrazoL = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.LeftLowerArm);
			this.m_Muscles.anteBrazoR = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.RightLowerArm);
			this.m_Muscles.brazoL = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.LeftUpperArm);
			this.m_Muscles.brazoR = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.RightUpperArm);
			this.m_Muscles.handL = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.LeftHand);
			this.m_Muscles.handR = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.RightHand);
			this.m_Muscles.piernaL = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.LeftUpperLeg);
			this.m_Muscles.piernaR = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.RightUpperLeg);
			this.m_Muscles.canillaL = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.LeftLowerLeg);
			this.m_Muscles.canillaR = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.RightLowerLeg);
			this.m_Muscles.pieL = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.LeftFoot);
			this.m_Muscles.pieR = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.RightFoot);
			this.m_Muscles.hips = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.Hips);
			this.m_Muscles.spine = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.Spine);
			this.m_Muscles.chest = this.m_PuppetMaster.GetMuscle(this.m_Animator, HumanBodyBones.Chest);
			try
			{
				foreach (Muscle muscle in this.m_PuppetMaster.muscles)
				{
					try
					{
						foreach (Collider collider in muscle.colliders)
						{
							this.m_puppetColliders.Add(collider);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
				this.m_modContact.InitializedIncluding(this.m_puppetColliders.Where((Collider col) => col.GetComponentInParent<ModificadorDeMasaDeContactosUser>() == this.m_modContact));
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}

		// Token: 0x06000E64 RID: 3684 RVA: 0x00040028 File Offset: 0x0003E228
		protected override void OnChangingPositionAndRotation(ref Vector3 posicion, ref Quaternion rotacion)
		{
			base.OnChangingPositionAndRotation(ref posicion, ref rotacion);
			this.m_lastMode = new PuppetMaster.Mode?(this.m_PuppetMaster.mode);
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x00040048 File Offset: 0x0003E248
		protected override void OnChangedPositionAndRotation(Vector3 posicion, Quaternion rotacion)
		{
			base.OnChangedPositionAndRotation(posicion, rotacion);
			this.m_PuppetMaster.transform.SetPositionAndRotation(posicion, rotacion);
			if (this.m_PuppetMaster.mode != PuppetMaster.Mode.Disabled)
			{
				this.m_PuppetMaster.KinimaticImmediately();
			}
			Muscle[] muscles = this.m_PuppetMaster.muscles;
			for (int i = 0; i < muscles.Length; i++)
			{
				muscles[i].ResetForces();
			}
			if (this.m_lastMode == null)
			{
				throw new ArgumentNullException("m_lastMode", "m_lastMode null reference.");
			}
			this.m_PuppetMaster.mode = this.m_lastMode.Value;
			this.m_lastMode = null;
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x000400E9 File Offset: 0x0003E2E9
		public override Rigidbody TryObtenerPartePhysica(HumanBodyBones boneEnum)
		{
			Muscle muscle = this.m_PuppetMaster.GetMuscle(boneEnum);
			if (muscle == null)
			{
				return null;
			}
			return muscle.rigidbody;
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x00040102 File Offset: 0x0003E302
		public override Rigidbody TryObtenerPartePhysica(Transform characterBone)
		{
			Muscle muscle = this.m_PuppetMaster.GetMuscle(characterBone);
			if (muscle == null)
			{
				return null;
			}
			return muscle.rigidbody;
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x0004011C File Offset: 0x0003E31C
		public sealed override bool ObjetoEsMiTorzo(Collider col)
		{
			return this.m_Muscles.hips.colliders.Contains(col) || this.m_Muscles.spine.colliders.Contains(col) || this.m_Muscles.chest.colliders.Contains(col) || this.m_Muscles.head.colliders.Contains(col) || this.m_Muscles.brazoL.colliders.Contains(col) || this.m_Muscles.brazoR.colliders.Contains(col) || base.ObjetoEsMiTorzo(col);
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x000401C4 File Offset: 0x0003E3C4
		public sealed override bool ObjetoEsMiTorzo(Rigidbody obj)
		{
			return this.m_Muscles.hips.rigidbody == obj || this.m_Muscles.spine.rigidbody == obj || this.m_Muscles.chest.rigidbody == obj || this.m_Muscles.head.rigidbody == obj || this.m_Muscles.brazoR.rigidbody == obj || this.m_Muscles.brazoL.rigidbody == obj || base.ObjetoEsMiTorzo(obj);
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x0004026C File Offset: 0x0003E46C
		public sealed override bool ObjetoEsMiTorzo(Transform obj)
		{
			return obj.IsChildOf(this.m_Muscles.hips.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.spine.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.chest.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.head.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.brazoL.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.brazoR.rigidbody.transform) || base.ObjetoEsMiTorzo(obj);
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00040334 File Offset: 0x0003E534
		public sealed override bool ObjetoEsMiPierna(Collider col)
		{
			return this.m_Muscles.piernaL.colliders.Contains(col) || this.m_Muscles.piernaR.colliders.Contains(col) || (this.m_Muscles.canillaL.colliders.Contains(col) || this.m_Muscles.canillaR.colliders.Contains(col)) || (this.m_Muscles.pieL.colliders.Contains(col) || this.m_Muscles.pieR.colliders.Contains(col)) || base.ObjetoEsMiPierna(col);
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x000403E0 File Offset: 0x0003E5E0
		public sealed override bool ObjetoEsMiPierna(Rigidbody obj)
		{
			return this.m_Muscles.piernaL.rigidbody == obj || this.m_Muscles.piernaR.rigidbody == obj || (this.m_Muscles.canillaL.rigidbody == obj || this.m_Muscles.canillaR.rigidbody == obj) || (this.m_Muscles.pieL.rigidbody == obj || this.m_Muscles.pieR.rigidbody == obj) || base.ObjetoEsMiPierna(obj);
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x0004048C File Offset: 0x0003E68C
		public sealed override bool ObjetoEsMiPierna(Transform obj)
		{
			return obj.IsChildOf(this.m_Muscles.piernaL.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.piernaR.rigidbody.transform) || (obj.IsChildOf(this.m_Muscles.canillaL.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.canillaR.rigidbody.transform)) || (obj.IsChildOf(this.m_Muscles.pieL.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.pieR.rigidbody.transform)) || base.ObjetoEsMiPierna(obj);
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x00040554 File Offset: 0x0003E754
		public sealed override bool ObjetoEsMiMano(Collider col)
		{
			return this.m_Muscles.handR.colliders.Contains(col) || this.m_Muscles.handL.colliders.Contains(col) || base.ObjetoEsMiMano(col);
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x0004058F File Offset: 0x0003E78F
		public sealed override bool ObjetoEsMiMano(Rigidbody rigid)
		{
			return this.m_Muscles.handR.rigidbody == rigid || this.m_Muscles.handL.rigidbody == rigid || base.ObjetoEsMiMano(rigid);
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x000405CC File Offset: 0x0003E7CC
		public sealed override bool ObjetoEsMiMano(Transform obj)
		{
			return obj.IsChildOf(this.m_Muscles.handR.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.handL.rigidbody.transform) || base.ObjetoEsMiMano(obj);
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x0004061C File Offset: 0x0003E81C
		public sealed override bool ObjetoEsMiAnteBrazo(Transform obj)
		{
			return obj.IsChildOf(this.m_Muscles.anteBrazoR.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.anteBrazoL.rigidbody.transform) || base.ObjetoEsMiAnteBrazo(obj);
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x0004066C File Offset: 0x0003E86C
		public override void IgnorarCollosionesConManos(Collider other, bool ignore)
		{
			base.IgnorarCollosionesConManos(other, ignore);
			ExtendedMonoBehaviour.IgnorarCollisiones(other, this.m_Muscles.handR.colliders, ignore);
			ExtendedMonoBehaviour.IgnorarCollisiones(other, this.m_Muscles.handL.colliders, ignore);
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x000406A4 File Offset: 0x0003E8A4
		public override void IgnorarCollosionesConMano(Collider other, Side side, bool ignore)
		{
			base.IgnorarCollosionesConMano(other, side, ignore);
			switch (side)
			{
			case Side.L:
				ExtendedMonoBehaviour.IgnorarCollisiones(other, this.m_Muscles.handL.colliders, ignore);
				return;
			case Side.R:
				ExtendedMonoBehaviour.IgnorarCollisiones(other, this.m_Muscles.handR.colliders, ignore);
				return;
			}
			throw new ArgumentOutOfRangeException(side.ToString());
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00040718 File Offset: 0x0003E918
		public sealed override void IgnoreCollisions(Collider other, bool ignore = true)
		{
			base.IgnoreCollisions(other, ignore);
			ExtendedMonoBehaviour.IgnorarCollisiones(other, this.m_puppetColliders, ignore);
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x0004072F File Offset: 0x0003E92F
		public sealed override void IgnoreCollisions(IList<Collider> others, bool ignore = true)
		{
			base.IgnoreCollisions(others, ignore);
			ExtendedMonoBehaviour.IgnorarCollisiones(others, this.m_puppetColliders, ignore);
		}

		// Token: 0x06000E76 RID: 3702 RVA: 0x00040748 File Offset: 0x0003E948
		public void GetCollidersHead(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.Head).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00040770 File Offset: 0x0003E970
		public void GetCollidersBrazoL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftUpperArm).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x00040798 File Offset: 0x0003E998
		public void GetCollidersBrazoR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightUpperArm).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x000407C0 File Offset: 0x0003E9C0
		public void GetCollidersAnteBrazoL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftLowerArm).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x000407E8 File Offset: 0x0003E9E8
		public void GetCollidersAnteBrazoR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightLowerArm).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x00040810 File Offset: 0x0003EA10
		public void GetCollidersHandL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftHand).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x00040838 File Offset: 0x0003EA38
		public void GetCollidersHandR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightHand).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E7D RID: 3709 RVA: 0x00040860 File Offset: 0x0003EA60
		public void GetCollidersPiernaL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftUpperLeg).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x00040888 File Offset: 0x0003EA88
		public void GetCollidersPiernaR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightUpperLeg).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x000408B0 File Offset: 0x0003EAB0
		public void GetCollidersCanillaL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftLowerLeg).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x000408D8 File Offset: 0x0003EAD8
		public void GetCollidersCanillaR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightLowerLeg).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x00040900 File Offset: 0x0003EB00
		public void GetCollidersPieL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftFoot).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E82 RID: 3714 RVA: 0x00040928 File Offset: 0x0003EB28
		public void GetCollidersPieR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightFoot).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x00040950 File Offset: 0x0003EB50
		public void GetCollidersHips(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.Hips).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x00040978 File Offset: 0x0003EB78
		public void GetCollidersSpine(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.Spine).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x000409A0 File Offset: 0x0003EBA0
		public void GetCollidersChest(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.Chest).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x000409C8 File Offset: 0x0003EBC8
		public float TryGetMuscleMass(HumanBodyBones humanBone, float defaultValue)
		{
			Muscle muscle = this.m_PuppetMaster.GetMuscle(humanBone);
			if (!(((muscle != null) ? muscle.rigidbody : null) == null))
			{
				return muscle.rigidbody.mass;
			}
			return defaultValue;
		}

		// Token: 0x040009E1 RID: 2529
		[Obsolete("", true)]
		public bool añadirRespiracion = true;

		// Token: 0x040009E2 RID: 2530
		private PuppetMaster m_PuppetMaster;

		// Token: 0x040009E3 RID: 2531
		private HashSetList<Collider> m_puppetColliders = new HashSetList<Collider>();

		// Token: 0x040009E4 RID: 2532
		private CharacterMuscles m_Muscles = new CharacterMuscles();

		// Token: 0x040009E5 RID: 2533
		private FullBodyBipedIK m_ik;

		// Token: 0x040009E6 RID: 2534
		private RespiracionDeIK m_respiracion;

		// Token: 0x040009E7 RID: 2535
		private FemalePuppetCharIdleable m_FemalePuppetCharIdleable;

		// Token: 0x040009E8 RID: 2536
		private ModificadorDeMasaDeContactosUser m_modContact;

		// Token: 0x040009E9 RID: 2537
		private PuppetMaster.Mode? m_lastMode;
	}
}
