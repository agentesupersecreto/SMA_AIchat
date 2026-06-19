using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000075 RID: 117
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class InputConToolTipAttribute : DynamicUIElementAttribute
	{
		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00007A76 File Offset: 0x00005C76
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.inputConToolTip;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00007A7A File Offset: 0x00005C7A
		// (set) Token: 0x0600034E RID: 846 RVA: 0x00007A82 File Offset: 0x00005C82
		public InputConToolTipAttribute.ContentType contentType { get; set; }

		// Token: 0x02000171 RID: 369
		public enum ContentType
		{
			// Token: 0x04000484 RID: 1156
			Standard,
			// Token: 0x04000485 RID: 1157
			Autocorrected,
			// Token: 0x04000486 RID: 1158
			IntegerNumber,
			// Token: 0x04000487 RID: 1159
			DecimalNumber,
			// Token: 0x04000488 RID: 1160
			Alphanumeric,
			// Token: 0x04000489 RID: 1161
			Name,
			// Token: 0x0400048A RID: 1162
			EmailAddress,
			// Token: 0x0400048B RID: 1163
			Password,
			// Token: 0x0400048C RID: 1164
			Pin,
			// Token: 0x0400048D RID: 1165
			Custom
		}
	}
}
