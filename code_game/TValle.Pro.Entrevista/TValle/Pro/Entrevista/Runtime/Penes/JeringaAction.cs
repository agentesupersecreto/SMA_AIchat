using System;
using Assets.TValle.BeachGirl.Runtime.Semens;
using Assets._ReusableScripts.CuchiCuchi.Characters.Holes.Sonidos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Props;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Penes
{
	// Token: 0x02000088 RID: 136
	public class JeringaAction : GrabbablePropFireActionWithPoser
	{
		// Token: 0x0600058B RID: 1419 RVA: 0x00020660 File Offset: 0x0001E860
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_presionadaShape = new ShapeKey("NoLiquido");
			this.m_jeringa = base.GetComponent<Jeringa>();
			if (this.m_jeringa == null)
			{
				throw new ArgumentNullException("m_jeringa", "m_jeringa null reference.");
			}
			if (this.m_emisor == null)
			{
				throw new ArgumentNullException("m_emisor", "m_emisor null reference.");
			}
			if (this.m_liquidoRenderer == null)
			{
				throw new ArgumentNullException("m_liquidoRenderer", "m_liquidoRenderer null reference.");
			}
			if (this.m_pistonBone == null)
			{
				throw new ArgumentNullException("m_pistonBone", "m_pistonBone null reference.");
			}
			if (this.m_pistonStartBone == null)
			{
				throw new ArgumentNullException("m_pistonStartBone", "m_pistonStartBone null reference.");
			}
			if (this.m_pistonEndBone == null)
			{
				throw new ArgumentNullException("m_pistonEndBone", "m_pistonEndBone null reference.");
			}
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00020744 File Offset: 0x0001E944
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			SonidosGenericosSegunInputDual sonidosGenericosSegunInputDual = ColleccionDeReproductoresDeSonidoParaHoles.AddToPenisLiberadorTip(this.m_jeringa.tipBone, ConfiguracionGlobal.layersStatic.penes);
			sonidosGenericosSegunInputDual.altos.config.maxPitch *= 3f;
			sonidosGenericosSegunInputDual.altos.config.medPitch *= 3f;
			sonidosGenericosSegunInputDual.altos.config.minPitch *= 3f;
			sonidosGenericosSegunInputDual.bajos.config.maxPitch *= 0.75f;
			sonidosGenericosSegunInputDual.bajos.config.medPitch *= 0.75f;
			sonidosGenericosSegunInputDual.bajos.config.minPitch *= 0.75f;
			sonidosGenericosSegunInputDual.altos.config.maxVol *= 0.5f;
			sonidosGenericosSegunInputDual.altos.config.medVol *= 0.5f;
			sonidosGenericosSegunInputDual.altos.config.minVol *= 0.5f;
			sonidosGenericosSegunInputDual.bajos.config.maxVol *= 0.5f;
			sonidosGenericosSegunInputDual.bajos.config.medVol *= 0.5f;
			sonidosGenericosSegunInputDual.bajos.config.minVol *= 0.5f;
			this.m_sonidos = sonidosGenericosSegunInputDual;
			this.m_pistonBone.localPosition = this.m_pistonEndBone.localPosition;
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x000208E0 File Offset: 0x0001EAE0
		protected override void OnFireActionWeightUpdated(bool changed, bool increasing)
		{
			base.OnFireActionWeightUpdated(changed, increasing);
			this.m_presionadaShape.SetValor(this.m_liquidoRenderer, this.m_currentFireActionValue * 100f);
			this.m_pistonBone.localPosition = Vector3.Lerp(this.m_pistonEndBone.localPosition, this.m_pistonStartBone.localPosition, this.m_currentFireActionValue);
			if (changed && increasing)
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
					if (!this.m_jeringa.isPenetrating)
					{
						this.m_emisor.EmitirDesdePeneConOverflow(this.m_jeringa, this, num5 - 1, null, null);
						this.m_sonidos.ReproducirParaInput(1f);
						return;
					}
					this.m_sonidos.ReproducirParaInput(-1f);
				}
			}
		}

		// Token: 0x04000368 RID: 872
		[SerializeField]
		private EmisorDeSemenChain m_emisor;

		// Token: 0x04000369 RID: 873
		[SerializeField]
		private SkinnedMeshRenderer m_liquidoRenderer;

		// Token: 0x0400036A RID: 874
		[SerializeField]
		private Transform m_pistonBone;

		// Token: 0x0400036B RID: 875
		[SerializeField]
		private Transform m_pistonStartBone;

		// Token: 0x0400036C RID: 876
		[SerializeField]
		private Transform m_pistonEndBone;

		// Token: 0x0400036D RID: 877
		[SerializeField]
		private float emissionDensity = 0.6f;

		// Token: 0x0400036E RID: 878
		private ISonidosSegunInput m_sonidos;

		// Token: 0x0400036F RID: 879
		private ShapeKey m_presionadaShape;

		// Token: 0x04000370 RID: 880
		private Jeringa m_jeringa;

		// Token: 0x04000371 RID: 881
		private float m_emissionAccumulator;
	}
}
