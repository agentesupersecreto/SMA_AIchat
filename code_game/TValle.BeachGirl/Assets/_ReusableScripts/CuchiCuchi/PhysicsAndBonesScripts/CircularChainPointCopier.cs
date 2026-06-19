using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x02000100 RID: 256
	public class CircularChainPointCopier : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x00024ADD File Offset: 0x00022CDD
		public override int updateEvent1Index
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x00024AE0 File Offset: 0x00022CE0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x00024AF4 File Offset: 0x00022CF4
		public void Init(CircularChainPointStretcherJoint joint)
		{
			if (joint == null)
			{
				throw new ArgumentNullException("joint", "joint null reference.");
			}
			this.m_joint = joint;
			base.Initialize();
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x00024B1C File Offset: 0x00022D1C
		public void Init(CircularChainPointStretcherJoint joint, CircularChainPointCopier.Configuracion configuracion)
		{
			if (configuracion == null)
			{
				throw new ArgumentNullException("configuracion", "configuracion null reference.");
			}
			this.configuracion = configuracion;
			this.Init(joint);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x00024B40 File Offset: 0x00022D40
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Quaternion quaternion = Quaternion.LookRotation(this.m_joint.jointAxisAdmin.jointForward, this.m_joint.jointAxisAdmin.jointUp);
			Quaternion localRotation = this.m_joint.transform.localRotation;
			this.m_joint.transform.localRotation = quaternion;
			this.m_matrix = this.m_joint.transform.worldToLocalMatrix * this.m_joint.transform.parent.localToWorldMatrix;
			this.targetDefPosition = this.m_matrix.MultiplyPoint3x4(this.m_joint.otherBody.transform.localPosition);
			this.targetDefPositionNormalized = this.targetDefPosition.normalized;
			this.m_joint.transform.localRotation = localRotation;
			this.m_invertedMatrix = this.m_matrix.inverse;
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x00024C24 File Offset: 0x00022E24
		public override void OnUpdateEvent1()
		{
			Vector3 vector = this.m_matrix.MultiplyPoint3x4(this.m_joint.otherBody.transform.localPosition);
			this.ApplyZLimit(ref vector);
			if (this.configuracion.noPermitirJustoDetras)
			{
				Vector3 vector2 = this.targetDefPositionNormalized;
				Vector3 vector3 = vector - this.targetDefPosition;
				Vector3 vector4 = vector3.normalized;
				if (Vector3.Dot(vector4, vector2) < -this.configuracion.porDetrasSensivilidad && vector3.sqrMagnitude > 1E-06f)
				{
					Vector3 normalized = this.configuracion.correcionDeJustoDetrasPreferida.normalized;
					Vector3 vector5 = normalized - vector2 * Vector3.Dot(normalized, vector2);
					if (vector5.sqrMagnitude < 1E-06f)
					{
						vector5 = Vector3.Cross(vector2, Vector3.up);
						if (vector5.sqrMagnitude < 1E-06f)
						{
							vector5 = Vector3.Cross(vector2, Vector3.right);
						}
					}
					vector5.Normalize();
					vector4 = (-vector2 + vector5 * 0.001f).normalized;
					vector = this.targetDefPosition + vector4 * vector3.magnitude;
				}
			}
			Vector3 vector6 = this.m_invertedMatrix.MultiplyPoint3x4(vector);
			base.transform.localPosition = vector6;
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x00024D6C File Offset: 0x00022F6C
		private void ApplyZLimit(ref Vector3 localFromMatrix)
		{
			if (!this.configuracion.limitarZ)
			{
				return;
			}
			if (Mathf.Abs(localFromMatrix.z - this.targetDefPosition.z) > this.configuracion.zMaxDistance)
			{
				int num = ((localFromMatrix.z >= this.targetDefPosition.z) ? 1 : (-1));
				localFromMatrix.z = this.targetDefPosition.z + this.configuracion.zMaxDistance * (float)num;
			}
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x00024DE3 File Offset: 0x00022FE3
		private void OnDrawGizmosSelected()
		{
		}

		// Token: 0x040005E3 RID: 1507
		private Matrix4x4 m_matrix;

		// Token: 0x040005E4 RID: 1508
		private Matrix4x4 m_invertedMatrix;

		// Token: 0x040005E5 RID: 1509
		[ReadOnlyUI]
		[SerializeField]
		private Vector3 targetDefPosition;

		// Token: 0x040005E6 RID: 1510
		private Vector3 targetDefPositionNormalized;

		// Token: 0x040005E7 RID: 1511
		[ReadOnlyUI]
		[SerializeField]
		private CircularChainPointStretcherJoint m_joint;

		// Token: 0x040005E8 RID: 1512
		public CircularChainPointCopier.Configuracion configuracion = new CircularChainPointCopier.Configuracion();

		// Token: 0x020001E3 RID: 483
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000A92 RID: 2706
			public bool limitarZ = true;

			// Token: 0x04000A93 RID: 2707
			public float zMaxDistance = 0.0185f;

			// Token: 0x04000A94 RID: 2708
			public bool noPermitirJustoDetras;

			// Token: 0x04000A95 RID: 2709
			public float porDetrasSensivilidad = 0.999f;

			// Token: 0x04000A96 RID: 2710
			public Vector3 correcionDeJustoDetrasPreferida = -Vector3.up;
		}
	}
}
