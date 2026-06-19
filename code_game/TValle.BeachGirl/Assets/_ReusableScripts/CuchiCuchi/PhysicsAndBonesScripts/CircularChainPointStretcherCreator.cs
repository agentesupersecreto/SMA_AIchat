using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x02000101 RID: 257
	[RequireComponent(typeof(Rigidbody))]
	public class CircularChainPointStretcherCreator : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000B1C RID: 2844 RVA: 0x00024DF8 File Offset: 0x00022FF8
		public void CrearPunto(Transform stretchBase)
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_Rigidbody.useGravity = false;
			if (this.configuracion.distance == 0f)
			{
				this.configuracion.distance = Vector3.Distance(stretchBase.position, base.transform.position);
			}
			else if (this.configuracion.distance < 0f)
			{
				this.configuracion.distance *= -1f;
			}
			this.m_ChainPointStretcherTransform = stretchBase;
			Rigidbody rigidbody = this.m_ChainPointStretcherTransform.gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			this.m_ChainPointStretcherTransform.gameObject.AddComponent<ConfigurableJoint>().connectedBody = this.m_Rigidbody;
			this.chainPointStretcherJoint = this.m_ChainPointStretcherTransform.gameObject.AddComponent<CircularChainPointStretcherJoint>();
			this.chainPointStretcherJoint.configTipo = this.configTipo;
			this.chainPointStretcherJoint.configuraciones = this.configuraciones;
			this.chainPointStretcherJoint.driveFixConfiguracion = this.driveFixConfiguracion;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x00024F04 File Offset: 0x00023104
		public void CrearPuntoCreandoStretchBase(Transform pointParent, float upOffset)
		{
			this.configuracion.up = this.configuracion.up.normalized;
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
			this.m_Rigidbody.useGravity = false;
			if (this.configuracion.distance == 0f)
			{
				this.configuracion.distance = Vector3.Distance(this.configuracion.center.position, base.transform.position);
			}
			else if (this.configuracion.distance < 0f)
			{
				this.configuracion.distance *= -1f;
			}
			float num = this.configuracion.upOffset + upOffset;
			Vector3 vector;
			Vector3 vector2;
			if (!this.configuracion.overrideOutDirection)
			{
				vector = -(this.configuracion.center.position - base.transform.position).normalized;
				vector *= this.configuracion.distance;
				vector2 = base.transform.InverseTransformDirection(vector);
			}
			else
			{
				vector2 = this.configuracion.overridingOutDirection.normalized * this.configuracion.distance;
			}
			vector2 += this.configuracion.up * num;
			vector = base.transform.TransformDirection(vector2);
			Vector3 vector3 = base.transform.position + vector;
			Quaternion quaternion = Quaternion.LookRotation(-vector, base.transform.rotation * this.configuracion.up);
			this.m_ChainPointStretcherTransform = new GameObject(base.name + "_ChainPointStretcher").transform;
			this.m_ChainPointStretcherTransform.gameObject.layer = base.gameObject.layer;
			this.m_ChainPointStretcherTransform.parent = pointParent;
			this.m_ChainPointStretcherTransform.position = vector3;
			this.m_ChainPointStretcherTransform.rotation = quaternion;
			Rigidbody rigidbody = this.m_ChainPointStretcherTransform.gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			this.m_ChainPointStretcherTransform.gameObject.AddComponent<ConfigurableJoint>().connectedBody = this.m_Rigidbody;
			this.chainPointStretcherJoint = this.m_ChainPointStretcherTransform.gameObject.AddComponent<CircularChainPointStretcherJoint>();
			this.chainPointStretcherJoint.configTipo = this.configTipo;
			this.chainPointStretcherJoint.configuraciones = this.configuraciones;
			this.chainPointStretcherJoint.driveFixConfiguracion = this.driveFixConfiguracion;
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00025178 File Offset: 0x00023378
		private void OnDrawGizmosSelected()
		{
		}

		// Token: 0x040005E9 RID: 1513
		public CircularChainPointStretcherCreator.Configuracion configuracion = new CircularChainPointStretcherCreator.Configuracion();

		// Token: 0x040005EA RID: 1514
		private Transform m_ChainPointStretcherTransform;

		// Token: 0x040005EB RID: 1515
		private Rigidbody m_Rigidbody;

		// Token: 0x040005EC RID: 1516
		[ReadOnlyUI]
		public CircularChainPointStretcherJoint chainPointStretcherJoint;

		// Token: 0x040005ED RID: 1517
		public ChainPointStretcherJoint.ConfigTipo configTipo;

		// Token: 0x040005EE RID: 1518
		public ChainPointStretcherJoint.Configuraciones configuraciones = new ChainPointStretcherJoint.Configuraciones();

		// Token: 0x040005EF RID: 1519
		public CircularChainPointStretcherJoint.DriveFixConfiguracion driveFixConfiguracion = new CircularChainPointStretcherJoint.DriveFixConfiguracion();

		// Token: 0x020001E4 RID: 484
		[Serializable]
		public class Configuracion
		{
			// Token: 0x06000F9A RID: 3994 RVA: 0x00034E0A File Offset: 0x0003300A
			public CircularChainPointStretcherCreator.Configuracion Copy()
			{
				return (CircularChainPointStretcherCreator.Configuracion)base.MemberwiseClone();
			}

			// Token: 0x04000A97 RID: 2711
			public Transform center;

			// Token: 0x04000A98 RID: 2712
			public float distance = 0.016f;

			// Token: 0x04000A99 RID: 2713
			public Vector3 up = Vector3.forward;

			// Token: 0x04000A9A RID: 2714
			public float upOffset;

			// Token: 0x04000A9B RID: 2715
			public bool overrideOutDirection;

			// Token: 0x04000A9C RID: 2716
			public Vector3 overridingOutDirection;
		}
	}
}
