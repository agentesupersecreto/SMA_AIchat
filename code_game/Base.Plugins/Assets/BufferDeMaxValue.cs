using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200010D RID: 269
	[Serializable]
	public class BufferDeMaxValue
	{
		// Token: 0x060007AA RID: 1962 RVA: 0x0001ACE9 File Offset: 0x00018EE9
		public void Add(IBufferDeMaxValueListiner listiner)
		{
			if (listiner == null)
			{
				return;
			}
			if (!this.m_listiners.Add(listiner))
			{
				Debug.LogError("Tratando de añadir listiner repetido: " + listiner.name);
			}
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0001AD12 File Offset: 0x00018F12
		public void Remove(IBufferDeMaxValueListiner listiner)
		{
			if (listiner == null)
			{
				return;
			}
			this.m_listiners.Remove(listiner);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0001AD28 File Offset: 0x00018F28
		public void DoUpdate()
		{
			try
			{
				for (int i = this.m_enQueue.Count - 1; i >= 0; i--)
				{
					IList<IBufferDeMaxValueListiner> item = this.m_enQueue[i].Item2;
					for (int j = item.Count - 1; j >= 0; j--)
					{
						IBufferDeMaxValueListiner bufferDeMaxValueListiner = item[j];
						if (bufferDeMaxValueListiner == null || !this.m_listiners.Contains(bufferDeMaxValueListiner))
						{
							item.RemoveAt(j);
						}
						else if (this.m_llamados.Add(bufferDeMaxValueListiner) && bufferDeMaxValueListiner.OnMaxValue())
						{
							item.RemoveAt(j);
						}
					}
					if (item.Count == 0)
					{
						this.m_enQueue.RemoveAt(i);
						this.m_buffer.RemoveAt(i);
					}
				}
			}
			finally
			{
				if (this.m_llamados.Count > 0)
				{
					this.m_llamados.Clear();
				}
			}
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0001AE04 File Offset: 0x00019004
		public void OnMaxValue()
		{
			ForcedUpdateId current = ForcedUpdateId.current;
			if (this.m_buffer.Contains(current))
			{
				Debug.LogError("Max value: Id Repetida");
				return;
			}
			this.m_buffer.Insert(0, current);
			ValueTuple<ForcedUpdateId, IList<IBufferDeMaxValueListiner>> valueTuple = new ValueTuple<ForcedUpdateId, IList<IBufferDeMaxValueListiner>>
			{
				Item1 = current,
				Item2 = this.m_listiners.ToList<IBufferDeMaxValueListiner>()
			};
			this.m_enQueue.Insert(0, valueTuple);
			for (int i = 0; i < valueTuple.Item2.Count; i++)
			{
				IBufferDeMaxValueListiner bufferDeMaxValueListiner = valueTuple.Item2[i];
				if (bufferDeMaxValueListiner != null)
				{
					bufferDeMaxValueListiner.OnEnqueue();
				}
			}
		}

		// Token: 0x0400021B RID: 539
		[ReadOnlyUI]
		[SerializeField]
		private List<ForcedUpdateId> m_buffer = new List<ForcedUpdateId>();

		// Token: 0x0400021C RID: 540
		[NonSerialized]
		private HashSetList<IBufferDeMaxValueListiner> m_listiners = new HashSetList<IBufferDeMaxValueListiner>();

		// Token: 0x0400021D RID: 541
		[NonSerialized]
		private List<ValueTuple<ForcedUpdateId, IList<IBufferDeMaxValueListiner>>> m_enQueue = new List<ValueTuple<ForcedUpdateId, IList<IBufferDeMaxValueListiner>>>();

		// Token: 0x0400021E RID: 542
		private HashSet<IBufferDeMaxValueListiner> m_llamados = new HashSet<IBufferDeMaxValueListiner>();
	}
}
