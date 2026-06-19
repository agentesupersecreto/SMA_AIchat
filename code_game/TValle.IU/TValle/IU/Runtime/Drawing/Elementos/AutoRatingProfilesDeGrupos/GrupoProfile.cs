using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.TValle.IU.Runtime.Drawing.Elementos.AutoRatingProfilesDeGrupos
{
	// Token: 0x0200014C RID: 332
	public class GrupoProfile : UIElemento, IUIElementoConValor, IUIElementoConValorMutable, IUIElemento, IUIElementoConValorSoloEscritura, IUIElementoConValorSoloLectura
	{
		// Token: 0x14000046 RID: 70
		// (add) Token: 0x060009AB RID: 2475 RVA: 0x000200D0 File Offset: 0x0001E2D0
		// (remove) Token: 0x060009AC RID: 2476 RVA: 0x00020108 File Offset: 0x0001E308
		public event Action<GrupoProfile> onCambiar;

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x060009AD RID: 2477 RVA: 0x00020140 File Offset: 0x0001E340
		// (remove) Token: 0x060009AE RID: 2478 RVA: 0x00020178 File Offset: 0x0001E378
		public event Action<GrupoProfile> onEditar;

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x060009AF RID: 2479 RVA: 0x000201B0 File Offset: 0x0001E3B0
		// (remove) Token: 0x060009B0 RID: 2480 RVA: 0x000201E8 File Offset: 0x0001E3E8
		public event Action<GrupoProfile> onRemover;

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x0002021D File Offset: 0x0001E41D
		public int index
		{
			get
			{
				return this.m_index;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x00020225 File Offset: 0x0001E425
		public OnValueChanged onValueChanged
		{
			get
			{
				return this.m_onValueChanged;
			}
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00020230 File Offset: 0x0001E430
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.portraitDeGrupo == null)
			{
				throw new ArgumentNullException("portraitDeGrupo", "portraitDeGrupo null reference.");
			}
			if (this.m_cambiar == null)
			{
				throw new ArgumentNullException("m_cambiar", "m_cambiar null reference.");
			}
			if (this.m_editar == null)
			{
				throw new ArgumentNullException("m_editar", "m_editar null reference.");
			}
			if (this.m_remover == null)
			{
				throw new ArgumentNullException("m_remover", "m_remover null reference.");
			}
			if (this.m_SimpleTooltip == null)
			{
				throw new ArgumentNullException("m_SimpleTooltip", "m_SimpleTooltip null reference.");
			}
			this.m_cambiar.onClick.AddListener(new UnityAction(this.OnCambiar));
			this.m_editar.onClick.AddListener(new UnityAction(this.OnEditar));
			this.m_remover.onClick.AddListener(new UnityAction(this.OnRemover));
			this.m_SimpleTooltip.enabled = false;
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00020339 File Offset: 0x0001E539
		public void Init(int grupoIndex)
		{
			if (this.m_index != -1)
			{
				throw new NotSupportedException();
			}
			this.m_index = grupoIndex;
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00020354 File Offset: 0x0001E554
		public virtual void DoLoad(string nombreDeProtrait, GrupoProfile.LoadingMode loadingMode, PortraitDeGrupo.CustomLoaderHandler customLoader = null)
		{
			switch (loadingMode)
			{
			case GrupoProfile.LoadingMode.none:
				this.m_SimpleTooltip.enabled = false;
				this.m_cambiar.interactable = true;
				this.m_editar.interactable = true;
				this.m_remover.interactable = true;
				this.portraitDeGrupo.nombreDeProtrait = nombreDeProtrait;
				this.portraitDeGrupo.DoLoad(customLoader);
				this.UpdateControls();
				return;
			case GrupoProfile.LoadingMode.locked:
				this.portraitDeGrupo.Lock();
				this.m_cambiar.gameObject.SetActive(true);
				this.m_editar.gameObject.SetActive(true);
				this.m_remover.gameObject.SetActive(true);
				this.m_cambiar.interactable = false;
				this.m_editar.interactable = false;
				this.m_remover.interactable = false;
				this.m_SimpleTooltip.enabled = true;
				return;
			case GrupoProfile.LoadingMode.displayOnly:
				this.m_SimpleTooltip.enabled = false;
				this.portraitDeGrupo.nombreDeProtrait = nombreDeProtrait;
				this.portraitDeGrupo.DoLoadAsDisplayOnly(customLoader);
				this.UpdateControls();
				return;
			default:
				throw new ArgumentOutOfRangeException(loadingMode.ToString());
			}
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00020474 File Offset: 0x0001E674
		protected virtual void UpdateControls()
		{
			switch (this.portraitDeGrupo.modo)
			{
			case PortraitDeGrupo.Modo.applyed:
				this.m_cambiar.gameObject.SetActive(true);
				this.m_editar.gameObject.SetActive(true);
				this.m_remover.gameObject.SetActive(true);
				return;
			case PortraitDeGrupo.Modo.notFound:
				this.m_cambiar.gameObject.SetActive(true);
				this.m_editar.gameObject.SetActive(false);
				this.m_remover.gameObject.SetActive(true);
				return;
			case PortraitDeGrupo.Modo.manual:
				this.m_cambiar.gameObject.SetActive(true);
				this.m_editar.gameObject.SetActive(false);
				this.m_remover.gameObject.SetActive(false);
				return;
			case PortraitDeGrupo.Modo.displayOnly:
				this.m_cambiar.gameObject.SetActive(false);
				this.m_editar.gameObject.SetActive(false);
				this.m_remover.gameObject.SetActive(false);
				return;
			}
			throw new ArgumentOutOfRangeException(this.portraitDeGrupo.modo.ToString());
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0002059E File Offset: 0x0001E79E
		private void OnCambiar()
		{
			Action<GrupoProfile> action = this.onCambiar;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x000205B1 File Offset: 0x0001E7B1
		private void OnEditar()
		{
			Action<GrupoProfile> action = this.onEditar;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x000205C4 File Offset: 0x0001E7C4
		private void OnRemover()
		{
			Action<GrupoProfile> action = this.onRemover;
			if (action == null)
			{
				return;
			}
			action(this);
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x000205D7 File Offset: 0x0001E7D7
		public void Bind(string modeloName, Type modeloType, object initialValue, bool isListItem)
		{
			base.Bind(modeloName, modeloType, isListItem);
			this.SetValor(initialValue, true);
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x000205EC File Offset: 0x0001E7EC
		public void SetValor(object valor, bool silenced)
		{
			if (valor is string)
			{
				this.DoLoad(valor.ToString(), GrupoProfile.LoadingMode.none, null);
			}
			else
			{
				if (!(valor is IMultipleValorElemento<string, bool>))
				{
					throw new ArgumentOutOfRangeException();
				}
				IMultipleValorElemento<string, bool> multipleValorElemento = (IMultipleValorElemento<string, bool>)valor;
				this.DoLoad(multipleValorElemento.item1, multipleValorElemento.item2 ? GrupoProfile.LoadingMode.locked : GrupoProfile.LoadingMode.none, null);
			}
			if (!silenced)
			{
				this.m_onValueChanged.Invoke(this);
			}
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00020650 File Offset: 0x0001E850
		public object GetValor()
		{
			return this.portraitDeGrupo.nombreDeProtrait;
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00020677 File Offset: 0x0001E877
		string IUIElemento.get_name()
		{
			return base.name;
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0002067F File Offset: 0x0001E87F
		Transform IUIElemento.get_transform()
		{
			return base.transform;
		}

		// Token: 0x040003D6 RID: 982
		public PortraitDeGrupo portraitDeGrupo;

		// Token: 0x040003D7 RID: 983
		[ReadOnlyUI]
		[SerializeField]
		private int m_index = -1;

		// Token: 0x040003D8 RID: 984
		[SerializeField]
		protected Button m_cambiar;

		// Token: 0x040003D9 RID: 985
		[SerializeField]
		protected Button m_editar;

		// Token: 0x040003DA RID: 986
		[SerializeField]
		protected Button m_remover;

		// Token: 0x040003DB RID: 987
		[SerializeField]
		private SimpleTooltip m_SimpleTooltip;

		// Token: 0x040003DF RID: 991
		[SerializeField]
		private OnValueChanged m_onValueChanged = new OnValueChanged();

		// Token: 0x020001D0 RID: 464
		public enum LoadingMode
		{
			// Token: 0x040005C4 RID: 1476
			none,
			// Token: 0x040005C5 RID: 1477
			locked,
			// Token: 0x040005C6 RID: 1478
			displayOnly
		}
	}
}
