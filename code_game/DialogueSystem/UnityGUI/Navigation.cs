using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002CE RID: 718
	[Serializable]
	public class Navigation
	{
		// Token: 0x17000A8B RID: 2699
		// (get) Token: 0x06001D7A RID: 7546 RVA: 0x00039218 File Offset: 0x00037418
		public string FocusedControlName
		{
			get
			{
				return (!this.IsCurrentValid) ? string.Empty : this.order[this.current].FullName;
			}
		}

		// Token: 0x17000A8C RID: 2700
		// (get) Token: 0x06001D7B RID: 7547 RVA: 0x00039244 File Offset: 0x00037444
		private bool IsCurrentValid
		{
			get
			{
				return this.IsOrderArrayValid && 0 <= this.current && this.current < this.order.Length;
			}
		}

		// Token: 0x17000A8D RID: 2701
		// (get) Token: 0x06001D7C RID: 7548 RVA: 0x0003927C File Offset: 0x0003747C
		private bool IsOrderArrayValid
		{
			get
			{
				return this.order != null && this.order.Length > 0;
			}
		}

		// Token: 0x17000A8E RID: 2702
		// (get) Token: 0x06001D7D RID: 7549 RVA: 0x00039298 File Offset: 0x00037498
		public bool IsClicked
		{
			get
			{
				return Event.current.type == EventType.KeyDown && Event.current.keyCode == this.click;
			}
		}

		// Token: 0x06001D7E RID: 7550 RVA: 0x000392CC File Offset: 0x000374CC
		public void FocusFirstControl()
		{
			if (this.IsOrderArrayValid && this.IsClickableButton(this.order[0]))
			{
				this.current = 0;
			}
			else
			{
				this.current = ((this.order == null) ? 0 : (this.order.Length + 1));
				this.Navigate(1);
			}
		}

		// Token: 0x06001D7F RID: 7551 RVA: 0x0003932C File Offset: 0x0003752C
		public void CheckNavigationInput(Vector2 relativeMousePosition)
		{
			this.CheckMouseWheel();
			float navigationAxis = this.GetNavigationAxis();
			if (this.IsPreviousControlInputDown(navigationAxis))
			{
				this.Navigate(-1);
			}
			else if (this.IsNextControlInputDown(navigationAxis))
			{
				this.Navigate(1);
			}
			else if (this.jumpToMousePosition)
			{
				this.NavigateToMousePosition(relativeMousePosition);
			}
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x00039388 File Offset: 0x00037588
		private void NavigateToMousePosition(Vector2 relativeMousePosition)
		{
			for (int i = 0; i < this.order.Length; i++)
			{
				if (this.order[i].gameObject.activeInHierarchy && this.order[i].visible && this.IsClickableButton(this.order[i]) && this.order[i].rect.Contains(relativeMousePosition))
				{
					this.current = i;
					return;
				}
			}
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x00039410 File Offset: 0x00037610
		public void Navigate(int direction)
		{
			if (this.IsOrderArrayValid)
			{
				int num = this.current;
				this.current = this.NextControlIndex(direction);
				int num2 = 0;
				while (!this.IsClickableButton(this.order[this.current]) && this.current != num && num2 <= 999)
				{
					this.current = this.NextControlIndex(direction);
					num2++;
				}
			}
		}

		// Token: 0x06001D82 RID: 7554 RVA: 0x00039484 File Offset: 0x00037684
		private bool IsClickableButton(GUIControl control)
		{
			return control != null && control.visible && control is GUIButton && (control as GUIButton).clickable;
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x000394C4 File Offset: 0x000376C4
		private int NextControlIndex(int direction)
		{
			if (this.IsOrderArrayValid)
			{
				int num = (this.current + direction) % this.order.Length;
				return (num < 0) ? (this.order.Length - 1) : num;
			}
			return 0;
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x00039508 File Offset: 0x00037708
		private void CheckMouseWheel()
		{
			if (Event.current.type == EventType.ScrollWheel)
			{
				this.mouseWheelY += Event.current.delta.y;
			}
		}

		// Token: 0x06001D85 RID: 7557 RVA: 0x00039544 File Offset: 0x00037744
		private bool IsNextControlInputDown(float axisValue)
		{
			if (Event.current.type == EventType.KeyDown && Event.current.keyCode == this.next)
			{
				Event.current.Use();
				this.isAxisNextDown = true;
			}
			else if (this.mouseWheelY >= this.mouseWheelSensitivity)
			{
				this.mouseWheelY = 0f;
				return true;
			}
			bool flag = this.isAxisNextDown && axisValue <= 0.01f && Time.time >= this.timeNextRelease;
			this.isAxisNextDown = axisValue > 0.01f;
			if (axisValue > 0.5f)
			{
				if (DialogueTime.time >= this.axisRepeatTime)
				{
					this.axisRepeatTime = DialogueTime.time + this.axisRepeatDelay;
					this.timeNextRelease = Time.time + 0.5f;
					return true;
				}
			}
			else
			{
				if (axisValue >= 0f)
				{
					this.axisRepeatTime = 0f;
				}
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001D86 RID: 7558 RVA: 0x00039648 File Offset: 0x00037848
		private bool IsPreviousControlInputDown(float axisValue)
		{
			if (Event.current.type == EventType.KeyDown && Event.current.keyCode == this.previous)
			{
				Event.current.Use();
				this.isAxisPrevDown = true;
			}
			else if (this.mouseWheelY <= -this.mouseWheelSensitivity)
			{
				this.mouseWheelY = 0f;
				return true;
			}
			bool flag = this.isAxisPrevDown && axisValue >= -0.01f && Time.time >= this.timeNextRelease;
			this.isAxisPrevDown = axisValue < -0.01f;
			if (axisValue < -0.5f)
			{
				if (DialogueTime.time >= this.axisRepeatTime)
				{
					this.axisRepeatTime = DialogueTime.time + this.axisRepeatDelay;
					this.timeNextRelease = Time.time + 0.5f;
					return true;
				}
			}
			else
			{
				if (axisValue <= 0f)
				{
					this.axisRepeatTime = 0f;
				}
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001D87 RID: 7559 RVA: 0x0003974C File Offset: 0x0003794C
		private float GetNavigationAxis()
		{
			if (!Application.isPlaying || string.IsNullOrEmpty(this.axis))
			{
				return 0f;
			}
			float num;
			try
			{
				num = Input.GetAxis(this.axis) * (float)((!this.invertAxis) ? 1 : (-1));
			}
			catch (UnityException)
			{
				num = 0f;
			}
			return num;
		}

		// Token: 0x04001101 RID: 4353
		private const float AxisThreshold = 0.5f;

		// Token: 0x04001102 RID: 4354
		private const float MinorAxisThreshold = 0.01f;

		// Token: 0x04001103 RID: 4355
		public bool enabled;

		// Token: 0x04001104 RID: 4356
		public bool focusFirstControlOnEnable = true;

		// Token: 0x04001105 RID: 4357
		public bool jumpToMousePosition = true;

		// Token: 0x04001106 RID: 4358
		public GUIControl[] order;

		// Token: 0x04001107 RID: 4359
		public string clickButton = "Fire1";

		// Token: 0x04001108 RID: 4360
		public KeyCode click = KeyCode.Space;

		// Token: 0x04001109 RID: 4361
		public KeyCode previous = KeyCode.UpArrow;

		// Token: 0x0400110A RID: 4362
		public KeyCode next = KeyCode.DownArrow;

		// Token: 0x0400110B RID: 4363
		public string axis = "Vertical";

		// Token: 0x0400110C RID: 4364
		public bool invertAxis = true;

		// Token: 0x0400110D RID: 4365
		public float axisRepeatDelay = 1f;

		// Token: 0x0400110E RID: 4366
		public float mouseWheelSensitivity = 5f;

		// Token: 0x0400110F RID: 4367
		private int current;

		// Token: 0x04001110 RID: 4368
		private float axisRepeatTime;

		// Token: 0x04001111 RID: 4369
		private float mouseWheelY;

		// Token: 0x04001112 RID: 4370
		private bool isAxisPrevDown;

		// Token: 0x04001113 RID: 4371
		private bool isAxisNextDown;

		// Token: 0x04001114 RID: 4372
		private float timeNextRelease;
	}
}
