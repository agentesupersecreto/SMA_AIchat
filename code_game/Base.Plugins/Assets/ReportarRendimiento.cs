using System;
using System.Diagnostics;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000F0 RID: 240
	public static class ReportarRendimiento
	{
		// Token: 0x06000695 RID: 1685 RVA: 0x00017DED File Offset: 0x00015FED
		[Conditional("UNITY_EDITOR")]
		public static void BeginSample(string name)
		{
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00017DEF File Offset: 0x00015FEF
		[Conditional("UNITY_EDITOR")]
		public static void BeginSample(string name, Object obj)
		{
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00017DF1 File Offset: 0x00015FF1
		[Conditional("UNITY_EDITOR")]
		public static void BeginSampleEspecifico(string name, object t)
		{
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00017DF3 File Offset: 0x00015FF3
		[Conditional("UNITY_EDITOR")]
		public static void EndSample()
		{
		}
	}
}
