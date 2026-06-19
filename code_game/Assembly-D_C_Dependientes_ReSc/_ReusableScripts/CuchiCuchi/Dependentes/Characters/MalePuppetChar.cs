using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts;
using com.ootii.Actors;
using com.ootii.Actors.AnimationControllers;
using RootMotion.Dynamics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters
{
	// Token: 0x0200022E RID: 558
	public sealed class MalePuppetChar : MaleChar, IPuppetChar, IPuppetCharacter, ICharacter, ICharacterRoot, IComponentStartable, IComponentAwakeable, ICharacterTeleportable, ICharacterControllerChar, IMaleCharacterIdleable, ICharacterIdleable, ICharacterConversador
	{
		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000E9F RID: 3743 RVA: 0x00040E17 File Offset: 0x0003F017
		public bool puedeConversar
		{
			get
			{
				return this.m_ICharacterConversador.puedeConversar;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000EA0 RID: 3744 RVA: 0x00040E24 File Offset: 0x0003F024
		public IReadOnlyList<ICharacterPuedeConversar> puedeConversarDelegados
		{
			get
			{
				return this.m_ICharacterConversador.puedeConversarDelegados;
			}
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x00040E31 File Offset: 0x0003F031
		public void UpdateDelegados()
		{
			this.m_ICharacterConversador.UpdateDelegados();
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x00040E3E File Offset: 0x0003F03E
		public bool TryConversarCon(string title, ICharacterUnico conversant)
		{
			return this.m_ICharacterConversador.TryConversarCon(title, conversant);
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x00040E4D File Offset: 0x0003F04D
		public bool TrySerConversarzado(string title, ICharacterUnico actor)
		{
			return this.m_ICharacterConversador.TrySerConversarzado(title, actor);
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000EA4 RID: 3748 RVA: 0x00040E5C File Offset: 0x0003F05C
		public bool estaConversando
		{
			get
			{
				return this.m_ICharacterConversador.estaConversando;
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000EA5 RID: 3749 RVA: 0x00040E69 File Offset: 0x0003F069
		public bool idle
		{
			get
			{
				return this.m_MalePuppetCharIdleable.idle;
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x00040E76 File Offset: 0x0003F076
		public float desarrollandoActividadPor
		{
			get
			{
				return this.m_MalePuppetCharIdleable.desarrollandoActividadPor;
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x00040E83 File Offset: 0x0003F083
		public float idlePor
		{
			get
			{
				return this.m_MalePuppetCharIdleable.idlePor;
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x00040E90 File Offset: 0x0003F090
		public bool handEsIdle
		{
			get
			{
				return this.m_MalePuppetCharIdleable.handEsIdle;
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000EA9 RID: 3753 RVA: 0x00040E9D File Offset: 0x0003F09D
		public bool pelvisEsIdle
		{
			get
			{
				return this.m_MalePuppetCharIdleable.pelvisEsIdle;
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000EAA RID: 3754 RVA: 0x00040EAA File Offset: 0x0003F0AA
		HashSetList<Collider> ICharacterControllerChar.characterControllerColliders
		{
			get
			{
				if (this.m_ActorControllerColliders.Count == 0)
				{
					this.UpdateActorControllerColliders();
				}
				return this.m_ActorControllerColliders;
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06000EAB RID: 3755 RVA: 0x00040EC5 File Offset: 0x0003F0C5
		public PuppetMaster puppetMaster
		{
			get
			{
				return this.m_PuppetMaster;
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000EAC RID: 3756 RVA: 0x00040ECD File Offset: 0x0003F0CD
		public CharacterMuscles musculos
		{
			get
			{
				return this.m_Muscles;
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000EAD RID: 3757 RVA: 0x0003011F File Offset: 0x0002E31F
		public AnimatorCharacter self
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000EAE RID: 3758 RVA: 0x00040ED5 File Offset: 0x0003F0D5
		public HashSetList<Collider> puppetColliders
		{
			get
			{
				return this.m_puppetColliders;
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000EAF RID: 3759 RVA: 0x00040EDD File Offset: 0x0003F0DD
		public BehaviourPuppet puppetBehaviour
		{
			get
			{
				return this.m_BehaviourPuppet;
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x0003011F File Offset: 0x0002E31F
		Character IPuppetChar.character
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000EB1 RID: 3761 RVA: 0x00040EE5 File Offset: 0x0003F0E5
		public Vector3 movingOnDirection
		{
			get
			{
				return this.m_ActorController.State.Velocity;
			}
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00040EF8 File Offset: 0x0003F0F8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ActorController = base.GetComponentInChildren<ActorController>();
			this.m_MotionController = base.GetComponentInChildren<MotionController>();
			this.m_PuppetMaster = base.transform.GetComponentInChildren<PuppetMaster>();
			this.m_BehaviourPuppet = base.transform.GetComponentInChildren<BehaviourPuppet>();
			this.m_MalePuppetCharIdleable = base.GetComponentNotNull<MalePuppetCharIdleable>();
			this.m_ICharacterConversador = (from c in base.GetComponentsInChildren<ICharacterConversador>()
				where c != this
				select c).FirstOrDefault<ICharacterConversador>();
			if (this.m_ICharacterConversador == null)
			{
				throw new ArgumentNullException("m_ICharacterConversador", "m_ICharacterConversador null reference.");
			}
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x00040F8C File Offset: 0x0003F18C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_PuppetExtraColliders = base.GetComponentInChildren<PuppetExtraColliders>();
			this.m_collidersToConvex = base.GetComponent<PuppetCollidersToConvexAdderV2>();
			this.m_collidersToPenis = base.GetComponent<PuppetCollidersToPenisAdder>();
			if (this.m_PuppetMaster == null)
			{
				throw new ArgumentNullException("m_PuppetMaster", "m_PuppetMaster null reference.");
			}
			this.m_penis = base.GetComponentInChildren<Penis>();
			if (this.m_PuppetMaster.initiated)
			{
				this.OnPuppetPostInitiate();
			}
			else
			{
				PuppetMaster puppetMaster = this.m_PuppetMaster;
				puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Combine(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPuppetPostInitiate));
			}
			if (this.m_PuppetExtraColliders.isStared)
			{
				this.OnExtraPuppetCollidersInitiate(this.m_PuppetExtraColliders);
				return;
			}
			this.m_PuppetExtraColliders.stared += this.OnExtraPuppetCollidersInitiate;
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x0004105A File Offset: 0x0003F25A
		protected override void OnAnimatorMove()
		{
			base.OnAnimatorMove();
			this.m_MotionController.rootMotionScale = this.escala;
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x00041073 File Offset: 0x0003F273
		protected override void OnChangingPositionAndRotation(ref Vector3 posicion, ref Quaternion rotacion)
		{
			base.OnChangingPositionAndRotation(ref posicion, ref rotacion);
			this.m_lastMode = new PuppetMaster.Mode?(this.m_PuppetMaster.mode);
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x00041094 File Offset: 0x0003F294
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

		// Token: 0x06000EB7 RID: 3767 RVA: 0x00041138 File Offset: 0x0003F338
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_ActorControllerColliders.Clear();
			ModificadorDeFloat[] modsAgaintsRagdolls = this.m_modsAgaintsRagdolls;
			if (modsAgaintsRagdolls == null)
			{
				return;
			}
			modsAgaintsRagdolls.ForEach(delegate(ModificadorDeFloat mod)
			{
				if (mod != null)
				{
					mod.TryRemoverDeOwner(true);
				}
			});
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x00041188 File Offset: 0x0003F388
		public void UpdateActorControllerColliders()
		{
			this.m_ActorControllerColliders.Clear();
			foreach (BodyShape bodyShape in this.m_ActorController.BodyShapes)
			{
				try
				{
					foreach (Collider collider in bodyShape.Colliders)
					{
						this.m_ActorControllerColliders.Add(collider);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x0004121C File Offset: 0x0003F41C
		private void OnExtraPuppetCollidersInitiate(object obj)
		{
			this.OnExtraPuppetCollidersInitiateFlag = true;
			if (this.OnPuppetPostInitiateFlag)
			{
				this.LoadPuppetColliders();
			}
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x00041234 File Offset: 0x0003F434
		private void OnPuppetPostInitiate()
		{
			PuppetMaster puppetMaster = this.m_PuppetMaster;
			puppetMaster.OnPostInitiate = (PuppetMaster.UpdateDelegate)Delegate.Remove(puppetMaster.OnPostInitiate, new PuppetMaster.UpdateDelegate(this.OnPuppetPostInitiate));
			this.OnPuppetPostInitiateFlag = true;
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
			if (this.OnExtraPuppetCollidersInitiateFlag)
			{
				this.LoadPuppetColliders();
			}
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00041454 File Offset: 0x0003F654
		private void LoadPuppetColliders()
		{
			try
			{
				this.m_modsContact = new ModificadorDeMasaDeContactosUser[this.m_PuppetMaster.muscles.Length];
				this.m_modsAgaintsRagdolls = new ModificadorDeFloat[this.m_PuppetMaster.muscles.Length];
				for (int i = 0; i < this.m_PuppetMaster.muscles.Length; i++)
				{
					Muscle muscle = this.m_PuppetMaster.muscles[i];
					ModificadorDeMasaDeContactosUser componentNotNull = muscle.rigidbody.GetComponentNotNull<ModificadorDeMasaDeContactosUser>();
					if (!componentNotNull.isInitiated)
					{
						componentNotNull.InitializedIncluding(muscle.rigidbody.GetComponent<Collider>());
					}
					ModificadorDeFloat modificadorDeFloat = componentNotNull.GetAgaintsLayerModificable(ConfiguracionGlobal.layersStatic.ragdoll).ObtenerModificadorNotNull(this);
					modificadorDeFloat.valor.valor = 0.3333f;
					this.m_modsContact[i] = componentNotNull;
					this.m_modsAgaintsRagdolls[i] = modificadorDeFloat;
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
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x00041570 File Offset: 0x0003F770
		public sealed override bool ObjetoEsMiTorzo(Collider col)
		{
			return (this.m_collidersToConvex.isActiveAndEnabled && (this.m_collidersToConvex.hipsCollider.collidersSet.Contains(col) || this.m_collidersToConvex.spine.collidersSet.Contains(col) || this.m_collidersToConvex.chest.collidersSet.Contains(col) || this.m_collidersToConvex.armL.collidersSet.Contains(col) || this.m_collidersToConvex.armR.collidersSet.Contains(col))) || (this.m_collidersToPenis.isActiveAndEnabled && this.m_collidersToPenis.hipsCollider.collidersSet.Contains(col)) || (this.m_Muscles.hips.colliders.Contains(col) || this.m_Muscles.spine.colliders.Contains(col) || this.m_Muscles.chest.colliders.Contains(col) || this.m_Muscles.head.colliders.Contains(col) || this.m_Muscles.brazoL.colliders.Contains(col) || this.m_Muscles.brazoR.colliders.Contains(col)) || base.ObjetoEsMiTorzo(col);
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x000416C4 File Offset: 0x0003F8C4
		public sealed override bool ObjetoEsMiTorzo(Rigidbody obj)
		{
			return (this.m_collidersToConvex.isActiveAndEnabled && (this.m_collidersToConvex.hipsCollider.dynamic == obj || this.m_collidersToConvex.spine.dynamic == obj || this.m_collidersToConvex.chest.dynamic == obj || this.m_collidersToConvex.armL.dynamic == obj || this.m_collidersToConvex.armR.dynamic == obj)) || (this.m_Muscles.hips.rigidbody == obj || this.m_Muscles.spine.rigidbody == obj || this.m_Muscles.chest.rigidbody == obj || this.m_Muscles.head.rigidbody == obj || this.m_Muscles.brazoR.rigidbody == obj || this.m_Muscles.brazoL.rigidbody == obj) || base.ObjetoEsMiTorzo(obj);
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x000417F4 File Offset: 0x0003F9F4
		public sealed override bool ObjetoEsMiTorzo(Transform obj)
		{
			return (this.m_collidersToConvex.isActiveAndEnabled && (obj.IsChildOf(this.m_collidersToConvex.hipsCollider.dynamic.transform) || obj.IsChildOf(this.m_collidersToConvex.spine.dynamic.transform) || obj.IsChildOf(this.m_collidersToConvex.chest.dynamic.transform) || obj.IsChildOf(this.m_collidersToConvex.armL.dynamic.transform) || obj.IsChildOf(this.m_collidersToConvex.armR.dynamic.transform))) || (this.m_collidersToPenis.isActiveAndEnabled && obj.IsChildOf(this.m_collidersToPenis.hipsCollider.transform)) || (obj.IsChildOf(this.m_Muscles.hips.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.spine.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.chest.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.head.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.brazoL.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.brazoR.rigidbody.transform)) || base.ObjetoEsMiTorzo(obj);
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x00041988 File Offset: 0x0003FB88
		public sealed override bool ObjetoEsMiPierna(Collider col)
		{
			if (this.m_collidersToConvex.isActiveAndEnabled)
			{
				if (this.m_collidersToConvex.piernaL.collidersSet.Contains(col))
				{
					return true;
				}
				if (this.m_collidersToConvex.piernaR.collidersSet.Contains(col))
				{
					return true;
				}
			}
			if (this.m_collidersToPenis.isActiveAndEnabled)
			{
				if (this.m_collidersToPenis.piernaL.collidersSet.Contains(col))
				{
					return true;
				}
				if (this.m_collidersToPenis.piernaR.collidersSet.Contains(col))
				{
					return true;
				}
			}
			return this.m_Muscles.piernaL.colliders.Contains(col) || this.m_Muscles.piernaR.colliders.Contains(col) || (this.m_Muscles.canillaL.colliders.Contains(col) || this.m_Muscles.canillaR.colliders.Contains(col)) || (this.m_Muscles.pieL.colliders.Contains(col) || this.m_Muscles.pieR.colliders.Contains(col)) || base.ObjetoEsMiPierna(col);
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00041AB4 File Offset: 0x0003FCB4
		public sealed override bool ObjetoEsMiPierna(Rigidbody obj)
		{
			if (this.m_collidersToConvex.isActiveAndEnabled)
			{
				if (this.m_collidersToConvex.piernaL.dynamic == obj)
				{
					return true;
				}
				if (this.m_collidersToConvex.piernaR.dynamic == obj)
				{
					return true;
				}
			}
			return this.m_Muscles.piernaL.rigidbody == obj || this.m_Muscles.piernaR.rigidbody == obj || (this.m_Muscles.canillaL.rigidbody == obj || this.m_Muscles.canillaR.rigidbody == obj) || (this.m_Muscles.pieL.rigidbody == obj || this.m_Muscles.pieR.rigidbody == obj) || base.ObjetoEsMiPierna(obj);
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00041BA0 File Offset: 0x0003FDA0
		public sealed override bool ObjetoEsMiPierna(Transform obj)
		{
			if (this.m_collidersToConvex.isActiveAndEnabled)
			{
				if (obj.IsChildOf(this.m_collidersToConvex.piernaL.dynamic.transform))
				{
					return true;
				}
				if (obj.IsChildOf(this.m_collidersToConvex.piernaR.dynamic.transform))
				{
					return true;
				}
			}
			if (this.m_collidersToPenis.isActiveAndEnabled)
			{
				if (obj.IsChildOf(this.m_collidersToPenis.piernaL.transform))
				{
					return true;
				}
				if (obj.IsChildOf(this.m_collidersToPenis.piernaR.transform))
				{
					return true;
				}
			}
			return obj.IsChildOf(this.m_Muscles.piernaL.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.piernaR.rigidbody.transform) || (obj.IsChildOf(this.m_Muscles.canillaL.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.canillaR.rigidbody.transform)) || (obj.IsChildOf(this.m_Muscles.pieL.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.pieR.rigidbody.transform)) || base.ObjetoEsMiPierna(obj);
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x00041CF4 File Offset: 0x0003FEF4
		public sealed override bool ObjetoEsMiMano(Collider col)
		{
			return this.m_PuppetExtraColliders.partes.handL.collidersSet.Contains(col) || this.m_PuppetExtraColliders.partes.handR.collidersSet.Contains(col) || (this.m_Muscles.handR.colliders.Contains(col) || this.m_Muscles.handL.colliders.Contains(col)) || base.ObjetoEsMiMano(col);
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x00041D76 File Offset: 0x0003FF76
		public sealed override bool ObjetoEsMiMano(Rigidbody rigid)
		{
			return this.m_Muscles.handR.rigidbody == rigid || this.m_Muscles.handL.rigidbody == rigid || base.ObjetoEsMiMano(rigid);
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x00041DB4 File Offset: 0x0003FFB4
		public sealed override bool ObjetoEsMiMano(Transform obj)
		{
			return obj.IsChildOf(this.m_Muscles.handR.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.handL.rigidbody.transform) || base.ObjetoEsMiMano(obj);
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x00041E04 File Offset: 0x00040004
		public sealed override bool ObjetoEsMiAnteBrazo(Transform obj)
		{
			return obj.IsChildOf(this.m_Muscles.anteBrazoR.rigidbody.transform) || obj.IsChildOf(this.m_Muscles.anteBrazoL.rigidbody.transform) || base.ObjetoEsMiAnteBrazo(obj);
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x00041E54 File Offset: 0x00040054
		public override void IgnorarCollosionesConManos(Collider other, bool ignore)
		{
			Muscle muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftHand);
			if (muscle != null)
			{
				muscle.IgnoreCollisions(other, ignore);
			}
			Muscle muscle2 = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightHand);
			if (muscle2 == null)
			{
				return;
			}
			muscle2.IgnoreCollisions(other, ignore);
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x00041E8C File Offset: 0x0004008C
		public override void IgnorarCollosionesConMano(Collider other, Side side, bool ignore)
		{
			switch (side)
			{
			case Side.L:
			{
				Muscle muscle = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftHand);
				if (muscle == null)
				{
					return;
				}
				muscle.IgnoreCollisions(other, ignore);
				return;
			}
			case Side.R:
			{
				Muscle muscle2 = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightHand);
				if (muscle2 == null)
				{
					return;
				}
				muscle2.IgnoreCollisions(other, ignore);
				return;
			}
			}
			throw new ArgumentOutOfRangeException(side.ToString());
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x00041EFB File Offset: 0x000400FB
		public override Rigidbody TryObtenerPartePhysica(HumanBodyBones boneEnum)
		{
			Muscle muscle = this.m_PuppetMaster.GetMuscle(boneEnum);
			if (muscle == null)
			{
				return null;
			}
			return muscle.rigidbody;
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x00041F14 File Offset: 0x00040114
		public override Rigidbody TryObtenerPartePhysica(Transform characterBone)
		{
			Muscle muscle = this.m_PuppetMaster.GetMuscle(characterBone);
			if (muscle == null)
			{
				return null;
			}
			return muscle.rigidbody;
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x00041F30 File Offset: 0x00040130
		public void GetCollidersHead(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.Head).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x00041F58 File Offset: 0x00040158
		public void GetCollidersBrazoL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftUpperArm).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x00041F80 File Offset: 0x00040180
		public void GetCollidersBrazoR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightUpperArm).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x00041FA8 File Offset: 0x000401A8
		public void GetCollidersAnteBrazoL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftLowerArm).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x00041FD0 File Offset: 0x000401D0
		public void GetCollidersAnteBrazoR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightLowerArm).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x00041FF8 File Offset: 0x000401F8
		public void GetCollidersHandL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftHand).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x00042020 File Offset: 0x00040220
		public void GetCollidersHandR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightHand).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x00042048 File Offset: 0x00040248
		public void GetCollidersPiernaL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftUpperLeg).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x00042070 File Offset: 0x00040270
		public void GetCollidersPiernaR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightUpperLeg).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x00042098 File Offset: 0x00040298
		public void GetCollidersCanillaL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftLowerLeg).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x000420C0 File Offset: 0x000402C0
		public void GetCollidersCanillaR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightLowerLeg).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x000420E8 File Offset: 0x000402E8
		public void GetCollidersPieL(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.LeftFoot).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x00042110 File Offset: 0x00040310
		public void GetCollidersPieR(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.RightFoot).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x00042138 File Offset: 0x00040338
		public void GetCollidersHips(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.Hips).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x00042160 File Offset: 0x00040360
		public void GetCollidersSpine(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.Spine).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x00042188 File Offset: 0x00040388
		public void GetCollidersChest(List<Collider> result)
		{
			Collider[] colliders = this.m_PuppetMaster.GetMuscle(HumanBodyBones.Chest).colliders;
			result.AddRange(colliders);
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x000421B0 File Offset: 0x000403B0
		public float TryGetMuscleMass(HumanBodyBones humanBone, float defaultValue)
		{
			Muscle muscle = this.m_PuppetMaster.GetMuscle(humanBone);
			if (!(((muscle != null) ? muscle.rigidbody : null) == null))
			{
				return muscle.rigidbody.mass;
			}
			return defaultValue;
		}

		// Token: 0x040009FB RID: 2555
		private Penis m_penis;

		// Token: 0x040009FC RID: 2556
		private CharacterMuscles m_Muscles = new CharacterMuscles();

		// Token: 0x040009FD RID: 2557
		private PuppetMaster m_PuppetMaster;

		// Token: 0x040009FE RID: 2558
		private BehaviourPuppet m_BehaviourPuppet;

		// Token: 0x040009FF RID: 2559
		private PuppetExtraColliders m_PuppetExtraColliders;

		// Token: 0x04000A00 RID: 2560
		private PuppetCollidersToConvexAdderV2 m_collidersToConvex;

		// Token: 0x04000A01 RID: 2561
		private PuppetCollidersToPenisAdder m_collidersToPenis;

		// Token: 0x04000A02 RID: 2562
		private HashSetList<Collider> m_puppetColliders = new HashSetList<Collider>();

		// Token: 0x04000A03 RID: 2563
		private HashSetList<Collider> m_ActorControllerColliders = new HashSetList<Collider>();

		// Token: 0x04000A04 RID: 2564
		private ActorController m_ActorController;

		// Token: 0x04000A05 RID: 2565
		private MotionController m_MotionController;

		// Token: 0x04000A06 RID: 2566
		private bool OnExtraPuppetCollidersInitiateFlag;

		// Token: 0x04000A07 RID: 2567
		private bool OnPuppetPostInitiateFlag;

		// Token: 0x04000A08 RID: 2568
		private MalePuppetCharIdleable m_MalePuppetCharIdleable;

		// Token: 0x04000A09 RID: 2569
		private ICharacterConversador m_ICharacterConversador;

		// Token: 0x04000A0A RID: 2570
		private PuppetMaster.Mode? m_lastMode;

		// Token: 0x04000A0B RID: 2571
		private ModificadorDeMasaDeContactosUser[] m_modsContact;

		// Token: 0x04000A0C RID: 2572
		private ModificadorDeFloat[] m_modsAgaintsRagdolls;
	}
}
