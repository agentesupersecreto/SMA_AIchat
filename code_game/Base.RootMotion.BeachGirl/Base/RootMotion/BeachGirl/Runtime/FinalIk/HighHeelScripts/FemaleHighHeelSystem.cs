using System;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using InterfaceFields;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.HighHeelScripts
{
	// Token: 0x0200002E RID: 46
	public sealed class FemaleHighHeelSystem : AplicableBehaviour
	{
		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060001B3 RID: 435 RVA: 0x000097A8 File Offset: 0x000079A8
		// (remove) Token: 0x060001B4 RID: 436 RVA: 0x000097E0 File Offset: 0x000079E0
		public event Action<FemaleHighHeelSystem> highHeelUpdated;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060001B5 RID: 437 RVA: 0x00009818 File Offset: 0x00007A18
		// (remove) Token: 0x060001B6 RID: 438 RVA: 0x00009850 File Offset: 0x00007A50
		public event Action<FemaleHighHeelSystem> highHeelHeightUpdated;

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00009885 File Offset: 0x00007A85
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdateBeforeIKs);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000988E File Offset: 0x00007A8E
		public override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.meshGeneralModsUpdate1);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00009897 File Offset: 0x00007A97
		public ModificableDeFloat grounderIkWeigthModificable
		{
			get
			{
				return this.m_grounderIkWeigthModificable;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000989F File Offset: 0x00007A9F
		public float currentHeelLocalHeight
		{
			get
			{
				return this.m_currentHeelLocalHeight;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000098A7 File Offset: 0x00007AA7
		public float currentToeLocalHeight
		{
			get
			{
				return this.m_currentToeLocalHeight;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001BC RID: 444 RVA: 0x000098AF File Offset: 0x00007AAF
		public float currentHeelLocalTotalHeight
		{
			get
			{
				return this.m_currentHeelLocalHeight + this.m_defaultHeelHeight;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001BD RID: 445 RVA: 0x000098BE File Offset: 0x00007ABE
		public float currentToeLocalTotalHeight
		{
			get
			{
				return this.m_currentToeLocalHeight + this.m_defaultToeHeight;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001BE RID: 446 RVA: 0x000098CD File Offset: 0x00007ACD
		public float currentHeelWorldHeight
		{
			get
			{
				return this.m_currentHeelLocalHeight * this.m_currentHeelEscala;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001BF RID: 447 RVA: 0x000098DC File Offset: 0x00007ADC
		public float currentToeWorldHeight
		{
			get
			{
				return this.m_currentToeLocalHeight * this.m_currentToeEscala;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x000098EB File Offset: 0x00007AEB
		public float currentHeelWorldTotalHeight
		{
			get
			{
				return (this.m_currentHeelLocalHeight + this.m_defaultHeelHeight) * this.m_currentHeelEscala;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00009901 File Offset: 0x00007B01
		public float currentToeWorldTotalHeight
		{
			get
			{
				return (this.m_currentToeLocalHeight + this.m_defaultToeHeight) * this.m_currentToeEscala;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00009917 File Offset: 0x00007B17
		public float currentRealHeelWorldHeight
		{
			get
			{
				return this.m_realHeelLocalHeight * this.m_currentHeelEscala;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00009926 File Offset: 0x00007B26
		public float currentRealToeWorldHeight
		{
			get
			{
				return this.m_realToeLocalHeight * this.m_currentToeEscala;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00009935 File Offset: 0x00007B35
		public float currentRealHeelLocalHeight
		{
			get
			{
				return this.m_realHeelLocalHeight;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x0000993D File Offset: 0x00007B3D
		public float currentRealToeLocalHeight
		{
			get
			{
				return this.m_realToeLocalHeight;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00009945 File Offset: 0x00007B45
		public float currentRealHeelWorldTotalHeight
		{
			get
			{
				return this.currentRealHeelLocalTotalHeight * this.m_currentHeelEscala;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00009954 File Offset: 0x00007B54
		public float currentRealToeWorldTotalHeight
		{
			get
			{
				return this.currentRealToeLocalTotalHeight * this.m_currentToeEscala;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00009963 File Offset: 0x00007B63
		public float currentRealHeelLocalTotalHeight
		{
			get
			{
				return this.m_realHeelLocalHeight + this.m_defaultHeelHeight;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00009972 File Offset: 0x00007B72
		public float currentRealToeLocalTotalHeight
		{
			get
			{
				return this.m_realToeLocalHeight + this.m_defaultToeHeight;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001CA RID: 458 RVA: 0x00009981 File Offset: 0x00007B81
		public GrounderFBBIK grounderFBBIK
		{
			get
			{
				return this.m_GrounderFBBIK;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00009989 File Offset: 0x00007B89
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00009996 File Offset: 0x00007B96
		private IToesIKEffector toesIKEffectors
		{
			get
			{
				return this.m_toesIKEffectors as IToesIKEffector;
			}
			set
			{
				this.m_toesIKEffectors = value as Object;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001CD RID: 461 RVA: 0x000099A4 File Offset: 0x00007BA4
		public Vector3 interactionPelvisUpWorldOffset
		{
			get
			{
				return this.m_interactionPelvisUpWorldOffset;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001CE RID: 462 RVA: 0x000099AC File Offset: 0x00007BAC
		public Vector3 interactionFootRUpWorldOffset
		{
			get
			{
				return this.m_interactionFootRUpWorldOffset;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001CF RID: 463 RVA: 0x000099B4 File Offset: 0x00007BB4
		public Vector3 interactionFootLUpWorldOffset
		{
			get
			{
				return this.m_interactionFootLUpWorldOffset;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x000099BC File Offset: 0x00007BBC
		public Transform heelL
		{
			get
			{
				return this.m_heelL;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x000099C4 File Offset: 0x00007BC4
		public Transform heelR
		{
			get
			{
				return this.m_heelR;
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x000099CC File Offset: 0x00007BCC
		public Transform toeL
		{
			get
			{
				return this.m_toeL;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x000099D4 File Offset: 0x00007BD4
		public Transform toeR
		{
			get
			{
				return this.m_toeR;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x000099DC File Offset: 0x00007BDC
		public ModificableDeFloat heelHeight
		{
			get
			{
				return this.m_heelHeight;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x000099E4 File Offset: 0x00007BE4
		public ModificableDeFloat toeHeight
		{
			get
			{
				return this.m_toeHeight;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x000099EC File Offset: 0x00007BEC
		public ModificableDeFloat heelPoseWeight
		{
			get
			{
				return this.m_heelPoseWeight;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x000099F4 File Offset: 0x00007BF4
		public ModificableDeFloat toePoseWeight
		{
			get
			{
				return this.m_toePoseWeight;
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000099FC File Offset: 0x00007BFC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_GrounderFBBIK == null)
			{
				throw new ArgumentNullException("m_GrounderFBBIK", "m_GrounderFBBIK null reference.");
			}
			if (this.m_InteractionSystemV3 == null)
			{
				throw new ArgumentNullException("m_InteractionSystemV3", "m_InteractionSystemV3 null reference.");
			}
			if (this.m_FullBodyBipedIK == null)
			{
				throw new ArgumentNullException("m_FullBodyBipedIK", "m_FullBodyBipedIK null reference.");
			}
			if (this.toesIKEffectors == null)
			{
				throw new ArgumentNullException("toesIKEffectors", "toesIKEffectors null reference.");
			}
			this.m_GrounderFBBIK.solver.rotateSolver = true;
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_ikUpdater = this.GetComponentEnRoot(false);
			if (this.m_ikUpdater == null)
			{
				throw new ArgumentNullException("m_ikUpdater", "m_ikUpdater null reference.");
			}
			Animator bodyAnimator = this.m_character.bodyAnimator;
			this.m_toeL = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.ToeBase_L, bodyAnimator);
			this.m_toeR = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.ToeBase_R, bodyAnimator);
			this.m_heelL = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.Foot_L, bodyAnimator);
			this.m_heelR = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.Foot_R, bodyAnimator);
			this.m_calfL = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.Calf_L, bodyAnimator);
			this.m_calfR = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.Calf_R, bodyAnimator);
			this.m_defaultLocalUpdirectionFromCalfL = this.m_calfL.InverseTransformDirection(this.m_FullBodyBipedIK.references.root.up);
			this.m_defaultLocalUpdirectionFromCalfR = this.m_calfR.InverseTransformDirection(this.m_FullBodyBipedIK.references.root.up);
			this.m_defaultLocalUpdirectionFromHeelL = this.m_heelL.InverseTransformDirection(this.m_FullBodyBipedIK.references.root.up);
			this.m_defaultLocalUpdirectionFromHeelR = this.m_heelR.InverseTransformDirection(this.m_FullBodyBipedIK.references.root.up);
			this.m_defaultLocalUpdirectionFromToeL = this.m_toeL.InverseTransformDirection(this.m_FullBodyBipedIK.references.root.up);
			this.m_defaultLocalUpdirectionFromToeR = this.m_toeR.InverseTransformDirection(this.m_FullBodyBipedIK.references.root.up);
			this.m_defaultLocalRightdirectionFromHeelL = this.m_heelL.InverseTransformDirection(this.m_FullBodyBipedIK.references.root.right);
			this.m_defaultLocalRightdirectionFromHeelR = this.m_heelR.InverseTransformDirection(this.m_FullBodyBipedIK.references.root.right);
			this.m_defaultLocalRotationHeelL = Quaternion.Inverse(this.m_calfL.rotation) * this.m_heelL.rotation;
			this.m_defaultLocalRotationHeelR = Quaternion.Inverse(this.m_calfR.rotation) * this.m_heelR.rotation;
			this.m_defaultLocalRotationToeL = Quaternion.Inverse(this.m_heelL.rotation) * this.m_toeL.rotation;
			this.m_defaultLocalRotationToeR = Quaternion.Inverse(this.m_heelR.rotation) * this.m_toeR.rotation;
			this.m_defaultLocalPositionHeelL = this.m_calfL.InverseTransformPoint(this.m_heelL.position);
			this.m_defaultLocalPositionHeelR = this.m_calfR.InverseTransformPoint(this.m_heelR.position);
			this.m_defaultLocalPositionToeL = this.m_calfL.InverseTransformPoint(this.m_toeL.position);
			this.m_defaultLocalPositionToeR = this.m_calfR.InverseTransformPoint(this.m_toeR.position);
			this.m_defaultLocalRotationHeelToToeFromCalfL = Quaternion.Inverse(this.m_calfL.rotation) * Quaternion.LookRotation(Math3d.ProjectPointOnPlane(this.m_FullBodyBipedIK.references.root.right, this.m_heelL.position, this.m_toeL.position) - this.m_heelL.position, this.m_FullBodyBipedIK.references.root.up);
			this.m_defaultLocalRotationHeelToToeFromCalfR = Quaternion.Inverse(this.m_calfR.rotation) * Quaternion.LookRotation(Math3d.ProjectPointOnPlane(this.m_FullBodyBipedIK.references.root.right, this.m_heelR.position, this.m_toeR.position) - this.m_heelR.position, this.m_FullBodyBipedIK.references.root.up);
			this.m_defaultRightAxisRotationHeelL = this.m_defaultLocalRotationHeelL.eulerAngles.x;
			this.m_defaultRightAxisRotationHeelR = this.m_defaultLocalRotationHeelR.eulerAngles.x;
			this.m_localPositionVirtualHeelL = this.m_heelL.InverseTransformPoint(this.m_heelL.position + -bodyAnimator.transform.up * this.m_defaultHeelHeight);
			this.m_localPositionVirtualHeelR = this.m_heelR.InverseTransformPoint(this.m_heelR.position + -bodyAnimator.transform.up * this.m_defaultHeelHeight);
			this.m_localPositionVirtualToeL = this.m_toeL.InverseTransformPoint(this.m_toeL.position + -bodyAnimator.transform.up * this.m_defaultToeHeight);
			this.m_localPositionVirtualToeR = this.m_toeR.InverseTransformPoint(this.m_toeR.position + -bodyAnimator.transform.up * this.m_defaultToeHeight);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00009FC8 File Offset: 0x000081C8
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.UpdateHeight();
			this.m_ikUpdater.SortedIKsDeLayer(0);
			if (this.m_otherFemaleHighHeelSystem == null)
			{
				throw new ArgumentNullException("m_otherFemaleHighHeelSystem", "m_otherFemaleHighHeelSystem null reference.");
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000A001 File Offset: 0x00008201
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_InteractionSystemV3.interacted += this.InteractionSystemUpdated;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000A020 File Offset: 0x00008220
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_InteractionSystemV3 != null)
			{
				this.m_InteractionSystemV3.interacted -= this.InteractionSystemUpdated;
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000A050 File Offset: 0x00008250
		public void UpdateEscalas()
		{
			this.m_currentHeelEscala = (this.m_heelR.lossyScale.Escala() + this.m_heelL.lossyScale.Escala()) / 2f;
			this.m_currentToeEscala = (this.m_toeR.lossyScale.Escala() + this.m_toeL.lossyScale.Escala()) / 2f;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000A0B8 File Offset: 0x000082B8
		public void UpdateHeight()
		{
			this.UpdateEscalas();
			Quaternion rotation = this.m_heelL.rotation;
			Quaternion rotation2 = this.m_heelR.rotation;
			Quaternion rotation3 = this.m_toeL.rotation;
			Quaternion rotation4 = this.m_toeR.rotation;
			Vector3 position = this.m_heelL.position;
			Vector3 position2 = this.m_heelR.position;
			Vector3 position3 = this.m_toeL.position;
			Vector3 position4 = this.m_toeR.position;
			this.m_realHeelLocalHeight = this.m_currentHeelLocalHeight;
			this.m_realToeLocalHeight = this.m_currentToeLocalHeight;
			for (int i = 0; i < 1; i++)
			{
				this.m_heelL.SetPositionAndRotation(this.m_calfL.TransformPoint(this.m_defaultLocalPositionHeelL), this.m_calfL.rotation * this.m_defaultLocalRotationHeelL);
				this.m_heelR.SetPositionAndRotation(this.m_calfR.TransformPoint(this.m_defaultLocalPositionHeelR), this.m_calfR.rotation * this.m_defaultLocalRotationHeelR);
				this.m_toeL.SetPositionAndRotation(this.m_calfL.TransformPoint(this.m_defaultLocalPositionToeL), this.m_heelL.rotation * this.m_defaultLocalRotationToeL);
				this.m_toeR.SetPositionAndRotation(this.m_calfR.TransformPoint(this.m_defaultLocalPositionToeR), this.m_heelR.rotation * this.m_defaultLocalRotationToeR);
				FemaleHighHeelSystem.CalculeAnimationMinOffsets(this.m_calfL, this.m_heelL, this.m_toeL, this.m_defaultLocalUpdirectionFromCalfL, this.m_defaultLocalRightdirectionFromHeelL, this.m_defaultLocalRotationHeelToToeFromCalfL, this.m_defaultLocalPositionHeelL, this.m_defaultLocalPositionToeL, this.m_defaultLocalRotationHeelL, this.m_defaultLocalRotationToeL, this.m_realHeelLocalHeight, this.m_realToeLocalHeight, this.m_currentHeelEscala, this.m_currentToeEscala, out this.m_minAnimationRotationAngleOffsetRightAxisHeelL, out this.m_animationOffsetHeelL, out this.m_HighHeelsLocalDirectionFromHeelL, out this.m_HighToesLocalDirectionFromHeelL);
				FemaleHighHeelSystem.CalculeAnimationMinOffsets(this.m_calfR, this.m_heelR, this.m_toeR, this.m_defaultLocalUpdirectionFromCalfR, this.m_defaultLocalRightdirectionFromHeelR, this.m_defaultLocalRotationHeelToToeFromCalfR, this.m_defaultLocalPositionHeelR, this.m_defaultLocalPositionToeR, this.m_defaultLocalRotationHeelR, this.m_defaultLocalRotationToeR, this.m_realHeelLocalHeight, this.m_realToeLocalHeight, this.m_currentHeelEscala, this.m_currentToeEscala, out this.m_minAnimationRotationAngleOffsetRightAxisHeelR, out this.m_animationOffsetHeelR, out this.m_HighHeelsLocalDirectionFromHeelR, out this.m_HighToesLocalDirectionFromHeelR);
				FemaleHighHeelSystem.CalculeHeelAndToeRotationAndHeightOffset(this.currentRealHeelWorldHeight, this.m_FullBodyBipedIK.references.root, this.m_calfL, this.m_calfR, this.m_heelL, this.m_heelR, this.m_toeL, this.m_toeR, this.m_animationOffsetHeelL, this.m_animationOffsetHeelR, this.m_defaultLocalUpdirectionFromCalfL, this.m_defaultLocalUpdirectionFromCalfR, out this.m_CalculedHeelRotationL, out this.m_CalculedToeRotationL, out this.m_CalculedHeelRotationR, out this.m_CalculedToeRotationR, out this.m_heightOffsetHeelL, out this.m_heightOffsetHeelR);
				FemaleHighHeelSystem.SetHeelAndToePoseRotation(1f, 1f, this.m_CalculedHeelRotationL, this.m_CalculedToeRotationL, this.m_heelL, this.m_toeL);
				FemaleHighHeelSystem.SetHeelAndToePoseRotation(1f, 1f, this.m_CalculedHeelRotationR, this.m_CalculedToeRotationR, this.m_heelR, this.m_toeR);
				float num;
				FemaleHighHeelSystem.CalculeCurrentHeight(this.m_calfL, this.m_heelL, this.m_toeL, this.m_localPositionVirtualHeelL, this.m_localPositionVirtualToeL, this.m_defaultLocalUpdirectionFromToeL, this.m_currentHeelEscala, out num, out this.m_VirtualHighHeelsLocalDirectionFromHeelL, out this.m_VirtualHighToesLocalDirectionFromHeelL);
				float num2;
				FemaleHighHeelSystem.CalculeCurrentHeight(this.m_calfR, this.m_heelR, this.m_toeR, this.m_localPositionVirtualHeelR, this.m_localPositionVirtualToeR, this.m_defaultLocalUpdirectionFromToeR, this.m_currentHeelEscala, out num2, out this.m_VirtualHighHeelsLocalDirectionFromHeelR, out this.m_VirtualHighToesLocalDirectionFromHeelR);
				float num3 = Mathf.InverseLerp(0f, num, this.currentHeelLocalHeight);
				float num4 = Mathf.InverseLerp(0f, num2, this.currentHeelLocalHeight);
				this.m_realHeelLocalHeight *= (num3 + num4) / 2f;
			}
			this.m_heelL.SetPositionAndRotation(position, rotation);
			this.m_heelR.SetPositionAndRotation(position2, rotation2);
			this.m_toeL.SetPositionAndRotation(position3, rotation3);
			this.m_toeR.SetPositionAndRotation(position4, rotation4);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000A4C4 File Offset: 0x000086C4
		private static void CalculeCurrentHeight(Transform calf, Transform heel, Transform toe, Vector3 localPositionVirtualHeel, Vector3 localPositionVirtualToe, Vector3 toeLocalUp, float heelScale, out float currentHeight, out Vector3 virtualHighHeelsLocalDirectionFromHeel, out Vector3 virtualHighToeLocalDirectionFromHeel)
		{
			Vector3 vector = heel.TransformPoint(localPositionVirtualHeel);
			Vector3 vector2 = toe.TransformPoint(localPositionVirtualToe);
			Vector3 vector3 = Math3d.ProjectPointOnPlane(toe.TransformDirection(toeLocalUp), vector2, vector);
			currentHeight = Vector3.Distance(vector, vector3) / heelScale;
			virtualHighToeLocalDirectionFromHeel = heel.InverseTransformDirection(vector2 - heel.position).normalized;
			virtualHighHeelsLocalDirectionFromHeel = heel.InverseTransformDirection(vector3 - heel.position).normalized;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000A544 File Offset: 0x00008744
		private static void CalculeAnimationMinOffsets(Transform calf, Transform heel, Transform toe, Vector3 calfLocalUp, Vector3 heelLocalRight, Quaternion localRotationHeelToToeFromCalf, Vector3 defaultLocalHeelPosition, Vector3 defaultLocalToePosition, Quaternion defaultLocalHeelRotation, Quaternion defaultLocalToeRotation, float heelLocalHeight, float toeLocalHeight, float heelEscala, float ToeEscala, out float minAngleOffsetHeel, out Quaternion animationOffsetHeel, out Vector3 highHeelsLocalDirectionFromHeel, out Vector3 highToesLocalDirectionFromHeel)
		{
			Vector3 vector = calf.TransformDirection(calfLocalUp);
			Quaternion quaternion = calf.rotation * defaultLocalHeelRotation;
			quaternion * defaultLocalToeRotation;
			Vector3 vector2 = calf.TransformPoint(defaultLocalHeelPosition);
			Vector3 vector3 = calf.TransformPoint(defaultLocalToePosition);
			float magnitude = (vector3 - vector2).magnitude;
			float num = heelEscala * heelLocalHeight;
			num = Mathf.Clamp(num, 0f, 1f);
			float num2 = ToeEscala * toeLocalHeight;
			num2 = Mathf.Clamp(num2, 0f, num);
			Vector3 vector4 = quaternion * heelLocalRight;
			Vector3 vector5 = vector2 + vector * num;
			Vector3 vector6 = vector3 + vector * num2;
			for (int i = 0; i < 10; i++)
			{
				Vector3 vector7 = vector6 - vector5;
				vector7 = vector7.SetMagnitud(magnitude);
				vector6 = vector5 + vector7;
				vector3 = Math3d.ProjectPointOnPlane(vector, vector3, vector6);
				vector6 = vector3 + vector * num2;
			}
			Vector3 vector8 = Math3d.ProjectPointOnPlane(vector4, vector2, vector6);
			Quaternion quaternion2 = calf.rotation * localRotationHeelToToeFromCalf;
			Quaternion quaternion3 = Quaternion.LookRotation(vector8 - vector5, vector);
			animationOffsetHeel = Quaternion.Inverse(quaternion3) * quaternion2;
			Quaternion quaternion4 = quaternion * animationOffsetHeel;
			highHeelsLocalDirectionFromHeel = Math3d.InverseTransformDirectionMath(quaternion4, -vector).normalized;
			highToesLocalDirectionFromHeel = Math3d.InverseTransformDirectionMath(quaternion4, -vector).normalized;
			minAngleOffsetHeel = Quaternion.Angle(quaternion2, quaternion3);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000A6CD File Offset: 0x000088CD
		public void ResetHeight()
		{
			this.m_currentHeelLocalHeight = 0f;
			this.m_currentToeLocalHeight = 0f;
			this.UpdateHeight();
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000A6EB File Offset: 0x000088EB
		public void SetHeight(float toeLocalHeight, float heelLocalHeight, float toePoseWeight, float heelPoseWeight)
		{
			this.m_currentHeelLocalHeight = heelLocalHeight;
			this.m_currentToeLocalHeight = toeLocalHeight;
			this.m_currentHeelPoseWeight = heelPoseWeight;
			this.m_currentToePoseWeight = toePoseWeight;
			this.UpdateHeight();
			Action<FemaleHighHeelSystem> action = this.highHeelHeightUpdated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000A721 File Offset: 0x00008921
		public Vector3 GetDownDirectionFromHeelsR()
		{
			return Vector3.Slerp(this.m_animationDownDirectionFromHeelR, this.m_heelR.TransformDirection(this.m_HighHeelsLocalDirectionFromHeelR), this.m_currentHeelPoseWeight);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000A745 File Offset: 0x00008945
		public Vector3 GetDownDirectionFromHeelsL()
		{
			return Vector3.Slerp(this.m_animationDownDirectionFromHeelL, this.m_heelL.TransformDirection(this.m_HighHeelsLocalDirectionFromHeelL), this.m_currentHeelPoseWeight);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000A769 File Offset: 0x00008969
		public Vector3 GetDownDirectionFromToesR()
		{
			return Vector3.Slerp(this.m_animationDownDirectionFromToeR, this.m_heelR.TransformDirection(this.m_HighToesLocalDirectionFromHeelR), this.m_currentHeelPoseWeight);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000A78D File Offset: 0x0000898D
		public Vector3 GetDownDirectionFromToesL()
		{
			return Vector3.Slerp(this.m_animationDownDirectionFromToeL, this.m_heelL.TransformDirection(this.m_HighToesLocalDirectionFromHeelL), this.m_currentHeelPoseWeight);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000A7B1 File Offset: 0x000089B1
		public Vector3 GetVirtualDownDirectionFromHeelL()
		{
			return Vector3.Slerp(this.m_animationDownDirectionFromHeelL, this.m_heelL.TransformDirection(this.m_VirtualHighHeelsLocalDirectionFromHeelL), this.m_currentHeelPoseWeight);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000A7D5 File Offset: 0x000089D5
		public Vector3 GetVirtualDownDirectionFromHeelR()
		{
			return Vector3.Slerp(this.m_animationDownDirectionFromHeelR, this.m_heelR.TransformDirection(this.m_VirtualHighHeelsLocalDirectionFromHeelR), this.m_currentHeelPoseWeight);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000A7F9 File Offset: 0x000089F9
		public Vector3 GetVirtualDownDirectionFromToeL()
		{
			return Vector3.Slerp(this.m_animationDownDirectionFromToeL, this.m_heelL.TransformDirection(this.m_VirtualHighToesLocalDirectionFromHeelL), this.m_currentHeelPoseWeight);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000A81D File Offset: 0x00008A1D
		public Vector3 GetVirtualDownDirectionFromToeR()
		{
			return Vector3.Slerp(this.m_animationDownDirectionFromToeR, this.m_heelR.TransformDirection(this.m_VirtualHighToesLocalDirectionFromHeelR), this.m_currentHeelPoseWeight);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000A844 File Offset: 0x00008A44
		public override void OnUpdateEvent1()
		{
			this.m_animationDownDirectionFromToeL = this.m_toeL.TransformDirection(-this.m_defaultLocalUpdirectionFromToeL);
			this.m_animationDownDirectionFromHeelL = this.m_heelL.TransformDirection(-this.m_defaultLocalUpdirectionFromHeelL);
			this.m_animationDownDirectionFromToeR = this.m_toeR.TransformDirection(-this.m_defaultLocalUpdirectionFromToeR);
			this.m_animationDownDirectionFromHeelR = this.m_heelR.TransformDirection(-this.m_defaultLocalUpdirectionFromHeelR);
			InteractionEffectorV2 interactionEffectorV;
			bool flag = this.m_InteractionSystemV3.EstaInteractuandoConV2(FullBodyBipedEffector.Body, out interactionEffectorV);
			InteractionEffectorV2 interactionEffectorV2;
			bool flag2 = this.m_InteractionSystemV3.EstaInteractuandoConV2(FullBodyBipedEffector.LeftFoot, out interactionEffectorV2);
			InteractionEffectorV2 interactionEffectorV3;
			bool flag3 = this.m_InteractionSystemV3.EstaInteractuandoConV2(FullBodyBipedEffector.RightFoot, out interactionEffectorV3);
			InteractionEffectorV2 interactionEffectorV4;
			bool flag4 = this.m_otherFemaleHighHeelSystem.m_InteractionSystemV3.EstaInteractuandoConV2(FullBodyBipedEffector.Body, out interactionEffectorV4);
			InteractionEffectorV2 interactionEffectorV5;
			bool flag5 = this.m_otherFemaleHighHeelSystem.m_InteractionSystemV3.EstaInteractuandoConV2(FullBodyBipedEffector.LeftFoot, out interactionEffectorV5);
			InteractionEffectorV2 interactionEffectorV6;
			bool flag6 = this.m_otherFemaleHighHeelSystem.m_InteractionSystemV3.EstaInteractuandoConV2(FullBodyBipedEffector.RightFoot, out interactionEffectorV6);
			float num = this.m_otherFemaleHighHeelSystem.m_FullBodyBipedIK.solver.IKPositionWeight + this.m_FullBodyBipedIK.solver.IKPositionWeight;
			num = ((num == 0f) ? 1E-05f : num);
			this.m_weightModPorLayer = Mathf.Clamp01(1f / num) * this.m_FullBodyBipedIK.solver.IKPositionWeight;
			float num2 = Mathf.Max(interactionEffectorV.timeWeight, interactionEffectorV4.timeWeight);
			float num3 = Mathf.Max((interactionEffectorV2.timeWeight + interactionEffectorV3.timeWeight) / 2f, (interactionEffectorV5.timeWeight + interactionEffectorV6.timeWeight) / 2f);
			if (flag && !flag4)
			{
				this.m_weightModPorInteraccion = 1f;
			}
			else if (flag || flag4)
			{
				this.m_weightModPorInteraccion = 1f - MathfExtension.InverseLerpAlMedio(0f, 0.5f, 1f, num2).OutPow(6f);
			}
			else
			{
				this.m_weightModPorInteraccion = 1f;
			}
			if (flag2 && flag3 && (!flag5 || !flag6))
			{
				this.m_weightModPorInteraccion = 1f;
			}
			else if ((flag2 && flag3) || (flag5 && flag6))
			{
				this.m_weightModPorInteraccion = 1f - MathfExtension.InverseLerpAlMedio(0f, 0.5f, 1f, num3).OutPow(6f);
			}
			else
			{
				this.m_weightModPorInteraccion = 1f;
			}
			float num4 = this.weight * this.m_weightModPorLayer * this.m_weightModPorInteraccion;
			this.m_currentWeight = Mathf.MoveTowards(this.m_currentWeight, num4, Time.deltaTime * 10f);
			this.m_GrounderFBBIK.weight = this.m_grounderIkWeigthModificable.ModificarValor(num4);
			float num5;
			float num6;
			float num7;
			if (flag2)
			{
				num5 = (interactionEffectorV2.inInteractionConV2 ? (interactionEffectorV2.interactionObjectV2.highHeelPoseWeigth * this.m_currentHeelPoseWeight) : 0f);
				num6 = (interactionEffectorV2.inInteractionConV2 ? (interactionEffectorV2.interactionObjectV2.highHeelToePoseWeigth * this.m_currentToePoseWeight) : 0f);
				num7 = (interactionEffectorV2.inInteractionConV2 ? interactionEffectorV2.interactionObjectV2.highHeelPoseHeightMod : 0f);
				float num8 = MathfExtension.InverseLerpAlMedio(0f, 0.5f, 1f, interactionEffectorV2.timeWeight).InPow(2f);
				num5 *= num8;
				num6 *= num8;
				num7 *= num8;
			}
			else
			{
				num7 = 0f;
				num5 = 0f;
				num6 = 0f;
			}
			float num9;
			float num10;
			float num11;
			if (flag3)
			{
				num9 = (interactionEffectorV3.inInteractionConV2 ? (interactionEffectorV3.interactionObjectV2.highHeelPoseWeigth * this.m_currentHeelPoseWeight) : 0f);
				num10 = (interactionEffectorV3.inInteractionConV2 ? (interactionEffectorV3.interactionObjectV2.highHeelToePoseWeigth * this.m_currentToePoseWeight) : 0f);
				num11 = (interactionEffectorV3.inInteractionConV2 ? interactionEffectorV3.interactionObjectV2.highHeelPoseHeightMod : 0f);
				float num12 = MathfExtension.InverseLerpAlMedio(0f, 0.5f, 1f, interactionEffectorV3.timeWeight).InPow(2f);
				num9 *= num12;
				num10 *= num12;
				num11 *= num12;
			}
			else
			{
				num9 = 0f;
				num10 = 0f;
				num11 = 0f;
			}
			this.m_highHeelsPoseWeightOnInteractionL = Mathf.MoveTowards(this.m_highHeelsPoseWeightOnInteractionL, num5, Time.deltaTime * 4f);
			this.m_highHeelsPoseWeightOnInteractionR = Mathf.MoveTowards(this.m_highHeelsPoseWeightOnInteractionR, num9, Time.deltaTime * 4f);
			this.m_highToesPoseWeightOnInteractionL = Mathf.MoveTowards(this.m_highToesPoseWeightOnInteractionL, num6, Time.deltaTime * 4f);
			this.m_highToesPoseWeightOnInteractionR = Mathf.MoveTowards(this.m_highToesPoseWeightOnInteractionR, num10, Time.deltaTime * 4f);
			this.m_highHeelPoseHeightModOnInteractionR = Mathf.MoveTowards(this.m_highHeelPoseHeightModOnInteractionR, num11, Time.deltaTime * 4f);
			this.m_highHeelPoseHeightModOnInteractionL = Mathf.MoveTowards(this.m_highHeelPoseHeightModOnInteractionL, num7, Time.deltaTime * 4f);
			float num13;
			float num14;
			if (flag3 || flag2)
			{
				num13 = (interactionEffectorV.inInteractionConV2 ? interactionEffectorV.interactionObjectV2.highHeelPoseWeigth : 0f);
				num14 = (interactionEffectorV.inInteractionConV2 ? interactionEffectorV.interactionObjectV2.highHeelPoseHeightMod : 0f);
				float num15 = MathfExtension.InverseLerpAlMedio(0f, 0.5f, 1f, interactionEffectorV.timeWeight).InPow(2f);
				num13 *= num15;
				num14 *= num15;
			}
			else
			{
				num13 = 0f;
				num14 = 0f;
			}
			this.m_highHeelPoseWeightOnInteractionPelvis = Mathf.MoveTowards(this.m_highHeelPoseWeightOnInteractionPelvis, num13, Time.deltaTime * 4f);
			this.m_highHeelPoseHeightModOnInteractionPelvis = Mathf.MoveTowards(this.m_highHeelPoseHeightModOnInteractionPelvis, num14, Time.deltaTime * 4f);
			Vector3 up = this.m_FullBodyBipedIK.references.root.up;
			Vector3 centerOfMassPosition = this.m_character.centerOfMassPosition;
			Vector3 vector = (this.m_heelL.position + this.m_heelR.position + this.m_toeL.position + this.m_toeR.position) / 4f + this.m_character.centerOfMassVelocity * this.config.velocityMod;
			float num16 = Vector3.Angle(centerOfMassPosition - vector, up);
			this.m_pelvisToFeetWeight = Mathf.InverseLerp(this.config.startAngle, this.config.endAngle, num16).InPow(2f);
			if (this.currentRealHeelWorldHeight <= 0f)
			{
				this.m_heightOffsetHeelL = 0f;
				this.m_heightOffsetHeelR = 0f;
			}
			else
			{
				FemaleHighHeelSystem.CalculeHeelAndToeRotationAndHeightOffset(this.currentRealHeelWorldHeight, this.m_FullBodyBipedIK.references.root, this.m_calfL, this.m_calfR, this.m_heelL, this.m_heelR, this.m_toeL, this.m_toeR, this.m_animationOffsetHeelL, this.m_animationOffsetHeelR, this.m_defaultLocalUpdirectionFromCalfL, this.m_defaultLocalUpdirectionFromCalfR, out this.m_CalculedHeelRotationL, out this.m_CalculedToeRotationL, out this.m_CalculedHeelRotationR, out this.m_CalculedToeRotationR, out this.m_heightOffsetHeelL, out this.m_heightOffsetHeelR);
				if (this.m_currentWeight > 0f)
				{
					FemaleHighHeelSystem.SetHeelAndToePoseRotation(this.m_currentWeight * this.m_currentHeelPoseWeight, 1f * this.m_currentToePoseWeight, this.m_CalculedHeelRotationL, this.m_CalculedToeRotationL, this.m_heelL, this.m_toeL);
					FemaleHighHeelSystem.SetHeelAndToePoseRotation(this.m_currentWeight * this.m_currentHeelPoseWeight, 1f * this.m_currentToePoseWeight, this.m_CalculedHeelRotationR, this.m_CalculedToeRotationR, this.m_heelR, this.m_toeR);
				}
			}
			float num17 = Mathf.Max(this.m_heightOffsetHeelL, this.m_heightOffsetHeelR);
			this.m_GrounderFBBIK.solver.heightOffset = Mathf.Lerp(num17 * this.config.noInteractionHeelsUpBonus, 0f, this.m_pelvisToFeetWeight) * this.m_currentWeight.OutPow(1.6f);
			if (this.m_pelvisToFeetWeight > 0f && this.m_currentWeight > 0f)
			{
				Vector3 vector2 = up * this.m_heightOffsetHeelR * this.config.noInteractionHeelsUpBonus;
				FemaleHighHeelSystem.SetEffectorPosition(this.m_FullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.RightFoot), Vector3.Lerp(Vector3.zero, vector2, this.m_pelvisToFeetWeight));
				Vector3 vector3 = up * this.m_heightOffsetHeelL * this.config.noInteractionHeelsUpBonus;
				FemaleHighHeelSystem.SetEffectorPosition(this.m_FullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.LeftFoot), Vector3.Lerp(Vector3.zero, vector3, this.m_pelvisToFeetWeight));
			}
			Action<FemaleHighHeelSystem> action = this.highHeelUpdated;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000B0B4 File Offset: 0x000092B4
		private void InteractionSystemUpdated(InteractionSystemV3 obj)
		{
			if (this.m_highHeelsPoseWeightOnInteractionR > 0f || this.m_highToesPoseWeightOnInteractionR > 0f)
			{
				Vector3 vector = this.m_calfR.TransformDirection(this.m_defaultLocalUpdirectionFromCalfR) * (this.m_heightOffsetHeelR * this.config.inInteractionHeelsUpBonus * this.m_highHeelPoseHeightModOnInteractionR);
				IKEffector effector = this.m_FullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.RightFoot);
				FemaleHighHeelSystem.SetEffectorPosition(effector, Vector3.Lerp(Vector3.zero, vector, this.m_highHeelsPoseWeightOnInteractionR));
				FemaleHighHeelSystem.SetEffectorRotation(this.m_highHeelsPoseWeightOnInteractionR, this.m_highToesPoseWeightOnInteractionR, effector, this.toesIKEffectors.derecho, this.m_animationOffsetHeelR, this.m_defaultLocalRotationToeR, this.m_heelR, this.m_toeR);
			}
			if (this.m_highHeelsPoseWeightOnInteractionL > 0f || this.m_highToesPoseWeightOnInteractionL > 0f)
			{
				Vector3 vector2 = this.m_calfL.TransformDirection(this.m_defaultLocalUpdirectionFromCalfL) * (this.m_heightOffsetHeelL * this.config.inInteractionHeelsUpBonus * this.m_highHeelPoseHeightModOnInteractionL);
				IKEffector effector2 = this.m_FullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.LeftFoot);
				FemaleHighHeelSystem.SetEffectorPosition(effector2, Vector3.Lerp(Vector3.zero, vector2, this.m_highHeelsPoseWeightOnInteractionL));
				FemaleHighHeelSystem.SetEffectorRotation(this.m_highHeelsPoseWeightOnInteractionL, this.m_highToesPoseWeightOnInteractionL, effector2, this.toesIKEffectors.izquierdo, this.m_animationOffsetHeelL, this.m_defaultLocalRotationToeL, this.m_heelL, this.m_toeL);
			}
			if (this.m_highHeelPoseWeightOnInteractionPelvis > 0f)
			{
				Vector3 vector3 = this.m_calfR.TransformDirection(this.m_defaultLocalUpdirectionFromCalfR);
				Vector3 vector4 = this.m_calfL.TransformDirection(this.m_defaultLocalUpdirectionFromCalfL);
				Vector3 vector5 = (vector3 + vector4).normalized * (Mathf.Max(this.m_heightOffsetHeelL, this.m_heightOffsetHeelR) * this.config.inInteractionHeelsUpBonus * this.m_highHeelPoseHeightModOnInteractionPelvis);
				IKEffector effector3 = this.m_FullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.Body);
				IKEffector effector4 = this.m_FullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.LeftThigh);
				IKEffector effector5 = this.m_FullBodyBipedIK.solver.GetEffector(FullBodyBipedEffector.RightThigh);
				this.m_interactionPelvisUpWorldOffset = Vector3.Lerp(Vector3.zero, vector5, this.m_highHeelPoseWeightOnInteractionPelvis);
				FemaleHighHeelSystem.SetEffectorPosition(effector3, this.m_interactionPelvisUpWorldOffset);
				FemaleHighHeelSystem.SetEffectorPosition(effector4, this.m_interactionPelvisUpWorldOffset);
				FemaleHighHeelSystem.SetEffectorPosition(effector5, this.m_interactionPelvisUpWorldOffset);
			}
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000B2FC File Offset: 0x000094FC
		private static void SetEffectorPosition(IKEffector effector, Vector3 worldOffset)
		{
			effector.positionOffset += worldOffset;
			if (effector.positionWeight <= 0f)
			{
				return;
			}
			Vector3 vector = Vector3.Lerp(Vector3.zero, worldOffset, effector.positionWeight);
			effector.position += vector;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000B350 File Offset: 0x00009550
		private static void SetEffectorRotation(float heelW, float toeW, IKEffector HeelEffector, IToeIKEffector toeEffector, Quaternion worldOffset, Quaternion toeOffset, Transform heel, Transform toe)
		{
			toeEffector.rotation = Quaternion.Slerp(toeEffector.rotation, heel.rotation * toeOffset, toeW);
			float num = 1f - toeEffector.rotationWeight;
			HeelEffector.rotation *= Quaternion.Slerp(Quaternion.identity, worldOffset, heelW);
			FemaleHighHeelSystem.SetHeelAndToePoseRotation((1f - HeelEffector.rotationWeight) * heelW, num * toeW, heel.rotation * worldOffset, heel.rotation * Quaternion.Inverse(worldOffset) * toeOffset, heel, toe);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000B3EC File Offset: 0x000095EC
		private static void CalculeHeelAndToeRotationAndHeightOffset(float currentRealHeelWorldHeight, Transform root, Transform calfL, Transform calfR, Transform heelL, Transform heelR, Transform toeL, Transform toeR, Quaternion animationOffsetHeelL, Quaternion animationOffsetHeelR, Vector3 defaultLocalUpdirectionFromCalfL, Vector3 defaultLocalUpdirectionFromCalfR, out Quaternion heelRotationL, out Quaternion toeRotationL, out Quaternion heelRotationR, out Quaternion toeRotationR, out float heightOffsetL, out float heightOffsetR)
		{
			FemaleHighHeelSystem.CalculeHeelAndToeRotation(root, calfL, heelL, toeL, animationOffsetHeelL, defaultLocalUpdirectionFromCalfL, currentRealHeelWorldHeight, out heelRotationL, out toeRotationL, out heightOffsetL);
			FemaleHighHeelSystem.CalculeHeelAndToeRotation(root, calfR, heelR, toeR, animationOffsetHeelR, defaultLocalUpdirectionFromCalfR, currentRealHeelWorldHeight, out heelRotationR, out toeRotationR, out heightOffsetR);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000B428 File Offset: 0x00009628
		private static void CalculeHeelAndToeRotation(Transform root, Transform calf, Transform heel, Transform toe, Quaternion animRotationOffset, Vector3 calfLocalUp, float currentWorldHeight, out Quaternion heelRotation, out Quaternion toeRotation, out float heightOffset)
		{
			toeRotation = toe.rotation;
			heelRotation = heel.rotation * animRotationOffset;
			Vector3 vector = calf.TransformDirection(calfLocalUp) * currentWorldHeight;
			Vector3 up = root.up;
			heightOffset = Vector3.Project(vector, up).magnitude;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000B47D File Offset: 0x0000967D
		private static void SetHeelAndToePoseRotation(float highHeelPoseWeight, float highToePoseWeight, Quaternion heelRotation, Quaternion toeRotation, Transform heel, Transform toe)
		{
			heel.rotation = Quaternion.Slerp(heel.rotation, heelRotation, highHeelPoseWeight);
			toe.rotation = Quaternion.Slerp(toe.rotation, toeRotation, highToePoseWeight);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000B4AC File Offset: 0x000096AC
		public override void OnUpdateEvent2()
		{
			this.UpdateEscalas();
			float num = this.m_heelHeight.AdicinarValorIncluyendo(this.m_DebugHeelLocalHeight);
			float num2 = this.m_toeHeight.AdicinarValorIncluyendo(this.m_DebugToeLocalHeight);
			float num3 = this.m_heelPoseWeight.ModificarValor(this.m_DebugHeelPoseWeight);
			float num4 = this.m_toePoseWeight.ModificarValor(this.m_DebugToePoseWeight);
			if (num != this.m_currentHeelLocalHeight || num2 != this.m_currentToeLocalHeight || num3 != this.m_currentHeelPoseWeight || num4 != this.m_currentToePoseWeight)
			{
				this.SetHeight(num2, num, num4, num3);
			}
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000B538 File Offset: 0x00009738
		private void OnDrawGizmosSelected()
		{
			if (!Application.isPlaying || !base.isStared)
			{
				return;
			}
			DebugExtension.DrawArrow(this.m_heelL.position, this.m_heelL.TransformDirection(this.m_HighHeelsLocalDirectionFromHeelL * this.currentHeelWorldTotalHeight * 1.01f), Color.green);
			DebugExtension.DrawArrow(this.m_heelR.position, this.m_heelR.TransformDirection(this.m_HighHeelsLocalDirectionFromHeelR * this.currentHeelWorldTotalHeight * 1.01f), Color.green);
			DebugExtension.DrawArrow(this.m_toeL.position, this.m_heelL.TransformDirection(this.m_HighToesLocalDirectionFromHeelL * this.currentToeWorldTotalHeight * 1.01f), Color.green);
			DebugExtension.DrawArrow(this.m_toeR.position, this.m_heelR.TransformDirection(this.m_HighToesLocalDirectionFromHeelR * this.currentToeWorldTotalHeight * 1.01f), Color.green);
			DebugExtension.DrawArrow(this.m_heelL.position, this.GetDownDirectionFromHeelsL() * this.currentHeelWorldTotalHeight * 0.99f, Color.red);
			DebugExtension.DrawArrow(this.m_heelR.position, this.GetDownDirectionFromHeelsR() * this.currentHeelWorldTotalHeight * 0.99f, Color.red);
			DebugExtension.DrawArrow(this.m_toeL.position, this.GetDownDirectionFromToesL() * this.currentToeWorldTotalHeight * 0.99f, Color.red);
			DebugExtension.DrawArrow(this.m_toeR.position, this.GetDownDirectionFromToesR() * this.currentToeWorldTotalHeight * 0.99f, Color.red);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000B701 File Offset: 0x00009901
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Calcule Default Height",
				playTimeVisible = false
			};
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000B71C File Offset: 0x0000991C
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			ICharacter componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			Animator bodyAnimator = componentEnRoot.bodyAnimator;
			Transform transform = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.ToeBase_L, bodyAnimator);
			Transform transform2 = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.ToeBase_R, bodyAnimator);
			Transform transform3 = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.Foot_L, bodyAnimator);
			Transform transform4 = MapaSingleton<MapaSingletonDeFemaleBones>.instance.ObtenerHueso(MapaSingleton<MapaSingletonDeFemaleBones>.instance.Foot_R, bodyAnimator);
			RaycastHit raycastHit;
			Physics.Raycast(transform3.position, -bodyAnimator.transform.up, out raycastHit, 0.1f, this.m_GrounderFBBIK.solver.layers, QueryTriggerInteraction.Ignore);
			RaycastHit raycastHit2;
			Physics.Raycast(transform4.position, -bodyAnimator.transform.up, out raycastHit2, 0.1f, this.m_GrounderFBBIK.solver.layers, QueryTriggerInteraction.Ignore);
			RaycastHit raycastHit3;
			Physics.Raycast(transform.position, -bodyAnimator.transform.up, out raycastHit3, 0.1f, this.m_GrounderFBBIK.solver.layers, QueryTriggerInteraction.Ignore);
			RaycastHit raycastHit4;
			Physics.Raycast(transform2.position, -bodyAnimator.transform.up, out raycastHit4, 0.1f, this.m_GrounderFBBIK.solver.layers, QueryTriggerInteraction.Ignore);
			this.m_defaultHeelHeight = Mathf.Max(raycastHit.distance, raycastHit2.distance);
			this.m_defaultToeHeight = Mathf.Max(raycastHit3.distance, raycastHit4.distance);
		}

		// Token: 0x04000119 RID: 281
		[SerializeField]
		private ModificableDeFloat m_grounderIkWeigthModificable = new ModificableDeFloat(1f);

		// Token: 0x0400011A RID: 282
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x0400011B RID: 283
		[SerializeField]
		[ReadOnlyUI]
		private float m_weightModPorLayer = 1f;

		// Token: 0x0400011C RID: 284
		[SerializeField]
		[ReadOnlyUI]
		private float m_weightModPorInteraccion = 1f;

		// Token: 0x0400011D RID: 285
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentWeight;

		// Token: 0x0400011E RID: 286
		public FemaleHighHeelSystem.Config config = new FemaleHighHeelSystem.Config();

		// Token: 0x0400011F RID: 287
		[SerializeField]
		private GrounderFBBIK m_GrounderFBBIK;

		// Token: 0x04000120 RID: 288
		[SerializeField]
		private InteractionSystemV3 m_InteractionSystemV3;

		// Token: 0x04000121 RID: 289
		[SerializeField]
		private FullBodyBipedIK m_FullBodyBipedIK;

		// Token: 0x04000122 RID: 290
		[SerializeField]
		private FemaleHighHeelSystem m_otherFemaleHighHeelSystem;

		// Token: 0x04000123 RID: 291
		[ConstraintType(typeof(IToesIKEffector), true)]
		[SerializeField]
		private Object m_toesIKEffectors;

		// Token: 0x04000124 RID: 292
		[ReadOnlyUI]
		[SerializeField]
		private float m_highHeelsPoseWeightOnInteractionR;

		// Token: 0x04000125 RID: 293
		[ReadOnlyUI]
		[SerializeField]
		private float m_highHeelsPoseWeightOnInteractionL;

		// Token: 0x04000126 RID: 294
		[ReadOnlyUI]
		[SerializeField]
		private float m_highToesPoseWeightOnInteractionR;

		// Token: 0x04000127 RID: 295
		[ReadOnlyUI]
		[SerializeField]
		private float m_highToesPoseWeightOnInteractionL;

		// Token: 0x04000128 RID: 296
		[ReadOnlyUI]
		[SerializeField]
		private float m_highHeelPoseWeightOnInteractionPelvis;

		// Token: 0x04000129 RID: 297
		[ReadOnlyUI]
		[SerializeField]
		private float m_highHeelPoseHeightModOnInteractionR;

		// Token: 0x0400012A RID: 298
		[ReadOnlyUI]
		[SerializeField]
		private float m_highHeelPoseHeightModOnInteractionL;

		// Token: 0x0400012B RID: 299
		[ReadOnlyUI]
		[SerializeField]
		private float m_highHeelPoseHeightModOnInteractionPelvis;

		// Token: 0x0400012C RID: 300
		[ReadOnlyUI]
		[SerializeField]
		private float m_pelvisToFeetWeight;

		// Token: 0x0400012D RID: 301
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_interactionFootRUpWorldOffset;

		// Token: 0x0400012E RID: 302
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_interactionFootLUpWorldOffset;

		// Token: 0x0400012F RID: 303
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 m_interactionPelvisUpWorldOffset;

		// Token: 0x04000130 RID: 304
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentHeelLocalHeight;

		// Token: 0x04000131 RID: 305
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentToeLocalHeight;

		// Token: 0x04000132 RID: 306
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentHeelPoseWeight;

		// Token: 0x04000133 RID: 307
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentToePoseWeight;

		// Token: 0x04000134 RID: 308
		[ReadOnlyUI]
		[SerializeField]
		private float m_realHeelLocalHeight;

		// Token: 0x04000135 RID: 309
		[ReadOnlyUI]
		[SerializeField]
		private float m_realToeLocalHeight;

		// Token: 0x04000136 RID: 310
		[ReadOnlyUI]
		[SerializeField]
		private float m_heightOffsetHeelL;

		// Token: 0x04000137 RID: 311
		[ReadOnlyUI]
		[SerializeField]
		private float m_heightOffsetHeelR;

		// Token: 0x04000138 RID: 312
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_CalculedHeelRotationL;

		// Token: 0x04000139 RID: 313
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_CalculedToeRotationL;

		// Token: 0x0400013A RID: 314
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_CalculedHeelRotationR;

		// Token: 0x0400013B RID: 315
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_CalculedToeRotationR;

		// Token: 0x0400013C RID: 316
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_toeL;

		// Token: 0x0400013D RID: 317
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_toeR;

		// Token: 0x0400013E RID: 318
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_heelL;

		// Token: 0x0400013F RID: 319
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_heelR;

		// Token: 0x04000140 RID: 320
		[ReadOnlyUI]
		[SerializeField]
		private Transform m_calfL;

		// Token: 0x04000141 RID: 321
		[SerializeField]
		[ReadOnlyUI]
		private Transform m_calfR;

		// Token: 0x04000142 RID: 322
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentHeelEscala;

		// Token: 0x04000143 RID: 323
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentToeEscala;

		// Token: 0x04000144 RID: 324
		[SerializeField]
		[ReadOnlyUI]
		private float m_defaultHeelHeight;

		// Token: 0x04000145 RID: 325
		[SerializeField]
		[ReadOnlyUI]
		private float m_defaultToeHeight;

		// Token: 0x04000146 RID: 326
		private ICharacter m_character;

		// Token: 0x04000147 RID: 327
		private Vector3 m_defaultLocalUpdirectionFromCalfL;

		// Token: 0x04000148 RID: 328
		private Vector3 m_defaultLocalUpdirectionFromCalfR;

		// Token: 0x04000149 RID: 329
		private Vector3 m_defaultLocalUpdirectionFromHeelL;

		// Token: 0x0400014A RID: 330
		private Vector3 m_defaultLocalUpdirectionFromHeelR;

		// Token: 0x0400014B RID: 331
		private Vector3 m_defaultLocalUpdirectionFromToeL;

		// Token: 0x0400014C RID: 332
		private Vector3 m_defaultLocalUpdirectionFromToeR;

		// Token: 0x0400014D RID: 333
		private Quaternion m_defaultLocalRotationHeelToToeFromCalfL;

		// Token: 0x0400014E RID: 334
		private Quaternion m_defaultLocalRotationHeelToToeFromCalfR;

		// Token: 0x0400014F RID: 335
		private Vector3 m_defaultLocalRightdirectionFromHeelL;

		// Token: 0x04000150 RID: 336
		private Vector3 m_defaultLocalRightdirectionFromHeelR;

		// Token: 0x04000151 RID: 337
		private Quaternion m_defaultLocalRotationHeelL;

		// Token: 0x04000152 RID: 338
		private Quaternion m_defaultLocalRotationHeelR;

		// Token: 0x04000153 RID: 339
		private Quaternion m_defaultLocalRotationToeL;

		// Token: 0x04000154 RID: 340
		private Quaternion m_defaultLocalRotationToeR;

		// Token: 0x04000155 RID: 341
		private Vector3 m_defaultLocalPositionHeelL;

		// Token: 0x04000156 RID: 342
		private Vector3 m_defaultLocalPositionHeelR;

		// Token: 0x04000157 RID: 343
		private Vector3 m_defaultLocalPositionToeL;

		// Token: 0x04000158 RID: 344
		private Vector3 m_defaultLocalPositionToeR;

		// Token: 0x04000159 RID: 345
		private Vector3 m_animationDownDirectionFromToeL;

		// Token: 0x0400015A RID: 346
		private Vector3 m_animationDownDirectionFromHeelL;

		// Token: 0x0400015B RID: 347
		private Vector3 m_animationDownDirectionFromToeR;

		// Token: 0x0400015C RID: 348
		private Vector3 m_animationDownDirectionFromHeelR;

		// Token: 0x0400015D RID: 349
		[ReadOnlyUI]
		[SerializeField]
		private float m_minAnimationRotationAngleOffsetRightAxisHeelL;

		// Token: 0x0400015E RID: 350
		[ReadOnlyUI]
		[SerializeField]
		private float m_minAnimationRotationAngleOffsetRightAxisHeelR;

		// Token: 0x0400015F RID: 351
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_animationOffsetHeelR;

		// Token: 0x04000160 RID: 352
		[ReadOnlyUI]
		[SerializeField]
		private Quaternion m_animationOffsetHeelL;

		// Token: 0x04000161 RID: 353
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultRightAxisRotationHeelL;

		// Token: 0x04000162 RID: 354
		[ReadOnlyUI]
		[SerializeField]
		private float m_defaultRightAxisRotationHeelR;

		// Token: 0x04000163 RID: 355
		private Vector3 m_HighHeelsLocalDirectionFromHeelR;

		// Token: 0x04000164 RID: 356
		private Vector3 m_HighHeelsLocalDirectionFromHeelL;

		// Token: 0x04000165 RID: 357
		private Vector3 m_HighToesLocalDirectionFromHeelR;

		// Token: 0x04000166 RID: 358
		private Vector3 m_HighToesLocalDirectionFromHeelL;

		// Token: 0x04000167 RID: 359
		private Vector3 m_VirtualHighHeelsLocalDirectionFromHeelR;

		// Token: 0x04000168 RID: 360
		private Vector3 m_VirtualHighHeelsLocalDirectionFromHeelL;

		// Token: 0x04000169 RID: 361
		private Vector3 m_VirtualHighToesLocalDirectionFromHeelR;

		// Token: 0x0400016A RID: 362
		private Vector3 m_VirtualHighToesLocalDirectionFromHeelL;

		// Token: 0x0400016B RID: 363
		private Vector3 m_localPositionVirtualHeelL;

		// Token: 0x0400016C RID: 364
		private Vector3 m_localPositionVirtualHeelR;

		// Token: 0x0400016D RID: 365
		private Vector3 m_localPositionVirtualToeL;

		// Token: 0x0400016E RID: 366
		private Vector3 m_localPositionVirtualToeR;

		// Token: 0x0400016F RID: 367
		[SerializeField]
		private ModificableDeFloat m_heelHeight = new ModificableDeFloat(0f);

		// Token: 0x04000170 RID: 368
		[SerializeField]
		private ModificableDeFloat m_toeHeight = new ModificableDeFloat(0f);

		// Token: 0x04000171 RID: 369
		[SerializeField]
		private ModificableDeFloat m_heelPoseWeight = new ModificableDeFloat(1f);

		// Token: 0x04000172 RID: 370
		[SerializeField]
		private ModificableDeFloat m_toePoseWeight = new ModificableDeFloat(1f);

		// Token: 0x04000173 RID: 371
		private IIKUpdater m_ikUpdater;

		// Token: 0x04000174 RID: 372
		[SerializeField]
		private float m_DebugHeelLocalHeight;

		// Token: 0x04000175 RID: 373
		[SerializeField]
		private float m_DebugToeLocalHeight;

		// Token: 0x04000176 RID: 374
		[SerializeField]
		private float m_DebugHeelPoseWeight = 1f;

		// Token: 0x04000177 RID: 375
		[SerializeField]
		private float m_DebugToePoseWeight = 1f;

		// Token: 0x0200011F RID: 287
		[Serializable]
		public class Config
		{
			// Token: 0x040006B3 RID: 1715
			public float velocityMod = 0.025f;

			// Token: 0x040006B4 RID: 1716
			public float startAngle = 7f;

			// Token: 0x040006B5 RID: 1717
			public float endAngle = 14f;

			// Token: 0x040006B6 RID: 1718
			public float noInteractionHeelsUpBonus = 1.05f;

			// Token: 0x040006B7 RID: 1719
			public float inInteractionHeelsUpBonus = 1f;
		}
	}
}
