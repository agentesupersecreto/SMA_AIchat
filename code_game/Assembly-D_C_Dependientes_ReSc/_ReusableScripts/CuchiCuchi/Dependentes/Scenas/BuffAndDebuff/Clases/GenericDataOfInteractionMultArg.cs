using System;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000A1 RID: 161
	[Serializable]
	public class GenericDataOfInteractionMultArg : IDataOfInteractionMultArg
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000361 RID: 865 RVA: 0x0001417D File Offset: 0x0001237D
		// (set) Token: 0x06000362 RID: 866 RVA: 0x00014185 File Offset: 0x00012385
		InterationReceivedType[] IDataOfInteractionMultArg.interationReceivedTypes
		{
			get
			{
				return this.interationReceivedTypes;
			}
			set
			{
				this.interationReceivedTypes = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0001418E File Offset: 0x0001238E
		// (set) Token: 0x06000364 RID: 868 RVA: 0x00014196 File Offset: 0x00012396
		TriggeringBodyPart[] IDataOfInteractionMultArg.fromParts
		{
			get
			{
				return this.fromParts;
			}
			set
			{
				this.fromParts = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000365 RID: 869 RVA: 0x0001419F File Offset: 0x0001239F
		// (set) Token: 0x06000366 RID: 870 RVA: 0x000141A7 File Offset: 0x000123A7
		SensitiveBodyPart[] IDataOfInteractionMultArg.toParts
		{
			get
			{
				return this.toParts;
			}
			set
			{
				this.toParts = value;
			}
		}

		// Token: 0x0400032E RID: 814
		public InterationReceivedType[] interationReceivedTypes;

		// Token: 0x0400032F RID: 815
		public TriggeringBodyPart[] fromParts;

		// Token: 0x04000330 RID: 816
		public SensitiveBodyPart[] toParts;
	}
}
