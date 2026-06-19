using System;
using Assets.Base.Behaviours.Runtime.Bones;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Animations
{
	// Token: 0x0200029A RID: 666
	public class PoseBlendingByFemeninityAndHeight : CustomMonobehaviour, IBlender
	{
		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000EA4 RID: 3748 RVA: 0x00044D80 File Offset: 0x00042F80
		// (set) Token: 0x06000EA5 RID: 3749 RVA: 0x00044D8D File Offset: 0x00042F8D
		private IPoseBlendingSource normalVsSexy
		{
			get
			{
				return this.m_normalVsSexy as IPoseBlendingSource;
			}
			set
			{
				this.m_normalVsSexy = value as Object;
			}
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x00044D9B File Offset: 0x00042F9B
		// (set) Token: 0x06000EA7 RID: 3751 RVA: 0x00044DA8 File Offset: 0x00042FA8
		private IPoseBlendingSource sexyEstatura
		{
			get
			{
				return this.m_sexyEstatura as IPoseBlendingSource;
			}
			set
			{
				this.m_sexyEstatura = value as Object;
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x00044DB6 File Offset: 0x00042FB6
		// (set) Token: 0x06000EA9 RID: 3753 RVA: 0x00044DC3 File Offset: 0x00042FC3
		private IPoseBlendingSource normalEstatura
		{
			get
			{
				return this.m_normalEstatura as IPoseBlendingSource;
			}
			set
			{
				this.m_normalEstatura = value as Object;
			}
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x00044DD4 File Offset: 0x00042FD4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.normalVsSexy == null)
			{
				throw new ArgumentNullException("normalVsSexy", "normalVsSexy null reference.");
			}
			if (this.sexyEstatura == null)
			{
				throw new ArgumentNullException("sexyEstatura", "sexyEstatura null reference.");
			}
			if (this.normalEstatura == null)
			{
				throw new ArgumentNullException("normalEstatura", "normalEstatura null reference.");
			}
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x00044E30 File Offset: 0x00043030
		public void Blend(ICharacter poseTo, IPoseTarget target, Transform GoTo = null)
		{
			if (GoTo != null)
			{
				base.transform.SetPositionAndRotation(GoTo.position, GoTo.rotation);
			}
			float num = poseTo.CalculeFemeninityFrom();
			float num2 = MathfExtension.InverseLerpConMedio(0.7777f, 1f, 1.2f, poseTo.escala);
			this.sexyEstatura.t = num2;
			this.normalEstatura.t = num2;
			this.normalVsSexy.t = num;
			this.normalVsSexy.GenerateBlending();
			target.LoadPose(this.normalVsSexy.rootPosition, this.normalVsSexy.rootRotation, this.normalVsSexy.hipsLocalPosition, this.normalVsSexy.feetLocalOffset, this.normalVsSexy.bonesRotations);
		}

		// Token: 0x04000C93 RID: 3219
		[ConstraintType(typeof(IPoseBlendingSource), true)]
		[SerializeField]
		private Object m_normalVsSexy;

		// Token: 0x04000C94 RID: 3220
		[ConstraintType(typeof(IPoseBlendingSource), true)]
		[SerializeField]
		private Object m_sexyEstatura;

		// Token: 0x04000C95 RID: 3221
		[ConstraintType(typeof(IPoseBlendingSource), true)]
		[SerializeField]
		private Object m_normalEstatura;
	}
}
