using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts
{
	// Token: 0x020000F2 RID: 242
	[Serializable]
	public class PenisPartHit : ILimpiarPenisHit, IPoblarPenisHit
	{
		// Token: 0x06000A55 RID: 2645 RVA: 0x00021B8C File Offset: 0x0001FD8C
		internal PenisPartHit()
		{
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000A56 RID: 2646 RVA: 0x00021B94 File Offset: 0x0001FD94
		public bool isValid
		{
			get
			{
				return this.hit != null && this.penis != null;
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x00021BBF File Offset: 0x0001FDBF
		// (set) Token: 0x06000A58 RID: 2648 RVA: 0x00021BC7 File Offset: 0x0001FDC7
		public PenisPart penisPart { get; private set; }

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x00021BD0 File Offset: 0x0001FDD0
		public Penetrador penis
		{
			get
			{
				PenisPart penisPart = this.penisPart;
				if (penisPart == null)
				{
					return null;
				}
				return penisPart.penis;
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06000A5A RID: 2650 RVA: 0x00021BE3 File Offset: 0x0001FDE3
		// (set) Token: 0x06000A5B RID: 2651 RVA: 0x00021BEB File Offset: 0x0001FDEB
		public float profundidad { get; private set; }

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x00021BF4 File Offset: 0x0001FDF4
		// (set) Token: 0x06000A5D RID: 2653 RVA: 0x00021BFC File Offset: 0x0001FDFC
		public float maxProfundidad { get; private set; }

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000A5E RID: 2654 RVA: 0x00021C05 File Offset: 0x0001FE05
		// (set) Token: 0x06000A5F RID: 2655 RVA: 0x00021C0D File Offset: 0x0001FE0D
		public Vector3 worldHitPosition { get; private set; }

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000A60 RID: 2656 RVA: 0x00021C16 File Offset: 0x0001FE16
		// (set) Token: 0x06000A61 RID: 2657 RVA: 0x00021C1E File Offset: 0x0001FE1E
		public Vector3 worldHitNormal { get; private set; }

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06000A62 RID: 2658 RVA: 0x00021C27 File Offset: 0x0001FE27
		// (set) Token: 0x06000A63 RID: 2659 RVA: 0x00021C2F File Offset: 0x0001FE2F
		public RaycastHit? hit { get; private set; }

		// Token: 0x06000A64 RID: 2660 RVA: 0x00021C38 File Offset: 0x0001FE38
		void ILimpiarPenisHit.Limpiar()
		{
			this.penisPart = null;
			this.hit = null;
			this.profundidad = 0f;
			this.maxProfundidad = 0f;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x00021C74 File Offset: 0x0001FE74
		bool IPoblarPenisHit.Poblar(RaycastHit hit, PenisPart parte, float largoAgujero)
		{
			this.hit = new RaycastHit?(hit);
			this.penisPart = parte;
			float distance = hit.distance;
			this.maxProfundidad = largoAgujero;
			this.profundidad = largoAgujero - distance;
			if (this.profundidad < 0f)
			{
				this.profundidad = 0f;
			}
			this.worldHitPosition = hit.point;
			this.worldHitNormal = hit.normal;
			return this.profundidad > 0f;
		}
	}
}
