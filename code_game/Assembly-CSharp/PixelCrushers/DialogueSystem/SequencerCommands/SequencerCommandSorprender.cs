using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200001E RID: 30
	public class SequencerCommandSorprender : SequencerCommand
	{
		// Token: 0x0600009A RID: 154 RVA: 0x0000765C File Offset: 0x0000585C
		public void Start()
		{
			try
			{
				FemaleChar componentInParent = base.Sequencer.Speaker.GetComponentInParent<FemaleChar>();
				if (!(componentInParent == null))
				{
					float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
					float parameterAsFloat2 = base.GetParameterAsFloat(2, 0f);
					float parameterAsFloat3 = base.GetParameterAsFloat(3, 0f);
					float parameterAsFloat4 = base.GetParameterAsFloat(4, 0f);
					bool parameterAsBool = base.GetParameterAsBool(5, false);
					float parameterAsFloat5 = base.GetParameterAsFloat(0, 1f);
					float num = (parameterAsBool ? parameterAsFloat5 : (base.Sequencer.SubtitleEndTime * parameterAsFloat5));
					SequencerCommandSorprender.Gestuar(componentInParent, parameterAsFloat, parameterAsFloat2, parameterAsFloat3, parameterAsFloat4, num);
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000770C File Offset: 0x0000590C
		public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float weightBoca, float duracion)
		{
			RegistroDeFuncionesDeGestos.Sorprender.Gestuar(female, weightFace, weightHead, weightHombros, weightBoca, duracion);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000771B File Offset: 0x0000591B
		public void Update()
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000771D File Offset: 0x0000591D
		public void OnDestroy()
		{
		}
	}
}
