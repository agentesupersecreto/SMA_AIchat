using System;
using Assets.TValle.BeachGirl.Runtime;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.SexoIKs
{
	// Token: 0x02000027 RID: 39
	[RequireComponent(typeof(LookAtIK))]
	[RequireComponent(typeof(SexIKInitializador))]
	public sealed class SexIK : SexIKBase<SexIKInitializador>, IVagAnalAt, ISexAt, IComponentStartable, ILookAtSolverIK, ILookAt
	{
		// Token: 0x06000158 RID: 344 RVA: 0x00008264 File Offset: 0x00006464
		protected override void UpdateEstadisticasHaciaTarget()
		{
			Quaternion currentWorldRotation = this.m_IAnimatorCharacter.bones.chest.currentWorldRotation;
			Vector3 vector = Vector3.Lerp(currentWorldRotation * Vector3.forward, this.m_target - base.mainBone.position, (this.m_LookAtIK.solver.headWeight * this.m_LookAtIK.solver.IKPositionWeight).OutPow(2f));
			this.estadisticasHaciaTarget.Actualizar(currentWorldRotation, vector);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000082E8 File Offset: 0x000064E8
		protected override void UpdateEstadisticasHead()
		{
			Quaternion currentWorldRotation = this.m_IAnimatorCharacter.bones.chest.currentWorldRotation;
			Vector3 currentForward = this.m_IAnimatorCharacter.bones.pelvis.currentForward;
			this.estadisticasHead.Actualizar(currentWorldRotation, currentForward);
		}
	}
}
