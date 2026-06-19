using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002B2 RID: 690
	public class GUIControl : MonoBehaviour
	{
		// Token: 0x17000A77 RID: 2679
		// (get) Token: 0x06001CDB RID: 7387 RVA: 0x00036428 File Offset: 0x00034628
		// (set) Token: 0x06001CDC RID: 7388 RVA: 0x00036430 File Offset: 0x00034630
		public Rect rect { get; set; }

		// Token: 0x17000A78 RID: 2680
		// (get) Token: 0x06001CDD RID: 7389 RVA: 0x0003643C File Offset: 0x0003463C
		// (set) Token: 0x06001CDE RID: 7390 RVA: 0x00036444 File Offset: 0x00034644
		public Vector2 Offset { get; set; }

		// Token: 0x17000A79 RID: 2681
		// (get) Token: 0x06001CDF RID: 7391 RVA: 0x00036450 File Offset: 0x00034650
		protected List<GUIControl> Children
		{
			get
			{
				return this.children;
			}
		}

		// Token: 0x17000A7A RID: 2682
		// (get) Token: 0x06001CE0 RID: 7392 RVA: 0x00036458 File Offset: 0x00034658
		// (set) Token: 0x06001CE1 RID: 7393 RVA: 0x00036460 File Offset: 0x00034660
		public bool NeedToUpdateLayout
		{
			get
			{
				return this.needToUpdateLayout;
			}
			set
			{
				this.needToUpdateLayout = value;
			}
		}

		// Token: 0x17000A7B RID: 2683
		// (get) Token: 0x06001CE2 RID: 7394 RVA: 0x0003646C File Offset: 0x0003466C
		// (set) Token: 0x06001CE3 RID: 7395 RVA: 0x00036474 File Offset: 0x00034674
		protected Vector2 WindowSize
		{
			get
			{
				return this.windowSize;
			}
			set
			{
				this.windowSize = value;
			}
		}

		// Token: 0x17000A7C RID: 2684
		// (get) Token: 0x06001CE4 RID: 7396 RVA: 0x00036480 File Offset: 0x00034680
		public bool IsNavigationEnabled
		{
			get
			{
				return this.navigation != null && this.navigation.enabled;
			}
		}

		// Token: 0x17000A7D RID: 2685
		// (get) Token: 0x06001CE5 RID: 7397 RVA: 0x0003649C File Offset: 0x0003469C
		public string FullName
		{
			get
			{
				if (string.IsNullOrEmpty(this.fullName))
				{
					this.fullName = Tools.GetFullName(base.gameObject);
				}
				return this.fullName;
			}
		}

		// Token: 0x17000A7E RID: 2686
		// (get) Token: 0x06001CE6 RID: 7398 RVA: 0x000364C8 File Offset: 0x000346C8
		// (set) Token: 0x06001CE7 RID: 7399 RVA: 0x000364D0 File Offset: 0x000346D0
		public Vector2 dRect { get; set; }

		// Token: 0x06001CE8 RID: 7400 RVA: 0x000364DC File Offset: 0x000346DC
		public virtual void Awake()
		{
			this.dRect = Vector2.zero;
			this.rect = this.scaledRect.GetPixelRect();
			this.Offset = Vector2.zero;
		}

		// Token: 0x06001CE9 RID: 7401 RVA: 0x00036510 File Offset: 0x00034710
		public virtual void OnEnable()
		{
			this.Refresh();
			if (this.IsNavigationEnabled && this.navigation.focusFirstControlOnEnable)
			{
				this.navigation.FocusFirstControl();
			}
		}

		// Token: 0x06001CEA RID: 7402 RVA: 0x0003654C File Offset: 0x0003474C
		public void Draw(Vector2 relativeMousePosition)
		{
			if (this.visible && base.gameObject.activeSelf)
			{
				this.UpdateLayout();
				this.DrawSelf(relativeMousePosition);
				this.DrawChildren(relativeMousePosition);
			}
		}

		// Token: 0x06001CEB RID: 7403 RVA: 0x00036588 File Offset: 0x00034788
		public virtual void DrawSelf(Vector2 relativeMousePosition)
		{
		}

		// Token: 0x06001CEC RID: 7404 RVA: 0x0003658C File Offset: 0x0003478C
		public virtual void DrawChildren(Vector2 relativeMousePosition)
		{
			if (this.Children.Count == 0)
			{
				return;
			}
			if (this.clipChildren)
			{
				GUI.BeginGroup(this.rect);
			}
			try
			{
				bool isNavigationEnabled = this.IsNavigationEnabled;
				if (!isNavigationEnabled || this.navigation.click == KeyCode.Space || Event.current.type != EventType.KeyDown || Event.current.character != ' ')
				{
					GUIControl guicontrol = null;
					bool flag = this.IsNavigationEnabled && (this.navigation.IsClicked || this.navigationSelectButtonClicked);
					Vector2 vector = new Vector2(relativeMousePosition.x - this.rect.x, relativeMousePosition.y - this.rect.y);
					if (isNavigationEnabled)
					{
						this.navigation.CheckNavigationInput(vector);
					}
					foreach (GUIControl guicontrol2 in this.Children)
					{
						if (this.IsNavigationEnabled)
						{
							GUI.SetNextControlName(guicontrol2.FullName);
							if (flag && string.Equals(GUI.GetNameOfFocusedControl(), guicontrol2.FullName))
							{
								this.navigationSelectButtonClicked = false;
								guicontrol = guicontrol2;
							}
						}
						guicontrol2.Draw(vector);
					}
					if (isNavigationEnabled)
					{
						GUI.FocusControl(this.navigation.FocusedControlName);
					}
					if (guicontrol != null && guicontrol is GUIButton)
					{
						(guicontrol as GUIButton).Click();
					}
				}
			}
			finally
			{
				if (this.clipChildren)
				{
					GUI.EndGroup();
				}
			}
		}

		// Token: 0x06001CED RID: 7405 RVA: 0x00036778 File Offset: 0x00034978
		public virtual void Update()
		{
			if (this.IsNavigationEnabled)
			{
				this.navigationSelectButtonClicked = DialogueManager.GetInputButtonDown(this.navigation.clickButton);
			}
		}

		// Token: 0x06001CEE RID: 7406 RVA: 0x000367AC File Offset: 0x000349AC
		public virtual void Refresh(Vector2 windowSize)
		{
			this.NeedToUpdateLayout = true;
			this.WindowSize = windowSize;
		}

		// Token: 0x06001CEF RID: 7407 RVA: 0x000367BC File Offset: 0x000349BC
		public virtual void Refresh()
		{
			this.NeedToUpdateLayout = true;
		}

		// Token: 0x06001CF0 RID: 7408 RVA: 0x000367C8 File Offset: 0x000349C8
		public virtual void UpdateLayout()
		{
			if (this.NeedToUpdateLayout)
			{
				this.UpdateLayoutSelf();
				this.FitSelf();
				this.UpdateLayoutChildren();
				this.FitChildren();
			}
		}

		// Token: 0x06001CF1 RID: 7409 RVA: 0x000367F8 File Offset: 0x000349F8
		public virtual void UpdateLayoutSelf()
		{
			this.NeedToUpdateLayout = false;
			if (this.WindowSize.x == 0f)
			{
				this.WindowSize = new Vector2((float)Screen.width, (float)Screen.height);
			}
			this.rect = this.scaledRect.GetPixelRect(this.WindowSize);
			if (this.Offset.x != 0f || this.Offset.y != 0f)
			{
				this.rect = new Rect(this.rect.x + this.Offset.x, this.rect.y + this.Offset.y, this.rect.width, this.rect.height);
			}
			if (this.dRect.x != 0f || this.dRect.y != 0f)
			{
				this.rect = new Rect(this.rect.x + this.dRect.x, this.rect.y + this.dRect.y, this.rect.width, this.rect.height);
			}
			if (this.autoSize != null)
			{
				this.AutoSizeSelf();
			}
		}

		// Token: 0x06001CF2 RID: 7410 RVA: 0x00036994 File Offset: 0x00034B94
		public virtual void AutoSizeSelf()
		{
		}

		// Token: 0x06001CF3 RID: 7411 RVA: 0x00036998 File Offset: 0x00034B98
		protected virtual void FitSelf()
		{
			if (this.fit != null && this.fit.IsSpecified)
			{
				float num = this.rect.xMin;
				float num2 = this.rect.xMax;
				float num3 = this.rect.yMin;
				float num4 = this.rect.yMax;
				if (this.fit.above != null)
				{
					num4 = this.fit.above.rect.yMin;
					if (this.fit.below == null && !this.fit.expandToFit)
					{
						num3 = num4 - this.rect.height;
					}
				}
				if (this.fit.below != null)
				{
					num3 = this.fit.below.rect.yMax;
					if (this.fit.above == null && !this.fit.expandToFit)
					{
						num4 = num3 + this.rect.height;
					}
				}
				if (this.fit.leftOf != null)
				{
					num2 = this.fit.leftOf.rect.xMin;
					if (this.fit.rightOf == null && !this.fit.expandToFit)
					{
						num = num2 - this.rect.width;
					}
				}
				if (this.fit.rightOf != null)
				{
					num = this.fit.rightOf.rect.xMax;
					if (this.fit.rightOf == null && !this.fit.expandToFit)
					{
						num2 = num + this.rect.width;
					}
				}
				this.rect = Rect.MinMaxRect(num, num3, num2, num4);
			}
		}

		// Token: 0x06001CF4 RID: 7412 RVA: 0x00036BB0 File Offset: 0x00034DB0
		private void UpdateLayoutChildren()
		{
			this.FindChildren();
			if (this.depthSortChildren)
			{
				this.SortChildren();
			}
			Vector2 vector = new Vector2(this.rect.width, this.rect.height);
			foreach (GUIControl guicontrol in this.Children)
			{
				this.UpdateLayoutChild(guicontrol, vector);
			}
		}

		// Token: 0x06001CF5 RID: 7413 RVA: 0x00036C54 File Offset: 0x00034E54
		private void UpdateLayoutChild(GUIControl child, Vector2 childWindowSize)
		{
			child.Refresh(childWindowSize);
			child.dRect = ((!this.clipChildren) ? new Vector2(this.rect.x, this.rect.y) : Vector2.zero);
			child.UpdateLayout();
		}

		// Token: 0x06001CF6 RID: 7414 RVA: 0x00036CAC File Offset: 0x00034EAC
		private void FitChildren()
		{
			for (int i = 0; i < this.Children.Count; i++)
			{
				this.Children[i].FitSelf();
			}
		}

		// Token: 0x06001CF7 RID: 7415 RVA: 0x00036CE8 File Offset: 0x00034EE8
		private void FindChildren()
		{
			this.Children.Clear();
			foreach (object obj in base.transform)
			{
				Transform transform = (Transform)obj;
				GUIControl[] components = transform.GetComponents<GUIControl>();
				this.Children.AddRange(components);
				if (components.Length > 0)
				{
					components[0].FindChildren();
				}
			}
		}

		// Token: 0x06001CF8 RID: 7416 RVA: 0x00036D80 File Offset: 0x00034F80
		private void SortChildren()
		{
			this.Children.Sort((GUIControl x, GUIControl y) => x.depth.CompareTo(y.depth));
		}

		// Token: 0x0400106E RID: 4206
		public int depth;

		// Token: 0x0400106F RID: 4207
		public bool depthSortChildren;

		// Token: 0x04001070 RID: 4208
		public ScaledRect scaledRect = new ScaledRect(ScaledRect.wholeScreen);

		// Token: 0x04001071 RID: 4209
		public AutoSize autoSize;

		// Token: 0x04001072 RID: 4210
		public Fit fit;

		// Token: 0x04001073 RID: 4211
		public Navigation navigation;

		// Token: 0x04001074 RID: 4212
		public bool visible = true;

		// Token: 0x04001075 RID: 4213
		public bool clipChildren = true;

		// Token: 0x04001076 RID: 4214
		private string fullName;

		// Token: 0x04001077 RID: 4215
		private List<GUIControl> children = new List<GUIControl>();

		// Token: 0x04001078 RID: 4216
		private bool needToUpdateLayout = true;

		// Token: 0x04001079 RID: 4217
		private Vector2 windowSize = Vector2.zero;

		// Token: 0x0400107A RID: 4218
		private bool navigationSelectButtonClicked;
	}
}
