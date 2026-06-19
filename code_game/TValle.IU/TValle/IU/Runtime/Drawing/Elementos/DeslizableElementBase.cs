using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000115 RID: 277
	public abstract class DeslizableElementBase : UIElemento, IUIElementoConExtraData, IUIElemento, IUIElementoConValorModificable
	{
		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x0001C660 File Offset: 0x0001A860
		// (set) Token: 0x06000831 RID: 2097 RVA: 0x0001C668 File Offset: 0x0001A868
		public IReadOnlyList<Func<object>> extradata
		{
			get
			{
				return this.m_extradata;
			}
			set
			{
				this.m_extradata = (List<Func<object>>)value;
				this.TryUpdateRangeWithExtraData();
			}
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0001C67C File Offset: 0x0001A87C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.slider == null)
			{
				throw new ArgumentNullException("slider", "slider null reference.");
			}
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0001C6A4 File Offset: 0x0001A8A4
		protected void TryUpdateRangeWithExtraData()
		{
			ITuple tuple = null;
			if (this.m_extradata != null && this.m_extradata.Count > 0)
			{
				for (int i = 0; i < this.m_extradata.Count; i++)
				{
					Func<object> func = this.m_extradata[i];
					tuple = ((func != null) ? func() : null) as ITuple;
					if (tuple != null)
					{
						break;
					}
				}
			}
			if (tuple == null || tuple.Length != 2)
			{
				return;
			}
			this.slider.minValue = Convert.ToSingle(tuple[0]);
			this.slider.maxValue = Convert.ToSingle(tuple[1]);
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0001C73B File Offset: 0x0001A93B
		public float GetValorAsModZeroToOne()
		{
			return Mathf.InverseLerp(this.slider.minValue, this.slider.maxValue, Convert.ToSingle(this.GetValor()));
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0001C763 File Offset: 0x0001A963
		public void SetValorAsModZeroToOne(float valorZeroToOne, bool silenced)
		{
			this.SetValor(Mathf.Lerp(this.slider.minValue, this.slider.maxValue, valorZeroToOne), silenced);
		}

		// Token: 0x06000836 RID: 2102
		public abstract object GetValor();

		// Token: 0x06000837 RID: 2103
		public abstract void SetValor(object valor, bool silenced);

		// Token: 0x06000839 RID: 2105 RVA: 0x0001C795 File Offset: 0x0001A995
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0001C79D File Offset: 0x0001A99D
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0400033C RID: 828
		public Slider slider;

		// Token: 0x0400033D RID: 829
		private List<Func<object>> m_extradata;
	}
}
