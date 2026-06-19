using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200001D RID: 29
	public class SequencerCommandSonrreir : SequencerCommand
	{
		// Token: 0x06000094 RID: 148 RVA: 0x00007548 File Offset: 0x00005748
		public void Start()
		{
			try
			{
				FemaleChar componentInParent = base.Sequencer.Speaker.GetComponentInParent<FemaleChar>();
				if (!(componentInParent == null))
				{
					ControlladorDeGestosFacialesEmocionales componentInChildren = componentInParent.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
					if (!(componentInChildren == null))
					{
						ControladorDeGestosConCabeza componentInChildren2 = componentInParent.GetComponentInChildren<ControladorDeGestosConCabeza>();
						if (!(componentInChildren2 == null))
						{
							ControladorDeGestosConHombros componentInChildren3 = componentInParent.GetComponentInChildren<ControladorDeGestosConHombros>();
							if (!(componentInChildren3 == null))
							{
								float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
								float parameterAsFloat2 = base.GetParameterAsFloat(2, 0f);
								float parameterAsFloat3 = base.GetParameterAsFloat(3, 0f);
								bool parameterAsBool = base.GetParameterAsBool(4, false);
								float parameterAsFloat4 = base.GetParameterAsFloat(0, 1f);
								float num = (parameterAsBool ? parameterAsFloat4 : (base.Sequencer.SubtitleEndTime * parameterAsFloat4));
								SequencerCommandSonrreir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, parameterAsFloat2, parameterAsFloat3, num);
							}
						}
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00007630 File Offset: 0x00005830
		public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
		{
			RegistroDeFuncionesDeGestos.Sonrreir.Gestuar(female, weightFace, weightHead, weightHombros, duracionFace);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000763D File Offset: 0x0000583D
		public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
		{
			RegistroDeFuncionesDeGestos.Sonrreir.Gestuar(fController, headController, hombrosController, weightFace, weightHead, weightHombros, duracionFace);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000764E File Offset: 0x0000584E
		public void Update()
		{
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00007650 File Offset: 0x00005850
		public void OnDestroy()
		{
		}
	}
}
