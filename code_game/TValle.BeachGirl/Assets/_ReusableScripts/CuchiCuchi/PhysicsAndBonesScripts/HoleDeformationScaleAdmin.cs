using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000E6 RID: 230
	[RequireComponent(typeof(Circular8BoneChain))]
	public class HoleDeformationScaleAdmin : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000979 RID: 2425 RVA: 0x0001E093 File Offset: 0x0001C293
		// (set) Token: 0x0600097A RID: 2426 RVA: 0x0001E09B File Offset: 0x0001C29B
		public GlobalUpdater.UpdateType updateEvent
		{
			get
			{
				return this.m_UpdateEvent;
			}
			set
			{
				this.m_UpdateEvent = value;
			}
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x0600097B RID: 2427 RVA: 0x0001E0A4 File Offset: 0x0001C2A4
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.m_UpdateEvent;
			}
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0001E0AC File Offset: 0x0001C2AC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetInicializable();
			base.SetManualStart();
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0001E0C0 File Offset: 0x0001C2C0
		public void Init(Transform targetToDef)
		{
			if (targetToDef == null)
			{
				throw new ArgumentNullException("targetToDef", "targetToDef null reference.");
			}
			this.m_target = targetToDef;
			base.Initialize();
			base.ManualStart();
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0001E0EE File Offset: 0x0001C2EE
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_hole = base.GetComponent<Circular8BoneChain>();
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0001E104 File Offset: 0x0001C304
		public override void OnUpdateEvent1()
		{
			bool isPenetrated = this.m_hole.isPenetrated;
			float num = (isPenetrated ? this.m_hole.estadoDePuntos.actualLocal.maxLocalHole : this.m_hole.estadoDePuntos.actualLocal.maxLimpiaLocalHole);
			float num2 = Mathf.Lerp(this.modMax, this.modMin, Mathf.InverseLerp(0.01f, 0.1f, num).OutPow(this.power));
			num2 = Mathf.Max(num2, 0f);
			Vector3 vector = Vector3.one + Vector3.one * num2 * num2;
			if (!isPenetrated)
			{
				vector = new Vector3(vector.x, vector.y, Mathf.Min(this.modMax, vector.z));
			}
			this.m_target.localScale = Vector3.SmoothDamp(this.m_target.localScale, vector, ref this.velocity, 0.5f, 150f);
		}

		// Token: 0x040004F4 RID: 1268
		[SerializeField]
		protected GlobalUpdater.UpdateType m_UpdateEvent = GlobalUpdater.UpdateType.yieldFixedUpdate1;

		// Token: 0x040004F5 RID: 1269
		public float modMin = 5.25f;

		// Token: 0x040004F6 RID: 1270
		public float modMax = 1.75f;

		// Token: 0x040004F7 RID: 1271
		public float power = 1.3333334f;

		// Token: 0x040004F8 RID: 1272
		private Transform m_target;

		// Token: 0x040004F9 RID: 1273
		private Circular8BoneChain m_hole;

		// Token: 0x040004FA RID: 1274
		private Vector3 velocity = Vector3.zero;
	}
}
