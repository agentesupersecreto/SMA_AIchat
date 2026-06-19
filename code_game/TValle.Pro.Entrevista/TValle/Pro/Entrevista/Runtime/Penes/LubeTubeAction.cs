using System;
using Assets.TValle.BeachGirl.Runtime.Semens;
using Assets.TValle.BeachGirl.Sexual;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Holes.Sonidos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Penes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes
{
	// Token: 0x02000089 RID: 137
	public class LubeTubeAction : GrabbableToyFireActionWithPoser
	{
		// Token: 0x0600058F RID: 1423 RVA: 0x00020A74 File Offset: 0x0001EC74
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_presionadaShape = new ShapeKey("presionada");
			if (this.m_emisor == null)
			{
				throw new ArgumentNullException("m_emisor", "m_emisor null reference.");
			}
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00020AAC File Offset: 0x0001ECAC
		protected override void OnToyStared()
		{
			SonidosGenericosSegunInputDual sonidosGenericosSegunInputDual = ColleccionDeReproductoresDeSonidoParaHoles.AddToPenisLiberadorTip(this.m_GrabbableToy.toy);
			sonidosGenericosSegunInputDual.altos.config.maxPitch *= 0.75f;
			sonidosGenericosSegunInputDual.altos.config.medPitch *= 0.75f;
			sonidosGenericosSegunInputDual.altos.config.minPitch *= 0.75f;
			sonidosGenericosSegunInputDual.bajos.config.maxPitch *= 0.66f;
			sonidosGenericosSegunInputDual.bajos.config.medPitch *= 0.66f;
			sonidosGenericosSegunInputDual.bajos.config.minPitch *= 0.66f;
			sonidosGenericosSegunInputDual.altos.config.maxVol *= 1.25f;
			sonidosGenericosSegunInputDual.altos.config.medVol *= 1.25f;
			sonidosGenericosSegunInputDual.altos.config.minVol *= 1.25f;
			sonidosGenericosSegunInputDual.bajos.config.maxVol *= 1.25f;
			sonidosGenericosSegunInputDual.bajos.config.medVol *= 1.25f;
			sonidosGenericosSegunInputDual.bajos.config.minVol *= 1.25f;
			this.m_sonidos = sonidosGenericosSegunInputDual;
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00020C24 File Offset: 0x0001EE24
		protected override void OnFireActionWeightUpdated(bool changed, bool increasing)
		{
			base.OnFireActionWeightUpdated(changed, increasing);
			if (changed)
			{
				this.m_presionadaShape.SetValor(this.m_GrabbableToy.toy.penisLinearChain.penisLinearChainRenderer.skinnedMeshRenderer, this.m_currentFireActionValue * 100f);
				if (increasing)
				{
					float num = (this.m_emisor.next.minScale + this.m_emisor.next.maxScale) * 0.5f * this.m_emisor.next.scale;
					float num2 = 0.008f * num * (float)this.m_emisor.next.count;
					float num3 = (this.m_emisor.next.minVelocity + this.m_emisor.next.maxVelocity) * 0.5f;
					float num4 = num2 / num3;
					num4 /= this.m_currentFireActionSpeedMod * this.emissionDensity;
					num4 = Mathf.Max(num4, 0.0001f);
					this.m_emissionAccumulator += Time.deltaTime / num4;
					int num5 = Mathf.Min(Mathf.FloorToInt(this.m_emissionAccumulator), 5);
					this.m_emissionAccumulator -= (float)num5;
					if (num5 > 0)
					{
						BoneStretchedChain boneStretchedChain;
						if (!this.m_GrabbableToy.toy.IsPenetratingHole(out boneStretchedChain))
						{
							this.m_emisor.EmitirDesdePeneConOverflow(this.m_GrabbableToy.toy, this, num5 - 1, null, null);
							this.m_sonidos.ReproducirParaInput(1f);
							return;
						}
						float num6 = -Mathf.Clamp01(boneStretchedChain.profundidadPhysicsUnClampWeigth).OutPow(3f);
						if (this.m_sonidos != null)
						{
							float num7 = num6 * 0.6666667f + -Mathf.Clamp01(this.m_emisor.next.maxVelocity) * 0.33333334f;
							this.m_sonidos.ReproducirParaInput(num7);
						}
						ISemenAcumulable semenAcumulable;
						if (!boneStretchedChain.TryGetComponent<ISemenAcumulable>(out semenAcumulable))
						{
							Debug.LogError("hole: " + boneStretchedChain.name + " no puede acumular semen", this);
							return;
						}
						ParteDelCuerpoHumano parteDelCuerpoHumano;
						int num8;
						if (!(boneStretchedChain is IVagHole))
						{
							if (!(boneStretchedChain is IAnusHole))
							{
								if (!(boneStretchedChain is IBocaHole))
								{
									throw new ArgumentOutOfRangeException(boneStretchedChain.ToString());
								}
								parteDelCuerpoHumano = ParteDelCuerpoHumano.bocaInterno;
								num8 = 1;
							}
							else
							{
								parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
								num8 = 1;
							}
						}
						else
						{
							parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
							num8 = 1;
						}
						float particleVolumenAproxV = EmisorDeSemenChain.GetParticleVolumenAproxV2(this.m_GrabbableToy.toy, ref this.m_emisor.next, this.m_emisor);
						float num9 = semenAcumulable.GetParticleVolumenAproxMililiters(TipoDeSemen.lubricante) ?? particleVolumenAproxV;
						float num10 = particleVolumenAproxV / num9;
						int num11 = Mathf.CeilToInt((float)this.m_emisor.next.count * num10) * num8;
						semenAcumulable.Acumular(this.m_GrabbableToy.toy, TipoDeSemen.lubricante, num11 * num5, particleVolumenAproxV, this.m_emisor.direccionDeEmision * Mathf.Max(this.m_emisor.next.maxVelocity, this.m_emisor.next.minVelocity));
						CharAi componentEnRoot = boneStretchedChain.GetComponentEnRoot(false);
						if (componentEnRoot != null)
						{
							componentEnRoot.RegistrarSemenSobre(parteDelCuerpoHumano, TipoDeSemen.lubricante, Side.none, num11 * num5);
						}
					}
				}
			}
		}

		// Token: 0x04000372 RID: 882
		[SerializeField]
		private EmisorDeSemenChain m_emisor;

		// Token: 0x04000373 RID: 883
		[SerializeField]
		private float emissionDensity = 0.6f;

		// Token: 0x04000374 RID: 884
		private ShapeKey m_presionadaShape;

		// Token: 0x04000375 RID: 885
		private ISonidosSegunInput m_sonidos;

		// Token: 0x04000376 RID: 886
		private float m_emissionAccumulator;
	}
}
