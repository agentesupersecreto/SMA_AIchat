using System;
using UnityEngine;

namespace NodeEditorFramework
{
	// Token: 0x0200008E RID: 142
	public abstract class NodeEditorCallbackReceiver : MonoBehaviour
	{
		// Token: 0x0600042C RID: 1068 RVA: 0x0001295E File Offset: 0x00010B5E
		public virtual void OnEditorStartUp()
		{
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00012960 File Offset: 0x00010B60
		public virtual void OnLoadCanvas(NodeCanvas canvas)
		{
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00012962 File Offset: 0x00010B62
		public virtual void OnLoadEditorState(NodeEditorState editorState)
		{
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00012964 File Offset: 0x00010B64
		public virtual void OnSaveCanvas(NodeCanvas canvas)
		{
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00012966 File Offset: 0x00010B66
		public virtual void OnSaveEditorState(NodeEditorState editorState)
		{
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00012968 File Offset: 0x00010B68
		public virtual void OnAddNode(Node node)
		{
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0001296A File Offset: 0x00010B6A
		public virtual void OnDeleteNode(Node node)
		{
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0001296C File Offset: 0x00010B6C
		public virtual void OnMoveNode(Node node)
		{
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0001296E File Offset: 0x00010B6E
		public virtual void OnAddConnection(NodeInput input)
		{
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00012970 File Offset: 0x00010B70
		public virtual void OnRemoveConnection(NodeInput input)
		{
		}
	}
}
