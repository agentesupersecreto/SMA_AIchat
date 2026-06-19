using System;
using System.Collections.Generic;
using com.ootii.Actors;
using com.ootii.Actors.AnimationControllers;
using com.ootii.Cameras;
using RootMotion;
using RootMotion.Dynamics;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ootii.Controllers
{
	// Token: 0x02000168 RID: 360
	[RequireComponent(typeof(Character))]
	public sealed class MotionControllerPuppet : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060007D4 RID: 2004 RVA: 0x00028954 File Offset: 0x00026B54
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.actorController = base.GetComponentInChildren<ActorController>();
			this.motionController = base.GetComponentInChildren<MotionController>();
			this.m_MotionAndActorControllerActivable = base.GetComponentInChildren<MotionAndActorControllerActivable>();
			this.m_Character = base.GetComponent<Character>();
			if (this.m_MotionAndActorControllerActivable == null)
			{
				Debug.LogWarning("No MotionAndActorControllerActivable found on OotiiPuppet.cs GameObject. Please add OotiiPuppet.cs to the same Gameobject as the MotionAndActorControllerActivable.", base.transform);
				return;
			}
			if (this.actorController == null)
			{
				Debug.LogWarning("No ActorController found on OotiiPuppet.cs GameObject. Please add OotiiPuppet.cs to the same Gameobject as the ActorController.", base.transform);
				return;
			}
			if (!this.actorController.IsGroundingLayersEnabled)
			{
				Debug.LogWarning("OotiiPuppet.cs is enabling 'Use Grounding Layers' in the ActorController. Enable it manually in Editor to get rid of this warning.", base.transform);
				this.actorController.IsGroundingLayersEnabled = true;
			}
			this.m_Character.stared += this.M_Character_stared;
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x00028A18 File Offset: 0x00026C18
		private void M_Character_stared(object obj)
		{
			ActorController actorController = this.actorController;
			if (actorController != null)
			{
				actorController.DoStart();
			}
			MotionController motionController = this.motionController;
			if (motionController != null)
			{
				motionController.DoStart();
			}
			(this.actorController.BodyShapes[0] as BodyCapsule).EndTransform = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x00028A74 File Offset: 0x00026C74
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_MotionAndActorEstanDesactivos = this.m_MotionAndActorControllerActivable.estanDesactivadosModificable.ObtenerModificadorNotNull(this);
			this.puppet = base.GetComponentInChildren<BehaviourPuppet>();
			this.fall = base.GetComponentInChildren<BehaviourFall>();
			this.puppetMaster = base.GetComponentInChildren<PuppetMaster>();
			this.SetUpLayers();
			this.puppet.onLoseBalance.unityEvent.AddListener(new UnityAction(this.OnLoseBalance));
			this.puppet.onRegainBalance.unityEvent.AddListener(new UnityAction(this.OnRegainBalance));
			if (LayerMaskExtensions.Contains(this.actorController.GroundingLayers, this.puppetMaster.muscles[0].joint.gameObject.layer))
			{
				Debug.LogWarning("ActorController's 'Grounding Layers' includes the ragdoll layer. This will probably send the character flying.", base.transform);
			}
			if (LayerMaskExtensions.Contains(this.actorController.CollisionLayers, this.puppetMaster.muscles[0].joint.gameObject.layer))
			{
				Debug.LogWarning("ActorController's 'Collision Layers' includes the ragdoll layer. Please make sure it doesn't", base.transform);
			}
			foreach (BaseCameraRig baseCameraRig in Object.FindObjectsOfType<BaseCameraRig>())
			{
				if (this.TransformContains(base.transform, baseCameraRig.Anchor))
				{
					this.cameraRigs.Add(baseCameraRig);
				}
			}
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00028BC8 File Offset: 0x00026DC8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeBool motionAndActorEstanDesactivos = this.m_MotionAndActorEstanDesactivos;
			if (motionAndActorEstanDesactivos != null)
			{
				motionAndActorEstanDesactivos.TryRemoverDeOwner(true);
			}
			if (this.puppet)
			{
				this.puppet.onLoseBalance.unityEvent.RemoveListener(new UnityAction(this.OnLoseBalance));
				this.puppet.onRegainBalance.unityEvent.RemoveListener(new UnityAction(this.OnRegainBalance));
			}
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00028C3E File Offset: 0x00026E3E
		public void OnLoseBalance()
		{
			this.m_MotionAndActorEstanDesactivos.valor.valor = true;
			this.m_MotionAndActorControllerActivable.Actualizar();
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x00028C5C File Offset: 0x00026E5C
		public void OnRegainBalance()
		{
			this.actorController.State.IsGrounded = true;
			this.actorController.SetPosition(this.m_Character.bodyAnimator.transform.position);
			this.actorController.SetRotation(this.m_Character.bodyAnimator.transform.rotation);
			this.actorController.AccumulatedVelocity = Vector3.zero;
			this.m_MotionAndActorEstanDesactivos.valor.valor = false;
			this.m_MotionAndActorControllerActivable.Actualizar();
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x00028CE8 File Offset: 0x00026EE8
		private bool TransformContains(Transform root, Transform t)
		{
			Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i] == t)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00028D18 File Offset: 0x00026F18
		public void SetUpLayers()
		{
			if (this.puppet != null)
			{
				this.actorController.GroundingLayers = this.puppet.groundLayers;
				if (this.fall != null)
				{
					this.fall.raycastLayers = this.actorController.GroundingLayers;
				}
			}
		}

		// Token: 0x04000619 RID: 1561
		private PuppetMaster puppetMaster;

		// Token: 0x0400061A RID: 1562
		private MotionController motionController;

		// Token: 0x0400061B RID: 1563
		private ActorController actorController;

		// Token: 0x0400061C RID: 1564
		private MotionAndActorControllerActivable m_MotionAndActorControllerActivable;

		// Token: 0x0400061D RID: 1565
		[SerializeField]
		private ModificadorDeBool m_MotionAndActorEstanDesactivos;

		// Token: 0x0400061E RID: 1566
		private BehaviourPuppet puppet;

		// Token: 0x0400061F RID: 1567
		private BehaviourFall fall;

		// Token: 0x04000620 RID: 1568
		private Character m_Character;

		// Token: 0x04000621 RID: 1569
		private List<BaseCameraRig> cameraRigs = new List<BaseCameraRig>();
	}
}
