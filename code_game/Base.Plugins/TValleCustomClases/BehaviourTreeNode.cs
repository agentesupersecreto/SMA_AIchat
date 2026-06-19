using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000078 RID: 120
	public abstract class BehaviourTreeNode : MonoBehaviour, IEnumerable<BehaviourTreeNode>, IEnumerable
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000387 RID: 903
		public abstract BehaviourTreeNode parent { get; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000388 RID: 904
		protected abstract List<BehaviourTreeNode> children { get; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000389 RID: 905 RVA: 0x0000F313 File Offset: 0x0000D513
		public virtual int count
		{
			get
			{
				return this.children.Count;
			}
		}

		// Token: 0x17000077 RID: 119
		public virtual BehaviourTreeNode this[int i]
		{
			get
			{
				return this.children[i];
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000F32E File Offset: 0x0000D52E
		public virtual bool isvalid()
		{
			return this != null && this.children != null && !this.children.Contains(null);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000F352 File Offset: 0x0000D552
		public IEnumerator<BehaviourTreeNode> GetEnumerator()
		{
			return this.children.GetEnumerator();
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000F364 File Offset: 0x0000D564
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.children.GetEnumerator();
		}
	}
}
