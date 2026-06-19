using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x02000099 RID: 153
	public abstract class DisplayableArgumentoDeEfecto<T> : ArgumentoDeEfecto<T>, IDisplayableArgumentoDeEfecto, IDisplayableArgCategorable where T : DisplayableArgumentoDeEfecto<T>
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000332 RID: 818
		public abstract DisplayableBuffCategory displayableBuffType { get; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000333 RID: 819 RVA: 0x000140D6 File Offset: 0x000122D6
		// (set) Token: 0x06000334 RID: 820 RVA: 0x000140DE File Offset: 0x000122DE
		public bool flagUpdateNonLocalizedTextV2
		{
			get
			{
				return this.flagUpdateNonLocalizedTextNext;
			}
			set
			{
				this.flagUpdateNonLocalizedTextNext = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000335 RID: 821 RVA: 0x000140E7 File Offset: 0x000122E7
		// (set) Token: 0x06000336 RID: 822 RVA: 0x000140EF File Offset: 0x000122EF
		public bool AlwaysUpdateNonLocalizedText
		{
			get
			{
				return this.flagUpdateNonLocalizedText;
			}
			set
			{
				this.flagUpdateNonLocalizedText = value;
			}
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000140F8 File Offset: 0x000122F8
		public string NonLocalizedText(DisplayableBuff buff)
		{
			if (this.flagUpdateNonLocalizedTextV2 || this.AlwaysUpdateNonLocalizedText || string.IsNullOrWhiteSpace(this.nonLocalizedText))
			{
				this.nonLocalizedText = this.GenerateNonLocalizedText(buff);
				this.flagUpdateNonLocalizedTextV2 = false;
			}
			return this.nonLocalizedText;
		}

		// Token: 0x06000338 RID: 824
		protected abstract string GenerateNonLocalizedText(DisplayableBuff buff);

		// Token: 0x04000327 RID: 807
		[SerializeField]
		private bool flagUpdateNonLocalizedText;

		// Token: 0x04000328 RID: 808
		[SerializeField]
		private bool flagUpdateNonLocalizedTextNext;

		// Token: 0x04000329 RID: 809
		public string nonLocalizedText;
	}
}
