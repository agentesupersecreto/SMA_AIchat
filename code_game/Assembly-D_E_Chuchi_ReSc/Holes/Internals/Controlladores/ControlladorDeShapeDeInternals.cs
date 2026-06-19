using System;
using Assets.Base.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores
{
	// Token: 0x020001B8 RID: 440
	public abstract class ControlladorDeShapeDeInternals : ControllerGenericoDeShapesKey
	{
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000A5F RID: 2655 RVA: 0x0002F28D File Offset: 0x0002D48D
		public SkinnedMeshRenderer internalsRenderer
		{
			get
			{
				return this.m_internalsRenderer;
			}
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0002F298 File Offset: 0x0002D498
		protected override void AwakeUnityEvent()
		{
			HoleInternal componentInParent = base.GetComponentInParent<HoleInternal>();
			if (componentInParent == null)
			{
				throw new ArgumentNullException("internals", "internals null reference.");
			}
			this.m_internalsRenderer = componentInParent.GetComponentInChildren<SkinnedMeshRenderer>();
			base.AwakeUnityEvent();
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x0002F28D File Offset: 0x0002D48D
		protected override SkinnedMeshRenderer GetRenderer()
		{
			return this.m_internalsRenderer;
		}

		// Token: 0x04000843 RID: 2115
		private SkinnedMeshRenderer m_internalsRenderer;
	}
}
