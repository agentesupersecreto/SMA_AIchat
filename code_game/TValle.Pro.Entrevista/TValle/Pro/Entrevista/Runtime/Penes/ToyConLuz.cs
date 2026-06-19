using System;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Props;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes
{
	// Token: 0x0200008B RID: 139
	public class ToyConLuz : CustomMonobehaviour
	{
		// Token: 0x06000598 RID: 1432 RVA: 0x000210B0 File Offset: 0x0001F2B0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_self = base.GetComponent<GrabbableProp>();
			if (this.m_self == null)
			{
				throw new ArgumentNullException("m_self", "m_self null reference.");
			}
			if (this.m_luz == null)
			{
				this.m_luz = base.GetComponentInChildren<Light>();
			}
			if (this.m_luz == null)
			{
				throw new ArgumentNullException("m_luz", "m_luz null reference.");
			}
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00021125 File Offset: 0x0001F325
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_self.onStadoChanged += this.M_self_onStadoChanged;
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00021144 File Offset: 0x0001F344
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_self != null)
			{
				this.m_self.onStadoChanged -= this.M_self_onStadoChanged;
			}
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00021172 File Offset: 0x0001F372
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_luz.enabled = false;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00021186 File Offset: 0x0001F386
		private void M_self_onStadoChanged(GrabbablePropEstado current, GrabbablePropEstado last, GrabbableProp sender)
		{
			if (current <= GrabbablePropEstado.NotGrabbed)
			{
				this.m_luz.enabled = false;
				return;
			}
			if (current - GrabbablePropEstado.Grabbed > 1)
			{
				throw new ArgumentOutOfRangeException(current.ToString());
			}
			this.m_luz.enabled = true;
		}

		// Token: 0x0400037D RID: 893
		[SerializeField]
		private Light m_luz;

		// Token: 0x0400037E RID: 894
		private GrabbableProp m_self;
	}
}
