using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;

namespace Assets.Productos.Juegos.Reception.Scripts.Entrevistas.Modelos
{
	// Token: 0x020000B0 RID: 176
	[Panel(width = 400, height = 550)]
	[Modelo]
	[UnTittle]
	[Serializable]
	public class EntrevistaStartCampaingInfo
	{
		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060003F6 RID: 1014 RVA: 0x0001429C File Offset: 0x0001249C
		// (remove) Token: 0x060003F7 RID: 1015 RVA: 0x000142D4 File Offset: 0x000124D4
		public event Action onNoEnoughMoney;

		// Token: 0x060003F8 RID: 1016 RVA: 0x0001430C File Offset: 0x0001250C
		public void Binded(IUIPanel to)
		{
			this.m_allPublicElemento = to.elementoPorModelo["allPublic"] as IUIElementoConValorSoloEscritura;
			this.m_amateurElemento = to.elementoPorModelo["amateur"] as IUIElementoConValorSoloEscritura;
			this.m_profesionalsElemento = to.elementoPorModelo["profesionals"] as IUIElementoConValorSoloEscritura;
			this.m_costoElemento = to.elementoPorModelo["costo"] as IUIElementoConValorSoloEscritura;
			if (this.m_costoElemento == null)
			{
				throw new ArgumentNullException("m_costoElemento", "m_costoElemento null reference.");
			}
			if (this.m_profesionalsElemento == null)
			{
				throw new ArgumentNullException("m_profesionalsElemento", "m_profesionalsElemento null reference.");
			}
			if (this.m_amateurElemento == null)
			{
				throw new ArgumentNullException("m_amateurElemento", "m_amateurElemento null reference.");
			}
			if (this.m_allPublicElemento == null)
			{
				throw new ArgumentNullException("m_allPublicElemento", "m_allPublicElemento null reference.");
			}
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x000143E8 File Offset: 0x000125E8
		[MemberValueChangedListener(member = "allPublic")]
		protected void OnAllPublicChanged(IUIElementoConValor elemento)
		{
			if (!Convert.ToBoolean(elemento.GetValor()))
			{
				elemento.SetValor(true, false);
				return;
			}
			this.allPublic = true;
			this.amateur = false;
			this.profesionals = false;
			this.m_amateurElemento.SetValor(false, true);
			this.m_profesionalsElemento.SetValor(false, true);
			this.costMoney = 100f;
			this.costo = 100f.ToString("C");
			this.m_costoElemento.SetValor(this.costo, true);
			if (this.costMoney > this.currentMoney)
			{
				Action action = this.onNoEnoughMoney;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0001449C File Offset: 0x0001269C
		[MemberValueChangedListener(member = "amateur")]
		protected void OnAmateurChanged(IUIElementoConValor elemento)
		{
			if (!Convert.ToBoolean(elemento.GetValor()))
			{
				elemento.SetValor(true, false);
				return;
			}
			this.amateur = true;
			this.allPublic = false;
			this.profesionals = false;
			this.m_allPublicElemento.SetValor(false, true);
			this.m_profesionalsElemento.SetValor(false, true);
			this.costMoney = 700f;
			this.costo = 700f.ToString("C");
			this.m_costoElemento.SetValor(this.costo, true);
			if (this.costMoney > this.currentMoney)
			{
				Action action = this.onNoEnoughMoney;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00014550 File Offset: 0x00012750
		[MemberValueChangedListener(member = "profesionals")]
		protected void OnProfesionalsChanged(IUIElementoConValor elemento)
		{
			if (!Convert.ToBoolean(elemento.GetValor()))
			{
				elemento.SetValor(true, false);
				return;
			}
			this.profesionals = true;
			this.allPublic = false;
			this.amateur = false;
			this.m_allPublicElemento.SetValor(false, true);
			this.m_amateurElemento.SetValor(false, true);
			this.costMoney = 5000f;
			this.costo = 5000f.ToString("C");
			this.m_costoElemento.SetValor(this.costo, true);
			if (this.costMoney > this.currentMoney)
			{
				Action action = this.onNoEnoughMoney;
				if (action == null)
				{
					return;
				}
				action();
			}
		}

		// Token: 0x040001AC RID: 428
		public const float allPublicCost = 100f;

		// Token: 0x040001AD RID: 429
		public const float amateurCost = 700f;

		// Token: 0x040001AE RID: 430
		public const float profesionalsCost = 5000f;

		// Token: 0x040001B0 RID: 432
		[Texto(height = 90)]
		public string GuiaInfo = "*Please choose a campaign type. The models participating in the new campaign are required to meet a minimum standard.";

		// Token: 0x040001B1 RID: 433
		[Separador]
		[Toggle]
		[Label("Free For All", "US")]
		[Descripcion("Pay someone to distribute pamphlets in the street.", "US")]
		public bool allPublic;

		// Token: 0x040001B2 RID: 434
		[Toggle]
		[Label("Amateur", "US")]
		[Descripcion("Social Media & Local Print Ads", "US")]
		public bool amateur;

		// Token: 0x040001B3 RID: 435
		[Toggle]
		[Label("Professionals", "US")]
		[Descripcion("Social Media, Events & Shows Ads", "US")]
		public bool profesionals;

		// Token: 0x040001B4 RID: 436
		[Separador]
		[Label("Cost in Total", "US")]
		[Descripcion("asdasdas asd a asd as ads", "US")]
		[InfoLabel]
		public string costo = 0f.ToString("C");

		// Token: 0x040001B5 RID: 437
		public float costMoney;

		// Token: 0x040001B6 RID: 438
		public float currentMoney;

		// Token: 0x040001B7 RID: 439
		private IUIElementoConValorSoloEscritura m_allPublicElemento;

		// Token: 0x040001B8 RID: 440
		private IUIElementoConValorSoloEscritura m_amateurElemento;

		// Token: 0x040001B9 RID: 441
		private IUIElementoConValorSoloEscritura m_profesionalsElemento;

		// Token: 0x040001BA RID: 442
		private IUIElementoConValorSoloEscritura m_costoElemento;
	}
}
