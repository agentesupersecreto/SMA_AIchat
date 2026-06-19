using System;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos;
using Assets._ReusableScripts;
using Assets._ReusableScripts.UI.Drawing;
using UnityEngine;

namespace Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Paneles
{
	// Token: 0x02000151 RID: 337
	[RequireComponent(typeof(GenericUserPanelBase))]
	public class MaleInfoPanel : PanelBaseSingleModel<MaleInfoModelo>
	{
		// Token: 0x1400004E RID: 78
		// (add) Token: 0x060009E4 RID: 2532 RVA: 0x00020F80 File Offset: 0x0001F180
		// (remove) Token: 0x060009E5 RID: 2533 RVA: 0x00020FB8 File Offset: 0x0001F1B8
		public event MaleInfoPanel.LoadHandler loading;

		// Token: 0x1400004F RID: 79
		// (add) Token: 0x060009E6 RID: 2534 RVA: 0x00020FF0 File Offset: 0x0001F1F0
		// (remove) Token: 0x060009E7 RID: 2535 RVA: 0x00021028 File Offset: 0x0001F228
		public event MaleInfoPanel.LoadHandler load;

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x060009E8 RID: 2536 RVA: 0x00021060 File Offset: 0x0001F260
		// (remove) Token: 0x060009E9 RID: 2537 RVA: 0x00021098 File Offset: 0x0001F298
		public event MaleInfoPanel.AccionHandler onAction;

		// Token: 0x14000051 RID: 81
		// (add) Token: 0x060009EA RID: 2538 RVA: 0x000210D0 File Offset: 0x0001F2D0
		// (remove) Token: 0x060009EB RID: 2539 RVA: 0x00021108 File Offset: 0x0001F308
		public event MaleInfoPanel.LoadHandler clearing;

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x060009EC RID: 2540 RVA: 0x0002113D File Offset: 0x0001F33D
		public MaleInfoModelo curriculumModel
		{
			get
			{
				return this.m_model;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x060009ED RID: 2541 RVA: 0x00021145 File Offset: 0x0001F345
		public IAnimatorCharacter target
		{
			get
			{
				return this.m_target;
			}
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0002114D File Offset: 0x0001F34D
		public void SetTarget(IAnimatorCharacter Target)
		{
			if (Target == null)
			{
				throw new ArgumentNullException("Target", "Target null reference.");
			}
			this.m_target = Target;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0002116C File Offset: 0x0001F36C
		protected override void OnBinding()
		{
			base.OnBinding();
			DatosDeHumanBone head = this.m_target.bones.head;
			base.transform.SetPositionAndRotation(head.posicionFinal, head.rotacionFinal * head.offSetToForward);
			this.m_follower = base.gameObject.AddComponent<TrasnformCopier>();
			this.m_follower.Init(false, base.transform, this.m_target.bones.head.transform, new Vector3?(head.offSetToForward.eulerAngles), null, null);
			MaleInfoPanel.LoadHandler loadHandler = this.loading;
			if (loadHandler != null)
			{
				loadHandler(ref this.m_model, this);
			}
			this.OnLoading();
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0002122A File Offset: 0x0001F42A
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_model.accion1 += this.M_model_accion1;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0002124C File Offset: 0x0001F44C
		protected override void OnClearing()
		{
			base.OnClearing();
			this.m_model.accion1 -= this.M_model_accion1;
			MaleInfoPanel.LoadHandler loadHandler = this.clearing;
			if (loadHandler != null)
			{
				loadHandler(ref this.m_model, this);
			}
			this.m_model = new MaleInfoModelo();
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00021299 File Offset: 0x0001F499
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

		// Token: 0x060009F3 RID: 2547 RVA: 0x000212C8 File Offset: 0x0001F4C8
		private void OnLoading()
		{
			MaleInfoPanel.LoadHandler loadHandler = this.load;
			if (loadHandler == null)
			{
				return;
			}
			loadHandler(ref this.m_model, this);
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x000212E1 File Offset: 0x0001F4E1
		private void M_model_accion1(MaleInfoModelo obj)
		{
			MaleInfoPanel.AccionHandler accionHandler = this.onAction;
			if (accionHandler == null)
			{
				return;
			}
			accionHandler(0, obj, this);
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x000212F6 File Offset: 0x0001F4F6
		private void M_model_accion2(MaleInfoModelo obj)
		{
			MaleInfoPanel.AccionHandler accionHandler = this.onAction;
			if (accionHandler == null)
			{
				return;
			}
			accionHandler(1, obj, this);
		}

		// Token: 0x040003F6 RID: 1014
		[SerializeField]
		[ReadOnlyUI]
		private IAnimatorCharacter m_target;

		// Token: 0x040003F7 RID: 1015
		[SerializeField]
		[ReadOnlyUI]
		private TrasnformCopier m_follower;

		// Token: 0x020001D5 RID: 469
		// (Invoke) Token: 0x06000C66 RID: 3174
		public delegate void LoadHandler(ref MaleInfoModelo modelo, MaleInfoPanel sender);

		// Token: 0x020001D6 RID: 470
		// (Invoke) Token: 0x06000C6A RID: 3178
		public delegate void AccionHandler(int actionIndex, MaleInfoModelo modelo, MaleInfoPanel sender);
	}
}
