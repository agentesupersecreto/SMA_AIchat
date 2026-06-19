using System;
using Assets.TValle.BeachGirl.Runtime.Constraints.Bocas;
using Assets.TValle.SystemasConstraints.RunTime.ChildOfConstraints.Implementation.Constraints;
using Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x02000086 RID: 134
	[RequireComponent(typeof(AperturaDeBocaSegunAnchoDePenetracion))]
	public class BocaHoleMovementSegunAnchoDePenetracion : CustomMonobehaviour
	{
		// Token: 0x060003B9 RID: 953 RVA: 0x0000B510 File Offset: 0x00009710
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_AperturaDeBocaSegunAnchoDePenetracion = base.GetComponent<AperturaDeBocaSegunAnchoDePenetracion>();
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000B524 File Offset: 0x00009724
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_hole = base.GetComponentInChildren<BocaHole>();
			if (this.m_hole == null)
			{
				throw new ArgumentNullException("m_hole", "m_hole null reference.");
			}
			this.m_LabiosJawConstraintsAdder = this.GetComponentEnRoot(false);
			if (this.m_LabiosJawConstraintsAdder == null)
			{
				throw new ArgumentNullException("m_LabiosJawConstraintsAdder", "m_LabiosJawConstraintsAdder null reference.");
			}
			if (!this.m_LabiosJawConstraintsAdder.areConstraintsAdded)
			{
				this.m_LabiosJawConstraintsAdder.constraintsAdded += this.M_LabiosJawConstraintsAdder_constraintsAdded;
				return;
			}
			this.M_LabiosJawConstraintsAdder_constraintsAdded(this.m_LabiosJawConstraintsAdder);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000B5BD File Offset: 0x000097BD
		private void M_LabiosJawConstraintsAdder_constraintsAdded(ConstraintsAdder obj)
		{
			this.m_defaultWeight = this.m_LabiosJawConstraintsAdder.inner.config.weight;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000B5DA File Offset: 0x000097DA
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_AperturaDeBocaSegunAnchoDePenetracion.updated += this.M_AperturaDeBocaSegunAnchoDePenetracion_updated;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000B5F9 File Offset: 0x000097F9
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_AperturaDeBocaSegunAnchoDePenetracion)
			{
				this.m_AperturaDeBocaSegunAnchoDePenetracion.updated -= this.M_AperturaDeBocaSegunAnchoDePenetracion_updated;
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000B628 File Offset: 0x00009828
		private void M_AperturaDeBocaSegunAnchoDePenetracion_updated(AperturaDeBocaSegunAnchoDePenetracion obj)
		{
			if (!this.m_LabiosJawConstraintsAdder.areConstraintsAdded || !this.m_hole.isStared)
			{
				return;
			}
			ChildOfMainUserForSkeletonProxyBone inner = this.m_LabiosJawConstraintsAdder.inner;
			float weight = inner.config.weight;
			float maxLimpiaLocalHole = this.m_hole.estadoDePuntos.actualLocal.maxLimpiaLocalHole;
			float x = this.m_AperturaDeBocaSegunAnchoDePenetracion.controladorDeJaw.controlladorAngles.x;
			float currentJawAngleFromWalls = this.m_AperturaDeBocaSegunAnchoDePenetracion.currentJawAngleFromWalls;
			float num = 0f;
			if (currentJawAngleFromWalls > 0f)
			{
				num = maxLimpiaLocalHole * x / currentJawAngleFromWalls;
			}
			float num2 = 0f;
			if (num > 0f)
			{
				num2 = maxLimpiaLocalHole * 0.5f / num;
			}
			num2 = Mathf.Clamp(num2, this.m_defaultWeight, 1f);
			this.m_currentWeight = (inner.config.weight = num2);
			if (weight != inner.config.weight)
			{
				inner.flagUpdateConfig = true;
			}
		}

		// Token: 0x0400022A RID: 554
		private AperturaDeBocaSegunAnchoDePenetracion m_AperturaDeBocaSegunAnchoDePenetracion;

		// Token: 0x0400022B RID: 555
		private LabiosJawConstraintsAdder m_LabiosJawConstraintsAdder;

		// Token: 0x0400022C RID: 556
		private BocaHole m_hole;

		// Token: 0x0400022D RID: 557
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentWeight;

		// Token: 0x0400022E RID: 558
		private float m_defaultWeight;
	}
}
