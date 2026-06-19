using System;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Props;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes
{
	// Token: 0x0200008D RID: 141
	public class UltrasonidoTrasnVagCamera : AplicableBehaviour
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x000215A8 File Offset: 0x0001F7A8
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x000215B0 File Offset: 0x0001F7B0
		public GameObject monitor
		{
			get
			{
				return this.m_monitor;
			}
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x000215B8 File Offset: 0x0001F7B8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_self = base.GetComponent<GrabbableProp>();
			if (this.m_self == null)
			{
				throw new ArgumentNullException("m_self", "m_self null reference.");
			}
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x000215EA File Offset: 0x0001F7EA
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_self.onStadoChanged += this.M_self_onStadoChanged;
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x00021609 File Offset: 0x0001F809
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_self != null)
			{
				this.m_self.onStadoChanged -= this.M_self_onStadoChanged;
			}
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x00021637 File Offset: 0x0001F837
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_camera.enabled = false;
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0002164B File Offset: 0x0001F84B
		private void M_self_onStadoChanged(GrabbablePropEstado current, GrabbablePropEstado last, GrabbableProp sender)
		{
			if (current <= GrabbablePropEstado.NotGrabbed)
			{
				this.m_camera.enabled = false;
				return;
			}
			if (current - GrabbablePropEstado.Grabbed > 1)
			{
				throw new ArgumentOutOfRangeException(current.ToString());
			}
			this.m_camera.enabled = true;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00021688 File Offset: 0x0001F888
		public override void OnUpdateEvent1()
		{
			if (this.m_camera.enabled)
			{
				Transform parent = this.m_camera.transform.parent;
				Camera main = Camera.main;
				this.m_camera.transform.rotation = Quaternion.LookRotation(parent.forward, main.transform.up);
			}
		}

		// Token: 0x0400038C RID: 908
		[SerializeField]
		private Camera m_camera;

		// Token: 0x0400038D RID: 909
		[SerializeField]
		private GameObject m_monitor;

		// Token: 0x0400038E RID: 910
		private GrabbableProp m_self;
	}
}
