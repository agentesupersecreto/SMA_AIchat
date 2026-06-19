using System;
using com.ootii.Data.Serializers;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x0200009F RID: 159
	[Serializable]
	public abstract class ActorCoreEffect
	{
		// Token: 0x17000263 RID: 611
		// (get) Token: 0x060008F4 RID: 2292 RVA: 0x0002F961 File Offset: 0x0002DB61
		// (set) Token: 0x060008F5 RID: 2293 RVA: 0x0002F969 File Offset: 0x0002DB69
		public string SourceID
		{
			get
			{
				return this._SourceID;
			}
			set
			{
				this._SourceID = value;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x0002F972 File Offset: 0x0002DB72
		// (set) Token: 0x060008F7 RID: 2295 RVA: 0x0002F97A File Offset: 0x0002DB7A
		public bool IsEnabled
		{
			get
			{
				return this._IsEnabled;
			}
			set
			{
				this._IsEnabled = value;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x0002F983 File Offset: 0x0002DB83
		// (set) Token: 0x060008F9 RID: 2297 RVA: 0x0002F98B File Offset: 0x0002DB8B
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

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x0002F994 File Offset: 0x0002DB94
		// (set) Token: 0x060008FB RID: 2299 RVA: 0x0002F99C File Offset: 0x0002DB9C
		public virtual float MaxAge
		{
			get
			{
				return this._MaxAge;
			}
			set
			{
				this._MaxAge = value;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x0002F9A5 File Offset: 0x0002DBA5
		// (set) Token: 0x060008FD RID: 2301 RVA: 0x0002F9AD File Offset: 0x0002DBAD
		public float TriggerDelay
		{
			get
			{
				return this._TriggerDelay;
			}
			set
			{
				this._TriggerDelay = value;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x0002F9B6 File Offset: 0x0002DBB6
		// (set) Token: 0x060008FF RID: 2303 RVA: 0x0002F9BE File Offset: 0x0002DBBE
		public IActorCore ActorCore
		{
			get
			{
				return this.mActorCore;
			}
			set
			{
				this.mActorCore = value;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x0002F9C7 File Offset: 0x0002DBC7
		// (set) Token: 0x06000901 RID: 2305 RVA: 0x0002F9CF File Offset: 0x0002DBCF
		public virtual float Age
		{
			get
			{
				return this.mAge;
			}
			set
			{
				this.mAge = value;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x0002F9D8 File Offset: 0x0002DBD8
		// (set) Token: 0x06000903 RID: 2307 RVA: 0x0002F9E0 File Offset: 0x0002DBE0
		public float TriggerTime
		{
			get
			{
				return this.mTriggerTime;
			}
			set
			{
				this.mTriggerTime = value;
			}
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x0002F9E9 File Offset: 0x0002DBE9
		public ActorCoreEffect()
		{
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0002FA24 File Offset: 0x0002DC24
		public ActorCoreEffect(ActorCore rActorCore)
		{
			this.mActorCore = rActorCore;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0002FA71 File Offset: 0x0002DC71
		public virtual void Awake()
		{
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0002FA73 File Offset: 0x0002DC73
		public virtual void Clear()
		{
			this.mAge = 0f;
			this.mTriggerTime = 0f;
			this.mActorCore = null;
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0002FA92 File Offset: 0x0002DC92
		public virtual void Activate(float rTriggerDelay, float rMaxAge)
		{
			this.mAge = 0f;
			this.mTriggerTime = 0f;
			this.MaxAge = rMaxAge;
			this.TriggerDelay = rTriggerDelay;
			this.TriggerEffect();
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x0002FABE File Offset: 0x0002DCBE
		public virtual void Deactivate()
		{
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0002FAC0 File Offset: 0x0002DCC0
		public virtual bool Update()
		{
			this.mAge += Time.deltaTime;
			if (this._MaxAge > 0f && this.mAge > this._MaxAge)
			{
				this.Deactivate();
				return false;
			}
			if (this._TriggerDelay > 0f && this.mTriggerTime + this._TriggerDelay < Time.time)
			{
				this.TriggerEffect();
			}
			return true;
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0002FB2A File Offset: 0x0002DD2A
		public virtual void TriggerEffect()
		{
			this.mTriggerTime = Time.time;
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0002FB37 File Offset: 0x0002DD37
		public virtual void Release()
		{
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0002FB39 File Offset: 0x0002DD39
		public virtual string Serialize()
		{
			return JSONSerializer.Serialize(this, false);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0002FB44 File Offset: 0x0002DD44
		public virtual void Deserialize(string rDefinition)
		{
			object obj = this;
			JSONSerializer.DeserializeInto(rDefinition, ref obj);
		}

		// Token: 0x04000495 RID: 1173
		public string _SourceID = "";

		// Token: 0x04000496 RID: 1174
		public bool _IsEnabled = true;

		// Token: 0x04000497 RID: 1175
		public string _Name = "";

		// Token: 0x04000498 RID: 1176
		public float _MaxAge = 2f;

		// Token: 0x04000499 RID: 1177
		public float _TriggerDelay = 0.5f;

		// Token: 0x0400049A RID: 1178
		protected IActorCore mActorCore;

		// Token: 0x0400049B RID: 1179
		protected float mAge;

		// Token: 0x0400049C RID: 1180
		protected float mTriggerTime;
	}
}
