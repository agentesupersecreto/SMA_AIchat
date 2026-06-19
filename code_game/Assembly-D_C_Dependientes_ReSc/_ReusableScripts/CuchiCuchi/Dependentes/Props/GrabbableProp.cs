using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Props
{
	// Token: 0x0200014B RID: 331
	public class GrabbableProp : AplicableBehaviour, IGrabableProp, GuiaDeGrabbableProp.IHandler
	{
		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x00023ABA File Offset: 0x00021CBA
		public virtual Transform physcisRoot
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x00023ABD File Offset: 0x00021CBD
		public virtual Transform skeletonRoot
		{
			get
			{
				return this.m_root;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x00023AC5 File Offset: 0x00021CC5
		public virtual float worldLength
		{
			get
			{
				return this.m_root.localScale.Escala() * this.m_defaultLocalLargo;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x00023ADE File Offset: 0x00021CDE
		public InteractionTarget handRInteractionTarget
		{
			get
			{
				return this.m_handTargetR;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00023AE6 File Offset: 0x00021CE6
		// (set) Token: 0x06000685 RID: 1669 RVA: 0x00023AEE File Offset: 0x00021CEE
		public bool? alwaysFollowHandBoneOnGrabbedOverride { get; set; }

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000686 RID: 1670 RVA: 0x00023AF8 File Offset: 0x00021CF8
		// (remove) Token: 0x06000687 RID: 1671 RVA: 0x00023B30 File Offset: 0x00021D30
		public event GrabbableProp.OnStadoChangedHandler onStadoChanged;

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x00023B65 File Offset: 0x00021D65
		public GrabbablePropEstado estado
		{
			get
			{
				return this.m_Estado;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x00023B6D File Offset: 0x00021D6D
		public Side grabbedBySide
		{
			get
			{
				return this.m_GrabbedBySide;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600068A RID: 1674 RVA: 0x00023B75 File Offset: 0x00021D75
		public GameObject notGrabedPhysics
		{
			get
			{
				return this.m_DisabledRootPhyscis;
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00023B80 File Offset: 0x00021D80
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CheckForCharScaleCoroutine = new CoroutineCapsule(this.CheckForCharacterScaleRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
			if (this.m_root == null)
			{
				throw new ArgumentNullException("m_root", "m_root null reference.");
			}
			if (this.m_armatureRoot == null)
			{
				throw new ArgumentNullException("m_armatureRoot", "m_armatureRoot null reference.");
			}
			this.m_DisabledRootPhyscis.SetActive(false);
			this.m_EnabledExtraPhyscis.SetActive(false);
			this.m_DisabledRootPhyscis.SetActive(true);
			this.m_EnabledExtraPhyscis.SetActive(true);
			this.m_EnabledNotGrabbedExtraPhyscis.SetActive(true);
			this.m_EnabledNotGrabbedExtraPhyscis.SetActive(true);
			if (this.m_interaccionR == null)
			{
				throw new ArgumentNullException("m_interaccionR", "m_interaccionR null reference.");
			}
			if (this.m_EnabledExtraPhyscis == null)
			{
				throw new ArgumentNullException("m_afterGrabbing", "m_afterGrabbing null reference.");
			}
			if (this.m_DisabledRootPhyscis == null)
			{
				throw new ArgumentNullException("m_beforeGrabbing", "m_beforeGrabbing null reference.");
			}
			this.m_handTargetR = this.m_interaccionR.GetComponentInChildren<InteractionTarget>();
			this.m_handTargetPivotR = this.m_handTargetR.pivot;
			if (this.m_handTargetPivotR == null)
			{
				throw new ArgumentNullException("m_handTargetPivotR", "m_handTargetPivotR null reference.");
			}
			this.m_RootPositonFromPivotR = this.m_handTargetPivotR.InverseTransformPoint(this.m_root.position);
			this.m_RootRotationFromPivotR = Quaternion.Inverse(this.m_handTargetPivotR.rotation) * this.m_root.rotation;
			this.m_PivotRPositionFromRoot = this.m_root.InverseTransformPoint(this.m_handTargetPivotR.position);
			this.m_PivotRRotationFromRoot = Quaternion.Inverse(this.m_root.rotation) * this.m_handTargetPivotR.rotation;
			this.m_handRDefaultLocalPosition = this.m_handTargetR.transform.localPosition;
			this.m_handRDefaultLocalRotation = this.m_handTargetR.transform.localRotation;
			this.m_pivotRDefaultLocalPosition = this.m_handTargetR.transform.InverseTransformPoint(this.m_handTargetPivotR.position);
			this.m_pivotRDefaultLocalRotation = Quaternion.Inverse(this.m_handTargetR.transform.rotation) * this.m_handTargetPivotR.rotation;
			this.AwakeGrabbingLogic();
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00023DD8 File Offset: 0x00021FD8
		private void AwakeGrabbingLogic()
		{
			if (this.guiaPrefab == null)
			{
				throw new ArgumentNullException("guiaPrefab", "guiaPrefab null reference.");
			}
			if (this.m_guia == null)
			{
				throw new ArgumentNullException("m_guia", "m_guia null reference.");
			}
			Renderer component = this.guiaPrefab.GetComponent<Renderer>();
			this.m_guia.Init(this, component, this.m_guia.config, Singleton<DrawOnTopGuiasDeProps>.instance.drawOnTopOR.ObtenerModificadorNotNull(this.m_guia), new Transform[] { this.m_grabbingTrasfrom, this.m_grabbingTrasfrom });
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00023E72 File Offset: 0x00022072
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.Sub(this.m_interaccionR);
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00023E86 File Offset: 0x00022086
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.UnSubAndDetener(this.m_interaccionR);
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00023E9B File Offset: 0x0002209B
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.SetNotGrabbedHierarchy();
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00023EA9 File Offset: 0x000220A9
		private void Sub(InteraccionSegundariaBase inter)
		{
			this.UnSub(inter);
			inter.comenzada += this.M_interaccion_comenzada;
			inter.justAntesDeDetener += this.M_interaccion_justAntesDeDetener;
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00023ED6 File Offset: 0x000220D6
		private void UnSub(InteraccionSegundariaBase inter)
		{
			if (inter != null)
			{
				inter.comenzada -= this.M_interaccion_comenzada;
				inter.justAntesDeDetener -= this.M_interaccion_justAntesDeDetener;
			}
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00023F05 File Offset: 0x00022105
		private void UnSubAndDetener(InteraccionSegundariaBase inter)
		{
			if (inter != null)
			{
				this.UnSub(inter);
				if (inter.ejecutandose)
				{
					inter.Detener(true);
				}
			}
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00023F26 File Offset: 0x00022126
		private void M_interaccion_comenzada(Interaccion obj)
		{
			if (obj == this.m_interaccionR)
			{
				this.OnGrabedR(obj);
				return;
			}
			throw new NotImplementedException("falta desarrollar interaccion con mano izquierda");
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00023F48 File Offset: 0x00022148
		private void M_interaccion_justAntesDeDetener(Interaccion obj)
		{
			if (obj == this.m_interaccionR)
			{
				this.OnDropedR(obj);
				return;
			}
			throw new NotImplementedException("falta desarrollar interaccion con mano izquierda");
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00023F6A File Offset: 0x0002216A
		protected virtual void OnGrabedR(Interaccion obj)
		{
			this.SetGrabbedHierarchy(Side.R, obj, this.m_poserRtoationOffset, true, 0f, 1f);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00023F85 File Offset: 0x00022185
		protected virtual void OnGrabedL(Interaccion obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00023F8C File Offset: 0x0002218C
		protected virtual void OnDropedR(Interaccion obj)
		{
			this.SetNotGrabbedHierarchy();
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00023F85 File Offset: 0x00022185
		protected virtual void OnDropedL(Interaccion obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void Pre_SetNotGrabbedHierarchy()
		{
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void On_SetNotGrabbedHierarchy(Vector3 pos, Quaternion rot, Vector3 scale)
		{
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void Post_SetNotGrabbedHierarchy()
		{
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00023F94 File Offset: 0x00022194
		protected void SetNotGrabbedHierarchy()
		{
			this.m_GrabbedBySide = Side.none;
			this.UnSubAndDetener(this.m_interaccionR);
			this.Sub(this.m_interaccionR);
			this.DejarDeSostener();
			GlobalUpdater.Corrutina followBoneHandCorutina = this.m_followBoneHandCorutina;
			if (followBoneHandCorutina != null)
			{
				followBoneHandCorutina.Stop();
			}
			this.m_followBoneHandCorutina = null;
			GlobalUpdater.Corrutina followMuscleHadCorutina = this.m_FollowMuscleHadCorutina;
			if (followMuscleHadCorutina != null)
			{
				followMuscleHadCorutina.Stop();
			}
			this.m_FollowMuscleHadCorutina = null;
			GlobalUpdater.Corrutina followPoserOnGrabbingCorutina = this.m_followPoserOnGrabbingCorutina;
			if (followPoserOnGrabbingCorutina != null)
			{
				followPoserOnGrabbingCorutina.Stop();
			}
			this.m_followPoserOnGrabbingCorutina = null;
			GlobalUpdater.Corrutina trackHandModeCorutina = this.m_TrackHandModeCorutina;
			if (trackHandModeCorutina != null)
			{
				trackHandModeCorutina.Stop();
			}
			this.m_TrackHandModeCorutina = null;
			this.Pre_SetNotGrabbedHierarchy();
			Vector3 position = this.m_root.position;
			Quaternion rotation = this.m_root.rotation;
			Vector3 vector;
			if (!this.m_scaleWithMainCharacter)
			{
				vector = Vector3.one;
			}
			else
			{
				MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
				vector = ((((current != null) ? current.character : null) != null) ? CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.escala : 1f) * Vector3.one;
			}
			Vector3 vector2 = vector;
			this.m_EnabledExtraPhyscis.transform.parent = this.m_root;
			this.m_EnabledNotGrabbedExtraPhyscis.transform.parent = this.m_root;
			this.m_root.parent = base.transform;
			this.m_interaccionR.transform.parent = this.m_root;
			this.m_interaccionR.transform.SetPositionAndRotation(position, rotation);
			this.m_interaccionR.transform.localScale = Vector3.one * (1f / vector2.Escala());
			this.m_handTargetR.transform.SetLocalPositionAndRotation(this.m_handRDefaultLocalPosition, this.m_handRDefaultLocalRotation);
			this.m_handTargetPivotR.transform.SetPositionAndRotation(this.m_root.TransformPoint(this.m_PivotRPositionFromRoot), this.m_root.rotation * this.m_PivotRRotationFromRoot);
			this.m_handTargetPivotR.localScale = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.escala / this.m_interaccionR.transform.lossyScale.Escala() * Vector3.one;
			this.m_DisabledRootPhyscis.transform.parent = base.transform;
			this.m_DisabledRootPhyscis.transform.SetPositionAndRotation(position, rotation);
			this.m_DisabledRootPhyscis.transform.localScale = vector2;
			this.On_SetNotGrabbedHierarchy(position, rotation, vector2);
			this.m_EnabledNotGrabbedExtraPhyscis.SetActive(false);
			this.m_EnabledExtraPhyscis.SetActive(false);
			this.m_DisabledRootPhyscis.SetActive(true);
			this.m_root.parent = this.m_DisabledRootPhyscis.transform;
			this.m_root.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			this.m_root.localScale = Vector3.one;
			this.Post_SetNotGrabbedHierarchy();
			this.m_Estado = GrabbablePropEstado.NotGrabbed;
			this.OnStado();
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void Pre_SetGrabbedHierarchyDelayed(Side side, Interaccion obj)
		{
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void On_SetGrabbedHierarchyDelayed(Side side, Interaccion obj)
		{
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void Post_SetGrabbedHierarchyDelayed(Side side, Interaccion obj)
		{
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0002425C File Offset: 0x0002245C
		protected void SetGrabbedHierarchyDelayed(Side side, Interaccion obj)
		{
			GlobalUpdater.Corrutina setGrabbedHierarchyDelayedCorutina = this.m_SetGrabbedHierarchyDelayedCorutina;
			if (setGrabbedHierarchyDelayedCorutina != null)
			{
				setGrabbedHierarchyDelayedCorutina.Stop();
			}
			this.m_SetGrabbedHierarchyDelayedCorutina = null;
			this.Pre_SetGrabbedHierarchyDelayed(side, obj);
			this.m_root.parent = base.transform;
			this.m_EnabledExtraPhyscis.transform.parent = this.m_root;
			this.m_DisabledRootPhyscis.transform.parent = this.m_root;
			this.m_EnabledNotGrabbedExtraPhyscis.transform.parent = this.m_root;
			this.m_EnabledNotGrabbedExtraPhyscis.SetActive(false);
			this.m_DisabledRootPhyscis.SetActive(false);
			this.m_EnabledExtraPhyscis.SetActive(false);
			this.On_SetGrabbedHierarchyDelayed(side, obj);
			HandControllerV2 componentInChildren = obj.owner.character.GetComponentInChildren<HandControllerV2>();
			componentInChildren.flagForzeNewHandRotationMode = true;
			Transform currentPose = componentInChildren.currentPose;
			if (side == Side.L)
			{
				throw new NotImplementedException("falta desarrollar interaccion con mano izquierda");
			}
			if (side != Side.R)
			{
				throw new ArgumentOutOfRangeException(side.ToString());
			}
			this.m_handTargetPivotR.transform.SetPositionAndRotation(this.m_root.TransformPoint(this.m_PivotRPositionFromRoot), this.m_root.rotation * this.m_PivotRRotationFromRoot);
			this.m_handTargetPivotR.localScale = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.escala / this.m_interaccionR.transform.lossyScale.Escala() * Vector3.one;
			if (currentPose != null)
			{
				this.m_handTargetR.transform.SetPositionAndRotation(currentPose.position, currentPose.rotation);
			}
			InteractionTarget handTargetR = this.m_handTargetR;
			this.Post_SetGrabbedHierarchyDelayed(side, obj);
			this.m_SetGrabbedHierarchyDelayedCorutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.lateUpdateBeforePupetMaster, this, this.SetGrabbedHierarchyDelayedRutina(componentInChildren, side, currentPose, obj, handTargetR), null);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void Pre_SetGrabbedHierarchy(Side side, Interaccion obj, Quaternion handRotOffset, bool smoothHandRotOffset, float poseInSmothTime, float resetHandUserPosesSmoothTime)
		{
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void On_SetGrabbedHierarchy(Rigidbody muscleRigid, Vector3 pos, Quaternion rot, Vector3 scale, Side side, Interaccion obj, Quaternion handRotOffset, bool smoothHandRotOffset, float poseInSmothTime, float resetHandUserPosesSmoothTime)
		{
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void Post_SetGrabbedHierarchy(Rigidbody muscleRigid, Side side, Interaccion obj, Quaternion handRotOffset, bool smoothHandRotOffset, float poseInSmothTime, float resetHandUserPosesSmoothTime)
		{
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00024418 File Offset: 0x00022618
		protected void SetGrabbedHierarchy(Side side, Interaccion obj, Quaternion handRotOffset, bool smoothHandRotOffset, float poseInSmothTime, float resetHandUserPosesSmoothTime)
		{
			this.m_GrabbedBySide = Side.none;
			GlobalUpdater.Corrutina followBoneHandCorutina = this.m_followBoneHandCorutina;
			if (followBoneHandCorutina != null)
			{
				followBoneHandCorutina.Stop();
			}
			this.m_followBoneHandCorutina = null;
			GlobalUpdater.Corrutina followMuscleHadCorutina = this.m_FollowMuscleHadCorutina;
			if (followMuscleHadCorutina != null)
			{
				followMuscleHadCorutina.Stop();
			}
			this.m_FollowMuscleHadCorutina = null;
			GlobalUpdater.Corrutina setGrabbedHierarchyDelayedCorutina = this.m_SetGrabbedHierarchyDelayedCorutina;
			if (setGrabbedHierarchyDelayedCorutina != null)
			{
				setGrabbedHierarchyDelayedCorutina.Stop();
			}
			this.m_SetGrabbedHierarchyDelayedCorutina = null;
			GlobalUpdater.Corrutina followPoserOnGrabbingCorutina = this.m_followPoserOnGrabbingCorutina;
			if (followPoserOnGrabbingCorutina != null)
			{
				followPoserOnGrabbingCorutina.Stop();
			}
			this.m_followPoserOnGrabbingCorutina = null;
			GlobalUpdater.Corrutina trackHandModeCorutina = this.m_TrackHandModeCorutina;
			if (trackHandModeCorutina != null)
			{
				trackHandModeCorutina.Stop();
			}
			this.m_TrackHandModeCorutina = null;
			this.Pre_SetGrabbedHierarchy(side, obj, handRotOffset, smoothHandRotOffset, poseInSmothTime, resetHandUserPosesSmoothTime);
			ICharacter character = obj.owner.character;
			PuppetMaster componentInChildren = character.GetComponentInChildren<PuppetMaster>();
			Muscle muscle = ((componentInChildren != null) ? componentInChildren.GetMuscle(side, Muscle.GroupCompleto.Hand) : null);
			Rigidbody rigidbody = ((muscle != null) ? muscle.rigidbody : null);
			Vector3 position = this.m_DisabledRootPhyscis.transform.position;
			Quaternion rotation = this.m_DisabledRootPhyscis.transform.rotation;
			Vector3 vector = (this.m_scaleWithMainCharacter ? Vector3.one : (Vector3.one * (1f / character.escala)));
			HandControllerV2 componentInChildren2 = obj.owner.character.GetComponentInChildren<HandControllerV2>();
			componentInChildren2.flagForzeNewHandRotationMode = true;
			Transform currentPose = componentInChildren2.currentPose;
			if (side == Side.L)
			{
				throw new NotImplementedException("falta desarrollar interaccion con mano izquierda");
			}
			if (side != Side.R)
			{
				throw new ArgumentOutOfRangeException(side.ToString());
			}
			Vector3 position2 = this.m_handTargetR.transform.position;
			Quaternion rotation2 = this.m_handTargetR.transform.rotation;
			obj.transform.parent = base.transform;
			obj.transform.SetPositionAndRotation(position, rotation);
			obj.transform.localScale = Vector3.one;
			this.m_handTargetPivotR.localScale = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.escala / this.m_interaccionR.transform.lossyScale.Escala() * Vector3.one;
			this.m_handTargetR.transform.SetPositionAndRotation(position2, rotation2);
			Vector3 vector2;
			Quaternion quaternion;
			this.GetRootPoseFromHand(rigidbody.transform, side, this.m_handTargetR, out vector2, out quaternion);
			this.m_root.parent = rigidbody.transform;
			this.m_root.transform.localScale = vector;
			this.m_root.transform.SetPositionAndRotation(vector2, quaternion);
			this.m_EnabledExtraPhyscis.transform.parent = rigidbody.transform;
			this.m_EnabledExtraPhyscis.transform.localScale = vector;
			this.m_EnabledExtraPhyscis.transform.SetPositionAndRotation(vector2, quaternion);
			if (poseInSmothTime <= 0f && currentPose != null)
			{
				this.m_handTargetR.transform.SetPositionAndRotation(currentPose.position, currentPose.rotation);
			}
			this.m_followPoserOnGrabbingCorutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.lateUpdateBeforePupetMaster, this, this.FollowCurrentPoserRutine(componentInChildren2, this.m_handTargetR, handRotOffset, smoothHandRotOffset, poseInSmothTime, resetHandUserPosesSmoothTime), null);
			this.m_TrackHandModeCorutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.lateUpdateAfterCameraController, this, this.TrackHandModeRutine(componentInChildren2, this.m_interaccionR), null);
			GrabbableProp.RequiresHandPostionFix requiresHandPostionFix = new GrabbableProp.RequiresHandPostionFix();
			this.m_followBoneHandCorutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.lateUpdateAfterCameraController, this, this.FollowBoneHandRutine(character, requiresHandPostionFix, this.m_root, muscle.target, this.m_root.localPosition, this.m_root.localRotation), null);
			this.m_FollowMuscleHadCorutina = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.updateActor, this, this.FollowMuscleHadRutine(requiresHandPostionFix, this.m_root, rigidbody.transform, this.m_root.localPosition, this.m_root.localRotation), null);
			this.m_DisabledRootPhyscis.transform.parent = this.m_root;
			this.m_EnabledNotGrabbedExtraPhyscis.SetActive(false);
			this.m_DisabledRootPhyscis.SetActive(false);
			this.m_EnabledExtraPhyscis.SetActive(true);
			this.On_SetGrabbedHierarchy(rigidbody, position, rotation, vector, side, obj, handRotOffset, smoothHandRotOffset, poseInSmothTime, resetHandUserPosesSmoothTime);
			this.Post_SetGrabbedHierarchy(rigidbody, side, obj, handRotOffset, smoothHandRotOffset, poseInSmothTime, resetHandUserPosesSmoothTime);
			this.m_GrabbedBySide = side;
			this.m_Estado = GrabbablePropEstado.Grabbed;
			this.OnStado();
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void Pre_SetNotGrabbedButActivatedHierarchy(Interaccion obj, object attachedTo)
		{
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void On_SetNotGrabbedButActivatedHierarchy(Vector3 pos, Quaternion rot, Vector3 scale, Interaccion obj, object attachedTo)
		{
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void Post_SetNotGrabbedButActivatedHierarchy(Interaccion obj, object attachedTo)
		{
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00024820 File Offset: 0x00022A20
		protected void SetNotGrabbedButActivatedHierarchy(Interaccion obj, object attachedTo)
		{
			this.m_GrabbedBySide = Side.none;
			this.DejarDeSostener();
			GlobalUpdater.Corrutina followBoneHandCorutina = this.m_followBoneHandCorutina;
			if (followBoneHandCorutina != null)
			{
				followBoneHandCorutina.Stop();
			}
			this.m_followBoneHandCorutina = null;
			GlobalUpdater.Corrutina followMuscleHadCorutina = this.m_FollowMuscleHadCorutina;
			if (followMuscleHadCorutina != null)
			{
				followMuscleHadCorutina.Stop();
			}
			this.m_FollowMuscleHadCorutina = null;
			GlobalUpdater.Corrutina followPoserOnGrabbingCorutina = this.m_followPoserOnGrabbingCorutina;
			if (followPoserOnGrabbingCorutina != null)
			{
				followPoserOnGrabbingCorutina.Stop();
			}
			this.m_followPoserOnGrabbingCorutina = null;
			GlobalUpdater.Corrutina trackHandModeCorutina = this.m_TrackHandModeCorutina;
			if (trackHandModeCorutina != null)
			{
				trackHandModeCorutina.Stop();
			}
			this.m_TrackHandModeCorutina = null;
			this.Pre_SetNotGrabbedButActivatedHierarchy(obj, attachedTo);
			Vector3 position = this.m_root.position;
			Quaternion rotation = this.m_root.rotation;
			Vector3 vector = (this.m_scaleWithMainCharacter ? (CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.escala * Vector3.one) : Vector3.one);
			this.m_EnabledExtraPhyscis.transform.parent = this.m_root;
			this.m_DisabledRootPhyscis.transform.parent = this.m_root;
			this.m_EnabledNotGrabbedExtraPhyscis.transform.parent = this.m_root;
			this.m_root.parent = base.transform;
			this.m_interaccionR.transform.parent = this.m_root;
			this.m_interaccionR.transform.SetPositionAndRotation(position, rotation);
			this.m_interaccionR.transform.localScale = Vector3.one;
			this.m_handTargetR.transform.SetLocalPositionAndRotation(this.m_handRDefaultLocalPosition, this.m_handRDefaultLocalRotation);
			this.m_handTargetPivotR.transform.SetPositionAndRotation(this.m_root.TransformPoint(this.m_PivotRPositionFromRoot), this.m_root.rotation * this.m_PivotRRotationFromRoot);
			this.m_handTargetPivotR.localScale = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.escala / this.m_interaccionR.transform.lossyScale.Escala() * Vector3.one;
			this.m_EnabledNotGrabbedExtraPhyscis.transform.SetPositionAndRotation(position, rotation);
			this.m_EnabledNotGrabbedExtraPhyscis.transform.localScale = vector;
			this.On_SetNotGrabbedButActivatedHierarchy(position, rotation, vector, obj, attachedTo);
			this.m_EnabledExtraPhyscis.SetActive(false);
			this.m_DisabledRootPhyscis.SetActive(false);
			this.m_EnabledNotGrabbedExtraPhyscis.SetActive(true);
			this.Post_SetNotGrabbedButActivatedHierarchy(obj, attachedTo);
			this.m_Estado = GrabbablePropEstado.NotGrabbedButActivated;
			this.OnStado();
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00024A68 File Offset: 0x00022C68
		private void OnStado()
		{
			if (this.m_Estado != this.m_LastEstado)
			{
				try
				{
					GrabbableProp.OnStadoChangedHandler onStadoChangedHandler = this.onStadoChanged;
					if (onStadoChangedHandler != null)
					{
						onStadoChangedHandler(this.m_Estado, this.m_LastEstado, this);
					}
				}
				finally
				{
					this.m_LastEstado = this.m_Estado;
				}
			}
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00024AC0 File Offset: 0x00022CC0
		private IEnumerator CheckForCharacterScaleRutine()
		{
			WaitForSeconds w = new WaitForSeconds(3f.Random(0.2f));
			for (;;)
			{
				if (this.m_scaleWithMainCharacter && this.m_Estado == GrabbablePropEstado.NotGrabbed && this.m_DisabledRootPhyscis != null)
				{
					MainChar current = CurrentMainCharacter<CurrentMainChar, MainChar>.current;
					if (((current != null) ? current.character : null) != null)
					{
						this.m_DisabledRootPhyscis.transform.localScale = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character.escala * Vector3.one;
					}
				}
				yield return w;
			}
			yield break;
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00002BE7 File Offset: 0x00000DE7
		protected virtual bool FollowHandBone()
		{
			return false;
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00024ACF File Offset: 0x00022CCF
		private IEnumerator FollowBoneHandRutine(ICharacter grabedBy, GrabbableProp.RequiresHandPostionFix requires, Transform toyRoot, Transform handBone, Vector3 localPosition, Quaternion localRotation)
		{
			ICharacterControllerChar caminante = grabedBy as ICharacterControllerChar;
			bool puedeCaminar = caminante != null;
			while (this.m_Estado == GrabbablePropEstado.Grabbed)
			{
				if (((this.alwaysFollowHandBoneOnGrabbedOverride != null) ? this.alwaysFollowHandBoneOnGrabbedOverride.Value : this.m_alwaysFollowHandBoneOnGrabbed) || this.FollowHandBone() || (puedeCaminar && caminante.movingOnDirection.sqrMagnitude > 1E-06f))
				{
					toyRoot.SetPositionAndRotation(handBone.TransformPoint(localPosition), handBone.rotation * localRotation);
					requires.req = true;
				}
				yield return null;
			}
			yield break;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00024B0B File Offset: 0x00022D0B
		private IEnumerator FollowMuscleHadRutine(GrabbableProp.RequiresHandPostionFix requires, Transform toyRoot, Transform handMuscle, Vector3 localPosition, Quaternion localRotation)
		{
			while (this.m_Estado == GrabbablePropEstado.Grabbed)
			{
				if (requires.req && handMuscle != null && toyRoot != null)
				{
					toyRoot.SetPositionAndRotation(handMuscle.TransformPoint(localPosition), handMuscle.rotation * localRotation);
				}
				requires.req = false;
				yield return null;
			}
			yield break;
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00024B3F File Offset: 0x00022D3F
		private IEnumerator TrackHandModeRutine(HandControllerV2 controller, Interaccion grabInter)
		{
			while (controller.enabled)
			{
				yield return null;
			}
			grabInter.Detener(true);
			yield break;
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00024B55 File Offset: 0x00022D55
		private IEnumerator FollowCurrentPoserRutine(HandControllerV2 controller, InteractionTarget grabInterTarget, Quaternion handRotOffset, bool smoothHandRotOffset, float inSmoothTime, float resetHandUserPosesSmoothTime)
		{
			Quaternion currentOffset = Quaternion.identity;
			if (!smoothHandRotOffset)
			{
				currentOffset = handRotOffset;
			}
			float startTime = Time.time;
			while (this.m_Estado == GrabbablePropEstado.Grabbed)
			{
				Transform currentPose = controller.currentPose;
				if (currentPose == null)
				{
					break;
				}
				if (!ExtendedMonoBehaviour.AlmostEqual(currentOffset, handRotOffset, 0.1f))
				{
					currentOffset = Quaternion.RotateTowards(currentOffset, handRotOffset, Time.deltaTime * 180f);
				}
				float num = ((inSmoothTime <= 0f) ? 1f : Mathf.InverseLerp(0f, inSmoothTime, Time.time - startTime));
				if (num >= 1f)
				{
					grabInterTarget.transform.SetPositionAndRotation(currentPose.position, currentPose.rotation * currentOffset);
				}
				else
				{
					Vector3 vector = Vector3.Lerp(grabInterTarget.transform.position, currentPose.position, num);
					Quaternion quaternion = Quaternion.Slerp(grabInterTarget.transform.rotation, currentPose.rotation * currentOffset, num);
					grabInterTarget.transform.SetPositionAndRotation(vector, quaternion);
				}
				if (resetHandUserPosesSmoothTime >= 0f)
				{
					float num2 = Mathf.InverseLerp(0f, resetHandUserPosesSmoothTime, Time.time - startTime);
					Vector2 viewportPosition = controller.handCameraController.viewPortPositionContainer.viewportPosition;
					Vector2 viewportLookAtPosition = controller.handCameraController.viewPortPositionContainer.viewportLookAtPosition;
					float depthPosition = controller.handCameraController.depthPositionContainer.depthPosition;
					controller.handCameraController.viewPortPositionContainer.viewportPosition = Vector2.Lerp(viewportPosition, controller.GetCurrentInitialViewPosition(), num2);
					controller.handCameraController.viewPortPositionContainer.viewportLookAtPosition = Vector2.Lerp(viewportLookAtPosition, new Vector2(0.5f, 0.6f), num2);
					controller.handCameraController.depthPositionContainer.depthPosition = Mathf.Lerp(depthPosition, 0f, num2);
					if (num2 >= 1f)
					{
						resetHandUserPosesSmoothTime = -1f;
					}
				}
				yield return null;
			}
			yield break;
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x00024B94 File Offset: 0x00022D94
		private void GetHandPoseFromRoot(Transform root, Side side, InteractionTarget grabInterTarget, out Vector3 handPosition, out Quaternion handRotation)
		{
			if (side == Side.L)
			{
				throw new NotImplementedException("falta desarrollar interaccion con mano izquierda");
			}
			if (side != Side.R)
			{
				throw new ArgumentOutOfRangeException(side.ToString());
			}
			GrabbableProp.GetHandPoseFromRoot(root, this.m_PivotRPositionFromRoot, this.m_PivotRRotationFromRoot, grabInterTarget, this.m_handRDefaultLocalPosition, this.m_handRDefaultLocalRotation, out handPosition, out handRotation);
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x00024BEC File Offset: 0x00022DEC
		private void GetRootPoseFromHand(Transform hand, Side side, InteractionTarget grabInterTarget, out Vector3 rootPosition, out Quaternion rootRotation)
		{
			if (side == Side.L)
			{
				throw new NotImplementedException("falta desarrollar interaccion con mano izquierda");
			}
			if (side != Side.R)
			{
				throw new ArgumentOutOfRangeException(side.ToString());
			}
			GrabbableProp.GetRootPoseFromHand(hand, this.m_scaleWithMainCharacter, this.m_RootPositonFromPivotR, this.m_RootRotationFromPivotR, grabInterTarget, this.m_pivotRDefaultLocalPosition, this.m_pivotRDefaultLocalRotation, out rootPosition, out rootRotation);
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00024C4C File Offset: 0x00022E4C
		private static void GetHandPoseFromRoot(Transform root, Vector3 HandPivotPositionFromRoot, Quaternion HandPivotRotationFromRoot, InteractionTarget grabInterTarget, Vector3 handDefaultLocalPosition, Quaternion handDefaultLocalRotation, out Vector3 handPosition, out Quaternion handRotation)
		{
			Quaternion quaternion = root.rotation * HandPivotRotationFromRoot;
			handPosition = Matrix4x4.TRS(root.transform.TransformPoint(HandPivotPositionFromRoot), quaternion, grabInterTarget.pivot.lossyScale).MultiplyPoint3x4(handDefaultLocalPosition);
			handRotation = quaternion * handDefaultLocalRotation;
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00024CA4 File Offset: 0x00022EA4
		private static void GetRootPoseFromHand(Transform hand, bool usesPivotScale, Vector3 RootPositonFromHandPivot, Quaternion RootRotationFromHandPivot, InteractionTarget grabInterTarget, Vector3 pivotDefaultLocalPosition, Quaternion pivotDefaultLocalRotation, out Vector3 rootPosition, out Quaternion rootRotation)
		{
			Quaternion quaternion = hand.rotation * pivotDefaultLocalRotation;
			rootPosition = Matrix4x4.TRS(hand.TransformPoint(pivotDefaultLocalPosition), quaternion, usesPivotScale ? grabInterTarget.pivot.lossyScale : Vector3.one).MultiplyPoint3x4(RootPositonFromHandPivot);
			rootRotation = quaternion * RootRotationFromHandPivot;
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00024D01 File Offset: 0x00022F01
		private IEnumerator SetGrabbedHierarchyDelayedRutina(HandControllerV2 controller, Side side, Transform currentPoser, Interaccion obj, InteractionTarget grabInterTarget)
		{
			bool GrabInteractionTargetEstaEnToy = false;
			Vector3 vector;
			Quaternion quaternion;
			this.GetHandPoseFromRoot(this.m_root, side, grabInterTarget, out vector, out quaternion);
			float distance = Vector3.Distance(grabInterTarget.transform.position, vector);
			float angle = Quaternion.Angle(grabInterTarget.transform.rotation, quaternion);
			while (!GrabInteractionTargetEstaEnToy)
			{
				bool flag = ExtendedMonoBehaviour.AlmostEqual(vector, grabInterTarget.transform.position, 0.001f);
				bool flag2 = ExtendedMonoBehaviour.AlmostEqual(quaternion, grabInterTarget.transform.rotation, 0.1f);
				GrabInteractionTargetEstaEnToy = flag && flag2;
				Vector3 vector2 = Vector3.MoveTowards(grabInterTarget.transform.position, vector, Time.deltaTime * distance * 3f);
				Quaternion quaternion2 = Quaternion.RotateTowards(grabInterTarget.transform.rotation, quaternion, Time.deltaTime * angle * 3f);
				grabInterTarget.transform.SetPositionAndRotation(vector2, quaternion2);
				yield return null;
				this.GetHandPoseFromRoot(this.m_root, side, grabInterTarget, out vector, out quaternion);
			}
			bool flag3;
			if (obj == null)
			{
				flag3 = null != null;
			}
			else
			{
				IInteraccionesDeCharacter owner = obj.owner;
				flag3 = ((owner != null) ? owner.character : null) != null;
			}
			if (!flag3)
			{
				controller.activador.activated = false;
				this.SetNotGrabbedHierarchy();
			}
			else if (currentPoser != null)
			{
				Quaternion quaternion3 = Quaternion.Inverse(currentPoser.rotation) * quaternion;
				this.SetGrabbedHierarchy(side, obj, quaternion3, false, 0.5f, -1f);
			}
			yield break;
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x00024D35 File Offset: 0x00022F35
		public AgarranteObjeto agarradoPor
		{
			get
			{
				return this.m_agarrando;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x000066D6 File Offset: 0x000048D6
		bool GuiaDeGrabbableProp.IHandler.interactable
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00024D3D File Offset: 0x00022F3D
		bool GuiaDeGrabbableProp.IHandler.PuedeEfectuarInteraccionPara(AgarranteObjeto agarrante)
		{
			Interaccion interaccion = this.GetInteraccion(agarrante);
			return ((interaccion != null) ? interaccion.owner : null) != null;
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00024D58 File Offset: 0x00022F58
		private Interaccion GetInteraccion(AgarranteObjeto agarrante)
		{
			ISidedAgarranteObjeto sidedAgarranteObjeto = agarrante as ISidedAgarranteObjeto;
			Side side = ((sidedAgarranteObjeto != null) ? sidedAgarranteObjeto.side : Side.none);
			if (side == Side.none)
			{
				return null;
			}
			Interaccion interaccion;
			if (side != Side.L)
			{
				if (side != Side.R)
				{
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				interaccion = this.m_interaccionR;
			}
			else
			{
				Debug.LogException(new NotImplementedException("aun no es compatible copn interaccion de mano izquierda"));
				interaccion = null;
			}
			return interaccion;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00024DB8 File Offset: 0x00022FB8
		IEnumerator GuiaDeGrabbableProp.IHandler.EfectuarInteraccion(AgarranteObjeto agarrante)
		{
			Interaccion interaccion = this.GetInteraccion(agarrante);
			if (interaccion == null)
			{
				yield break;
			}
			while (agarrante.character != interaccion.owner.character)
			{
				yield return null;
			}
			this.DejarDeSostener();
			this.m_agarrando = agarrante;
			this.Sostener();
			this.m_ejecutandose = interaccion;
			interaccion.ForzarEjecucion(-1f, float.MaxValue, 1f, 1f, true, false);
			yield break;
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00024DCE File Offset: 0x00022FCE
		private void DejarDeSostener()
		{
			if (this.m_agarrando != null)
			{
				this.m_agarrando.DejarDeSostener();
			}
			this.m_agarrando = null;
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x00024DF0 File Offset: 0x00022FF0
		private void Sostener()
		{
			this.m_agarrando.Sostener(this.m_guia);
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00024E03 File Offset: 0x00023003
		void GuiaDeGrabbableProp.IHandler.Stop()
		{
			if (!base.isAwaken)
			{
				return;
			}
			if (this.m_ejecutandose != null && this.m_ejecutandose.ejecutandose)
			{
				this.m_ejecutandose.Detener(true);
			}
			this.m_ejecutandose = null;
		}

		// Token: 0x04000536 RID: 1334
		[Header("Prop")]
		[SerializeField]
		protected Transform m_root;

		// Token: 0x04000537 RID: 1335
		[SerializeField]
		protected Transform m_armatureRoot;

		// Token: 0x04000538 RID: 1336
		[SerializeField]
		private InteraccionSegundariaBase m_interaccionR;

		// Token: 0x04000539 RID: 1337
		[SerializeField]
		private bool m_scaleWithMainCharacter = true;

		// Token: 0x0400053A RID: 1338
		[SerializeField]
		private bool m_alwaysFollowHandBoneOnGrabbed;

		// Token: 0x0400053B RID: 1339
		[SerializeField]
		private float m_defaultLocalLargo = 0.1f;

		// Token: 0x0400053C RID: 1340
		[SerializeField]
		[ReadOnlyUI]
		private GrabbablePropEstado m_Estado;

		// Token: 0x0400053D RID: 1341
		[SerializeField]
		[ReadOnlyUI]
		private Side m_GrabbedBySide;

		// Token: 0x0400053E RID: 1342
		[SerializeField]
		private GameObject m_DisabledRootPhyscis;

		// Token: 0x0400053F RID: 1343
		[SerializeField]
		private GameObject m_EnabledExtraPhyscis;

		// Token: 0x04000540 RID: 1344
		[SerializeField]
		private GameObject m_EnabledNotGrabbedExtraPhyscis;

		// Token: 0x04000541 RID: 1345
		[SerializeField]
		protected Quaternion m_poserRtoationOffset = Quaternion.identity;

		// Token: 0x04000542 RID: 1346
		[SerializeField]
		[ReadOnlyUI]
		private InteractionTarget m_handTargetR;

		// Token: 0x04000543 RID: 1347
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_handTargetPivotR;

		// Token: 0x04000544 RID: 1348
		private GlobalUpdater.Corrutina m_SetGrabbedHierarchyDelayedCorutina;

		// Token: 0x04000545 RID: 1349
		private GlobalUpdater.Corrutina m_TrackHandModeCorutina;

		// Token: 0x04000546 RID: 1350
		private GlobalUpdater.Corrutina m_followPoserOnGrabbingCorutina;

		// Token: 0x04000547 RID: 1351
		private GlobalUpdater.Corrutina m_followBoneHandCorutina;

		// Token: 0x04000548 RID: 1352
		private GlobalUpdater.Corrutina m_FollowMuscleHadCorutina;

		// Token: 0x04000549 RID: 1353
		private Vector3 m_RootPositonFromPivotR;

		// Token: 0x0400054A RID: 1354
		private Quaternion m_RootRotationFromPivotR;

		// Token: 0x0400054B RID: 1355
		private Vector3 m_PivotRPositionFromRoot;

		// Token: 0x0400054C RID: 1356
		private Quaternion m_PivotRRotationFromRoot;

		// Token: 0x0400054D RID: 1357
		private Vector3 m_handRDefaultLocalPosition;

		// Token: 0x0400054E RID: 1358
		private Quaternion m_handRDefaultLocalRotation;

		// Token: 0x0400054F RID: 1359
		private Vector3 m_pivotRDefaultLocalPosition;

		// Token: 0x04000550 RID: 1360
		private Quaternion m_pivotRDefaultLocalRotation;

		// Token: 0x04000551 RID: 1361
		private GrabbablePropEstado m_LastEstado;

		// Token: 0x04000553 RID: 1363
		private CoroutineCapsule m_CheckForCharScaleCoroutine;

		// Token: 0x04000554 RID: 1364
		[Header("Grabbing")]
		public GameObject guiaPrefab;

		// Token: 0x04000555 RID: 1365
		[SerializeField]
		private GuiaDeGrabbableProp m_guia;

		// Token: 0x04000556 RID: 1366
		[SerializeField]
		private Transform m_grabbingTrasfrom;

		// Token: 0x04000557 RID: 1367
		[SerializeField]
		[ReadOnlyUI]
		private Interaccion m_ejecutandose;

		// Token: 0x04000558 RID: 1368
		[SerializeField]
		[ReadOnlyUI]
		private AgarranteObjeto m_agarrando;

		// Token: 0x0200014C RID: 332
		// (Invoke) Token: 0x060006BF RID: 1727
		public delegate void OnStadoChangedHandler(GrabbablePropEstado current, GrabbablePropEstado last, GrabbableProp sender);

		// Token: 0x0200014D RID: 333
		private class RequiresHandPostionFix
		{
			// Token: 0x04000559 RID: 1369
			public bool req;
		}
	}
}
