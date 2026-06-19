using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Vags
{
	// Token: 0x0200010E RID: 270
	public class VagLabiaPoint : ChainPointStretcherJoint
	{
		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x00027C13 File Offset: 0x00025E13
		// (set) Token: 0x06000BE2 RID: 3042 RVA: 0x00027C1B File Offset: 0x00025E1B
		public new GlobalUpdater.UpdateType updateEvent2
		{
			get
			{
				return this.m_UpdateEvent2;
			}
			set
			{
				this.m_UpdateEvent2 = value;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x00027C24 File Offset: 0x00025E24
		public sealed override int updateEvent2Index
		{
			get
			{
				return (int)this.m_UpdateEvent2;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x00027C2C File Offset: 0x00025E2C
		public VagLabiaPointColliders vagLabiaPointColliders
		{
			get
			{
				return this.m_VagLabiaPointColliders;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x00027C34 File Offset: 0x00025E34
		// (set) Token: 0x06000BE6 RID: 3046 RVA: 0x00027C3C File Offset: 0x00025E3C
		public float maxLocalLimit
		{
			get
			{
				return this.m_maxLocalLimit;
			}
			set
			{
				this.m_maxLocalLimit = value;
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x00027C45 File Offset: 0x00025E45
		protected Transform root
		{
			get
			{
				return this.vagLabia.transform;
			}
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x00027C54 File Offset: 0x00025E54
		protected override void StartUnityEvent()
		{
			this.m_LocaljointOriginalPos = this.root.InverseTransformPoint(this.m_joint.transform.position);
			this.m_LocalotherBodyOriginalPos = this.root.InverseTransformPoint(base.otherBody.transform.position);
			this.m_LocalOriginalDirBodyToJoint = this.m_LocaljointOriginalPos - this.m_LocalotherBodyOriginalPos;
			this.m_LocalOriginalDirBodyToJointMag = this.m_LocalOriginalDirBodyToJoint.magnitude;
			this.m_LocalOriginalDirBodyToJoint = this.m_LocalOriginalDirBodyToJoint.normalized;
			this.FixLimit();
			this.m_LocalMaxPosition = this.CalculeLocalMaxPosition();
			this.m_JointDistancesAdmin.maxLocalLimit = this.maxLocalLimit;
			base.StartUnityEvent();
			if (this.vagLabia == null)
			{
				throw new ArgumentNullException("vagLabia", "vagLabia null reference.");
			}
			this.AddCollider();
			this.m_JointOtherbodyAdmin.densityMod = this.densityMod;
			this.m_JointDrivesAdmin.AñadirModificador("Mod de VagLabiaPoint").SetAllTo(this.driversMod);
			this.m_JointOtherbodyAdmin.Fix();
			this.m_JointDrivesAdmin.FixDrivers();
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x00027D6C File Offset: 0x00025F6C
		private void FixLimit()
		{
			float localMinDistance = this.vagLabiaPointConfiguracion.localMinDistance;
			if (this.maxLocalLimit < this.m_LocalOriginalDirBodyToJointMag && this.maxLocalLimit > this.m_LocalOriginalDirBodyToJointMag - localMinDistance)
			{
				this.maxLocalLimit = this.m_LocalOriginalDirBodyToJointMag - localMinDistance;
			}
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x00027DB4 File Offset: 0x00025FB4
		private Vector3 CalculeLocalMaxPosition()
		{
			if (this.maxLocalLimit < this.m_LocalOriginalDirBodyToJointMag)
			{
				return this.m_LocaljointOriginalPos;
			}
			if (this.m_LocalOriginalDirBodyToJointMag * 2f < this.maxLocalLimit)
			{
				return this.m_LocaljointOriginalPos + this.m_LocalOriginalDirBodyToJoint * this.m_LocalOriginalDirBodyToJointMag;
			}
			return this.m_LocaljointOriginalPos + this.m_LocalOriginalDirBodyToJoint * (this.maxLocalLimit - this.m_LocalOriginalDirBodyToJointMag);
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x00027E2A File Offset: 0x0002602A
		public bool IsTouchedByAny()
		{
			return this.m_VagLabiaPointColliders.IsTouchedByAny();
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x00027E38 File Offset: 0x00026038
		private void AddCollider()
		{
			Transform transform = base.otherBody.transform;
			this.m_VagLabiaPointColliders = transform.GetComponentNotNull<VagLabiaPointColliders>();
			this.m_VagLabiaPointColliders.SetManualStart();
			this.m_VagLabiaPointColliders.configuracion = this.colliderConfig;
			Vector3 normalized = transform.InverseTransformDirection(this.root.TransformDirection(this.vagLabiaPointConfiguracion.vagRootLocalRight)).normalized;
			Vector3 normalized2 = transform.InverseTransformDirection(this.root.TransformDirection(this.vagLabiaPointConfiguracion.vagRootLocalForward)).normalized;
			switch (this.side)
			{
			case Side.none:
			case Side.F:
				throw new InvalidOperationException();
			case Side.L:
				this.m_VagLabiaPointColliders.centerOffsetDirection = new Vector3?(-normalized);
				break;
			case Side.R:
				this.m_VagLabiaPointColliders.centerOffsetDirection = new Vector3?(normalized);
				break;
			case Side.B:
				this.m_VagLabiaPointColliders.centerOffsetDirection = new Vector3?((-normalized2 + Vector3.Cross(normalized2, normalized) * 0.5f).normalized);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			this.m_VagLabiaPointColliders.ManualStart();
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x00027F60 File Offset: 0x00026160
		public override void OnUpdateEvent2()
		{
			if (!this.vagLabiaPointConfiguracion.useMinDistance)
			{
				return;
			}
			Vector3 vector = Vector3.zero;
			Vector3 vector2;
			vector = (vector2 = this.root.InverseTransformPoint(this.m_joint.transform.position));
			Vector3 vector3 = this.root.InverseTransformPoint(base.otherBody.transform.position);
			Vector3 vector4 = this.m_LocaljointOriginalPos + this.m_LocalOriginalDirBodyToJoint * 100f;
			vector2 = Math3d.ProjectPointOnLineSegment(this.m_LocalotherBodyOriginalPos, vector4, vector2);
			vector3 = Math3d.ProjectPointOnLineSegment(this.m_LocalotherBodyOriginalPos, vector4, vector3);
			if (this.JointPosPasoDePosicionOriginal(vector2))
			{
				this.VolverAPosOriginal();
				return;
			}
			if (this.JointPosFueraDeCarril(vector2, vector))
			{
				this.m_joint.transform.position = this.root.TransformPoint(vector2);
			}
			float num = Vector3.Distance(vector2, vector3);
			if (num > this.vagLabiaPointConfiguracion.localMinDistance)
			{
				if (Vector3.Distance(vector2, this.m_LocaljointOriginalPos) > 1E-05f)
				{
					vector2 = this.MantenerDistancia(vector3);
				}
			}
			else if (num < this.vagLabiaPointConfiguracion.localMinDistance)
			{
				vector2 = this.MantenerDistancia(vector3);
			}
			if (this.MaxDistanciaSuperada(vector2, this.m_LocaljointOriginalPos))
			{
				this.m_joint.transform.position = this.root.TransformPoint(this.m_LocalMaxPosition);
			}
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x000280A8 File Offset: 0x000262A8
		private bool MaxDistanciaSuperada(Vector3 localPointKinematicPos, Vector3 localOriginal)
		{
			return (localPointKinematicPos - this.m_LocalotherBodyOriginalPos).magnitude >= this.maxLocalLimit + this.vagLabiaPointConfiguracion.localMinDistance || (localPointKinematicPos - localOriginal).magnitude >= this.m_LocalOriginalDirBodyToJointMag;
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x000280FC File Offset: 0x000262FC
		private Vector3 MantenerDistancia(Vector3 localPointDynamicPos)
		{
			float localMinDistance = this.vagLabiaPointConfiguracion.localMinDistance;
			Vector3 vector = localPointDynamicPos + this.m_LocalOriginalDirBodyToJoint * localMinDistance;
			Vector3 vector2 = this.root.TransformPoint(vector);
			if (Vector3.Distance(vector2, this.m_joint.transform.position) > 1E-06f)
			{
				this.m_joint.transform.position = vector2;
			}
			return vector;
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x00028164 File Offset: 0x00026364
		private bool JointPosPasoDePosicionOriginal(Vector3 localPointKinematicPos)
		{
			return Vector3.Dot((localPointKinematicPos - this.m_LocaljointOriginalPos).normalized, this.m_LocalOriginalDirBodyToJoint) < 0f;
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x00028198 File Offset: 0x00026398
		private bool JointPosFueraDeCarril(Vector3 ProyectedlocalPointKinematicPos, Vector3 CurrentlocalPointKinematicPos)
		{
			return (ProyectedlocalPointKinematicPos - CurrentlocalPointKinematicPos).sqrMagnitude > 2.5E-07f;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x000281BB File Offset: 0x000263BB
		private void VolverAPosOriginal()
		{
			this.m_joint.transform.position = this.root.TransformPoint(this.m_LocaljointOriginalPos);
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x000281DE File Offset: 0x000263DE
		[Obsolete]
		private void AcercarAPosOriginal(float distanceToInitial, float distanceToDynamic, Vector3 localPointKinematicPos, Vector3 localPointDynamicPos)
		{
		}

		// Token: 0x04000666 RID: 1638
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent2 = GlobalUpdater.UpdateType.yieldFixedUpdate3;

		// Token: 0x04000667 RID: 1639
		public VagLabiaPoint.VagLabiaPointConfiguracion vagLabiaPointConfiguracion = new VagLabiaPoint.VagLabiaPointConfiguracion();

		// Token: 0x04000668 RID: 1640
		public float densityMod = 1f;

		// Token: 0x04000669 RID: 1641
		public float driversMod = 1f;

		// Token: 0x0400066A RID: 1642
		[SerializeField]
		[ReadOnlyUI]
		private float m_maxLocalLimit = float.MaxValue;

		// Token: 0x0400066B RID: 1643
		private VagLabiaPointColliders m_VagLabiaPointColliders;

		// Token: 0x0400066C RID: 1644
		public VagLabiaPointColliders.Configuracion colliderConfig = new VagLabiaPointColliders.Configuracion();

		// Token: 0x0400066D RID: 1645
		public VagLabia vagLabia;

		// Token: 0x0400066E RID: 1646
		public Side side;

		// Token: 0x0400066F RID: 1647
		private Vector3 m_LocaljointOriginalPos;

		// Token: 0x04000670 RID: 1648
		private Vector3 m_LocalotherBodyOriginalPos;

		// Token: 0x04000671 RID: 1649
		private Vector3 m_LocalOriginalDirBodyToJoint;

		// Token: 0x04000672 RID: 1650
		private Vector3 m_LocalMaxPosition;

		// Token: 0x04000673 RID: 1651
		private float m_LocalOriginalDirBodyToJointMag;

		// Token: 0x020001EE RID: 494
		[Serializable]
		public class VagLabiaPointConfiguracion
		{
			// Token: 0x06000FBC RID: 4028 RVA: 0x00035130 File Offset: 0x00033330
			public VagLabiaPoint.VagLabiaPointConfiguracion Clone()
			{
				return (VagLabiaPoint.VagLabiaPointConfiguracion)base.MemberwiseClone();
			}

			// Token: 0x04000AB4 RID: 2740
			public bool useMinDistance = true;

			// Token: 0x04000AB5 RID: 2741
			[Tooltip("distancia que se conserva desde el joint al body, para mejorar el aspecto visual")]
			public float localMinDistance = 0.009f;

			// Token: 0x04000AB6 RID: 2742
			public Vector3 vagRootLocalRight = -Vector3.right;

			// Token: 0x04000AB7 RID: 2743
			public Vector3 vagRootLocalForward = -Vector3.up;
		}
	}
}
