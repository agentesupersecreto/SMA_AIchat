using System;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Modelos;
using Assets.TValle.IU.Runtime.Drawing.CurriculumVitae.Paneles;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.UI
{
	// Token: 0x020000B9 RID: 185
	[RequireComponent(typeof(MaleInfoPanel))]
	public class SMAMaleInfoPanelDataLoader : CustomMonobehaviour
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x000273D1 File Offset: 0x000255D1
		public MaleInfoPanel panel
		{
			get
			{
				return this.m_panel;
			}
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x000273DC File Offset: 0x000255DC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_panel = base.GetComponent<MaleInfoPanel>();
			this.m_panel.loading += this.M_panel_loading;
			this.m_panel.load += this.M_panel_load;
			this.m_panel.onAction += this.M_panel_onAction;
			this.m_panel.clearing += this.M_panel_clearing;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00027457 File Offset: 0x00025657
		private void M_panel_loading(ref MaleInfoModelo modelo, MaleInfoPanel sender)
		{
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00027459 File Offset: 0x00025659
		private void M_panel_load(ref MaleInfoModelo modelo, MaleInfoPanel sender)
		{
			MaleInfoPanel panel = this.panel;
			SMAMaleInfoPanelDataLoader.LoadInfoToPanel(((panel != null) ? panel.target : null) as MaleChar, modelo);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0002747C File Offset: 0x0002567C
		public static void LoadInfoToPanel(MaleChar character, MaleInfoModelo modelo)
		{
			if (character == null)
			{
				throw new ArgumentNullException("character", "character null reference.");
			}
			modelo.accion1ConfirmacionPregunta = null;
			AlteradoresDeCharacterMasculino componentInChildren = character.GetComponentInChildren<AlteradoresDeCharacterMasculino>();
			Penis componentInChildren2 = character.GetComponentInChildren<Penis>();
			if (componentInChildren == null)
			{
				throw new ArgumentNullException("AlteradoresDeCharacterMasculino", "AlteradoresDeCharacterMasculino null reference.");
			}
			if (componentInChildren2 == null)
			{
				throw new ArgumentNullException("Penis", "Penis null reference.");
			}
			modelo.height = Mathf.RoundToInt(character.estatura * 100f).ToString() + " cm";
			float num = (componentInChildren.alteradorDeFatValor * 0.9f + componentInChildren.alteradorDeMuscleValor * 0.1f - componentInChildren.alteradorDeThinValor * 0.6f) / 100f;
			float num2 = MathfExtension.InverseLerpConMedio(-0.6f, 0f, 1f, num);
			float num3 = character.estatura * (character.estatura / 2f) * (character.estatura / 4f) * MathfExtension.LerpConMedio(0.6f, 1f, 3f, num2);
			modelo.weight = (num3 * 100f).ToString("F1") + " kg";
			float num4 = (componentInChildren.alteradorDeFatValor * 3f - componentInChildren.alteradorDeMuscleValor * 0.1f - componentInChildren.alteradorDeThinValor * 1.15f) / 100f;
			float num5 = MathfExtension.InverseLerpConMedio(-1.25f, 0f, 3f, num4);
			modelo.bodyfat = (14f * MathfExtension.LerpConMedio(0.2f, 1f, 4f, num5)).ToString("F1") + " %";
			modelo.name = character.nombre;
			modelo.lastName = character.apellido;
			modelo.age = Mathf.FloorToInt(Mathf.Lerp(28f, 75f, (componentInChildren.alteradorDeOldValor / 100f).InPow(3f))).ToString();
			modelo.sex = "Male";
			modelo.currentLength = (componentInChildren2.worldLength * 100f).ToString("F1") + " cm";
			modelo.currentGirth = (componentInChildren2.worldMaxWidth * 100f).ToString("F1") + " cm";
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x000276E4 File Offset: 0x000258E4
		private void M_panel_onAction(int actionIndex, MaleInfoModelo modelo, MaleInfoPanel sender)
		{
			if (actionIndex == 1)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x000276F2 File Offset: 0x000258F2
		private void M_panel_clearing(ref MaleInfoModelo modelo, MaleInfoPanel sender)
		{
		}

		// Token: 0x0400040A RID: 1034
		private MaleInfoPanel m_panel;
	}
}
