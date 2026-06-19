using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x0200017E RID: 382
	public class MaleSlaveHandFollowCameraRotation : CustomMonobehaviour
	{
		// Token: 0x0600083C RID: 2108 RVA: 0x0002B710 File Offset: 0x00029910
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
			this.m_pivotCopy = base.transform.parent.CreateChild("PivotCopy", true);
			this.m_pivotCopy.SetPositionAndRotation(base.transform.position, base.transform.rotation);
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0002B766 File Offset: 0x00029966
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			Object.Destroy(this.m_pivotCopy);
			this.m_pivotCopy = null;
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0002B781 File Offset: 0x00029981
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_Interaccion = base.GetComponentInParent<Interaccion>();
			this.m_handController = this.GetComponentEnRoot(false);
			while (this.m_handController.handCameraController == null)
			{
				yield return null;
			}
			this.m_handController.handCameraController.updatedHandPosition += this.HandCameraController_updatedHandPosition;
			yield break;
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x0002B790 File Offset: 0x00029990
		private void HandCameraController_updatedHandPosition()
		{
			if (!this.m_Interaccion.currentEstado.ejecutandose)
			{
				base.transform.SetPositionAndRotation(this.m_pivotCopy.position, this.m_pivotCopy.rotation);
				return;
			}
			Vector3 vector = Math3d.ProjectVectorOnPlane((this.m_handController.handCameraController.cameraRotationOnHandTransformUpdate * Vector3.right).normalized, this.m_pivotCopy.forward);
			base.transform.rotation = Quaternion.LookRotation(vector, this.m_pivotCopy.up);
		}

		// Token: 0x0400069C RID: 1692
		private Interaccion m_Interaccion;

		// Token: 0x0400069D RID: 1693
		private HandControllerV2 m_handController;

		// Token: 0x0400069E RID: 1694
		private Transform m_pivotCopy;
	}
}
