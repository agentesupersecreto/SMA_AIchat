using System;
using System.Collections;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Jobs.StandardizedPatient
{
	// Token: 0x02000068 RID: 104
	[RequireComponent(typeof(IGrabableProp))]
	public class HerramientasVuelveASuSlot : CustomMonobehaviour
	{
		// Token: 0x060004B8 RID: 1208 RVA: 0x0001C100 File Offset: 0x0001A300
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_checkEstado = new CoroutineCapsule(this.CheckEstadoRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
			this.m_prop = base.GetComponent<IGrabableProp>();
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0001C139 File Offset: 0x0001A339
		public void SetSlot(Transform slot)
		{
			this.m_slot = slot;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0001C142 File Offset: 0x0001A342
		private IEnumerator CheckEstadoRutine()
		{
			WaitForSeconds w = new WaitForSeconds(3f);
			for (;;)
			{
				yield return w;
				if (this.m_prop.estado == GrabbablePropEstado.NotGrabbed)
				{
					yield return this.SendToSlotRutine();
				}
			}
			yield break;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0001C151 File Offset: 0x0001A351
		private IEnumerator SendToSlotRutine()
		{
			Transform rootNotGrabed = this.m_prop.notGrabedPhysics.transform;
			if (Vector3.Distance(rootNotGrabed.position, this.m_slot.position) > 0.35f)
			{
				Rigidbody rb = this.m_prop.notGrabedPhysics.GetComponent<Rigidbody>();
				while (!MathfExtension.AlmostEqual(rootNotGrabed.position, this.m_slot.position, 0.001f) || !MathfExtension.AlmostEqual(rootNotGrabed.rotation, this.m_slot.rotation, 0.1f))
				{
					rb.detectCollisions = false;
					rb.useGravity = false;
					if (this.m_prop.estado != GrabbablePropEstado.NotGrabbed)
					{
						if (!rb.detectCollisions)
						{
							rb.detectCollisions = true;
						}
						rb.useGravity = true;
						yield break;
					}
					rootNotGrabed.position = Vector3.Lerp(rootNotGrabed.position, this.m_slot.position, Time.deltaTime * 5f);
					rootNotGrabed.rotation = Quaternion.Slerp(rootNotGrabed.rotation, this.m_slot.rotation, Time.deltaTime * 5f);
					yield return null;
				}
				if (!rb.detectCollisions)
				{
					rb.detectCollisions = true;
				}
				rb.useGravity = true;
				rb = null;
			}
			yield break;
		}

		// Token: 0x0400029D RID: 669
		private IGrabableProp m_prop;

		// Token: 0x0400029E RID: 670
		private Transform m_slot;

		// Token: 0x0400029F RID: 671
		private CoroutineCapsule m_checkEstado;
	}
}
