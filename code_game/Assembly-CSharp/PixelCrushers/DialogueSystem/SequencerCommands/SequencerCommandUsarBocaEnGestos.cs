using System;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000016 RID: 22
	public class SequencerCommandUsarBocaEnGestos : SequencerCommand
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00006AB0 File Offset: 0x00004CB0
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
						float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
						float parameterAsFloat2 = base.GetParameterAsFloat(0, 1f);
						float num = base.Sequencer.SubtitleEndTime * parameterAsFloat2;
						SequencerCommandUsarBocaEnGestos.UsarBoca(componentInChildren, parameterAsFloat, num);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00006B38 File Offset: 0x00004D38
		public static void UsarBoca(ControlladorDeGestosFacialesEmocionales fController, float minWeight, float duracion)
		{
			RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, minWeight, duracion);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00006B42 File Offset: 0x00004D42
		public void Update()
		{
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00006B44 File Offset: 0x00004D44
		public void OnDestroy()
		{
		}
	}
}
