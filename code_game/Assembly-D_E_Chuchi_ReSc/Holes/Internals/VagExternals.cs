using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals
{
	// Token: 0x0200019F RID: 415
	public sealed class VagExternals : HoleExternal
	{
		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x0002C10B File Offset: 0x0002A30B
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterPhyscisConstraints);
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x00005F51 File Offset: 0x00004151
		public override int updateEvent1ExtraCalls
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0002C114 File Offset: 0x0002A314
		public override void OnUpdateEvent1()
		{
			if (GlobalUpdater.CurrentUserCallCount(base.updaterUser) != 2)
			{
				return;
			}
			this.m_overcanal000.Copy(this.m_internalsOvercanalRoot);
			this.m_overcanal001.Copy(this.m_internalsOvercanalRoot);
			this.m_overcanal002.Copy(this.m_internalsOvercanalRoot);
			this.m_overcanal003.Copy(this.m_internalsOvercanalRoot);
		}

		// Token: 0x040007BF RID: 1983
		[SerializeField]
		private Transform m_internalsOvercanalRoot;

		// Token: 0x040007C0 RID: 1984
		[SerializeField]
		private VagExternals.CopyScalePar m_overcanal000 = new VagExternals.CopyScalePar();

		// Token: 0x040007C1 RID: 1985
		[SerializeField]
		private VagExternals.CopyScalePar m_overcanal001 = new VagExternals.CopyScalePar();

		// Token: 0x040007C2 RID: 1986
		[SerializeField]
		private VagExternals.CopyScalePar m_overcanal002 = new VagExternals.CopyScalePar();

		// Token: 0x040007C3 RID: 1987
		[SerializeField]
		private VagExternals.CopyScalePar m_overcanal003 = new VagExternals.CopyScalePar();

		// Token: 0x020001A0 RID: 416
		[Serializable]
		public class CopyScalePar
		{
			// Token: 0x060009DD RID: 2525 RVA: 0x0002C1A8 File Offset: 0x0002A3A8
			public void Copy(Transform overcanalRoot)
			{
				float num = overcanalRoot.localScale.Escala();
				Vector3 vector = this.other.localScale * num;
				float num2 = (vector.y + vector.x) / 2f;
				Vector3 vector2 = new Vector3(num2, num2, Mathf.LerpUnclamped(1f, num2, this.zW));
				this.self.localScale = Vector3.LerpUnclamped(Vector3.one, vector2, this.w);
			}

			// Token: 0x040007C4 RID: 1988
			public float w = 1f;

			// Token: 0x040007C5 RID: 1989
			public float zW;

			// Token: 0x040007C6 RID: 1990
			public Transform self;

			// Token: 0x040007C7 RID: 1991
			public Transform other;
		}
	}
}
