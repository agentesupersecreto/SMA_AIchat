using System;

namespace com.ootii.Utilities
{
	// Token: 0x0200000F RID: 15
	internal class JSONLazyCreator : JSONNode
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x00007177 File Offset: 0x00005377
		public JSONLazyCreator(JSONNode aNode)
		{
			this.m_Node = aNode;
			this.m_Key = null;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000718D File Offset: 0x0000538D
		public JSONLazyCreator(JSONNode aNode, string aKey)
		{
			this.m_Node = aNode;
			this.m_Key = aKey;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000071A3 File Offset: 0x000053A3
		private void Set(JSONNode aVal)
		{
			if (this.m_Key == null)
			{
				this.m_Node.Add(aVal);
			}
			else
			{
				this.m_Node.Add(this.m_Key, aVal);
			}
			this.m_Node = null;
		}

		// Token: 0x1700003C RID: 60
		public override JSONNode this[int aIndex]
		{
			get
			{
				return new JSONLazyCreator(this);
			}
			set
			{
				this.Set(new JSONArray { value });
			}
		}

		// Token: 0x1700003D RID: 61
		public override JSONNode this[string aKey]
		{
			get
			{
				return new JSONLazyCreator(this, aKey);
			}
			set
			{
				this.Set(new JSONClass { { aKey, value } });
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000722C File Offset: 0x0000542C
		public override void Add(JSONNode aItem)
		{
			this.Set(new JSONArray { aItem });
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00007250 File Offset: 0x00005450
		public override void Add(string aKey, JSONNode aItem)
		{
			this.Set(new JSONClass { { aKey, aItem } });
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00007272 File Offset: 0x00005472
		public static bool operator ==(JSONLazyCreator a, object b)
		{
			return b == null || a == b;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000727D File Offset: 0x0000547D
		public static bool operator !=(JSONLazyCreator a, object b)
		{
			return !(a == b);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00007289 File Offset: 0x00005489
		public override bool Equals(object obj)
		{
			return obj == null || this == obj;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00007294 File Offset: 0x00005494
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000729C File Offset: 0x0000549C
		public override string ToString()
		{
			return "";
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000072A3 File Offset: 0x000054A3
		public override string ToString(string aPrefix)
		{
			return "";
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000107 RID: 263 RVA: 0x000072AC File Offset: 0x000054AC
		// (set) Token: 0x06000108 RID: 264 RVA: 0x000072C8 File Offset: 0x000054C8
		public override int AsInt
		{
			get
			{
				JSONData jsondata = new JSONData(0);
				this.Set(jsondata);
				return 0;
			}
			set
			{
				JSONData jsondata = new JSONData(value);
				this.Set(jsondata);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000109 RID: 265 RVA: 0x000072E4 File Offset: 0x000054E4
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00007308 File Offset: 0x00005508
		public override float AsFloat
		{
			get
			{
				JSONData jsondata = new JSONData(0f);
				this.Set(jsondata);
				return 0f;
			}
			set
			{
				JSONData jsondata = new JSONData(value);
				this.Set(jsondata);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00007324 File Offset: 0x00005524
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00007350 File Offset: 0x00005550
		public override double AsDouble
		{
			get
			{
				JSONData jsondata = new JSONData(0.0);
				this.Set(jsondata);
				return 0.0;
			}
			set
			{
				JSONData jsondata = new JSONData(value);
				this.Set(jsondata);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600010D RID: 269 RVA: 0x0000736C File Offset: 0x0000556C
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00007388 File Offset: 0x00005588
		public override bool AsBool
		{
			get
			{
				JSONData jsondata = new JSONData(false);
				this.Set(jsondata);
				return false;
			}
			set
			{
				JSONData jsondata = new JSONData(value);
				this.Set(jsondata);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600010F RID: 271 RVA: 0x000073A4 File Offset: 0x000055A4
		public override JSONArray AsArray
		{
			get
			{
				JSONArray jsonarray = new JSONArray();
				this.Set(jsonarray);
				return jsonarray;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000110 RID: 272 RVA: 0x000073C0 File Offset: 0x000055C0
		public override JSONClass AsObject
		{
			get
			{
				JSONClass jsonclass = new JSONClass();
				this.Set(jsonclass);
				return jsonclass;
			}
		}

		// Token: 0x040000B8 RID: 184
		private JSONNode m_Node;

		// Token: 0x040000B9 RID: 185
		private string m_Key;
	}
}
