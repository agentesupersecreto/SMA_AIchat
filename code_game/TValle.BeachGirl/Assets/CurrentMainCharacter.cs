using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200000E RID: 14
	public abstract class CurrentMainCharacter<TSingle, TCharacter> : Singleton<TSingle> where TSingle : CurrentMainCharacter<TSingle, TCharacter> where TCharacter : Component
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002214 File Offset: 0x00000414
		public static TCharacter current
		{
			get
			{
				if (!Singleton<TSingle>.IsInScene)
				{
					return default(TCharacter);
				}
				return Singleton<TSingle>.instance.main;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002241 File Offset: 0x00000441
		public TCharacter main
		{
			get
			{
				return this.m_main;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600004D RID: 77 RVA: 0x0000224C File Offset: 0x0000044C
		// (remove) Token: 0x0600004E RID: 78 RVA: 0x00002284 File Offset: 0x00000484
		public event CurrentMainCharacter<TSingle, TCharacter>.ChangedHandler changed;

		// Token: 0x0600004F RID: 79 RVA: 0x000022BC File Offset: 0x000004BC
		public void SetMain(TCharacter mainchar)
		{
			if (mainchar == null)
			{
				throw new ArgumentNullException("mainchar", "mainchar null reference.");
			}
			TCharacter tcharacter = this.m_main;
			if (this.m_main != null)
			{
				this.RemoveMain();
			}
			else
			{
				tcharacter = default(TCharacter);
			}
			this.m_main = mainchar;
			this.OnChanged(mainchar, tcharacter);
			CurrentMainCharacter<TSingle, TCharacter>.ChangedHandler changedHandler = this.changed;
			if (changedHandler == null)
			{
				return;
			}
			changedHandler(mainchar, tcharacter, (TSingle)((object)this));
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002338 File Offset: 0x00000538
		public void RemoveMain()
		{
			if (this.m_main == null)
			{
				return;
			}
			TCharacter main = this.m_main;
			this.m_main = default(TCharacter);
			this.OnChanged(default(TCharacter), main);
			CurrentMainCharacter<TSingle, TCharacter>.ChangedHandler changedHandler = this.changed;
			if (changedHandler == null)
			{
				return;
			}
			changedHandler(default(TCharacter), main, (TSingle)((object)this));
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000239C File Offset: 0x0000059C
		public void RemoveMain(TCharacter mainchar)
		{
			if (this.m_main != mainchar)
			{
				return;
			}
			this.RemoveMain();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000023BD File Offset: 0x000005BD
		protected virtual void OnChanged(TCharacter nuevo, TCharacter viejo)
		{
			this.m_ComponentsTEMP.Clear();
			this.m_CharactersComponentsTEMP.Clear();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000023D8 File Offset: 0x000005D8
		public T GetCachedComponent<T>() where T : class
		{
			WeakReference weakReference;
			if (!this.m_ComponentsTEMP.TryGetValue(typeof(T), out weakReference))
			{
				TCharacter tcharacter = this.m_main;
				T t = ((tcharacter != null) ? tcharacter.GetComponent<T>() : default(T));
				if (t != null)
				{
					weakReference = new WeakReference(t);
					this.m_ComponentsTEMP.Add(typeof(T), weakReference);
				}
			}
			return ((weakReference != null) ? weakReference.Target : null) as T;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000245E File Offset: 0x0000065E
		public bool TryGetCachedComponent<T>(out T component) where T : class
		{
			component = this.GetCachedComponent<T>();
			return component != null;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000247C File Offset: 0x0000067C
		public T GetCachedComponentInCharacter<T>() where T : class
		{
			WeakReference weakReference;
			if (!this.m_CharactersComponentsTEMP.TryGetValue(typeof(T), out weakReference))
			{
				TCharacter tcharacter = this.m_main;
				T t = ((tcharacter != null) ? tcharacter.GetComponentEnRoot(false) : default(T));
				if (t != null)
				{
					weakReference = new WeakReference(t);
					this.m_CharactersComponentsTEMP.Add(typeof(T), weakReference);
				}
			}
			return ((weakReference != null) ? weakReference.Target : null) as T;
		}

		// Token: 0x04000017 RID: 23
		[ReadOnlyUI]
		[SerializeField]
		private TCharacter m_main;

		// Token: 0x04000019 RID: 25
		private Dictionary<Type, WeakReference> m_ComponentsTEMP = new Dictionary<Type, WeakReference>();

		// Token: 0x0400001A RID: 26
		private Dictionary<Type, WeakReference> m_CharactersComponentsTEMP = new Dictionary<Type, WeakReference>();

		// Token: 0x0200013E RID: 318
		// (Invoke) Token: 0x06000D9B RID: 3483
		public delegate void ChangedHandler(TCharacter nuevo, TCharacter viejo, TSingle sender);
	}
}
