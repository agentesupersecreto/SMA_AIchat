using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.FinalIk.Interacciones.InteractionObjects.InteraccionObjectCallBacksComponents
{
	// Token: 0x0200002B RID: 43
	public class InterObjInstanciador : InteraccionObjectComienzaTerminaCallBacks
	{
		// Token: 0x06000190 RID: 400 RVA: 0x000093E9 File Offset: 0x000075E9
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.comienzaTime = 0.1f;
			this.terminaTime = 0.9f;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00009408 File Offset: 0x00007608
		protected override void OnStaring(InteractionSystem interactionSystem)
		{
			if (this.m_instance == null && this.prefab == null)
			{
				throw new ArgumentNullException("prefab", "prefab null reference.");
			}
			if (this.m_instance == null)
			{
				Transform parent = this.GetParent();
				this.m_instance = Object.Instantiate<GameObject>(this.prefab, parent.TransformPoint(this.positionLocalOffset), parent.rotation * this.rotationLocalOffset, parent);
				this.m_instance.transform.localScale = this.scaleLocalOffset;
				if (this.overrideLayer)
				{
					this.m_instance.transform.ExecDeepChild(delegate(Transform t)
					{
						t.gameObject.layer = parent.gameObject.layer;
					}, true);
				}
				if (this.m_instance.gameObject.activeSelf)
				{
					this.m_instance.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00009500 File Offset: 0x00007700
		protected override void OnComienza()
		{
			this.m_instance.gameObject.SetActive(true);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00009513 File Offset: 0x00007713
		protected override void OnTermina()
		{
			this.m_instance.gameObject.SetActive(false);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00009526 File Offset: 0x00007726
		protected virtual Transform GetParent()
		{
			return base.transform;
		}

		// Token: 0x0400010E RID: 270
		public GameObject prefab;

		// Token: 0x0400010F RID: 271
		public Vector3 positionLocalOffset;

		// Token: 0x04000110 RID: 272
		public Quaternion rotationLocalOffset;

		// Token: 0x04000111 RID: 273
		public Vector3 scaleLocalOffset = Vector3.one;

		// Token: 0x04000112 RID: 274
		public bool overrideLayer;

		// Token: 0x04000113 RID: 275
		private GameObject m_instance;
	}
}
