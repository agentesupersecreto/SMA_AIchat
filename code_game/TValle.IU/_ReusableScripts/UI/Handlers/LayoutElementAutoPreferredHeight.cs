using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.UI.Handlers
{
	// Token: 0x0200002E RID: 46
	public class LayoutElementAutoPreferredHeight : AplicableCustomMonobehaviour
	{
		// Token: 0x06000143 RID: 323 RVA: 0x00005B90 File Offset: 0x00003D90
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.m_itemsHolder == null)
			{
				throw new ArgumentNullException("m_itemsHolder", "m_itemsHolder null reference.");
			}
			if (this.m_target == null)
			{
				throw new ArgumentNullException("m_target", "m_target null reference.");
			}
			this.Actualizar();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00005BE5 File Offset: 0x00003DE5
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (!base.isStared)
			{
				return;
			}
			this.Actualizar();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00005BFC File Offset: 0x00003DFC
		private void OnTransformChildrenChanged()
		{
			if (!base.isStared)
			{
				return;
			}
			this.Actualizar();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00005C10 File Offset: 0x00003E10
		public void Actualizar()
		{
			try
			{
				HorizontalOrVerticalLayoutGroup component = this.m_itemsHolder.GetComponent<HorizontalOrVerticalLayoutGroup>();
				float valueOrDefault = ((component != null) ? new float?(component.spacing) : null).GetValueOrDefault();
				int? num;
				if (component == null)
				{
					num = null;
				}
				else
				{
					RectOffset padding = component.padding;
					num = ((padding != null) ? new int?(padding.top) : null);
				}
				int? num2 = num;
				int valueOrDefault2 = num2.GetValueOrDefault();
				int? num3;
				if (component == null)
				{
					num3 = null;
				}
				else
				{
					RectOffset padding2 = component.padding;
					num3 = ((padding2 != null) ? new int?(padding2.bottom) : null);
				}
				num2 = num3;
				int valueOrDefault3 = num2.GetValueOrDefault();
				this.m_itemsHolder.GetComponentsInChildren<LayoutElement>(false, LayoutElementAutoPreferredHeight.m_childrenTEMP);
				float num4 = (float)(valueOrDefault2 + valueOrDefault3);
				for (int i = 0; i < LayoutElementAutoPreferredHeight.m_childrenTEMP.Count; i++)
				{
					LayoutElement layoutElement = LayoutElementAutoPreferredHeight.m_childrenTEMP[i];
					if (!(layoutElement.transform == this.m_itemsHolder))
					{
						float preferredHeight = layoutElement.preferredHeight;
						num4 += preferredHeight;
						num4 += valueOrDefault;
					}
				}
				this.m_target.preferredHeight = num4;
			}
			finally
			{
				LayoutElementAutoPreferredHeight.m_childrenTEMP.Clear();
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00005D58 File Offset: 0x00003F58
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Actualizar",
				playTimeVisible = false
			};
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00005D71 File Offset: 0x00003F71
		protected override void OnAplicar()
		{
			base.OnAplicar();
			if (this.m_itemsHolder == null)
			{
				return;
			}
			if (this.m_target == null)
			{
				return;
			}
			this.Actualizar();
		}

		// Token: 0x040000A7 RID: 167
		[SerializeField]
		private LayoutElement m_target;

		// Token: 0x040000A8 RID: 168
		[SerializeField]
		private Transform m_itemsHolder;

		// Token: 0x040000A9 RID: 169
		private static List<LayoutElement> m_childrenTEMP = new List<LayoutElement>();
	}
}
