using System;
using Assets;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000015 RID: 21
	public class SequencerCommandSuprimirTipoDeExpresion : SequencerCommand
	{
		// Token: 0x0600006C RID: 108 RVA: 0x000069FC File Offset: 0x00004BFC
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
						ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoDeExpresion = base.GetParameter(0, "0").ToEnum(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia);
						float parameterAsFloat = base.GetParameterAsFloat(1, 1f);
						float num = base.Sequencer.SubtitleEndTime * parameterAsFloat;
						float parameterAsFloat2 = base.GetParameterAsFloat(2, 1f);
						SequencerCommandSuprimirTipoDeExpresion.Suprimir(componentInChildren, tipoDeExpresion, num, parameterAsFloat2);
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00006A98 File Offset: 0x00004C98
		public static void Suprimir(ControlladorDeGestosFacialesEmocionales fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, float duracion, float weight)
		{
			RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, tipo, duracion, weight);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00006AA3 File Offset: 0x00004CA3
		public void Update()
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00006AA5 File Offset: 0x00004CA5
		public void OnDestroy()
		{
		}
	}
}
