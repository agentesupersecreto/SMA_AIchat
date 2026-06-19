using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.Memorias.JsonMemorias.Clases;
using Assets._ReusableScripts.Memorias.JsonMemorias.Mapas.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.Memorias.JsonMemorias
{
	// Token: 0x02000010 RID: 16
	public class NodeDeMemoriaBehaviour : CustomMonobehaviour, IJsonMemoryNodeBehaviour, IMemoryNode<string, IJsonMemoryNode>, IMemoryNodeEvents, IDataContainer<string>, ISerializedDataContainer, IJsonMemoryNodeReadOnlyBehaviour, IMemoryNodeReadOnly<string, IJsonMemoryNodeReadOnly>, IDataContainerReadOnly<string>
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000029EA File Offset: 0x00000BEA
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000029F2 File Offset: 0x00000BF2
		public string id
		{
			get
			{
				return base.name;
			}
			private set
			{
				base.name = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000029FB File Offset: 0x00000BFB
		public IJsonMemoryNode node
		{
			get
			{
				return this.m_node;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002A03 File Offset: 0x00000C03
		public IReadOnlyDictionary<string, string> data
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002A0B File Offset: 0x00000C0B
		public IReadOnlyList<NodeDeMemoriaBehaviour> children
		{
			get
			{
				return this.m_children;
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000065 RID: 101 RVA: 0x00002A14 File Offset: 0x00000C14
		// (remove) Token: 0x06000066 RID: 102 RVA: 0x00002A4C File Offset: 0x00000C4C
		public event Action<IMemoryNode<string, IJsonMemoryNode>> loaded;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000067 RID: 103 RVA: 0x00002A84 File Offset: 0x00000C84
		// (remove) Token: 0x06000068 RID: 104 RVA: 0x00002ABC File Offset: 0x00000CBC
		public event Action<IMemoryNode<string, IJsonMemoryNode>> saving;

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002AF1 File Offset: 0x00000CF1
		public bool isRoot
		{
			get
			{
				return this.m_rootBehaviour == this;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002AFC File Offset: 0x00000CFC
		public IJsonMemoryNode root
		{
			get
			{
				return ((NodeDeMemoriaBehaviour)this.m_rootBehaviour).node;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002B0E File Offset: 0x00000D0E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_rootBehaviour = NodeDeMemoriaBehaviour.GetRootBehaviour(this);
			if (this.m_rootBehaviour == null)
			{
				throw new ArgumentNullException("m_rootBehaviour", "m_rootBehaviour null reference.");
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002B3C File Offset: 0x00000D3C
		private static IJsonMemoryNodeBehaviour GetRootBehaviour(IJsonMemoryNodeBehaviour self)
		{
			Transform parent = self.transform.parent;
			IJsonMemoryNodeBehaviour jsonMemoryNodeBehaviour;
			if (parent != null && parent.TryGetComponent<IJsonMemoryNodeBehaviour>(out jsonMemoryNodeBehaviour))
			{
				return NodeDeMemoriaBehaviour.GetRootBehaviour(jsonMemoryNodeBehaviour);
			}
			return self;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002B70 File Offset: 0x00000D70
		public void AddData(string id, string data, bool replace = true)
		{
			this.m_data.AddData(id, data, replace);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002B80 File Offset: 0x00000D80
		public string FindData(string id)
		{
			return this.m_data.FindData(id);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002B8E File Offset: 0x00000D8E
		public bool RemoverData(string id)
		{
			return this.m_data.RemoverData(id);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002B9C File Offset: 0x00000D9C
		public void ClearData()
		{
			this.m_data.ClearData();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002BA9 File Offset: 0x00000DA9
		public void ResetMemoria()
		{
			this.m_data = new StringKeyStringValueDictionary();
			this.m_children = new List<NodeDeMemoriaBehaviour>();
			this.InyectExtraData();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002BC7 File Offset: 0x00000DC7
		public NodeDeMemoriaBehaviour FindChild(string id)
		{
			Transform transform = base.transform.Find(id);
			if (transform == null)
			{
				return null;
			}
			return transform.GetComponent<NodeDeMemoriaBehaviour>();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002BE0 File Offset: 0x00000DE0
		public NodeDeMemoriaBehaviour FindChildNotNull(string id)
		{
			NodeDeMemoriaBehaviour nodeDeMemoriaBehaviour = this.FindChild(id);
			if (nodeDeMemoriaBehaviour != null)
			{
				return nodeDeMemoriaBehaviour;
			}
			nodeDeMemoriaBehaviour = base.transform.CreateChild(id).gameObject.AddComponent<NodeDeMemoriaBehaviour>();
			nodeDeMemoriaBehaviour.id = id;
			this.m_children.Add(nodeDeMemoriaBehaviour);
			return nodeDeMemoriaBehaviour;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002C2C File Offset: 0x00000E2C
		public void AddChild(NodeDeMemoriaBehaviour child)
		{
			if (child == null)
			{
				return;
			}
			if (child.id == null)
			{
				throw new ArgumentNullException("id", "id null reference.");
			}
			child.transform.parent = base.transform;
			this.m_children.Add(child);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002C78 File Offset: 0x00000E78
		public bool RemoverChild(IMemoryNode<string, IJsonMemoryNode> child)
		{
			NodeDeMemoriaBehaviour nodeDeMemoriaBehaviour = child as NodeDeMemoriaBehaviour;
			if (nodeDeMemoriaBehaviour == null)
			{
				return false;
			}
			if (this.m_children.Remove(nodeDeMemoriaBehaviour))
			{
				nodeDeMemoriaBehaviour.transform.parent = null;
				return true;
			}
			return false;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002CB4 File Offset: 0x00000EB4
		public bool RemoverChild(string id)
		{
			NodeDeMemoriaBehaviour nodeDeMemoriaBehaviour = this.m_children.FirstOrDefault((NodeDeMemoriaBehaviour c) => c.id == id);
			return nodeDeMemoriaBehaviour != null && this.RemoverChild(nodeDeMemoriaBehaviour);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002CF8 File Offset: 0x00000EF8
		private void InyectExtraData()
		{
			this.InyectData();
			this.InyectDataInMaps();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002D08 File Offset: 0x00000F08
		public void Load(IJsonMemoryNode loadData)
		{
			this.m_node = loadData;
			this.id = loadData.nodeID;
			this.m_data = new StringKeyStringValueDictionary();
			this.m_data.LoadFrom(loadData.data);
			for (int i = 0; i < loadData.children.Count; i++)
			{
				IJsonMemoryNode jsonMemoryNode = (IJsonMemoryNode)loadData.children[i];
				IMemoryNodeEvents memoryNodeEvents;
				IMemoryNode<string, IJsonMemoryNode> memoryNode = (memoryNodeEvents = this.FindChildNotNull(jsonMemoryNode.nodeID));
				memoryNodeEvents.Loading();
				memoryNode.Load(jsonMemoryNode);
				memoryNodeEvents.Loaded();
			}
			Action<IMemoryNode<string, IJsonMemoryNode>> action = this.loaded;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002DA0 File Offset: 0x00000FA0
		public IJsonMemoryNode Save()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			this.m_node = new JsonMemoryNode(this.id, this.root);
			foreach (KeyValuePair<string, string> keyValuePair in this.m_data)
			{
				this.m_node.AddData(keyValuePair.Key, keyValuePair.Value, true);
			}
			this.save();
			return this.m_node;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002E38 File Offset: 0x00001038
		public IJsonMemoryNode Save(IJsonMemoryNode Root)
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			this.m_node = new JsonMemoryNode(this.id, Root);
			foreach (KeyValuePair<string, string> keyValuePair in this.m_data)
			{
				this.m_node.AddData(keyValuePair.Key, keyValuePair.Value, true);
			}
			this.save();
			return this.m_node;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002ECC File Offset: 0x000010CC
		public void SaveToNode(IJsonMemoryNode Node)
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			this.m_node = Node;
			foreach (KeyValuePair<string, string> keyValuePair in this.m_data)
			{
				this.m_node.AddData(keyValuePair.Key, keyValuePair.Value, true);
			}
			this.save();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002F50 File Offset: 0x00001150
		private void save()
		{
			Action<IMemoryNode<string, IJsonMemoryNode>> action = this.saving;
			if (action != null)
			{
				action(this);
			}
			foreach (object obj in base.transform)
			{
				IMemoryNodeEvents componentNotNull;
				NodeDeMemoriaBehaviour nodeDeMemoriaBehaviour = (componentNotNull = ((Transform)obj).GetComponentNotNull<NodeDeMemoriaBehaviour>());
				componentNotNull.Saving();
				IJsonMemoryNode jsonMemoryNode = nodeDeMemoriaBehaviour.Save();
				componentNotNull.Saved();
				this.m_node.AddChild(jsonMemoryNode);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002FD8 File Offset: 0x000011D8
		private void InyectData()
		{
			foreach (KeyValuePair<string, string> keyValuePair in this.m_stringInyectores)
			{
				if (this.m_data.ContainsKey(keyValuePair.Key))
				{
					this.m_data[keyValuePair.Key] = keyValuePair.Value;
				}
				else
				{
					this.m_data.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
			foreach (KeyValuePair<string, int> keyValuePair2 in this.m_intInyectores)
			{
				if (this.m_data.ContainsKey(keyValuePair2.Key))
				{
					this.m_data[keyValuePair2.Key] = keyValuePair2.Value.ToString();
				}
				else
				{
					this.m_data.Add(keyValuePair2.Key, keyValuePair2.Value.ToString());
				}
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003104 File Offset: 0x00001304
		private void InyectDataInMaps()
		{
			foreach (MapaInyectorDeMemoriaString mapaInyectorDeMemoriaString in this.m_inyectores)
			{
				if (mapaInyectorDeMemoriaString == null)
				{
					Debug.LogWarning("mapa inyector es nullo", this);
				}
				else
				{
					mapaInyectorDeMemoriaString.OnLoad();
					foreach (KeyValuePair<string, string> keyValuePair in mapaInyectorDeMemoriaString.data)
					{
						if (this.m_data.ContainsKey(keyValuePair.Key))
						{
							this.m_data[keyValuePair.Key] = keyValuePair.Value;
						}
						else
						{
							this.m_data.Add(keyValuePair.Key, keyValuePair.Value);
						}
					}
				}
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000031F8 File Offset: 0x000013F8
		IReadOnlyList<IMemoryNode<string, IJsonMemoryNode>> IMemoryNode<string, IJsonMemoryNode>.children
		{
			get
			{
				return this.m_children;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00003200 File Offset: 0x00001400
		IReadOnlyDictionary<string, string> IMemoryNode<string, IJsonMemoryNode>.data
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003208 File Offset: 0x00001408
		string IMemoryNode<string, IJsonMemoryNode>.nodeID
		{
			get
			{
				return this.id;
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003210 File Offset: 0x00001410
		IMemoryNode<string, IJsonMemoryNode> IMemoryNode<string, IJsonMemoryNode>.FindChild(string id)
		{
			return this.FindChild(id);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003219 File Offset: 0x00001419
		IMemoryNode<string, IJsonMemoryNode> IMemoryNode<string, IJsonMemoryNode>.FindChildNotNull(string id)
		{
			return this.FindChildNotNull(id);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003222 File Offset: 0x00001422
		T IMemoryNode<string, IJsonMemoryNode>.FindChild<T>(string id)
		{
			return this.FindChild(id) as T;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003235 File Offset: 0x00001435
		T IMemoryNode<string, IJsonMemoryNode>.FindChildNotNull<T>(string id)
		{
			return this.FindChildNotNull(id) as T;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003248 File Offset: 0x00001448
		void IMemoryNode<string, IJsonMemoryNode>.Load(IJsonMemoryNode loadData)
		{
			this.Load(loadData);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003251 File Offset: 0x00001451
		IJsonMemoryNode IMemoryNode<string, IJsonMemoryNode>.Save()
		{
			return this.Save();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003259 File Offset: 0x00001459
		void IDataContainer<string>.AddData(string id, string data, bool replace)
		{
			this.AddData(id, data, replace);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003264 File Offset: 0x00001464
		void IMemoryNode<string, IJsonMemoryNode>.AddChild(IMemoryNode<string, IJsonMemoryNode> child)
		{
			this.AddChild((NodeDeMemoriaBehaviour)child);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003272 File Offset: 0x00001472
		void IMemoryNodeEvents.Loading()
		{
			this.InyectExtraData();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000327A File Offset: 0x0000147A
		void IMemoryNodeEvents.Loaded()
		{
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000327C File Offset: 0x0000147C
		void IMemoryNodeEvents.Saving()
		{
			this.InyectExtraData();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003284 File Offset: 0x00001484
		void IMemoryNodeEvents.Saved()
		{
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00003286 File Offset: 0x00001486
		string IMemoryNodeReadOnly<string, IJsonMemoryNodeReadOnly>.nodeID
		{
			get
			{
				return this.id;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600008F RID: 143 RVA: 0x0000328E File Offset: 0x0000148E
		IReadOnlyDictionary<string, string> IMemoryNodeReadOnly<string, IJsonMemoryNodeReadOnly>.data
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00003296 File Offset: 0x00001496
		IReadOnlyList<IMemoryNodeReadOnly<string, IJsonMemoryNodeReadOnly>> IMemoryNodeReadOnly<string, IJsonMemoryNodeReadOnly>.childrenReadOnly
		{
			get
			{
				return this.m_children;
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000329E File Offset: 0x0000149E
		IMemoryNodeReadOnly<string, IJsonMemoryNodeReadOnly> IMemoryNodeReadOnly<string, IJsonMemoryNodeReadOnly>.FindChildReadOnly(string id)
		{
			return this.FindChild(id);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000032A7 File Offset: 0x000014A7
		T IMemoryNodeReadOnly<string, IJsonMemoryNodeReadOnly>.FindChildReadOnly<T>(string id)
		{
			return this.FindChild(id) as T;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000032BA File Offset: 0x000014BA
		string IDataContainerReadOnly<string>.FindData(string id)
		{
			return this.FindData(id);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003302 File Offset: 0x00001502
		Transform IJsonMemoryNodeBehaviour.get_transform()
		{
			return base.transform;
		}

		// Token: 0x04000026 RID: 38
		[HideInInspector]
		[SerializeField]
		private StringKeyStringValueDictionary m_data = new StringKeyStringValueDictionary();

		// Token: 0x04000027 RID: 39
		[HideInInspector]
		[SerializeField]
		private List<NodeDeMemoriaBehaviour> m_children = new List<NodeDeMemoriaBehaviour>();

		// Token: 0x04000028 RID: 40
		[NonSerialized]
		private IJsonMemoryNode m_node;

		// Token: 0x04000029 RID: 41
		[CoolArrayItem]
		[SerializeField]
		private List<MapaInyectorDeMemoriaString> m_inyectores = new List<MapaInyectorDeMemoriaString>();

		// Token: 0x0400002A RID: 42
		[SerializeField]
		private StringKeyStringValueDictionary m_stringInyectores = new StringKeyStringValueDictionary();

		// Token: 0x0400002B RID: 43
		[SerializeField]
		private StringKeyIntValueDictionary m_intInyectores = new StringKeyIntValueDictionary();

		// Token: 0x0400002E RID: 46
		[SerializeReference]
		private IJsonMemoryNodeBehaviour m_rootBehaviour;
	}
}
