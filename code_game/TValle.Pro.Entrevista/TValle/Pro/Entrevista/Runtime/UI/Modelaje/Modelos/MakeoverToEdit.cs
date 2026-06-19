using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Modelaje.Modelos
{
	// Token: 0x02000037 RID: 55
	[Modelo]
	[Panel(width = 475, height = 900)]
	[Label("Makeover Editor", "US", alignment = TextAlignmentOptions.MidlineRight, fontStyle = FontStyles.Bold, fontSizeMod = 1.25f)]
	[Serializable]
	public class MakeoverToEdit
	{
		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060001D3 RID: 467 RVA: 0x0000BD50 File Offset: 0x00009F50
		// (remove) Token: 0x060001D4 RID: 468 RVA: 0x0000BD88 File Offset: 0x00009F88
		public event Action<IUIElementoConValor, IUIPanel> onModelChanged;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060001D5 RID: 469 RVA: 0x0000BDC0 File Offset: 0x00009FC0
		// (remove) Token: 0x060001D6 RID: 470 RVA: 0x0000BDF8 File Offset: 0x00009FF8
		public event Action accion1;

		// Token: 0x060001D7 RID: 471 RVA: 0x0000BE2D File Offset: 0x0000A02D
		[ModelValueChangedListener(escucharTodosLosElementosAnteriores = true)]
		protected virtual void OnModelChanged(IUIElementoConValor elemento)
		{
			Action<IUIElementoConValor, IUIPanel> action = this.onModelChanged;
			if (action == null)
			{
				return;
			}
			action(elemento, elemento.transform.GetComponentInParent<IUIPanel>());
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000BE4B File Offset: 0x0000A04B
		[BotonDePanel]
		[Label("Ok", "US")]
		public void Accion1()
		{
			Action action = this.accion1;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x0400013E RID: 318
		[Modelo]
		[Label("MakeUp (BETA)", "US")]
		public MakeUpMakeover makeUp = new MakeUpMakeover();

		// Token: 0x0400013F RID: 319
		[Modelo]
		[Label("Hair", "US")]
		public HairMakeover hair = new HairMakeover();

		// Token: 0x04000140 RID: 320
		[Modelo]
		[Label("Eyebrows", "US")]
		public EyebrowsMakeover eyebrows = new EyebrowsMakeover();

		// Token: 0x04000141 RID: 321
		[Modelo]
		[Label("Eyelashes", "US")]
		public EyelashesMakeover eyelashes = new EyelashesMakeover();

		// Token: 0x04000142 RID: 322
		[Modelo]
		[Label("Lipstick Color", "US")]
		public LipstickMakeover lipstick = new LipstickMakeover();
	}
}
