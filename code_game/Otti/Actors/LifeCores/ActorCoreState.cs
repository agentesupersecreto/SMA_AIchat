using System;
using com.ootii.Data.Serializers;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000A6 RID: 166
	[Serializable]
	public class ActorCoreState
	{
		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x000307C2 File Offset: 0x0002E9C2
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x000307CA File Offset: 0x0002E9CA
		public virtual string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x000307D3 File Offset: 0x0002E9D3
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x000307DB File Offset: 0x0002E9DB
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
			}
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x000307F7 File Offset: 0x0002E9F7
		public virtual string Serialize()
		{
			return JSONSerializer.Serialize(this, false);
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x00030800 File Offset: 0x0002EA00
		public virtual void Deserialize(string rDefinition)
		{
			object obj = this;
			JSONSerializer.DeserializeInto(rDefinition, ref obj);
		}

		// Token: 0x040004B9 RID: 1209
		public string _Name = "";

		// Token: 0x040004BA RID: 1210
		public int _Value;
	}
}
