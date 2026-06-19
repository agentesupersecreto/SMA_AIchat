using System;
using Assets._ReusableScripts.CuchiCuchi.Skins;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Skins
{
	// Token: 0x020001A5 RID: 421
	public class HoleInternalSkin : Skin
	{
		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00004252 File Offset: 0x00002452
		protected sealed override bool cookAfterPhysics
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000A02 RID: 2562 RVA: 0x00004252 File Offset: 0x00002452
		// (set) Token: 0x06000A03 RID: 2563 RVA: 0x00003BC5 File Offset: 0x00001DC5
		public sealed override bool corregirLayer
		{
			get
			{
				return false;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000A04 RID: 2564 RVA: 0x00004252 File Offset: 0x00002452
		// (set) Token: 0x06000A05 RID: 2565 RVA: 0x00003BC5 File Offset: 0x00001DC5
		public sealed override bool corregirRootBone
		{
			get
			{
				return false;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x00004252 File Offset: 0x00002452
		// (set) Token: 0x06000A07 RID: 2567 RVA: 0x00003BC5 File Offset: 0x00001DC5
		public sealed override bool cambiarBonesReferences
		{
			get
			{
				return false;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x0002D4C5 File Offset: 0x0002B6C5
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.CloneMaterialsSimple();
		}
	}
}
