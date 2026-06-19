using System;
using Assets.TValle.BeachGirl.Runtime;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.SexoIKs
{
	// Token: 0x02000024 RID: 36
	[RequireComponent(typeof(LookAtIK))]
	[RequireComponent(typeof(OralIKInitializador))]
	public sealed class OralIK : SexIKBase<OralIKInitializador>, IOralAt, ISexAt, IComponentStartable, ILookAtSolverIK, ILookAt
	{
		// Token: 0x06000141 RID: 321 RVA: 0x00007DC6 File Offset: 0x00005FC6
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			base.tipoDeSexIK = TipoDeSexIK.facial;
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00007DD5 File Offset: 0x00005FD5
		// (set) Token: 0x06000143 RID: 323 RVA: 0x00007DD8 File Offset: 0x00005FD8
		public override TipoDeSexIK tipo
		{
			get
			{
				return TipoDeSexIK.facial;
			}
			set
			{
				throw new NotSupportedException("oral ik solo puede ser facial");
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00007DE4 File Offset: 0x00005FE4
		protected override void UpdateEstadisticasHaciaTarget()
		{
			Quaternion currentWorldRotation = this.m_IAnimatorCharacter.bones.chest.currentWorldRotation;
			Vector3 vector = Vector3.Lerp(currentWorldRotation * Vector3.forward, this.m_target - base.mainBone.position, (this.m_LookAtIK.solver.headWeight * this.m_LookAtIK.solver.IKPositionWeight).OutPow(2f));
			this.estadisticasHaciaTarget.Actualizar(currentWorldRotation, vector);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00007E68 File Offset: 0x00006068
		protected override void UpdateEstadisticasHead()
		{
			Quaternion currentWorldRotation = this.m_IAnimatorCharacter.bones.chest.currentWorldRotation;
			Vector3 currentForward = this.m_IAnimatorCharacter.bones.head.currentForward;
			this.estadisticasHead.Actualizar(currentWorldRotation, currentForward);
		}
	}
}
