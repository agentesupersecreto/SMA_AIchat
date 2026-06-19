using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos
{
	// Token: 0x02000116 RID: 278
	public abstract class SelectableFavoritablePortrait : SelectablePortraitBase
	{
		// Token: 0x1700024E RID: 590
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0001C7A5 File Offset: 0x0001A9A5
		protected sealed override bool linkToggleAndElementClick
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0001C7A8 File Offset: 0x0001A9A8
		public override void SetValor(object valor, bool silenced)
		{
			if (valor is IMultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, string, bool>)
			{
				IMultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, string, bool> multipleValorElemento = (IMultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, string, bool>)valor;
				MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool> multipleValorElemento2 = default(MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>);
				multipleValorElemento2.item1 = multipleValorElemento.item1;
				multipleValorElemento2.item2 = multipleValorElemento.item2;
				multipleValorElemento2.item3 = multipleValorElemento.item3;
				multipleValorElemento2.item4 = multipleValorElemento.item5;
				if (string.IsNullOrWhiteSpace(multipleValorElemento.item4))
				{
					TextMeshProUGUI resaltoText = this.m_resaltoText;
					if (resaltoText != null)
					{
						resaltoText.gameObject.SetActive(false);
					}
				}
				else if (this.m_resaltoText != null)
				{
					this.m_resaltoText.gameObject.SetActive(true);
					this.m_resaltoText.text = multipleValorElemento.item4;
				}
				base.SetValor(multipleValorElemento2, silenced);
				return;
			}
			base.SetValor(valor, silenced);
		}

		// Token: 0x0400033E RID: 830
		[SerializeField]
		private TextMeshProUGUI m_resaltoText;
	}
}
