using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts
{
	// Token: 0x02000123 RID: 291
	public abstract class StandaloneConstraintsAdder : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1400005A RID: 90
		// (add) Token: 0x06000CA3 RID: 3235 RVA: 0x0002AF58 File Offset: 0x00029158
		// (remove) Token: 0x06000CA4 RID: 3236 RVA: 0x0002AF90 File Offset: 0x00029190
		public event Action<StandaloneConstraintsAdder> constraintsAdded;

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x0002AFC5 File Offset: 0x000291C5
		public bool areConstraintsAdded
		{
			get
			{
				return this.m_areConstraintsAdded;
			}
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x0002AFCD File Offset: 0x000291CD
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.Init();
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x0002AFDB File Offset: 0x000291DB
		private void Init()
		{
			this.OnInit();
			this.m_areConstraintsAdded = true;
			Action<StandaloneConstraintsAdder> action = this.constraintsAdded;
			if (action != null)
			{
				action(this);
			}
			this.constraintsAdded = null;
		}

		// Token: 0x06000CA8 RID: 3240
		protected abstract void OnInit();

		// Token: 0x06000CA9 RID: 3241 RVA: 0x0002B004 File Offset: 0x00029204
		protected T Create<T>(string constrained) where T : Component
		{
			T t = default(T);
			this.Create<T>(ref t, constrained);
			return t;
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x0002B024 File Offset: 0x00029224
		protected void Create<T>(ref T constraint, string constrained) where T : Component
		{
			try
			{
				constraint = base.transform.GetChildNotNull(constrained, true).gameObject.AddComponent<T>();
			}
			catch (Exception)
			{
				throw;
			}
		}

		// Token: 0x040006BB RID: 1723
		private bool m_areConstraintsAdded;
	}
}
