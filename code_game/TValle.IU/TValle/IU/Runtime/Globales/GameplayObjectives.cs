using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Paneles;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets._ReusableScripts;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Globales
{
	// Token: 0x020000EA RID: 234
	public class GameplayObjectives : Singleton<GameplayObjectives>
	{
		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060006F9 RID: 1785 RVA: 0x000195B4 File Offset: 0x000177B4
		// (remove) Token: 0x060006FA RID: 1786 RVA: 0x000195EC File Offset: 0x000177EC
		public event GameplayObjectives.StatusChandedHandler objectiveStatusChanged;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060006FB RID: 1787 RVA: 0x00019624 File Offset: 0x00017824
		// (remove) Token: 0x060006FC RID: 1788 RVA: 0x0001965C File Offset: 0x0001785C
		public event GameplayObjectives.ProgressChandedHandler objectiveProgressChanged;

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00019691 File Offset: 0x00017891
		public PanelDeObjectives UIPanel
		{
			get
			{
				return this.m_PanelDeObjectives;
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x00019699 File Offset: 0x00017899
		public ModificableDeBool showPanel
		{
			get
			{
				return this.m_showPanel;
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x000196A4 File Offset: 0x000178A4
		protected override void DoAwake()
		{
			base.DoAwake();
			this.m_PanelDeObjectives = base.GetComponent<PanelDeObjectives>();
			if (this.m_PanelDeObjectives == null)
			{
				throw new ArgumentNullException("m_PanelDeObjectives", "m_PanelDeObjectives null reference.");
			}
			this.m_PanelDeObjectives.onBiding += this.M_PanelDeObjectives_onBiding;
			this.m_PanelDeObjectives.onHiddenBase += this.M_PanelDeObjectives_onHiddenBase;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0001970F File Offset: 0x0001790F
		public void ForceHide()
		{
			this.m_seflShowing = false;
			this.UpdateVisibilidad(false);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0001971F File Offset: 0x0001791F
		private void OnEnable()
		{
			this.m_UpdateCorutine = base.StartCoroutine(this.UpdateNonRealTimeRutine());
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00019733 File Offset: 0x00017933
		private void OnDisable()
		{
			if (this.m_UpdateCorutine != null)
			{
				base.StopCoroutine(this.m_UpdateCorutine);
			}
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00019749 File Offset: 0x00017949
		private IEnumerator UpdateNonRealTimeRutine()
		{
			WaitForSeconds w = new WaitForSeconds(1f.Random(0.25f));
			for (;;)
			{
				yield return w;
				this.UpdateNonRealTimeObjetives();
			}
			yield break;
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00019758 File Offset: 0x00017958
		private void Update()
		{
			this.UpdateRealTimeObjetives();
			if (Singleton<PlayerInputProxy>.instance.virtualesUI.showObjectives)
			{
				this.m_seflShowing = !this.m_seflShowing;
			}
			bool flag = this.m_showPanel.Or(this.m_seflShowing);
			this.UpdateVisibilidad(flag);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x000197A4 File Offset: 0x000179A4
		public void Refresh()
		{
			this.m_PanelDeObjectives.Clear();
			bool flag = this.m_showPanel.Or(this.m_seflShowing);
			if (flag)
			{
				this.UpdateVisibilidad(flag);
			}
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x000197D8 File Offset: 0x000179D8
		private void UpdateVisibilidad(bool showing)
		{
			if (showing)
			{
				if (!this.m_PanelDeObjectives.isBinded)
				{
					this.m_PanelDeObjectives.CrearYDibujar(null);
				}
				if (!this.m_PanelDeObjectives.isShowing)
				{
					this.m_PanelDeObjectives.Show();
					return;
				}
			}
			else if (this.m_PanelDeObjectives.isBinded || this.m_PanelDeObjectives.isShowing)
			{
				this.m_PanelDeObjectives.Clear();
			}
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00019840 File Offset: 0x00017A40
		private void UpdateNonRealTimeObjetives()
		{
			for (int i = 0; i < this.m_objetives.Count; i++)
			{
				GameplayObjectives.Objective objective = this.m_objetives[i];
				if (objective != null && !objective.realTime)
				{
					objective.Update();
				}
			}
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00019884 File Offset: 0x00017A84
		private void UpdateRealTimeObjetives()
		{
			for (int i = 0; i < this.m_objetives.Count; i++)
			{
				GameplayObjectives.Objective objective = this.m_objetives[i];
				if (objective != null && objective.realTime)
				{
					objective.Update();
				}
			}
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x000198C8 File Offset: 0x00017AC8
		public void UpdateAllObjetives()
		{
			for (int i = 0; i < this.m_objetives.Count; i++)
			{
				GameplayObjectives.Objective objective = this.m_objetives[i];
				if (objective != null)
				{
					objective.Update();
				}
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00019904 File Offset: 0x00017B04
		public bool AllRequiredObjectivesCompleted()
		{
			for (int i = 0; i < this.m_required.Count; i++)
			{
				string text = this.m_required[i];
				if (this.m_objetivesDic[text].status != ObjectiveStatus.completed)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x0001994B File Offset: 0x00017B4B
		public void StartSession()
		{
			this.EndSession();
			this.m_inSession = true;
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x0001995A File Offset: 0x00017B5A
		public void SessionStatus(out int totalRequiredObjectives, out int completedRequiredObjectives, out int totalOptionalObjectives, out int completedOptionalObjectives)
		{
			totalRequiredObjectives = this.m_totalRequiredObjectives;
			completedRequiredObjectives = this.m_completedRequiredObjectives;
			totalOptionalObjectives = this.m_totalOptionalObjectives;
			completedOptionalObjectives = this.m_completedOptionalObjectives;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00019980 File Offset: 0x00017B80
		public void EndSession()
		{
			this.m_inSession = false;
			this.m_sessionRequired.Clear();
			this.m_sessionNonRequired.Clear();
			this.m_sessionRequiredEnded.Clear();
			this.m_sessionNonRequiredEnded.Clear();
			this.m_totalRequiredObjectives = 0;
			this.m_completedRequiredObjectives = 0;
			this.m_totalOptionalObjectives = 0;
			this.m_completedOptionalObjectives = 0;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000199DC File Offset: 0x00017BDC
		public void Status(out int totalRequiredObjectives, out int completedRequiredObjectives, out int totalOptionalObjectives, out int completedOptionalObjectives)
		{
			completedOptionalObjectives = (completedRequiredObjectives = 0);
			totalRequiredObjectives = this.m_required.Count;
			totalOptionalObjectives = this.m_nonRequired.Count;
			for (int i = 0; i < this.m_required.Count; i++)
			{
				string text = this.m_required[i];
				if (this.m_objetivesDic[text].status == ObjectiveStatus.completed)
				{
					completedRequiredObjectives++;
				}
			}
			for (int j = 0; j < this.m_nonRequired.Count; j++)
			{
				string text2 = this.m_nonRequired[j];
				if (this.m_objetivesDic[text2].status == ObjectiveStatus.completed)
				{
					completedOptionalObjectives++;
				}
			}
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00019A8C File Offset: 0x00017C8C
		public void AddObjetives(IReadOnlyList<GameplayObjectives.Objective> objetives, bool required)
		{
			if (objetives == null)
			{
				return;
			}
			for (int i = 0; i < objetives.Count; i++)
			{
				this.AddObjetive(objetives[i], required, false);
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00019AC0 File Offset: 0x00017CC0
		public void AddObjetive(GameplayObjectives.Objective objetive, bool required, bool msgOnComplete)
		{
			if (objetive == null)
			{
				return;
			}
			if (this.m_objetivesDic.ContainsKey(objetive.id))
			{
				return;
			}
			objetive.statusChanged += this.Objetive_statusChanged;
			if (required || msgOnComplete)
			{
				objetive.statusChanged += this.Objetive_statusChangedMsg;
			}
			this.m_objetives.Add(objetive);
			this.m_objetivesDic.Add(objetive.id, objetive);
			if (required)
			{
				if (this.m_required.Add(objetive.id) && this.m_sessionRequired.Add(objetive.id))
				{
					this.m_totalRequiredObjectives++;
				}
			}
			else if (this.m_nonRequired.Add(objetive.id) && this.m_sessionNonRequired.Add(objetive.id))
			{
				this.m_totalOptionalObjectives++;
			}
			objetive.ChangeStatus(ObjectiveStatus.active);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00019BA0 File Offset: 0x00017DA0
		public void RemoveObjetive(GameplayObjectives.Objective objetive)
		{
			if (objetive == null)
			{
				return;
			}
			objetive.ChangeStatus(ObjectiveStatus.cleared);
			objetive.statusChanged -= this.Objetive_statusChanged;
			objetive.statusChanged -= this.Objetive_statusChangedMsg;
			this.m_objetives.Remove(objetive);
			this.m_objetivesDic.Remove(objetive.id);
			this.m_required.Remove(objetive.id);
			this.m_nonRequired.Remove(objetive.id);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00019C20 File Offset: 0x00017E20
		public void RemoveObjetives(IReadOnlyList<GameplayObjectives.Objective> objetives)
		{
			if (objetives == null)
			{
				return;
			}
			for (int i = 0; i < objetives.Count; i++)
			{
				this.RemoveObjetive(objetives[i]);
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00019C50 File Offset: 0x00017E50
		public void ResetObjetives()
		{
			for (int i = this.m_objetives.Count - 1; i >= 0; i--)
			{
				this.RemoveObjetive(this.m_objetives[i]);
			}
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00019C88 File Offset: 0x00017E88
		public void ChangeObjetiveStatus(string id, ObjectiveStatus newStatus)
		{
			GameplayObjectives.Objective objective;
			if (!this.m_objetivesDic.TryGetValue(id, out objective))
			{
				return;
			}
			objective.ChangeStatus(newStatus);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00019CB0 File Offset: 0x00017EB0
		public GameplayObjectives.Objective GetObjetive(string id)
		{
			GameplayObjectives.Objective objective;
			if (!this.m_objetivesDic.TryGetValue(id, out objective))
			{
				return null;
			}
			return objective;
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00019CD0 File Offset: 0x00017ED0
		public void UpdateObjetivesUIModel()
		{
			bool flag;
			GamePlayObjectivesModel gamePlayObjectivesModel = (GamePlayObjectivesModel)this.m_PanelDeObjectives.CurrentModelObjectAndState(out flag);
			gamePlayObjectivesModel.objectives.Clear();
			for (int i = 0; i < this.m_objetives.Count; i++)
			{
				GamePlayObjectiveModel gamePlayObjectiveModel = new GamePlayObjectiveModel();
				this.m_objetives[i].UpdateModel(gamePlayObjectiveModel);
				gamePlayObjectivesModel.objectives.Add(gamePlayObjectiveModel);
			}
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00019D35 File Offset: 0x00017F35
		private void M_PanelDeObjectives_onBiding(PanelDeObjectives obj)
		{
			this.UpdateObjetivesUIModel();
			if (this.m_updatingUIRutine != null)
			{
				base.StopCoroutine(this.m_updatingUIRutine);
				this.m_updatingUIRutine = null;
			}
			this.m_updatingUIRutine = base.StartCoroutine(this.UpdateUIRutine());
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00019D6A File Offset: 0x00017F6A
		private void M_PanelDeObjectives_onHiddenBase(PanelBase obj)
		{
			if (this.m_updatingUIRutine != null)
			{
				base.StopCoroutine(this.m_updatingUIRutine);
				this.m_updatingUIRutine = null;
			}
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00019D87 File Offset: 0x00017F87
		private IEnumerator UpdateUIRutine()
		{
			WaitForSeconds w = new WaitForSeconds(0.25f);
			for (;;)
			{
				yield return w;
				this.UpdateObjetivesUIModel();
				this.m_PanelDeObjectives.ActualizarValoresDePanel();
			}
			yield break;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00019D98 File Offset: 0x00017F98
		private void Objetive_statusChanged(ObjectiveStatus newStatus, ObjectiveStatus oldStatus, GameplayObjectives.Objective sender)
		{
			GameplayObjectives.StatusChandedHandler statusChandedHandler = this.objectiveStatusChanged;
			if (statusChandedHandler != null)
			{
				statusChandedHandler(newStatus, oldStatus, sender, this);
			}
			if (this.m_sessionRequired.Contains(sender.id) && this.m_sessionRequiredEnded.Add(sender.id))
			{
				this.m_completedRequiredObjectives++;
			}
			if (this.m_sessionNonRequired.Contains(sender.id) && this.m_sessionNonRequiredEnded.Add(sender.id))
			{
				this.m_completedOptionalObjectives++;
			}
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00019E24 File Offset: 0x00018024
		private void Objetive_statusChangedMsg(ObjectiveStatus newStatus, ObjectiveStatus oldStatus, GameplayObjectives.Objective sender)
		{
			if (newStatus == ObjectiveStatus.completed)
			{
				Singleton<MainCanvas>.instance.MostrartMsg(string.Empty, "Objective Completed", 0.001f, false, null, null, null);
			}
		}

		// Token: 0x040002AE RID: 686
		[SerializeReference]
		private List<GameplayObjectives.Objective> m_objetives = new List<GameplayObjectives.Objective>();

		// Token: 0x040002AF RID: 687
		private Dictionary<string, GameplayObjectives.Objective> m_objetivesDic = new Dictionary<string, GameplayObjectives.Objective>();

		// Token: 0x040002B0 RID: 688
		[SerializeField]
		private SerializableHashSetList<string> m_required = new SerializableHashSetList<string>();

		// Token: 0x040002B1 RID: 689
		[SerializeField]
		private SerializableHashSetList<string> m_nonRequired = new SerializableHashSetList<string>();

		// Token: 0x040002B2 RID: 690
		private PanelDeObjectives m_PanelDeObjectives;

		// Token: 0x040002B3 RID: 691
		private Coroutine m_UpdateCorutine;

		// Token: 0x040002B4 RID: 692
		[SerializeField]
		private ModificableDeBool m_showPanel = new ModificableDeBool(false);

		// Token: 0x040002B5 RID: 693
		[ReadOnlyUI]
		[SerializeField]
		private bool m_seflShowing;

		// Token: 0x040002B6 RID: 694
		[ReadOnlyUI]
		[SerializeField]
		private bool m_inSession;

		// Token: 0x040002B7 RID: 695
		[NonSerialized]
		private HashSet<string> m_sessionRequired = new HashSet<string>();

		// Token: 0x040002B8 RID: 696
		[NonSerialized]
		private HashSet<string> m_sessionNonRequired = new HashSet<string>();

		// Token: 0x040002B9 RID: 697
		[NonSerialized]
		private HashSet<string> m_sessionRequiredEnded = new HashSet<string>();

		// Token: 0x040002BA RID: 698
		[NonSerialized]
		private HashSet<string> m_sessionNonRequiredEnded = new HashSet<string>();

		// Token: 0x040002BB RID: 699
		[ReadOnlyUI]
		[SerializeField]
		private int m_totalRequiredObjectives;

		// Token: 0x040002BC RID: 700
		[ReadOnlyUI]
		[SerializeField]
		private int m_completedRequiredObjectives;

		// Token: 0x040002BD RID: 701
		[ReadOnlyUI]
		[SerializeField]
		private int m_totalOptionalObjectives;

		// Token: 0x040002BE RID: 702
		[ReadOnlyUI]
		[SerializeField]
		private int m_completedOptionalObjectives;

		// Token: 0x040002BF RID: 703
		private Coroutine m_updatingUIRutine;

		// Token: 0x020001B3 RID: 435
		// (Invoke) Token: 0x06000BAD RID: 2989
		public delegate void StatusChandedHandler(ObjectiveStatus newStatus, ObjectiveStatus oldStatus, GameplayObjectives.Objective objective, GameplayObjectives sender);

		// Token: 0x020001B4 RID: 436
		// (Invoke) Token: 0x06000BB1 RID: 2993
		public delegate void ProgressChandedHandler(float newProgressWeight, float oldProgressWeight, GameplayObjectives.Objective objective, GameplayObjectives sender);

		// Token: 0x020001B5 RID: 437
		[Serializable]
		public class SingleActionObjective : GameplayObjectives.Objective
		{
			// Token: 0x06000BB4 RID: 2996 RVA: 0x0002434E File Offset: 0x0002254E
			public SingleActionObjective(string ID, string description, bool checkAfterCompleted, ObjectiveCheckerHandler IsCompleted = null, bool RealTime = false, IReadOnlyList<GameplayObjectives.Objective> subObjectives = null, string tips = null)
				: base(ID, description, subObjectives, tips, RealTime, checkAfterCompleted, ObjectiveProgressType.singleAction)
			{
				this.m_isCompleted = IsCompleted;
			}

			// Token: 0x06000BB5 RID: 2997 RVA: 0x00024368 File Offset: 0x00022568
			public void SetCompleted()
			{
				if (base.status == ObjectiveStatus.completed)
				{
					return;
				}
				if (!base.CanProgress())
				{
					return;
				}
				base.OnProgressChanded(true);
				base.ChangeStatus(ObjectiveStatus.completed);
			}

			// Token: 0x06000BB6 RID: 2998 RVA: 0x0002438B File Offset: 0x0002258B
			protected override void OnUpdate()
			{
				if (this.m_isCompleted == null)
				{
					return;
				}
				if (this.m_isCompleted())
				{
					this.SetCompleted();
				}
			}

			// Token: 0x06000BB7 RID: 2999 RVA: 0x000243A9 File Offset: 0x000225A9
			public override void UpdateModelProgress(GamePlayObjectiveModel model)
			{
				model.progress = string.Empty;
			}

			// Token: 0x0400057C RID: 1404
			private ObjectiveCheckerHandler m_isCompleted;
		}

		// Token: 0x020001B6 RID: 438
		[Serializable]
		public class CountOfSingleActionObjective : GameplayObjectives.Objective
		{
			// Token: 0x170002F3 RID: 755
			// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x000243B6 File Offset: 0x000225B6
			public int capacity
			{
				get
				{
					return this.m_capacity;
				}
			}

			// Token: 0x170002F4 RID: 756
			// (get) Token: 0x06000BB9 RID: 3001 RVA: 0x000243BE File Offset: 0x000225BE
			public int count
			{
				get
				{
					return this.m_count;
				}
			}

			// Token: 0x1400005F RID: 95
			// (add) Token: 0x06000BBA RID: 3002 RVA: 0x000243C8 File Offset: 0x000225C8
			// (remove) Token: 0x06000BBB RID: 3003 RVA: 0x00024400 File Offset: 0x00022600
			public event GameplayObjectives.CountOfSingleActionObjective.CountChandedHandler countChanded;

			// Token: 0x14000060 RID: 96
			// (add) Token: 0x06000BBC RID: 3004 RVA: 0x00024438 File Offset: 0x00022638
			// (remove) Token: 0x06000BBD RID: 3005 RVA: 0x00024470 File Offset: 0x00022670
			public event ObjectiveCountChandedHandler countChanded2;

			// Token: 0x06000BBE RID: 3006 RVA: 0x000244A5 File Offset: 0x000226A5
			public CountOfSingleActionObjective(string ID, string description, bool checkAfterCompleted, int Capacity, ObjectiveCheckerHandler_CurrentCount CurrentCountGetter = null, bool RealTime = false, IReadOnlyList<GameplayObjectives.Objective> subObjectives = null, string tips = null)
				: base(ID, description, subObjectives, tips, RealTime, checkAfterCompleted, ObjectiveProgressType.countOfSingleAction)
			{
				this.m_getCurrentCount = CurrentCountGetter;
				this.m_capacity = Capacity;
				this.m_count = 0;
			}

			// Token: 0x06000BBF RID: 3007 RVA: 0x000244D0 File Offset: 0x000226D0
			public void SetCount(int newValue)
			{
				if (!base.CanProgress())
				{
					return;
				}
				if (newValue != this.count)
				{
					int count = this.m_count;
					this.m_count = newValue;
					bool flag = this.m_count >= this.m_capacity;
					base.OnProgressChanded(flag);
					GameplayObjectives.CountOfSingleActionObjective.CountChandedHandler countChandedHandler = this.countChanded;
					if (countChandedHandler != null)
					{
						countChandedHandler(this.m_count, count, this);
					}
					ObjectiveCountChandedHandler objectiveCountChandedHandler = this.countChanded2;
					if (objectiveCountChandedHandler != null)
					{
						objectiveCountChandedHandler(this.m_count, count, this);
					}
					if (flag)
					{
						base.ChangeStatus(ObjectiveStatus.completed);
					}
				}
			}

			// Token: 0x06000BC0 RID: 3008 RVA: 0x00024554 File Offset: 0x00022754
			protected override void OnUpdate()
			{
				if (this.m_getCurrentCount == null)
				{
					return;
				}
				int num = this.m_getCurrentCount(this.m_capacity, this.m_count);
				this.SetCount(num);
			}

			// Token: 0x06000BC1 RID: 3009 RVA: 0x00024589 File Offset: 0x00022789
			public override void UpdateModelProgress(GamePlayObjectiveModel model)
			{
				model.progress = string.Format("{0}/{1}", this.m_count, this.m_capacity);
			}

			// Token: 0x0400057F RID: 1407
			private ObjectiveCheckerHandler_CurrentCount m_getCurrentCount;

			// Token: 0x04000580 RID: 1408
			[SerializeField]
			[ReadOnlyUI]
			private int m_capacity;

			// Token: 0x04000581 RID: 1409
			[SerializeField]
			[ReadOnlyUI]
			private int m_count;

			// Token: 0x020001DC RID: 476
			// (Invoke) Token: 0x06000C73 RID: 3187
			public delegate void CountChandedHandler(int newValue, int oldValue, GameplayObjectives.CountOfSingleActionObjective sender);
		}

		// Token: 0x020001B7 RID: 439
		[Serializable]
		public class CountOfUniqueActionObjective : GameplayObjectives.Objective
		{
			// Token: 0x170002F5 RID: 757
			// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x000245B1 File Offset: 0x000227B1
			public int capacity
			{
				get
				{
					return this.m_capacity;
				}
			}

			// Token: 0x170002F6 RID: 758
			// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x000245B9 File Offset: 0x000227B9
			public int count
			{
				get
				{
					return this.m_uniqueActions.Count;
				}
			}

			// Token: 0x14000061 RID: 97
			// (add) Token: 0x06000BC4 RID: 3012 RVA: 0x000245C8 File Offset: 0x000227C8
			// (remove) Token: 0x06000BC5 RID: 3013 RVA: 0x00024600 File Offset: 0x00022800
			public event GameplayObjectives.CountOfUniqueActionObjective.CountChandedHandler countChanded;

			// Token: 0x14000062 RID: 98
			// (add) Token: 0x06000BC6 RID: 3014 RVA: 0x00024638 File Offset: 0x00022838
			// (remove) Token: 0x06000BC7 RID: 3015 RVA: 0x00024670 File Offset: 0x00022870
			public event ObjectiveCountChandedHandler countChanded2;

			// Token: 0x06000BC8 RID: 3016 RVA: 0x000246A5 File Offset: 0x000228A5
			public CountOfUniqueActionObjective(string ID, string description, bool checkAfterCompleted, int Capacity, ObjectiveCheckerHandler_GetLastUniqueAction LastUniqueActionGetter = null, bool RealTime = false, IReadOnlyList<GameplayObjectives.Objective> subObjectives = null, string tips = null)
				: base(ID, description, subObjectives, tips, RealTime, checkAfterCompleted, ObjectiveProgressType.countOfUniqueAction)
			{
				this.m_getLastAction = LastUniqueActionGetter;
				this.m_capacity = Capacity;
			}

			// Token: 0x06000BC9 RID: 3017 RVA: 0x000246D4 File Offset: 0x000228D4
			public void OnAction(string action)
			{
				if (!base.CanProgress())
				{
					return;
				}
				if (string.IsNullOrWhiteSpace(action))
				{
					return;
				}
				if (!this.m_uniqueActions.Contains(action))
				{
					int count = this.m_uniqueActions.Count;
					this.m_uniqueActions.Add(action);
					bool flag = this.m_uniqueActions.Count >= this.m_capacity;
					base.OnProgressChanded(flag);
					GameplayObjectives.CountOfUniqueActionObjective.CountChandedHandler countChandedHandler = this.countChanded;
					if (countChandedHandler != null)
					{
						countChandedHandler(this.m_uniqueActions.Count, count, this);
					}
					ObjectiveCountChandedHandler objectiveCountChandedHandler = this.countChanded2;
					if (objectiveCountChandedHandler != null)
					{
						objectiveCountChandedHandler(this.m_uniqueActions.Count, count, this);
					}
					if (flag)
					{
						base.ChangeStatus(ObjectiveStatus.completed);
					}
				}
			}

			// Token: 0x06000BCA RID: 3018 RVA: 0x00024780 File Offset: 0x00022980
			protected override void OnUpdate()
			{
				if (this.m_getLastAction == null)
				{
					return;
				}
				string text = this.m_getLastAction();
				this.OnAction(text);
			}

			// Token: 0x06000BCB RID: 3019 RVA: 0x000247A9 File Offset: 0x000229A9
			public override void UpdateModelProgress(GamePlayObjectiveModel model)
			{
				model.progress = string.Format("{0}/{1}", this.m_uniqueActions.Count, this.m_capacity);
			}

			// Token: 0x04000584 RID: 1412
			[SerializeField]
			[ReadOnlyUI]
			private List<string> m_uniqueActions = new List<string>();

			// Token: 0x04000585 RID: 1413
			private ObjectiveCheckerHandler_GetLastUniqueAction m_getLastAction;

			// Token: 0x04000586 RID: 1414
			[SerializeField]
			[ReadOnlyUI]
			private int m_capacity;

			// Token: 0x020001DD RID: 477
			// (Invoke) Token: 0x06000C77 RID: 3191
			public delegate void CountChandedHandler(int newValue, int oldValue, GameplayObjectives.CountOfUniqueActionObjective sender);
		}

		// Token: 0x020001B8 RID: 440
		[Serializable]
		public class FlagsObjective : GameplayObjectives.Objective
		{
			// Token: 0x170002F7 RID: 759
			// (get) Token: 0x06000BCC RID: 3020 RVA: 0x000247D6 File Offset: 0x000229D6
			public IReadOnlyDictionary<string, bool> flags
			{
				get
				{
					return this.m_flags;
				}
			}

			// Token: 0x14000063 RID: 99
			// (add) Token: 0x06000BCD RID: 3021 RVA: 0x000247E0 File Offset: 0x000229E0
			// (remove) Token: 0x06000BCE RID: 3022 RVA: 0x00024818 File Offset: 0x00022A18
			public event GameplayObjectives.FlagsObjective.FlagsChandedHandler flagsChanged;

			// Token: 0x14000064 RID: 100
			// (add) Token: 0x06000BCF RID: 3023 RVA: 0x00024850 File Offset: 0x00022A50
			// (remove) Token: 0x06000BD0 RID: 3024 RVA: 0x00024888 File Offset: 0x00022A88
			public event ObjectiveFlagsChandedHandler flagsChanged2;

			// Token: 0x06000BD1 RID: 3025 RVA: 0x000248C0 File Offset: 0x00022AC0
			public FlagsObjective(string ID, string description, bool checkAfterCompleted, IReadOnlyList<string> Flags, ObjectiveCheckerHandler_IsFlagSet IsFlagSet = null, bool RealTime = false, IReadOnlyList<GameplayObjectives.Objective> subObjectives = null, string tips = null)
				: base(ID, description, subObjectives, tips, RealTime, checkAfterCompleted, ObjectiveProgressType.flags)
			{
				this.m_flags = new StringKeyBoolValueDictionary();
				foreach (string text in Flags)
				{
					this.m_flags.Add(text, false);
				}
				this.m_isFlagSet = IsFlagSet;
			}

			// Token: 0x06000BD2 RID: 3026 RVA: 0x00024934 File Offset: 0x00022B34
			public void SetFlag(string flag, bool newValue)
			{
				if (!base.CanProgress())
				{
					return;
				}
				bool flag2;
				if (!this.m_flags.TryGetValue(flag, out flag2))
				{
					return;
				}
				if (newValue != flag2)
				{
					this.m_flags[flag] = newValue;
					bool flag3 = true;
					foreach (KeyValuePair<string, bool> keyValuePair in this.m_flags)
					{
						flag3 |= keyValuePair.Value;
					}
					base.OnProgressChanded(flag3);
					GameplayObjectives.FlagsObjective.FlagsChandedHandler flagsChandedHandler = this.flagsChanged;
					if (flagsChandedHandler != null)
					{
						flagsChandedHandler(flag, newValue, flag3, this);
					}
					ObjectiveFlagsChandedHandler objectiveFlagsChandedHandler = this.flagsChanged2;
					if (objectiveFlagsChandedHandler != null)
					{
						objectiveFlagsChandedHandler(flag, newValue, flag3, this);
					}
					if (flag3)
					{
						base.ChangeStatus(ObjectiveStatus.completed);
						return;
					}
					base.ChangeStatus(ObjectiveStatus.active);
				}
			}

			// Token: 0x06000BD3 RID: 3027 RVA: 0x00024A00 File Offset: 0x00022C00
			protected override void OnUpdate()
			{
				if (this.m_isFlagSet == null)
				{
					return;
				}
				foreach (KeyValuePair<string, bool> keyValuePair in this.m_flags)
				{
					this.SetFlag(keyValuePair.Key, this.m_isFlagSet(keyValuePair.Key));
				}
			}

			// Token: 0x06000BD4 RID: 3028 RVA: 0x00024A74 File Offset: 0x00022C74
			public override void UpdateModelProgress(GamePlayObjectiveModel model)
			{
				int num = 0;
				foreach (KeyValuePair<string, bool> keyValuePair in this.m_flags)
				{
					num += (keyValuePair.Value ? 1 : 0);
				}
				model.progress = string.Format("{0}/{1}", num, this.m_flags.Count);
			}

			// Token: 0x04000589 RID: 1417
			[SerializeField]
			private StringKeyBoolValueDictionary m_flags;

			// Token: 0x0400058A RID: 1418
			private ObjectiveCheckerHandler_IsFlagSet m_isFlagSet;

			// Token: 0x020001DE RID: 478
			// (Invoke) Token: 0x06000C7B RID: 3195
			public delegate void FlagsChandedHandler(string flag, bool newValue, bool allFlagsSet, GameplayObjectives.FlagsObjective sender);
		}

		// Token: 0x020001B9 RID: 441
		[Serializable]
		public sealed class PercentageObjective : GameplayObjectives.Objective
		{
			// Token: 0x170002F8 RID: 760
			// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x00024AF8 File Offset: 0x00022CF8
			public float progressWeight
			{
				get
				{
					return this.m_progressWeight;
				}
			}

			// Token: 0x14000065 RID: 101
			// (add) Token: 0x06000BD6 RID: 3030 RVA: 0x00024B00 File Offset: 0x00022D00
			// (remove) Token: 0x06000BD7 RID: 3031 RVA: 0x00024B38 File Offset: 0x00022D38
			public event GameplayObjectives.PercentageObjective.ProgressWeightChandedHandler progressWeightChanged;

			// Token: 0x14000066 RID: 102
			// (add) Token: 0x06000BD8 RID: 3032 RVA: 0x00024B70 File Offset: 0x00022D70
			// (remove) Token: 0x06000BD9 RID: 3033 RVA: 0x00024BA8 File Offset: 0x00022DA8
			public event PercentageObjectiveProgressWeightChandedHandler progressWeightChanged2;

			// Token: 0x06000BDA RID: 3034 RVA: 0x00024BDD File Offset: 0x00022DDD
			public PercentageObjective(string ID, string description, bool checkAfterCompleted, ObjectiveCheckerHandler_RecalculateWeight recalculateWeight = null, bool RealTime = false, IReadOnlyList<GameplayObjectives.Objective> subObjectives = null, string tips = null)
				: base(ID, description, subObjectives, tips, RealTime, checkAfterCompleted, ObjectiveProgressType.percentage)
			{
				this.m_recalculateWeight = recalculateWeight;
			}

			// Token: 0x06000BDB RID: 3035 RVA: 0x00024BF8 File Offset: 0x00022DF8
			public void ChangeProgress(float newProgress)
			{
				if (!base.CanProgress())
				{
					return;
				}
				if (!ExtendedMonoBehaviour.AlmostEqual(newProgress, this.m_progressWeight, 0.001f))
				{
					float progressWeight = this.m_progressWeight;
					this.m_progressWeight = newProgress;
					bool flag = this.m_progressWeight >= 1f;
					base.OnProgressChanded(flag);
					GameplayObjectives.PercentageObjective.ProgressWeightChandedHandler progressWeightChandedHandler = this.progressWeightChanged;
					if (progressWeightChandedHandler != null)
					{
						progressWeightChandedHandler(this.m_progressWeight, progressWeight, this);
					}
					PercentageObjectiveProgressWeightChandedHandler percentageObjectiveProgressWeightChandedHandler = this.progressWeightChanged2;
					if (percentageObjectiveProgressWeightChandedHandler != null)
					{
						percentageObjectiveProgressWeightChandedHandler(this.m_progressWeight, progressWeight, this);
					}
					if (flag)
					{
						base.ChangeStatus(ObjectiveStatus.completed);
					}
				}
			}

			// Token: 0x06000BDC RID: 3036 RVA: 0x00024C84 File Offset: 0x00022E84
			protected override void OnUpdate()
			{
				if (this.m_recalculateWeight == null)
				{
					return;
				}
				float num = this.m_recalculateWeight();
				this.ChangeProgress(num);
			}

			// Token: 0x06000BDD RID: 3037 RVA: 0x00024CB0 File Offset: 0x00022EB0
			public override void UpdateModelProgress(GamePlayObjectiveModel model)
			{
				model.progress = (this.m_progressWeight * 100f).ToString("P1");
			}

			// Token: 0x0400058D RID: 1421
			[SerializeField]
			[ReadOnlyUI]
			private float m_progressWeight;

			// Token: 0x0400058E RID: 1422
			private ObjectiveCheckerHandler_RecalculateWeight m_recalculateWeight;

			// Token: 0x020001DF RID: 479
			// (Invoke) Token: 0x06000C7F RID: 3199
			public delegate void ProgressWeightChandedHandler(float newProgressWeight, float oldProgressWeight, GameplayObjectives.PercentageObjective sender);
		}

		// Token: 0x020001BA RID: 442
		[Serializable]
		public abstract class Objective : ISMAJobObjective
		{
			// Token: 0x14000067 RID: 103
			// (add) Token: 0x06000BDE RID: 3038 RVA: 0x00024CDC File Offset: 0x00022EDC
			// (remove) Token: 0x06000BDF RID: 3039 RVA: 0x00024CE5 File Offset: 0x00022EE5
			event ObjectiveStatusChandedHandler ISMAJobObjective.statusChanged
			{
				add
				{
					this.m_statusChanged += value;
				}
				remove
				{
					this.m_statusChanged -= value;
				}
			}

			// Token: 0x14000068 RID: 104
			// (add) Token: 0x06000BE0 RID: 3040 RVA: 0x00024CEE File Offset: 0x00022EEE
			// (remove) Token: 0x06000BE1 RID: 3041 RVA: 0x00024CF7 File Offset: 0x00022EF7
			event ObjectiveProgressChandedHandler ISMAJobObjective.progressChanged
			{
				add
				{
					this.m_progressChanged += value;
				}
				remove
				{
					this.m_progressChanged -= value;
				}
			}

			// Token: 0x14000069 RID: 105
			// (add) Token: 0x06000BE2 RID: 3042 RVA: 0x00024D00 File Offset: 0x00022F00
			// (remove) Token: 0x06000BE3 RID: 3043 RVA: 0x00024D09 File Offset: 0x00022F09
			event OnObjectiveCompletedHandler ISMAJobObjective.onCompleted
			{
				add
				{
					this.m_onCompleted += value;
				}
				remove
				{
					this.m_onCompleted -= value;
				}
			}

			// Token: 0x170002F9 RID: 761
			// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x00024D12 File Offset: 0x00022F12
			public string id
			{
				get
				{
					return this.m_id;
				}
			}

			// Token: 0x170002FA RID: 762
			// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x00024D1A File Offset: 0x00022F1A
			public bool realTime
			{
				get
				{
					return this.m_realTime;
				}
			}

			// Token: 0x170002FB RID: 763
			// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x00024D22 File Offset: 0x00022F22
			public ObjectiveStatus status
			{
				get
				{
					return this.m_Status;
				}
			}

			// Token: 0x170002FC RID: 764
			// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x00024D2A File Offset: 0x00022F2A
			public ObjectiveProgressType progressType
			{
				get
				{
					return this.m_progressType;
				}
			}

			// Token: 0x170002FD RID: 765
			// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x00024D32 File Offset: 0x00022F32
			public ObjectiveCheckFrequency checkFrequency
			{
				get
				{
					if (!this.m_realTime)
					{
						return ObjectiveCheckFrequency.delayed;
					}
					return ObjectiveCheckFrequency.eachFrame;
				}
			}

			// Token: 0x1400006A RID: 106
			// (add) Token: 0x06000BE9 RID: 3049 RVA: 0x00024D40 File Offset: 0x00022F40
			// (remove) Token: 0x06000BEA RID: 3050 RVA: 0x00024D78 File Offset: 0x00022F78
			public event GameplayObjectives.Objective.StatusChandedHandler statusChanged;

			// Token: 0x1400006B RID: 107
			// (add) Token: 0x06000BEB RID: 3051 RVA: 0x00024DB0 File Offset: 0x00022FB0
			// (remove) Token: 0x06000BEC RID: 3052 RVA: 0x00024DE8 File Offset: 0x00022FE8
			public event GameplayObjectives.Objective.ProgressChandedHandler progressChanged;

			// Token: 0x1400006C RID: 108
			// (add) Token: 0x06000BED RID: 3053 RVA: 0x00024E20 File Offset: 0x00023020
			// (remove) Token: 0x06000BEE RID: 3054 RVA: 0x00024E58 File Offset: 0x00023058
			public event GameplayObjectives.Objective.OnCompletedHandler onCompleted;

			// Token: 0x1400006D RID: 109
			// (add) Token: 0x06000BEF RID: 3055 RVA: 0x00024E90 File Offset: 0x00023090
			// (remove) Token: 0x06000BF0 RID: 3056 RVA: 0x00024EC8 File Offset: 0x000230C8
			private event ObjectiveStatusChandedHandler m_statusChanged;

			// Token: 0x1400006E RID: 110
			// (add) Token: 0x06000BF1 RID: 3057 RVA: 0x00024F00 File Offset: 0x00023100
			// (remove) Token: 0x06000BF2 RID: 3058 RVA: 0x00024F38 File Offset: 0x00023138
			private event ObjectiveProgressChandedHandler m_progressChanged;

			// Token: 0x1400006F RID: 111
			// (add) Token: 0x06000BF3 RID: 3059 RVA: 0x00024F70 File Offset: 0x00023170
			// (remove) Token: 0x06000BF4 RID: 3060 RVA: 0x00024FA8 File Offset: 0x000231A8
			private event OnObjectiveCompletedHandler m_onCompleted;

			// Token: 0x06000BF5 RID: 3061 RVA: 0x00024FE0 File Offset: 0x000231E0
			protected Objective(string ID, string Description, IReadOnlyList<GameplayObjectives.Objective> SubObjectives, string Tips, bool RealTime, bool checkAfterCompleted, ObjectiveProgressType ProgressType)
			{
				this.m_progressType = ProgressType;
				this.m_Status = ObjectiveStatus.inactive;
				this.m_id = ID;
				this.m_subObjectives = ((SubObjectives != null) ? SubObjectives.ToArray<GameplayObjectives.Objective>() : null);
				this.m_description = Description;
				this.m_tips = Tips ?? string.Empty;
				this.m_realTime = RealTime;
				this.m_checkAfterCompleted = checkAfterCompleted;
			}

			// Token: 0x06000BF6 RID: 3062 RVA: 0x00025043 File Offset: 0x00023243
			internal void Update()
			{
				this.OnUpdate();
			}

			// Token: 0x06000BF7 RID: 3063 RVA: 0x0002504B File Offset: 0x0002324B
			public bool CanProgress()
			{
				return (this.m_Status != ObjectiveStatus.completed || this.m_checkAfterCompleted) && (this.m_Status == ObjectiveStatus.active || this.m_Status == ObjectiveStatus.completed);
			}

			// Token: 0x06000BF8 RID: 3064
			protected abstract void OnUpdate();

			// Token: 0x06000BF9 RID: 3065 RVA: 0x00025074 File Offset: 0x00023274
			public void ChangeStatus(ObjectiveStatus newStatus)
			{
				if (newStatus != this.m_Status)
				{
					ObjectiveStatus status = this.m_Status;
					this.m_Status = newStatus;
					GameplayObjectives.Objective.StatusChandedHandler statusChandedHandler = this.statusChanged;
					if (statusChandedHandler != null)
					{
						statusChandedHandler(this.m_Status, status, this);
					}
					ObjectiveStatusChandedHandler objectiveStatusChandedHandler = this.m_statusChanged;
					if (objectiveStatusChandedHandler != null)
					{
						objectiveStatusChandedHandler(this.m_Status, status, this);
					}
					if (newStatus == ObjectiveStatus.completed)
					{
						GameplayObjectives.Objective.OnCompletedHandler onCompletedHandler = this.onCompleted;
						if (onCompletedHandler != null)
						{
							onCompletedHandler(this);
						}
						OnObjectiveCompletedHandler onObjectiveCompletedHandler = this.m_onCompleted;
						if (onObjectiveCompletedHandler == null)
						{
							return;
						}
						onObjectiveCompletedHandler(this);
					}
				}
			}

			// Token: 0x06000BFA RID: 3066 RVA: 0x000250F4 File Offset: 0x000232F4
			public void UpdateModel(GamePlayObjectiveModel model)
			{
				model.id = this.m_id;
				model.completed = this.m_Status == ObjectiveStatus.completed;
				model.description = this.m_description;
				model.subObjetives = new List<ValueTuple<string, bool>>();
				if (this.m_subObjectives != null)
				{
					for (int i = 0; i < this.m_subObjectives.Length; i++)
					{
						GameplayObjectives.Objective objective = this.m_subObjectives[i];
						model.subObjetives.Add(new ValueTuple<string, bool>(objective.m_description, this.m_Status == ObjectiveStatus.completed));
					}
				}
				model.tooltip = this.m_tips;
				this.UpdateModelProgress(model);
			}

			// Token: 0x06000BFB RID: 3067
			public abstract void UpdateModelProgress(GamePlayObjectiveModel model);

			// Token: 0x06000BFC RID: 3068 RVA: 0x00025189 File Offset: 0x00023389
			protected void OnProgressChanded(bool completed)
			{
				GameplayObjectives.Objective.ProgressChandedHandler progressChandedHandler = this.progressChanged;
				if (progressChandedHandler != null)
				{
					progressChandedHandler(completed, this);
				}
				ObjectiveProgressChandedHandler objectiveProgressChandedHandler = this.m_progressChanged;
				if (objectiveProgressChandedHandler == null)
				{
					return;
				}
				objectiveProgressChandedHandler(completed, this);
			}

			// Token: 0x04000595 RID: 1429
			[ReadOnlyUI]
			[SerializeField]
			private string m_id;

			// Token: 0x04000596 RID: 1430
			[ReadOnlyUI]
			[SerializeField]
			private bool m_realTime;

			// Token: 0x04000597 RID: 1431
			[ReadOnlyUI]
			[SerializeField]
			private bool m_checkAfterCompleted;

			// Token: 0x04000598 RID: 1432
			[ReadOnlyUI]
			[SerializeField]
			private ObjectiveStatus m_Status;

			// Token: 0x04000599 RID: 1433
			[ReadOnlyUI]
			[SerializeField]
			private ObjectiveProgressType m_progressType;

			// Token: 0x0400059A RID: 1434
			[ReadOnlyUI]
			[SerializeField]
			private string m_description;

			// Token: 0x0400059B RID: 1435
			[ReadOnlyUI]
			[SerializeField]
			private string m_tips;

			// Token: 0x0400059C RID: 1436
			[ReadOnlyUI]
			[SerializeField]
			private GameplayObjectives.Objective[] m_subObjectives;

			// Token: 0x020001E0 RID: 480
			// (Invoke) Token: 0x06000C83 RID: 3203
			public delegate void StatusChandedHandler(ObjectiveStatus newStatus, ObjectiveStatus oldStatus, GameplayObjectives.Objective sender);

			// Token: 0x020001E1 RID: 481
			// (Invoke) Token: 0x06000C87 RID: 3207
			public delegate void ProgressChandedHandler(bool completed, GameplayObjectives.Objective sender);

			// Token: 0x020001E2 RID: 482
			// (Invoke) Token: 0x06000C8B RID: 3211
			public delegate void OnCompletedHandler(GameplayObjectives.Objective sender);
		}
	}
}
