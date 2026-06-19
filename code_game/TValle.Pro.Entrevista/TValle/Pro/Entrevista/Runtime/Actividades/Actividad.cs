using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x0200010F RID: 271
	public abstract class Actividad : AplicableCustomMonobehaviour
	{
		// Token: 0x06000924 RID: 2340 RVA: 0x000373F2 File Offset: 0x000355F2
		internal static void ForzeClear()
		{
			Actividad.m_running = null;
			Actividad.m_loaded = null;
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x00037400 File Offset: 0x00035600
		public static Actividad running
		{
			get
			{
				return Actividad.m_running;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000926 RID: 2342 RVA: 0x00037407 File Offset: 0x00035607
		public static Actividad loaded
		{
			get
			{
				return Actividad.m_loaded;
			}
		}

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x06000927 RID: 2343 RVA: 0x00037410 File Offset: 0x00035610
		// (remove) Token: 0x06000928 RID: 2344 RVA: 0x00037448 File Offset: 0x00035648
		public event Actividad.CharacterChangedHandler mainPlayerChanged;

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06000929 RID: 2345 RVA: 0x00037480 File Offset: 0x00035680
		// (remove) Token: 0x0600092A RID: 2346 RVA: 0x000374B8 File Offset: 0x000356B8
		public event Actividad.CharacterChangedHandler mainNonPlayerChanged;

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600092B RID: 2347
		public abstract Character mainPlayerCharacter { get; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600092C RID: 2348
		public abstract Character mainNonPlayerCharacter { get; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x000374ED File Offset: 0x000356ED
		public virtual bool isInit
		{
			get
			{
				return this.m_isInit;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x000374F5 File Offset: 0x000356F5
		public virtual bool aborted
		{
			get
			{
				return this.m_aborted;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600092F RID: 2351
		public abstract string ID { get; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000930 RID: 2352
		public abstract string Name { get; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000931 RID: 2353
		public abstract bool usesCustomLightingByUser { get; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000932 RID: 2354 RVA: 0x000374FD File Offset: 0x000356FD
		public Scene mainScene
		{
			get
			{
				return this.loader.mainScene;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000933 RID: 2355 RVA: 0x0003750A File Offset: 0x0003570A
		public Scene lightingAndGeometricsScene
		{
			get
			{
				return this.loader.lightingAndGeometricsScene;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x00037517 File Offset: 0x00035717
		public IActividadLoader loader
		{
			get
			{
				return this.m_loader;
			}
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x0003751F File Offset: 0x0003571F
		public void Init(IActividadLoader Loader)
		{
			if (Loader == null)
			{
				throw new ArgumentNullException("Loader", "Loader null reference.");
			}
			this.m_loader = Loader;
			this.OnInit();
			this.m_isInit = true;
		}

		// Token: 0x06000936 RID: 2358
		protected abstract void OnInit();

		// Token: 0x06000937 RID: 2359 RVA: 0x00037548 File Offset: 0x00035748
		internal void OnLoadedByLoader()
		{
			Actividad.m_loaded = this;
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00037550 File Offset: 0x00035750
		internal void OnUnLoadedByLoader()
		{
			if (Actividad.m_loaded == this)
			{
				Actividad.m_loaded = null;
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00037565 File Offset: 0x00035765
		internal void OnAborted()
		{
			this.m_aborted = true;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0003756E File Offset: 0x0003576E
		protected virtual void OnMainPlayerChanged(Character nuevo, Character viejo)
		{
			this.m_mainPlayerCharacterComponentCache.m_ComponentsTEMP.Clear();
			this.m_mainPlayerCharacterRootComponentCache.m_ComponentsTEMP.Clear();
			Actividad.CharacterChangedHandler characterChangedHandler = this.mainPlayerChanged;
			if (characterChangedHandler == null)
			{
				return;
			}
			characterChangedHandler(nuevo, viejo, this);
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x000375A3 File Offset: 0x000357A3
		protected virtual void OnMainNonPlayerChanged(Character nuevo, Character viejo)
		{
			this.m_mainNonPlayerCharacterComponentCache.m_ComponentsTEMP.Clear();
			this.m_mainNonPlayerCharacterRootComponentCache.m_ComponentsTEMP.Clear();
			Actividad.CharacterChangedHandler characterChangedHandler = this.mainPlayerChanged;
			if (characterChangedHandler == null)
			{
				return;
			}
			characterChangedHandler(nuevo, viejo, this);
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x000375D8 File Offset: 0x000357D8
		public T GetCachedMainPlayerComponent<T>() where T : class
		{
			object obj;
			if (!this.m_mainPlayerCharacterComponentCache.m_ComponentsTEMP.TryGetValue(typeof(T), out obj))
			{
				Character mainPlayerCharacter = this.mainPlayerCharacter;
				obj = ((mainPlayerCharacter != null) ? mainPlayerCharacter.GetComponent<T>() : default(T));
				this.m_mainPlayerCharacterComponentCache.m_ComponentsTEMP.Add(typeof(T), obj);
			}
			return obj as T;
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0003764C File Offset: 0x0003584C
		public T GetCachedMainPlayerComponentInCharacter<T>() where T : class
		{
			object obj;
			if (!this.m_mainPlayerCharacterRootComponentCache.m_ComponentsTEMP.TryGetValue(typeof(T), out obj))
			{
				Character mainPlayerCharacter = this.mainPlayerCharacter;
				obj = ((mainPlayerCharacter != null) ? mainPlayerCharacter.GetComponentEnRoot<T>() : default(T));
				this.m_mainPlayerCharacterRootComponentCache.m_ComponentsTEMP.Add(typeof(T), obj);
			}
			return obj as T;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x000376C0 File Offset: 0x000358C0
		public T GetCachedMainNonPlayerComponent<T>() where T : class
		{
			object obj;
			if (!this.m_mainNonPlayerCharacterComponentCache.m_ComponentsTEMP.TryGetValue(typeof(T), out obj))
			{
				Character mainNonPlayerCharacter = this.mainNonPlayerCharacter;
				obj = ((mainNonPlayerCharacter != null) ? mainNonPlayerCharacter.GetComponent<T>() : default(T));
				this.m_mainNonPlayerCharacterComponentCache.m_ComponentsTEMP.Add(typeof(T), obj);
			}
			return obj as T;
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00037734 File Offset: 0x00035934
		public T GetCachedMainNonPlayerComponentInCharacter<T>() where T : class
		{
			object obj;
			if (!this.m_mainNonPlayerCharacterRootComponentCache.m_ComponentsTEMP.TryGetValue(typeof(T), out obj))
			{
				Character mainNonPlayerCharacter = this.mainNonPlayerCharacter;
				obj = ((mainNonPlayerCharacter != null) ? mainNonPlayerCharacter.GetComponentEnRoot<T>() : default(T));
				this.m_mainNonPlayerCharacterRootComponentCache.m_ComponentsTEMP.Add(typeof(T), obj);
			}
			return obj as T;
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x000377A5 File Offset: 0x000359A5
		public IEnumerator DoStart()
		{
			if (Actividad.m_running != null)
			{
				throw new InvalidOperationException();
			}
			Actividad.m_running = this;
			yield return this.OnStart();
			yield break;
		}

		// Token: 0x06000941 RID: 2369
		protected abstract IEnumerator OnStart();

		// Token: 0x06000942 RID: 2370
		public abstract IEnumerator Introduce();

		// Token: 0x06000943 RID: 2371
		public abstract void OnNonPlayerMaxEmotionValue(Emotion emotion);

		// Token: 0x06000944 RID: 2372
		public abstract bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion);

		// Token: 0x06000945 RID: 2373
		public abstract void OnPlayerMaxEmotionValue(Emotion emotion);

		// Token: 0x06000946 RID: 2374
		public abstract bool OnPlayerMaxEmotionValueBuffer(Emotion emotion);

		// Token: 0x06000947 RID: 2375
		public abstract void BeforeAnimationsUpdate();

		// Token: 0x06000948 RID: 2376
		public abstract void AfterAnimationsUpdate();

		// Token: 0x06000949 RID: 2377
		public abstract void BeforePhysicsUpdate();

		// Token: 0x0600094A RID: 2378
		public abstract void AfterPhysicsUpdate();

		// Token: 0x0600094B RID: 2379
		public abstract void BeforeAIUpdate();

		// Token: 0x0600094C RID: 2380
		public abstract void AfterAIUpdate();

		// Token: 0x0600094D RID: 2381
		public abstract IEnumerator Conclude();

		// Token: 0x0600094E RID: 2382 RVA: 0x000377B4 File Offset: 0x000359B4
		public IEnumerator End()
		{
			if (Actividad.m_running == null)
			{
				throw new InvalidOperationException();
			}
			Actividad.m_running = null;
			if (Singleton<GameplayObjectives>.IsInScene)
			{
				Singleton<GameplayObjectives>.instance.EndSession();
			}
			yield return this.OnEnd();
			yield break;
		}

		// Token: 0x0600094F RID: 2383
		protected abstract IEnumerator OnEnd();

		// Token: 0x0400051E RID: 1310
		private static Actividad m_running;

		// Token: 0x0400051F RID: 1311
		private static Actividad m_loaded;

		// Token: 0x04000522 RID: 1314
		private Actividad.ComponentCache m_mainPlayerCharacterComponentCache = new Actividad.ComponentCache();

		// Token: 0x04000523 RID: 1315
		private Actividad.ComponentCache m_mainPlayerCharacterRootComponentCache = new Actividad.ComponentCache();

		// Token: 0x04000524 RID: 1316
		private Actividad.ComponentCache m_mainNonPlayerCharacterComponentCache = new Actividad.ComponentCache();

		// Token: 0x04000525 RID: 1317
		private Actividad.ComponentCache m_mainNonPlayerCharacterRootComponentCache = new Actividad.ComponentCache();

		// Token: 0x04000526 RID: 1318
		private IActividadLoader m_loader;

		// Token: 0x04000527 RID: 1319
		[SerializeField]
		[ReadOnlyUI]
		private bool m_isInit;

		// Token: 0x04000528 RID: 1320
		[SerializeField]
		[ReadOnlyUI]
		private bool m_aborted;

		// Token: 0x02000283 RID: 643
		// (Invoke) Token: 0x0600117C RID: 4476
		public delegate void CharacterChangedHandler(Character nuevo, Character viejo, Actividad sender);

		// Token: 0x02000284 RID: 644
		internal class ComponentCache
		{
			// Token: 0x04000BD0 RID: 3024
			internal Dictionary<Type, object> m_ComponentsTEMP = new Dictionary<Type, object>();
		}
	}
}
