using System;
using Assets.SystemasConstraints._Abstract;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.ConstraintsScripts
{
	// Token: 0x02000122 RID: 290
	public abstract class ConstraintsAdder : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x14000059 RID: 89
		// (add) Token: 0x06000C99 RID: 3225 RVA: 0x0002ADA0 File Offset: 0x00028FA0
		// (remove) Token: 0x06000C9A RID: 3226 RVA: 0x0002ADD8 File Offset: 0x00028FD8
		public event Action<ConstraintsAdder> constraintsAdded;

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x0002AE0D File Offset: 0x0002900D
		public bool areConstraintsAdded
		{
			get
			{
				return this.m_areConstraintsAdded;
			}
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x0002AE18 File Offset: 0x00029018
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Character componentInParent = base.GetComponentInParent<Character>();
			if (componentInParent.isStared)
			{
				this.Init(componentInParent);
				return;
			}
			componentInParent.stared += this.C_stared;
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x0002AE54 File Offset: 0x00029054
		private void C_stared(object sender)
		{
			this.Init(sender as Character);
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x0002AE64 File Offset: 0x00029064
		private void Init(Character character)
		{
			Animator bodyAnimator = character.bodyAnimator;
			if (this.constrainedSkeleton == null)
			{
				this.constrainedSkeleton = bodyAnimator.GetComponentInChildren<ConstrainedSkeleton>();
			}
			if (this.constrainedSkeleton == null)
			{
				throw new ArgumentNullException("m_ConstrainedSkeleton", "m_ConstrainedSkeleton null reference.");
			}
			if (!this.constrainedSkeleton.initiated)
			{
				throw new InvalidOperationException("constrainedSkeleton no esta inicializado");
			}
			this.OnInit();
			this.m_areConstraintsAdded = true;
			Action<ConstraintsAdder> action = this.constraintsAdded;
			if (action != null)
			{
				action(this);
			}
			this.constraintsAdded = null;
		}

		// Token: 0x06000C9F RID: 3231
		protected abstract void OnInit();

		// Token: 0x06000CA0 RID: 3232 RVA: 0x0002AEF0 File Offset: 0x000290F0
		protected T Create<T>(string constrained) where T : Component
		{
			T t = default(T);
			this.Create<T>(ref t, constrained);
			return t;
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x0002AF10 File Offset: 0x00029110
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

		// Token: 0x040006B7 RID: 1719
		public ConstrainedSkeleton constrainedSkeleton;

		// Token: 0x040006B9 RID: 1721
		private bool m_areConstraintsAdded;
	}
}
