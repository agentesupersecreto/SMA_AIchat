using System;
using System.Collections;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.Globales.Updater;
using RootMotion.Dynamics;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet
{
	// Token: 0x02000102 RID: 258
	[RequireComponent(typeof(ICharacterRoot))]
	public abstract class IKBeforePhysicsBase : CustomUpdatedMonobehaviourBase, IIKUpdater, IUserFullBodyBipedIK, IPhysicsIKJustUpdater
	{
		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x0002B6D0 File Offset: 0x000298D0
		public sealed override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdateActor);
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000995 RID: 2453 RVA: 0x0002B6D9 File Offset: 0x000298D9
		public sealed override GlobalUpdater.UpdateType? updateEvent2
		{
			get
			{
				return new GlobalUpdater.UpdateType?(this.m_fixTargetTransforms_UpdateEvent);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x0002B6E6 File Offset: 0x000298E6
		public sealed override GlobalUpdater.UpdateType? updateEvent3
		{
			get
			{
				return new GlobalUpdater.UpdateType?(this.m_IK_UpdateEvent);
			}
		}

		// Token: 0x14000076 RID: 118
		// (add) Token: 0x06000997 RID: 2455 RVA: 0x0002B6F4 File Offset: 0x000298F4
		// (remove) Token: 0x06000998 RID: 2456 RVA: 0x0002B72C File Offset: 0x0002992C
		public event Action<IIKUpdater> onFixingTransforms;

		// Token: 0x14000077 RID: 119
		// (add) Token: 0x06000999 RID: 2457 RVA: 0x0002B764 File Offset: 0x00029964
		// (remove) Token: 0x0600099A RID: 2458 RVA: 0x0002B79C File Offset: 0x0002999C
		public event Action<IIKUpdater> onFixedTransforms;

		// Token: 0x14000078 RID: 120
		// (add) Token: 0x0600099B RID: 2459 RVA: 0x0002B7D4 File Offset: 0x000299D4
		// (remove) Token: 0x0600099C RID: 2460 RVA: 0x0002B80C File Offset: 0x00029A0C
		[Obsolete("", true)]
		public event Action<IIKUpdater> iKsFixedTransforms;

		// Token: 0x14000079 RID: 121
		// (add) Token: 0x0600099D RID: 2461 RVA: 0x0002B844 File Offset: 0x00029A44
		// (remove) Token: 0x0600099E RID: 2462 RVA: 0x0002B87C File Offset: 0x00029A7C
		public event Action<IIKUpdater> onAllIKsUpdating;

		// Token: 0x1400007A RID: 122
		// (add) Token: 0x0600099F RID: 2463 RVA: 0x0002B8B4 File Offset: 0x00029AB4
		// (remove) Token: 0x060009A0 RID: 2464 RVA: 0x0002B8EC File Offset: 0x00029AEC
		public event Action<IIKUpdater> onAllIKsUpdated;

		// Token: 0x1400007B RID: 123
		// (add) Token: 0x060009A1 RID: 2465 RVA: 0x0002B924 File Offset: 0x00029B24
		// (remove) Token: 0x060009A2 RID: 2466 RVA: 0x0002B95C File Offset: 0x00029B5C
		public event Action<IIKUpdater> onPhysicsIKUpdating;

		// Token: 0x1400007C RID: 124
		// (add) Token: 0x060009A3 RID: 2467 RVA: 0x0002B994 File Offset: 0x00029B94
		// (remove) Token: 0x060009A4 RID: 2468 RVA: 0x0002B9CC File Offset: 0x00029BCC
		public event Action<IIKUpdater> onPhysicsIKUpdated;

		// Token: 0x1400007D RID: 125
		// (add) Token: 0x060009A5 RID: 2469 RVA: 0x0002BA04 File Offset: 0x00029C04
		// (remove) Token: 0x060009A6 RID: 2470 RVA: 0x0002BA3C File Offset: 0x00029C3C
		public event IIKUpdateEventoHandler onSingleIKUpdating;

		// Token: 0x1400007E RID: 126
		// (add) Token: 0x060009A7 RID: 2471 RVA: 0x0002BA74 File Offset: 0x00029C74
		// (remove) Token: 0x060009A8 RID: 2472 RVA: 0x0002BAAC File Offset: 0x00029CAC
		public event IIKUpdateEventoHandler onSingleIKUpdated;

		// Token: 0x1400007F RID: 127
		// (add) Token: 0x060009A9 RID: 2473 RVA: 0x0002BAE4 File Offset: 0x00029CE4
		// (remove) Token: 0x060009AA RID: 2474 RVA: 0x0002BB1C File Offset: 0x00029D1C
		public event IIKPassEventoHandler onSingleIKUpdatingJustPass0;

		// Token: 0x14000080 RID: 128
		// (add) Token: 0x060009AB RID: 2475 RVA: 0x0002BB54 File Offset: 0x00029D54
		// (remove) Token: 0x060009AC RID: 2476 RVA: 0x0002BB8C File Offset: 0x00029D8C
		public event IIKPassEventoHandler onSingleIKUpdatingJustPass1;

		// Token: 0x14000081 RID: 129
		// (add) Token: 0x060009AD RID: 2477 RVA: 0x0002BBC4 File Offset: 0x00029DC4
		// (remove) Token: 0x060009AE RID: 2478 RVA: 0x0002BBFC File Offset: 0x00029DFC
		public event IIKPassEventoHandler onSingleIKUpdatingJustPass2;

		// Token: 0x14000082 RID: 130
		// (add) Token: 0x060009AF RID: 2479 RVA: 0x0002BC34 File Offset: 0x00029E34
		// (remove) Token: 0x060009B0 RID: 2480 RVA: 0x0002BC6C File Offset: 0x00029E6C
		public event IIKPassEventoHandler onSingleIKUpdatingJustPass3;

		// Token: 0x14000083 RID: 131
		// (add) Token: 0x060009B1 RID: 2481 RVA: 0x0002BCA4 File Offset: 0x00029EA4
		// (remove) Token: 0x060009B2 RID: 2482 RVA: 0x0002BCDC File Offset: 0x00029EDC
		public event IIKPassEventoHandler onSingleIKUpdatingPass1;

		// Token: 0x14000084 RID: 132
		// (add) Token: 0x060009B3 RID: 2483 RVA: 0x0002BD14 File Offset: 0x00029F14
		// (remove) Token: 0x060009B4 RID: 2484 RVA: 0x0002BD4C File Offset: 0x00029F4C
		public event IIKPassEventoHandler onSingleIKUpdatingPass2;

		// Token: 0x14000085 RID: 133
		// (add) Token: 0x060009B5 RID: 2485 RVA: 0x0002BD84 File Offset: 0x00029F84
		// (remove) Token: 0x060009B6 RID: 2486 RVA: 0x0002BDBC File Offset: 0x00029FBC
		public event IIKPassEventoHandler onSingleIKUpdatingPass3;

		// Token: 0x14000086 RID: 134
		// (add) Token: 0x060009B7 RID: 2487 RVA: 0x0002BDF4 File Offset: 0x00029FF4
		// (remove) Token: 0x060009B8 RID: 2488 RVA: 0x0002BE2C File Offset: 0x0002A02C
		public event IIKPassEventoHandler onSingleIKUpdatedPass1;

		// Token: 0x14000087 RID: 135
		// (add) Token: 0x060009B9 RID: 2489 RVA: 0x0002BE64 File Offset: 0x0002A064
		// (remove) Token: 0x060009BA RID: 2490 RVA: 0x0002BE9C File Offset: 0x0002A09C
		public event IIKPassEventoHandler onSingleIKUpdatedPass2;

		// Token: 0x14000088 RID: 136
		// (add) Token: 0x060009BB RID: 2491 RVA: 0x0002BED4 File Offset: 0x0002A0D4
		// (remove) Token: 0x060009BC RID: 2492 RVA: 0x0002BF0C File Offset: 0x0002A10C
		public event IIKPassEventoHandler onSingleIKUpdatedPass3;

		// Token: 0x14000089 RID: 137
		// (add) Token: 0x060009BD RID: 2493 RVA: 0x0002BF44 File Offset: 0x0002A144
		// (remove) Token: 0x060009BE RID: 2494 RVA: 0x0002BF7C File Offset: 0x0002A17C
		public event IIKPassEventoHandler onSingleIKUpdatedPostPasses;

		// Token: 0x1400008A RID: 138
		// (add) Token: 0x060009BF RID: 2495 RVA: 0x0002BFB4 File Offset: 0x0002A1B4
		// (remove) Token: 0x060009C0 RID: 2496 RVA: 0x0002BFEC File Offset: 0x0002A1EC
		[Obsolete]
		public event Action<IIKUpdater> lookAtIKsBodyUpdating;

		// Token: 0x1400008B RID: 139
		// (add) Token: 0x060009C1 RID: 2497 RVA: 0x0002C024 File Offset: 0x0002A224
		// (remove) Token: 0x060009C2 RID: 2498 RVA: 0x0002C05C File Offset: 0x0002A25C
		[Obsolete]
		public event Action<IIKUpdater> lookAtIKsBodyUpdated;

		// Token: 0x1400008C RID: 140
		// (add) Token: 0x060009C3 RID: 2499 RVA: 0x0002C094 File Offset: 0x0002A294
		// (remove) Token: 0x060009C4 RID: 2500 RVA: 0x0002C0CC File Offset: 0x0002A2CC
		[Obsolete]
		public event Action<IIKUpdater> lookAtIKsHeadUpdating;

		// Token: 0x1400008D RID: 141
		// (add) Token: 0x060009C5 RID: 2501 RVA: 0x0002C104 File Offset: 0x0002A304
		// (remove) Token: 0x060009C6 RID: 2502 RVA: 0x0002C13C File Offset: 0x0002A33C
		[Obsolete]
		public event Action<IIKUpdater> lookAtIKsHeadUpdated;

		// Token: 0x1400008E RID: 142
		// (add) Token: 0x060009C7 RID: 2503 RVA: 0x0002C174 File Offset: 0x0002A374
		// (remove) Token: 0x060009C8 RID: 2504 RVA: 0x0002C1AC File Offset: 0x0002A3AC
		public event Action<IPhysicsIKJustUpdater> physicsIKJustUpdating;

		// Token: 0x1400008F RID: 143
		// (add) Token: 0x060009C9 RID: 2505 RVA: 0x0002C1E4 File Offset: 0x0002A3E4
		// (remove) Token: 0x060009CA RID: 2506 RVA: 0x0002C21C File Offset: 0x0002A41C
		public event Action<IPhysicsIKJustUpdater> physicsIKJustUpdated;

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x060009CB RID: 2507
		public abstract FullBodyBipedIK userFullBodyBipedIK { get; }

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x060009CC RID: 2508 RVA: 0x0002C251 File Offset: 0x0002A451
		FullBodyBipedIK IUserFullBodyBipedIK.IK
		{
			get
			{
				return this.userFullBodyBipedIK;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x060009CD RID: 2509
		public abstract int cantidadDeIKs { get; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x060009CE RID: 2510
		public abstract int cantidadDeLayers { get; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060009CF RID: 2511 RVA: 0x0002C259 File Offset: 0x0002A459
		public bool esPhysicsIK
		{
			get
			{
				return this.m_esPhysicsIK;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060009D0 RID: 2512 RVA: 0x0002C264 File Offset: 0x0002A464
		public int cantidadDeIKsActivos
		{
			get
			{
				int num = 0;
				IReadOnlyList<FullBodyBipedIK> readOnlyList = this.ObtenerAllFullBodyBipedIKSortedNonAlloc();
				for (int i = 0; i < readOnlyList.Count; i++)
				{
					if (readOnlyList[i].solver.IKPositionWeight > 0f)
					{
						num++;
					}
				}
				return num;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x0002C2A8 File Offset: 0x0002A4A8
		// (set) Token: 0x060009D2 RID: 2514 RVA: 0x0002C2FC File Offset: 0x0002A4FC
		public bool physicsIKEnabled
		{
			get
			{
				if (this.m_puppetMaster == null)
				{
					return false;
				}
				PuppetMaster.Mode mode = this.m_puppetMaster.mode;
				if (mode <= PuppetMaster.Mode.Kinematic)
				{
					return true;
				}
				if (mode != PuppetMaster.Mode.Disabled)
				{
					throw new ArgumentOutOfRangeException(this.m_puppetMaster.mode.ToString());
				}
				return false;
			}
			set
			{
				if (this.m_puppetMaster == null)
				{
					return;
				}
				PuppetMaster.Mode mode = this.m_puppetMaster.mode;
				if (mode > PuppetMaster.Mode.Kinematic)
				{
					if (mode != PuppetMaster.Mode.Disabled)
					{
						throw new ArgumentOutOfRangeException(this.m_puppetMaster.mode.ToString());
					}
					if (value)
					{
						this.m_puppetMaster.mode = PuppetMaster.Mode.Kinematic;
						return;
					}
				}
				else if (!value)
				{
					this.m_puppetMaster.mode = PuppetMaster.Mode.Disabled;
					return;
				}
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060009D3 RID: 2515 RVA: 0x0002C36C File Offset: 0x0002A56C
		// (set) Token: 0x060009D4 RID: 2516 RVA: 0x0002C3B4 File Offset: 0x0002A5B4
		public bool ikEnabled
		{
			get
			{
				IReadOnlyList<FullBodyBipedIK> readOnlyList = this.ObtenerAllFullBodyBipedIKSortedNonAlloc();
				if (readOnlyList == null)
				{
					return false;
				}
				for (int i = 0; i < readOnlyList.Count; i++)
				{
					if (readOnlyList[i].solver.IKPositionWeight > 0f)
					{
						return true;
					}
				}
				return false;
			}
			set
			{
				IReadOnlyList<FullBodyBipedIK> readOnlyList = this.ObtenerAllFullBodyBipedIKSortedNonAlloc();
				if (readOnlyList == null)
				{
					return;
				}
				if (value)
				{
					for (int i = 0; i < readOnlyList.Count; i++)
					{
						if (readOnlyList[i].solver.IKPositionWeight <= 0f)
						{
							readOnlyList[i].solver.IKPositionWeight = 1f;
						}
					}
					return;
				}
				for (int j = 0; j < readOnlyList.Count; j++)
				{
					readOnlyList[j].solver.IKPositionWeight = 0f;
				}
			}
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0002C438 File Offset: 0x0002A638
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_root = base.GetComponent<ICharacterRoot>();
			if (this.m_root == null)
			{
				throw new ArgumentNullException("m_root", "m_root null reference.");
			}
			this.m_puppetMaster = base.GetComponentInChildren<PuppetMaster>();
			if (this.m_puppetMaster)
			{
				this.m_puppetMasterUpdater = this.m_puppetMaster.GetComponentNotNull<PuppetMasterUpdater>();
			}
			this.m_esPhysicsIK = this.m_puppetMaster != null;
			IReadOnlyList<FullBodyBipedIK> readOnlyList = this.ObtenerAllFullBodyBipedIKSortedNonAlloc();
			if (readOnlyList != null)
			{
				foreach (FullBodyBipedIK fullBodyBipedIK in readOnlyList)
				{
					fullBodyBipedIK.InitiateComponent();
				}
			}
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0002C4F0 File Offset: 0x0002A6F0
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			IReadOnlyList<FullBodyBipedIK> readOnlyList = this.ObtenerAllFullBodyBipedIKSortedNonAlloc();
			if (this.userFullBodyBipedIK != null && !((IList)readOnlyList).Contains(this.userFullBodyBipedIK))
			{
				throw new InvalidOperationException("la lista de iks debe contener user iks");
			}
			this.updatingList = new CoroutineCapsule(this);
			this.updatingList.Start(this.UpdateListAuto(Random.Range(10f, 12.2f)), null, null);
			this.UpdateLists();
			this.UsarPuppet();
			if (this.m_puppetMaster != null)
			{
				this.m_puppetMaster.fixTargetTransforms = false;
			}
			this.m_lastAnimatedPhysics = false;
			this.UpdateIKUpdaterMetodo(this.m_lastAnimatedPhysics);
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0002C5A6 File Offset: 0x0002A7A6
		protected void UsarPuppet()
		{
			if (this.m_puppetMasterUpdater != null)
			{
				this.m_puppetMasterUpdater.beforeLateUpdate += this.M_puppetMasterUpdater_beforeLateUpdate;
				this.m_puppetMasterUpdater.afterLateUpdate += this.M_puppetMasterUpdater_afterLateUpdate;
			}
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0002C5E4 File Offset: 0x0002A7E4
		public sealed override void OnUpdateEvent1()
		{
			if (this.m_puppetMaster != null)
			{
				this.m_puppetMaster.fixTargetTransforms = false;
			}
			if (this.m_lastAnimatedPhysics)
			{
				this.m_lastAnimatedPhysics = false;
				this.UpdateIKUpdaterMetodo(this.m_lastAnimatedPhysics);
			}
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0002C61C File Offset: 0x0002A81C
		public sealed override void OnUpdateEvent2()
		{
			IReadOnlyList<FullBodyBipedIK> readOnlyList = this.ObtenerAllFullBodyBipedIKSortedNonAlloc();
			if (readOnlyList != null)
			{
				for (int i = 1; i < readOnlyList.Count; i++)
				{
					readOnlyList[i].fixTransforms = false;
				}
				readOnlyList[0].fixTransforms = this.fixTargetTransforms;
			}
			if (this.fixTargetTransforms)
			{
				this.FixIkTransforms();
			}
			if (this.m_puppetMaster != null && this.m_puppetMaster.isActive)
			{
				this.m_puppetMaster.fixTargetTransforms = this.fixTargetTransforms;
				this.m_puppetMaster.FixTargetTransformsTValle();
				this.m_puppetMaster.fixTargetTransforms = false;
			}
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0002C6B4 File Offset: 0x0002A8B4
		public override void OnUpdateEvent3()
		{
			this.UpdateIks();
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0002C6BC File Offset: 0x0002A8BC
		private void M_puppetMasterUpdater_beforeLateUpdate()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			Action<IIKUpdater> action = this.onPhysicsIKUpdating;
			if (action != null)
			{
				action(this);
			}
			Action<IPhysicsIKJustUpdater> action2 = this.physicsIKJustUpdating;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0002C6EA File Offset: 0x0002A8EA
		private void M_puppetMasterUpdater_afterLateUpdate()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			Action<IPhysicsIKJustUpdater> action = this.physicsIKJustUpdated;
			if (action != null)
			{
				action(this);
			}
			Action<IIKUpdater> action2 = this.onPhysicsIKUpdated;
			if (action2 == null)
			{
				return;
			}
			action2(this);
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0002C718 File Offset: 0x0002A918
		private void UpdateIKUpdaterMetodo(bool animatedPhysics)
		{
			if (animatedPhysics)
			{
				this.m_IK_UpdateEvent = GlobalUpdater.UpdateType.fixedUpdateOnFinalIK;
				this.m_fixTargetTransforms_UpdateEvent = GlobalUpdater.UpdateType.fixedFixBonesTransforms;
			}
			else
			{
				this.m_IK_UpdateEvent = GlobalUpdater.UpdateType.lateUpdateOnFinalIK;
				this.m_fixTargetTransforms_UpdateEvent = GlobalUpdater.UpdateType.fixBonesTransforms;
			}
			base.ReSubscribeToGlobalUpdater();
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0002C745 File Offset: 0x0002A945
		private IEnumerator UpdateListAuto(float time)
		{
			yield return new WaitForSeconds(time * 0.2f);
			this.UpdateLists();
			WaitForSeconds y = new WaitForSeconds(time);
			for (;;)
			{
				yield return y;
				this.UpdateLists();
			}
			yield break;
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0002C75B File Offset: 0x0002A95B
		public void UpdateLists()
		{
			this.posers.Clear();
			this.m_root.GetComponentsInChildren<Poser>(true, this.posers);
		}

		// Token: 0x060009E0 RID: 2528
		public abstract void SwitchLayerIks(int layer);

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060009E1 RID: 2529 RVA: 0x0002C77A File Offset: 0x0002A97A
		public IReadOnlyList<Component> sortedIKs
		{
			get
			{
				return this.ObtenerAllFullBodyBipedIKSortedNonAlloc();
			}
		}

		// Token: 0x060009E2 RID: 2530
		public abstract FullBodyBipedIK ObtenerFullBodyBipedIKDeID(int ID);

		// Token: 0x060009E3 RID: 2531
		[Obsolete("", true)]
		public abstract FullBodyBipedIK ObtenerFullBodyBipedIKLayer(int layer);

		// Token: 0x060009E4 RID: 2532
		public abstract IReadOnlyList<Component> SortedIKsDeLayer(int layer);

		// Token: 0x060009E5 RID: 2533
		public abstract int LayerDeIK(Component IK);

		// Token: 0x060009E6 RID: 2534 RVA: 0x0002C784 File Offset: 0x0002A984
		public int InvertLayerDeIK(Component IK)
		{
			int num = this.LayerDeIK(IK);
			if (num < 0)
			{
				return num;
			}
			return this.cantidadDeLayers - 1 - num;
		}

		// Token: 0x060009E7 RID: 2535
		public abstract int IndexEnLayerDeIK(Component IK, out bool ultimoDeLayer);

		// Token: 0x060009E8 RID: 2536
		protected abstract IReadOnlyList<FullBodyBipedIK> ObtenerAllFullBodyBipedIKSortedNonAlloc();

		// Token: 0x060009E9 RID: 2537
		public abstract int IDDeIK(Component IK);

		// Token: 0x060009EA RID: 2538 RVA: 0x0002C7AC File Offset: 0x0002A9AC
		[Obsolete("", true)]
		public int InvertIDDeIK(Component IK)
		{
			int num = this.IDDeIK(IK);
			if (num < 0)
			{
				return num;
			}
			return this.cantidadDeIKs - 1 - num;
		}

		// Token: 0x060009EB RID: 2539
		public abstract int CantidadDePasadasDeIK(int ID);

		// Token: 0x060009EC RID: 2540 RVA: 0x0002C7D1 File Offset: 0x0002A9D1
		public int CantidadDePasadasDeIK(Component IK)
		{
			return this.CantidadDePasadasDeIK(this.IDDeIK(IK));
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0002C7E0 File Offset: 0x0002A9E0
		public Component IKDeID(int ID)
		{
			return this.ObtenerFullBodyBipedIKDeID(ID);
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0002C7E9 File Offset: 0x0002A9E9
		[Obsolete("", true)]
		public Component IKDeLayer(int layer)
		{
			return this.ObtenerFullBodyBipedIKLayer(layer);
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0002C7F4 File Offset: 0x0002A9F4
		protected void FixIkTransforms()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			bool profilePerformance = this.customUpdatedConfig.profilePerformance;
			Action<IIKUpdater> action = this.onFixingTransforms;
			if (action != null)
			{
				action(this);
			}
			if (this.posers != null)
			{
				for (int i = 0; i < this.posers.Count; i++)
				{
					Poser poser = this.posers[i];
					if (poser.fixTransforms)
					{
						poser.FixTransformsTValle();
					}
				}
			}
			IReadOnlyList<FullBodyBipedIK> readOnlyList = this.ObtenerAllFullBodyBipedIKSortedNonAlloc();
			if (readOnlyList != null)
			{
				for (int j = 0; j < readOnlyList.Count; j++)
				{
					FullBodyBipedIK fullBodyBipedIK = readOnlyList[j];
					if (fullBodyBipedIK.fixTransforms)
					{
						fullBodyBipedIK.solver.FixTransforms();
					}
				}
			}
			Action<IIKUpdater> action2 = this.onFixedTransforms;
			if (action2 != null)
			{
				action2(this);
			}
			bool profilePerformance2 = this.customUpdatedConfig.profilePerformance;
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0002C8B8 File Offset: 0x0002AAB8
		public int CurrentPassIndexDeIK(int id)
		{
			if (this.currentIkID == id)
			{
				return this.currentPassIndex;
			}
			return -1;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0002C8CB File Offset: 0x0002AACB
		public int CurrentPassIndexDeIK(Component IK)
		{
			return this.CurrentPassIndexDeIK(this.IDDeIK(IK));
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0002C8DC File Offset: 0x0002AADC
		protected void UpdateIks()
		{
			if (!base.enabled)
			{
				return;
			}
			if (this.m_id == UpdateAutoId.current)
			{
				return;
			}
			this.m_id = UpdateAutoId.current;
			bool profilePerformance = this.customUpdatedConfig.profilePerformance;
			if (this.onAllIKsUpdating != null)
			{
				this.onAllIKsUpdating(this);
			}
			IReadOnlyList<FullBodyBipedIK> readOnlyList = this.ObtenerAllFullBodyBipedIKSortedNonAlloc();
			for (int i = 0; i < this.cantidadDeIKs; i++)
			{
				FullBodyBipedIK fullBodyBipedIK = readOnlyList[i];
				if (!(fullBodyBipedIK == null) && fullBodyBipedIK.gameObject.activeInHierarchy)
				{
					this.currentIkID = this.IDDeIK(fullBodyBipedIK);
					this.currentIkLayer = this.LayerDeIK(fullBodyBipedIK);
					bool flag;
					this.currentIkIndexEnLayer = this.IndexEnLayerDeIK(fullBodyBipedIK, out flag);
					if (fullBodyBipedIK.enabled)
					{
						fullBodyBipedIK.enabled = false;
					}
					int num = this.CantidadDePasadasDeIK(this.currentIkID);
					if (num <= 0)
					{
						Debug.LogWarning("IK no pasa ninguna vez.", fullBodyBipedIK);
					}
					else
					{
						bool profilePerformance2 = this.customUpdatedConfig.profilePerformance;
						if (this.fixEffectorTargets)
						{
							for (int j = 0; j < fullBodyBipedIK.solver.effectors.Length; j++)
							{
								IKEffector ikeffector = fullBodyBipedIK.solver.effectors[j];
								ikeffector.position = ikeffector.bone.position;
								ikeffector.rotation = ikeffector.bone.rotation;
							}
						}
						bool flag2 = this.currentIkLayer + 1 == this.cantidadDeLayers;
						IKEventData ikeventData = new IKEventData(this.currentIkID, this.currentIkLayer, this.currentIkIndexEnLayer, flag, flag2);
						IIKUpdateEventoHandler iikupdateEventoHandler = this.onSingleIKUpdating;
						if (iikupdateEventoHandler != null)
						{
							iikupdateEventoHandler(this, fullBodyBipedIK, ref ikeventData);
						}
						this.currentPassIndex = 0;
						while (this.currentPassIndex < num)
						{
							bool profilePerformance3 = this.customUpdatedConfig.profilePerformance;
							bool flag3 = this.currentPassIndex + 1 == num;
							IKPassEventData ikpassEventData = new IKPassEventData(this.currentPassIndex, flag3);
							IIKPassEventoHandler iikpassEventoHandler = this.onSingleIKUpdatingJustPass0;
							if (iikpassEventoHandler != null)
							{
								iikpassEventoHandler(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							IIKPassEventoHandler iikpassEventoHandler2 = this.onSingleIKUpdatingJustPass1;
							if (iikpassEventoHandler2 != null)
							{
								iikpassEventoHandler2(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							IIKPassEventoHandler iikpassEventoHandler3 = this.onSingleIKUpdatingJustPass2;
							if (iikpassEventoHandler3 != null)
							{
								iikpassEventoHandler3(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							IIKPassEventoHandler iikpassEventoHandler4 = this.onSingleIKUpdatingJustPass3;
							if (iikpassEventoHandler4 != null)
							{
								iikpassEventoHandler4(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							IIKPassEventoHandler iikpassEventoHandler5 = this.onSingleIKUpdatingPass1;
							if (iikpassEventoHandler5 != null)
							{
								iikpassEventoHandler5(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							IIKPassEventoHandler iikpassEventoHandler6 = this.onSingleIKUpdatingPass2;
							if (iikpassEventoHandler6 != null)
							{
								iikpassEventoHandler6(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							IIKPassEventoHandler iikpassEventoHandler7 = this.onSingleIKUpdatingPass3;
							if (iikpassEventoHandler7 != null)
							{
								iikpassEventoHandler7(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							fullBodyBipedIK.solver.Update();
							IIKPassEventoHandler iikpassEventoHandler8 = this.onSingleIKUpdatedPass1;
							if (iikpassEventoHandler8 != null)
							{
								iikpassEventoHandler8(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							IIKPassEventoHandler iikpassEventoHandler9 = this.onSingleIKUpdatedPass2;
							if (iikpassEventoHandler9 != null)
							{
								iikpassEventoHandler9(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							IIKPassEventoHandler iikpassEventoHandler10 = this.onSingleIKUpdatedPass3;
							if (iikpassEventoHandler10 != null)
							{
								iikpassEventoHandler10(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							IIKPassEventoHandler iikpassEventoHandler11 = this.onSingleIKUpdatedPostPasses;
							if (iikpassEventoHandler11 != null)
							{
								iikpassEventoHandler11(this, fullBodyBipedIK, ref ikeventData, ref ikpassEventData);
							}
							bool profilePerformance4 = this.customUpdatedConfig.profilePerformance;
							this.currentPassIndex++;
						}
						this.currentPassIndex = -1;
						IIKUpdateEventoHandler iikupdateEventoHandler2 = this.onSingleIKUpdated;
						if (iikupdateEventoHandler2 != null)
						{
							iikupdateEventoHandler2(this, fullBodyBipedIK, ref ikeventData);
						}
						bool profilePerformance5 = this.customUpdatedConfig.profilePerformance;
					}
				}
			}
			this.currentIkID = -1;
			this.currentIkLayer = -1;
			this.currentIkIndexEnLayer = -1;
			bool profilePerformance6 = this.customUpdatedConfig.profilePerformance;
			for (int k = 0; k < this.posers.Count; k++)
			{
				Poser poser = this.posers[k];
				if (!(poser == null) && poser.gameObject.activeInHierarchy)
				{
					if (poser.enabled)
					{
						poser.enabled = false;
					}
					poser.UpdateSolverTValle();
				}
			}
			bool profilePerformance7 = this.customUpdatedConfig.profilePerformance;
			if (this.onAllIKsUpdated != null)
			{
				this.onAllIKsUpdated(this);
			}
			bool profilePerformance8 = this.customUpdatedConfig.profilePerformance;
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0002CCA4 File Offset: 0x0002AEA4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			this.m_puppetMaster != null;
			if (this.m_puppetMasterUpdater)
			{
				this.m_puppetMasterUpdater.beforeLateUpdate -= this.M_puppetMasterUpdater_beforeLateUpdate;
				this.m_puppetMasterUpdater.afterLateUpdate -= this.M_puppetMasterUpdater_afterLateUpdate;
			}
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x0002CD00 File Offset: 0x0002AF00
		public bool IKEstaActivo(int index)
		{
			return this.ObtenerFullBodyBipedIKDeID(index).solver.IKPositionWeight > 0f;
		}

		// Token: 0x040005E4 RID: 1508
		public bool debug;

		// Token: 0x040005E5 RID: 1509
		public bool fixTargetTransforms = true;

		// Token: 0x040005E6 RID: 1510
		public bool fixEffectorTargets = true;

		// Token: 0x040005E7 RID: 1511
		public const bool animatedPhysics = false;

		// Token: 0x040005E8 RID: 1512
		public const bool puedeAdministrarElAnimator = false;

		// Token: 0x040005E9 RID: 1513
		private bool m_lastAnimatedPhysics;

		// Token: 0x040005EA RID: 1514
		[ReadOnlyUI]
		[SerializeField]
		private GlobalUpdater.UpdateType m_fixTargetTransforms_UpdateEvent;

		// Token: 0x040005EB RID: 1515
		[ReadOnlyUI]
		[SerializeField]
		private GlobalUpdater.UpdateType m_IK_UpdateEvent;

		// Token: 0x040005EC RID: 1516
		private ICharacterRoot m_root;

		// Token: 0x040005ED RID: 1517
		private UpdateAutoId m_id;

		// Token: 0x040005EE RID: 1518
		protected PuppetMasterUpdater m_puppetMasterUpdater;

		// Token: 0x040005EF RID: 1519
		protected PuppetMaster m_puppetMaster;

		// Token: 0x040005F0 RID: 1520
		[SerializeField]
		[ReadOnlyUI]
		protected List<Poser> posers = new List<Poser>();

		// Token: 0x040005F1 RID: 1521
		private CoroutineCapsule updatingList;

		// Token: 0x0400060C RID: 1548
		[ReadOnlyUI]
		[SerializeField]
		private bool m_esPhysicsIK;

		// Token: 0x0400060D RID: 1549
		[NonSerialized]
		private int currentIkID;

		// Token: 0x0400060E RID: 1550
		[NonSerialized]
		private int currentIkLayer;

		// Token: 0x0400060F RID: 1551
		[NonSerialized]
		private int currentIkIndexEnLayer;

		// Token: 0x04000610 RID: 1552
		[NonSerialized]
		private int currentPassIndex;
	}
}
