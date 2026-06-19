using System;
using System.Collections;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones.MaleInteractions;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Hands;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores
{
	// Token: 0x0200023F RID: 575
	public class HandControllerV2 : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000F37 RID: 3895 RVA: 0x0004386B File Offset: 0x00041A6B
		public bool usarRotationMetodoViejo
		{
			get
			{
				return Singleton<ConfiguracionGeneralDeInputs>.instance.useLegacyHandRotationMode && !this.flagForzeNewHandRotationMode;
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000F38 RID: 3896 RVA: 0x00043884 File Offset: 0x00041A84
		public Transform currentPose
		{
			get
			{
				return this.GetCurrentPose();
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x0004388C File Offset: 0x00041A8C
		public Transform currentPoseIndex
		{
			get
			{
				return this.GetCurrentPoseIndex();
			}
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000F3A RID: 3898 RVA: 0x00043894 File Offset: 0x00041A94
		public Quaternion currentDefOffset
		{
			get
			{
				return this.GetCurrentDefOffset();
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06000F3B RID: 3899 RVA: 0x0004389C File Offset: 0x00041A9C
		public bool handEstaSiendoUsada
		{
			get
			{
				return this.GetCurrentInteraction().instancia.ejecutandose;
			}
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000F3C RID: 3900 RVA: 0x000438AE File Offset: 0x00041AAE
		public float weigth
		{
			get
			{
				if (!this.handEstaSiendoUsada)
				{
					return 0f;
				}
				return this.GetCurrentInteraction().instancia.currentEstado.estados[0].timerWeigth;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x000438DE File Offset: 0x00041ADE
		public HandCameraControllerV2 handCameraController
		{
			get
			{
				return this.m_handCameraController;
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x000438E6 File Offset: 0x00041AE6
		public FingerPhyscisController fingerPhyscisController
		{
			get
			{
				return this.m_FingerPhyscisController;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x000438EE File Offset: 0x00041AEE
		public bool isMovingHand
		{
			get
			{
				return this.m_handCameraController.handWasMoved && base.enabled;
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x00043905 File Offset: 0x00041B05
		public Character character
		{
			get
			{
				return this.m_Character;
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000F41 RID: 3905 RVA: 0x0004390D File Offset: 0x00041B0D
		public Quaternion armatureOrientationOffSet
		{
			get
			{
				return this.m_Character.armatureOrientationOffSet;
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000F42 RID: 3906 RVA: 0x0004391A File Offset: 0x00041B1A
		public Quaternion skeletonRotationFix
		{
			get
			{
				return this.m_RotationMatrix;
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000F43 RID: 3907 RVA: 0x00043922 File Offset: 0x00041B22
		public IHandActivador activador
		{
			get
			{
				return this.m_activador;
			}
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x0004392C File Offset: 0x00041B2C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_RotationMatrix = Quaternion.LookRotation(this.m_handForward, this.m_handUp);
			this.m_Character = base.GetComponentInParent<Character>();
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_InteraccionesBasicasDeMale = this.m_Character.GetComponentInChildren<InteraccionesBasicasDeMale>();
			if (this.m_InteraccionesBasicasDeMale == null)
			{
				throw new ArgumentNullException("m_InteraccionesBasicasDeMale", "m_InteraccionesBasicasDeMale null reference.");
			}
			if (!this.m_InteraccionesBasicasDeMale.isAwaken)
			{
				this.m_InteraccionesBasicasDeMale.ManualAwake();
			}
			this.m_activador = base.GetComponentInParent<IHandActivador>();
			if (this.m_activador == null)
			{
				throw new ArgumentNullException("m_activador", "m_activador null reference.");
			}
			this.m_handCameraController = this.GetComponentNotNull<HandCameraControllerV2>();
			this.m_massage = this.m_InteraccionesBasicasDeMale.Obtener(InteraccionesBasicasDeMale.InteraccionSegundariaName.massage_R);
			this.m_finger = this.m_InteraccionesBasicasDeMale.Obtener(InteraccionesBasicasDeMale.InteraccionSegundariaName.finger_R);
			this.m_phoneCam = this.m_InteraccionesBasicasDeMale.Obtener(InteraccionesBasicasDeMale.InteraccionSegundariaName.phone_Cam);
			this.m_camera = this.m_InteraccionesBasicasDeMale.Obtener(InteraccionesBasicasDeMale.InteraccionSegundariaName.camera);
			this.m_grab = this.m_InteraccionesBasicasDeMale.Obtener(InteraccionesBasicasDeMale.InteraccionSegundariaName.grab_R);
			this.m_massage_R_Target = this.m_massage.instancia.GetComponentsInChildren<MaleHandInteractionTarget>().FirstOrDefault(delegate(MaleHandInteractionTarget inte)
			{
				if (!inte.isAwaken)
				{
					inte.ManualAwake();
				}
				return inte.interactionTarget.effectorType == FullBodyBipedEffector.RightHand;
			});
			this.m_finger_R_Target = this.m_finger.instancia.GetComponentsInChildren<MaleHandInteractionTarget>().FirstOrDefault(delegate(MaleHandInteractionTarget inte)
			{
				if (!inte.isAwaken)
				{
					inte.ManualAwake();
				}
				return inte.interactionTarget.effectorType == FullBodyBipedEffector.RightHand;
			});
			this.m_phoneCam_R_Target = this.m_phoneCam.instancia.GetComponentsInChildren<MaleHandInteractionTarget>().FirstOrDefault(delegate(MaleHandInteractionTarget inte)
			{
				if (!inte.isAwaken)
				{
					inte.ManualAwake();
				}
				return inte.interactionTarget.effectorType == FullBodyBipedEffector.RightHand;
			});
			this.m_camera_Target = this.m_camera.instancia.GetComponentsInChildren<MaleHandInteractionTarget>().FirstOrDefault(delegate(MaleHandInteractionTarget inte)
			{
				if (!inte.isAwaken)
				{
					inte.ManualAwake();
				}
				return inte.interactionTarget.effectorType == FullBodyBipedEffector.RightHand;
			});
			this.m_grab_R_Target = this.m_grab.instancia.GetComponentsInChildren<MaleHandInteractionTarget>().FirstOrDefault(delegate(MaleHandInteractionTarget inte)
			{
				if (!inte.isAwaken)
				{
					inte.ManualAwake();
				}
				return inte.interactionTarget.effectorType == FullBodyBipedEffector.RightHand;
			});
			this.m_head = this.m_Character.bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
			this.m_defOffsetMassage = Quaternion.Inverse(this.m_head.rotation) * this.m_massage_R_Target.transform.rotation;
			this.m_defOffsetFinger = Quaternion.Inverse(this.m_head.rotation) * this.m_finger_R_Target.transform.rotation;
			this.m_defOffsetPhoneCam = Quaternion.Inverse(this.m_head.rotation) * this.m_phoneCam_R_Target.transform.rotation;
			this.m_defOffsetCamera = Quaternion.Inverse(this.m_head.rotation) * this.m_camera_Target.transform.rotation;
			this.m_defOffsetGrab = Quaternion.Inverse(this.m_head.rotation) * this.m_grab_R_Target.transform.rotation;
			base.SetYieldStart();
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x00043C68 File Offset: 0x00041E68
		public Vector2 GetCurrentInitialViewPosition()
		{
			switch (this.tipoDePose)
			{
			case HandTipoDePose.None:
				return this.initialViewPositions.None;
			case HandTipoDePose.massage:
			case HandTipoDePose.grab:
				return this.initialViewPositions.massage;
			case HandTipoDePose.finger:
				return this.initialViewPositions.finger;
			case HandTipoDePose.phoneCam:
				return this.initialViewPositions.phoneCam;
			case HandTipoDePose.camera:
				return this.initialViewPositions.camera;
			}
			throw new ArgumentOutOfRangeException(this.tipoDePose.ToString());
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x00043CF4 File Offset: 0x00041EF4
		public void GetCurrentInteractionDepths(out float minDepth, out float defDepth, out float maxDepth)
		{
			switch (this.tipoDePose)
			{
			case HandTipoDePose.None:
				defDepth = this.limites.None.defaultDepth;
				maxDepth = this.limites.None.maxDepth;
				goto IL_0109;
			case HandTipoDePose.massage:
			case HandTipoDePose.grab:
				defDepth = this.limites.massage.defaultDepth;
				maxDepth = this.limites.massage.maxDepth;
				goto IL_0109;
			case HandTipoDePose.finger:
				defDepth = this.limites.finger.defaultDepth;
				maxDepth = this.limites.finger.maxDepth;
				goto IL_0109;
			case HandTipoDePose.phoneCam:
				defDepth = this.limites.phoneCam.defaultDepth;
				maxDepth = this.limites.phoneCam.maxDepth;
				goto IL_0109;
			case HandTipoDePose.camera:
				defDepth = this.limites.camera.defaultDepth;
				maxDepth = this.limites.camera.maxDepth;
				goto IL_0109;
			}
			throw new ArgumentOutOfRangeException(this.tipoDePose.ToString());
			IL_0109:
			maxDepth *= this.m_Character.escala;
			defDepth *= this.m_Character.escala;
			minDepth = -defDepth;
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x00043E30 File Offset: 0x00042030
		private InteraccionDeCharacter GetCurrentInteraction()
		{
			switch (this.tipoDePose)
			{
			case HandTipoDePose.massage:
				return this.m_massage;
			case HandTipoDePose.finger:
				return this.m_finger;
			case HandTipoDePose.phoneCam:
				return this.m_phoneCam;
			case HandTipoDePose.camera:
				return this.m_camera;
			case HandTipoDePose.grab:
				return this.m_grab;
			}
			throw new ArgumentOutOfRangeException(this.tipoDePose.ToString());
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x00043EA4 File Offset: 0x000420A4
		private Transform GetCurrentPose()
		{
			switch (this.tipoDePose)
			{
			case HandTipoDePose.massage:
				if (!(this.m_massage_R_Target != null))
				{
					return null;
				}
				return this.m_massage_R_Target.transform;
			case HandTipoDePose.finger:
				if (!(this.m_finger_R_Target != null))
				{
					return null;
				}
				return this.m_finger_R_Target.transform;
			case HandTipoDePose.phoneCam:
				if (!(this.m_phoneCam_R_Target != null))
				{
					return null;
				}
				return this.m_phoneCam_R_Target.transform;
			case HandTipoDePose.camera:
				if (!(this.m_camera_Target != null))
				{
					return null;
				}
				return this.m_camera_Target.transform;
			case HandTipoDePose.grab:
				if (!(this.m_grab_R_Target != null))
				{
					return null;
				}
				return this.m_grab_R_Target.transform;
			}
			throw new ArgumentOutOfRangeException(this.tipoDePose.ToString());
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x00043F84 File Offset: 0x00042184
		private Transform GetCurrentPoseIndex()
		{
			switch (this.tipoDePose)
			{
			case HandTipoDePose.massage:
				if (!(this.m_massage_R_Target != null))
				{
					return null;
				}
				return this.m_massage_R_Target.proximalIndex;
			case HandTipoDePose.finger:
				if (!(this.m_massage_R_Target != null))
				{
					return null;
				}
				return this.m_finger_R_Target.proximalIndex;
			case HandTipoDePose.phoneCam:
				if (!(this.m_massage_R_Target != null))
				{
					return null;
				}
				return this.m_phoneCam_R_Target.proximalIndex;
			case HandTipoDePose.camera:
				if (!(this.m_massage_R_Target != null))
				{
					return null;
				}
				return this.m_camera_Target.proximalIndex;
			}
			throw new ArgumentOutOfRangeException(this.tipoDePose.ToString());
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x0004403C File Offset: 0x0004223C
		private Quaternion GetCurrentDefOffset()
		{
			switch (this.tipoDePose)
			{
			case HandTipoDePose.massage:
				return this.m_defOffsetMassage;
			case HandTipoDePose.finger:
				return this.m_defOffsetFinger;
			case HandTipoDePose.phoneCam:
				return this.m_defOffsetPhoneCam;
			case HandTipoDePose.camera:
				return this.m_defOffsetCamera;
			case HandTipoDePose.grab:
				return this.m_defOffsetGrab;
			}
			throw new ArgumentOutOfRangeException(this.tipoDePose.ToString());
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x000440B0 File Offset: 0x000422B0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_handCameraController.activado = (this.m_handCameraController.puedeMoverHand = true);
			if (base.isStared)
			{
				this.currentPose.SetPositionAndRotation(this.m_handCameraController.hand.position, this.m_handCameraController.hand.rotation);
				this.GetCurrentInteraction().instancia.Ejecutar(int.MaxValue, -1f, ControllerPrioridadConfig.interrumpir, 1f, 1f, false);
			}
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x00044138 File Offset: 0x00042338
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_handCameraController.activado = (this.m_handCameraController.puedeMoverHand = false);
			this.GetCurrentInteraction().instancia.Detener(false);
			this.flagForzeNewHandRotationMode = false;
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x0004417E File Offset: 0x0004237E
		protected override IEnumerator YieldStartUnityEvent()
		{
			do
			{
				yield return null;
				this.m_FingerPhyscisController = this.GetComponentEnRoot(true);
			}
			while (this.m_FingerPhyscisController == null);
			this.m_handCameraController.Init(this.side);
			yield break;
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x0004418D File Offset: 0x0004238D
		public void SetViewPortContainer(IViewPortPositionContainer viewPortPositionContainer)
		{
			this.m_handCameraController.viewPortPositionContainer = viewPortPositionContainer;
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x0004419B File Offset: 0x0004239B
		public void SetDepthContainer(IDepthPositionContainer depthPositionContainer)
		{
			this.m_handCameraController.depthPositionContainer = depthPositionContainer;
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x000441A9 File Offset: 0x000423A9
		public void ResetRotationOffset()
		{
			this.m_handCameraController.fixingRotationOffSet = Quaternion.identity;
			this.m_handCameraController.userRotationOffSet = Quaternion.identity;
			this.m_handCameraController.fixingPositionOffSet = Vector3.zero;
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x000441DB File Offset: 0x000423DB
		public void SetRotationOffset(Quaternion offsetAngles)
		{
			this.m_handCameraController.userRotationOffSet = offsetAngles;
		}

		// Token: 0x04000A69 RID: 2665
		public Side side;

		// Token: 0x04000A6A RID: 2666
		public HandTipoDePose tipoDePose = HandTipoDePose.massage;

		// Token: 0x04000A6B RID: 2667
		[SerializeField]
		private Quaternion m_defOffsetMassage;

		// Token: 0x04000A6C RID: 2668
		[SerializeField]
		private Quaternion m_defOffsetFinger;

		// Token: 0x04000A6D RID: 2669
		[SerializeField]
		private Quaternion m_defOffsetPhoneCam;

		// Token: 0x04000A6E RID: 2670
		[SerializeField]
		private Quaternion m_defOffsetCamera;

		// Token: 0x04000A6F RID: 2671
		[SerializeField]
		private Quaternion m_defOffsetGrab;

		// Token: 0x04000A70 RID: 2672
		private Transform m_head;

		// Token: 0x04000A71 RID: 2673
		private Character m_Character;

		// Token: 0x04000A72 RID: 2674
		private FingerPhyscisController m_FingerPhyscisController;

		// Token: 0x04000A73 RID: 2675
		private HandCameraControllerV2 m_handCameraController;

		// Token: 0x04000A74 RID: 2676
		public HandControllerV2.Limites limites = new HandControllerV2.Limites();

		// Token: 0x04000A75 RID: 2677
		public HandControllerV2.InitialViewPositions initialViewPositions = new HandControllerV2.InitialViewPositions();

		// Token: 0x04000A76 RID: 2678
		[SerializeField]
		private Vector3 m_handForward = Vector3.up;

		// Token: 0x04000A77 RID: 2679
		[SerializeField]
		private Vector3 m_handUp = -Vector3.right;

		// Token: 0x04000A78 RID: 2680
		private Quaternion m_RotationMatrix;

		// Token: 0x04000A79 RID: 2681
		private InteraccionesBasicasDeMale m_InteraccionesBasicasDeMale;

		// Token: 0x04000A7A RID: 2682
		private InteraccionDeCharacter m_massage;

		// Token: 0x04000A7B RID: 2683
		private InteraccionDeCharacter m_finger;

		// Token: 0x04000A7C RID: 2684
		private InteraccionDeCharacter m_phoneCam;

		// Token: 0x04000A7D RID: 2685
		private InteraccionDeCharacter m_camera;

		// Token: 0x04000A7E RID: 2686
		private InteraccionDeCharacter m_grab;

		// Token: 0x04000A7F RID: 2687
		private MaleHandInteractionTarget m_massage_R_Target;

		// Token: 0x04000A80 RID: 2688
		private MaleHandInteractionTarget m_finger_R_Target;

		// Token: 0x04000A81 RID: 2689
		private MaleHandInteractionTarget m_phoneCam_R_Target;

		// Token: 0x04000A82 RID: 2690
		private MaleHandInteractionTarget m_camera_Target;

		// Token: 0x04000A83 RID: 2691
		private MaleHandInteractionTarget m_grab_R_Target;

		// Token: 0x04000A84 RID: 2692
		[Obsolete("", true)]
		private MaleHandInteractionTarget m_pick_R_Target;

		// Token: 0x04000A85 RID: 2693
		[SerializeField]
		[Obsolete("", true)]
		private Quaternion m_defOffsetPick;

		// Token: 0x04000A86 RID: 2694
		[Obsolete("", true)]
		private InteraccionDeCharacter m_pick;

		// Token: 0x04000A87 RID: 2695
		public bool flagForzeNewHandRotationMode;

		// Token: 0x04000A88 RID: 2696
		private IHandActivador m_activador;

		// Token: 0x02000240 RID: 576
		[Serializable]
		public class Limites
		{
			// Token: 0x04000A89 RID: 2697
			public HandControllerV2.Limite None = new HandControllerV2.Limite
			{
				defaultDepth = 0.25f,
				maxDepth = 0.25f
			};

			// Token: 0x04000A8A RID: 2698
			public HandControllerV2.Limite massage = new HandControllerV2.Limite
			{
				defaultDepth = 0.3f,
				maxDepth = 0.3f
			};

			// Token: 0x04000A8B RID: 2699
			public HandControllerV2.Limite finger = new HandControllerV2.Limite
			{
				defaultDepth = 0.26f,
				maxDepth = 0.3f
			};

			// Token: 0x04000A8C RID: 2700
			public HandControllerV2.Limite phoneCam = new HandControllerV2.Limite
			{
				defaultDepth = 0.2f,
				maxDepth = 0.1f
			};

			// Token: 0x04000A8D RID: 2701
			public HandControllerV2.Limite camera = new HandControllerV2.Limite
			{
				defaultDepth = 0.15f,
				maxDepth = 0.0001f
			};
		}

		// Token: 0x02000241 RID: 577
		[Serializable]
		public class InitialViewPositions
		{
			// Token: 0x04000A8E RID: 2702
			public Vector2 None = new Vector2
			{
				x = 0.63f,
				y = 0.25f
			};

			// Token: 0x04000A8F RID: 2703
			public Vector2 massage = new Vector2
			{
				x = 0.63f,
				y = 0.25f
			};

			// Token: 0x04000A90 RID: 2704
			public Vector2 finger = new Vector2
			{
				x = 0.63f,
				y = 0.25f
			};

			// Token: 0x04000A91 RID: 2705
			public Vector2 phoneCam = new Vector2
			{
				x = 0.63f,
				y = 0f
			};

			// Token: 0x04000A92 RID: 2706
			public Vector2 camera = new Vector2
			{
				x = 1.1f,
				y = 0.2f
			};
		}

		// Token: 0x02000242 RID: 578
		[Serializable]
		public class Limite
		{
			// Token: 0x04000A93 RID: 2707
			public float defaultDepth = 0.5f;

			// Token: 0x04000A94 RID: 2708
			public float maxDepth = 0.5f;
		}
	}
}
