using System;

namespace Unity.IL2CPP.CompilerServices
{
	// Token: 0x020000A2 RID: 162
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
	public class Il2CppSetOptionAttribute : Attribute
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x00016137 File Offset: 0x00014337
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x0001613F File Offset: 0x0001433F
		public Option Option { get; private set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x00016148 File Offset: 0x00014348
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x00016150 File Offset: 0x00014350
		public object Value { get; private set; }

		// Token: 0x060004EF RID: 1263 RVA: 0x00016159 File Offset: 0x00014359
		public Il2CppSetOptionAttribute(Option option, object value)
		{
			this.Option = option;
			this.Value = value;
		}
	}
}
