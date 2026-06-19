using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000017 RID: 23
	public class SequencerCommandAchiquitarOjos : SequencerCommand
	{
		// Token: 0x06000076 RID: 118 RVA: 0x00006B50 File Offset: 0x00004D50
		public void Start()
		{
			try
			{
				FemaleChar componentInParent = base.Sequencer.Speaker.GetComponentInParent<FemaleChar>();
				if (!(componentInParent == null))
				{
					OjosExpresionController componentInChildren = componentInParent.GetComponentInChildren<OjosExpresionController>();
					if (!(componentInChildren == null))
					{
						float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
						float parameterAsFloat2 = base.GetParameterAsFloat(0, 1f);
						float num = base.Sequencer.SubtitleEndTime * parameterAsFloat2;
						SequencerCommandAchiquitarOjos.Gestuar(componentInChildren, parameterAsFloat, num);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00006BD8 File Offset: 0x00004DD8
		public static void Gestuar(OjosExpresionController ojosController, float weight, float duracion)
		{
			RegistroDeFuncionesDeGestos.Ojos.Gestuar(ojosController, OjosExpresionController.Tipo.achiquitar, weight, duracion);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00006BE3 File Offset: 0x00004DE3
		public void Update()
		{
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00006BE5 File Offset: 0x00004DE5
		public void OnDestroy()
		{
		}
	}
}
