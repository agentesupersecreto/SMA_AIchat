using System;
using Assets;
using Assets.Base.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200001B RID: 27
	public class SequencerCommandGestuarAutoBadMood : SequencerCommand
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00007108 File Offset: 0x00005308
		public void Start()
		{
			try
			{
				Personalidad.Tipo tipo = DialogueLua.GetVariable("MAYOR_PERSONALIDAD").AsString.ToEnum(Personalidad.Tipo.None);
				if (tipo == Personalidad.Tipo.All)
				{
					Debug.LogError("Cant gestuar a All personality", this);
				}
				else
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
									float num = base.GetParameterAsFloat(2, 0f);
									float parameterAsFloat2 = base.GetParameterAsFloat(3, 0f);
									bool parameterAsBool = base.GetParameterAsBool(4, false);
									float parameterAsFloat3 = base.GetParameterAsFloat(0, 1f);
									float num2 = (parameterAsBool ? parameterAsFloat3 : (base.Sequencer.SubtitleEndTime * parameterAsFloat3));
									SequencerCommandGestuarAuto.TipoDeRespuesta tipoDeRespuesta = base.GetParameter(5, string.Empty).ToEnum(SequencerCommandGestuarAuto.TipoDeRespuesta.Default);
									switch (tipoDeRespuesta)
									{
									case SequencerCommandGestuarAuto.TipoDeRespuesta.Default:
										break;
									case SequencerCommandGestuarAuto.TipoDeRespuesta.No:
										num = 1f;
										RegistroDeFuncionesDeGestos.Cabeza.overrrideNext = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.no);
										break;
									case SequencerCommandGestuarAuto.TipoDeRespuesta.Yes:
										num = 1f;
										RegistroDeFuncionesDeGestos.Cabeza.overrrideNext = new TipoDeGestoDeCabeza?(TipoDeGestoDeCabeza.si);
										break;
									default:
										throw new ArgumentOutOfRangeException(tipoDeRespuesta.ToString());
									}
									if (tipo <= Personalidad.Tipo.exhibicionista)
									{
										switch (tipo)
										{
										case Personalidad.Tipo.None:
										case Personalidad.Tipo.neutral:
											RegistroDeFuncionesDeGestos.EnojarSufrir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat * 0.75f, num * 0.75f, parameterAsFloat2 * 0.75f, num2);
											return;
										case Personalidad.Tipo.timido:
											SequencerCommandAsustar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num * 0.5f, parameterAsFloat2 * 0.5f, num2);
											return;
										case Personalidad.Tipo.neutral | Personalidad.Tipo.timido:
										case Personalidad.Tipo.neutral | Personalidad.Tipo.extrovertido:
										case Personalidad.Tipo.timido | Personalidad.Tipo.extrovertido:
										case Personalidad.Tipo.neutral | Personalidad.Tipo.timido | Personalidad.Tipo.extrovertido:
											break;
										case Personalidad.Tipo.extrovertido:
											SequencerCommandSonrreir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat * 0.66f, num * 0.66f, parameterAsFloat2 * 0.66f, num2);
											return;
										case Personalidad.Tipo.sumiso:
											SequencerCommandLamentar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num * 0.5f, parameterAsFloat2 * 0.5f, num2);
											return;
										default:
											if (tipo == Personalidad.Tipo.pervertido)
											{
												RegistroDeFuncionesDeGestos.EnojarSufrir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat * 0.5f, num * 0.5f, parameterAsFloat2 * 0.5f, num2);
												return;
											}
											if (tipo == Personalidad.Tipo.exhibicionista)
											{
												RegistroDeFuncionesDeGestos.EnojarSufrir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat * 0.5f, num * 0.5f, parameterAsFloat2 * 0.5f, num2);
												return;
											}
											break;
										}
									}
									else
									{
										if (tipo == Personalidad.Tipo.respetuoso)
										{
											RegistroDeFuncionesDeGestos.EnojarSufrir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat * 0.25f, num * 0.25f, parameterAsFloat2 * 0.25f, num2);
											return;
										}
										if (tipo == Personalidad.Tipo.grosero)
										{
											SequencerCommandEnojar.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num * 0.5f, parameterAsFloat2 * 0.5f, num2);
											return;
										}
										if (tipo == Personalidad.Tipo.honesto)
										{
											RegistroDeFuncionesDeGestos.EnojarSufrir.Gestuar(componentInChildren, componentInChildren2, componentInChildren3, parameterAsFloat, num, parameterAsFloat2, num2);
											return;
										}
									}
									throw new ArgumentOutOfRangeException(tipo.ToString());
								}
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

		// Token: 0x0600008C RID: 140 RVA: 0x00007434 File Offset: 0x00005634
		public void Update()
		{
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00007436 File Offset: 0x00005636
		public void OnDestroy()
		{
		}
	}
}
