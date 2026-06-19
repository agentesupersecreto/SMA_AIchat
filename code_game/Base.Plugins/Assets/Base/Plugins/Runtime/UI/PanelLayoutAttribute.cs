using System;

namespace Assets.Base.Plugins.Runtime.UI
{
	// Token: 0x0200018E RID: 398
	public sealed class PanelLayoutAttribute : Attribute
	{
		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x00025FAB File Offset: 0x000241AB
		public bool alturaMinimaUsing
		{
			get
			{
				return this.m_alturaMinimaUsing;
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x00025FB3 File Offset: 0x000241B3
		public bool alturaPreferidaUsing
		{
			get
			{
				return this.m_alturaPreferidaUsing;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x00025FBB File Offset: 0x000241BB
		// (set) Token: 0x06000BA1 RID: 2977 RVA: 0x00025FC3 File Offset: 0x000241C3
		public float alturaMinima
		{
			get
			{
				return this.m_alturaMinima;
			}
			set
			{
				this.m_alturaMinima = value;
				this.m_alturaMinimaUsing = true;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x00025FD3 File Offset: 0x000241D3
		// (set) Token: 0x06000BA3 RID: 2979 RVA: 0x00025FDB File Offset: 0x000241DB
		public float alturaPreferida
		{
			get
			{
				return this.m_alturaPreferida;
			}
			set
			{
				this.m_alturaPreferida = value;
				this.m_alturaPreferidaUsing = true;
			}
		}

		// Token: 0x040003C8 RID: 968
		private bool m_alturaMinimaUsing;

		// Token: 0x040003C9 RID: 969
		private bool m_alturaPreferidaUsing;

		// Token: 0x040003CA RID: 970
		private float m_alturaMinima;

		// Token: 0x040003CB RID: 971
		private float m_alturaPreferida;
	}
}
