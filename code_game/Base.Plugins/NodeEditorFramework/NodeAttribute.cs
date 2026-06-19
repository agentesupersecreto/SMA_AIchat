using System;

namespace NodeEditorFramework
{
	// Token: 0x02000099 RID: 153
	public class NodeAttribute : Attribute
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00014308 File Offset: 0x00012508
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x00014310 File Offset: 0x00012510
		public bool hide { get; private set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x00014319 File Offset: 0x00012519
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x00014321 File Offset: 0x00012521
		public string contextText { get; private set; }

		// Token: 0x06000495 RID: 1173 RVA: 0x0001432A File Offset: 0x0001252A
		public NodeAttribute(bool HideNode, string ReplacedContextText)
		{
			this.hide = HideNode;
			this.contextText = ReplacedContextText;
		}
	}
}
