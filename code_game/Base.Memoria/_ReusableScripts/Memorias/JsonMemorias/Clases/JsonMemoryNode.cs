using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.Memorias.JsonMemorias.Clases
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	public class JsonMemoryNode : IJsonMemoryNode, IMemoryNode<string, string>, IMemoryNodeEvents, IDataContainer<string>, ISerializedDataContainer, IJsonMemoryNodeReadOnly, IMemoryNodeReadOnly<string, string>, IDataContainerReadOnly<string>
	{
		// Token: 0x0600009B RID: 155 RVA: 0x0000332F File Offset: 0x0000152F
		public static JsonMemoryNode ProducirRoot(string id, IMemoria mem)
		{
			if (mem == null)
			{
				throw new ArgumentNullException("mem", "mem null reference.");
			}
			return new JsonMemoryNode(id)
			{
				m_root = null,
				m_memory = mem,
				m_isRoot = true
			};
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003360 File Offset: 0x00001560
		public static T ProducirRoot<T>(string id, IMemoria mem) where T : JsonMemoryNode, new()
		{
			if (id == null)
			{
				throw new ArgumentNullException("ID", "ID null reference.");
			}
			if (mem == null)
			{
				throw new ArgumentNullException("mem", "mem null reference.");
			}
			T t = new T();
			t.m_id = id;
			t.m_root = null;
			t.m_isRoot = true;
			t.m_memory = mem;
			return t;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000033C8 File Offset: 0x000015C8
		protected JsonMemoryNode()
		{
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000033E6 File Offset: 0x000015E6
		private JsonMemoryNode(string ID)
		{
			if (ID == null)
			{
				throw new ArgumentNullException("ID", "ID null reference.");
			}
			this.m_id = ID;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000341E File Offset: 0x0000161E
		public JsonMemoryNode(string ID, IJsonMemoryNode Root)
			: this(ID)
		{
			if (Root == null)
			{
				throw new ArgumentNullException("Root", "Root null reference.");
			}
			if (Root.memory == null)
			{
				throw new ArgumentNullException("Root.memory", "Root.memory null reference.");
			}
			this.m_root = Root;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00003459 File Offset: 0x00001659
		public string id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00003461 File Offset: 0x00001661
		public bool isRoot
		{
			get
			{
				return this.m_isRoot;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000346C File Offset: 0x0000166C
		public IJsonMemoryNode root
		{
			get
			{
				if (!this.m_isRoot)
				{
					return this.m_root;
				}
				return this;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x0000348B File Offset: 0x0000168B
		public IMemoria memory
		{
			get
			{
				if (!this.m_isRoot)
				{
					return this.m_root.memory;
				}
				return this.m_memory;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000034A7 File Offset: 0x000016A7
		public IReadOnlyDictionary<string, string> data
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x000034AF File Offset: 0x000016AF
		public IReadOnlyList<JsonMemoryNode> children
		{
			get
			{
				return this.m_children;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000034B7 File Offset: 0x000016B7
		IJsonMemoryNodeReadOnly IJsonMemoryNodeReadOnly.root
		{
			get
			{
				return (IJsonMemoryNodeReadOnly)this.root;
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060000A7 RID: 167 RVA: 0x000034C4 File Offset: 0x000016C4
		// (remove) Token: 0x060000A8 RID: 168 RVA: 0x000034FC File Offset: 0x000016FC
		public event Action<IMemoryNode<string, string>> loaded;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060000A9 RID: 169 RVA: 0x00003534 File Offset: 0x00001734
		// (remove) Token: 0x060000AA RID: 170 RVA: 0x0000356C File Offset: 0x0000176C
		public event Action<IMemoryNode<string, string>> saving;

		// Token: 0x060000AB RID: 171 RVA: 0x000035A1 File Offset: 0x000017A1
		public void AddData(string id, string data, bool replace = true)
		{
			this.m_data.AddData(id, data, replace);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000035B1 File Offset: 0x000017B1
		public string FindData(string id)
		{
			return this.m_data.FindData(id);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000035BF File Offset: 0x000017BF
		public bool RemoverData(string id)
		{
			return this.m_data.RemoverData(id);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000035CD File Offset: 0x000017CD
		public void ClearData()
		{
			this.m_data.ClearData();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000035DA File Offset: 0x000017DA
		public void ResetMemoria()
		{
			this.m_data = new StringKeyStringValueDictionary();
			this.m_children = new List<JsonMemoryNode>();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000035F4 File Offset: 0x000017F4
		public JsonMemoryNode FindChild(string id)
		{
			for (int i = 0; i < this.m_children.Count; i++)
			{
				JsonMemoryNode jsonMemoryNode = this.m_children[i];
				if (jsonMemoryNode.m_id == id)
				{
					return jsonMemoryNode;
				}
			}
			return null;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003638 File Offset: 0x00001838
		public JsonMemoryNode FindChildNotNull(string id)
		{
			JsonMemoryNode jsonMemoryNode = this.FindChild(id);
			if (jsonMemoryNode != null)
			{
				return jsonMemoryNode;
			}
			jsonMemoryNode = new JsonMemoryNode(id, this.root);
			this.m_children.Add(jsonMemoryNode);
			return jsonMemoryNode;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000366C File Offset: 0x0000186C
		public void AddChild(JsonMemoryNode child)
		{
			if (child == null)
			{
				return;
			}
			if (child.id == null)
			{
				throw new ArgumentNullException("id", "id null reference.");
			}
			this.m_children.Add(child);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003696 File Offset: 0x00001896
		public bool RemoverChild(IMemoryNode<string, string> child)
		{
			return this.m_children.Remove(child as JsonMemoryNode);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000036AC File Offset: 0x000018AC
		public bool RemoverChild(string id)
		{
			JsonMemoryNode jsonMemoryNode = this.m_children.FirstOrDefault((JsonMemoryNode c) => c.id == id);
			return jsonMemoryNode != null && this.RemoverChild(jsonMemoryNode);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000036EA File Offset: 0x000018EA
		public void RemoverChildAll()
		{
			this.m_children.Clear();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000036F7 File Offset: 0x000018F7
		public void RemoverDataAll()
		{
			this.m_data.Clear();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003704 File Offset: 0x00001904
		public string Save()
		{
			((IMemoryNodeEvents)this).Saving();
			string text = JsonUtility.ToJson(this);
			((IMemoryNodeEvents)this).Saved();
			return text;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00003718 File Offset: 0x00001918
		string IMemoryNodeReadOnly<string, string>.nodeID
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00003720 File Offset: 0x00001920
		IReadOnlyList<IMemoryNodeReadOnly<string, string>> IMemoryNodeReadOnly<string, string>.childrenReadOnly
		{
			get
			{
				return this.m_children;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00003728 File Offset: 0x00001928
		IReadOnlyDictionary<string, string> IMemoryNodeReadOnly<string, string>.data
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003730 File Offset: 0x00001930
		IMemoryNodeReadOnly<string, string> IMemoryNodeReadOnly<string, string>.FindChildReadOnly(string id)
		{
			return this.FindChild(id);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003739 File Offset: 0x00001939
		T IMemoryNodeReadOnly<string, string>.FindChildReadOnly<T>(string id)
		{
			return this.FindChild(id) as T;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000374C File Offset: 0x0000194C
		IReadOnlyList<IMemoryNode<string, string>> IMemoryNode<string, string>.children
		{
			get
			{
				return this.m_children;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00003754 File Offset: 0x00001954
		IReadOnlyDictionary<string, string> IMemoryNode<string, string>.data
		{
			get
			{
				return this.m_data;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000375C File Offset: 0x0000195C
		string IMemoryNode<string, string>.nodeID
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003764 File Offset: 0x00001964
		void IMemoryNode<string, string>.Load(string json)
		{
			this.m_data = new StringKeyStringValueDictionary();
			this.m_children = new List<JsonMemoryNode>();
			((IMemoryNodeEvents)this).Loading();
			JsonUtility.FromJsonOverwrite(json, this);
			foreach (JsonMemoryNode jsonMemoryNode in this.m_children)
			{
				jsonMemoryNode.SetRootAfterLoadFromJson(this);
			}
			((IMemoryNodeEvents)this).Loaded();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000037E0 File Offset: 0x000019E0
		private void SetRootAfterLoadFromJson(JsonMemoryNode root)
		{
			this.m_root = root;
			foreach (JsonMemoryNode jsonMemoryNode in this.m_children)
			{
				jsonMemoryNode.SetRootAfterLoadFromJson(root);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003838 File Offset: 0x00001A38
		string IMemoryNode<string, string>.Save()
		{
			return this.Save();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003840 File Offset: 0x00001A40
		IMemoryNode<string, string> IMemoryNode<string, string>.FindChild(string id)
		{
			return this.FindChild(id);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003849 File Offset: 0x00001A49
		IMemoryNode<string, string> IMemoryNode<string, string>.FindChildNotNull(string id)
		{
			return this.FindChildNotNull(id);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003852 File Offset: 0x00001A52
		T IMemoryNode<string, string>.FindChild<T>(string id)
		{
			return this.FindChild(id) as T;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003865 File Offset: 0x00001A65
		T IMemoryNode<string, string>.FindChildNotNull<T>(string id)
		{
			return this.FindChildNotNull(id) as T;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003878 File Offset: 0x00001A78
		void IDataContainer<string>.AddData(string id, string data, bool replace)
		{
			this.AddData(id, data, replace);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003883 File Offset: 0x00001A83
		void IMemoryNode<string, string>.AddChild(IMemoryNode<string, string> child)
		{
			this.AddChild((JsonMemoryNode)child);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003894 File Offset: 0x00001A94
		void IMemoryNodeEvents.Loading()
		{
			for (int i = 0; i < this.children.Count; i++)
			{
				((IMemoryNodeEvents)this.children[i]).Loading();
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000038C8 File Offset: 0x00001AC8
		void IMemoryNodeEvents.Loaded()
		{
			for (int i = 0; i < this.children.Count; i++)
			{
				((IMemoryNodeEvents)this.children[i]).Loaded();
			}
			Action<IMemoryNode<string, string>> action = this.loaded;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003910 File Offset: 0x00001B10
		void IMemoryNodeEvents.Saving()
		{
			Action<IMemoryNode<string, string>> action = this.saving;
			if (action != null)
			{
				action(this);
			}
			for (int i = 0; i < this.children.Count; i++)
			{
				((IMemoryNodeEvents)this.children[i]).Saving();
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003958 File Offset: 0x00001B58
		void IMemoryNodeEvents.Saved()
		{
			for (int i = 0; i < this.children.Count; i++)
			{
				((IMemoryNodeEvents)this.children[i]).Saved();
			}
		}

		// Token: 0x04000030 RID: 48
		[NonSerialized]
		private IMemoria m_memory;

		// Token: 0x04000031 RID: 49
		[NonSerialized]
		private IJsonMemoryNode m_root;

		// Token: 0x04000032 RID: 50
		[NonSerialized]
		private bool m_isRoot;

		// Token: 0x04000033 RID: 51
		[SerializeField]
		private string m_id;

		// Token: 0x04000034 RID: 52
		[SerializeField]
		private StringKeyStringValueDictionary m_data = new StringKeyStringValueDictionary();

		// Token: 0x04000035 RID: 53
		[SerializeField]
		private List<JsonMemoryNode> m_children = new List<JsonMemoryNode>();
	}
}
