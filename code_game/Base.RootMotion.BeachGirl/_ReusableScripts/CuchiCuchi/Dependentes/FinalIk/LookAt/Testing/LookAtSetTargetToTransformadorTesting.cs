using System;
using Assets.FinalIk;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt.Testing
{
	// Token: 0x02000097 RID: 151
	public sealed class LookAtSetTargetToTransformadorTesting : CustomUpdatedMonobehaviourBase, LookAtIK_TargetTransformer.IProveedorDeTarget
	{
		// Token: 0x060005FE RID: 1534 RVA: 0x0001DA63 File Offset: 0x0001BC63
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0001DA6C File Offset: 0x0001BC6C
		public bool TryObtener(LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango, Vector3 bodyForward, Vector3 posicionGlobalOrigen, float minDistance, out Vector3 targetPosition, out float velocityMod, out float w)
		{
			velocityMod = 1f;
			if (this.target == null)
			{
				targetPosition = Vector3.zero;
				w = 0f;
				return false;
			}
			targetPosition = this.target.position;
			w = 1f;
			return true;
		}

		// Token: 0x04000424 RID: 1060
		public Transform target;
	}
}
