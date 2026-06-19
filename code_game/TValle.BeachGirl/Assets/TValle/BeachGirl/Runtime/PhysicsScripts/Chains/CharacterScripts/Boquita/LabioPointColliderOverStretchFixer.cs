using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x0200008B RID: 139
	[RequireComponent(typeof(LabioPointCollider))]
	public sealed class LabioPointColliderOverStretchFixer : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x0000C003 File Offset: 0x0000A203
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.fixedUpdate1);
			}
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000C00C File Offset: 0x0000A20C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_LabioPointCollider = base.GetComponent<LabioPointCollider>();
			this.m_boca = base.GetComponentInParent<Boca>();
			if (this.m_boca == null)
			{
				throw new ArgumentNullException("m_boca", "m_boca null reference.");
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000C04C File Offset: 0x0000A24C
		public override void OnUpdateEvent1()
		{
			if (GlobalUpdater.instancia.currentFixedUpdateIndex > 0)
			{
				return;
			}
			if (!this.m_boca.hole.isPenetrated)
			{
				return;
			}
			SphereCollider main = this.m_LabioPointCollider.main;
			Transform transform = main.attachedRigidbody.transform;
			float num = main.radius * this.m_LabioPointCollider.escala;
			LabioPoint punto = this.m_LabioPointCollider.punto;
			int layerDeteccionDePenes = Singleton<ConfiguracionGeneral>.instance.layers.layerDeteccionDePenes;
			Vector3 vector = main.transform.TransformPoint(main.center);
			Vector3 vector2 = vector - transform.position;
			Vector3 vector3 = punto.jointTransform.position + vector2;
			Vector3 vector4 = vector - vector3;
			if (vector4.sqrMagnitude == 0f)
			{
				return;
			}
			vector3 += -vector4.normalized * num;
			RaycastHit raycastHit;
			if (!Physics.SphereCast(vector3, num * 0.75f, vector4, out raycastHit, vector4.magnitude, layerDeteccionDePenes, QueryTriggerInteraction.Ignore))
			{
				return;
			}
			Vector3 vector5 = raycastHit.point;
			if (raycastHit.distance == 0f)
			{
				vector5 = punto.jointTransform.position + vector2;
			}
			else
			{
				vector5 -= vector2;
			}
			transform.position = vector5 + -vector4.normalized * num;
		}

		// Token: 0x04000248 RID: 584
		private LabioPointCollider m_LabioPointCollider;

		// Token: 0x04000249 RID: 585
		private Boca m_boca;
	}
}
