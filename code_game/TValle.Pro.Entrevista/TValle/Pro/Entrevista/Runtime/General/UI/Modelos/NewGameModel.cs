using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Modelos.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.UI.Modelos
{
	// Token: 0x020000BA RID: 186
	[Panel(height = 650, posX = -195, posY = -26, backgroundColor = PanelBackgroundColor.white, backgroundType = PanelBackgroundType.window, backgroundAlpha = 1f)]
	[Modelo]
	[UnTittle]
	[Serializable]
	public class NewGameModel : BindableModel
	{
		// Token: 0x1400003D RID: 61
		// (add) Token: 0x060006CB RID: 1739 RVA: 0x000276FC File Offset: 0x000258FC
		// (remove) Token: 0x060006CC RID: 1740 RVA: 0x00027734 File Offset: 0x00025934
		public event Action onAttreibutoShapeChanged;

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x060006CD RID: 1741 RVA: 0x0002776C File Offset: 0x0002596C
		// (remove) Token: 0x060006CE RID: 1742 RVA: 0x000277A4 File Offset: 0x000259A4
		public event Action onAttreibutoAlturaChanged;

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x060006CF RID: 1743 RVA: 0x000277DC File Offset: 0x000259DC
		// (remove) Token: 0x060006D0 RID: 1744 RVA: 0x00027814 File Offset: 0x00025A14
		public event Action onAttreibutoPenisChanged;

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x060006D1 RID: 1745 RVA: 0x0002784C File Offset: 0x00025A4C
		// (remove) Token: 0x060006D2 RID: 1746 RVA: 0x00027884 File Offset: 0x00025A84
		public event Func<int, bool> canChangeAttreibutoMoney;

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x060006D3 RID: 1747 RVA: 0x000278BC File Offset: 0x00025ABC
		// (remove) Token: 0x060006D4 RID: 1748 RVA: 0x000278F4 File Offset: 0x00025AF4
		public event Action onAttreibutoMoneyChanged;

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x060006D5 RID: 1749 RVA: 0x0002792C File Offset: 0x00025B2C
		// (remove) Token: 0x060006D6 RID: 1750 RVA: 0x00027964 File Offset: 0x00025B64
		public event NewGameModel.onPanelValuesChangedHandler onPanelValuesChanged;

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x060006D7 RID: 1751 RVA: 0x0002799C File Offset: 0x00025B9C
		// (remove) Token: 0x060006D8 RID: 1752 RVA: 0x000279D4 File Offset: 0x00025BD4
		public event Action onSkinChanged;

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x060006D9 RID: 1753 RVA: 0x00027A0C File Offset: 0x00025C0C
		// (remove) Token: 0x060006DA RID: 1754 RVA: 0x00027A44 File Offset: 0x00025C44
		public event Action onCancel;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x060006DB RID: 1755 RVA: 0x00027A7C File Offset: 0x00025C7C
		// (remove) Token: 0x060006DC RID: 1756 RVA: 0x00027AB4 File Offset: 0x00025CB4
		public event Action onStart;

		// Token: 0x060006DD RID: 1757 RVA: 0x00027AE9 File Offset: 0x00025CE9
		[Label("Cancel", "US")]
		[BotonDePanel]
		public void Cancel()
		{
			Action action = this.onCancel;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x00027AFB File Offset: 0x00025CFB
		[Label("Start", "US")]
		[BotonDePanel]
		public void Start()
		{
			Action action = this.onStart;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00027B0D File Offset: 0x00025D0D
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x00027B15 File Offset: 0x00025D15
		[ActivatedDelegates(para = "Start")]
		public bool isValid { get; set; }

		// Token: 0x060006E1 RID: 1761 RVA: 0x00027B1E File Offset: 0x00025D1E
		protected override void Binded(IUIPanel to)
		{
			base.Binded(to);
			this.m_pointsLeftElemento = to.elementoPorModelo["pointsLeft"] as IUIElementoConValorSoloEscritura;
			if (this.m_pointsLeftElemento == null)
			{
				throw new ArgumentNullException("m_pointsLeftElemento", "m_pointsLeftElemento null reference.");
			}
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00027B5A File Offset: 0x00025D5A
		[ModelValueChangedListener]
		protected void OnSomeValueChanged(IUIElementoConValor elemento)
		{
			NewGameModel.onPanelValuesChangedHandler onPanelValuesChangedHandler = this.onPanelValuesChanged;
			if (onPanelValuesChangedHandler != null)
			{
				onPanelValuesChangedHandler((IUIElementoConValor)base.panel.elementoPorModelo["mainCharName"]);
			}
			this.RefreshStartButton();
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00027B8D File Offset: 0x00025D8D
		public void RefreshStartButton()
		{
			((IUIElementoRefreshable)base.panel.elementoPorModelo["Start"]).Refresh();
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00027BB0 File Offset: 0x00025DB0
		[MemberValueChangedListener(member = "skinColor")]
		protected void OnValorSkinColorChanged(IUIElementoConValor elemento)
		{
			int num = Convert.ToInt32(elemento.GetValor());
			this.skinColor = Mathf.Clamp(num, 0, 100);
			Action action = this.onSkinChanged;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00027BE8 File Offset: 0x00025DE8
		[MemberValueChangedListener(member = "altura")]
		protected void OnValorAlturaChanged(IUIElementoConValor elemento)
		{
			NewGameModel.CheckValues(ref this.altura, elemento, ref this.pointsLeft, this.m_pointsLeftElemento, 2);
			Action action = this.onAttreibutoAlturaChanged;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00027C13 File Offset: 0x00025E13
		[MemberValueChangedListener(member = "musculos")]
		protected void OnValorMusculosChanged(IUIElementoConValor elemento)
		{
			NewGameModel.CheckValues(ref this.musculos, elemento, ref this.pointsLeft, this.m_pointsLeftElemento, 1);
			Action action = this.onAttreibutoShapeChanged;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00027C3E File Offset: 0x00025E3E
		[MemberValueChangedListener(member = "slimness")]
		protected void OnValorBodyFatChanged(IUIElementoConValor elemento)
		{
			NewGameModel.CheckValues(ref this.slimness, elemento, ref this.pointsLeft, this.m_pointsLeftElemento, 1);
			Action action = this.onAttreibutoShapeChanged;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00027C69 File Offset: 0x00025E69
		[MemberValueChangedListener(member = "youngness")]
		protected void OnValorAgeChanged(IUIElementoConValor elemento)
		{
			NewGameModel.CheckValues(ref this.youngness, elemento, ref this.pointsLeft, this.m_pointsLeftElemento, 2);
			Action action = this.onAttreibutoShapeChanged;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00027C94 File Offset: 0x00025E94
		[MemberValueChangedListener(member = "money")]
		protected void OnValorMoneyChanged(IUIElementoConValor elemento)
		{
			int num;
			NewGameModel.ClampValue(ref this.money, elemento, out num);
			Func<int, bool> func = this.canChangeAttreibutoMoney;
			if (!((func != null) ? new bool?(func(num)) : null).GetValueOrDefault(true))
			{
				NewGameModel.UndoValue(ref this.money, elemento);
				return;
			}
			NewGameModel.CheckValues(ref this.money, elemento, ref this.pointsLeft, this.m_pointsLeftElemento, 2);
			Action action = this.onAttreibutoMoneyChanged;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00027D10 File Offset: 0x00025F10
		[MemberValueChangedListener(member = "dickSize")]
		protected void OnValorDickSizeChanged(IUIElementoConValor elemento)
		{
			NewGameModel.CheckValues(ref this.dickSize, elemento, ref this.pointsLeft, this.m_pointsLeftElemento, 1);
			Action action = this.onAttreibutoPenisChanged;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00027D3C File Offset: 0x00025F3C
		private static void ClampValue(ref int atributo, IUIElementoConValor attibutoElemento, out int newValor)
		{
			newValor = Convert.ToInt32(attibutoElemento.GetValor());
			int num = -1;
			int num2 = 3;
			if (newValor < num)
			{
				newValor = num;
			}
			if (atributo < num)
			{
				atributo = num;
				attibutoElemento.SetValor(num, true);
			}
			if (newValor > num2)
			{
				newValor = num2;
			}
			if (atributo > num2)
			{
				atributo = num2;
				attibutoElemento.SetValor(num2, true);
			}
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00027D94 File Offset: 0x00025F94
		private static void UndoValue(ref int atributo, IUIElementoConValor attibutoElemento)
		{
			int num;
			NewGameModel.ClampValue(ref atributo, attibutoElemento, out num);
			attibutoElemento.SetValor(atributo, true);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00027DB8 File Offset: 0x00025FB8
		private static void CheckValues(ref int atributo, IUIElementoConValor attibutoElemento, ref int pointsLeft, IUIElementoConValorSoloEscritura pointsLeftElemento, int cost)
		{
			int num;
			NewGameModel.ClampValue(ref atributo, attibutoElemento, out num);
			pointsLeft = Mathf.Clamp(pointsLeft, 0, 12);
			int num2 = Mathf.Clamp(num - atributo + atributo, -1, 3) - atributo;
			int num3 = num2 * cost;
			if (num3 > 0 && num3 > pointsLeft)
			{
				num2 = Mathf.Clamp(num2, 0, Mathf.FloorToInt((float)(pointsLeft / cost)));
				num3 = num2 * cost;
			}
			int num4 = atributo + num2;
			if (num4 != num)
			{
				attibutoElemento.SetValor(num4, true);
			}
			atributo = num4;
			pointsLeft -= num3;
			pointsLeftElemento.SetValor(pointsLeft, true);
		}

		// Token: 0x04000414 RID: 1044
		[Espacio(height = 30)]
		[InputConToolTip(contentType = InputConToolTipAttribute.ContentType.Name)]
		[Label("The main character's name is...", "US", color = ColorEnum.black)]
		public string mainCharName;

		// Token: 0x04000415 RID: 1045
		[Separador(height = 30)]
		[Label("Height (Cost x2)", "US", color = ColorEnum.black)]
		[DescripcionLocalizado("It also increases member size.", "US")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(-1f, 3f)]
		public int altura;

		// Token: 0x04000416 RID: 1046
		[Label("Physique", "US", color = ColorEnum.black)]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(-1f, 3f)]
		public int musculos;

		// Token: 0x04000417 RID: 1047
		[Label("Slimness ", "US", color = ColorEnum.black)]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(-1f, 3f)]
		public int slimness;

		// Token: 0x04000418 RID: 1048
		[Label("Youngness (Cost x2)", "US", color = ColorEnum.black)]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[DescripcionLocalizado("Increases the number of times the hero can ejaculate. (upgradeable later in the game).", "US")]
		[Range(-1f, 3f)]
		public int youngness;

		// Token: 0x04000419 RID: 1049
		[Label("Funds (Cost x2)", "US", color = ColorEnum.black)]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[DescripcionLocalizado("Change your starting clothes, money, and location (upgradeable later in the game).", "US")]
		[Range(-1f, 3f)]
		public int money;

		// Token: 0x0400041A RID: 1050
		[Label("Member size", "US", color = ColorEnum.black)]
		[DescripcionLocalizado("Most girls will be unable to take on a member that is too large.", "US")]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(-1f, 3f)]
		public int dickSize;

		// Token: 0x0400041B RID: 1051
		[Label("Available Points for allocation", "US", color = ColorEnum.black)]
		[LabelPar]
		public int pointsLeft = 6;

		// Token: 0x0400041C RID: 1052
		[Separador]
		[Label("Skin tone", "US", color = ColorEnum.black)]
		[DeslizableConToolTip(decimalesDibujar = 0, wholeNumbers = true)]
		[Range(0f, 100f)]
		public int skinColor = 25;

		// Token: 0x0400041E RID: 1054
		private IUIElementoConValorSoloEscritura m_pointsLeftElemento;

		// Token: 0x0200023C RID: 572
		// (Invoke) Token: 0x0600109F RID: 4255
		public delegate void onPanelValuesChangedHandler(IUIElementoConValor nameInputField);
	}
}
