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
	// Token: 0x02000086 RID: 134
	public class BulbEnemaAction : GrabbableToyFireActionWithPoser
	{
		// Token: 0x0600055D RID: 1373 RVA: 0x0001ED21 File Offset: 0x0001CF21
		protected override void AwakeUnityEvent()
		{
			Debug.LogError("si un hole llega al maximo de us capacidad de alvergar liquido, deberia botarlo de inmediato");
			base.AwakeUnityEvent();
			this.m_presionadaShape = new ShapeKey("presionada");
			if (this.m_emisor == null)
			{
				throw new ArgumentNullException("m_emisor", "m_emisor null reference.");
			}
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0001ED64 File Offset: 0x0001CF64
		protected override void OnToyStared()
		{
			SonidosGenericosSegunInputDual sonidosGenericosSegunInputDual = ColleccionDeReproductoresDeSonidoParaHoles.AddToPenisLiberadorTip(this.m_GrabbableToy.toy);
			sonidosGenericosSegunInputDual.altos.config.maxPitch *= 1.5f;
			sonidosGenericosSegunInputDual.altos.config.medPitch *= 1.5f;
			sonidosGenericosSegunInputDual.altos.config.minPitch *= 1.5f;
			sonidosGenericosSegunInputDual.bajos.config.maxPitch *= 1.25f;
			sonidosGenericosSegunInputDual.bajos.config.medPitch *= 1.25f;
			sonidosGenericosSegunInputDual.bajos.config.minPitch *= 1.25f;
			sonidosGenericosSegunInputDual.altos.config.maxVol *= 1.25f;
			sonidosGenericosSegunInputDual.altos.config.medVol *= 1.25f;
			sonidosGenericosSegunInputDual.altos.config.minVol *= 1.25f;
			sonidosGenericosSegunInputDual.bajos.config.maxVol *= 1.25f;
			sonidosGenericosSegunInputDual.bajos.config.medVol *= 1.25f;
			sonidosGenericosSegunInputDual.bajos.config.minVol *= 1.25f;
			this.m_sonidos = sonidosGenericosSegunInputDual;
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0001EEDC File Offset: 0x0001D0DC
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
								num8 = 5;
							}
							else
							{
								parteDelCuerpoHumano = ParteDelCuerpoHumano.ano;
								num8 = 25;
							}
						}
						else
						{
							parteDelCuerpoHumano = ParteDelCuerpoHumano.vag;
							num8 = 5;
						}
						float particleVolumenAproxV = EmisorDeSemenChain.GetParticleVolumenAproxV2(this.m_GrabbableToy.toy, ref this.m_emisor.next, this.m_emisor);
						float num9 = semenAcumulable.GetParticleVolumenAproxMililiters(TipoDeSemen.water) ?? particleVolumenAproxV;
						float num10 = particleVolumenAproxV / num9;
						int num11 = Mathf.CeilToInt((float)this.m_emisor.next.count * num10) * num8;
						semenAcumulable.Acumular(this.m_GrabbableToy.toy, TipoDeSemen.water, num11 * num5, particleVolumenAproxV, this.m_emisor.direccionDeEmision * Mathf.Max(this.m_emisor.next.maxVelocity, this.m_emisor.next.minVelocity));
						CharAi componentEnRoot = boneStretchedChain.GetComponentEnRoot(false);
						if (componentEnRoot != null)
						{
							componentEnRoot.RegistrarSemenSobre(parteDelCuerpoHumano, TipoDeSemen.water, Side.none, num11 * num5);
						}
					}
				}
			}
		}

		// Token: 0x04000345 RID: 837
		[SerializeField]
		private EmisorDeSemenChain m_emisor;

		// Token: 0x04000346 RID: 838
		[SerializeField]
		private float emissionDensity = 0.6f;

		// Token: 0x04000347 RID: 839
		private ShapeKey m_presionadaShape;

		// Token: 0x04000348 RID: 840
		private ISonidosSegunInput m_sonidos;

		// Token: 0x04000349 RID: 841
		private float m_emissionAccumulator;
	}
}
