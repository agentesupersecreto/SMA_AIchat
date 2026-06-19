using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200007B RID: 123
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class PosePortraitAttribute : DynamicUIElementAttribute
	{
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00007AF8 File Offset: 0x00005CF8
		public override UIElementoDinamico tipo
		{
			get
			{
				return UIElementoDinamico.posePortrait;
			}
		}
	}
}
