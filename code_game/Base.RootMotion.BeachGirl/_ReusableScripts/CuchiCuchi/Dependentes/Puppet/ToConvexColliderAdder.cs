using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x020000FE RID: 254
	public abstract class ToConvexColliderAdder<T> : BehaviourAdder where T : Component
	{
		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x0002B251 File Offset: 0x00029451
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000975 RID: 2421 RVA: 0x0002B259 File Offset: 0x00029459
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.custom;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x0002B25C File Offset: 0x0002945C
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0002B260 File Offset: 0x00029460
		public override void OnUpdateEvent1()
		{
			if (this.m_currentTryingTime == null)
			{
				this.m_currentTryingTime = new float?(0f);
			}
			this.TryAdd();
			this.m_currentTryingTime += Time.deltaTime;
			float? currentTryingTime = this.m_currentTryingTime;
			float num = this.tryingTime;
			if ((currentTryingTime.GetValueOrDefault() >= num) & (currentTryingTime != null))
			{
				Debug.LogError("no se pudo añadir " + typeof(T).Name + ", a to convex colliders");
				base.enabled = false;
			}
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0002B314 File Offset: 0x00029514
		private void TryAdd()
		{
			this.GetComponentsEnRoot(false, this.m_toConvex);
			if (this.m_toConvex == null || this.m_toConvex.Count == 0)
			{
				return;
			}
			this.m_added = new List<T>();
			for (int i = 0; i < this.m_toConvex.Count; i++)
			{
				T componentNotNull = this.m_toConvex[i].dynamic.GetComponentNotNull<T>();
				this.m_added.Add(componentNotNull);
			}
			base.OnAddBehaviour();
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0002B38E File Offset: 0x0002958E
		protected override void AddBehaviour()
		{
		}

		// Token: 0x040005DD RID: 1501
		public float tryingTime = 5f;

		// Token: 0x040005DE RID: 1502
		private float? m_currentTryingTime;

		// Token: 0x040005DF RID: 1503
		private List<T> m_added;

		// Token: 0x040005E0 RID: 1504
		private List<PuppetColliderToConvexV2> m_toConvex = new List<PuppetColliderToConvexV2>();
	}
}
