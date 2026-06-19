using System;
using Assets.Base.Plugins.Runtime.UI;
using Assets.TValle.IU.Runtime.Drawing;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using TMPro;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos
{
	// Token: 0x0200004D RID: 77
	[Modelo]
	[Label("Assignment", alignment = TextAlignmentOptions.MidlineRight)]
	[Panel(tipo = TipoDePanel.nestedContainerConTitulo, controlChildHeight = false, controlChildWidth = true, childForceExpandHeight = false, childForceExpandWidth = true, width = 625)]
	[Serializable]
	public class AssignmentInfoModelo
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600026C RID: 620 RVA: 0x0000F4A1 File Offset: 0x0000D6A1
		// (set) Token: 0x0600026D RID: 621 RVA: 0x0000F4A9 File Offset: 0x0000D6A9
		[ModeloExtraData(para = "level")]
		public string[] nivelesDisponiblesParaEsteJobParaEstaModelo { get; set; } = new string[] { "None" };

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600026E RID: 622 RVA: 0x0000F4B2 File Offset: 0x0000D6B2
		// (set) Token: 0x0600026F RID: 623 RVA: 0x0000F4BA File Offset: 0x0000D6BA
		public string[] DescDeNivelesDisponiblesParaEsteJobParaEstaModelo { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0000F4C3 File Offset: 0x0000D6C3
		// (set) Token: 0x06000271 RID: 625 RVA: 0x0000F4CB File Offset: 0x0000D6CB
		public string[] SalarioDeNivelesDisponiblesParaEsteJobParaEstaModelo { get; set; }

		// Token: 0x06000272 RID: 626 RVA: 0x0000F4D4 File Offset: 0x0000D6D4
		[MemberValueChangedListener(member = "level")]
		protected void OnLvlChanged(IUIElementoConValor elemento)
		{
			int num = Convert.ToInt32(elemento.GetValor());
			this.level = num;
			IUIPanel component = elemento.panelTransform.GetComponent<IUIPanel>();
			string text = this.DescDeNivelesDisponiblesParaEsteJobParaEstaModelo[num];
			this.assignmentDesc.label2 = text;
			((LabelParElement)component.elementoPorModelo["assignmentDesc"]).label2.text = text;
			string text2 = this.SalarioDeNivelesDisponiblesParaEsteJobParaEstaModelo[num];
			this.assignmentSalarioAtSelectedLevel.label2 = text2;
			((LabelParElement)component.elementoPorModelo["assignmentSalarioAtSelectedLevel"]).label2.text = text2;
		}

		// Token: 0x0400018C RID: 396
		[Ignore]
		public string id;

		// Token: 0x0400018D RID: 397
		[Ignore]
		public bool levelIsValid;

		// Token: 0x0400018E RID: 398
		[Ignore]
		public float[] incomes;

		// Token: 0x0400018F RID: 399
		[Modelo]
		public JobImageModelo portrait = new JobImageModelo();

		// Token: 0x04000190 RID: 400
		[LabelCortoLabelLargoPar]
		public LabelParData assignmentName = new LabelParData();

		// Token: 0x04000191 RID: 401
		[Label("Model Exp", "US")]
		[Descripcion("The model's experience in carrying out this assignment", "US")]
		[LevelLabelCorto]
		public LevelParData modelExperience = new LevelParData();

		// Token: 0x04000192 RID: 402
		[Label("Level", "US")]
		[Descripcion("-A higher level can be chosen here as the model gains experience in this job; some jobs only have one level.", "US")]
		[DesplegableLabelCorto]
		public int level;

		// Token: 0x04000193 RID: 403
		[LabelCortoLabelLargoPar]
		[LayoutDynamicUI(height = 120)]
		public LabelParData assignmentDesc = new LabelParData();

		// Token: 0x04000194 RID: 404
		[LabelCortoLabelLargoPar]
		public LabelParData assignmentSalarioAtSelectedLevel = new LabelParData();
	}
}
