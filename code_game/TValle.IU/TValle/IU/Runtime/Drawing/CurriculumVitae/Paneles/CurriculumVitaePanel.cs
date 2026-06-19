using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Paneles
{
	// Token: 0x0200014F RID: 335
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class CurriculumVitaePanel : PanelBaseSingleModel<CurriculumVitaeModelo>
	{
		// Token: 0x1400004A RID: 74
		// (add) Token: 0x060009CD RID: 2509 RVA: 0x00020B70 File Offset: 0x0001ED70
		// (remove) Token: 0x060009CE RID: 2510 RVA: 0x00020BA8 File Offset: 0x0001EDA8
		public event CurriculumVitaePanel.LoadHandler loading;

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x060009CF RID: 2511 RVA: 0x00020BE0 File Offset: 0x0001EDE0
		// (remove) Token: 0x060009D0 RID: 2512 RVA: 0x00020C18 File Offset: 0x0001EE18
		public event CurriculumVitaePanel.LoadHandler load;

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x060009D1 RID: 2513 RVA: 0x00020C50 File Offset: 0x0001EE50
		// (remove) Token: 0x060009D2 RID: 2514 RVA: 0x00020C88 File Offset: 0x0001EE88
		public event CurriculumVitaePanel.AccionHandler onAction;

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x060009D3 RID: 2515 RVA: 0x00020CC0 File Offset: 0x0001EEC0
		// (remove) Token: 0x060009D4 RID: 2516 RVA: 0x00020CF8 File Offset: 0x0001EEF8
		public event CurriculumVitaePanel.LoadHandler clearing;

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x060009D5 RID: 2517 RVA: 0x00020D2D File Offset: 0x0001EF2D
		public CurriculumVitaeModelo curriculumModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x060009D6 RID: 2518 RVA: 0x00020D35 File Offset: 0x0001EF35
		public IAnimatorCharacter target
		{
			get
			{
				return this.m_target;
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x00020D3D File Offset: 0x0001EF3D
		public void SetTarget(IAnimatorCharacter Target)
		{
			if (Target == null)
			{
				throw new ArgumentNullException("Target", "Target null reference.");
			}
			this.m_target = Target;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00020D5C File Offset: 0x0001EF5C
		protected override void OnBinding()
		{
			base.OnBinding();
			DatosDeHumanBone head = this.m_target.bones.head;
			base.transform.SetPositionAndRotation(head.posicionFinal, head.rotacionFinal * head.offSetToForward);
			this.m_follower = base.gameObject.AddComponent<TrasnformCopier>();
			this.m_follower.Init(false, base.transform, this.m_target.bones.head.transform, new Vector3?(head.offSetToForward.eulerAngles), null, null);
			CurriculumVitaePanel.LoadHandler loadHandler = this.loading;
			if (loadHandler != null)
			{
				loadHandler(ref this.m_model, this);
			}
			this.OnLoading();
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x00020E1A File Offset: 0x0001F01A
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_model.accion1 += this.M_model_accion1;
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00020E3C File Offset: 0x0001F03C
		protected override void OnClearing()
		{
			base.OnClearing();
			this.m_model.accion1 -= this.M_model_accion1;
			CurriculumVitaePanel.LoadHandler loadHandler = this.clearing;
			if (loadHandler != null)
			{
				loadHandler(ref this.m_model, this);
			}
			this.m_model = new CurriculumVitaeModelo();
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00020E89 File Offset: 0x0001F089
		protected override void OnCleared()
		{
			base.OnCleared();
			this.m_target = null;
			if (this.m_follower != null)
			{
				Object.Destroy(this.m_follower);
			}
			this.m_follower = null;
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x00020EB8 File Offset: 0x0001F0B8
		private void OnLoading()
		{
			CurriculumVitaePanel.LoadHandler loadHandler = this.load;
			if (loadHandler == null)
			{
				return;
			}
			loadHandler(ref this.m_model, this);
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x00020ED1 File Offset: 0x0001F0D1
		private void M_model_accion1(CurriculumVitaeModelo obj)
		{
			CurriculumVitaePanel.AccionHandler accionHandler = this.onAction;
			if (accionHandler == null)
			{
				return;
			}
			accionHandler(0, obj, this);
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00020EE6 File Offset: 0x0001F0E6
		private void M_model_accion2(CurriculumVitaeModelo obj)
		{
			CurriculumVitaePanel.AccionHandler accionHandler = this.onAction;
			if (accionHandler == null)
			{
				return;
			}
			accionHandler(1, obj, this);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x00020EFC File Offset: 0x0001F0FC
		public void UpdatePortraitPanel()
		{
			IUIPanel iuipanel = null;
			string text = "portrait";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			base.ReDrawSubModelo(this.m_model.portrait, text, ref iuipanel, base.UIPanel, base.UIPanel.GetParentPara(0));
		}

		// Token: 0x040003EF RID: 1007
		[SerializeField]
		[ReadOnlyUI]
		private IAnimatorCharacter m_target;

		// Token: 0x040003F0 RID: 1008
		[SerializeField]
		[ReadOnlyUI]
		private TrasnformCopier m_follower;

		// Token: 0x020001D3 RID: 467
		// (Invoke) Token: 0x06000C5E RID: 3166
		public delegate void LoadHandler(ref CurriculumVitaeModelo modelo, CurriculumVitaePanel sender);

		// Token: 0x020001D4 RID: 468
		// (Invoke) Token: 0x06000C62 RID: 3170
		public delegate void AccionHandler(int actionIndex, CurriculumVitaeModelo modelo, CurriculumVitaePanel sender);
	}
}
