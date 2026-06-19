using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Runtime.AI;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Interacciones
{
	// Token: 0x0200000D RID: 13
	[RequireComponent(typeof(InteraccionPrimariaBase))]
	public class PoseQueExponePartes : AplicableCustomMonobehaviour
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00003383 File Offset: 0x00001583
		public IReadOnlyList<ParteDelCuerpoHumano> exponiendoPartes
		{
			get
			{
				return this.m_exponiendoPartes;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000338B File Offset: 0x0000158B
		public IReadOnlyCollection<int> exponiendoPartesSet
		{
			get
			{
				return this.m_lastExponiendoPartesSet;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00003393 File Offset: 0x00001593
		public IReadOnlyList<Side> exponiendoSides
		{
			get
			{
				return this.m_exponiendoSides;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000339B File Offset: 0x0000159B
		public Transform poseRoot
		{
			get
			{
				return this.m_interaccion.interactionRootBone;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000033A8 File Offset: 0x000015A8
		public Transform poseHips
		{
			get
			{
				return this.m_poseHips;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000033B0 File Offset: 0x000015B0
		public Transform poseSpine
		{
			get
			{
				return this.m_poseSpine;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000033B8 File Offset: 0x000015B8
		public Transform poseChest
		{
			get
			{
				return this.m_poseChest;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000033C0 File Offset: 0x000015C0
		public Transform poseHombroL
		{
			get
			{
				return this.m_poseHombroL;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000033C8 File Offset: 0x000015C8
		public Transform poseHombroR
		{
			get
			{
				return this.m_poseHombroR;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000033D0 File Offset: 0x000015D0
		public Transform poseBrazoL
		{
			get
			{
				return this.m_poseBrazoL;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000033D8 File Offset: 0x000015D8
		public Transform poseBrazoR
		{
			get
			{
				return this.m_poseBrazoR;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000033E0 File Offset: 0x000015E0
		public Transform posePiernaL
		{
			get
			{
				return this.m_posePiernaL;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000033E8 File Offset: 0x000015E8
		public Transform posePiernaR
		{
			get
			{
				return this.m_posePiernaR;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000049 RID: 73 RVA: 0x000033F0 File Offset: 0x000015F0
		// (remove) Token: 0x0600004A RID: 74 RVA: 0x00003428 File Offset: 0x00001628
		public event Action<ParteDelCuerpoHumano, PoseQueExponePartes> onNuevaParteExpuesta;

		// Token: 0x0600004B RID: 75 RVA: 0x00003460 File Offset: 0x00001660
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_interaccion = base.GetComponent<InteraccionPrimariaBase>();
			if (this.m_interaccion.owner == null)
			{
				base.SetInicializable();
				base.SetManualStart();
				this.m_interaccion.addedTo += this.M_interaccion_addedTo;
				return;
			}
			base.SetInicializable();
			base.SetManualStart();
			this.m_interaccion.owner.character.stared += this.Character_stared;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000034E0 File Offset: 0x000016E0
		private void M_interaccion_addedTo(Interaccion arg1, IInteraccionesDeCharacter arg2)
		{
			this.m_interaccion.addedTo -= this.M_interaccion_addedTo;
			if (!this.m_interaccion.owner.character.isStared)
			{
				this.m_interaccion.owner.character.stared += this.Character_stared;
				return;
			}
			this.Character_stared(this.m_interaccion.owner.character);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003553 File Offset: 0x00001753
		private void Character_stared(object sender)
		{
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003564 File Offset: 0x00001764
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			IInteraccionesDeCharacter owner = this.m_interaccion.owner;
			ExponiendoPartesSegunCurrentPose exponiendoPartesSegunCurrentPose;
			if (owner == null)
			{
				exponiendoPartesSegunCurrentPose = null;
			}
			else
			{
				ICharacter character = owner.character;
				exponiendoPartesSegunCurrentPose = ((character != null) ? character.GetComponentEnRoot<ExponiendoPartesSegunCurrentPose>() : null);
			}
			this.m_ExponiendoPartesSegunCurrentPose = exponiendoPartesSegunCurrentPose;
			if (this.m_ExponiendoPartesSegunCurrentPose == null)
			{
				throw new ArgumentNullException("m_cm_ExponiendoPartesSegunCurrentPoseharacter", "m_ExponiendoPartesSegunCurrentPose null reference.");
			}
			IInteraccionesDeCharacter owner2 = this.m_interaccion.owner;
			ICharacter character2 = ((owner2 != null) ? owner2.character : null);
			if (character2 == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			Animator bodyAnimator = character2.bodyAnimator;
			IFemaleChar femaleChar = (IFemaleChar)character2;
			Transform boneTransform = bodyAnimator.GetBoneTransform(HumanBodyBones.Hips);
			Transform boneTransform2 = bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
			this.m_poseVagLocalPositionOffset = boneTransform.InverseTransformPoint(femaleChar.vagHole.entrada.position);
			this.m_poseVagLocalForward = boneTransform.InverseTransformDirection(femaleChar.vagHole.worldOutHoleDirection);
			this.m_poseAnusLocalPositionOffset = boneTransform.InverseTransformPoint(femaleChar.anusHole.entrada.position);
			this.m_poseAnusLocalForward = boneTransform.InverseTransformDirection(femaleChar.anusHole.worldOutHoleDirection);
			this.m_poseBocaLocalPositionOffset = boneTransform2.InverseTransformPoint(femaleChar.bocaHole.entrada.position);
			this.m_poseBocaLocalForward = boneTransform2.InverseTransformDirection(femaleChar.bocaHole.worldOutHoleDirection);
			this.m_poseHips = this.m_interaccion.interactionRootBone.FindDeepChild(boneTransform.name, true);
			this.m_poseSpine = this.m_interaccion.interactionRootBone.FindDeepChild(bodyAnimator.GetBoneTransform(HumanBodyBones.Spine).name, true);
			this.m_poseChest = this.m_interaccion.interactionRootBone.FindDeepChild(bodyAnimator.GetBoneTransform(HumanBodyBones.Chest).name, true);
			this.m_poseHombroL = this.m_interaccion.interactionRootBone.FindDeepChild(bodyAnimator.GetBoneTransform(HumanBodyBones.LeftShoulder).name, true);
			this.m_poseHombroR = this.m_interaccion.interactionRootBone.FindDeepChild(bodyAnimator.GetBoneTransform(HumanBodyBones.RightShoulder).name, true);
			this.m_poseBrazoL = this.m_interaccion.interactionRootBone.FindDeepChild(bodyAnimator.GetBoneTransform(HumanBodyBones.LeftUpperArm).name, true);
			this.m_poseBrazoR = this.m_interaccion.interactionRootBone.FindDeepChild(bodyAnimator.GetBoneTransform(HumanBodyBones.RightUpperArm).name, true);
			this.m_posePiernaL = this.m_interaccion.interactionRootBone.FindDeepChild(bodyAnimator.GetBoneTransform(HumanBodyBones.LeftUpperLeg).name, true);
			this.m_posePiernaR = this.m_interaccion.interactionRootBone.FindDeepChild(bodyAnimator.GetBoneTransform(HumanBodyBones.RightUpperLeg).name, true);
			this.m_poseHead = this.m_interaccion.interactionRootBone.FindDeepChild(boneTransform2.name, true);
			this.m_pose.hips = new ExponiendoPartesSegunCurrentPose.BonePose
			{
				bone = this.m_poseHips,
				medidoDesde = this.m_poseSpine
			};
			this.m_pose.chest = new ExponiendoPartesSegunCurrentPose.BonePose
			{
				bone = this.m_poseChest,
				medidoDesde = this.m_poseSpine
			};
			this.m_pose.head = new ExponiendoPartesSegunCurrentPose.BonePose
			{
				bone = this.m_poseHead,
				medidoDesde = this.m_poseChest
			};
			this.m_pose.hombroL = new ExponiendoPartesSegunCurrentPose.BonePose
			{
				bone = this.m_poseHombroL,
				medidoDesde = this.m_poseChest
			};
			this.m_pose.hombroR = new ExponiendoPartesSegunCurrentPose.BonePose
			{
				bone = this.m_poseHombroR,
				medidoDesde = this.m_poseChest
			};
			this.m_pose.brazoL = new ExponiendoPartesSegunCurrentPose.BonePose
			{
				bone = this.m_poseBrazoL,
				medidoDesde = this.m_poseChest
			};
			this.m_pose.brazoR = new ExponiendoPartesSegunCurrentPose.BonePose
			{
				bone = this.m_poseBrazoR,
				medidoDesde = this.m_poseChest
			};
			this.m_pose.piernaL = new ExponiendoPartesSegunCurrentPose.BonePose
			{
				bone = this.m_posePiernaL,
				medidoDesde = this.m_poseHips
			};
			this.m_pose.piernaR = new ExponiendoPartesSegunCurrentPose.BonePose
			{
				bone = this.m_posePiernaR,
				medidoDesde = this.m_poseHips
			};
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000395D File Offset: 0x00001B5D
		public ExponiendoPartesSegunCurrentPose.Poses ObtenerCurrentPoses()
		{
			this.UpdatePose();
			return this.m_pose;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000396B File Offset: 0x00001B6B
		public ExponiendoPartesSegunCurrentPose.Poses ObtenerFinalPoses()
		{
			this.UpdatePoseFromAnimatedIKConstrainedPose();
			return this.m_pose;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000397C File Offset: 0x00001B7C
		public void UpdatePoseFromAnimatedIKConstrainedPose()
		{
			if (!base.isStared)
			{
				throw new InvalidOperationException("exponiendo partes de interaccion: " + base.name + ", no ha inicializado");
			}
			IInteraccionesDeCharacter owner = this.m_interaccion.owner;
			AnimatorCharacter animatorCharacter = ((owner != null) ? owner.character : null) as AnimatorCharacter;
			if (animatorCharacter == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_pose.hips.UpdateFromPose(animatorCharacter.bones.spine.localToWorldFinal, animatorCharacter.bones.spine.rotacionFinal, animatorCharacter.bones.hips.posicionFinal, animatorCharacter.bones.hips.rotacionFinal);
			this.m_pose.chest.UpdateFromPose(animatorCharacter.bones.spine.localToWorldFinal, animatorCharacter.bones.spine.rotacionFinal, animatorCharacter.bones.hips.posicionFinal, animatorCharacter.bones.hips.rotacionFinal);
			this.m_pose.hombroL.UpdateFromPose(animatorCharacter.bones.chest.localToWorldFinal, animatorCharacter.bones.chest.rotacionFinal, animatorCharacter.bones.shoulderL.posicionFinal, animatorCharacter.bones.shoulderL.rotacionFinal);
			this.m_pose.hombroR.UpdateFromPose(animatorCharacter.bones.chest.localToWorldFinal, animatorCharacter.bones.chest.rotacionFinal, animatorCharacter.bones.shoulderR.posicionFinal, animatorCharacter.bones.shoulderR.rotacionFinal);
			this.m_pose.brazoL.UpdateFromPose(animatorCharacter.bones.chest.localToWorldFinal, animatorCharacter.bones.chest.rotacionFinal, animatorCharacter.bones.armsL.posicionFinal, animatorCharacter.bones.armsL.rotacionFinal);
			this.m_pose.brazoR.UpdateFromPose(animatorCharacter.bones.chest.localToWorldFinal, animatorCharacter.bones.chest.rotacionFinal, animatorCharacter.bones.armsR.posicionFinal, animatorCharacter.bones.armsR.rotacionFinal);
			this.m_pose.piernaL.UpdateFromPose(animatorCharacter.bones.hips.localToWorldFinal, animatorCharacter.bones.hips.rotacionFinal, animatorCharacter.bones.legL.posicionFinal, animatorCharacter.bones.legL.rotacionFinal);
			this.m_pose.piernaR.UpdateFromPose(animatorCharacter.bones.hips.localToWorldFinal, animatorCharacter.bones.hips.rotacionFinal, animatorCharacter.bones.legR.posicionFinal, animatorCharacter.bones.legR.rotacionFinal);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003C64 File Offset: 0x00001E64
		public void UpdatePose()
		{
			if (!base.isStared)
			{
				throw new InvalidOperationException("exponiendo partes de interaccion: " + base.name + ", no ha inicializado");
			}
			this.m_pose.hips.Update();
			this.m_pose.chest.Update();
			this.m_pose.hombroL.Update();
			this.m_pose.hombroR.Update();
			this.m_pose.brazoL.Update();
			this.m_pose.brazoR.Update();
			this.m_pose.piernaL.Update();
			this.m_pose.piernaR.Update();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003D14 File Offset: 0x00001F14
		public void UpdateCurrentExposingPartes()
		{
			this.UpdatePose();
			this.LoadListaDePartesExpuesta();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003D22 File Offset: 0x00001F22
		public void UpdateFinalExposingPartes()
		{
			this.UpdatePoseFromAnimatedIKConstrainedPose();
			this.LoadListaDePartesExpuesta();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003D30 File Offset: 0x00001F30
		private void LoadListaDePartesExpuesta()
		{
			Character character = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character;
			float escala = this.m_interaccion.owner.character.escala;
			float escala2 = character.escala;
			Vector3 localScale = this.m_interaccion.interactionRootBone.localScale;
			this.m_interaccion.interactionRootBone.localScale = Vector3.one * escala;
			try
			{
				this.m_exponiendoPartes.Clear();
				this.m_exponiendoSides.Clear();
				Vector3 posicion = this.m_interaccion.owner.character.posicion;
				Vector3 vector = this.m_interaccion.owner.character.rotacion * Vector3.up;
				Vector3 posicion2 = character.posicion;
				Vector3 vector2 = character.rotacion * Vector3.up;
				Vector3 vector3 = (posicion + posicion2) / 2f;
				Vector3 normalized = (vector + vector2).normalized;
				bool flag;
				bool flag2;
				bool flag3;
				bool flag4;
				this.EstaExponiendoAnoVaginaNalgas(escala, escala2, vector3, normalized, out flag, out flag2, out flag3, out flag4);
				if (flag)
				{
					this.m_exponiendoPartes.Add(ParteDelCuerpoHumano.ano);
					this.m_exponiendoSides.Add(Side.none);
				}
				if (flag2)
				{
					this.m_exponiendoPartes.Add(ParteDelCuerpoHumano.vag);
					this.m_exponiendoSides.Add(Side.none);
				}
				if (flag3)
				{
					this.m_exponiendoPartes.Add(ParteDelCuerpoHumano.nalgas);
					this.m_exponiendoSides.Add(Side.L);
				}
				if (flag4)
				{
					this.m_exponiendoPartes.Add(ParteDelCuerpoHumano.nalgas);
					this.m_exponiendoSides.Add(Side.R);
				}
				if (this.EstaExponiendoSenos(escala, vector3, normalized))
				{
					this.m_exponiendoPartes.Add(ParteDelCuerpoHumano.senos);
					this.m_exponiendoSides.Add(Side.L);
					this.m_exponiendoPartes.Add(ParteDelCuerpoHumano.senos);
					this.m_exponiendoSides.Add(Side.R);
				}
				bool flag5;
				bool flag6;
				this.EstaExponiendoAxilas(escala, vector3, normalized, out flag5, out flag6);
				if (flag5)
				{
					this.m_exponiendoPartes.Add(ParteDelCuerpoHumano.axilas);
					this.m_exponiendoSides.Add(Side.L);
				}
				if (flag6)
				{
					this.m_exponiendoPartes.Add(ParteDelCuerpoHumano.axilas);
					this.m_exponiendoSides.Add(Side.R);
				}
				if (this.EstaExponiendoBoca(escala, escala2, vector3, normalized))
				{
					this.m_exponiendoPartes.Add(ParteDelCuerpoHumano.bocaInterno);
					this.m_exponiendoSides.Add(Side.none);
				}
			}
			finally
			{
				this.m_interaccion.interactionRootBone.localScale = localScale;
				for (int i = 0; i < this.m_exponiendoPartes.Count; i++)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = this.m_exponiendoPartes[i];
					if (this.m_lastExponiendoPartesSet.Add((int)parteDelCuerpoHumano))
					{
						this.OnNuevaParteExpuesta(parteDelCuerpoHumano);
					}
				}
				this.m_lastExponiendoPartesSet.Clear();
				for (int j = 0; j < this.m_exponiendoPartes.Count; j++)
				{
					this.m_lastExponiendoPartesSet.Add((int)this.m_exponiendoPartes[j]);
				}
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004008 File Offset: 0x00002208
		private void OnNuevaParteExpuesta(ParteDelCuerpoHumano parte)
		{
			Action<ParteDelCuerpoHumano, PoseQueExponePartes> action = this.onNuevaParteExpuesta;
			if (action == null)
			{
				return;
			}
			action(parte, this);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000401C File Offset: 0x0000221C
		private void EstaExponiendoAnoVaginaNalgas(float scalaFemale, float scalaMale, Vector3 sueloPoint, Vector3 sueloNormal, out bool expuestaAno, out bool expuestaVagina, out bool expuestaNalgaL, out bool expuestaNalgaR)
		{
			Vector3 vector = this.m_poseHips.TransformDirection(this.m_poseVagLocalForward);
			Vector3 vector2 = this.m_poseHips.TransformDirection(this.m_poseAnusLocalForward);
			Vector3 vector3 = this.m_poseHips.TransformPoint(this.m_poseAnusLocalPositionOffset);
			Vector3 vector4 = Math3d.ProjectPointOnPlane(sueloNormal, sueloPoint, vector3);
			float num = Vector3.Distance(vector3, vector4);
			Vector3 vector5 = this.m_poseHips.TransformDirection(-this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.hips.spaceForward);
			Vector3 normalized = Physics.gravity.normalized;
			bool flag = Vector3.Angle(vector, normalized) > PoseQueExponePartes.ConfigDeAngles.angleMinAgaintsGravityToExposeHole;
			bool flag2 = Vector3.Angle(vector2, normalized) > PoseQueExponePartes.ConfigDeAngles.angleMinAgaintsGravityToExposeHole;
			bool flag3 = Vector3.Angle(vector5, -normalized) < PoseQueExponePartes.ConfigDeAngles.angleAgaintsNegativeGravityToExposeNalga;
			bool flag4 = flag3 || num > PoseQueExponePartes.ConfigDeAngles.alturaMinParaPoderExponerNalgas;
			Vector3 vector6 = this.m_pose.piernaL.localRotation * Vector3.forward;
			Vector3 vector7 = this.m_pose.piernaR.localRotation * Vector3.forward;
			Vector3 vector8 = this.m_pose.hips.localRotation * Vector3.forward;
			Vector3 vector9 = this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaL.localRotation * Vector3.forward;
			Vector3 vector10 = this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaR.localRotation * Vector3.forward;
			Vector3 vector11 = this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.hips.localRotation * Vector3.forward;
			Vector3 vector12 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaL.spaceForward, vector6);
			Vector3 vector13 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaR.spaceForward, vector7);
			Vector3 vector14 = Math3d.ProjectVectorOnPlane(-this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaL.spaceRight, vector6);
			Vector3 vector15 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaR.spaceRight, vector7);
			Vector3 vector16 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.hips.spaceRight, vector8);
			Vector3 vector17 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaL.spaceForward, vector9);
			Vector3 vector18 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaR.spaceForward, vector10);
			Vector3 vector19 = Math3d.ProjectVectorOnPlane(-this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaL.spaceRight, vector9);
			Vector3 vector20 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaR.spaceRight, vector10);
			Vector3 vector21 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.hips.spaceRight, vector11);
			float num2 = Vector3.Angle(vector17, vector12);
			float num3 = Vector3.Angle(vector18, vector13);
			this.Polarizar(ref num2, vector12, -this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaL.rightNormal);
			this.Polarizar(ref num3, vector13, this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaR.rightNormal);
			float num4 = Vector3.Angle(vector19, vector14);
			float num5 = Vector3.Angle(vector20, vector15);
			this.Polarizar(ref num4, vector14, this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaL.forwardNormal);
			this.Polarizar(ref num5, vector15, this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.piernaR.forwardNormal);
			float num6 = Vector3.Angle(vector21, vector16);
			this.Polarizar(ref num6, vector16, this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.hips.forwardNormal);
			expuestaAno = flag2 && Mathf.Max(0f, num4) + Mathf.Max(0f, num5) > PoseQueExponePartes.ConfigDeAngles.anguloConvinadoEnNormalRightDePiernasParaExponerAno;
			expuestaVagina = flag && Mathf.Max(0f, num4) + Mathf.Max(0f, num5) > PoseQueExponePartes.ConfigDeAngles.anguloConvinadoPositivoEnNormalRightDePiernasParaExponerVag;
			expuestaVagina = expuestaVagina || (flag && Mathf.Max(0f, num4 * -1f) + Mathf.Max(0f, num5 * -1f) > PoseQueExponePartes.ConfigDeAngles.anguloConvinadoNegativoEnNormalRightDePiernasParaExponerVag);
			expuestaVagina = expuestaVagina || Mathf.Max(0f, num2) + Mathf.Max(0f, num3) > PoseQueExponePartes.ConfigDeAngles.anguloConvinadoEnNormalForwardDePiernasParaExponerVag;
			if (flag4)
			{
				expuestaNalgaL = (expuestaNalgaR = flag3 || Mathf.Max(0f, num6) > PoseQueExponePartes.ConfigDeAngles.anguloEnNormalRightDePelvisParaExponerNalgas);
				expuestaNalgaL = expuestaNalgaL || Mathf.Max(0f, num4) > PoseQueExponePartes.ConfigDeAngles.anguloEnNormalRightDePiernasParaExponerNalgas;
				expuestaNalgaR = expuestaNalgaR || Mathf.Max(0f, num5) > PoseQueExponePartes.ConfigDeAngles.anguloEnNormalRightDePiernasParaExponerNalgas;
				return;
			}
			expuestaNalgaL = (expuestaNalgaR = false);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000044DC File Offset: 0x000026DC
		private void EstaExponiendoAxilas(float scalaFemale, Vector3 sueloPoint, Vector3 sueloNormal, out bool expuestaAxilaL, out bool expuestaAxilaR)
		{
			Vector3 vector = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.brazoL.spaceForward, this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.brazoL.localRotation * Vector3.forward);
			Vector3 vector2 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.brazoR.spaceForward, this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.brazoR.localRotation * Vector3.forward);
			Vector3 vector3 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.brazoL.spaceForward, this.m_pose.brazoL.localRotation * Vector3.forward);
			Vector3 vector4 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.brazoR.spaceForward, this.m_pose.brazoR.localRotation * Vector3.forward);
			float num = Vector3.Angle(vector, vector3);
			float num2 = Vector3.Angle(vector2, vector4);
			this.Polarizar(ref num, vector3, this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.brazoL.upNormal);
			this.Polarizar(ref num2, vector4, this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.brazoR.upNormal);
			expuestaAxilaL = num > PoseQueExponePartes.ConfigDeAngles.anguloEnNormalForwardParaExponerAxila;
			expuestaAxilaR = num2 > PoseQueExponePartes.ConfigDeAngles.anguloEnNormalForwardParaExponerAxila;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000462C File Offset: 0x0000282C
		private bool EstaExponiendoSenos(float scalaFemale, Vector3 sueloPoint, Vector3 sueloNormal)
		{
			Vector3 vector = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.chest.spaceRight, this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.chest.localRotation * Vector3.forward);
			Vector3 vector2 = Math3d.ProjectVectorOnPlane(this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.chest.spaceRight, this.m_pose.chest.localRotation * Vector3.forward);
			float num = Vector3.Angle(vector, vector2);
			this.Polarizar(ref num, vector2, -this.m_ExponiendoPartesSegunCurrentPose.posesIniciales.chest.forwardNormal);
			return num > PoseQueExponePartes.ConfigDeAngles.anguloEnNormalRightDeChestParaExponerSenos;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000046DC File Offset: 0x000028DC
		private bool EstaExponiendoBoca(float scalaFemale, float scalaMale, Vector3 sueloPoint, Vector3 sueloNormal)
		{
			Vector3 vector = this.m_poseHead.TransformPoint(this.m_poseBocaLocalPositionOffset);
			Vector3 vector2 = Math3d.ProjectPointOnPlane(sueloNormal, sueloPoint, vector);
			return Vector3.Distance(vector, vector2) * scalaMale < PoseQueExponePartes.ConfigDeAngles.alturaMaxParaPoderExponerBoca;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004715 File Offset: 0x00002915
		private void Polarizar(ref float value, Vector3 direccion, Vector3 normal)
		{
			if (Vector3.Dot(normal.normalized, direccion.normalized) < 0f)
			{
				value *= -1f;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000473B File Offset: 0x0000293B
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Actualizar Current Exponiendo Partes"
			};
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004754 File Offset: 0x00002954
		protected override void OnAplicar2()
		{
			this.UpdateCurrentExposingPartes();
		}

		// Token: 0x0400000F RID: 15
		private InteraccionPrimariaBase m_interaccion;

		// Token: 0x04000010 RID: 16
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_poseHips;

		// Token: 0x04000011 RID: 17
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_poseSpine;

		// Token: 0x04000012 RID: 18
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_poseChest;

		// Token: 0x04000013 RID: 19
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_poseHead;

		// Token: 0x04000014 RID: 20
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_poseHombroL;

		// Token: 0x04000015 RID: 21
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_poseHombroR;

		// Token: 0x04000016 RID: 22
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_poseBrazoL;

		// Token: 0x04000017 RID: 23
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_poseBrazoR;

		// Token: 0x04000018 RID: 24
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_posePiernaL;

		// Token: 0x04000019 RID: 25
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_posePiernaR;

		// Token: 0x0400001A RID: 26
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_poseVagLocalPositionOffset;

		// Token: 0x0400001B RID: 27
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_poseVagLocalForward;

		// Token: 0x0400001C RID: 28
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_poseAnusLocalPositionOffset;

		// Token: 0x0400001D RID: 29
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_poseAnusLocalForward;

		// Token: 0x0400001E RID: 30
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_poseBocaLocalPositionOffset;

		// Token: 0x0400001F RID: 31
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_poseBocaLocalForward;

		// Token: 0x04000020 RID: 32
		private ExponiendoPartesSegunCurrentPose.Poses m_pose = new ExponiendoPartesSegunCurrentPose.Poses();

		// Token: 0x04000021 RID: 33
		private ExponiendoPartesSegunCurrentPose m_ExponiendoPartesSegunCurrentPose;

		// Token: 0x04000022 RID: 34
		[SerializeField]
		private List<ParteDelCuerpoHumano> m_exponiendoPartes = new List<ParteDelCuerpoHumano>();

		// Token: 0x04000023 RID: 35
		private HashSet<int> m_lastExponiendoPartesSet = new HashSet<int>();

		// Token: 0x04000024 RID: 36
		[SerializeField]
		private List<Side> m_exponiendoSides = new List<Side>();

		// Token: 0x02000114 RID: 276
		public static class ConfigDeAngles
		{
			// Token: 0x0400067E RID: 1662
			public static float angleMinAgaintsGravityToExposeHole = 45f;

			// Token: 0x0400067F RID: 1663
			public static float angleAgaintsNegativeGravityToExposeNalga = 45f;

			// Token: 0x04000680 RID: 1664
			public static float alturaMaxParaPoderExponerBoca = 1.1f;

			// Token: 0x04000681 RID: 1665
			public static float alturaMinParaPoderExponerNalgas = 0.65f;

			// Token: 0x04000682 RID: 1666
			public static float anguloEnNormalForwardParaExponerAxila = 10f;

			// Token: 0x04000683 RID: 1667
			public static float anguloConvinadoEnNormalRightDePiernasParaExponerAno = 60f;

			// Token: 0x04000684 RID: 1668
			public static float anguloEnNormalRightDePiernasParaExponerNalgas = 45f;

			// Token: 0x04000685 RID: 1669
			public static float anguloEnNormalRightDePelvisParaExponerNalgas = 15f;

			// Token: 0x04000686 RID: 1670
			public static float anguloConvinadoPositivoEnNormalRightDePiernasParaExponerVag = 100f;

			// Token: 0x04000687 RID: 1671
			public static float anguloConvinadoNegativoEnNormalRightDePiernasParaExponerVag = 40f;

			// Token: 0x04000688 RID: 1672
			public static float anguloConvinadoEnNormalForwardDePiernasParaExponerVag = 40f;

			// Token: 0x04000689 RID: 1673
			public static float anguloEnNormalRightDeChestParaExponerSenos = 15f;
		}
	}
}
