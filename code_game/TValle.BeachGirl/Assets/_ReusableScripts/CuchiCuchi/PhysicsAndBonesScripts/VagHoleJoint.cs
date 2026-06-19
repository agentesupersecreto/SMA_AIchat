using System;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000E9 RID: 233
	[RequireComponent(typeof(VagHole))]
	public class VagHoleJoint : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x060009BC RID: 2492 RVA: 0x0001EFD3 File Offset: 0x0001D1D3
		// (set) Token: 0x060009BD RID: 2493 RVA: 0x0001EFDB File Offset: 0x0001D1DB
		public new GlobalUpdater.UpdateType updateEvent1
		{
			get
			{
				return this.m_UpdateEvent1;
			}
			set
			{
				this.m_UpdateEvent1 = value;
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x0001EFE4 File Offset: 0x0001D1E4
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.m_UpdateEvent1;
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x0001EFEC File Offset: 0x0001D1EC
		public Vector3 posicionGlobalInicial
		{
			get
			{
				return this.m_vagHole.vagRoot.TransformPoint(this.m_posicionlocalInicial);
			}
		}

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x060009C0 RID: 2496 RVA: 0x0001F004 File Offset: 0x0001D204
		// (remove) Token: 0x060009C1 RID: 2497 RVA: 0x0001F03C File Offset: 0x0001D23C
		public event VagHoleJoint.UpdateEventHandler updating;

		// Token: 0x060009C2 RID: 2498 RVA: 0x0001F071 File Offset: 0x0001D271
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Rigidbody = this.GetComponentNotNull<Rigidbody>();
			this.m_vagHole = base.GetComponent<VagHole>();
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0001F094 File Offset: 0x0001D294
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_posicionlocalInicial = this.m_vagHole.vagRoot.InverseTransformPoint(base.transform.position);
			this.SetInitialRelativesToRoot();
			this.UpdateMass();
			this.LoadDefConfig();
			this.UpdateMaxDistance();
			this.m_vagHole.scaleChangedBroadcaster.ScaleChanged += new ScaleChangedBroadcaster.ScaleChangedHandler(this.ScaleChangedBroadcaster_ScaleChanged);
			this.m_JointConnectorAnchorAdmin = this.GetComponentNotNull<JointConnectorAnchorAdmin>();
			this.m_JointConnectorAnchorAdmin.customUpdatedConfig.manualStart = true;
			this.m_JointDrivesAdmin = this.GetComponentNotNull<JointDrivesAdminV2>();
			this.m_JointDrivesAdmin.customUpdatedConfig.manualStart = true;
			this.m_JointConnectorAnchorAdmin.ManualStart();
			this.m_JointConnectorAnchorAdmin.Fix();
			this.m_JointDrivesAdmin.configuracion = new JointDrivesAdminV2.Configuracion
			{
				yDrive = this.configuracion.jointDriveConfig
			};
			this.m_JointDrivesAdmin.ManualStart();
			this.m_JointDrivesAdmin.FixDrivers();
			if (this.GetComponentEnRoot(false) != null)
			{
				this.GetComponentNotNull<VagHoleJointAnusStateMover>();
			}
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0001F19C File Offset: 0x0001D39C
		private void SetInitialRelativesToRoot()
		{
			Transform vagRoot = this.m_vagHole.vagRoot;
			Vector3 vector = vagRoot.transform.TransformDirection(this.configuracion.vagRootProyectionNormal);
			Vector3 vector2 = Math3d.ProjectPointOnPlane(vector, vagRoot.position, this.m_vagHole._6.otherBody.transform.position);
			Vector3 vector3 = Math3d.ProjectPointOnPlane(vector, vagRoot.position, this.m_vagHole.backLabiaPointIn.position);
			this.m_RelativeProyectedInicialBackHole = vagRoot.InverseTransformPoint(vector2);
			this.m_RelativeProyectedInicialBackLabia = vagRoot.InverseTransformPoint(vector3);
			Vector3 vector4 = Math3d.ProjectPointOnPlane(vector, vagRoot.position, this.m_vagHole.clitBaseTransform.position);
			Vector3 vector5 = Math3d.ProjectPointOnPlane(vector, vagRoot.position, base.transform.position);
			this.m_RelativeProyectedInicialClit = vagRoot.InverseTransformPoint(vector4);
			this.m_RelativeProyectedInicialHole = vagRoot.InverseTransformPoint(vector5);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0001F27C File Offset: 0x0001D47C
		private float GetWorldDistanceBetRealtivePoints()
		{
			Transform vagRoot = this.m_vagHole.vagRoot;
			return this.configuracion.reserveMod * Vector3.Distance(vagRoot.TransformPoint(this.m_RelativeProyectedInicialBackHole), vagRoot.TransformPoint(this.m_RelativeProyectedInicialBackLabia));
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0001F2BE File Offset: 0x0001D4BE
		private void ScaleChangedBroadcaster_ScaleChanged(object target)
		{
			this.UpdateMass();
			this.UpdateMaxDistance();
			this.m_JointConnectorAnchorAdmin.Fix();
			this.m_JointDrivesAdmin.FixDrivers();
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0001F2E2 File Offset: 0x0001D4E2
		private void UpdateMass()
		{
			this.m_Rigidbody.mass = this.configuracion.density * JointOtherbodyAdmin.GetVol(base.transform.lossyScale);
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0001F30C File Offset: 0x0001D50C
		private void UpdateMaxDistance()
		{
			Transform vagRoot = this.m_vagHole.vagRoot;
			Vector3 vector = vagRoot.TransformPoint(this.m_RelativeProyectedInicialClit);
			Vector3 vector2 = vagRoot.TransformPoint(this.m_RelativeProyectedInicialHole);
			this.m_maxDistance = Vector3.Distance(vector, vector2) * this.configuracion.effectiveMaxDistance;
			this.m_ConfigurableJoint.linearLimit = new SoftJointLimit
			{
				limit = this.m_maxDistance * 0.5f,
				contactDistance = this.m_maxDistance * 0.25f
			};
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0001F390 File Offset: 0x0001D590
		private void LoadDefConfig()
		{
			this.m_Rigidbody.useGravity = false;
			Rigidbody componentNotNull = this.m_vagHole.vagRoot.GetComponentNotNull<Rigidbody>();
			componentNotNull.isKinematic = true;
			this.m_ConfigurableJoint = this.GetComponentNotNull<ConfigurableJoint>();
			this.m_ConfigurableJoint.connectedBody = componentNotNull;
			this.m_ConfigurableJoint.xMotion = ConfigurableJointMotion.Locked;
			this.m_ConfigurableJoint.yMotion = ConfigurableJointMotion.Limited;
			this.m_ConfigurableJoint.zMotion = ConfigurableJointMotion.Locked;
			this.m_ConfigurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
			this.m_ConfigurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
			this.m_ConfigurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
			this.m_ConfigurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
			this.m_ConfigurableJoint.projectionDistance = 0.001f;
			this.m_ConfigurableJoint.breakForce = float.PositiveInfinity;
			this.m_ConfigurableJoint.breakTorque = float.PositiveInfinity;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0001F460 File Offset: 0x0001D660
		public sealed override void OnUpdateEvent1()
		{
			this.m_cDistance = 0f;
			this.m_cFinalDistance = 0f;
			this.m_cOverDistance = 0f;
			this.m_UpdatingArg.distanciaGlobalAgregada = 0f;
			if (this.updating != null)
			{
				this.updating(this, this.m_UpdatingArg);
			}
			if (this.m_vagHole.estadoDePuntos.actualLocal.maxLimpiaLocalHole <= 0f && this.m_UpdatingArg.distanciaGlobalAgregada <= 0f)
			{
				this.m_ConfigurableJoint.targetPosition = Vector3.zero;
				return;
			}
			float worldDistanceBetRealtivePoints = this.GetWorldDistanceBetRealtivePoints();
			float maxValue = this.m_vagHole.estadoDePuntos.globalActual.maxValue;
			if (maxValue * 0.5f <= worldDistanceBetRealtivePoints && this.m_UpdatingArg.distanciaGlobalAgregada <= 0f)
			{
				this.m_ConfigurableJoint.targetPosition = Vector3.zero;
				return;
			}
			this.m_cDistance = maxValue;
			this.m_cOverDistance = ((this.m_cDistance > this.m_maxDistance) ? (this.m_cDistance - this.m_maxDistance) : 0f);
			this.m_cFinalDistance = this.m_UpdatingArg.distanciaGlobalAgregada + Mathf.Clamp(this.m_cDistance * 0.5f - worldDistanceBetRealtivePoints, 0f, float.MaxValue) - this.m_cOverDistance * 0.5f * this.configuracion.overDistanceMod;
			this.m_ConfigurableJoint.targetPosition = this.configuracion.movementAxis.normalized * this.m_cFinalDistance;
		}

		// Token: 0x04000521 RID: 1313
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent1 = GlobalUpdater.UpdateType.fixedUpdate2;

		// Token: 0x04000522 RID: 1314
		public VagHoleJoint.Configuracion configuracion = new VagHoleJoint.Configuracion();

		// Token: 0x04000523 RID: 1315
		private ConfigurableJoint m_ConfigurableJoint;

		// Token: 0x04000524 RID: 1316
		private Rigidbody m_Rigidbody;

		// Token: 0x04000525 RID: 1317
		private VagHole m_vagHole;

		// Token: 0x04000526 RID: 1318
		private JointDrivesAdminV2 m_JointDrivesAdmin;

		// Token: 0x04000527 RID: 1319
		private JointConnectorAnchorAdmin m_JointConnectorAnchorAdmin;

		// Token: 0x04000529 RID: 1321
		private VagHoleJoint.UpdatingArg m_UpdatingArg = new VagHoleJoint.UpdatingArg();

		// Token: 0x0400052A RID: 1322
		private Vector3 m_posicionlocalInicial;

		// Token: 0x0400052B RID: 1323
		[SerializeField]
		private Vector3 m_RelativeProyectedInicialBackHole;

		// Token: 0x0400052C RID: 1324
		[SerializeField]
		private Vector3 m_RelativeProyectedInicialBackLabia;

		// Token: 0x0400052D RID: 1325
		[SerializeField]
		private Vector3 m_RelativeProyectedInicialClit;

		// Token: 0x0400052E RID: 1326
		[SerializeField]
		private Vector3 m_RelativeProyectedInicialHole;

		// Token: 0x0400052F RID: 1327
		[SerializeField]
		[ReadOnlyUI]
		private float m_maxDistance;

		// Token: 0x04000530 RID: 1328
		[SerializeField]
		[ReadOnlyUI]
		private float m_cDistance;

		// Token: 0x04000531 RID: 1329
		[SerializeField]
		[ReadOnlyUI]
		private float m_cOverDistance;

		// Token: 0x04000532 RID: 1330
		[SerializeField]
		[ReadOnlyUI]
		private float m_cFinalDistance;

		// Token: 0x020001BD RID: 445
		// (Invoke) Token: 0x06000F4D RID: 3917
		public delegate void UpdateEventHandler(VagHoleJoint sender, VagHoleJoint.UpdatingArg args);

		// Token: 0x020001BE RID: 446
		[Serializable]
		public class Configuracion
		{
			// Token: 0x040009F8 RID: 2552
			public Vector3 movementAxis = Vector3.up;

			// Token: 0x040009F9 RID: 2553
			public float density = 10f;

			// Token: 0x040009FA RID: 2554
			public JointDriveConfiguration jointDriveConfig = new JointDriveConfiguration(2200f, 200f);

			// Token: 0x040009FB RID: 2555
			public Vector3 vagRootProyectionNormal = Vector3.forward;

			// Token: 0x040009FC RID: 2556
			public float reserveMod = 1.5f;

			// Token: 0x040009FD RID: 2557
			public float overDistanceMod = 1f;

			// Token: 0x040009FE RID: 2558
			public float effectiveMaxDistance = 0.85f;
		}

		// Token: 0x020001BF RID: 447
		public class UpdatingArg
		{
			// Token: 0x040009FF RID: 2559
			public float distanciaGlobalAgregada;
		}
	}
}
