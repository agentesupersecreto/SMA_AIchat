using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x0200004F RID: 79
	[Modelo]
	[UnTittle]
	[Panel(width = 370, height = 239, controlChildHeight = false, controlChildWidth = false, childForceExpandHeight = false, childForceExpandWidth = false)]
	[Serializable]
	public class JobImageModelo
	{
		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06000275 RID: 629 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
		// (remove) Token: 0x06000276 RID: 630 RVA: 0x0000F608 File Offset: 0x0000D808
		public event Action<JobImageModelo> onChangeJobClicked;

		// Token: 0x06000277 RID: 631 RVA: 0x0000F63D File Offset: 0x0000D83D
		[Label("Change", "US")]
		[Descripcion("-Assign a different job for this model.", "US")]
		[BotonDePanel]
		public void ChangeJob()
		{
			Action<JobImageModelo> action = this.onChangeJobClicked;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x0400019A RID: 410
		[Imagen(height = 169, width = 300)]
		public Texture portrait;
	}
}
